using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using JueAo.Infrastructure;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System.IO;
using System.Reflection;
using System.Windows;

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

            Type iIModuleRegisterViewModelType = typeof(IModuleRegisterViewModel);

            string[] files = Directory.GetFiles(basePath, "*.dll");
            foreach (var file in files)
            {
                foreach (var item in Assembly.LoadFrom(file).GetTypes()
                    .Where(x=>!x.IsAbstract && iIModuleRegisterViewModelType.IsAssignableFrom(x)))
                {
                    IModuleRegisterViewModel moduleRegisterViewModel = this.Container.Resolve(item) as IModuleRegisterViewModel;
                    moduleRegisterViewModel.RegisterViewModule();
                }

                //Assembly assembly = Assembly.LoadFrom(file);

                //foreach (Type type in assembly.GetTypes()
                //    .Where(x=>x.IsInterface== false))
                //{
                //    if(type.GetInterfaces().Any(iface=> iface.get))
                //}
            }

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
            //LoadAllViewModels();

            MyContainer.Instance.Builder.Register(c => new CallTester());

            MyContainer.Instance.Builder.RegisterType<Views.MainWindowView>();
            MyContainer.Instance.Builder.RegisterType<ViewModels.MainWindowViewModel>()
                .InterceptedBy(typeof(CallTester))
                .EnableClassInterceptors();

            MyContainer.Instance.Builder.RegisterType<Mytest1>()
                .InterceptedBy(typeof(CallTester))
                .EnableClassInterceptors();

            MyContainer.Instance.Builder.Register<IRegionManager>(x => this.Container.Resolve<RegionManager>());

            MyContainer.Instance.Init();

            var mytest1 = MyContainer.Instance.Container.Resolve<Mytest1>();
            mytest1.Test();

            //mainWindowView.DataContext = viewModel;

            

            return this.Container.Resolve<Views.MainWindowView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        //protected override void ConfigureViewModelLocator()
        //{
        //    base.ConfigureViewModelLocator();

        //    ViewModelLocationProvider.SetDefaultViewModelFactory(
        //        (Func<object, Type, object>)((view, type) =>
        //        {
        //            return MyContainer.Instance.Container.Resolve(type);
        //        })
        //    );

        //}
    }

}
