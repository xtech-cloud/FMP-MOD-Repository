
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.30.0.  DO NOT EDIT!
//*************************************************************************************

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using LibMVCS = XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.Repository.LIB.Bridge;
using XTC.FMP.MOD.Repository.LIB.MVCS;
using XTC.FMP.MOD.Repository.LIB.Proto;

namespace XTC.FMP.MOD.Repository.LIB.Unity
{
    public class MyInstanceBase
    {
        public string uid { get; private set; }
        public GameObject rootUI { get; private set; }
        public GameObject rootAttachments { get; private set; }
        public ObjectsPool contentObjectsPool { get; private set; }
        public ObjectsPool themeObjectsPool { get; private set; }


        public IAgentViewBridge viewBridgeAgent { get; set; }

        public IHealthyViewBridge viewBridgeHealthy { get; set; }

        public IModuleViewBridge viewBridgeModule { get; set; }

        public IPluginViewBridge viewBridgePlugin { get; set; }


        protected MyEntryBase entry_ { get; set; }
        protected LibMVCS.Logger logger_ { get; set; }
        protected MyConfig config_ { get; set; }
        protected MyConfig.Style style_ { get; set; }
        protected Dictionary<string, LibMVCS.Any> settings_ { get; set; }
        protected MonoBehaviour mono_ {get;set;}

        public MyInstanceBase(string _uid, string _style, MyConfig _config, LibMVCS.Logger _logger, Dictionary<string, LibMVCS.Any> _settings, MyEntryBase _entry, MonoBehaviour _mono, GameObject _rootAttachments)
        {
            uid = _uid;
            config_ = _config;
            logger_ = _logger;
            settings_ = _settings;
            entry_ = _entry;
            mono_ = _mono;
            rootAttachments = _rootAttachments;
            foreach(var style in config_.styles)
            {
                if (style.name.Equals(_style))
                {
                    style_ = style;
                    break;
                }
            }
            contentObjectsPool = new ObjectsPool(uid + ".Content", logger_);
            themeObjectsPool = new ObjectsPool(uid + ".Theme", logger_);
        }

        /// <summary>
        /// 实例化UI
        /// </summary>
        /// <param name="_instanceUI">ui的实例模板</param>
        public void InstantiateUI(GameObject _instanceUI)
        {
            rootUI = Object.Instantiate(_instanceUI, _instanceUI.transform.parent);
            rootUI.name = uid;
        }

        public void SetupBridges()
        {

            var facadeAgent = entry_.getDynamicAgentFacade(uid);
            var bridgeAgent = new AgentUiBridge();
            bridgeAgent.logger = logger_;
            facadeAgent.setUiBridge(bridgeAgent);
            viewBridgeAgent = facadeAgent.getViewBridge() as IAgentViewBridge;

            var facadeHealthy = entry_.getDynamicHealthyFacade(uid);
            var bridgeHealthy = new HealthyUiBridge();
            bridgeHealthy.logger = logger_;
            facadeHealthy.setUiBridge(bridgeHealthy);
            viewBridgeHealthy = facadeHealthy.getViewBridge() as IHealthyViewBridge;

            var facadeModule = entry_.getDynamicModuleFacade(uid);
            var bridgeModule = new ModuleUiBridge();
            bridgeModule.logger = logger_;
            facadeModule.setUiBridge(bridgeModule);
            viewBridgeModule = facadeModule.getViewBridge() as IModuleViewBridge;

            var facadePlugin = entry_.getDynamicPluginFacade(uid);
            var bridgePlugin = new PluginUiBridge();
            bridgePlugin.logger = logger_;
            facadePlugin.setUiBridge(bridgePlugin);
            viewBridgePlugin = facadePlugin.getViewBridge() as IPluginViewBridge;

        }

