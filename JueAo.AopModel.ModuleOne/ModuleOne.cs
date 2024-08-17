
using Autofac;
using JueAo.Infrastructure;
using Prism.Ioc;
using Prism.Modularity;

namespace JueAo.AopModel.ModuleOne
{
    [Module(ModuleName = "One", OnDemand = false)]
    public class ModuleOne : IModule, IModuleRegisterViewModel
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Views.Ui1>("Ui1");

        }

        public void RegisterViewModule()
        {
            MyContainer.Instance.Builder.RegisterType<ViewModels.Ui1ViewModel>();
        }
    }

}
