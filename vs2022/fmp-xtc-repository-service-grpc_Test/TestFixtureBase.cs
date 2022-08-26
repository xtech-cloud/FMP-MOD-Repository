
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.30.0.  DO NOT EDIT!
//*************************************************************************************

using XTC.FMP.MOD.Repository.App.Service;

public abstract class TestFixtureBase : IDisposable
{
    public TestServerCallContext context { get; set; }

    public TestFixtureBase()
    {
        context = TestServerCallContext.Create();
    }

    public virtual void Dispose()
    {

        var options = new DatabaseOptions();
        var mongoClient = new MongoDB.Driver.MongoClient(options.Value.ConnectionString);
        mongoClient.DropDatabase(options.Value.DatabaseName);

    }


    protected HealthyService? serviceHealthy_ { get; set; }

    public HealthyService getServiceHealthy()
    {
        if(null == serviceHealthy_)
        {
            newHealthyService();
        }
        return serviceHealthy_!;
    }

    /// <summary>
    /// 实例化服务
    /// </summary>
    /// <example>
    /// serviceHealthy_ = new HealthyService(new HealthyDAO(new DatabaseOptions()));
    /// </example>
    protected abstract void newHealthyService();

    protected ModuleService? serviceModule_ { get; set; }

    public ModuleService getServiceModule()
    {
        if(null == serviceModule_)
        {
            newModuleService();
        }
        return serviceModule_!;
    }

    /// <summary>
    /// 实例化服务
    /// </summary>
    /// <example>
    /// serviceModule_ = new ModuleService(new ModuleDAO(new DatabaseOptions()));
    /// </example>
    protected abstract void newModuleService();

    protected PluginService? servicePlugin_ { get; set; }

    public PluginService getServicePlugin()
    {
        if(null == servicePlugin_)
        {
            newPluginService();
        }
        return servicePlugin_!;
    }

    /// <summary>
    /// 实例化服务
    /// </summary>
    /// <example>
    /// servicePlugin_ = new PluginService(new PluginDAO(new DatabaseOptions()));
    /// </example>
    protected abstract void newPluginService();

}

