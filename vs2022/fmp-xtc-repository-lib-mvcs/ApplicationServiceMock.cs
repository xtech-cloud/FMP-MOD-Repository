
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.61.0.  DO NOT EDIT!
//*************************************************************************************

using System.Threading.Tasks;
using XTC.FMP.MOD.Repository.LIB.Proto;

namespace XTC.FMP.MOD.Repository.LIB.MVCS
{
    /// <summary>
    /// Application服务模拟类
    /// </summary>
    public class ApplicationServiceMock
    {


        public System.Func<ApplicationCreateRequest, Task<UuidResponse>>? CallCreateDelegate { get; set; } = null;

        public System.Func<ApplicationUpdateRequest, Task<UuidResponse>>? CallUpdateDelegate { get; set; } = null;

        public System.Func<UuidRequest, Task<ApplicationRetrieveResponse>>? CallRetrieveDelegate { get; set; } = null;

        public System.Func<UuidRequest, Task<UuidResponse>>? CallDeleteDelegate { get; set; } = null;

        public System.Func<ApplicationListRequest, Task<ApplicationListResponse>>? CallListDelegate { get; set; } = null;

        public System.Func<ApplicationSearchRequest, Task<ApplicationListResponse>>? CallSearchDelegate { get; set; } = null;

        public System.Func<UuidRequest, Task<PrepareUploadResponse>>? CallPrepareUploadDelegate { get; set; } = null;

        public System.Func<UuidRequest, Task<FlushUploadResponse>>? CallFlushUploadDelegate { get; set; } = null;

        public System.Func<FlagOperationRequest, Task<FlagOperationResponse>>? CallAddFlagDelegate { get; set; } = null;

        public System.Func<FlagOperationRequest, Task<FlagOperationResponse>>? CallRemoveFlagDelegate { get; set; } = null;

    }
}
