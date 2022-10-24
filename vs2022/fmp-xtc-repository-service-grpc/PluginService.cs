
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
    public class PluginService : PluginServiceBase
    {
        private readonly SingletonServices singletonServices_;

        public PluginService(SingletonServices _singletonServices)
        {
            singletonServices_ = _singletonServices;
        }

        protected override async Task<UuidResponse> safeCreate(PluginCreateRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Name, "Name");
            ArgumentChecker.CheckRequiredString(_request.Version, "Version");

            // 使用名字加上版本号的MD5值作为guid
            var guid = new Guid(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(_request.Name + "@" + _request.Version)));
            var plugin = await singletonServices_.getPluginDAO().GetAsync(guid.ToString());
            if (null != plugin)
            {
                return new UuidResponse
                {
                    Status = new LIB.Proto.Status() { Code = 1, Message = "" },
                    Uuid = plugin.Uuid.ToString(),
                };
            }
            plugin = new PluginEntity();
            plugin.Uuid = guid;
            plugin.Name = _request.Name;
            plugin.Version = _request.Version;
            plugin.UpdatedAt = DateTimeOffset.Now.ToUnixTimeSeconds();
            plugin.Flags = 0;
            await singletonServices_.getPluginDAO().CreateAsync(plugin);
            return new UuidResponse
            {
                Status = new LIB.Proto.Status() { Code = 0, Message = "" },
                Uuid = plugin.Uuid.ToString(),
            };
        }

        protected override async Task<PluginRetrieveResponse> safeRetrieve(UuidRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var plugin = await singletonServices_.getPluginDAO().GetAsync(_request.Uuid);
            if (null == plugin)
            {
                return new PluginRetrieveResponse { Status = new LIB.Proto.Status() { Code = 1, Message = "not found" } };
            }
            return new PluginRetrieveResponse
            {
                Status = new LIB.Proto.Status() { },
                Plugin = new LIB.Proto.PluginEntity()
                {
                    Uuid = plugin.Uuid.ToString(),
                    Name = plugin.Name,
                    Version = plugin.Version,
                    Flags = plugin.Flags,
                    UpdatedAt = plugin.UpdatedAt,
                    File = new FileEntity()
                    {
                        Name = plugin.Name + ".dll",
                        Size = plugin.Size,
                        Hash = plugin.Hash ?? "",
                    },
                }
            };
        }

        protected override async Task<PluginListResponse> safeList(PluginListRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredNumber((int)_request.Count, "Count");

            var response = new PluginListResponse()
            {
                Status = new LIB.Proto.Status(),
            };

            response.Total = await singletonServices_.getPluginDAO().CountAsync();
            var plugins = await singletonServices_.getPluginDAO().ListAsync((int)_request.Offset, (int)_request.Count);
            foreach (var plugin in plugins)
            {
                response.Plugins.Add(new LIB.Proto.PluginEntity
                {
                    Uuid = plugin.Uuid.ToString(),
                    Name = plugin.Name,
                    Version = plugin.Version,
                    Flags = plugin.Flags,
                    UpdatedAt = plugin.UpdatedAt,
                    File = new FileEntity()
                    {
                        Name = plugin.Name + ".dll",
                        Size = plugin.Size,
                        Hash = plugin.Hash ?? "",
                    },
                });
            }
            return response;
        }

        protected override async Task<PluginListResponse> safeSearch(PluginSearchRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredNumber((int)_request.Count, "Count");

            var result = await singletonServices_.getPluginDAO().SearchAsync(_request.Offset, _request.Count, _request.Name);
            var response = new PluginListResponse() { Status = new LIB.Proto.Status() };
            response.Total = result.Key;
            foreach (var plugin in result.Value)
            {
                response.Plugins.Add(new LIB.Proto.PluginEntity()
                {
                    Uuid = plugin.Uuid.ToString(),
                    Name = plugin.Name,
                    Version = plugin.Version,
                    Flags = plugin.Flags,
                    UpdatedAt = plugin.UpdatedAt,
                    File = new FileEntity()
                    {
                        Name = plugin.Name + ".dll",
                        Size = plugin.Size,
                        Hash = plugin.Hash ?? "",
                    },
                });
            }
            return response;
        }

        protected override async Task<UuidResponse> safeDelete(UuidRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var plugin = await singletonServices_.getPluginDAO().GetAsync(_request.Uuid);
            if (null == plugin)
            {
                return new UuidResponse() { Status = new LIB.Proto.Status() { Code = 1, Message = "not found" } };
            }

            await singletonServices_.getPluginDAO().RemoveAsync(_request.Uuid);
            return new UuidResponse() { Status = new LIB.Proto.Status(), Uuid = _request.Uuid };
        }

        protected override async Task<PrepareUploadResponse> safePrepareUpload(UuidRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var plugin = await singletonServices_.getPluginDAO().GetAsync(_request.Uuid);
            if (null == plugin)
            {
                return new PrepareUploadResponse() { Status = new LIB.Proto.Status() { Code = 1, Message = "Not Found" } };
            }

            if (Flags.HasFlag(plugin.Flags, Flags.LOCK))
            {
                return new PrepareUploadResponse() { Status = new LIB.Proto.Status() { Code = 2, Message = "Locked" } };
            }

            string filename = string.Format("{0}.dll", plugin.Name);
            string path = string.Format("plugins/{0}@{1}/{2}", plugin.Name, plugin.Version, filename);
            // 有效期1小时
            string url = await singletonServices_.getMinioClient().PresignedPutObject(path, 60 * 60);
            var response = new PrepareUploadResponse()
            {
                Status = new LIB.Proto.Status(),
                Uuid = plugin.Uuid.ToString(),
            };
            response.Urls.Add(filename, url);
            return response;
        }

        protected override async Task<FlushUploadResponse> safeFlushUpload(UuidRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var plugin = await singletonServices_.getPluginDAO().GetAsync(_request.Uuid);
            if (null == plugin)
            {
                return new FlushUploadResponse() { Status = new LIB.Proto.Status() { Code = 1, Message = "Not Found" } };
            }

            string filename = string.Format("{0}.dll", plugin.Name);
            string path = string.Format("plugins/{0}@{1}/{2}", plugin.Name, plugin.Version, filename);
            var result = await singletonServices_.getMinioClient().StateObject(path);
            plugin.Hash = result.Key;
            plugin.Size = result.Value;

            Dictionary<string, object> manifests = new Dictionary<string, object>();
            var entries = new List<object>();
            Dictionary<string, object> entry = new Dictionary<string, object>();
            entry["file"] = filename;
            entry["size"] = result.Value;
            entry["hash"] = result.Key;
            entries.Add(entry);
            manifests["entries"] = entries;
            // 保存Manifest到存储中
            string manifestPath = string.Format("plugins/{0}@{1}/manifest.json", plugin.Name, plugin.Version);
            byte[] manifestJson = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(manifests));
            await singletonServices_.getMinioClient().PutObject(manifestPath, new MemoryStream(manifestJson));

            if (!(plugin.Version?.Equals("develop") ?? false))
            {
                plugin.Flags = Flags.AddFlag(plugin.Flags, Flags.LOCK);
            }
            await singletonServices_.getPluginDAO().UpdateAsync(_request.Uuid, plugin);
            var response = new FlushUploadResponse()
            {
                Status = new LIB.Proto.Status(),
                Uuid = plugin.Uuid.ToString(),
            };
            response.Flags = plugin.Flags;
            response.Hashs[filename] = plugin.Hash;
            response.Sizes[filename] = plugin.Size;
            return response;
        }

        protected override async Task<FlagOperationResponse> safeAddFlag(FlagOperationRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var plugin = await singletonServices_.getPluginDAO().GetAsync(_request.Uuid);
            if (null == plugin)
            {
                return new FlagOperationResponse() { Status = new LIB.Proto.Status() { Code = 1, Message = "Not Found" } };
            }
            plugin.Flags = Flags.AddFlag(plugin.Flags, _request.Flag);
            await singletonServices_.getPluginDAO().UpdateAsync(_request.Uuid, plugin);
            return new FlagOperationResponse()
            {
                Status = new LIB.Proto.Status(),
                Uuid = _request.Uuid,
                Flags = plugin.Flags,
            };
        }

        protected override async Task<FlagOperationResponse> safeRemoveFlag(FlagOperationRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var plugin = await singletonServices_.getPluginDAO().GetAsync(_request.Uuid);
            if (null == plugin)
            {
                return new FlagOperationResponse() { Status = new LIB.Proto.Status() { Code = 1, Message = "Not Found" } };
            }
            plugin.Flags = Flags.RemoveFlag(plugin.Flags, _request.Flag);
            await singletonServices_.getPluginDAO().UpdateAsync(_request.Uuid, plugin);
            return new FlagOperationResponse()
            {
                Status = new LIB.Proto.Status(),
                Uuid = _request.Uuid,
                Flags = plugin.Flags,
            };
        }
    }
}
