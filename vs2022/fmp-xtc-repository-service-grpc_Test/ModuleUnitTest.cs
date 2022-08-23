
using System.Security.Cryptography;
using System.Text;
using XTC.FMP.MOD.Repository.LIB.Proto;

public class ModuleTest : ModuleUnitTestBase
{
    public ModuleTest(TestFixture _testFixture)
        : base(_testFixture)
    {
    }


    public override async Task CreateTest()
    {
        var reqCreate = new ModuleCreateRequest();
        reqCreate.Org = "Test";
        reqCreate.Name = "TestCreae";
        reqCreate.Version = "1.0.0";
        var rspUuid = await fixture_.getServiceModule().Create(reqCreate, fixture_.context);
        string uuid = rspUuid.Uuid;
        Assert.Equal(0, rspUuid.Status.Code);
        // 重复创建
        rspUuid = await fixture_.getServiceModule().Create(reqCreate, fixture_.context);
        Assert.Equal(1, rspUuid.Status.Code);
        // 删除
        var rspDelete = await fixture_.getServiceModule().Delete(new UuidRequest() { Uuid = uuid }, fixture_.context);
        Assert.Equal(0, rspDelete.Status.Code);

    }

    public override async Task UpdateTest()
    {
        var request = new ModuleUpdateRequest();
        var response = await fixture_.getServiceModule().Update(request, fixture_.context);
        Assert.Equal(0, response.Status.Code);
    }

