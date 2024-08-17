using JueAo.Infrastructure.Attributes;
using Prism.Commands;
using Prism.Regions;
using System.Windows.Input;

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

        public MainWindowViewModel(IRegionManager regionManger)
        {
            System.Diagnostics.Trace.WriteLine("MainWindowViewModel");

            m_command1 = new DelegateCommand(ExecuteCommand1);
            m_command2 = new DelegateCommand(ExecuteCommand2);
            m_regionManger = regionManger;

            
        }

        [PostLog(Message = "MainWindowViewModel_ExecuteCommand2")]
        public virtual void ExecuteCommand2()
        {
            System.Diagnostics.Trace.WriteLine("Command2");

            m_regionManger.RequestNavigate("Ui2", "Ui2");
        }

        [PostLog(Message = "MainWindowViewModel_ExecuteCommand1")]
        public void ExecuteCommand1()
        {
            System.Diagnostics.Trace.WriteLine("Command1");

            m_regionManger.RequestNavigate("Ui1", "Ui1");


        }
    }
}
