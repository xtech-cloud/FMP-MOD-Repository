
//*************************************************************************************
//   !!! Generated by the fmp-cli 1.50.0.  DO NOT EDIT!
//*************************************************************************************

using System.Collections.Generic;
using Grpc.Net.Client;
using XTC.FMP.LIB.MVCS;

namespace XTC.FMP.MOD.Repository.LIB.MVCS
{

    /// <summary>
    /// 模块选项
    /// </summary>
    public class Options : UserData
    {
        /// <summary>
        /// 获取GRPC通道
        /// </summary>
        public GrpcChannel? getChannel()
        {
            return channel_;
        }

        /// <summary>
        /// 设置GRPC通道
        /// </summary>
        /// <param name="_channel">GRPC通道</param>
        public void setChannel(GrpcChannel? _channel)
        {
            channel_ = _channel;
        }

        /// <summary>
        /// GRPC通道
        /// </summary>
        private GrpcChannel? channel_;
    }

    /// <summary>
    /// 模块入口基类
    /// </summary>
    public class EntryBase : UserData
    {
        /// <summary>
        /// 模块选项
        /// </summary>
        protected Options? options_;

        protected Dictionary<string, AgentFacade?> facadeAgentStaticMap_ = new Dictionary<string, AgentFacade?>();
        protected Dictionary<string, AgentModel?> modelAgentStaticMap_ = new Dictionary<string, AgentModel?>();
        protected Dictionary<string, AgentView?> viewAgentStaticMap_ = new Dictionary<string, AgentView?>();
        protected Dictionary<string, AgentController?> controllerAgentStaticMap_ = new Dictionary<string, AgentController?>();
        protected Dictionary<string, AgentService?> serviceAgentStaticMap_ = new Dictionary<string, AgentService?>();

        protected Dictionary<string, AgentFacade?> facadeAgentDynamicMap_ = new Dictionary<string, AgentFacade?>();
        protected Dictionary<string, AgentModel?> modelAgentDynamicMap_ = new Dictionary<string, AgentModel?>();
        protected Dictionary<string, AgentView?> viewAgentDynamicMap_ = new Dictionary<string, AgentView?>();
        protected Dictionary<string, AgentController?> controllerAgentDynamicMap_ = new Dictionary<string, AgentController?>();
        protected Dictionary<string, AgentService?> serviceAgentDynamicMap_ = new Dictionary<string, AgentService?>();

        /// <summary>
        /// 获取Agent的UI装饰层
        /// </summary>
        /// <param name="_gid">直系的组的ID</param>
        /// <returns>UI装饰层</returns>
        public AgentFacade? getStaticAgentFacade(string _gid)
        {
            AgentFacade? facade = null;
            if (!facadeAgentStaticMap_.TryGetValue(AgentFacade.NAME + "." + _gid, out facade))
                return null;
            return facade;
        }

        /// <summary>
        /// 获取Agent的UI装饰层
        /// </summary>
        /// <param name="_gid">直系的组的ID</param>
        /// <returns>UI装饰层</returns>
        public AgentFacade? getDynamicAgentFacade(string _gid)
        {
            AgentFacade? facade = null;
            if (!facadeAgentDynamicMap_.TryGetValue(AgentFacade.NAME + "." + _gid, out facade))
                return null;
            return facade;
        }

        protected Dictionary<string, HealthyFacade?> facadeHealthyStaticMap_ = new Dictionary<string, HealthyFacade?>();
        protected Dictionary<string, HealthyModel?> modelHealthyStaticMap_ = new Dictionary<string, HealthyModel?>();
        protected Dictionary<string, HealthyView?> viewHealthyStaticMap_ = new Dictionary<string, HealthyView?>();
        protected Dictionary<string, HealthyController?> controllerHealthyStaticMap_ = new Dictionary<string, HealthyController?>();
        protected Dictionary<string, HealthyService?> serviceHealthyStaticMap_ = new Dictionary<string, HealthyService?>();

        protected Dictionary<string, HealthyFacade?> facadeHealthyDynamicMap_ = new Dictionary<string, HealthyFacade?>();
        protected Dictionary<string, HealthyModel?> modelHealthyDynamicMap_ = new Dictionary<string, HealthyModel?>();
        protected Dictionary<string, HealthyView?> viewHealthyDynamicMap_ = new Dictionary<string, HealthyView?>();
        protected Dictionary<string, HealthyController?> controllerHealthyDynamicMap_ = new Dictionary<string, HealthyController?>();
        protected Dictionary<string, HealthyService?> serviceHealthyDynamicMap_ = new Dictionary<string, HealthyService?>();

        /// <summary>
        /// 获取Healthy的UI装饰层
        /// </summary>
        /// <param name="_gid">直系的组的ID</param>
        /// <returns>UI装饰层</returns>
        public HealthyFacade? getStaticHealthyFacade(string _gid)
        {
            HealthyFacade? facade = null;
            if (!facadeHealthyStaticMap_.TryGetValue(HealthyFacade.NAME + "." + _gid, out facade))
                return null;
            return facade;
        }

