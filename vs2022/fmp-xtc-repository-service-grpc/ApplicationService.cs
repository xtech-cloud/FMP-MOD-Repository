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
    public class ApplicationService : ApplicationServiceBase
    {
        private readonly SingletonServices singletonServices_;

        public ApplicationService(SingletonServices _singletonServices)
        {
            singletonServices_ = _singletonServices;
        }

        protected override async Task<UuidResponse> safeCreate(ApplicationCreateRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Org, "Org");
            ArgumentChecker.CheckRequiredString(_request.Name, "Name");
            ArgumentChecker.CheckRequiredString(_request.Version, "Version");

            // 使用名字加上版本号的MD5值作为guid
            var guid = new Guid(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(_request.Org + "/" + _request.Name + "@" + _request.Version)));
            var Application = await singletonServices_.getApplicationDAO().GetAsync(guid.ToString());
            if (null != Application)
            {
                return new UuidResponse
                {
                    Status = new LIB.Proto.Status() { Code = 1, Message = "" },
                    Uuid = Application.Uuid.ToString(),
                };
            }
            Application = singletonServices_.getApplicationDAO().NewEmptyApplication(_request.Org, _request.Name);
            Application.Uuid = guid;
            Application.Org = _request.Org;
            Application.Name = _request.Name;
            Application.Version = _request.Version;
            Application.Platform = _request.Platform;
            Application.UpdatedAt = DateTimeOffset.Now.ToUnixTimeSeconds();
            Application.Flags = 0;
            await singletonServices_.getApplicationDAO().CreateAsync(Application);
            return new UuidResponse
            {
                Status = new LIB.Proto.Status() { Code = 0, Message = "" },
                Uuid = Application.Uuid.ToString(),
            };
        }

        protected override async Task<UuidResponse> safeUpdate(ApplicationUpdateRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");
            var Application = await singletonServices_.getApplicationDAO().GetAsync(_request.Uuid);
            if (null == Application)
            {
                return new UuidResponse { Status = new LIB.Proto.Status() { Code = 1, Message = "not found" } };
            }

            await singletonServices_.getApplicationDAO().UpdateAsync(_request.Uuid, Application);

            return new UuidResponse
            {
                Status = new LIB.Proto.Status() { },
                Uuid = Application.Uuid.ToString(),
            };
        }


        protected override async Task<ApplicationRetrieveResponse> safeRetrieve(UuidRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var Application = await singletonServices_.getApplicationDAO().GetAsync(_request.Uuid);
            if (null == Application)
            {
                return new ApplicationRetrieveResponse { Status = new LIB.Proto.Status() { Code = 1, Message = "not found" } };
            }
            return new ApplicationRetrieveResponse
            {
                Status = new LIB.Proto.Status() { },
                Application = singletonServices_.getApplicationDAO().ToProtoEntity(Application),
            };
        }

        protected override async Task<ApplicationListResponse> safeList(ApplicationListRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredNumber((int)_request.Count, "Count");

            var response = new ApplicationListResponse()
            {
                Status = new LIB.Proto.Status(),
            };

            response.Total = await singletonServices_.getApplicationDAO().CountAsync();
            var plugins = await singletonServices_.getApplicationDAO().ListAsync((int)_request.Offset, (int)_request.Count);
            foreach (var Application in plugins)
            {
                response.Applications.Add(singletonServices_.getApplicationDAO().ToProtoEntity(Application));
            }
            return response;
        }

        protected override async Task<ApplicationListResponse> safeSearch(ApplicationSearchRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredNumber((int)_request.Count, "Count");

            var result = await singletonServices_.getApplicationDAO().SearchAsync(_request.Offset, _request.Count, _request.Org, _request.Name);
            var response = new ApplicationListResponse() { Status = new LIB.Proto.Status() };
            response.Total = result.Key;
            foreach (var Application in result.Value)
            {
                response.Applications.Add(singletonServices_.getApplicationDAO().ToProtoEntity(Application));
            }
            return response;
        }

        protected override async Task<UuidResponse> safeDelete(UuidRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var Application = await singletonServices_.getApplicationDAO().GetAsync(_request.Uuid);
            if (null == Application)
            {
                return new UuidResponse() { Status = new LIB.Proto.Status() { Code = 1, Message = "not found" } };
            }

            await singletonServices_.getApplicationDAO().RemoveAsync(_request.Uuid);
            return new UuidResponse() { Status = new LIB.Proto.Status(), Uuid = _request.Uuid };
        }

        protected override async Task<PrepareUploadResponse> safePrepareUpload(UuidRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var Application = await singletonServices_.getApplicationDAO().GetAsync(_request.Uuid);
            if (null == Application)
            {
                return new PrepareUploadResponse() { Status = new LIB.Proto.Status() { Code = 1, Message = "Not Found" } };
            }

            if (Flags.HasFlag(Application.Flags, Flags.LOCK))
            {
                return new PrepareUploadResponse() { Status = new LIB.Proto.Status() { Code = 2, Message = "Locked" } };
            }

            string filename = string.Format("{0}.{1}.zip", Application.Org, Application.Name);
            string path = string.Format("applications/{0}/{1}@{2}/{3}/{4}", Application.Org, Application.Name, Application.Version, Application.Platform, filename);
            // 有效期1小时
            string url = await singletonServices_.getMinioClient().PresignedPutObject(path, 60 * 60);
            var response = new PrepareUploadResponse()
            {
                Status = new LIB.Proto.Status(),
                Uuid = Application.Uuid.ToString(),
            };
            response.Urls.Add(filename, url);
            return response;
        }

        protected override async Task<FlushUploadResponse> safeFlushUpload(UuidRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var Application = await singletonServices_.getApplicationDAO().GetAsync(_request.Uuid);
            if (null == Application)
            {
                return new FlushUploadResponse() { Status = new LIB.Proto.Status() { Code = 1, Message = "Not Found" } };
            }

            string filename = string.Format("{0}.{1}.zip", Application.Org, Application.Name);
            string path = string.Format("applications/{0}/{1}@{2}/{3}/{4}", Application.Org, Application.Name, Application.Version, Application.Platform, filename);
            var result = await singletonServices_.getMinioClient().StateObject(path);
            Application.Hash = result.Key;
            Application.Size = result.Value;

            Dictionary<string, object> manifests = new Dictionary<string, object>();
            var entries = new List<object>();
            Dictionary<string, object> entry = new Dictionary<string, object>();
            entry["file"] = filename;
            entry["size"] = result.Value;
            entry["hash"] = result.Key;
            entries.Add(entry);
            manifests["entries"] = entries;

            // 保存Manifest到存储中
            string manifestPath = string.Format("applications/{0}/{1}@{2}/{3}/manifest.json", Application.Org, Application.Name, Application.Version, Application.Platform);
            byte[] manifestJson = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(manifests));
            await singletonServices_.getMinioClient().PutObject(manifestPath, new MemoryStream(manifestJson));

            Application.Flags = Flags.AddFlag(Application.Flags, Flags.LOCK);
            await singletonServices_.getApplicationDAO().UpdateAsync(_request.Uuid, Application);
            var response = new FlushUploadResponse()
            {
                Status = new LIB.Proto.Status(),
                Uuid = Application.Uuid.ToString(),
            };
            response.Flags = Application.Flags;
            response.Hashs[filename] = Application.Hash;
            response.Sizes[filename] = Application.Size;

            return response;
        }

        protected override async Task<FlagOperationResponse> safeAddFlag(FlagOperationRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var Application = await singletonServices_.getApplicationDAO().GetAsync(_request.Uuid);
            if (null == Application)
            {
                return new FlagOperationResponse() { Status = new LIB.Proto.Status() { Code = 1, Message = "Not Found" } };
            }
            Application.Flags = Flags.AddFlag(Application.Flags, _request.Flag);
            await singletonServices_.getApplicationDAO().UpdateAsync(_request.Uuid, Application);
            return new FlagOperationResponse()
            {
                Status = new LIB.Proto.Status(),
                Uuid = _request.Uuid,
                Flags = Application.Flags,
            };
        }

        protected override async Task<FlagOperationResponse> safeRemoveFlag(FlagOperationRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var Application = await singletonServices_.getApplicationDAO().GetAsync(_request.Uuid);
            if (null == Application)
            {
                return new FlagOperationResponse() { Status = new LIB.Proto.Status() { Code = 1, Message = "Not Found" } };
            }
            Application.Flags = Flags.RemoveFlag(Application.Flags, _request.Flag);
            await singletonServices_.getApplicationDAO().UpdateAsync(_request.Uuid, Application);
            return new FlagOperationResponse()
            {
                Status = new LIB.Proto.Status(),
                Uuid = _request.Uuid,
                Flags = Application.Flags,
            };
        }
    }
}
