namespace XTC.FMP.MOD.Repository.App.Service
{
    public class ApplicationEntity : Entity
    {
        public string? Org { get; set; }
        public string? Name { get; set; }
        public string? Version { get; set; }
        public string? Platform { get; set; }
        public long UpdatedAt { get; set; }
        public ulong Flags { get; set; }

        public ulong Size { get; set; }
        public string? Hash { get; set; }
    }
}
