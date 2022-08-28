
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.30.2.  DO NOT EDIT!
//*************************************************************************************

using System.Net;
using Grpc.Core;
using System.Threading.Tasks;
using XTC.FMP.MOD.Repository.LIB.Proto;

namespace XTC.FMP.MOD.Repository.App.Service
{
    /// <summary>
    /// Module基类
    /// </summary>
    public class ModuleServiceBase : LIB.Proto.Module.ModuleBase
    {
    

        public override async Task<UuidResponse> Create(ModuleCreateRequest _request, ServerCallContext _context)
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

        public override async Task<UuidResponse> Update(ModuleUpdateRequest _request, ServerCallContext _context)
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

        public override async Task<ModuleRetrieveResponse> Retrieve(UuidRequest _request, ServerCallContext _context)
        {
            try
            {
                return await safeRetrieve(_request, _context);
            }
            catch (ArgumentRequiredException ex)
            {
                return await Task.Run(() => new ModuleRetrieveResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.BadRequest.GetHashCode(), Message = ex.Message },
                });
            }
            catch (Exception ex)
            {
                return await Task.Run(() => new ModuleRetrieveResponse
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

        public override async Task<ModuleListResponse> List(ModuleListRequest _request, ServerCallContext _context)
        {
            try
            {
                return await safeList(_request, _context);
            }
            catch (ArgumentRequiredException ex)
            {
                return await Task.Run(() => new ModuleListResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.BadRequest.GetHashCode(), Message = ex.Message },
                });
            }
            catch (Exception ex)
            {
                return await Task.Run(() => new ModuleListResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.InternalServerError.GetHashCode(), Message = ex.Message },
                });
            }
        }

        public override async Task<ModuleListResponse> Search(ModuleSearchRequest _request, ServerCallContext _context)
        {
            try
            {
                return await safeSearch(_request, _context);
            }
            catch (ArgumentRequiredException ex)
            {
                return await Task.Run(() => new ModuleListResponse
                {
                    Status = new LIB.Proto.Status() { Code = -HttpStatusCode.BadRequest.GetHashCode(), Message = ex.Message },
                });
            }
            catch (Exception ex)
            {
                return await Task.Run(() => new ModuleListResponse
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



        protected virtual async Task<UuidResponse> safeCreate(ModuleCreateRequest _request, ServerCallContext _context)
        {
            return await Task.Run(() => new UuidResponse {
                    Status = new LIB.Proto.Status() { Code = -1, Message = "Not Implemented" },
            });
        }

        protected virtual async Task<UuidResponse> safeUpdate(ModuleUpdateRequest _request, ServerCallContext _context)
        {
            return await Task.Run(() => new UuidResponse {
                    Status = new LIB.Proto.Status() { Code = -1, Message = "Not Implemented" },
            });
        }

        protected virtual async Task<ModuleRetrieveResponse> safeRetrieve(UuidRequest _request, ServerCallContext _context)
        {
            return await Task.Run(() => new ModuleRetrieveResponse {
                    Status = new LIB.Proto.Status() { Code = -1, Message = "Not Implemented" },
            });
        }

        protected virtual async Task<UuidResponse> safeDelete(UuidRequest _request, ServerCallContext _context)
        {
            return await Task.Run(() => new UuidResponse {
                    Status = new LIB.Proto.Status() { Code = -1, Message = "Not Implemented" },
            });
        }

        protected virtual async Task<ModuleListResponse> safeList(ModuleListRequest _request, ServerCallContext _context)
        {
            return await Task.Run(() => new ModuleListResponse {
                    Status = new LIB.Proto.Status() { Code = -1, Message = "Not Implemented" },
            });
        }

        protected virtual async Task<ModuleListResponse> safeSearch(ModuleSearchRequest _request, ServerCallContext _context)
        {
            return await Task.Run(() => new ModuleListResponse {
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

