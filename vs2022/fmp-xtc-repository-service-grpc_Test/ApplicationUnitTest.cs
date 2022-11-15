
using XTC.FMP.MOD.Repository.LIB.Proto;

public class ApplicationTest : ApplicationUnitTestBase
{
    public ApplicationTest(TestFixture _testFixture)
        : base(_testFixture)
    {
    }


    public override async Task CreateTest()
    {
        var request = new ApplicationCreateRequest();
        var response = await fixture_.getServiceApplication().Create(request, fixture_.context);
        Assert.Equal(0, response.Status.Code);
    }

    public override async Task UpdateTest()
    {
        var request = new ApplicationUpdateRequest();
        var response = await fixture_.getServiceApplication().Update(request, fixture_.context);
        Assert.Equal(0, response.Status.Code);
    }

    public override async Task RetrieveTest()
    {
        var request = new UuidRequest();
        var response = await fixture_.getServiceApplication().Retrieve(request, fixture_.context);
        Assert.Equal(0, response.Status.Code);
    }

    public override async Task DeleteTest()
    {
        var request = new UuidRequest();
        var response = await fixture_.getServiceApplication().Delete(request, fixture_.context);
        Assert.Equal(0, response.Status.Code);
    }

    public override async Task ListTest()
    {
        var request = new ApplicationListRequest();
        var response = await fixture_.getServiceApplication().List(request, fixture_.context);
        Assert.Equal(0, response.Status.Code);
    }

    public override async Task SearchTest()
    {
        var request = new ApplicationSearchRequest();
        var response = await fixture_.getServiceApplication().Search(request, fixture_.context);
        Assert.Equal(0, response.Status.Code);
    }

    public override async Task PrepareUploadTest()
    {
        var request = new UuidRequest();
        var response = await fixture_.getServiceApplication().PrepareUpload(request, fixture_.context);
        Assert.Equal(0, response.Status.Code);
    }

    public override async Task FlushUploadTest()
    {
        var request = new UuidRequest();
        var response = await fixture_.getServiceApplication().FlushUpload(request, fixture_.context);
        Assert.Equal(0, response.Status.Code);
    }

    public override async Task AddFlagTest()
    {
        var request = new FlagOperationRequest();
        var response = await fixture_.getServiceApplication().AddFlag(request, fixture_.context);
        Assert.Equal(0, response.Status.Code);
    }

    public override async Task RemoveFlagTest()
    {
        var request = new FlagOperationRequest();
        var response = await fixture_.getServiceApplication().RemoveFlag(request, fixture_.context);
        Assert.Equal(0, response.Status.Code);
    }

}
