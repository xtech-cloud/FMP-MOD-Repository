
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.26.3.  DO NOT EDIT!
//*************************************************************************************

using System.Threading.Tasks;
using XTC.FMP.MOD.Repository.LIB.Proto;

namespace XTC.FMP.MOD.Repository.LIB.MVCS
{
    /// <summary>
    /// Module服务模拟类
    /// </summary>
    public class ModuleServiceMock
    {


        public System.Func<ModuleCreateRequest, Task<UuidResponse>>? CallCreateDelegate { get; set; } = null;

        public System.Func<ModuleUpdateRequest, Task<UuidResponse>>? CallUpdateDelegate { get; set; } = null;

        public System.Func<UuidRequest, Task<ModuleRetrieveResponse>>? CallRetrieveDelegate { get; set; } = null;

        public System.Func<UuidRequest, Task<UuidResponse>>? CallDeleteDelegate { get; set; } = null;

        public System.Func<ModuleListRequest, Task<ModuleListResponse>>? CallListDelegate { get; set; } = null;

        public System.Func<ModuleSearchRequest, Task<ModuleListResponse>>? CallSearchDelegate { get; set; } = null;

        public System.Func<UuidRequest, Task<PrepareUploadResponse>>? CallPrepareUploadDelegate { get; set; } = null;

        public System.Func<UuidRequest, Task<FlushUploadResponse>>? CallFlushUploadDelegate { get; set; } = null;

        public System.Func<FlagOperationRequest, Task<UuidResponse>>? CallAddFlagDelegate { get; set; } = null;

        public System.Func<FlagOperationRequest, Task<UuidResponse>>? CallRemoveFlagDelegate { get; set; } = null;

    }
}
