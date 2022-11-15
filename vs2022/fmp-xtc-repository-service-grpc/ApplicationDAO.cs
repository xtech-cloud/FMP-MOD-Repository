using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace XTC.FMP.MOD.Repository.App.Service
{
    public class ApplicationDAO : MongoDAO<ApplicationEntity>
    {
        public ApplicationDAO(IMongoDatabase _mongoDatabase) : base(_mongoDatabase, "Application")
        {
        }

        public ApplicationEntity NewEmptyApplication(string? _org, string? _name)
        {
            var entity = new ApplicationEntity();
            entity.Org = _org;
            entity.Name = _name;
            entity.Version = "";
            entity.Platform = "";
            entity.Flags = 0;
            entity.Size = 0;
            entity.Hash = "";
            return entity;
        }

        public LIB.Proto.ApplicationEntity ToProtoEntity(ApplicationEntity _entity)
        {
            var entity = new LIB.Proto.ApplicationEntity();
            entity.Uuid = _entity.Uuid.ToString();
            entity.Org = _entity.Org;
            entity.Name = _entity.Name;
            entity.Version = _entity.Version;
            entity.Platform = _entity.Platform;
            entity.Flags = _entity.Flags;
            entity.UpdatedAt = _entity.UpdatedAt;
            string file = string.Format("{0}.{1}.zip", _entity.Org, _entity.Name);
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
        public virtual async Task<KeyValuePair<long, List<ApplicationEntity>>> SearchAsync(long _offset, long _count, string _org, string _name)
        {
            var filter = Builders<ApplicationEntity>.Filter.Where(x =>
                !(string.IsNullOrEmpty(_org) && string.IsNullOrEmpty(_name)) &&
                (string.IsNullOrWhiteSpace(_org) || (null != x.Org && x.Org.ToLower().Contains(_org.ToLower()))) &&
                (string.IsNullOrWhiteSpace(_name) || (null != x.Name && x.Name.ToLower().Contains(_name.ToLower())))
            );

            var found = collection_.Find(filter);

            var total = await found.CountDocumentsAsync();
            var Modules = await found.Skip((int)_offset).Limit((int)_count).ToListAsync();

            return new KeyValuePair<long, List<ApplicationEntity>>(total, Modules);
        }
    }
}
