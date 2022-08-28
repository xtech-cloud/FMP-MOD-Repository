
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.30.2.  DO NOT EDIT!
//*************************************************************************************

using System.Threading;
using XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.Repository.LIB.Proto;

namespace XTC.FMP.MOD.Repository.LIB.MVCS
{
    /// <summary>
    /// Agent数据层基类
    /// </summary>
    public class AgentModelBase : Model
    {
        /// <summary>
        /// 带uid参数的构造函数
        /// </summary>
        /// <param name="_uid">实例化后的唯一识别码</param>
        /// <param name="_gid">直系的组的ID</param>
        public AgentModelBase(string _uid, string _gid) : base(_uid)
        {
            gid_ = _gid;
        }


        /// <summary>
        /// 更新Create的数据
        /// </summary>
        /// <param name="_response">Create的回复</param>
        public virtual void UpdateProtoCreate(UuidResponse _response, object? _context)
        {
            getController()?.UpdateProtoCreate(status_ as AgentModel.AgentStatus, _response, _context);
        }

        /// <summary>
        /// 更新Update的数据
        /// </summary>
        /// <param name="_response">Update的回复</param>
        public virtual void UpdateProtoUpdate(UuidResponse _response, object? _context)
        {
            getController()?.UpdateProtoUpdate(status_ as AgentModel.AgentStatus, _response, _context);
        }

        /// <summary>
        /// 更新Retrieve的数据
        /// </summary>
        /// <param name="_response">Retrieve的回复</param>
        public virtual void UpdateProtoRetrieve(AgentRetrieveResponse _response, object? _context)
        {
            getController()?.UpdateProtoRetrieve(status_ as AgentModel.AgentStatus, _response, _context);
        }

        /// <summary>
        /// 更新Delete的数据
        /// </summary>
        /// <param name="_response">Delete的回复</param>
        public virtual void UpdateProtoDelete(UuidResponse _response, object? _context)
        {
            getController()?.UpdateProtoDelete(status_ as AgentModel.AgentStatus, _response, _context);
        }

        /// <summary>
        /// 更新List的数据
        /// </summary>
        /// <param name="_response">List的回复</param>
        public virtual void UpdateProtoList(AgentListResponse _response, object? _context)
        {
            getController()?.UpdateProtoList(status_ as AgentModel.AgentStatus, _response, _context);
        }

        /// <summary>
        /// 更新Search的数据
        /// </summary>
        /// <param name="_response">Search的回复</param>
        public virtual void UpdateProtoSearch(AgentListResponse _response, object? _context)
        {
            getController()?.UpdateProtoSearch(status_ as AgentModel.AgentStatus, _response, _context);
        }

        /// <summary>
        /// 更新PrepareUpload的数据
        /// </summary>
        /// <param name="_response">PrepareUpload的回复</param>
        public virtual void UpdateProtoPrepareUpload(PrepareUploadResponse _response, object? _context)
        {
            getController()?.UpdateProtoPrepareUpload(status_ as AgentModel.AgentStatus, _response, _context);
        }

        /// <summary>
        /// 更新FlushUpload的数据
        /// </summary>
        /// <param name="_response">FlushUpload的回复</param>
        public virtual void UpdateProtoFlushUpload(FlushUploadResponse _response, object? _context)
        {
            getController()?.UpdateProtoFlushUpload(status_ as AgentModel.AgentStatus, _response, _context);
        }

        /// <summary>
        /// 更新AddFlag的数据
        /// </summary>
        /// <param name="_response">AddFlag的回复</param>
        public virtual void UpdateProtoAddFlag(FlagOperationResponse _response, object? _context)
        {
            getController()?.UpdateProtoAddFlag(status_ as AgentModel.AgentStatus, _response, _context);
        }

        /// <summary>
        /// 更新RemoveFlag的数据
        /// </summary>
        /// <param name="_response">RemoveFlag的回复</param>
        public virtual void UpdateProtoRemoveFlag(FlagOperationResponse _response, object? _context)
        {
            getController()?.UpdateProtoRemoveFlag(status_ as AgentModel.AgentStatus, _response, _context);
        }


        /// <summary>
        /// 获取直系控制层
        /// </summary>
        /// <returns>控制层</returns>
        protected AgentController? getController()
        {
            if(null == controller_)
                controller_ = findController(AgentController.NAME + "." + gid_) as AgentController;
            return controller_;
        }

        /// <summary>
        /// 直系的MVCS的四个组件的组的ID
        /// </summary>
        protected string gid_ = "";

        /// <summary>
        /// 直系控制层
        /// </summary>
        private AgentController? controller_;
    }
}


