
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.30.0.  DO NOT EDIT!
//*************************************************************************************

using System.Threading;
using System.Threading.Tasks;
using Grpc.Net.Client;
using XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.Repository.LIB.Proto;

namespace XTC.FMP.MOD.Repository.LIB.MVCS
{
    /// <summary>
    /// Agent服务层基类
    /// </summary>
    public class AgentServiceBase : Service
    {
        public AgentServiceMock mock { get; set; } = new AgentServiceMock();
    
        /// <summary>
        /// 带uid参数的构造函数
        /// </summary>
        /// <param name="_uid">实例化后的唯一识别码</param>
        /// <param name="_gid">直系的组的ID</param>
        public AgentServiceBase(string _uid, string _gid) : base(_uid)
        {
            gid_ = _gid;
        }

        /// <summary>
        /// 注入GRPC通道
        /// </summary>
        /// <param name="_channel">GRPC通道</param>
        public void InjectGrpcChannel(GrpcChannel? _channel)
        {
            grpcChannel_ = _channel;
        }


        /// <summary>
        /// 调用Create
        /// </summary>
        /// <param name="_request">Create的请求</param>
        /// <returns>错误</returns>
        public virtual async Task<Error> CallCreate(AgentCreateRequest? _request, SynchronizationContext? _context)
        {
            getLogger()?.Trace("Call Create ...");
            if (null == _request)
            {
                return Error.NewNullErr("parameter:_request is null");
            }

            UuidResponse? response = null;
            if (null != mock.CallCreateDelegate)
            {
                getLogger()?.Trace("use mock ...");
                response = await mock.CallCreateDelegate(_request);
            }
            else
            {
                var client = getGrpcClient();
                if (null == client)
                {
                    return await Task.FromResult(Error.NewNullErr("client is null"));
                }
                response = await client.CreateAsync(_request);
            }

            getModel()?.UpdateProtoCreate(response, _context);
            return Error.OK;
        }

        /// <summary>
        /// 调用Update
        /// </summary>
        /// <param name="_request">Update的请求</param>
        /// <returns>错误</returns>
        public virtual async Task<Error> CallUpdate(AgentUpdateRequest? _request, SynchronizationContext? _context)
        {
            getLogger()?.Trace("Call Update ...");
            if (null == _request)
            {
                return Error.NewNullErr("parameter:_request is null");
            }

            UuidResponse? response = null;
            if (null != mock.CallUpdateDelegate)
            {
                getLogger()?.Trace("use mock ...");
                response = await mock.CallUpdateDelegate(_request);
            }
            else
            {
                var client = getGrpcClient();
                if (null == client)
                {
                    return await Task.FromResult(Error.NewNullErr("client is null"));
                }
                response = await client.UpdateAsync(_request);
            }

            getModel()?.UpdateProtoUpdate(response, _context);
            return Error.OK;
        }

        /// <summary>
        /// 调用Retrieve
        /// </summary>
        /// <param name="_request">Retrieve的请求</param>
        /// <returns>错误</returns>
        public virtual async Task<Error> CallRetrieve(UuidRequest? _request, SynchronizationContext? _context)
        {
            getLogger()?.Trace("Call Retrieve ...");
            if (null == _request)
            {
                return Error.NewNullErr("parameter:_request is null");
            }

            AgentRetrieveResponse? response = null;
            if (null != mock.CallRetrieveDelegate)
            {
                getLogger()?.Trace("use mock ...");
                response = await mock.CallRetrieveDelegate(_request);
            }
            else
            {
                var client = getGrpcClient();
                if (null == client)
                {
                    return await Task.FromResult(Error.NewNullErr("client is null"));
                }
                response = await client.RetrieveAsync(_request);
            }

            getModel()?.UpdateProtoRetrieve(response, _context);
            return Error.OK;
        }

        /// <summary>
        /// 调用Delete
        /// </summary>
        /// <param name="_request">Delete的请求</param>
        /// <returns>错误</returns>
        public virtual async Task<Error> CallDelete(UuidRequest? _request, SynchronizationContext? _context)
        {
            getLogger()?.Trace("Call Delete ...");
            if (null == _request)
            {
                return Error.NewNullErr("parameter:_request is null");
            }

            UuidResponse? response = null;
            if (null != mock.CallDeleteDelegate)
            {
                getLogger()?.Trace("use mock ...");
                response = await mock.CallDeleteDelegate(_request);
            }
            else
            {
                var client = getGrpcClient();
                if (null == client)
                {
                    return await Task.FromResult(Error.NewNullErr("client is null"));
                }
                response = await client.DeleteAsync(_request);
            }

            getModel()?.UpdateProtoDelete(response, _context);
            return Error.OK;
        }

        /// <summary>
        /// 调用List
        /// </summary>
        /// <param name="_request">List的请求</param>
        /// <returns>错误</returns>
        public virtual async Task<Error> CallList(AgentListRequest? _request, SynchronizationContext? _context)
        {
            getLogger()?.Trace("Call List ...");
            if (null == _request)
            {
                return Error.NewNullErr("parameter:_request is null");
            }

            AgentListResponse? response = null;
            if (null != mock.CallListDelegate)
            {
                getLogger()?.Trace("use mock ...");
                response = await mock.CallListDelegate(_request);
            }
            else
            {
                var client = getGrpcClient();
                if (null == client)
                {
                    return await Task.FromResult(Error.NewNullErr("client is null"));
                }
                response = await client.ListAsync(_request);
            }

            getModel()?.UpdateProtoList(response, _context);
            return Error.OK;
        }

