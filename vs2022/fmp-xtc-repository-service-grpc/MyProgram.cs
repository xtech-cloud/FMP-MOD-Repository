
using XTC.FMP.MOD.Repository.App.Service;

public static class MyProgram
{
    public static void PreBuild(WebApplicationBuilder? _builder)
    {
        _builder?.Services.Configure<MinIOSettings>(_builder.Configuration.GetSection("MinIO"));
        _builder?.Services.AddSingleton<PluginDAO>();
        _builder?.Services.AddSingleton<ModuleDAO>();
        _builder?.Services.AddSingleton<MinIOClient>();
    }

    public static void PreRun(WebApplication? _app)
    {
    }
}
