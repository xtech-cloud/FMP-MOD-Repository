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
    public class AgentService : AgentServiceBase
    {
        private readonly MinIOClient minioClient_;
        // 解开以下代码的注释，可支持数据库操作
        private readonly AgentDAO agentDAO_;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <remarks>
        /// 支持多个参数，均为自动注入，注入点位于MyProgram.PreBuild
        /// </remarks>
        /// <param name="_agentDAO">自动注入的数据操作对象</param>
        /// <param name="_minioClient">自动注入的MinIO客户端</param>
        public AgentService(AgentDAO _agentDAO, MinIOClient _minioClient)
        {
            agentDAO_ = _agentDAO;
            minioClient_ = _minioClient;
        }

        protected override async Task<UuidResponse> safeCreate(AgentCreateRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Org, "Org");
            ArgumentChecker.CheckRequiredString(_request.Name, "Name");
            ArgumentChecker.CheckRequiredString(_request.Version, "Version");

            // 使用名字加上版本号的MD5值作为guid
            var guid = new Guid(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(_request.Org + "/" + _request.Name + "@" + _request.Version)));
            var agent = await agentDAO_.GetAsync(guid.ToString());
            if (null != agent)
            {
                return new UuidResponse
                {
                    Status = new LIB.Proto.Status() { Code = 1, Message = "" },
                    Uuid = agent.Uuid.ToString(),
                };
            }
            agent = agentDAO_.NewEmptyAgent(_request.Org, _request.Name);
            agent.Uuid = guid;
            agent.Org = _request.Org;
            agent.Name = _request.Name;
            agent.Version = _request.Version;
            agent.UpdatedAt = DateTimeOffset.Now.ToUnixTimeSeconds();
            agent.Flags = 0;
            await agentDAO_.CreateAsync(agent);
            return new UuidResponse
            {
                Status = new LIB.Proto.Status() { Code = 0, Message = "" },
                Uuid = agent.Uuid.ToString(),
            };
        }

        protected override async Task<UuidResponse> safeUpdate(AgentUpdateRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");
            var agent = await agentDAO_.GetAsync(_request.Uuid);
            if (null == agent)
            {
                return new UuidResponse { Status = new LIB.Proto.Status() { Code = 1, Message = "not found" } };
            }

            agent.Port = _request.Port;
            await agentDAO_.UpdateAsync(_request.Uuid, agent);

            return new UuidResponse
            {
                Status = new LIB.Proto.Status() { },
                Uuid = agent.Uuid.ToString(),
            };
        }


        protected override async Task<AgentRetrieveResponse> safeRetrieve(UuidRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var agent = await agentDAO_.GetAsync(_request.Uuid);
            if (null == agent)
            {
                return new AgentRetrieveResponse { Status = new LIB.Proto.Status() { Code = 1, Message = "not found" } };
            }
            return new AgentRetrieveResponse
            {
                Status = new LIB.Proto.Status() { },
                Agent = agentDAO_.ToProtoEntity(agent),
            };
        }

        protected override async Task<AgentListResponse> safeList(AgentListRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredNumber((int)_request.Count, "Count");

            var response = new AgentListResponse()
            {
                Status = new LIB.Proto.Status(),
            };

            response.Total = await agentDAO_.CountAsync();
            var plugins = await agentDAO_.ListAsync((int)_request.Offset, (int)_request.Count);
            foreach (var agent in plugins)
            {
                response.Agents.Add(agentDAO_.ToProtoEntity(agent));
            }
            return response;
        }

        protected override async Task<AgentListResponse> safeSearch(AgentSearchRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredNumber((int)_request.Count, "Count");

            var result = await agentDAO_.SearchAsync(_request.Offset, _request.Count, _request.Org, _request.Name);
            var response = new AgentListResponse() { Status = new LIB.Proto.Status() };
            response.Total = result.Key;
            foreach (var agent in result.Value)
            {
                response.Agents.Add(agentDAO_.ToProtoEntity(agent));
            }
            return response;
        }

        protected override async Task<UuidResponse> safeDelete(UuidRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var agent = await agentDAO_.GetAsync(_request.Uuid);
            if (null == agent)
            {
                return new UuidResponse() { Status = new LIB.Proto.Status() { Code = 1, Message = "not found" } };
            }

            await agentDAO_.RemoveAsync(_request.Uuid);
            return new UuidResponse() { Status = new LIB.Proto.Status(), Uuid = _request.Uuid };
        }

        protected override async Task<PrepareUploadResponse> safePrepareUpload(UuidRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var agent = await agentDAO_.GetAsync(_request.Uuid);
            if (null == agent)
            {
                return new PrepareUploadResponse() { Status = new LIB.Proto.Status() { Code = 1, Message = "Not Found" } };
            }

            if (Flags.HasFlag(agent.Flags, Flags.LOCK))
            {
                return new PrepareUploadResponse() { Status = new LIB.Proto.Status() { Code = 2, Message = "Locked" } };
            }

            string filename = string.Format("{0}.{1}.zip", agent.Org, agent.Name);
            string path = string.Format("agents/{0}/{1}@{2}/{3}", agent.Org, agent.Name, agent.Version, filename);
            // 有效期1小时
            string url = await minioClient_.PresignedPutObject(path, 60 * 60);
            var response = new PrepareUploadResponse()
            {
                Status = new LIB.Proto.Status(),
                Uuid = agent.Uuid.ToString(),
            };
            response.Urls.Add(filename, url);
            return response;
        }

        protected override async Task<FlushUploadResponse> safeFlushUpload(UuidRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var agent = await agentDAO_.GetAsync(_request.Uuid);
            if (null == agent)
            {
                return new FlushUploadResponse() { Status = new LIB.Proto.Status() { Code = 1, Message = "Not Found" } };
            }

            string filename = string.Format("{0}.{1}.zip", agent.Org, agent.Name);
            string path = string.Format("agents/{0}/{1}@{2}/{3}", agent.Org, agent.Name, agent.Version, filename);
            var result = await minioClient_.StateObject(path);
            agent.Hash = result.Key;
            agent.Size = result.Value;

            Dictionary<string, object> manifests = new Dictionary<string, object>();
            var entries = new List<object>();
            Dictionary<string, object> entry = new Dictionary<string, object>();
            entry["file"] = filename;
            entry["size"] = result.Value;
            entry["hash"] = result.Key;
            entries.Add(entry);
            manifests["entries"] = entries;

            // 保存Manifest到存储中
            string manifestPath = string.Format("agents/{0}/{1}@{2}/manifest.json", agent.Org, agent.Name, agent.Version);
            byte[] manifestJson = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(manifests));
            await minioClient_.PutObject(manifestPath, new MemoryStream(manifestJson));

            if (!(agent.Version?.Equals("develop") ?? false))
            {
                agent.Flags = Flags.AddFlag(agent.Flags, Flags.LOCK);
            }
            await agentDAO_.UpdateAsync(_request.Uuid, agent);
            var response = new FlushUploadResponse()
            {
                Status = new LIB.Proto.Status(),
                Uuid = agent.Uuid.ToString(),
            };
            response.Flags = agent.Flags;
            response.Hashs[filename] = agent.Hash;
            response.Sizes[filename] = agent.Size;

            // 保存整个清单
            var allAgents = await agentDAO_.ListDevelopAsync();
            string repoManifestPath = "agents/manifest.json";
            byte[] repoManifestJson = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(allAgents));
            await minioClient_.PutObject(repoManifestPath, new MemoryStream(repoManifestJson));

            return response;
        }

        protected override async Task<FlagOperationResponse> safeAddFlag(FlagOperationRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var agent = await agentDAO_.GetAsync(_request.Uuid);
            if (null == agent)
            {
                return new FlagOperationResponse() { Status = new LIB.Proto.Status() { Code = 1, Message = "Not Found" } };
            }
            agent.Flags = Flags.AddFlag(agent.Flags, _request.Flag);
            await agentDAO_.UpdateAsync(_request.Uuid, agent);
            return new FlagOperationResponse()
            {
                Status = new LIB.Proto.Status(),
                Uuid = _request.Uuid,
                Flags = agent.Flags,
            };
        }

        protected override async Task<FlagOperationResponse> safeRemoveFlag(FlagOperationRequest _request, ServerCallContext _context)
        {
            ArgumentChecker.CheckRequiredString(_request.Uuid, "Uuid");

            var agent = await agentDAO_.GetAsync(_request.Uuid);
            if (null == agent)
            {
                return new FlagOperationResponse() { Status = new LIB.Proto.Status() { Code = 1, Message = "Not Found" } };
            }
            agent.Flags = Flags.RemoveFlag(agent.Flags, _request.Flag);
            await agentDAO_.UpdateAsync(_request.Uuid, agent);
            return new FlagOperationResponse()
            {
                Status = new LIB.Proto.Status(),
                Uuid = _request.Uuid,
                Flags = agent.Flags,
            };
        }
    }
}
