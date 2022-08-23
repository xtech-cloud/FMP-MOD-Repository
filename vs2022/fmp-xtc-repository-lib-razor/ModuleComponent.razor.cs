
using Microsoft.AspNetCore.Components;
using XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.Repository.LIB.Proto;
using XTC.FMP.MOD.Repository.LIB.Bridge;
using XTC.FMP.MOD.Repository.LIB.MVCS;

namespace XTC.FMP.MOD.Repository.LIB.Razor
{
    public partial class ModuleComponent
    {
        public class ModuleUiBridge : IModuleUiBridge
        {

            public ModuleUiBridge(ModuleComponent _razor)
            {
                razor_ = _razor;
            }

            public void Alert(string _code, string _message, SynchronizationContext? _context)
            {
                if (null == razor_.messageService_)
                    return;
                Task.Run(async () =>
                {
                    await razor_.messageService_.Error(_message);
                }); 
            }


            public void RefreshCreate(IDTO _dto, SynchronizationContext? _context)
            {
                var dto = _dto as UuidResponseDTO;
                razor_.__debugCreate = dto?.Value.ToString();
            }

            public void RefreshUpdate(IDTO _dto, SynchronizationContext? _context)
            {
                var dto = _dto as UuidResponseDTO;
                razor_.__debugUpdate = dto?.Value.ToString();
            }

            public void RefreshRetrieve(IDTO _dto, SynchronizationContext? _context)
            {
                var dto = _dto as ModuleRetrieveResponseDTO;
                razor_.__debugRetrieve = dto?.Value.ToString();
            }

            public void RefreshDelete(IDTO _dto, SynchronizationContext? _context)
            {
                var dto = _dto as UuidResponseDTO;
                razor_.__debugDelete = dto?.Value.ToString();
            }

            public void RefreshList(IDTO _dto, SynchronizationContext? _context)
            {
                var dto = _dto as ModuleListResponseDTO;
                razor_.__debugList = dto?.Value.ToString();
            }

            public void RefreshSearch(IDTO _dto, SynchronizationContext? _context)
            {
                var dto = _dto as ModuleListResponseDTO;
                razor_.__debugSearch = dto?.Value.ToString();
            }

            public void RefreshPrepareUpload(IDTO _dto, SynchronizationContext? _context)
            {
                var dto = _dto as PrepareUploadResponseDTO;
                razor_.__debugPrepareUpload = dto?.Value.ToString();
            }

            public void RefreshFlushUpload(IDTO _dto, SynchronizationContext? _context)
            {
                var dto = _dto as FlushUploadResponseDTO;
                razor_.__debugFlushUpload = dto?.Value.ToString();
            }


            private ModuleComponent razor_;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        private async Task __debugClick()
        {
            var bridge = (getFacade()?.getViewBridge() as IModuleViewBridge);
            if (null == bridge)
            {
                logger_?.Error("bridge is null");
                return;
            }

            var reqCreate = new ModuleCreateRequest();
            var dtoCreate = new ModuleCreateRequestDTO(reqCreate);
            logger_?.Trace("invoke OnCreateSubmit");
            await bridge.OnCreateSubmit(dtoCreate, null);

            var reqUpdate = new ModuleUpdateRequest();
            var dtoUpdate = new ModuleUpdateRequestDTO(reqUpdate);
            logger_?.Trace("invoke OnUpdateSubmit");
            await bridge.OnUpdateSubmit(dtoUpdate, null);

            var reqRetrieve = new UuidRequest();
            var dtoRetrieve = new UuidRequestDTO(reqRetrieve);
            logger_?.Trace("invoke OnRetrieveSubmit");
            await bridge.OnRetrieveSubmit(dtoRetrieve, null);

            var reqDelete = new UuidRequest();
            var dtoDelete = new UuidRequestDTO(reqDelete);
            logger_?.Trace("invoke OnDeleteSubmit");
            await bridge.OnDeleteSubmit(dtoDelete, null);

            var reqList = new ModuleListRequest();
            var dtoList = new ModuleListRequestDTO(reqList);
            logger_?.Trace("invoke OnListSubmit");
            await bridge.OnListSubmit(dtoList, null);

            var reqSearch = new ModuleSearchRequest();
            var dtoSearch = new ModuleSearchRequestDTO(reqSearch);
            logger_?.Trace("invoke OnSearchSubmit");
            await bridge.OnSearchSubmit(dtoSearch, null);

            var reqPrepareUpload = new UuidRequest();
            var dtoPrepareUpload = new UuidRequestDTO(reqPrepareUpload);
            logger_?.Trace("invoke OnPrepareUploadSubmit");
            await bridge.OnPrepareUploadSubmit(dtoPrepareUpload, null);

            var reqFlushUpload = new UuidRequest();
            var dtoFlushUpload = new UuidRequestDTO(reqFlushUpload);
            logger_?.Trace("invoke OnFlushUploadSubmit");
            await bridge.OnFlushUploadSubmit(dtoFlushUpload, null);

        }


        private string? __debugCreate;

        private string? __debugUpdate;

        private string? __debugRetrieve;

        private string? __debugDelete;

        private string? __debugList;

        private string? __debugSearch;

        private string? __debugPrepareUpload;

        private string? __debugFlushUpload;

    }
}
