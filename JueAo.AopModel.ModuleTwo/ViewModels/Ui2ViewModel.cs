using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JueAo.AopModel.ModuleTwo.ViewModels
{
    public class Ui2ViewModel
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

        public Ui2ViewModel()
        {
            System.Diagnostics.Trace.WriteLine("Ui2ViewModel");

            m_command1 = new DelegateCommand(ExecuteCommand1);
            m_command2 = new DelegateCommand(ExecuteCommand2);
        }

        public virtual void ExecuteCommand2()
        {
            System.Diagnostics.Trace.WriteLine("Ui2ViewModel Command2");
        }

        public void ExecuteCommand1()
        {
            System.Diagnostics.Trace.WriteLine("Ui2ViewModel Command1");


        }
    }
}
