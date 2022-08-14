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
    /// Логика взаимодействия для mainpage.xaml
    /// </summary>
    public partial class mainpage : Page
    {
        public mainpage()
        {
            InitializeComponent();
            framecontent.Content = new SpisokMessageForEmpl();
            
        }

        private void loginbutton12_Click(object sender, RoutedEventArgs e)
        {
            framecontent.Content = new RezumePage();
            
        }

        private void loginbutton122_Click(object sender, RoutedEventArgs e)
        {
            framecontent.Content = new SpisokVacanciy();
            
        }

        private void loginbutton12в2_Click(object sender, RoutedEventArgs e)
        {
            framecontent.Content = new Myrezumes();
        }

        private void loginbutton1в2в2_Click(object sender, RoutedEventArgs e)
        {
            framecontent.Content = new FavoritesForUnempl();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            framecontent.Content = new SpisokMessage();
        }

        private void loginbutton_Click(object sender, RoutedEventArgs e)
        {
            framecontent.Content = new ProfilePage();
        }

        private void loginbutton1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new login());
        }
    }
}
