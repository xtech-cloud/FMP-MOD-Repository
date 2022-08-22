namespace XTC.FMP.MOD.Repository.App.Service
{
    public class PluginEntity : Entity
    {
        public string? Name { get; set; }
        public string? Version { get; set; }
        public ulong Size { get; set; }
        public string? Hash { get; set; }
        public long UpdatedAt { get; set; }
    }
}