        /// <summary>
        /// 获取Healthy的UI装饰层
        /// </summary>
        /// <param name="_gid">直系的组的ID</param>
        /// <returns>UI装饰层</returns>
        public HealthyFacade? getDynamicHealthyFacade(string _gid)
        {
            HealthyFacade? facade = null;
            if (!facadeHealthyDynamicMap_.TryGetValue(HealthyFacade.NAME + "." + _gid, out facade))
                return null;
            return facade;
        }

        protected Dictionary<string, ModuleFacade?> facadeModuleStaticMap_ = new Dictionary<string, ModuleFacade?>();
        protected Dictionary<string, ModuleModel?> modelModuleStaticMap_ = new Dictionary<string, ModuleModel?>();
        protected Dictionary<string, ModuleView?> viewModuleStaticMap_ = new Dictionary<string, ModuleView?>();
        protected Dictionary<string, ModuleController?> controllerModuleStaticMap_ = new Dictionary<string, ModuleController?>();
        protected Dictionary<string, ModuleService?> serviceModuleStaticMap_ = new Dictionary<string, ModuleService?>();

        protected Dictionary<string, ModuleFacade?> facadeModuleDynamicMap_ = new Dictionary<string, ModuleFacade?>();
        protected Dictionary<string, ModuleModel?> modelModuleDynamicMap_ = new Dictionary<string, ModuleModel?>();
        protected Dictionary<string, ModuleView?> viewModuleDynamicMap_ = new Dictionary<string, ModuleView?>();
        protected Dictionary<string, ModuleController?> controllerModuleDynamicMap_ = new Dictionary<string, ModuleController?>();
        protected Dictionary<string, ModuleService?> serviceModuleDynamicMap_ = new Dictionary<string, ModuleService?>();

        /// <summary>
        /// 获取Module的UI装饰层
        /// </summary>
        /// <param name="_gid">直系的组的ID</param>
        /// <returns>UI装饰层</returns>
        public ModuleFacade? getStaticModuleFacade(string _gid)
        {
            ModuleFacade? facade = null;
            if (!facadeModuleStaticMap_.TryGetValue(ModuleFacade.NAME + "." + _gid, out facade))
                return null;
            return facade;
        }

        /// <summary>
        /// 获取Module的UI装饰层
        /// </summary>
        /// <param name="_gid">直系的组的ID</param>
        /// <returns>UI装饰层</returns>
        public ModuleFacade? getDynamicModuleFacade(string _gid)
        {
            ModuleFacade? facade = null;
            if (!facadeModuleDynamicMap_.TryGetValue(ModuleFacade.NAME + "." + _gid, out facade))
                return null;
            return facade;
        }

        protected Dictionary<string, PluginFacade?> facadePluginStaticMap_ = new Dictionary<string, PluginFacade?>();
        protected Dictionary<string, PluginModel?> modelPluginStaticMap_ = new Dictionary<string, PluginModel?>();
        protected Dictionary<string, PluginView?> viewPluginStaticMap_ = new Dictionary<string, PluginView?>();
        protected Dictionary<string, PluginController?> controllerPluginStaticMap_ = new Dictionary<string, PluginController?>();
        protected Dictionary<string, PluginService?> servicePluginStaticMap_ = new Dictionary<string, PluginService?>();

        protected Dictionary<string, PluginFacade?> facadePluginDynamicMap_ = new Dictionary<string, PluginFacade?>();
        protected Dictionary<string, PluginModel?> modelPluginDynamicMap_ = new Dictionary<string, PluginModel?>();
        protected Dictionary<string, PluginView?> viewPluginDynamicMap_ = new Dictionary<string, PluginView?>();
        protected Dictionary<string, PluginController?> controllerPluginDynamicMap_ = new Dictionary<string, PluginController?>();
        protected Dictionary<string, PluginService?> servicePluginDynamicMap_ = new Dictionary<string, PluginService?>();

        /// <summary>
        /// 获取Plugin的UI装饰层
        /// </summary>
        /// <param name="_gid">直系的组的ID</param>
        /// <returns>UI装饰层</returns>
        public PluginFacade? getStaticPluginFacade(string _gid)
        {
            PluginFacade? facade = null;
            if (!facadePluginStaticMap_.TryGetValue(PluginFacade.NAME + "." + _gid, out facade))
                return null;
            return facade;
        }

        /// <summary>
        /// 获取Plugin的UI装饰层
        /// </summary>
        /// <param name="_gid">直系的组的ID</param>
        /// <returns>UI装饰层</returns>
        public PluginFacade? getDynamicPluginFacade(string _gid)
        {
            PluginFacade? facade = null;
            if (!facadePluginDynamicMap_.TryGetValue(PluginFacade.NAME + "." + _gid, out facade))
                return null;
            return facade;
        }


