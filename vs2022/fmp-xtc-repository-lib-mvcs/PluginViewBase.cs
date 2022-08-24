
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.28.2.  DO NOT EDIT!
//*************************************************************************************

using System.Threading;
using XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.Repository.LIB.Bridge;

namespace XTC.FMP.MOD.Repository.LIB.MVCS
{
    /// <summary>
    /// Plugin视图层基类
    /// </summary>
    public class PluginViewBase : View
    {
        /// <summary>
        /// 带uid参数的构造函数
        /// </summary>
        /// <param name="_uid">实例化后的唯一识别码</param>
        /// <param name="_gid">直系的组的ID</param>
        public PluginViewBase(string _uid, string _gid) : base(_uid)
        {
            gid_ = _gid;
        }


        /// <summary>
        /// 刷新Create的数据
        /// </summary>
        /// <param name="_err">错误</param>
        /// <param name="_dto">UuidResponse的数据传输对象</param>
        public virtual void RefreshProtoCreate(Error _err, UuidResponseDTO _dto, SynchronizationContext? _context)
        {
            var bridge = getFacade()?.getUiBridge() as IPluginUiBridge; 
            if (!Error.IsOK(_err))
            {
                bridge?.Alert(string.Format("errcode_Create_{0}", _err.getCode()), _err.getMessage(), _context);
                return;
            }
            bridge?.RefreshCreate(_dto, _context);
        }

        /// <summary>
        /// 刷新Update的数据
        /// </summary>
        /// <param name="_err">错误</param>
        /// <param name="_dto">UuidResponse的数据传输对象</param>
        public virtual void RefreshProtoUpdate(Error _err, UuidResponseDTO _dto, SynchronizationContext? _context)
        {
            var bridge = getFacade()?.getUiBridge() as IPluginUiBridge; 
            if (!Error.IsOK(_err))
            {
                bridge?.Alert(string.Format("errcode_Update_{0}", _err.getCode()), _err.getMessage(), _context);
                return;
            }
            bridge?.RefreshUpdate(_dto, _context);
        }

        /// <summary>
        /// 刷新Retrieve的数据
        /// </summary>
        /// <param name="_err">错误</param>
        /// <param name="_dto">PluginRetrieveResponse的数据传输对象</param>
        public virtual void RefreshProtoRetrieve(Error _err, PluginRetrieveResponseDTO _dto, SynchronizationContext? _context)
        {
            var bridge = getFacade()?.getUiBridge() as IPluginUiBridge; 
            if (!Error.IsOK(_err))
            {
                bridge?.Alert(string.Format("errcode_Retrieve_{0}", _err.getCode()), _err.getMessage(), _context);
                return;
            }
            bridge?.RefreshRetrieve(_dto, _context);
        }

        /// <summary>
        /// 刷新Delete的数据
        /// </summary>
        /// <param name="_err">错误</param>
        /// <param name="_dto">UuidResponse的数据传输对象</param>
        public virtual void RefreshProtoDelete(Error _err, UuidResponseDTO _dto, SynchronizationContext? _context)
        {
            var bridge = getFacade()?.getUiBridge() as IPluginUiBridge; 
            if (!Error.IsOK(_err))
            {
                bridge?.Alert(string.Format("errcode_Delete_{0}", _err.getCode()), _err.getMessage(), _context);
                return;
            }
            bridge?.RefreshDelete(_dto, _context);
        }

        /// <summary>
        /// 刷新List的数据
        /// </summary>
        /// <param name="_err">错误</param>
        /// <param name="_dto">PluginListResponse的数据传输对象</param>
        public virtual void RefreshProtoList(Error _err, PluginListResponseDTO _dto, SynchronizationContext? _context)
        {
            var bridge = getFacade()?.getUiBridge() as IPluginUiBridge; 
            if (!Error.IsOK(_err))
            {
                bridge?.Alert(string.Format("errcode_List_{0}", _err.getCode()), _err.getMessage(), _context);
                return;
            }
            bridge?.RefreshList(_dto, _context);
        }

        /// <summary>
        /// 刷新Search的数据
        /// </summary>
        /// <param name="_err">错误</param>
        /// <param name="_dto">PluginListResponse的数据传输对象</param>
        public virtual void RefreshProtoSearch(Error _err, PluginListResponseDTO _dto, SynchronizationContext? _context)
        {
            var bridge = getFacade()?.getUiBridge() as IPluginUiBridge; 
            if (!Error.IsOK(_err))
            {
                bridge?.Alert(string.Format("errcode_Search_{0}", _err.getCode()), _err.getMessage(), _context);
                return;
            }
            bridge?.RefreshSearch(_dto, _context);
        }

