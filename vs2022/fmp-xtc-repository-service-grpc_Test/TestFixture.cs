
using XTC.FMP.MOD.Repository.App.Service;

/// <summary>
/// 测试上下文，用于共享测试资源
/// </summary>
public class TestFixture : TestFixtureBase
{
    private SingletonServices singletonServices_;
    public TestFixture()
        : base()
    {
        singletonServices_ = new SingletonServices(new DatabaseOptions(), new MinIOOptions());
    }

    public override void Dispose()
    {
        base.Dispose();
    }

    protected override void newAgentService()
    {
        serviceAgent_ = new AgentService(singletonServices_);
    }

    protected override void newApplicationService()
    {
        throw new NotImplementedException();
    }

    protected override void newHealthyService()
    {
        serviceHealthy_ = new HealthyService();
    }

    protected override void newModuleService()
    {
        serviceModule_ = new ModuleService(singletonServices_);
    }

    protected override void newPluginService()
    {
        servicePlugin_ = new PluginService(singletonServices_);
    }

}