        /// <summary>
        /// 注入MVCS框架
        /// </summary>
        /// <param name="_framework">MVCS框架</param>
        /// <param name="_options">模块选项</param>
        public void Inject(Framework _framework, Options _options)
        {
            framework_ = _framework;
            options_ = _options;
        }

        /// <summary>
        /// 静态注册
        /// </summary>
        /// <param name="_gid">直系的组的ID</param>
        /// <param name="_logger">日志</param>
        /// <returns>错误</returns>
        protected Error staticRegister(string _gid, Logger? _logger)
        {
            _logger?.Trace("StaticRegister");

            if (null == framework_)
            {
                return Error.NewNullErr("framework is null");
            }

            // 注册数据层
            var modelAgent = new AgentModel(AgentModel.NAME + "." + _gid, _gid);
            modelAgentStaticMap_[AgentModel.NAME + "." + _gid] = modelAgent;
            framework_.getStaticPipe().RegisterModel(modelAgent);
            // 注册视图层
            var viewAgent = new AgentView(AgentView.NAME + "." + _gid, _gid);
            viewAgentStaticMap_[AgentView.NAME + "." + _gid] = viewAgent;
            framework_.getStaticPipe().RegisterView(viewAgent);
            // 注册控制层
            var controllerAgent = new AgentController(AgentController.NAME + "." + _gid, _gid);
            controllerAgentStaticMap_[AgentController.NAME + "." + _gid] = controllerAgent;
            framework_.getStaticPipe().RegisterController(controllerAgent);
            // 注册服务层
            var serviceAgent = new AgentService(AgentService.NAME + "." + _gid, _gid);
            serviceAgentStaticMap_[AgentService.NAME + "." + _gid] = serviceAgent;
            framework_.getStaticPipe().RegisterService(serviceAgent);
            serviceAgent.InjectGrpcChannel(options_?.getChannel());
            // 注册UI装饰层
            var facadeAgent = new AgentFacade(AgentFacade.NAME + "." + _gid, _gid);
            facadeAgentStaticMap_[AgentFacade.NAME + "." + _gid] = facadeAgent;
            var bridgeAgent = new AgentViewBridge();
            bridgeAgent.service = serviceAgent;
            facadeAgent.setViewBridge(bridgeAgent);
            framework_.getStaticPipe().RegisterFacade(facadeAgent);

            // 注册数据层
            var modelHealthy = new HealthyModel(HealthyModel.NAME + "." + _gid, _gid);
            modelHealthyStaticMap_[HealthyModel.NAME + "." + _gid] = modelHealthy;
            framework_.getStaticPipe().RegisterModel(modelHealthy);
            // 注册视图层
            var viewHealthy = new HealthyView(HealthyView.NAME + "." + _gid, _gid);
            viewHealthyStaticMap_[HealthyView.NAME + "." + _gid] = viewHealthy;
            framework_.getStaticPipe().RegisterView(viewHealthy);
            // 注册控制层
            var controllerHealthy = new HealthyController(HealthyController.NAME + "." + _gid, _gid);
            controllerHealthyStaticMap_[HealthyController.NAME + "." + _gid] = controllerHealthy;
            framework_.getStaticPipe().RegisterController(controllerHealthy);
            // 注册服务层
            var serviceHealthy = new HealthyService(HealthyService.NAME + "." + _gid, _gid);
            serviceHealthyStaticMap_[HealthyService.NAME + "." + _gid] = serviceHealthy;
            framework_.getStaticPipe().RegisterService(serviceHealthy);
            serviceHealthy.InjectGrpcChannel(options_?.getChannel());
            // 注册UI装饰层
            var facadeHealthy = new HealthyFacade(HealthyFacade.NAME + "." + _gid, _gid);
            facadeHealthyStaticMap_[HealthyFacade.NAME + "." + _gid] = facadeHealthy;
            var bridgeHealthy = new HealthyViewBridge();
            bridgeHealthy.service = serviceHealthy;
            facadeHealthy.setViewBridge(bridgeHealthy);
            framework_.getStaticPipe().RegisterFacade(facadeHealthy);

            // 注册数据层
            var modelModule = new ModuleModel(ModuleModel.NAME + "." + _gid, _gid);
            modelModuleStaticMap_[ModuleModel.NAME + "." + _gid] = modelModule;
            framework_.getStaticPipe().RegisterModel(modelModule);
            // 注册视图层
            var viewModule = new ModuleView(ModuleView.NAME + "." + _gid, _gid);
            viewModuleStaticMap_[ModuleView.NAME + "." + _gid] = viewModule;
            framework_.getStaticPipe().RegisterView(viewModule);
            // 注册控制层
            var controllerModule = new ModuleController(ModuleController.NAME + "." + _gid, _gid);
            controllerModuleStaticMap_[ModuleController.NAME + "." + _gid] = controllerModule;
            framework_.getStaticPipe().RegisterController(controllerModule);
            // 注册服务层
            var serviceModule = new ModuleService(ModuleService.NAME + "." + _gid, _gid);
            serviceModuleStaticMap_[ModuleService.NAME + "." + _gid] = serviceModule;
            framework_.getStaticPipe().RegisterService(serviceModule);
            serviceModule.InjectGrpcChannel(options_?.getChannel());
            // 注册UI装饰层
            var facadeModule = new ModuleFacade(ModuleFacade.NAME + "." + _gid, _gid);
            facadeModuleStaticMap_[ModuleFacade.NAME + "." + _gid] = facadeModule;
            var bridgeModule = new ModuleViewBridge();
            bridgeModule.service = serviceModule;
            facadeModule.setViewBridge(bridgeModule);
            framework_.getStaticPipe().RegisterFacade(facadeModule);

            // 注册数据层
            var modelPlugin = new PluginModel(PluginModel.NAME + "." + _gid, _gid);
            modelPluginStaticMap_[PluginModel.NAME + "." + _gid] = modelPlugin;
            framework_.getStaticPipe().RegisterModel(modelPlugin);
            // 注册视图层
            var viewPlugin = new PluginView(PluginView.NAME + "." + _gid, _gid);
            viewPluginStaticMap_[PluginView.NAME + "." + _gid] = viewPlugin;
            framework_.getStaticPipe().RegisterView(viewPlugin);
            // 注册控制层
            var controllerPlugin = new PluginController(PluginController.NAME + "." + _gid, _gid);
            controllerPluginStaticMap_[PluginController.NAME + "." + _gid] = controllerPlugin;
            framework_.getStaticPipe().RegisterController(controllerPlugin);
            // 注册服务层
            var servicePlugin = new PluginService(PluginService.NAME + "." + _gid, _gid);
            servicePluginStaticMap_[PluginService.NAME + "." + _gid] = servicePlugin;
            framework_.getStaticPipe().RegisterService(servicePlugin);
            servicePlugin.InjectGrpcChannel(options_?.getChannel());
            // 注册UI装饰层
            var facadePlugin = new PluginFacade(PluginFacade.NAME + "." + _gid, _gid);
            facadePluginStaticMap_[PluginFacade.NAME + "." + _gid] = facadePlugin;
            var bridgePlugin = new PluginViewBridge();
            bridgePlugin.service = servicePlugin;
            facadePlugin.setViewBridge(bridgePlugin);
            framework_.getStaticPipe().RegisterFacade(facadePlugin);

            return Error.OK;
        }

