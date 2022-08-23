
using XTC.FMP.MOD.Repository.LIB.Proto;

public class ModuleTest : ModuleUnitTestBase
{
    public ModuleTest(TestFixture _testFixture)
        : base(_testFixture)
    {
    }


    public override async Task CreateTest()
    {
        var request = new ModuleCreateRequest();
        var response = await fixture_.getServiceModule().Create(request, fixture_.context);
        Assert.Equal(0, response.Status.Code);
    }

    public override async Task UpdateTest()
    {
        var request = new ModuleUpdateRequest();
        var response = await fixture_.getServiceModule().Update(request, fixture_.context);
        Assert.Equal(0, response.Status.Code);
    }

    public override async Task RetrieveTest()
    {
        var request = new UuidRequest();
        var response = await fixture_.getServiceModule().Retrieve(request, fixture_.context);
        Assert.Equal(0, response.Status.Code);
    }

    public override async Task DeleteTest()
    {
        var request = new UuidRequest();
        var response = await fixture_.getServiceModule().Delete(request, fixture_.context);
        Assert.Equal(0, response.Status.Code);
    }

    public override async Task ListTest()
    {
        var request = new ModuleListRequest();
        var response = await fixture_.getServiceModule().List(request, fixture_.context);
        Assert.Equal(0, response.Status.Code);
    }

    public override async Task SearchTest()
    {
        var request = new ModuleSearchRequest();
        var response = await fixture_.getServiceModule().Search(request, fixture_.context);
        Assert.Equal(0, response.Status.Code);
    }

    public override async Task PrepareUploadTest()
    {
        var request = new UuidRequest();
        var response = await fixture_.getServiceModule().PrepareUpload(request, fixture_.context);
        Assert.Equal(0, response.Status.Code);
    }

    public override async Task FlushUploadTest()
    {
        var request = new UuidRequest();
        var response = await fixture_.getServiceModule().FlushUpload(request, fixture_.context);
        Assert.Equal(0, response.Status.Code);
    }

    public override Task AddFlagTest()
    {
        throw new NotImplementedException();
    }

    public override Task RemoveFlagTest()
    {
        throw new NotImplementedException();
    }
}
