
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.37.0.  DO NOT EDIT!
//*************************************************************************************

public abstract class PluginUnitTestBase : IClassFixture<TestFixture>
{
    /// <summary>
    /// 测试上下文
    /// </summary>
    protected TestFixture fixture_ { get; set; }

    public PluginUnitTestBase(TestFixture _testFixture)
    {
        fixture_ = _testFixture;
    }


    [Fact]
    public abstract Task CreateTest();

    [Fact]
    public abstract Task UpdateTest();

    [Fact]
    public abstract Task RetrieveTest();

    [Fact]
    public abstract Task DeleteTest();

    [Fact]
    public abstract Task ListTest();

    [Fact]
    public abstract Task SearchTest();

    [Fact]
    public abstract Task PrepareUploadTest();

    [Fact]
    public abstract Task FlushUploadTest();

    [Fact]
    public abstract Task AddFlagTest();

    [Fact]
    public abstract Task RemoveFlagTest();

}