        /// <summary>
        /// 动态注册
        /// </summary>
        /// <param name="_gid">直系的组的ID</param>
        /// <param name="_logger">日志</param>
        /// <returns>错误</returns>
        protected Error dynamicRegister(string _gid, Logger _logger)
        {
            _logger.Trace("DynamicRegister");

            if (null == framework_)
            {
                return Error.NewNullErr("framework is null");
            }

            // 注册数据层
            var modelAgent = new AgentModel(AgentModel.NAME + "." + _gid, _gid);
            modelAgentDynamicMap_[AgentModel.NAME + "." + _gid] = modelAgent;
            framework_.getDynamicPipe().PushModel(modelAgent);
            // 注册视图层
            var viewAgent = new AgentView(AgentView.NAME + "." + _gid, _gid);
            viewAgentDynamicMap_[AgentView.NAME + "." + _gid] = viewAgent;
            framework_.getDynamicPipe().PushView(viewAgent);
            // 注册控制层
            var controllerAgent = new AgentController(AgentController.NAME + "." + _gid, _gid);
            controllerAgentDynamicMap_[AgentController.NAME + "." + _gid] = controllerAgent;
            framework_.getDynamicPipe().PushController(controllerAgent);
            // 注册服务层
            var serviceAgent = new AgentService(AgentService.NAME + "." + _gid, _gid);
            serviceAgentDynamicMap_[AgentService.NAME + "." + _gid] = serviceAgent;
            framework_.getDynamicPipe().PushService(serviceAgent);
            serviceAgent.InjectGrpcChannel(options_?.getChannel());
            // 注册UI装饰层
            var facadeAgent = new AgentFacade(AgentFacade.NAME + "." + _gid, _gid);
            facadeAgentDynamicMap_[AgentFacade.NAME + "." + _gid] = facadeAgent;
            var bridgeAgent = new AgentViewBridge();
            bridgeAgent.service = serviceAgent;
            facadeAgent.setViewBridge(bridgeAgent);
            framework_.getDynamicPipe().PushFacade(facadeAgent);

            // 注册数据层
            var modelHealthy = new HealthyModel(HealthyModel.NAME + "." + _gid, _gid);
            modelHealthyDynamicMap_[HealthyModel.NAME + "." + _gid] = modelHealthy;
            framework_.getDynamicPipe().PushModel(modelHealthy);
            // 注册视图层
            var viewHealthy = new HealthyView(HealthyView.NAME + "." + _gid, _gid);
            viewHealthyDynamicMap_[HealthyView.NAME + "." + _gid] = viewHealthy;
            framework_.getDynamicPipe().PushView(viewHealthy);
            // 注册控制层
            var controllerHealthy = new HealthyController(HealthyController.NAME + "." + _gid, _gid);
            controllerHealthyDynamicMap_[HealthyController.NAME + "." + _gid] = controllerHealthy;
            framework_.getDynamicPipe().PushController(controllerHealthy);
            // 注册服务层
            var serviceHealthy = new HealthyService(HealthyService.NAME + "." + _gid, _gid);
            serviceHealthyDynamicMap_[HealthyService.NAME + "." + _gid] = serviceHealthy;
            framework_.getDynamicPipe().PushService(serviceHealthy);
            serviceHealthy.InjectGrpcChannel(options_?.getChannel());
            // 注册UI装饰层
            var facadeHealthy = new HealthyFacade(HealthyFacade.NAME + "." + _gid, _gid);
            facadeHealthyDynamicMap_[HealthyFacade.NAME + "." + _gid] = facadeHealthy;
            var bridgeHealthy = new HealthyViewBridge();
            bridgeHealthy.service = serviceHealthy;
            facadeHealthy.setViewBridge(bridgeHealthy);
            framework_.getDynamicPipe().PushFacade(facadeHealthy);

            // 注册数据层
            var modelModule = new ModuleModel(ModuleModel.NAME + "." + _gid, _gid);
            modelModuleDynamicMap_[ModuleModel.NAME + "." + _gid] = modelModule;
            framework_.getDynamicPipe().PushModel(modelModule);
            // 注册视图层
            var viewModule = new ModuleView(ModuleView.NAME + "." + _gid, _gid);
            viewModuleDynamicMap_[ModuleView.NAME + "." + _gid] = viewModule;
            framework_.getDynamicPipe().PushView(viewModule);
            // 注册控制层
            var controllerModule = new ModuleController(ModuleController.NAME + "." + _gid, _gid);
            controllerModuleDynamicMap_[ModuleController.NAME + "." + _gid] = controllerModule;
            framework_.getDynamicPipe().PushController(controllerModule);
            // 注册服务层
            var serviceModule = new ModuleService(ModuleService.NAME + "." + _gid, _gid);
            serviceModuleDynamicMap_[ModuleService.NAME + "." + _gid] = serviceModule;
            framework_.getDynamicPipe().PushService(serviceModule);
            serviceModule.InjectGrpcChannel(options_?.getChannel());
            // 注册UI装饰层
            var facadeModule = new ModuleFacade(ModuleFacade.NAME + "." + _gid, _gid);
            facadeModuleDynamicMap_[ModuleFacade.NAME + "." + _gid] = facadeModule;
            var bridgeModule = new ModuleViewBridge();
            bridgeModule.service = serviceModule;
            facadeModule.setViewBridge(bridgeModule);
            framework_.getDynamicPipe().PushFacade(facadeModule);

            // 注册数据层
            var modelPlugin = new PluginModel(PluginModel.NAME + "." + _gid, _gid);
            modelPluginDynamicMap_[PluginModel.NAME + "." + _gid] = modelPlugin;
            framework_.getDynamicPipe().PushModel(modelPlugin);
            // 注册视图层
            var viewPlugin = new PluginView(PluginView.NAME + "." + _gid, _gid);
            viewPluginDynamicMap_[PluginView.NAME + "." + _gid] = viewPlugin;
            framework_.getDynamicPipe().PushView(viewPlugin);
            // 注册控制层
            var controllerPlugin = new PluginController(PluginController.NAME + "." + _gid, _gid);
            controllerPluginDynamicMap_[PluginController.NAME + "." + _gid] = controllerPlugin;
            framework_.getDynamicPipe().PushController(controllerPlugin);
            // 注册服务层
            var servicePlugin = new PluginService(PluginService.NAME + "." + _gid, _gid);
            servicePluginDynamicMap_[PluginService.NAME + "." + _gid] = servicePlugin;
            framework_.getDynamicPipe().PushService(servicePlugin);
            servicePlugin.InjectGrpcChannel(options_?.getChannel());
            // 注册UI装饰层
            var facadePlugin = new PluginFacade(PluginFacade.NAME + "." + _gid, _gid);
            facadePluginDynamicMap_[PluginFacade.NAME + "." + _gid] = facadePlugin;
            var bridgePlugin = new PluginViewBridge();
            bridgePlugin.service = servicePlugin;
            facadePlugin.setViewBridge(bridgePlugin);
            framework_.getDynamicPipe().PushFacade(facadePlugin);

            return Error.OK;
        }

