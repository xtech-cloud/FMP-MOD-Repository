
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.53.0.  DO NOT EDIT!
//*************************************************************************************

using System.Threading;
using System.Threading.Tasks;
using XTC.FMP.LIB.MVCS;

namespace XTC.FMP.MOD.Repository.LIB.Bridge
{
    /// <summary>
    /// Agent的视图桥接层（协议部分）
    /// 处理UI的事件
    /// </summary>
    public interface IAgentViewProtoBridge : View.Facade.Bridge
    {

        /// <summary>
        /// 处理Create的提交
        /// </summary>
        Task<Error> OnCreateSubmit(IDTO _dto, object? _context);


        /// <summary>
        /// 处理Update的提交
        /// </summary>
        Task<Error> OnUpdateSubmit(IDTO _dto, object? _context);


        /// <summary>
        /// 处理Retrieve的提交
        /// </summary>
        Task<Error> OnRetrieveSubmit(IDTO _dto, object? _context);


        /// <summary>
        /// 处理Delete的提交
        /// </summary>
        Task<Error> OnDeleteSubmit(IDTO _dto, object? _context);


        /// <summary>
        /// 处理List的提交
        /// </summary>
        Task<Error> OnListSubmit(IDTO _dto, object? _context);


        /// <summary>
        /// 处理Search的提交
        /// </summary>
        Task<Error> OnSearchSubmit(IDTO _dto, object? _context);


        /// <summary>
        /// 处理PrepareUpload的提交
        /// </summary>
        Task<Error> OnPrepareUploadSubmit(IDTO _dto, object? _context);


        /// <summary>
        /// 处理FlushUpload的提交
        /// </summary>
        Task<Error> OnFlushUploadSubmit(IDTO _dto, object? _context);


        /// <summary>
        /// 处理AddFlag的提交
        /// </summary>
        Task<Error> OnAddFlagSubmit(IDTO _dto, object? _context);


        /// <summary>
        /// 处理RemoveFlag的提交
        /// </summary>
        Task<Error> OnRemoveFlagSubmit(IDTO _dto, object? _context);


    }
}

