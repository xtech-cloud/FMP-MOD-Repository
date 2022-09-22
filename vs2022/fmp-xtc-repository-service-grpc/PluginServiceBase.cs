
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.33.1.  DO NOT EDIT!
//*************************************************************************************

using System.Net;
using Grpc.Core;
using System.Threading.Tasks;
using XTC.FMP.MOD.Repository.LIB.Proto;

namespace XTC.FMP.MOD.Repository.App.Service
{
    /// <summary>
    /// Plugin基类
    /// </summary>
    public class PluginServiceBase : LIB.Proto.Plugin.PluginBase
    {
    

        public override async Task<UuidResponse> Create(PluginCreateRequest _request, ServerCallContext _context)
        {
            try
            {
                return await safeCreate(_request, _context);
            }
            catch (ArgumentRequiredException ex)
            {
                return await Task.Run(() => new UuidResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.BadRequest.GetHashCode(), Message = ex.Message },
                });
            }
            catch (Exception ex)
            {
                return await Task.Run(() => new UuidResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.InternalServerError.GetHashCode(), Message = ex.Message },
                });
            }
        }

        public override async Task<UuidResponse> Update(PluginUpdateRequest _request, ServerCallContext _context)
        {
            try
            {
                return await safeUpdate(_request, _context);
            }
            catch (ArgumentRequiredException ex)
            {
                return await Task.Run(() => new UuidResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.BadRequest.GetHashCode(), Message = ex.Message },
                });
            }
            catch (Exception ex)
            {
                return await Task.Run(() => new UuidResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.InternalServerError.GetHashCode(), Message = ex.Message },
                });
            }
        }

        public override async Task<PluginRetrieveResponse> Retrieve(UuidRequest _request, ServerCallContext _context)
        {
            try
            {
                return await safeRetrieve(_request, _context);
            }
            catch (ArgumentRequiredException ex)
            {
                return await Task.Run(() => new PluginRetrieveResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.BadRequest.GetHashCode(), Message = ex.Message },
                });
            }
            catch (Exception ex)
            {
                return await Task.Run(() => new PluginRetrieveResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.InternalServerError.GetHashCode(), Message = ex.Message },
                });
            }
        }

        public override async Task<UuidResponse> Delete(UuidRequest _request, ServerCallContext _context)
        {
            try
            {
                return await safeDelete(_request, _context);
            }
            catch (ArgumentRequiredException ex)
            {
                return await Task.Run(() => new UuidResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.BadRequest.GetHashCode(), Message = ex.Message },
                });
            }
            catch (Exception ex)
            {
                return await Task.Run(() => new UuidResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.InternalServerError.GetHashCode(), Message = ex.Message },
                });
            }
        }

        public override async Task<PluginListResponse> List(PluginListRequest _request, ServerCallContext _context)
        {
            try
            {
                return await safeList(_request, _context);
            }
            catch (ArgumentRequiredException ex)
            {
                return await Task.Run(() => new PluginListResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.BadRequest.GetHashCode(), Message = ex.Message },
                });
            }
            catch (Exception ex)
            {
                return await Task.Run(() => new PluginListResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.InternalServerError.GetHashCode(), Message = ex.Message },
                });
            }
        }

        public override async Task<PluginListResponse> Search(PluginSearchRequest _request, ServerCallContext _context)
        {
            try
            {
                return await safeSearch(_request, _context);
            }
            catch (ArgumentRequiredException ex)
            {
                return await Task.Run(() => new PluginListResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.BadRequest.GetHashCode(), Message = ex.Message },
                });
            }
            catch (Exception ex)
            {
                return await Task.Run(() => new PluginListResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.InternalServerError.GetHashCode(), Message = ex.Message },
                });
            }
        }

        public override async Task<PrepareUploadResponse> PrepareUpload(UuidRequest _request, ServerCallContext _context)
        {
            try
            {
                return await safePrepareUpload(_request, _context);
            }
            catch (ArgumentRequiredException ex)
            {
                return await Task.Run(() => new PrepareUploadResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.BadRequest.GetHashCode(), Message = ex.Message },
                });
            }
            catch (Exception ex)
            {
                return await Task.Run(() => new PrepareUploadResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.InternalServerError.GetHashCode(), Message = ex.Message },
                });
            }
        }

        public override async Task<FlushUploadResponse> FlushUpload(UuidRequest _request, ServerCallContext _context)
        {
            try
            {
                return await safeFlushUpload(_request, _context);
            }
            catch (ArgumentRequiredException ex)
            {
                return await Task.Run(() => new FlushUploadResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.BadRequest.GetHashCode(), Message = ex.Message },
                });
            }
            catch (Exception ex)
            {
                return await Task.Run(() => new FlushUploadResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.InternalServerError.GetHashCode(), Message = ex.Message },
                });
            }
        }

        public override async Task<FlagOperationResponse> AddFlag(FlagOperationRequest _request, ServerCallContext _context)
        {
            try
            {
                return await safeAddFlag(_request, _context);
            }
            catch (ArgumentRequiredException ex)
            {
                return await Task.Run(() => new FlagOperationResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.BadRequest.GetHashCode(), Message = ex.Message },
                });
            }
            catch (Exception ex)
            {
                return await Task.Run(() => new FlagOperationResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.InternalServerError.GetHashCode(), Message = ex.Message },
                });
            }
        }

        public override async Task<FlagOperationResponse> RemoveFlag(FlagOperationRequest _request, ServerCallContext _context)
        {
            try
            {
                return await safeRemoveFlag(_request, _context);
            }
            catch (ArgumentRequiredException ex)
            {
                return await Task.Run(() => new FlagOperationResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.BadRequest.GetHashCode(), Message = ex.Message },
                });
            }
            catch (Exception ex)
            {
                return await Task.Run(() => new FlagOperationResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.InternalServerError.GetHashCode(), Message = ex.Message },
                });
            }
        }



        protected virtual async Task<UuidResponse> safeCreate(PluginCreateRequest _request, ServerCallContext _context)
        {
            return await Task.Run(() => new UuidResponse {
                    Status = new LIB.Proto.Status() { Code = -1, Message = "Not Implemented" },
            });
        }

        protected virtual async Task<UuidResponse> safeUpdate(PluginUpdateRequest _request, ServerCallContext _context)
        {
            return await Task.Run(() => new UuidResponse {
                    Status = new LIB.Proto.Status() { Code = -1, Message = "Not Implemented" },
            });
        }

        protected virtual async Task<PluginRetrieveResponse> safeRetrieve(UuidRequest _request, ServerCallContext _context)
        {
            return await Task.Run(() => new PluginRetrieveResponse {
                    Status = new LIB.Proto.Status() { Code = -1, Message = "Not Implemented" },
            });
        }

        protected virtual async Task<UuidResponse> safeDelete(UuidRequest _request, ServerCallContext _context)
        {
            return await Task.Run(() => new UuidResponse {
                    Status = new LIB.Proto.Status() { Code = -1, Message = "Not Implemented" },
            });
        }

        protected virtual async Task<PluginListResponse> safeList(PluginListRequest _request, ServerCallContext _context)
        {
            return await Task.Run(() => new PluginListResponse {
                    Status = new LIB.Proto.Status() { Code = -1, Message = "Not Implemented" },
            });
        }

        protected virtual async Task<PluginListResponse> safeSearch(PluginSearchRequest _request, ServerCallContext _context)
        {
            return await Task.Run(() => new PluginListResponse {
                    Status = new LIB.Proto.Status() { Code = -1, Message = "Not Implemented" },
            });
        }

        protected virtual async Task<PrepareUploadResponse> safePrepareUpload(UuidRequest _request, ServerCallContext _context)
        {
            return await Task.Run(() => new PrepareUploadResponse {
                    Status = new LIB.Proto.Status() { Code = -1, Message = "Not Implemented" },
            });
        }

        protected virtual async Task<FlushUploadResponse> safeFlushUpload(UuidRequest _request, ServerCallContext _context)
        {
            return await Task.Run(() => new FlushUploadResponse {
                    Status = new LIB.Proto.Status() { Code = -1, Message = "Not Implemented" },
            });
        }

        protected virtual async Task<FlagOperationResponse> safeAddFlag(FlagOperationRequest _request, ServerCallContext _context)
        {
            return await Task.Run(() => new FlagOperationResponse {
                    Status = new LIB.Proto.Status() { Code = -1, Message = "Not Implemented" },
            });
        }

        protected virtual async Task<FlagOperationResponse> safeRemoveFlag(FlagOperationRequest _request, ServerCallContext _context)
        {
            return await Task.Run(() => new FlagOperationResponse {
                    Status = new LIB.Proto.Status() { Code = -1, Message = "Not Implemented" },
            });
        }

    }
}