        /// <summary>
        /// 静态注销
        /// </summary>
        /// <param name="_gid">直系的组的ID</param>
        /// <param name="_logger">日志</param>
        /// <returns>错误</returns>
        protected Error staticCancel(string _gid, Logger _logger)
        {
            _logger?.Trace("StaticCancel");

            if (null == framework_)
            {
                return Error.NewNullErr("framework is null");
            }

            // 注销服务层
            AgentService? serviceAgent;
            if(serviceAgentStaticMap_.TryGetValue(AgentService.NAME + "." + _gid, out serviceAgent))
            {
                framework_.getStaticPipe().CancelService(serviceAgent);
                serviceAgentStaticMap_.Remove(AgentService.NAME + "." +_gid);
            }
            // 注销控制层
            AgentController? controllerAgent;
            if(controllerAgentStaticMap_.TryGetValue(AgentController.NAME + "." + _gid, out controllerAgent))
            {
                framework_.getStaticPipe().CancelController(controllerAgent);
                controllerAgentStaticMap_.Remove(AgentController.NAME + "." +_gid);
            }
            // 注销视图层
            AgentView? viewAgent;
            if(viewAgentStaticMap_.TryGetValue(AgentView.NAME + "." + _gid, out viewAgent))
            {
                framework_.getStaticPipe().CancelView(viewAgent);
                viewAgentStaticMap_.Remove(AgentView.NAME + "." +_gid);
            }
            // 注销UI装饰层
            AgentFacade? facadeAgent;
            if(facadeAgentStaticMap_.TryGetValue(AgentFacade.NAME + "." + _gid, out facadeAgent))
            {
                framework_.getStaticPipe().CancelFacade(facadeAgent);
                facadeAgentStaticMap_.Remove(AgentFacade.NAME + "." +_gid);
            }
            // 注销数据层
            AgentModel? modelAgent;
            if(modelAgentStaticMap_.TryGetValue(AgentModel.NAME + "." + _gid, out modelAgent))
            {
                framework_.getStaticPipe().CancelModel(modelAgent);
                modelAgentStaticMap_.Remove(AgentModel.NAME + "." +_gid);
            }

            // 注销服务层
            HealthyService? serviceHealthy;
            if(serviceHealthyStaticMap_.TryGetValue(HealthyService.NAME + "." + _gid, out serviceHealthy))
            {
                framework_.getStaticPipe().CancelService(serviceHealthy);
                serviceHealthyStaticMap_.Remove(HealthyService.NAME + "." +_gid);
            }
            // 注销控制层
            HealthyController? controllerHealthy;
            if(controllerHealthyStaticMap_.TryGetValue(HealthyController.NAME + "." + _gid, out controllerHealthy))
            {
                framework_.getStaticPipe().CancelController(controllerHealthy);
                controllerHealthyStaticMap_.Remove(HealthyController.NAME + "." +_gid);
            }
            // 注销视图层
            HealthyView? viewHealthy;
            if(viewHealthyStaticMap_.TryGetValue(HealthyView.NAME + "." + _gid, out viewHealthy))
            {
                framework_.getStaticPipe().CancelView(viewHealthy);
                viewHealthyStaticMap_.Remove(HealthyView.NAME + "." +_gid);
            }
            // 注销UI装饰层
            HealthyFacade? facadeHealthy;
            if(facadeHealthyStaticMap_.TryGetValue(HealthyFacade.NAME + "." + _gid, out facadeHealthy))
            {
                framework_.getStaticPipe().CancelFacade(facadeHealthy);
                facadeHealthyStaticMap_.Remove(HealthyFacade.NAME + "." +_gid);
            }
            // 注销数据层
            HealthyModel? modelHealthy;
            if(modelHealthyStaticMap_.TryGetValue(HealthyModel.NAME + "." + _gid, out modelHealthy))
            {
                framework_.getStaticPipe().CancelModel(modelHealthy);
                modelHealthyStaticMap_.Remove(HealthyModel.NAME + "." +_gid);
            }

            // 注销服务层
            ModuleService? serviceModule;
            if(serviceModuleStaticMap_.TryGetValue(ModuleService.NAME + "." + _gid, out serviceModule))
            {
                framework_.getStaticPipe().CancelService(serviceModule);
                serviceModuleStaticMap_.Remove(ModuleService.NAME + "." +_gid);
            }
            // 注销控制层
            ModuleController? controllerModule;
            if(controllerModuleStaticMap_.TryGetValue(ModuleController.NAME + "." + _gid, out controllerModule))
            {
                framework_.getStaticPipe().CancelController(controllerModule);
                controllerModuleStaticMap_.Remove(ModuleController.NAME + "." +_gid);
            }
            // 注销视图层
            ModuleView? viewModule;
            if(viewModuleStaticMap_.TryGetValue(ModuleView.NAME + "." + _gid, out viewModule))
            {
                framework_.getStaticPipe().CancelView(viewModule);
                viewModuleStaticMap_.Remove(ModuleView.NAME + "." +_gid);
            }
            // 注销UI装饰层
            ModuleFacade? facadeModule;
            if(facadeModuleStaticMap_.TryGetValue(ModuleFacade.NAME + "." + _gid, out facadeModule))
            {
                framework_.getStaticPipe().CancelFacade(facadeModule);
                facadeModuleStaticMap_.Remove(ModuleFacade.NAME + "." +_gid);
            }
            // 注销数据层
            ModuleModel? modelModule;
            if(modelModuleStaticMap_.TryGetValue(ModuleModel.NAME + "." + _gid, out modelModule))
            {
                framework_.getStaticPipe().CancelModel(modelModule);
                modelModuleStaticMap_.Remove(ModuleModel.NAME + "." +_gid);
            }

            // 注销服务层
            PluginService? servicePlugin;
            if(servicePluginStaticMap_.TryGetValue(PluginService.NAME + "." + _gid, out servicePlugin))
            {
                framework_.getStaticPipe().CancelService(servicePlugin);
                servicePluginStaticMap_.Remove(PluginService.NAME + "." +_gid);
            }
            // 注销控制层
            PluginController? controllerPlugin;
            if(controllerPluginStaticMap_.TryGetValue(PluginController.NAME + "." + _gid, out controllerPlugin))
            {
                framework_.getStaticPipe().CancelController(controllerPlugin);
                controllerPluginStaticMap_.Remove(PluginController.NAME + "." +_gid);
            }
            // 注销视图层
            PluginView? viewPlugin;
            if(viewPluginStaticMap_.TryGetValue(PluginView.NAME + "." + _gid, out viewPlugin))
            {
                framework_.getStaticPipe().CancelView(viewPlugin);
                viewPluginStaticMap_.Remove(PluginView.NAME + "." +_gid);
            }
            // 注销UI装饰层
            PluginFacade? facadePlugin;
            if(facadePluginStaticMap_.TryGetValue(PluginFacade.NAME + "." + _gid, out facadePlugin))
            {
                framework_.getStaticPipe().CancelFacade(facadePlugin);
                facadePluginStaticMap_.Remove(PluginFacade.NAME + "." +_gid);
            }
            // 注销数据层
            PluginModel? modelPlugin;
            if(modelPluginStaticMap_.TryGetValue(PluginModel.NAME + "." + _gid, out modelPlugin))
            {
                framework_.getStaticPipe().CancelModel(modelPlugin);
                modelPluginStaticMap_.Remove(PluginModel.NAME + "." +_gid);
            }

            return Error.OK;
        }