        /// <summary>
        /// 调用Search
        /// </summary>
        /// <param name="_request">Search的请求</param>
        /// <returns>错误</returns>
        public virtual async Task<Error> CallSearch(AgentSearchRequest? _request, SynchronizationContext? _context)
        {
            getLogger()?.Trace("Call Search ...");
            if (null == _request)
            {
                return Error.NewNullErr("parameter:_request is null");
            }

            AgentListResponse? response = null;
            if (null != mock.CallSearchDelegate)
            {
                getLogger()?.Trace("use mock ...");
                response = await mock.CallSearchDelegate(_request);
            }
            else
            {
                var client = getGrpcClient();
                if (null == client)
                {
                    return await Task.FromResult(Error.NewNullErr("client is null"));
                }
                response = await client.SearchAsync(_request);
            }

            getModel()?.UpdateProtoSearch(response, _context);
            return Error.OK;
        }

        /// <summary>
        /// 调用PrepareUpload
        /// </summary>
        /// <param name="_request">PrepareUpload的请求</param>
        /// <returns>错误</returns>
        public virtual async Task<Error> CallPrepareUpload(UuidRequest? _request, SynchronizationContext? _context)
        {
            getLogger()?.Trace("Call PrepareUpload ...");
            if (null == _request)
            {
                return Error.NewNullErr("parameter:_request is null");
            }

            PrepareUploadResponse? response = null;
            if (null != mock.CallPrepareUploadDelegate)
            {
                getLogger()?.Trace("use mock ...");
                response = await mock.CallPrepareUploadDelegate(_request);
            }
            else
            {
                var client = getGrpcClient();
                if (null == client)
                {
                    return await Task.FromResult(Error.NewNullErr("client is null"));
                }
                response = await client.PrepareUploadAsync(_request);
            }

            getModel()?.UpdateProtoPrepareUpload(response, _context);
            return Error.OK;
        }

        /// <summary>
        /// 调用FlushUpload
        /// </summary>
        /// <param name="_request">FlushUpload的请求</param>
        /// <returns>错误</returns>
        public virtual async Task<Error> CallFlushUpload(UuidRequest? _request, SynchronizationContext? _context)
        {
            getLogger()?.Trace("Call FlushUpload ...");
            if (null == _request)
            {
                return Error.NewNullErr("parameter:_request is null");
            }

            FlushUploadResponse? response = null;
            if (null != mock.CallFlushUploadDelegate)
            {
                getLogger()?.Trace("use mock ...");
                response = await mock.CallFlushUploadDelegate(_request);
            }
            else
            {
                var client = getGrpcClient();
                if (null == client)
                {
                    return await Task.FromResult(Error.NewNullErr("client is null"));
                }
                response = await client.FlushUploadAsync(_request);
            }

            getModel()?.UpdateProtoFlushUpload(response, _context);
            return Error.OK;
        }

        /// <summary>
        /// 调用AddFlag
        /// </summary>
        /// <param name="_request">AddFlag的请求</param>
        /// <returns>错误</returns>
        public virtual async Task<Error> CallAddFlag(FlagOperationRequest? _request, SynchronizationContext? _context)
        {
            getLogger()?.Trace("Call AddFlag ...");
            if (null == _request)
            {
                return Error.NewNullErr("parameter:_request is null");
            }

            FlagOperationResponse? response = null;
            if (null != mock.CallAddFlagDelegate)
            {
                getLogger()?.Trace("use mock ...");
                response = await mock.CallAddFlagDelegate(_request);
            }
            else
            {
                var client = getGrpcClient();
                if (null == client)
                {
                    return await Task.FromResult(Error.NewNullErr("client is null"));
                }
                response = await client.AddFlagAsync(_request);
            }

            getModel()?.UpdateProtoAddFlag(response, _context);
            return Error.OK;
        }

        /// <summary>
        /// 调用RemoveFlag
        /// </summary>
        /// <param name="_request">RemoveFlag的请求</param>
        /// <returns>错误</returns>
        public virtual async Task<Error> CallRemoveFlag(FlagOperationRequest? _request, SynchronizationContext? _context)
        {
            getLogger()?.Trace("Call RemoveFlag ...");
            if (null == _request)
            {
                return Error.NewNullErr("parameter:_request is null");
            }

            FlagOperationResponse? response = null;
            if (null != mock.CallRemoveFlagDelegate)
            {
                getLogger()?.Trace("use mock ...");
                response = await mock.CallRemoveFlagDelegate(_request);
            }
            else
            {
                var client = getGrpcClient();
                if (null == client)
                {
                    return await Task.FromResult(Error.NewNullErr("client is null"));
                }
                response = await client.RemoveFlagAsync(_request);
            }

            getModel()?.UpdateProtoRemoveFlag(response, _context);
            return Error.OK;
        }


        /// <summary>
        /// 获取直系数据层
        /// </summary>
        /// <returns>数据层</returns>
        protected AgentModel? getModel()
        {
            if(null == model_)
                model_ = findModel(AgentModel.NAME + "." + gid_) as AgentModel;
            return model_;
        }

        /// <summary>
        /// 获取GRPC客户端
        /// </summary>
        /// <returns>GRPC客户端</returns>
        protected Agent.AgentClient? getGrpcClient()
        {
            if (null == grpcChannel_)
                return null;

            if(null == clientAgent_)
            {
                clientAgent_ = new Agent.AgentClient(grpcChannel_);
            }
            return clientAgent_;
        }

        /// <summary>
        /// 直系的MVCS的四个组件的组的ID
        /// </summary>
        protected string gid_ = "";

        /// <summary>
        /// GRPC客户端
        /// </summary>
        protected Agent.AgentClient? clientAgent_;

        /// <summary>
        /// GRPC通道
        /// </summary>
        protected GrpcChannel? grpcChannel_;

        /// <summary>
        /// 直系数据层
        /// </summary>
        private AgentModel? model_;
    }

}
