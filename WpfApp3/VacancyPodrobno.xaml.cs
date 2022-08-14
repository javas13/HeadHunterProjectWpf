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
    /// Логика взаимодействия для VacancyPodrobno.xaml
    /// </summary>
    public partial class VacancyPodrobno : Page
    {
        public VacancyPodrobno(string namevac, string descrip, string salary, string city, string address, string zanyat, string grafik, string valyta, string otIliDo, string mail, ListBox listb, employer empl4)
        {
            InitializeComponent();
            polnujen.Text = namevac;
            fromOrtotxt.Text = otIliDo;
            grajdnujen.Text = " " + salary;
            polnujen2.Text = descrip;
            phonenujen.Text = mail;
            citynujen.Text = city;
            citynujen2.Text = address;
            zanyatostnujna.Text = zanyat;
            grafiknujen.Text = grafik;
            p = listb;
            helper.unemploylId1 = empl4.id;
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

       

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var empl = (from unempl in App.bdhelp.unemployeds where unempl.login == helper.lognuj select unempl).FirstOrDefault();
            var p2 = (from favor in App.bdhelp.favorites_for_unemployed where favor.vacancy_id == helper.rezumId & favor.unemployed.login == helper.lognuj select favor);
            if (p2.Count() > 0)
            {
                MessageBox.Show("Это резюме уже находится в избранном");
            }
            else
            {
                favorites_for_unemployed lel = new favorites_for_unemployed()
                {
                    vacancy_id = helper.rezumId,
                    unemployed_id = empl.id
                };
                App.bdhelp.favorites_for_unemployed.Add(lel);
                App.bdhelp.SaveChanges();
                MessageBox.Show("Вакансия успешно добавлена в избранное");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var unempl = (from unemploy in App.bdhelp.unemployeds where unemploy.login == helper.lognuj select unemploy).FirstOrDefault();
            var p = from chan in App.bdhelp.channels where chan.unemployer_id == unempl.id & chan.employer_id == helper.unemploylId1 select chan;
            if (p.Count() > 0)
            {
                NavigationService.Navigate(new MessagePageForVacancy());
            }
            else
            {
                channel lol = new channel()
                {
                    employer_id = helper.unemploylId1,
                    unemployer_id = unempl.id
                };
                App.bdhelp.channels.Add(lol);
                App.bdhelp.SaveChanges();
                NavigationService.Navigate(new MessagePageForVacancy());

            }
        }
    }
}