        /// <summary>
        /// 动态注销
        /// </summary>
        /// <param name="_gid">直系的组的ID</param>
        /// <param name="_logger">日志</param>
        /// <returns>错误</returns>
        protected Error dynamicCancel(string _gid, Logger _logger)
        {
            _logger?.Trace("DynamicCancel");

            if (null == framework_)
            {
                return Error.NewNullErr("framework is null");
            }

            // 注销服务层
            AgentService? serviceAgent;
            if(serviceAgentDynamicMap_.TryGetValue(AgentService.NAME + "." + _gid, out serviceAgent))
            {
                framework_.getDynamicPipe().PopService(serviceAgent);
                serviceAgentDynamicMap_.Remove(AgentService.NAME + "." +_gid);
            }
            // 注销控制层
            AgentController? controllerAgent;
            if(controllerAgentDynamicMap_.TryGetValue(AgentController.NAME + "." + _gid, out controllerAgent))
            {
                framework_.getDynamicPipe().PopController(controllerAgent);
                controllerAgentDynamicMap_.Remove(AgentController.NAME + "." +_gid);
            }
            // 注销视图层
            AgentView? viewAgent;
            if(viewAgentDynamicMap_.TryGetValue(AgentView.NAME + "." + _gid, out viewAgent))
            {
                framework_.getDynamicPipe().PopView(viewAgent);
                viewAgentDynamicMap_.Remove(AgentView.NAME + "." +_gid);
            }
            // 注销UI装饰层
            AgentFacade? facadeAgent;
            if(facadeAgentDynamicMap_.TryGetValue(AgentFacade.NAME + "." + _gid, out facadeAgent))
            {
                framework_.getDynamicPipe().PopFacade(facadeAgent);
                facadeAgentDynamicMap_.Remove(AgentFacade.NAME + "." +_gid);
            }
            // 注销数据层
            AgentModel? modelAgent;
            if(modelAgentDynamicMap_.TryGetValue(AgentModel.NAME + "." + _gid, out modelAgent))
            {
                framework_.getDynamicPipe().PopModel(modelAgent);
                modelAgentDynamicMap_.Remove(AgentModel.NAME + "." +_gid);
            }

            // 注销服务层
            HealthyService? serviceHealthy;
            if(serviceHealthyDynamicMap_.TryGetValue(HealthyService.NAME + "." + _gid, out serviceHealthy))
            {
                framework_.getDynamicPipe().PopService(serviceHealthy);
                serviceHealthyDynamicMap_.Remove(HealthyService.NAME + "." +_gid);
            }
            // 注销控制层
            HealthyController? controllerHealthy;
            if(controllerHealthyDynamicMap_.TryGetValue(HealthyController.NAME + "." + _gid, out controllerHealthy))
            {
                framework_.getDynamicPipe().PopController(controllerHealthy);
                controllerHealthyDynamicMap_.Remove(HealthyController.NAME + "." +_gid);
            }
            // 注销视图层
            HealthyView? viewHealthy;
            if(viewHealthyDynamicMap_.TryGetValue(HealthyView.NAME + "." + _gid, out viewHealthy))
            {
                framework_.getDynamicPipe().PopView(viewHealthy);
                viewHealthyDynamicMap_.Remove(HealthyView.NAME + "." +_gid);
            }
            // 注销UI装饰层
            HealthyFacade? facadeHealthy;
            if(facadeHealthyDynamicMap_.TryGetValue(HealthyFacade.NAME + "." + _gid, out facadeHealthy))
            {
                framework_.getDynamicPipe().PopFacade(facadeHealthy);
                facadeHealthyDynamicMap_.Remove(HealthyFacade.NAME + "." +_gid);
            }
            // 注销数据层
            HealthyModel? modelHealthy;
            if(modelHealthyDynamicMap_.TryGetValue(HealthyModel.NAME + "." + _gid, out modelHealthy))
            {
                framework_.getDynamicPipe().PopModel(modelHealthy);
                modelHealthyDynamicMap_.Remove(HealthyModel.NAME + "." +_gid);
            }

            // 注销服务层
            ModuleService? serviceModule;
            if(serviceModuleDynamicMap_.TryGetValue(ModuleService.NAME + "." + _gid, out serviceModule))
            {
                framework_.getDynamicPipe().PopService(serviceModule);
                serviceModuleDynamicMap_.Remove(ModuleService.NAME + "." +_gid);
            }
            // 注销控制层
            ModuleController? controllerModule;
            if(controllerModuleDynamicMap_.TryGetValue(ModuleController.NAME + "." + _gid, out controllerModule))
            {
                framework_.getDynamicPipe().PopController(controllerModule);
                controllerModuleDynamicMap_.Remove(ModuleController.NAME + "." +_gid);
            }
            // 注销视图层
            ModuleView? viewModule;
            if(viewModuleDynamicMap_.TryGetValue(ModuleView.NAME + "." + _gid, out viewModule))
            {
                framework_.getDynamicPipe().PopView(viewModule);
                viewModuleDynamicMap_.Remove(ModuleView.NAME + "." +_gid);
            }
            // 注销UI装饰层
            ModuleFacade? facadeModule;
            if(facadeModuleDynamicMap_.TryGetValue(ModuleFacade.NAME + "." + _gid, out facadeModule))
            {
                framework_.getDynamicPipe().PopFacade(facadeModule);
                facadeModuleDynamicMap_.Remove(ModuleFacade.NAME + "." +_gid);
            }
            // 注销数据层
            ModuleModel? modelModule;
            if(modelModuleDynamicMap_.TryGetValue(ModuleModel.NAME + "." + _gid, out modelModule))
            {
                framework_.getDynamicPipe().PopModel(modelModule);
                modelModuleDynamicMap_.Remove(ModuleModel.NAME + "." +_gid);
            }

            // 注销服务层
            PluginService? servicePlugin;
            if(servicePluginDynamicMap_.TryGetValue(PluginService.NAME + "." + _gid, out servicePlugin))
            {
                framework_.getDynamicPipe().PopService(servicePlugin);
                servicePluginDynamicMap_.Remove(PluginService.NAME + "." +_gid);
            }
            // 注销控制层
            PluginController? controllerPlugin;
            if(controllerPluginDynamicMap_.TryGetValue(PluginController.NAME + "." + _gid, out controllerPlugin))
            {
                framework_.getDynamicPipe().PopController(controllerPlugin);
                controllerPluginDynamicMap_.Remove(PluginController.NAME + "." +_gid);
            }
            // 注销视图层
            PluginView? viewPlugin;
            if(viewPluginDynamicMap_.TryGetValue(PluginView.NAME + "." + _gid, out viewPlugin))
            {
                framework_.getDynamicPipe().PopView(viewPlugin);
                viewPluginDynamicMap_.Remove(PluginView.NAME + "." +_gid);
            }
            // 注销UI装饰层
            PluginFacade? facadePlugin;
            if(facadePluginDynamicMap_.TryGetValue(PluginFacade.NAME + "." + _gid, out facadePlugin))
            {
                framework_.getDynamicPipe().PopFacade(facadePlugin);
                facadePluginDynamicMap_.Remove(PluginFacade.NAME + "." +_gid);
            }
            // 注销数据层
            PluginModel? modelPlugin;
            if(modelPluginDynamicMap_.TryGetValue(PluginModel.NAME + "." + _gid, out modelPlugin))
            {
                framework_.getDynamicPipe().PopModel(modelPlugin);
                modelPluginDynamicMap_.Remove(PluginModel.NAME + "." +_gid);
            }

            return Error.OK;
        }

        /// <summary>
        /// MVCS框架
        /// </summary>
        protected Framework? framework_;
    }
}

