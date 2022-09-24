
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.37.0.  DO NOT EDIT!
//*************************************************************************************

using System.Threading;
using XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.Repository.LIB.Proto;

namespace XTC.FMP.MOD.Repository.LIB.MVCS
{
    /// <summary>
    /// Agent控制层基类
    /// </summary>
    public class AgentControllerBase : Controller
    {
        /// <summary>
        /// 带uid参数的构造函数
        /// </summary>
        /// <param name="_uid">实例化后的唯一识别码</param>
        /// <param name="_gid">直系的组的ID</param>
        public AgentControllerBase(string _uid, string _gid) : base(_uid)
        {
            gid_ = _gid;
        }


        /// <summary>
        /// 更新Create的数据
        /// </summary>
        /// <param name="_status">直系状态</param>
        /// <param name="_response">Create的回复</param>
        public virtual void UpdateProtoCreate(AgentModel.AgentStatus? _status, UuidResponse _response, object? _context)
        {
            Error err = new Error(_response.Status.Code, _response.Status.Message);
            UuidResponseDTO? dto = new UuidResponseDTO(_response);
            getView()?.RefreshProtoCreate(err, dto, _context);
        }

        /// <summary>
        /// 更新Update的数据
        /// </summary>
        /// <param name="_status">直系状态</param>
        /// <param name="_response">Update的回复</param>
        public virtual void UpdateProtoUpdate(AgentModel.AgentStatus? _status, UuidResponse _response, object? _context)
        {
            Error err = new Error(_response.Status.Code, _response.Status.Message);
            UuidResponseDTO? dto = new UuidResponseDTO(_response);
            getView()?.RefreshProtoUpdate(err, dto, _context);
        }

        /// <summary>
        /// 更新Retrieve的数据
        /// </summary>
        /// <param name="_status">直系状态</param>
        /// <param name="_response">Retrieve的回复</param>
        public virtual void UpdateProtoRetrieve(AgentModel.AgentStatus? _status, AgentRetrieveResponse _response, object? _context)
        {
            Error err = new Error(_response.Status.Code, _response.Status.Message);
            AgentRetrieveResponseDTO? dto = new AgentRetrieveResponseDTO(_response);
            getView()?.RefreshProtoRetrieve(err, dto, _context);
        }

        /// <summary>
        /// 更新Delete的数据
        /// </summary>
        /// <param name="_status">直系状态</param>
        /// <param name="_response">Delete的回复</param>
        public virtual void UpdateProtoDelete(AgentModel.AgentStatus? _status, UuidResponse _response, object? _context)
        {
            Error err = new Error(_response.Status.Code, _response.Status.Message);
            UuidResponseDTO? dto = new UuidResponseDTO(_response);
            getView()?.RefreshProtoDelete(err, dto, _context);
        }

        /// <summary>
        /// 更新List的数据
        /// </summary>
        /// <param name="_status">直系状态</param>
        /// <param name="_response">List的回复</param>
        public virtual void UpdateProtoList(AgentModel.AgentStatus? _status, AgentListResponse _response, object? _context)
        {
            Error err = new Error(_response.Status.Code, _response.Status.Message);
            AgentListResponseDTO? dto = new AgentListResponseDTO(_response);
            getView()?.RefreshProtoList(err, dto, _context);
        }

        /// <summary>
        /// 更新Search的数据
        /// </summary>
        /// <param name="_status">直系状态</param>
        /// <param name="_response">Search的回复</param>
        public virtual void UpdateProtoSearch(AgentModel.AgentStatus? _status, AgentListResponse _response, object? _context)
        {
            Error err = new Error(_response.Status.Code, _response.Status.Message);
            AgentListResponseDTO? dto = new AgentListResponseDTO(_response);
            getView()?.RefreshProtoSearch(err, dto, _context);
        }

        /// <summary>
        /// 更新PrepareUpload的数据
        /// </summary>
        /// <param name="_status">直系状态</param>
        /// <param name="_response">PrepareUpload的回复</param>
        public virtual void UpdateProtoPrepareUpload(AgentModel.AgentStatus? _status, PrepareUploadResponse _response, object? _context)
        {
            Error err = new Error(_response.Status.Code, _response.Status.Message);
            PrepareUploadResponseDTO? dto = new PrepareUploadResponseDTO(_response);
            getView()?.RefreshProtoPrepareUpload(err, dto, _context);
        }

        /// <summary>
        /// 更新FlushUpload的数据
        /// </summary>
        /// <param name="_status">直系状态</param>
        /// <param name="_response">FlushUpload的回复</param>
        public virtual void UpdateProtoFlushUpload(AgentModel.AgentStatus? _status, FlushUploadResponse _response, object? _context)
        {
            Error err = new Error(_response.Status.Code, _response.Status.Message);
            FlushUploadResponseDTO? dto = new FlushUploadResponseDTO(_response);
            getView()?.RefreshProtoFlushUpload(err, dto, _context);
        }

        /// <summary>
        /// 更新AddFlag的数据
        /// </summary>
        /// <param name="_status">直系状态</param>
        /// <param name="_response">AddFlag的回复</param>
        public virtual void UpdateProtoAddFlag(AgentModel.AgentStatus? _status, FlagOperationResponse _response, object? _context)
        {
            Error err = new Error(_response.Status.Code, _response.Status.Message);
            FlagOperationResponseDTO? dto = new FlagOperationResponseDTO(_response);
            getView()?.RefreshProtoAddFlag(err, dto, _context);
        }

        /// <summary>
        /// 更新RemoveFlag的数据
        /// </summary>
        /// <param name="_status">直系状态</param>
        /// <param name="_response">RemoveFlag的回复</param>
        public virtual void UpdateProtoRemoveFlag(AgentModel.AgentStatus? _status, FlagOperationResponse _response, object? _context)
        {
            Error err = new Error(_response.Status.Code, _response.Status.Message);
            FlagOperationResponseDTO? dto = new FlagOperationResponseDTO(_response);
            getView()?.RefreshProtoRemoveFlag(err, dto, _context);
        }


        /// <summary>
        /// 获取直系视图层
        /// </summary>
        /// <returns>视图层</returns>
        protected AgentView? getView()
        {
            if(null == view_)
                view_ = findView(AgentView.NAME + "." + gid_) as AgentView;
            return view_;
        }

        /// <summary>
        /// 直系的MVCS的四个组件的组的ID
        /// </summary>
        protected string gid_ = "";

        /// <summary>
        /// 直系视图层
        /// </summary>
        private AgentView? view_;
    }
}
