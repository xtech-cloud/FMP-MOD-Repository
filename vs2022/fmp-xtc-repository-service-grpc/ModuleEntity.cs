namespace XTC.FMP.MOD.Repository.App.Service
{
    public class ModuleEntity : Entity
    {
        public string? Org { get; set; }
        public string? Name { get; set; }
        public string? Version { get; set; }
        public long UpdatedAt { get; set; }
        public ulong Flags { get; set; }

        public Dictionary<string, ulong>? SizeMap{ get; set; }
        public Dictionary<string, string>? HashMap{ get; set; }
    }
}
