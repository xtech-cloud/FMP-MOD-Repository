using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace XTC.FMP.MOD.Repository.App.Service
{
    public class PluginDAO : MongoDAO<PluginEntity>
    {
        public PluginDAO(IMongoDatabase _mongoDatabase) : base(_mongoDatabase, "Plugin")
        {
        }

        /// <summary>
        /// 条件取且
        /// </summary>
        /// <param name="_offset"></param>
        /// <param name="_count"></param>
        /// <param name="_name"></param>
        /// <returns></returns>
        public virtual async Task<KeyValuePair<long, List<PluginEntity>>> SearchAsync(long _offset, long _count, string _name)
        {
            var filter = Builders<PluginEntity>.Filter.Where(x =>
                (!string.IsNullOrWhiteSpace(_name)) && (null != x.Name && x.Name.ToLower().Contains(_name.ToLower()))
            );

            var found = collection_.Find(filter);

            var total = await found.CountDocumentsAsync();
            var plugins = await found.Skip((int)_offset).Limit((int)_count).ToListAsync();

            return new KeyValuePair<long, List<PluginEntity>>(total, plugins);
        }

    }
}
