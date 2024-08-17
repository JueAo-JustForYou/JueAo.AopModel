using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using JueAo.Infrastructure;
using JueAo.Infrastructure.Aops;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace JueAo.AopModel
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        public App()
        {
            string basePath = AppContext.BaseDirectory;

            //MyContainer.Instance.Builder.RegisterType<CommandLogAop>();
            //MyContainer.Instance.Builder.Register( x => new CommandLogAop());

            //Type[] aopTypes = new Type[] { typeof(CommandLogAop)};

            //string appPath = Path.Combine(basePath, "JueAo.AopModel.dll");

            //MyContainer.Instance.Builder.RegisterAssemblyTypes(Assembly.LoadFrom(appPath))
            //    .Where(x => x.Name.EndsWith("ViewModel") && x.IsClass)
            //    .PublicOnly()
            //    //.InstancePerDependency()
            //    .InterceptedBy(typeof(CommandLogAop))
            //    //.PropertiesAutowired()
            //    .EnableClassInterceptors();

            //MyContainer.Instance.Builder.RegisterAssemblyTypes(Assembly.LoadFrom(appPath))
            //    .Where(x => x.Name.EndsWith("View") && x.IsClass)
            //    .PublicOnly()
            //    .InstancePerDependency()
            //    //.InterceptedBy(aopTypes)
            //    .PropertiesAutowired();

            //MyContainer.Instance.Init();






        }

        private void LoadAllViewModels()
        {
            string basePath = Path.Combine(AppContext.BaseDirectory, "Modules");
            if (!Directory.Exists(basePath))
            {
                return;
            }

            //Type iIModuleRegisterViewModelType = typeof(IModuleRegisterViewModel);


            //List<Assembly> assemblies = new List<Assembly>();

            //string[] files = Directory.GetFiles(basePath, "*.dll");
            //foreach (var file in files)
            //{
            //    Assembly assembly = Assembly.LoadFrom(file);
            //    foreach (var item in assembly.GetTypes()
            //        .Where(x => !x.IsAbstract && iIModuleRegisterViewModelType.IsAssignableFrom(x)))
            //    {
            //        IModuleRegisterViewModel moduleRegisterViewModel = (IModuleRegisterViewModel)Activator.CreateInstance(item);
            //        moduleRegisterViewModel.RegisterViewModule();

            //        assemblies.Add(assembly);
            //    }

            //    //Assembly assembly = Assembly.LoadFrom(file);

            //    //foreach (Type type in assembly.GetTypes()
            //    //    .Where(x=>x.IsInterface== false))
            //    //{
            //    //    if(type.GetInterfaces().Any(iface=> iface.get))
            //    //}
            //}


            MyContainer.Instance.Builder.Register(c => new CallTester());
            MyContainer.Instance.Builder.Register(c => new CommandLogAop());

            MyContainer.Instance.Builder.RegisterType<Views.MainWindowView>();
            MyContainer.Instance.Builder.RegisterType<ViewModels.MainWindowViewModel>()
                .InterceptedBy(typeof(CommandLogAop))
                .EnableClassInterceptors();

            MyContainer.Instance.Builder.Register<IRegionManager>(x => this.Container.Resolve<RegionManager>());

    //        MyContainer.Instance.Builder
    //.RegisterType<AopModel.ModuleTwo.ViewModels.Ui2ViewModel>()
    //.InterceptedBy(typeof(CommandLogAop))
    //.EnableClassInterceptors();

            //foreach (var assembly in assemblies)
            //{
            //    foreach (Type type in assembly.GetTypes()
            //        .Where(x=> !x.IsAbstract && x.Name.EndsWith("ViewModel") && x.IsClass))
            //    {
            //        Type? viewType = assembly.GetTypes().FirstOrDefault(x => !x.IsAbstract
            //            && (x.Name.Equals(type.Name.Replace("ViewModel", "View")) || x.Name.Equals(type.Name.Replace("ViewModel", ""))));

            //        if (viewType != null)
            //        {
            //            ViewModelLocationProvider.Register(viewType.ToString(), () => MyContainer.Instance.Container.Resolve(type));
            //            System.Diagnostics.Trace.WriteLine($"{viewType.ToString()}-{type.ToString()}");
            //        }
            //    }
            //}

            MyContainer.Instance.Init();

        }


        public class Mytest1
        {
            public virtual void Test()
            {
                System.Diagnostics.Trace.WriteLine("test");
            }
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            string modulePath = @".\Modules";
            if (!Directory.Exists(modulePath))
            {
                Directory.CreateDirectory(modulePath);
            }


            return new DirectoryModuleCatalog() { ModulePath = modulePath };
        }

        public class CallTester : IInterceptor
        {
            public void Intercept(IInvocation invocation)
            {
                System.Diagnostics.Trace.WriteLine("啥也不干");
                invocation.Proceed();
                System.Diagnostics.Trace.WriteLine("也不干啥");
            }
        }

        protected override Window CreateShell()
        {
            return this.Container.Resolve<Views.MainWindowView>();

            //LoadAllViewModels();

            //return MyContainer.Instance.Container.Resolve<Views.MainWindowView>();
           
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            //LoadAllViewModels();

            //containerRegistry.Register<ViewModels.MainWindowViewModel>(() =>
            //{
            //    return MyContainer.Instance.Container.Resolve<ViewModels.MainWindowViewModel>();
            //});


            //containerRegistry.Register<AopModel.ModuleTwo.ViewModels.Ui2ViewModel>(() =>
            //{
            //    return MyContainer.Instance.Container.Resolve<AopModel.ModuleTwo.ViewModels.Ui2ViewModel>();
            //});

            //containerRegistry.Register<AopModel.ModuleOne.ViewModels.Ui1ViewModel>(() =>
            //{
            //    return MyContainer.Instance.Container.Resolve<AopModel.ModuleOne.ViewModels.Ui1ViewModel>();
            //});


        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();


            //LoadAllViewModels();

            //ViewModelLocationProvider.Register(typeof(Views.MainWindowView).ToString(),
            //    () => MyContainer.Instance.Container.Resolve<ViewModels.MainWindowViewModel>()
            //);

            //ViewModelLocationProvider.SetDefaultViewModelFactory(
            //    (Func<object, Type, object>)((view, type) =>
            //    {
            //        return MyContainer.Instance.Container.Resolve(type);
            //    })
            //);




        }
    }

}
