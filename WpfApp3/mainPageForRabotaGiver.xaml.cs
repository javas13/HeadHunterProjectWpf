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
    /// Логика взаимодействия для mainPageForRabotaGiver.xaml
    /// </summary>
    public partial class mainPageForRabotaGiver : Page
    {
        public mainPageForRabotaGiver()
        {
            InitializeComponent();
            framecontent.Content = new SpisokRezume();
        }

        private void loginbutton12_Click(object sender, RoutedEventArgs e)
        {
            framecontent.Content = new Vacancy();
        }

        private void loginbutton122_Click(object sender, RoutedEventArgs e)
        {
            framecontent.Content = new SpisokRezume();
        }

        private void loginbutton12в2_Click(object sender, RoutedEventArgs e)
        {
            framecontent.Content = new Myvacancies();
        }

        private void loginbutton1в2в2_Click(object sender, RoutedEventArgs e)
        {
            framecontent.Content = new FavoritesForEmpl();
        }

        private void loginbutton1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new login());
        }

        private void loginbutton_Click(object sender, RoutedEventArgs e)
        {
            framecontent.Content = new ProfilePage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            framecontent.Content = new SpisokMessageForEmpl();
        }
    }
}
