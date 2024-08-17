using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using JueAo.Infrastructure.Attributes;

namespace JueAo.AopModel.ModuleOne.ViewModels
{
    public class Ui1ViewModel
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

        public Ui1ViewModel()
        {
            System.Diagnostics.Trace.WriteLine("Ui1ViewModel");

            m_command1 = new DelegateCommand(ExecuteCommand1);
            m_command2 = new DelegateCommand(ExecuteCommand2);
        }


        [LogAttributes(Info ="Ui1ViewModel…………Command2")]
        public virtual void ExecuteCommand2()
        {
            System.Diagnostics.Trace.WriteLine("Ui1ViewModel Command2");
        }

        public void ExecuteCommand1()
        {
            System.Diagnostics.Trace.WriteLine("Ui1ViewModel Command1");


        }
    }
}
