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
    /// Логика взаимодействия для RezumePodrobno.xaml
    /// </summary>
    public partial class RezumePodrobno : Page
    {
        public RezumePodrobno(string phone, string city, string pol, string grajdans, string estliOpit, string opit, string specialn, int zarplata, string valyta, string educlvl, string rodnoy, string osebe, string pereezd, string zanyatost, string grafik, string avto, string prava, ListBox l, int nujenId, unemployed unem)
        {
            InitializeComponent();
            phonenujen.Text = phone;
            citynujen.Text = city;
            polnujen.Text = pol;
            grajdnujen.Text = grajdans;
            opitnujen.Text = estliOpit;
            opitpodrobnonujen.Text = opit;
            specialnostnujen.Text = specialn;
            zarplatanujna.Text = Convert.ToString(zarplata);
            valytanujna.Text = valyta;
            lvlobraznujen.Text = educlvl;
            rodnoynujen.Text = rodnoy;
            osebenujen.Text = osebe;
            pereezdnujen.Text = pereezd;
            zanyatostnujna.Text = zanyatost;
            grafiknujen.Text = grafik;
            avtonujen.Text = avto;
            pravanujni.Text = prava;
            p = l;
            var educsp = from educati in App.bdhelp.educations where educati.rezume_id == nujenId select educati;
            obrlist.ItemsSource = educsp.ToList();
            var inolang = from lang in App.bdhelp.inolanguages where lang.rezume_id == nujenId select lang;
            langspisok.ItemsSource = inolang.ToList();
            helper.rezumId = nujenId;
            helper.unemploylId1 = unem.id;
            

           
        }
        ListBox p = new ListBox();
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            p.UnselectAll();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var empl = (from employ in App.bdhelp.employers where employ.login == helper.lognuj select employ).FirstOrDefault();
            var p2 = (from favor in App.bdhelp.favorites_for_employer where favor.rezume_id == helper.rezumId & favor.employer.login == helper.lognuj select favor);
            if (p2.Count() > 0)
            {
                MessageBox.Show("Это резюме уже находится в избранном");
            }
            else
            {
                favorites_for_employer lel = new favorites_for_employer()
                {
                    rezume_id = helper.rezumId,
                    employer_id = empl.id
                };
                App.bdhelp.favorites_for_employer.Add(lel);
                App.bdhelp.SaveChanges();
                MessageBox.Show("Резюме успешно добавлено в избранное");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            var empl = (from employ in App.bdhelp.employers where employ.login == helper.lognuj select employ).FirstOrDefault();           
            var p = from chan in App.bdhelp.channels where chan.employer_id == empl.id & chan.unemployer_id == helper.unemploylId1 select chan;
            if (p.Count() > 0)
            {
                NavigationService.Navigate(new MessagePage());
            }
            else
            {
                channel lol = new channel()
                {
                    employer_id = empl.id,
                    unemployer_id = helper.unemploylId1
                };
                App.bdhelp.channels.Add(lol);
                App.bdhelp.SaveChanges();
                NavigationService.Navigate(new MessagePage());
               
            }
            
        }
    }
}
