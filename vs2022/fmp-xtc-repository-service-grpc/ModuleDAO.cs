using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace XTC.FMP.MOD.Repository.App.Service
{
    public class ModuleDAO : DAO<ModuleEntity>
    {
        public ModuleDAO(IOptions<DatabaseSettings> _settings) : base(_settings, "Module")
        {
        }
        public ModuleEntity NewEmptyEntity(string? _org, string? _name)
        {
            var entity = new ModuleEntity();
            entity.SizeMap = new Dictionary<string, ulong>();
            entity.HashMap = new Dictionary<string, string>();
            entity.Cli = "";
            //proto
            {
                string file = string.Format("fmp-{0}-{1}-lib-proto.dll", _org?.ToLower(), _name?.ToLower());
                entity.HashMap[file] = "";
                entity.SizeMap[file] = 0;
            }
            //bridge
            {
                string file = string.Format("fmp-{0}-{1}-lib-bridge.dll", _org?.ToLower(), _name?.ToLower());
                entity.HashMap[file] = "";
                entity.SizeMap[file] = 0;
            }
            //mvcs
            {
                string file = string.Format("fmp-{0}-{1}-lib-mvcs.dll", _org?.ToLower(), _name?.ToLower());
                entity.HashMap[file] = "";
                entity.SizeMap[file] = 0;
            }
            //razor
            {
                string file = string.Format("fmp-{0}-{1}-lib-razor.dll", _org?.ToLower(), _name?.ToLower());
                entity.HashMap[file] = "";
                entity.SizeMap[file] = 0;
            }
            //Unity
            {
                string file = string.Format("{0}.FMP.MOD.{1}.LIB.Unity.dll", _org, _name);
                entity.HashMap[file] = "";
                entity.SizeMap[file] = 0;
            }
            //xml
            {
                string file = string.Format("{0}_{1}.xml", _org, _name);
                entity.HashMap[file] = "";
                entity.SizeMap[file] = 0;
            }
            //json
            {
                string file = string.Format("{0}_{1}.json", _org, _name);
                entity.HashMap[file] = "";
                entity.SizeMap[file] = 0;
            }
            //uab windows
            {
                string file = string.Format("{0}_{1}@windows.uab", _org?.ToLower(), _name?.ToLower());
                entity.HashMap[file] = "";
                entity.SizeMap[file] = 0;
            }
            //uab linux
            {
                string file = string.Format("{0}_{1}@linux.uab", _org?.ToLower(), _name?.ToLower());
                entity.HashMap[file] = "";
                entity.SizeMap[file] = 0;
            }
            //uab osx
            {
                string file = string.Format("{0}_{1}@osx.uab", _org?.ToLower(), _name?.ToLower());
                entity.HashMap[file] = "";
                entity.SizeMap[file] = 0;
            }
            //uab android
            {
                string file = string.Format("{0}_{1}@android.uab", _org?.ToLower(), _name?.ToLower());
                entity.HashMap[file] = "";
                entity.SizeMap[file] = 0;
            }
            //uab ios
            {
                string file = string.Format("{0}_{1}@ios.uab", _org?.ToLower(), _name?.ToLower());
                entity.HashMap[file] = "";
                entity.SizeMap[file] = 0;
            }
            //uab webgl
            {
                string file = string.Format("{0}_{1}@webgl.uab", _org?.ToLower(), _name?.ToLower());
                entity.HashMap[file] = "";
                entity.SizeMap[file] = 0;
            }
            return entity;
        }

        public LIB.Proto.ModuleEntity ToProtoEntity(ModuleEntity _entity)
        {
            var entity = new LIB.Proto.ModuleEntity();
            entity.Uuid = _entity.Uuid.ToString();
            entity.Org = _entity.Org;
            entity.Name = _entity.Name;
            entity.Version = _entity.Version;
            entity.Flags = _entity.Flags;
            entity.Cli = _entity.Cli;
            entity.UpdatedAt = _entity.UpdatedAt;

            //proto
            {
                string file = string.Format("fmp-{0}-{1}-lib-proto.dll", _entity.Org?.ToLower(), _entity.Name?.ToLower());
                ulong size = 0;
                _entity.SizeMap?.TryGetValue(file, out size);
                string? hash = "";
                _entity.HashMap?.TryGetValue(file, out hash);
                entity.Files.Add(new LIB.Proto.FileEntity()
                {
                    Name = file,
                    Hash = hash ?? "",
                    Size = size,
                });
            }
            //bridge
            {
                string file = string.Format("fmp-{0}-{1}-lib-bridge.dll", _entity.Org?.ToLower(), _entity.Name?.ToLower());
                ulong size = 0;
                _entity.SizeMap?.TryGetValue(file, out size);
                string? hash = "";
                _entity.HashMap?.TryGetValue(file, out hash);
                entity.Files.Add(new LIB.Proto.FileEntity()
                {
                    Name = file,
                    Hash = hash ?? "",
                    Size = size,
                });
            }
            //mvcs
            {
                string file = string.Format("fmp-{0}-{1}-lib-mvcs.dll", _entity.Org?.ToLower(), _entity.Name?.ToLower());
                ulong size = 0;
                _entity.SizeMap?.TryGetValue(file, out size);
                string? hash = "";
                _entity.HashMap?.TryGetValue(file, out hash);
                entity.Files.Add(new LIB.Proto.FileEntity()
                {
                    Name = file,
                    Hash = hash ?? "",
                    Size = size,
                });
            }
            //razor
            {
                string file = string.Format("fmp-{0}-{1}-lib-razor.dll", _entity.Org?.ToLower(), _entity.Name?.ToLower());
                ulong size = 0;
                _entity.SizeMap?.TryGetValue(file, out size);
                string? hash = "";
                _entity.HashMap?.TryGetValue(file, out hash);
                entity.Files.Add(new LIB.Proto.FileEntity()
                {
                    Name = file,
                    Hash = hash ?? "",
                    Size = size,
                });
            }
            //Unity
            {
                string file = string.Format("{0}.FMP.MOD.{1}.LIB.Unity.dll", _entity.Org, _entity.Name);
                ulong size = 0;
                _entity.SizeMap?.TryGetValue(file, out size);
                string? hash = "";
                _entity.HashMap?.TryGetValue(file, out hash);
                entity.Files.Add(new LIB.Proto.FileEntity()
                {
                    Name = file,
                    Hash = hash ?? "",
                    Size = size,
                });
            }
            //xml
            {
                string file = string.Format("{0}_{1}.xml", _entity.Org, _entity.Name);
                ulong size = 0;
                _entity.SizeMap?.TryGetValue(file, out size);
                string? hash = "";
                _entity.HashMap?.TryGetValue(file, out hash);
                entity.Files.Add(new LIB.Proto.FileEntity()
                {
                    Name = file,
                    Hash = hash ?? "",
                    Size = size,
                });
            }
            //json
            {
                string file = string.Format("{0}_{1}.json", _entity.Org, _entity.Name);
                ulong size = 0;
                _entity.SizeMap?.TryGetValue(file, out size);
                string? hash = "";
                _entity.HashMap?.TryGetValue(file, out hash);
                entity.Files.Add(new LIB.Proto.FileEntity()
                {
                    Name = file,
                    Hash = hash ?? "",
                    Size = size,
                });
            }
            //uab windows
            {
                string file = string.Format("{0}_{1}@windows.uab", _entity.Org?.ToLower(), _entity.Name?.ToLower());
                ulong size = 0;
                _entity.SizeMap?.TryGetValue(file, out size);
                string? hash = "";
                _entity.HashMap?.TryGetValue(file, out hash);
                entity.Files.Add(new LIB.Proto.FileEntity()
                {
                    Name = file,
                    Hash = hash ?? "",
                    Size = size,
                });
            }
            //uab osx
            {
                string file = string.Format("{0}_{1}@osx.uab", _entity.Org?.ToLower(), _entity.Name?.ToLower());
                ulong size = 0;
                _entity.SizeMap?.TryGetValue(file, out size);
                string? hash = "";
                _entity.HashMap?.TryGetValue(file, out hash);
                entity.Files.Add(new LIB.Proto.FileEntity()
                {
                    Name = file,
                    Hash = hash ?? "",
                    Size = size,
                });
            }
            //uab linux
            {
                string file = string.Format("{0}_{1}@linux.uab", _entity.Org?.ToLower(), _entity.Name?.ToLower());
                ulong size = 0;
                _entity.SizeMap?.TryGetValue(file, out size);
                string? hash = "";
                _entity.HashMap?.TryGetValue(file, out hash);
                entity.Files.Add(new LIB.Proto.FileEntity()
                {
                    Name = file,
                    Hash = hash ?? "",
                    Size = size,
                });
            }
            //uab android
            {
                string file = string.Format("{0}_{1}@android.uab", _entity.Org?.ToLower(), _entity.Name?.ToLower());
                ulong size = 0;
                _entity.SizeMap?.TryGetValue(file, out size);
                string? hash = "";
                _entity.HashMap?.TryGetValue(file, out hash);
                entity.Files.Add(new LIB.Proto.FileEntity()
                {
                    Name = file,
                    Hash = hash ?? "",
                    Size = size,
                });
            }
            //uab ios
            {
                string file = string.Format("{0}_{1}@ios.uab", _entity.Org?.ToLower(), _entity.Name?.ToLower());
                ulong size = 0;
                _entity.SizeMap?.TryGetValue(file, out size);
                string? hash = "";
                _entity.HashMap?.TryGetValue(file, out hash);
                entity.Files.Add(new LIB.Proto.FileEntity()
                {
                    Name = file,
                    Hash = hash ?? "",
                    Size = size,
                });
            }
            //uab webgl
            {
                string file = string.Format("{0}_{1}@webgl.uab", _entity.Org?.ToLower(), _entity.Name?.ToLower());
                ulong size = 0;
                _entity.SizeMap?.TryGetValue(file, out size);
                string? hash = "";
                _entity.HashMap?.TryGetValue(file, out hash);
                entity.Files.Add(new LIB.Proto.FileEntity()
                {
                    Name = file,
                    Hash = hash ?? "",
                    Size = size,
                });
            }
            return entity;
        }

        /// <summary>
        /// 条件取且
        /// </summary>
        /// <param name="_offset"></param>
        /// <param name="_count"></param>
        /// <param name="_name"></param>
        /// <returns></returns>
        public virtual async Task<KeyValuePair<long, List<ModuleEntity>>> SearchAsync(long _offset, long _count, string _org, string _name)
        {
            var filter = Builders<ModuleEntity>.Filter.Where(x =>
                !(string.IsNullOrEmpty(_org) && string.IsNullOrEmpty(_name)) &&
                (string.IsNullOrWhiteSpace(_org) || (null != x.Org && x.Org.ToLower().Contains(_org.ToLower()))) &&
                (string.IsNullOrWhiteSpace(_name) || (null != x.Name && x.Name.ToLower().Contains(_name.ToLower())))
            );

            var found = collection_.Find(filter);

            var total = await found.CountDocumentsAsync();
            var Modules = await found.Skip((int)_offset).Limit((int)_count).ToListAsync();

            return new KeyValuePair<long, List<ModuleEntity>>(total, Modules);
        }

    }
}
