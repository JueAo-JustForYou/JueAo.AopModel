using Autofac;
using Autofac.Extras.DynamicProxy;
using JueAo.AopModel.ViewModels;
using JueAo.Infrastructure;
using JueAo.Infrastructure.Aops;
using Microsoft.Extensions.Logging;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace JueAo.AopModel.Views
{
    /// <summary>
    /// MainWindowView.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindowView : Window
    {
        private readonly IRegionManager m_regionManager;

        public MainWindowView(IRegionManager regionManager)
        {
            InitializeComponent();
            
            this.Loaded += MainWindowView_Loaded;
            m_regionManager = regionManager;
        }

        private void MainWindowView_Loaded(object sender, RoutedEventArgs e)
        {
            //MyContainer.Instance.Init();
            LoadAllViewModels();
        }

        private void LoadAllViewModels()
        {
            string basePath = System.IO.Path.Combine(AppContext.BaseDirectory, "Modules");
            if (!Directory.Exists(basePath))
            {
                return;
            }

            //        MyContainer.Instance.Builder
            //.RegisterType<AopModel.ModuleTwo.ViewModels.Ui2ViewModel>()
            //.InterceptedBy(typeof(CommandLogAop))
            //.EnableClassInterceptors();
            Type iIModuleRegisterViewModelType = typeof(IModuleRegisterViewModel);

            List<Assembly> assemblies = new List<Assembly>();

            string[] files = Directory.GetFiles(basePath, "*.dll");
            foreach (var file in files)
            {
                Assembly assembly = Assembly.LoadFrom(file);
                foreach (var item in assembly.GetTypes()
                    .Where(x => !x.IsAbstract && iIModuleRegisterViewModelType.IsAssignableFrom(x)))
                {
                    IModuleRegisterViewModel moduleRegisterViewModel = (IModuleRegisterViewModel)Activator.CreateInstance(item);
                    moduleRegisterViewModel.RegisterViewModule();

                    assemblies.Add(assembly);
                }

                //Assembly assembly = Assembly.LoadFrom(file);

                //foreach (Type type in assembly.GetTypes()
                //    .Where(x=>x.IsInterface== false))
                //{
                //    if(type.GetInterfaces().Any(iface=> iface.get))
                //}
            }


            //MyContainer.Instance.Builder.Register(c => new CommandLogAop());
            MyContainer.Instance.Builder.RegisterType<TraceLogger>();
            MyContainer.Instance.Builder.RegisterType<CommandLogAop>();

            //MyContainer.Instance.Builder.RegisterType<Views.MainWindowView>();
            //MyContainer.Instance.Builder.RegisterType<ViewModels.MainWindowViewModel>()
            //    .InterceptedBy(typeof(CommandLogAop))
            //    .EnableClassInterceptors();


            //MyContainer.Instance.Builder.Register<IRegionManager>(x => this.Container.Resolve<RegionManager>());
            MyContainer.Instance.Builder.Register<IRegionManager>(x => m_regionManager);

            MyContainer.Instance.Init();

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

        }
    }
}
