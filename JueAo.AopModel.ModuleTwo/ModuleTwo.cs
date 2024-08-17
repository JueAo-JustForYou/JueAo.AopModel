using Autofac;
using Autofac.Extras.DynamicProxy;
using JueAo.Infrastructure;
using JueAo.Infrastructure.Aops;
using Prism.Ioc;
using Prism.Modularity;

namespace JueAo.AopModel.ModuleTwo
{

    [Module(ModuleName = "Two", OnDemand = false)]
    public class ModuleTwo : IModule, IModuleRegisterViewModel
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Views.Ui2>("Ui2");



        }

        public void RegisterViewModule()
        {
            MyContainer.Instance.Builder
                .RegisterType<ViewModels.Ui2ViewModel>()
                .InterceptedBy(typeof(CommandLogAop))
                .EnableClassInterceptors();
        }
    }

}
