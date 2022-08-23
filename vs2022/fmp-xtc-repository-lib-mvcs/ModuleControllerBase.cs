
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.26.3.  DO NOT EDIT!
//*************************************************************************************

using System.Threading;
using XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.Repository.LIB.Proto;

namespace XTC.FMP.MOD.Repository.LIB.MVCS
{
    /// <summary>
    /// Module控制层基类
    /// </summary>
    public class ModuleControllerBase : Controller
    {
        /// <summary>
        /// 带uid参数的构造函数
        /// </summary>
        /// <param name="_uid">实例化后的唯一识别码</param>
        /// <param name="_gid">直系的组的ID</param>
        public ModuleControllerBase(string _uid, string _gid) : base(_uid)
        {
            gid_ = _gid;
        }


        /// <summary>
        /// 更新Create的数据
        /// </summary>
        /// <param name="_status">直系状态</param>
        /// <param name="_response">Create的回复</param>
        public virtual void UpdateProtoCreate(ModuleModel.ModuleStatus? _status, UuidResponse _response, SynchronizationContext? _context)
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
        public virtual void UpdateProtoUpdate(ModuleModel.ModuleStatus? _status, UuidResponse _response, SynchronizationContext? _context)
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
        public virtual void UpdateProtoRetrieve(ModuleModel.ModuleStatus? _status, ModuleRetrieveResponse _response, SynchronizationContext? _context)
        {
            Error err = new Error(_response.Status.Code, _response.Status.Message);
            ModuleRetrieveResponseDTO? dto = new ModuleRetrieveResponseDTO(_response);
            getView()?.RefreshProtoRetrieve(err, dto, _context);
        }

        /// <summary>
        /// 更新Delete的数据
        /// </summary>
        /// <param name="_status">直系状态</param>
        /// <param name="_response">Delete的回复</param>
        public virtual void UpdateProtoDelete(ModuleModel.ModuleStatus? _status, UuidResponse _response, SynchronizationContext? _context)
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
        public virtual void UpdateProtoList(ModuleModel.ModuleStatus? _status, ModuleListResponse _response, SynchronizationContext? _context)
        {
            Error err = new Error(_response.Status.Code, _response.Status.Message);
            ModuleListResponseDTO? dto = new ModuleListResponseDTO(_response);
            getView()?.RefreshProtoList(err, dto, _context);
        }

        /// <summary>
        /// 更新Search的数据
        /// </summary>
        /// <param name="_status">直系状态</param>
        /// <param name="_response">Search的回复</param>
        public virtual void UpdateProtoSearch(ModuleModel.ModuleStatus? _status, ModuleListResponse _response, SynchronizationContext? _context)
        {
            Error err = new Error(_response.Status.Code, _response.Status.Message);
            ModuleListResponseDTO? dto = new ModuleListResponseDTO(_response);
            getView()?.RefreshProtoSearch(err, dto, _context);
        }

        /// <summary>
        /// 更新PrepareUpload的数据
        /// </summary>
        /// <param name="_status">直系状态</param>
        /// <param name="_response">PrepareUpload的回复</param>
        public virtual void UpdateProtoPrepareUpload(ModuleModel.ModuleStatus? _status, PrepareUploadResponse _response, SynchronizationContext? _context)
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
        public virtual void UpdateProtoFlushUpload(ModuleModel.ModuleStatus? _status, FlushUploadResponse _response, SynchronizationContext? _context)
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
        public virtual void UpdateProtoAddFlag(ModuleModel.ModuleStatus? _status, UuidResponse _response, SynchronizationContext? _context)
        {
            Error err = new Error(_response.Status.Code, _response.Status.Message);
            UuidResponseDTO? dto = new UuidResponseDTO(_response);
            getView()?.RefreshProtoAddFlag(err, dto, _context);
        }

        /// <summary>
        /// 更新RemoveFlag的数据
        /// </summary>
        /// <param name="_status">直系状态</param>
        /// <param name="_response">RemoveFlag的回复</param>
        public virtual void UpdateProtoRemoveFlag(ModuleModel.ModuleStatus? _status, UuidResponse _response, SynchronizationContext? _context)
        {
            Error err = new Error(_response.Status.Code, _response.Status.Message);
            UuidResponseDTO? dto = new UuidResponseDTO(_response);
            getView()?.RefreshProtoRemoveFlag(err, dto, _context);
        }


        /// <summary>
        /// 获取直系视图层
        /// </summary>
        /// <returns>视图层</returns>
        protected ModuleView? getView()
        {
            if(null == view_)
                view_ = findView(ModuleView.NAME + "." + gid_) as ModuleView;
            return view_;
        }

        /// <summary>
        /// 直系的MVCS的四个组件的组的ID
        /// </summary>
        protected string gid_ = "";

        /// <summary>
        /// 直系视图层
        /// </summary>
        private ModuleView? view_;
    }
}
