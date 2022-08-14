using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Noviylist.xaml
    /// </summary>
    public partial class Noviylist : Page
    {
        public Noviylist()
        {
            InitializeComponent();
            conwinlist.ItemsSource = helper.countries;
        }
        private void conwinlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (conwinlist.SelectedItems.Count > 3)
            {
                conwinlist.SelectedItems.RemoveAt(3);
            }
        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //helper.citview = new ObservableCollection<Country>(conwinlist.SelectedItems.Cast<Country>().ToList());
            helper.City = "";
            helper.phoneNumber = "";
            RezumePage.citview = new ObservableCollection<Country>(conwinlist.SelectedItems.Cast<Country>().ToList());
            NavigationService.Navigate(new RezumePage());




        }





        private void conwinlist_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (conwinlist.SelectedItems.Count > 3)
            {
                conwinlist.SelectedItems.RemoveAt(3);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
