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
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

    }

}