    public override async Task RetrieveTest()
    {
        var reqCreate = new ModuleCreateRequest();
        reqCreate.Org = "Test";
        reqCreate.Name = "TestRetrieve";
        reqCreate.Version = "1.0.0";
        var rspCreate = await fixture_.getServiceModule().Create(reqCreate, fixture_.context);
        Assert.Equal(0, rspCreate.Status.Code);

        var reqRetrieve = new UuidRequest();
        // 不存在
        reqRetrieve.Uuid = Guid.NewGuid().ToString();
        var rspRetrieve = await fixture_.getServiceModule().Retrieve(reqRetrieve, fixture_.context);
        Assert.Equal(1, rspRetrieve.Status.Code);
        //存在
        reqRetrieve.Uuid = new Guid(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes("Test/TestRetrieve@1.0.0"))).ToString();
        rspRetrieve = await fixture_.getServiceModule().Retrieve(reqRetrieve, fixture_.context);
        Assert.Equal(0, rspRetrieve.Status.Code);
        // 删除
        var rspDelete = await fixture_.getServiceModule().Delete(new UuidRequest() { Uuid = rspCreate.Uuid }, fixture_.context);
        Assert.Equal(0, rspDelete.Status.Code);

    }

    public override async Task DeleteTest()
    {
        // 创建
        var reqCreate = new ModuleCreateRequest();
        reqCreate.Org = "Test";
        reqCreate.Name = "TestDelete";
        reqCreate.Version = "1.0.0";
        var rspCreate = await fixture_.getServiceModule().Create(reqCreate, fixture_.context);
        Assert.Equal(0, rspCreate.Status.Code);
        // 删除不存在的
        var reqUuid = new UuidRequest();
        reqUuid.Uuid = Guid.NewGuid().ToString();
        var rspDelete = await fixture_.getServiceModule().Delete(reqUuid, fixture_.context);
        Assert.NotEqual(0, rspDelete.Status.Code);
        // 删除存在的
        reqUuid.Uuid = rspCreate.Uuid;
        rspDelete = await fixture_.getServiceModule().Delete(reqUuid, fixture_.context);
        Assert.Equal(0, rspDelete.Status.Code);

    }

    public override async Task ListTest()
    {
        {
            for (int i = 0; i < 20; i++)
            {
                var request = new ModuleCreateRequest();
                request.Org = "Test";
                request.Name = "TestList" + i.ToString();
                request.Version = "1.0.0";
                var response = await fixture_.getServiceModule().Create(request, fixture_.context);
                Assert.Equal(0, response.Status.Code);
            }
        }
        {
            var request = new ModuleListRequest();
            request.Offset = 0;
            request.Count = 10;
            var response = await fixture_.getServiceModule().List(request, fixture_.context);
            Assert.Equal(20, response.Total);
            Assert.Equal(10, response.Modules.Count);
            request.Offset = 18;
            request.Count = 10;
            response = await fixture_.getServiceModule().List(request, fixture_.context);
            Assert.Equal(20, response.Total);
            Assert.Equal(2, response.Modules.Count);
        }
        {
            for (int i = 0; i < 20; i++)
            {
                string uuid = new Guid(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(String.Format("Test/TestList{0}@1.0.0", i)))).ToString();
                var request = new UuidRequest();
                request.Uuid = uuid;
                var response = await fixture_.getServiceModule().Delete(request, fixture_.context);
                Assert.Equal(0, response.Status.Code);
            }
        }

    }

    public override async Task SearchTest()
    {
        {
            for (int i = 0; i < 20; i++)
            {
                var request = new ModuleCreateRequest();
                request.Org = "A";
                request.Name = "TestSearch" + (i + 1).ToString();
                request.Version = "1.0.0";
                var response = await fixture_.getServiceModule().Create(request, fixture_.context);
                Assert.Equal(0, response.Status.Code);
            }
            for (int i = 0; i < 20; i++)
            {
                var request = new ModuleCreateRequest();
                request.Org = "B";
                request.Name = "TestSearch" + (i + 1).ToString();
                request.Version = "1.0.0";
                var response = await fixture_.getServiceModule().Create(request, fixture_.context);
                Assert.Equal(0, response.Status.Code);
            }
        }
        {
            var request = new ModuleSearchRequest();

            var response = await fixture_.getServiceModule().Search(request, fixture_.context);
            Assert.Equal<long>(0, response.Total);
            Assert.Empty(response.Modules);

            request.Offset = 0;
            request.Count = 10;
            request.Name = "Search";
            response = await fixture_.getServiceModule().Search(request, fixture_.context);
            Assert.Equal(40, response.Total);
            Assert.Equal(10, response.Modules.Count);

            request.Offset = 0;
            request.Count = 5;
            request.Name = "arch1";
            response = await fixture_.getServiceModule().Search(request, fixture_.context);
            // Search1, Search10 ... Search19
            Assert.Equal(22, response.Total);
            Assert.Equal(5, response.Modules.Count);

            request.Offset = 5;
            request.Count = 50;
            request.Org = "A";
            request.Name = "arch1";
            response = await fixture_.getServiceModule().Search(request, fixture_.context);
            // Search1, Search10 ... Search19
            Assert.Equal(11, response.Total);
            Assert.Equal(6, response.Modules.Count);

            request.Offset = 0;
            request.Count = 50;
            request.Name = Guid.NewGuid().ToString();
            response = await fixture_.getServiceModule().Search(request, fixture_.context);
            Assert.Empty(response.Modules);
            Assert.Equal(0, response.Total);
        }
        {
            for (int i = 0; i < 20; i++)
            {
                var request = new UuidRequest();
                request.Uuid = new Guid(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(String.Format("A/TestSearch{0}@1.0.0", i + 1)))).ToString();
                var response = await fixture_.getServiceModule().Delete(request, fixture_.context);
                Assert.Equal(0, response.Status.Code);
            }
            for (int i = 0; i < 20; i++)
            {
                var request = new UuidRequest();
                request.Uuid = new Guid(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(String.Format("B/TestSearch{0}@1.0.0", i + 1)))).ToString();
                var response = await fixture_.getServiceModule().Delete(request, fixture_.context);
                Assert.Equal(0, response.Status.Code);
            }
        }


    }

    public override async Task PrepareUploadTest()
    {
        var reqCreate = new ModuleCreateRequest();
        reqCreate.Org = "Test";
        reqCreate.Name = "TestUpload";
        reqCreate.Version = "1.0.0";
        var rspCreate = await fixture_.getServiceModule().Create(reqCreate, fixture_.context);
        Assert.Equal(0, rspCreate.Status.Code);

        var reqPrepare = new UuidRequest();
        reqPrepare.Uuid = rspCreate.Uuid;
        var rspPrepare = await fixture_.getServiceModule().PrepareUpload(reqPrepare, fixture_.context);
        Assert.Equal(0, rspPrepare.Status.Code);

        var rspDelete = await fixture_.getServiceModule().Delete(reqPrepare, fixture_.context);
        Assert.Equal(0, rspPrepare.Status.Code);

        rspPrepare = await fixture_.getServiceModule().PrepareUpload(reqPrepare, fixture_.context);
        Assert.NotEqual(0, rspPrepare.Status.Code);
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
