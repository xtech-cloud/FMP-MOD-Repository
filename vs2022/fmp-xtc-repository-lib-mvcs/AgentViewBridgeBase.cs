
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.53.0.  DO NOT EDIT!
//*************************************************************************************

using System.Threading;
using System.Threading.Tasks;
using XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.Repository.LIB.Bridge;

namespace XTC.FMP.MOD.Repository.LIB.MVCS
{
    /// <summary>
    /// Agent的视图桥接层基类（协议部分）
    /// 处理UI的事件
    /// </summary>
    public class AgentViewBridgeBase : IAgentViewBridge
    {

        /// <summary>
        /// 直系服务层
        /// </summary>
        public AgentService? service { get; set; }


        /// <summary>
        /// 处理Create的提交
        /// </summary>
        /// <param name="_dto">AgentCreateRequest的数据传输对象</param>
        /// <returns>错误</returns>
        public virtual async Task<Error> OnCreateSubmit(IDTO _dto, object? _context)
        {
            AgentCreateRequestDTO? dto = _dto as AgentCreateRequestDTO;
            if(null == service)
            {
                return Error.NewNullErr("service is null");
            }
            return await service.CallCreate(dto?.Value, _context);
        }

        /// <summary>
        /// 处理Update的提交
        /// </summary>
        /// <param name="_dto">AgentUpdateRequest的数据传输对象</param>
        /// <returns>错误</returns>
        public virtual async Task<Error> OnUpdateSubmit(IDTO _dto, object? _context)
        {
            AgentUpdateRequestDTO? dto = _dto as AgentUpdateRequestDTO;
            if(null == service)
            {
                return Error.NewNullErr("service is null");
            }
            return await service.CallUpdate(dto?.Value, _context);
        }

        /// <summary>
        /// 处理Retrieve的提交
        /// </summary>
        /// <param name="_dto">UuidRequest的数据传输对象</param>
        /// <returns>错误</returns>
        public virtual async Task<Error> OnRetrieveSubmit(IDTO _dto, object? _context)
        {
            UuidRequestDTO? dto = _dto as UuidRequestDTO;
            if(null == service)
            {
                return Error.NewNullErr("service is null");
            }
            return await service.CallRetrieve(dto?.Value, _context);
        }

        /// <summary>
        /// 处理Delete的提交
        /// </summary>
        /// <param name="_dto">UuidRequest的数据传输对象</param>
        /// <returns>错误</returns>
        public virtual async Task<Error> OnDeleteSubmit(IDTO _dto, object? _context)
        {
            UuidRequestDTO? dto = _dto as UuidRequestDTO;
            if(null == service)
            {
                return Error.NewNullErr("service is null");
            }
            return await service.CallDelete(dto?.Value, _context);
        }

        /// <summary>
        /// 处理List的提交
        /// </summary>
        /// <param name="_dto">AgentListRequest的数据传输对象</param>
        /// <returns>错误</returns>
        public virtual async Task<Error> OnListSubmit(IDTO _dto, object? _context)
        {
            AgentListRequestDTO? dto = _dto as AgentListRequestDTO;
            if(null == service)
            {
                return Error.NewNullErr("service is null");
            }
            return await service.CallList(dto?.Value, _context);
        }

        /// <summary>
        /// 处理Search的提交
        /// </summary>
        /// <param name="_dto">AgentSearchRequest的数据传输对象</param>
        /// <returns>错误</returns>
        public virtual async Task<Error> OnSearchSubmit(IDTO _dto, object? _context)
        {
            AgentSearchRequestDTO? dto = _dto as AgentSearchRequestDTO;
            if(null == service)
            {
                return Error.NewNullErr("service is null");
            }
            return await service.CallSearch(dto?.Value, _context);
        }

        /// <summary>
        /// 处理PrepareUpload的提交
        /// </summary>
        /// <param name="_dto">UuidRequest的数据传输对象</param>
        /// <returns>错误</returns>
        public virtual async Task<Error> OnPrepareUploadSubmit(IDTO _dto, object? _context)
        {
            UuidRequestDTO? dto = _dto as UuidRequestDTO;
            if(null == service)
            {
                return Error.NewNullErr("service is null");
            }
            return await service.CallPrepareUpload(dto?.Value, _context);
        }

        /// <summary>
        /// 处理FlushUpload的提交
        /// </summary>
        /// <param name="_dto">UuidRequest的数据传输对象</param>
        /// <returns>错误</returns>
        public virtual async Task<Error> OnFlushUploadSubmit(IDTO _dto, object? _context)
        {
            UuidRequestDTO? dto = _dto as UuidRequestDTO;
            if(null == service)
            {
                return Error.NewNullErr("service is null");
            }
            return await service.CallFlushUpload(dto?.Value, _context);
        }

        /// <summary>
        /// 处理AddFlag的提交
        /// </summary>
        /// <param name="_dto">FlagOperationRequest的数据传输对象</param>
        /// <returns>错误</returns>
        public virtual async Task<Error> OnAddFlagSubmit(IDTO _dto, object? _context)
        {
            FlagOperationRequestDTO? dto = _dto as FlagOperationRequestDTO;
            if(null == service)
            {
                return Error.NewNullErr("service is null");
            }
            return await service.CallAddFlag(dto?.Value, _context);
        }

        /// <summary>
        /// 处理RemoveFlag的提交
        /// </summary>
        /// <param name="_dto">FlagOperationRequest的数据传输对象</param>
        /// <returns>错误</returns>
        public virtual async Task<Error> OnRemoveFlagSubmit(IDTO _dto, object? _context)
        {
            FlagOperationRequestDTO? dto = _dto as FlagOperationRequestDTO;
            if(null == service)
            {
                return Error.NewNullErr("service is null");
            }
            return await service.CallRemoveFlag(dto?.Value, _context);
        }


    }
}
