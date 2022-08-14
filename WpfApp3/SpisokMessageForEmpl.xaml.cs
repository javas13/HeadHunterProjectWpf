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
    /// Логика взаимодействия для SpisokMessageForEmpl.xaml
    /// </summary>
    public partial class SpisokMessageForEmpl : Page
    {
        public SpisokMessageForEmpl()
        {
            InitializeComponent();
            var p = from chan in App.bdhelp.channels where chan.employer.login == helper.lognuj & chan.is_created == 1 select chan;
            meslist.ItemsSource = p.ToList();
        }

        private void meslist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var l = meslist.SelectedItem as channel;
            helper.unemploylId1 = Convert.ToInt32(l.unemployed.id);
            NavigationService.Navigate(new MessageForEmpl(l.id));
        }
    }
}
