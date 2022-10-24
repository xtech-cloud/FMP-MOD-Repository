using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace XTC.FMP.MOD.Repository.App.Service
{
    public class AgentDAO : MongoDAO<AgentEntity>
    {
        public AgentDAO(IMongoDatabase _mongoDatabase) : base(_mongoDatabase, "Agent")
        {
        }
        public AgentEntity NewEmptyAgent(string? _org, string? _name)
        {
            var entity = new AgentEntity();
            entity.Size = 0;
            entity.Hash = "";
            entity.Port = 0;
            entity.Pages = new string[0];
            return entity;
        }

        public LIB.Proto.AgentEntity ToProtoEntity(AgentEntity _entity)
        {
            var entity = new LIB.Proto.AgentEntity();
            entity.Uuid = _entity.Uuid.ToString();
            entity.Org = _entity.Org;
            entity.Name = _entity.Name;
            entity.Version = _entity.Version;
            entity.Port = _entity.Port;
            entity.Flags = _entity.Flags;
            entity.UpdatedAt = _entity.UpdatedAt;
            string file = string.Format("{0}.{1}.zip", _entity.Org, _entity.Name);
            foreach (var page in _entity.Pages ?? new string[0])
            {
                entity.Pages.Add(page);
            }
            entity.File = new LIB.Proto.FileEntity
            {
                Name = file,
                Hash = _entity.Hash ?? "",
                Size = _entity.Size,
            };
            return entity;
        }

        /// <summary>
        /// 条件取且
        /// </summary>
        /// <param name="_offset"></param>
        /// <param name="_count"></param>
        /// <param name="_name"></param>
        /// <returns></returns>
        public virtual async Task<KeyValuePair<long, List<AgentEntity>>> SearchAsync(long _offset, long _count, string _org, string _name)
        {
            var filter = Builders<AgentEntity>.Filter.Where(x =>
                !(string.IsNullOrEmpty(_org) && string.IsNullOrEmpty(_name)) &&
                (string.IsNullOrWhiteSpace(_org) || (null != x.Org && x.Org.ToLower().Contains(_org.ToLower()))) &&
                (string.IsNullOrWhiteSpace(_name) || (null != x.Name && x.Name.ToLower().Contains(_name.ToLower())))
            );

            var found = collection_.Find(filter);

            var total = await found.CountDocumentsAsync();
            var Modules = await found.Skip((int)_offset).Limit((int)_count).ToListAsync();

            return new KeyValuePair<long, List<AgentEntity>>(total, Modules);
        }

        /// <summary>
        /// 异步列举开发版本实体
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<AgentEntity>> ListDevelopAsync() =>
            await collection_.Find(x => (!string.IsNullOrEmpty(x.Version) && x.Version.Equals("develop"))).ToListAsync();
    }
}
