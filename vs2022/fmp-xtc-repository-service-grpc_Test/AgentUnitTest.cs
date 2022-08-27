using System.Security.Cryptography;
using System.Text;
using XTC.FMP.MOD.Repository.LIB.Proto;

public class AgentTest : AgentUnitTestBase
{
    public AgentTest(TestFixture _testFixture)
        : base(_testFixture)
    {
    }


    public override async Task CreateTest()
    {
        var reqCreate = new AgentCreateRequest();
        reqCreate.Org = "XTC";
        reqCreate.Name = "AgentTestCreae";
        reqCreate.Version = "1.0.0";
        var rspUuid = await fixture_.getServiceAgent().Create(reqCreate, fixture_.context);
        string uuid = rspUuid.Uuid;
        Assert.Equal(0, rspUuid.Status.Code);
        // 重复创建
        rspUuid = await fixture_.getServiceAgent().Create(reqCreate, fixture_.context);
        Assert.Equal(1, rspUuid.Status.Code);
        // 删除
        var rspDelete = await fixture_.getServiceAgent().Delete(new UuidRequest() { Uuid = uuid }, fixture_.context);
        Assert.Equal(0, rspDelete.Status.Code);
    }

    public override async Task UpdateTest()
    {
        var request = new AgentUpdateRequest();
        var response = await fixture_.getServiceAgent().Update(request, fixture_.context);
        Assert.Equal(0, response.Status.Code);
    }

    public override async Task RetrieveTest()
    {
        var reqCreate = new AgentCreateRequest();
        reqCreate.Org = "XTC";
        reqCreate.Name = "AgentTestRetrieve";
        reqCreate.Version = "1.0.0";
        var rspCreate = await fixture_.getServiceAgent().Create(reqCreate, fixture_.context);
        Assert.Equal(0, rspCreate.Status.Code);

        var reqRetrieve = new UuidRequest();
        // 不存在
        reqRetrieve.Uuid = Guid.NewGuid().ToString();
        var rspRetrieve = await fixture_.getServiceAgent().Retrieve(reqRetrieve, fixture_.context);
        Assert.Equal(1, rspRetrieve.Status.Code);
        //存在
        reqRetrieve.Uuid = rspCreate.Uuid;
        rspRetrieve = await fixture_.getServiceAgent().Retrieve(reqRetrieve, fixture_.context);
        Assert.Equal(0, rspRetrieve.Status.Code);
        // 删除
        var rspDelete = await fixture_.getServiceAgent().Delete(new UuidRequest() { Uuid = rspCreate.Uuid }, fixture_.context);
        Assert.Equal(0, rspDelete.Status.Code);
    }

    public override async Task DeleteTest()
    {
        // 创建
        var reqCreate = new AgentCreateRequest();
        reqCreate.Org = "XTC";
        reqCreate.Name = "TestDelete";
        reqCreate.Version = "1.0.0";
        var rspCreate = await fixture_.getServiceAgent().Create(reqCreate, fixture_.context);
        Assert.Equal(0, rspCreate.Status.Code);
        // 删除不存在的
        var reqUuid = new UuidRequest();
        reqUuid.Uuid = Guid.NewGuid().ToString();
        var rspDelete = await fixture_.getServiceAgent().Delete(reqUuid, fixture_.context);
        Assert.NotEqual(0, rspDelete.Status.Code);
        // 删除存在的
        reqUuid.Uuid = rspCreate.Uuid;
        rspDelete = await fixture_.getServiceAgent().Delete(reqUuid, fixture_.context);
        Assert.Equal(0, rspDelete.Status.Code);
    }

    public override async Task ListTest()
    {
        List<string> uuids = new List<string>();
        {
            for (int i = 0; i < 20; i++)
            {
                var request = new AgentCreateRequest();
                request.Org = "XTC";
                request.Name = "AgentTestList" + i.ToString();
                request.Version = "1.0.0";
                var response = await fixture_.getServiceAgent().Create(request, fixture_.context);
                Assert.Equal(0, response.Status.Code);
                uuids.Add(response.Uuid);
            }
        }
        {
            var request = new AgentListRequest();
            request.Offset = 0;
            request.Count = 10;
            var response = await fixture_.getServiceAgent().List(request, fixture_.context);
            Assert.Equal(20, response.Total);
            Assert.Equal(10, response.Agents.Count);
            request.Offset = 18;
            request.Count = 10;
            response = await fixture_.getServiceAgent().List(request, fixture_.context);
            Assert.Equal(20, response.Total);
            Assert.Equal(2, response.Agents.Count);
        }
        {
            foreach (var uuid in uuids)
            {
                var request = new UuidRequest();
                request.Uuid = uuid;
                var response = await fixture_.getServiceAgent().Delete(request, fixture_.context);
                Assert.Equal(0, response.Status.Code);
            }
        }

    }

