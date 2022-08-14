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

namespace WpfApp3
{
    public partial class WhoAreU : Page
    {
        public WhoAreU()
        {
            InitializeComponent();
        }

        private void homelessButton_Click(object sender, RoutedEventArgs e)
        {
            helper.WhoAreU = true;
            NavigationService.Navigate(new HomelessRegistration());
        }

        private void WorkGiverButton_Click(object sender, RoutedEventArgs e)
        {
            helper.WhoAreU = false;
            NavigationService.Navigate(new HomelessRegistration());
        }
    }
}
