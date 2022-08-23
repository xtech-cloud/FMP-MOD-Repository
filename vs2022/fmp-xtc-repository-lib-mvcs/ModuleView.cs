
using XTC.FMP.LIB.MVCS;

namespace XTC.FMP.MOD.Repository.LIB.MVCS
{
    /// <summary>
    /// Module视图层
    /// </summary>
    public class ModuleView : ModuleViewBase
    {
        /// <summary>
        /// 完整名称
        /// </summary>
        public const string NAME = "XTC.FMP.MOD.Repository.LIB.MVCS.ModuleView";

        /// <summary>
        /// 带uid参数的构造函数
        /// </summary>
        /// <param name="_uid">实例化后的唯一识别码</param>
        /// <param name="_gid">直系的组的ID</param>
        public ModuleView(string _uid, string _gid) : base(_uid, _gid) 
        {
        }
    }
}