    public override async Task SearchTest()
    {
        List<string> uuids = new List<string>();
        {
            for (int i = 0; i < 20; i++)
            {
                var request = new AgentCreateRequest();
                request.Org = "XTC";
                request.Name = "TestSearch" + (i + 1).ToString();
                request.Version = "1.0.0";
                var response = await fixture_.getServiceAgent().Create(request, fixture_.context);
                Assert.Equal(0, response.Status.Code);
                uuids.Add(response.Uuid);
            }
        }
        {
            var request = new AgentSearchRequest();
            request.Offset = 0;
            request.Count = 10;
            request.Name = "Search";
            var response = await fixture_.getServiceAgent().Search(request, fixture_.context);
            Assert.Equal(20, response.Total);
            Assert.Equal(10, response.Agents.Count);

            request.Offset = 0;
            request.Count = 5;
            request.Name = "arch1";
            response = await fixture_.getServiceAgent().Search(request, fixture_.context);
            // Search1, Search10 ... Search19
            Assert.Equal(11, response.Total);
            Assert.Equal(5, response.Agents.Count);

            request.Offset = 5;
            request.Count = 50;
            request.Name = "arch1";
            response = await fixture_.getServiceAgent().Search(request, fixture_.context);
            // Search1, Search10 ... Search19
            Assert.Equal(11, response.Total);
            Assert.Equal(6, response.Agents.Count);

            request.Offset = 0;
            request.Count = 50;
            request.Name = Guid.NewGuid().ToString();
            response = await fixture_.getServiceAgent().Search(request, fixture_.context);
            Assert.Empty(response.Agents);
            Assert.Equal(0, response.Total);
        }
        {
            foreach (var uuid in uuids)
            {
                var request = new UuidRequest();
                request.Uuid = uuid;
                var response = await fixture_.getServiceAgent().Delete(request, fixture_.context);
                Assert.Equal(0, response.Status.Code);
            }
        }

    }

    public override async Task PrepareUploadTest()
    {
        var reqCreate = new AgentCreateRequest();
        reqCreate.Org = "XTC";
        reqCreate.Name = "TestUpload";
        reqCreate.Version = "1.0.0";
        var rspCreate = await fixture_.getServiceAgent().Create(reqCreate, fixture_.context);
        Assert.Equal(0, rspCreate.Status.Code);

        var reqPrepare = new UuidRequest();
        reqPrepare.Uuid = rspCreate.Uuid;
        var rspPrepare = await fixture_.getServiceAgent().PrepareUpload(reqPrepare, fixture_.context);
        Assert.Equal(0, rspPrepare.Status.Code);

        var rspDelete = await fixture_.getServiceAgent().Delete(reqPrepare, fixture_.context);
        Assert.Equal(0, rspPrepare.Status.Code);

        rspPrepare = await fixture_.getServiceAgent().PrepareUpload(reqPrepare, fixture_.context);
        Assert.NotEqual(0, rspPrepare.Status.Code);

    }

    public override async Task FlushUploadTest()
    {
        var reqCreate = new AgentCreateRequest();
        reqCreate.Org = "XTC";
        reqCreate.Name = "TestFlush";
        reqCreate.Version = "1.0.0";
        var rspCreate = await fixture_.getServiceAgent().Create(reqCreate, fixture_.context);
        Assert.Equal(0, rspCreate.Status.Code);

        var reqFlush = new UuidRequest();
        reqFlush.Uuid = rspCreate.Uuid;
        var rspFlush = await fixture_.getServiceAgent().FlushUpload(reqFlush, fixture_.context);
        Assert.Equal(0, rspFlush.Status.Code);

        var rspDelete = await fixture_.getServiceAgent().Delete(reqFlush, fixture_.context);
        Assert.Equal(0, rspDelete.Status.Code);
    }

    public override async Task AddFlagTest()
    {
        // See FlagsTest
        await Task.Run(() =>
        {
        });
    }

    public override async Task RemoveFlagTest()
    {
        // See FlagsTest
        await Task.Run(() =>
        {
        });
    }


    [Fact]
    public async void FlagsTest()
    {
        var reqCreate = new AgentCreateRequest();
        reqCreate.Org = "XTC";
        reqCreate.Name = "TestFlag";
        reqCreate.Version = "1.0.0";
        var rspCreate = await fixture_.getServiceAgent().Create(reqCreate, fixture_.context);
        Assert.Equal(0, rspCreate.Status.Code);

        var reqFlag = new FlagOperationRequest();
        reqFlag.Uuid = rspCreate.Uuid;
        var reqRetrieve = new UuidRequest();
        reqRetrieve.Uuid = rspCreate.Uuid;

        reqFlag.Flag = 1;
        var rspFlag = await fixture_.getServiceAgent().AddFlag(reqFlag, fixture_.context);
        Assert.Equal(0, rspFlag.Status.Code);
        var rspRetrieve = await fixture_.getServiceAgent().Retrieve(reqRetrieve, fixture_.context);
        Assert.Equal<ulong>(1, rspRetrieve.Agent.Flags);

        reqFlag.Flag = 8;
        rspFlag = await fixture_.getServiceAgent().AddFlag(reqFlag, fixture_.context);
        Assert.Equal(0, rspFlag.Status.Code);
        rspRetrieve = await fixture_.getServiceAgent().Retrieve(reqRetrieve, fixture_.context);
        Assert.Equal<ulong>(1 | 8, rspRetrieve.Agent.Flags);

        rspFlag = await fixture_.getServiceAgent().RemoveFlag(reqFlag, fixture_.context);
        Assert.Equal(0, rspFlag.Status.Code);
        rspRetrieve = await fixture_.getServiceAgent().Retrieve(reqRetrieve, fixture_.context);
        Assert.Equal<ulong>(1, rspRetrieve.Agent.Flags);

        reqFlag.Flag = 1;
        rspFlag = await fixture_.getServiceAgent().RemoveFlag(reqFlag, fixture_.context);
        Assert.Equal(0, rspFlag.Status.Code);
        rspRetrieve = await fixture_.getServiceAgent().Retrieve(reqRetrieve, fixture_.context);
        Assert.Equal<ulong>(0, rspRetrieve.Agent.Flags);

        var reqDelete = new UuidRequest();
        reqDelete.Uuid = rspCreate.Uuid;
        var rspDelete = await fixture_.getServiceAgent().Delete(reqDelete, fixture_.context);
        Assert.Equal(0, rspDelete.Status.Code);
    }
}