        /// <summary>
        /// 将目标按锚点在父对象中对齐
        /// </summary>
        /// <param name="_target">目标</param>
        /// <param name="_anchor">锚点</param>
        protected void alignByAncor(Transform _target, MyConfig.Anchor _anchor)
        {
            if (null == _target)
                return;
            RectTransform rectTransform = _target.GetComponent<RectTransform>();
            if (null == rectTransform)
                return;

            RectTransform parent = _target.transform.parent.GetComponent<RectTransform>();
            float marginH = 0;
            if (_anchor.marginH.EndsWith("%"))
            {
                float margin = 0;
                float.TryParse(_anchor.marginH.Replace("%", ""), out margin);
                marginH = (margin / 100.0f) * (parent.rect.width / 2);
            }
            else
            {
                float.TryParse(_anchor.marginH, out marginH);
            }

            float marginV = 0;
            if (_anchor.marginV.EndsWith("%"))
            {
                float margin = 0;
                float.TryParse(_anchor.marginV.Replace("%", ""), out margin);
                marginV = (margin / 100.0f) * (parent.rect.height / 2);
            }
            else
            {
                float.TryParse(_anchor.marginV, out marginV);
            }

            Vector2 anchorMin = new Vector2(0.5f, 0.5f);
            Vector2 anchorMax = new Vector2(0.5f, 0.5f);
            Vector2 pivot = new Vector2(0.5f, 0.5f);
            if (_anchor.horizontal.Equals("left"))
            {
                anchorMin.x = 0;
                anchorMax.x = 0;
                pivot.x = 0;
            }
            else if (_anchor.horizontal.Equals("right"))
            {
                anchorMin.x = 1;
                anchorMax.x = 1;
                pivot.x = 1;
                marginH *= -1;
            }

            if (_anchor.vertical.Equals("top"))
            {
                anchorMin.y = 1;
                anchorMax.y = 1;
                pivot.y = 1;
                marginV *= -1;
            }
            else if (_anchor.vertical.Equals("bottom"))
            {
                anchorMin.y = 0;
                anchorMax.y = 0;
                pivot.y = 0;
            }

            Vector2 position = new Vector2(marginH, marginV);
            rectTransform.anchorMin = anchorMin;
            rectTransform.anchorMax = anchorMax;
            rectTransform.pivot = pivot;
            rectTransform.anchoredPosition = position;
            rectTransform.sizeDelta = new Vector2(_anchor.width, _anchor.height);
        }

        protected void loadSpriteFromTheme(string _file, System.Action<Sprite> _onFinish)
        {
            string datapath = settings_["datapath"].AsString();
            string vendor = settings_["vendor"].AsString();
            string dir = System.IO.Path.Combine(datapath, vendor);
            dir = System.IO.Path.Combine(dir, "themes");
            dir = System.IO.Path.Combine(dir, MyEntryBase.ModuleName);
            string filefullpath = System.IO.Path.Combine(dir, _file);
            themeObjectsPool.LoadTexture(filefullpath, null, (_texture) =>
            {
                var sprite = Sprite.Create(_texture as Texture2D, new Rect(0, 0, _texture.width, _texture.height), new Vector2(0.5f, 0.5f));
                _onFinish(sprite);
            });
        }

         
        protected string combineAssetPath(string _source, string _uri)
        {
            if(_source.Equals("file://assloud"))
            {
                var dir = Path.Combine(settings_["datapath"].AsString(), settings_["vendor"].AsString());
                dir = Path.Combine(dir, "assloud");
                return Path.Combine(dir, _uri);
            }
            return _uri;
        }


