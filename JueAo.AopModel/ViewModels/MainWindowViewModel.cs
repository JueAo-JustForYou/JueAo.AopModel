using Autofac;
using Autofac.Extras.DynamicProxy;
using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static JueAo.AopModel.App;

namespace JueAo.AopModel.ViewModels
{
    public class MainWindowViewModel
    {

        private ICommand m_command1;

        public ICommand Command1
        {
            get { return m_command1; }
        }

        private ICommand m_command2;
        private readonly IRegionManager m_regionManger;

        public ICommand Command2
        {
            get { return m_command2; }
        }

        public MainWindowViewModel(/*IRegionManager regionManger*/)
        {
            System.Diagnostics.Trace.WriteLine("MainWindowViewModel");

            m_command1 = new DelegateCommand(ExecuteCommand1);
            m_command2 = new DelegateCommand(ExecuteCommand2);
            m_regionManger = Prism.Ioc.ContainerLocator.Container.Resolve<IRegionManager>();

            
        }

        public virtual void ExecuteCommand2()
        {
            System.Diagnostics.Trace.WriteLine("Command2");

            m_regionManger.RequestNavigate("Ui2", "Ui2");
        }

        public void ExecuteCommand1()
        {
            System.Diagnostics.Trace.WriteLine("Command1");

            m_regionManger.RequestNavigate("Ui1", "Ui1",(x)=>
            {
                System.Diagnostics.Trace.WriteLine($"{x.Result}");
            });


        }
    }
}
