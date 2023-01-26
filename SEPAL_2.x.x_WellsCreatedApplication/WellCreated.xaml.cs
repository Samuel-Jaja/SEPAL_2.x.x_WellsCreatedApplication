using SEPAL_2.x.x_WellsCreatedApplication.ViewModel;
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
using System.Windows.Shapes;

namespace SEPAL_2.x.x_WellsCreatedApplication
{
    /// <summary>
    /// Interaction logic for WellCreated.xaml
    /// </summary>
    public partial class WellCreated : Window
    {
        public WellCreated()
        {
            InitializeComponent();
            DataContext = new WellCreatedViewModel();
        }
    }
}
