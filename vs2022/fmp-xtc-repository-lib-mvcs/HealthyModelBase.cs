
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.80.0.  DO NOT EDIT!
//*************************************************************************************

using System.Threading;
using XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.Repository.LIB.Proto;

namespace XTC.FMP.MOD.Repository.LIB.MVCS
{
    /// <summary>
    /// Healthy数据层基类
    /// </summary>
    public class HealthyModelBase : Model
    {
        /// <summary>
        /// 带uid参数的构造函数
        /// </summary>
        /// <param name="_uid">实例化后的唯一识别码</param>
        /// <param name="_gid">直系的组的ID</param>
        public HealthyModelBase(string _uid, string _gid) : base(_uid)
        {
            gid_ = _gid;
        }


        /// <summary>
        /// 更新Echo的数据
        /// </summary>
        /// <param name="_response">Echo的回复</param>
        public virtual void UpdateProtoEcho(HealthyEchoResponse _response, object? _context)
        {
            getController()?.UpdateProtoEcho(status_ as HealthyModel.HealthyStatus, _response, _context);
        }


        /// <summary>
        /// 获取直系控制层
        /// </summary>
        /// <returns>控制层</returns>
        protected HealthyController? getController()
        {
            if(null == controller_)
                controller_ = findController(HealthyController.NAME + "." + gid_) as HealthyController;
            return controller_;
        }

        /// <summary>
        /// 直系的MVCS的四个组件的组的ID
        /// </summary>
        protected string gid_ = "";

        /// <summary>
        /// 直系控制层
        /// </summary>
        private HealthyController? controller_;
    }
}


