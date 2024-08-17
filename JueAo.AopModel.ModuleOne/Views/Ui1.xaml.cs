using Autofac;
using JueAo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JueAo.AopModel.ModuleOne.Views
{
    /// <summary>
    /// Ui1.xaml 的交互逻辑
    /// </summary>
    public partial class Ui1 : UserControl
    {
        public Ui1()
        {
            InitializeComponent();
            this.Loaded += Ui1_Loaded;
        }

        private void Ui1_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = MyContainer.Instance.Container.Resolve<ViewModels.Ui1ViewModel>();
        }
    }
}
