using Autofac;
using JueAo.Infrastructure;
using Prism.Ioc;
using Prism.Modularity;

namespace JueAo.AopModel.ModuleTwo
{

    [Module(ModuleName = "Two", OnDemand = false)]
    public class ModuleTwo : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Views.Ui2>("Ui2");

            MyContainer.Instance.Builder.RegisterType<ViewModels.Ui2ViewModel>();
        }
    }

}
