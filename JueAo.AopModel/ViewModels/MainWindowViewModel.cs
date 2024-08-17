using Autofac;
using Autofac.Extras.DynamicProxy;
using Prism.Commands;
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

        public ICommand Command2
        {
            get { return m_command2; }
        }

        public MainWindowViewModel()
        {
            System.Diagnostics.Trace.WriteLine("MainWindowViewModel");

            m_command1 = new DelegateCommand(ExecuteCommand1);
            m_command2 = new DelegateCommand(ExecuteCommand2);
        }

        public virtual void ExecuteCommand2()
        {
            System.Diagnostics.Trace.WriteLine("Command2");
        }

        public void ExecuteCommand1()
        {
            System.Diagnostics.Trace.WriteLine("Command1");


        }
    }
}
