using Grpc.Core;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using XTC.FMP.MOD.Repository.LIB.Proto;
using XTC.FMP.MOD.Repository.LIB.MVCS;
using Newtonsoft.Json;

namespace XTC.FMP.MOD.Repository.App.Service
{
    public class ModuleService : ModuleServiceBase
    {
        private readonly SingletonServices singletonServices_;

        public ModuleService(SingletonServices _singletonServices)
        {
            singletonServices_ = _singletonServices;
        }

        protected override async Task<UuidResponse> safeCreate(ModuleCreateRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Org, "Org");
            ArgumentChecker.CheckRequiredString(_request.Name, "Name");
            ArgumentChecker.CheckRequiredString(_request.Version, "Version");

            // 使用名字加上版本号的MD5值作为guid
            var guid = new Guid(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(_request.Org + "/" + _request.Name + "@" + _request.Version)));
            var module = await singletonServices_.getModuleDAO().GetAsync(guid.ToString());
            if (null != module)
            {
                return new UuidResponse
                {
                    Status = new LIB.Proto.Status() { Code = 1, Message = "" },
                    Uuid = module.Uuid.ToString(),
                };
            }
            module = singletonServices_.getModuleDAO().NewEmptyEntity(_request.Org, _request.Name);
            module.Uuid = guid;
            module.Org = _request.Org;
            module.Name = _request.Name;
            module.Version = _request.Version;
            module.UpdatedAt = DateTimeOffset.Now.ToUnixTimeSeconds();
            await singletonServices_.getModuleDAO().CreateAsync(module);
            return await Task.Run(() => new UuidResponse
            {
                Status = new LIB.Proto.Status() { Code = 0, Message = "" },
                Uuid = module.Uuid.ToString(),
            });
        }

        protected override async Task<UuidResponse> safeUpdate(ModuleUpdateRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");
            var module = await singletonServices_.getModuleDAO().GetAsync(_request.Uuid);
            if (null == module)
            {
                return new UuidResponse { Status = new LIB.Proto.Status() { Code = 1, Message = "not found" } };
            }

            module.Cli = _request.Cli;
            module.UpdatedAt = DateTimeOffset.Now.ToUnixTimeSeconds();
            await singletonServices_.getModuleDAO().UpdateAsync(_request.Uuid, module);

            return new UuidResponse
            {
                Status = new LIB.Proto.Status() { },
                Uuid = module.Uuid.ToString(),
            };
        }

        protected override async Task<ModuleRetrieveResponse> safeRetrieve(UuidRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var module = await singletonServices_.getModuleDAO().GetAsync(_request.Uuid);
            if (null == module)
            {
                return new ModuleRetrieveResponse { Status = new LIB.Proto.Status() { Code = 1, Message = "not found" } };
            }
            return new ModuleRetrieveResponse
            {
                Status = new LIB.Proto.Status() { },
                Module = singletonServices_.getModuleDAO().ToProtoEntity(module),
            };
        }

        protected override async Task<ModuleListResponse> safeList(ModuleListRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredNumber((int)_request.Count, "Count");

            var response = new ModuleListResponse()
            {
                Status = new LIB.Proto.Status(),
            };

            response.Total = await singletonServices_.getModuleDAO().CountAsync();
            var modules = await singletonServices_.getModuleDAO().ListAsync((int)_request.Offset, (int)_request.Count);
            foreach (var module in modules)
            {
                response.Modules.Add(singletonServices_.getModuleDAO().ToProtoEntity(module));
            }
            return response;
        }

        protected override async Task<ModuleListResponse> safeSearch(ModuleSearchRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredNumber((int)_request.Count, "Count");

            var result = await singletonServices_.getModuleDAO().SearchAsync(_request.Offset, _request.Count, _request.Org, _request.Name);
            var response = new ModuleListResponse() { Status = new LIB.Proto.Status() };
            response.Total = result.Key;
            foreach (var module in result.Value)
            {
                response.Modules.Add(singletonServices_.getModuleDAO().ToProtoEntity(module));
            }
            return response;
        }

        protected override async Task<UuidResponse> safeDelete(UuidRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var module = await singletonServices_.getModuleDAO().GetAsync(_request.Uuid);
            if (null == module)
            {
                return new UuidResponse() { Status = new LIB.Proto.Status() { Code = 1, Message = "not found" } };
            }

            await singletonServices_.getModuleDAO().RemoveAsync(_request.Uuid);
            return new UuidResponse() { Status = new LIB.Proto.Status(), Uuid = _request.Uuid };
        }

        protected override async Task<PrepareUploadResponse> safePrepareUpload(UuidRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var module = await singletonServices_.getModuleDAO().GetAsync(_request.Uuid);
            if (null == module)
            {
                return new PrepareUploadResponse() { Status = new LIB.Proto.Status() { Code = 1, Message = "Not Found" } };
            }

            if (Flags.HasFlag(module.Flags, Flags.LOCK))
            {
                return new PrepareUploadResponse() { Status = new LIB.Proto.Status() { Code = 2, Message = "Locked" } };
            }

            var response = new PrepareUploadResponse()
            {
                Status = new LIB.Proto.Status(),
            };

            if (null != module.HashMap)
            {
                foreach (var file in module.HashMap.Keys)
                {
                    string path = string.Format("modules/{0}/{1}@{2}/{3}", module.Org, module.Name, module.Version, file);
                    // 有效期1小时
                    string url = await singletonServices_.getMinioClient().PresignedPutObject(path, 60 * 60);
                    response.Urls.Add(file, url);
                }
            }
            return response;
        }

        protected override async Task<FlushUploadResponse> safeFlushUpload(UuidRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var module = await singletonServices_.getModuleDAO().GetAsync(_request.Uuid);
            if (null == module)
            {
                return new FlushUploadResponse() { Status = new LIB.Proto.Status() { Code = 1, Message = "Not Found" } };
            }

            Dictionary<string, object> manifests = new Dictionary<string, object>();
            var entries = new List<object>();
            if (null != module.HashMap)
            {
                foreach (var file in module.HashMap.Keys)
                {
                    string path = string.Format("modules/{0}/{1}@{2}/{3}", module.Org, module.Name, module.Version, file);
                    var result = await singletonServices_.getMinioClient().StateObject(path);
                    module.HashMap[file] = result.Key;
                    module.SizeMap![file] = result.Value;
                    Dictionary<string, object> entry = new Dictionary<string, object>();
                    entry["file"] = file;
                    entry["size"] = result.Value;
                    entry["hash"] = result.Key;
                    entries.Add(entry);
                }
            }
            manifests["entries"] = entries;
            // 保存Manifest到存储中
            string filepath = string.Format("modules/{0}/{1}@{2}/manifest.json", module.Org, module.Name, module.Version);
            byte[] manifestJson = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(manifests));
            await singletonServices_.getMinioClient().PutObject(filepath, new MemoryStream(manifestJson));
            if (!(module.Version?.Equals("develop") ?? false))
            {
                module.Flags = Flags.AddFlag(module.Flags, Flags.LOCK);
            }
            await singletonServices_.getModuleDAO().UpdateAsync(_request.Uuid, module);

            return new FlushUploadResponse()
            {
                Status = new LIB.Proto.Status(),
            };
        }

        protected override async Task<FlagOperationResponse> safeAddFlag(FlagOperationRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var module = await singletonServices_.getModuleDAO().GetAsync(_request.Uuid);
            if (null == module)
            {
                return new FlagOperationResponse() { Status = new LIB.Proto.Status() { Code = 1, Message = "Not Found" } };
            }
            module.Flags = Flags.AddFlag(module.Flags, _request.Flag);
            await singletonServices_.getModuleDAO().UpdateAsync(_request.Uuid, module);
            return new FlagOperationResponse()
            {
                Status = new LIB.Proto.Status(),
                Uuid = _request.Uuid,
                Flags = module.Flags,
            };
        }

        protected override async Task<FlagOperationResponse> safeRemoveFlag(FlagOperationRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var module = await singletonServices_.getModuleDAO().GetAsync(_request.Uuid);
            if (null == module)
            {
                return new FlagOperationResponse() { Status = new LIB.Proto.Status() { Code = 1, Message = "Not Found" } };
            }
            module.Flags = Flags.RemoveFlag(module.Flags, _request.Flag);
            await singletonServices_.getModuleDAO().UpdateAsync(_request.Uuid, module);
            return new FlagOperationResponse()
            {
                Status = new LIB.Proto.Status(),
                Uuid = _request.Uuid,
                Flags = module.Flags,
            };
        }
    }
}