        /// <summary>
        /// 刷新PrepareUpload的数据
        /// </summary>
        /// <param name="_err">错误</param>
        /// <param name="_dto">PrepareUploadResponse的数据传输对象</param>
        public virtual void RefreshProtoPrepareUpload(Error _err, PrepareUploadResponseDTO _dto, SynchronizationContext? _context)
        {
            var bridge = getFacade()?.getUiBridge() as IPluginUiBridge; 
            if (!Error.IsOK(_err))
            {
                bridge?.Alert(string.Format("errcode_PrepareUpload_{0}", _err.getCode()), _err.getMessage(), _context);
                return;
            }
            bridge?.RefreshPrepareUpload(_dto, _context);
        }

        /// <summary>
        /// 刷新FlushUpload的数据
        /// </summary>
        /// <param name="_err">错误</param>
        /// <param name="_dto">FlushUploadResponse的数据传输对象</param>
        public virtual void RefreshProtoFlushUpload(Error _err, FlushUploadResponseDTO _dto, SynchronizationContext? _context)
        {
            var bridge = getFacade()?.getUiBridge() as IPluginUiBridge; 
            if (!Error.IsOK(_err))
            {
                bridge?.Alert(string.Format("errcode_FlushUpload_{0}", _err.getCode()), _err.getMessage(), _context);
                return;
            }
            bridge?.RefreshFlushUpload(_dto, _context);
        }

        /// <summary>
        /// 刷新AddFlag的数据
        /// </summary>
        /// <param name="_err">错误</param>
        /// <param name="_dto">FlagOperationResponse的数据传输对象</param>
        public virtual void RefreshProtoAddFlag(Error _err, FlagOperationResponseDTO _dto, SynchronizationContext? _context)
        {
            var bridge = getFacade()?.getUiBridge() as IPluginUiBridge; 
            if (!Error.IsOK(_err))
            {
                bridge?.Alert(string.Format("errcode_AddFlag_{0}", _err.getCode()), _err.getMessage(), _context);
                return;
            }
            bridge?.RefreshAddFlag(_dto, _context);
        }

        /// <summary>
        /// 刷新RemoveFlag的数据
        /// </summary>
        /// <param name="_err">错误</param>
        /// <param name="_dto">FlagOperationResponse的数据传输对象</param>
        public virtual void RefreshProtoRemoveFlag(Error _err, FlagOperationResponseDTO _dto, SynchronizationContext? _context)
        {
            var bridge = getFacade()?.getUiBridge() as IPluginUiBridge; 
            if (!Error.IsOK(_err))
            {
                bridge?.Alert(string.Format("errcode_RemoveFlag_{0}", _err.getCode()), _err.getMessage(), _context);
                return;
            }
            bridge?.RefreshRemoveFlag(_dto, _context);
        }


        /// <summary>
        /// 获取直系数据层
        /// </summary>
        /// <returns>数据层</returns>
        protected PluginModel? getModel()
        {
            if(null == model_)
                model_ = findModel(PluginModel.NAME + "." + gid_) as PluginModel;
            return model_;
        }

        /// <summary>
        /// 获取直系服务层
        /// </summary>
        /// <returns>服务层</returns>
        protected PluginService? getService()
        {
            if(null == service_)
                service_ = findService(PluginService.NAME + "." + gid_) as PluginService;
            return service_;
        }

        /// <summary>
        /// 获取直系UI装饰层
        /// </summary>
        /// <returns>UI装饰层</returns>
        protected PluginFacade? getFacade()
        {
            if(null == facade_)
                facade_ = findFacade(PluginFacade.NAME + "." + gid_) as PluginFacade;
            return facade_;
        }

        /// <summary>
        /// 直系的MVCS的四个组件的组的ID
        /// </summary>
        protected string gid_ = "";

        /// <summary>
        /// 直系数据层
        /// </summary>
        private PluginModel? model_;

        /// <summary>
        /// 直系服务层
        /// </summary>
        private PluginService? service_;

        /// <summary>
        /// 直系UI装饰层
        /// </summary>
        private PluginFacade? facade_;
    }
}

