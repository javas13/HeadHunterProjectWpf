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
    /// <summary>
    /// Логика взаимодействия для ObrazovUrovPage.xaml
    /// </summary>
    public partial class ObrazovUrovPage : Page
    {
        public ObrazovUrovPage()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            secondobr.Visibility = Visibility.Visible;
            hyper.Visibility = Visibility.Collapsed;
            helper.CountObrazov = 2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            secondobr.Visibility = Visibility.Collapsed;
            hyper.Visibility = Visibility.Visible;
            helper.CountObrazov = 1;
        }

        private void uchebkatxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            helper.Zavedenie = uchebkatxt.Text;
        }

        private void fakultettxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            helper.Facultet = fakultettxt.Text;
        }

        private void specializationtxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            helper.Specialization = specializationtxt.Text;
        }

        private void godtxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            helper.GodOkonchaniya = godtxt.Text;
        }

        private void uchebka1_TextChanged(object sender, TextChangedEventArgs e)
        {
            helper.Zavedenie1 = uchebka1.Text;
        }

        private void fakultet1_TextChanged(object sender, TextChangedEventArgs e)
        {
            helper.Facultet1 = fakultet1.Text;
        }

        private void spicialization1_TextChanged(object sender, TextChangedEventArgs e)
        {
            helper.Specialization1 = spicialization1.Text;
        }

        private void god1_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            helper.GodOkonchaniya1 = god1.Text;
        }
    }
}
