using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using JueAo.Infrastructure;
using Prism.DryIoc;
using Prism.Ioc;
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

        public class Mytest1
        {
            public virtual void Test()
            {
                System.Diagnostics.Trace.WriteLine("test");
            }
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

            MyContainer.Instance.Builder.Register(c => new CallTester());

            MyContainer.Instance.Builder.RegisterType<Views.MainWindowView>();
            MyContainer.Instance.Builder.RegisterType<ViewModels.MainWindowViewModel>()
                .InterceptedBy(typeof(CallTester))
                .EnableClassInterceptors();

            MyContainer.Instance.Builder.RegisterType<Mytest1>()
                .InterceptedBy(typeof(CallTester))
                .EnableClassInterceptors();

            MyContainer.Instance.Init();

            var mytest1 = MyContainer.Instance.Container.Resolve<Mytest1>();
            mytest1.Test();

            Views.MainWindowView mainWindowView = MyContainer.Instance.Container.Resolve<Views.MainWindowView>();

            ViewModels.MainWindowViewModel viewModel = MyContainer.Instance.Container.Resolve<ViewModels.MainWindowViewModel>();

            viewModel.ExecuteCommand1();
            //mainWindowView.DataContext = viewModel;

            return this.Container.Resolve<Views.MainWindowView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }

}
