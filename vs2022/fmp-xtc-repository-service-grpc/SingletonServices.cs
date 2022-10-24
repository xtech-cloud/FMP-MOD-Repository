
using Grpc.Core;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Threading.Tasks;
using XTC.FMP.MOD.Repository.LIB.Proto;

namespace XTC.FMP.MOD.Repository.App.Service
{
    public class SingletonServices
    {
        private MongoClient mongoClient_;
        private IMongoDatabase mongoDatabase_;
        private AgentDAO daoAgent_;
        private ModuleDAO daoModule_;
        private PluginDAO daoPlugin_;
        private MinIOClient clientMinIO_;


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <remarks>
        /// 参数为自动注入，支持多个参数，DatabaseSettings的注入点在Program.cs中，自定义设置可在MyProgram.PreBuild中注入
        /// </remarks>
        public SingletonServices(IOptions<DatabaseSettings> _databaseSettings, IOptions<MinIOSettings> _minioSettings)
        {
            mongoClient_ = new MongoClient(_databaseSettings.Value.ConnectionString);
            mongoDatabase_ = mongoClient_.GetDatabase(_databaseSettings.Value.DatabaseName);

            daoAgent_ = new AgentDAO(mongoDatabase_);
            daoModule_ = new ModuleDAO(mongoDatabase_);
            daoPlugin_ = new PluginDAO(mongoDatabase_);
            clientMinIO_ = new MinIOClient(_minioSettings);
        }

        public AgentDAO getAgentDAO()
        {
            return daoAgent_;
        }

        public ModuleDAO getModuleDAO()
        {
            return daoModule_;
        }

        public PluginDAO getPluginDAO()
        {
            return daoPlugin_;
        }

        public MinIOClient getMinioClient()
        {
            return clientMinIO_;
        }
    }
}
