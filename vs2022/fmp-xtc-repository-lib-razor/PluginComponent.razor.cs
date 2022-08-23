
using Microsoft.AspNetCore.Components;
using XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.Repository.LIB.Proto;
using XTC.FMP.MOD.Repository.LIB.Bridge;
using XTC.FMP.MOD.Repository.LIB.MVCS;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel;
using AntDesign;

namespace XTC.FMP.MOD.Repository.LIB.Razor
{
    public partial class PluginComponent
    {
        public class PluginUiBridge : IPluginUiBridge
        {

            public PluginUiBridge(PluginComponent _razor)
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
                    razor_.createLoading = false;
                    razor_.StateHasChanged();
                });
            }


            public void RefreshCreate(IDTO _dto, SynchronizationContext? _context)
            {
                razor_.createLoading = false;
                razor_.visibleCreateModal = false;
                razor_.StateHasChanged();

                Task.Run(async () =>
                {
                    await razor_.listAll();
                });
            }

            public void RefreshUpdate(IDTO _dto, SynchronizationContext? _context)
            {
                var dto = _dto as UuidResponseDTO;
            }

            public void RefreshRetrieve(IDTO _dto, SynchronizationContext? _context)
            {
                var dto = _dto as PluginRetrieveResponseDTO;
            }

            public void RefreshDelete(IDTO _dto, SynchronizationContext? _context)
            {
                var dto = _dto as UuidResponseDTO;
                if (null == dto)
                    return;
                razor_.tableModel.RemoveAll((_item) =>
                {
                    return _item.Uuid?.Equals(dto.Value.Uuid) ?? false;
                });

            }

            public void RefreshList(IDTO _dto, SynchronizationContext? _context)
            {
                var dto = _dto as PluginListResponseDTO;
                if (null == dto)
                    return;

                razor_.tableTotal = (int)dto.Value.Total;
                razor_.tableModel.Clear();
                foreach (var plugin in dto.Value.Plugins)
                {

                    razor_.tableModel.Add(new TableModel
                    {
                        Uuid = plugin.Uuid,
                        Name = plugin.Name,
                        Version = plugin.Version,
                        Size = Utility.SizeToString(plugin.File.Size),
                        Hash = plugin.File.Hash,
                        UpdatedAt = Utility.TimestampToString(plugin.UpdatedAt),
                        _Locked = Flags.HasFlag(plugin.Flags, Flags.LOCK),
                    });
                }
                razor_.StateHasChanged();
            }

            public void RefreshSearch(IDTO _dto, SynchronizationContext? _context)
            {
                razor_.searchLoading = false;
                RefreshList(_dto, _context);
            }

            public void RefreshPrepareUpload(IDTO _dto, SynchronizationContext? _context)
            {
                var dto = _dto as PrepareUploadResponseDTO;
                if (null == dto)
                    return;
                var item = razor_.tableModel.Find((_item) =>
                {
                    return _item.Uuid == dto.Value.Uuid;
                });
                if (null == item)
                    return;

                string uploadUrl = "";
                if (!dto.Value.Urls.TryGetValue(String.Format("{0}@{1}.dll", item.Name, item.Version), out uploadUrl))
                    return;

                if (string.IsNullOrEmpty(uploadUrl))
                    return;

                razor_.visibleUploadModal = true;
                razor_.uploadUrl = uploadUrl;
                razor_.StateHasChanged();
            }

            public void RefreshFlushUpload(IDTO _dto, SynchronizationContext? _context)
            {
                var dto = _dto as FlushUploadResponseDTO;
                if (null == dto)
                    return;

                var item = razor_.tableModel.Find((_item) =>
                {
                    return _item.Uuid == dto.Value.Uuid;
                });
                if (null == item)
                    return;

                string filename = string.Format("{0}@{1}.dll", item.Name, item.Version);
                item._Locked = Flags.HasFlag(dto.Value.Flags, Flags.LOCK);
                item.Hash = dto.Value.Hashs[filename];
                item.Size = Utility.SizeToString(dto.Value.Sizes[filename]);
                razor_.StateHasChanged();
            }

            public void RefreshAddFlag(IDTO _dto, SynchronizationContext? _context)
            {
                var dto = _dto as FlagOperationResponseDTO;
                if (null == dto)
                    return;
                var item = razor_.tableModel.Find((_item) =>
                {
                    return _item?.Uuid?.Equals(dto.Value.Uuid) ?? false;
                });
                if (null == item)
                    return;
                item._Locked = Flags.HasFlag(dto.Value.Flags, Flags.LOCK);
                razor_.StateHasChanged();
            }

            public void RefreshRemoveFlag(IDTO _dto, SynchronizationContext? _context)
            {
                var dto = _dto as FlagOperationResponseDTO;
                if (null == dto)
                    return;
                var item = razor_.tableModel.Find((_item) =>
                {
                    return _item?.Uuid?.Equals(dto.Value.Uuid) ?? false;
                });
                if (null == item)
                    return;
                item._Locked = Flags.HasFlag(dto.Value.Flags, Flags.LOCK);
                razor_.StateHasChanged();
            }

            private PluginComponent razor_;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            searchFormData[SearchField.Name.GetHashCode()] = new FormValue { Text = "名称", Value = "" };
            await listAll();
        }

        #region Search
        private class FormValue
        {
            public string? Text { get; set; }
            public string? Value { get; set; }
        }

        private bool searchLoading = false;
        private AntDesign.Internal.IForm? searchForm;
        private Dictionary<int, FormValue> searchFormData = new();
        private bool searchExpand = false;

        private enum SearchField
        {
            Name,
        }

        private async void onSearchSubmit(EditContext _context)
        {
            searchLoading = true;
            var bridge = (getFacade()?.getViewBridge() as IPluginViewBridge);
            if (null == bridge)
            {
                logger_?.Error("bridge is null");
                return;
            }
            var req = new PluginSearchRequest();
            req.Offset = (tablePageIndex - 1) * tablePageSize;
            req.Count = tablePageSize;
            req.Name = searchFormData[SearchField.Name.GetHashCode()].Value;
            var dto = new PluginSearchRequestDTO(req);
            Error err = await bridge.OnSearchSubmit(dto, SynchronizationContext.Current);
            if (!Error.IsOK(err))
            {
                logger_?.Error(err.getMessage());
            }

        }

        private async void onSearchResetClick()
        {
            searchForm?.Reset();
            await listAll();
        }
        #endregion

        #region Create Modal
        private class CreateModel
        {
            [Required]
            public string? Name { get; set; }
            [Required]
            public string? Version { get; set; }
        }

        private bool visibleCreateModal = false;
        private bool createLoading = false;
        private AntDesign.Internal.IForm? createForm;
        private CreateModel createModel = new();

        private void onCreateClick()
        {
            visibleCreateModal = true;
        }

        private void onCreateModalOk()
        {
            createForm?.Submit();
        }

        private void onCreateModalCancel()
        {
            visibleCreateModal = false;
        }

        private async void onCreateSubmit(EditContext _context)
        {
            createLoading = true;
            var bridge = (getFacade()?.getViewBridge() as IPluginViewBridge);
            if (null == bridge)
            {
                logger_?.Error("bridge is null");
                return;
            }
            var model = _context.Model as CreateModel;
            if (null == model)
            {
                logger_?.Error("model is null");
                return;
            }
            var req = new PluginCreateRequest();
            req.Name = model.Name;
            req.Version = model.Version;
            PluginCreateRequestDTO dto = new PluginCreateRequestDTO(req);
            Error err = await bridge.OnCreateSubmit(dto, SynchronizationContext.Current);
            if (null != err)
            {
                logger_?.Error(err.getMessage());
            }
        }


        #endregion

        #region Table
        private class TableModel
        {
            public string? Uuid { get; set; }

            [DisplayName("名称")]
            public string? Name { get; set; }

            [DisplayName("版本")]
            public string? Version { get; set; }
            [DisplayName("大小")]
            public string? Size { get; set; }
            [DisplayName("哈希值")]
            public string? Hash { get; set; }
            [DisplayName("更新时间")]
            public string? UpdatedAt { get; set; }

            public bool _Locked { get; set; } = false;
        }


        private List<TableModel> tableModel = new();
        private int tableTotal = 0;
        private int tablePageIndex = 1;
        private int tablePageSize = 50;

        private async Task listAll()
        {
            var bridge = (getFacade()?.getViewBridge() as IPluginViewBridge);
            if (null == bridge)
            {
                logger_?.Error("bridge is null");
                return;
            }
            var req = new PluginListRequest();
            req.Offset = (tablePageIndex - 1) * tablePageSize;
            req.Count = tablePageSize;
            var dto = new PluginListRequestDTO(req);
            Error err = await bridge.OnListSubmit(dto, SynchronizationContext.Current);
            if (!Error.IsOK(err))
            {
                logger_?.Error(err.getMessage());
            }
        }

        private async Task onConfirmDelete(string? _uuid)
        {
            if (string.IsNullOrEmpty(_uuid))
                return;

            var bridge = (getFacade()?.getViewBridge() as IPluginViewBridge);
            if (null == bridge)
            {
                logger_?.Error("bridge is null");
                return;
            }
            var req = new UuidRequest();
            req.Uuid = _uuid;
            var dto = new UuidRequestDTO(req);
            Error err = await bridge.OnDeleteSubmit(dto, SynchronizationContext.Current);
            if (!Error.IsOK(err))
            {
                logger_?.Error(err.getMessage());
            }
        }

        private void onCancelDelete()
        {
            //Nothing to do
        }

        private async Task onConfirmUnlock(string? _uuid)
        {
            if (string.IsNullOrEmpty(_uuid))
                return;

            var bridge = (getFacade()?.getViewBridge() as IPluginViewBridge);
            if (null == bridge)
            {
                logger_?.Error("bridge is null");
                return;
            }
            var req = new FlagOperationRequest();
            req.Uuid = _uuid;
            req.Flag = Flags.LOCK;
            var dto = new FlagOperationRequestDTO(req);
            Error err = await bridge.OnRemoveFlagSubmit(dto, SynchronizationContext.Current);
            if (!Error.IsOK(err))
            {
                logger_?.Error(err.getMessage());
            }
        }

        private void onCancelUnlock()
        {
            //Nothing to do
        }

        private async void onPageIndexChanged(PaginationEventArgs args)
        {
            tablePageIndex = args.Page;
            await listAll();
        }
        #endregion

        #region Upload

        private bool visibleUploadModal = false;

        private string? uploadUuid = "";
        private string? uploadUrl = "";
        private int uploadPercent = 0;

        private void onUploadModalCancel()
        {
            visibleUploadModal = false;
        }

        private void onUploadChange(UploadInfo _fileinfo)
        {
            uploadPercent = _fileinfo.File.Percent;
        }

        private async void onUploadCompleted(UploadInfo _fileinfo)
        {
            var bridge = (getFacade()?.getViewBridge() as IPluginViewBridge);
            if (null == bridge)
            {
                logger_?.Error("bridge is null");
                return;
            }
            var req = new UuidRequest();
            req.Uuid = uploadUuid;
            var dto = new UuidRequestDTO(req);
            Error err = await bridge.OnFlushUploadSubmit(dto, SynchronizationContext.Current);
            if (!Error.IsOK(err))
            {
                logger_?.Error(err.getMessage());
            }
        }

        private async void onUploadClick(string? _uuid)
        {
            uploadPercent = 0;

            if (string.IsNullOrEmpty(_uuid))
                return;

            var bridge = (getFacade()?.getViewBridge() as IPluginViewBridge);
            if (null == bridge)
            {
                logger_?.Error("bridge is null");
                return;
            }
            var item = tableModel.Find((_item) =>
            {
                return _item.Uuid == _uuid;
            });
            if (null == item)
                return;

            uploadUuid = _uuid;

            var req = new UuidRequest();
            req.Uuid = _uuid;
            var dto = new UuidRequestDTO(req);
            Error err = await bridge.OnPrepareUploadSubmit(dto, SynchronizationContext.Current);
            if (!Error.IsOK(err))
            {
                logger_?.Error(err.getMessage());
            }
        }

        #endregion

    }
}