        protected virtual void submitAgentCreate(AgentCreateRequest _request)
        {
            var dto = new AgentCreateRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgeAgent.OnCreateSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitAgentUpdate(AgentUpdateRequest _request)
        {
            var dto = new AgentUpdateRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgeAgent.OnUpdateSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitAgentRetrieve(UuidRequest _request)
        {
            var dto = new UuidRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgeAgent.OnRetrieveSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitAgentDelete(UuidRequest _request)
        {
            var dto = new UuidRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgeAgent.OnDeleteSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitAgentList(AgentListRequest _request)
        {
            var dto = new AgentListRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgeAgent.OnListSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitAgentSearch(AgentSearchRequest _request)
        {
            var dto = new AgentSearchRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgeAgent.OnSearchSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitAgentPrepareUpload(UuidRequest _request)
        {
            var dto = new UuidRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgeAgent.OnPrepareUploadSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitAgentFlushUpload(UuidRequest _request)
        {
            var dto = new UuidRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgeAgent.OnFlushUploadSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitAgentAddFlag(FlagOperationRequest _request)
        {
            var dto = new FlagOperationRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgeAgent.OnAddFlagSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitAgentRemoveFlag(FlagOperationRequest _request)
        {
            var dto = new FlagOperationRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgeAgent.OnRemoveFlagSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitHealthyEcho(HealthyEchoRequest _request)
        {
            var dto = new HealthyEchoRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgeHealthy.OnEchoSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitModuleCreate(ModuleCreateRequest _request)
        {
            var dto = new ModuleCreateRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgeModule.OnCreateSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitModuleUpdate(ModuleUpdateRequest _request)
        {
            var dto = new ModuleUpdateRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgeModule.OnUpdateSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitModuleRetrieve(UuidRequest _request)
        {
            var dto = new UuidRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgeModule.OnRetrieveSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitModuleDelete(UuidRequest _request)
        {
            var dto = new UuidRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgeModule.OnDeleteSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitModuleList(ModuleListRequest _request)
        {
            var dto = new ModuleListRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgeModule.OnListSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitModuleSearch(ModuleSearchRequest _request)
        {
            var dto = new ModuleSearchRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgeModule.OnSearchSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitModulePrepareUpload(UuidRequest _request)
        {
            var dto = new UuidRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgeModule.OnPrepareUploadSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitModuleFlushUpload(UuidRequest _request)
        {
            var dto = new UuidRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgeModule.OnFlushUploadSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitModuleAddFlag(FlagOperationRequest _request)
        {
            var dto = new FlagOperationRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgeModule.OnAddFlagSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitModuleRemoveFlag(FlagOperationRequest _request)
        {
            var dto = new FlagOperationRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgeModule.OnRemoveFlagSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitPluginCreate(PluginCreateRequest _request)
        {
            var dto = new PluginCreateRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgePlugin.OnCreateSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitPluginUpdate(PluginUpdateRequest _request)
        {
            var dto = new PluginUpdateRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgePlugin.OnUpdateSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitPluginRetrieve(UuidRequest _request)
        {
            var dto = new UuidRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgePlugin.OnRetrieveSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitPluginDelete(UuidRequest _request)
        {
            var dto = new UuidRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgePlugin.OnDeleteSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitPluginList(PluginListRequest _request)
        {
            var dto = new PluginListRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgePlugin.OnListSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitPluginSearch(PluginSearchRequest _request)
        {
            var dto = new PluginSearchRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgePlugin.OnSearchSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitPluginPrepareUpload(UuidRequest _request)
        {
            var dto = new UuidRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgePlugin.OnPrepareUploadSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitPluginFlushUpload(UuidRequest _request)
        {
            var dto = new UuidRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgePlugin.OnFlushUploadSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitPluginAddFlag(FlagOperationRequest _request)
        {
            var dto = new FlagOperationRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgePlugin.OnAddFlagSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }

        protected virtual void submitPluginRemoveFlag(FlagOperationRequest _request)
        {
            var dto = new FlagOperationRequestDTO(_request);
            SynchronizationContext context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                try
                {
                    var reslut = await viewBridgePlugin.OnRemoveFlagSubmit(dto, context);
                    if (!LibMVCS.Error.IsOK(reslut))
                    {
                        logger_.Error(reslut.getMessage());
                    }
                }
                catch (System.Exception ex)
                {
                    logger_.Exception(ex);
                }
            });
        }


    }
}
