using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Vacancy.xaml
    /// </summary>
    public partial class Vacancy : Page
    {
        public Vacancy()
        {
            InitializeComponent();
            cmbcity.ItemsSource = helper.cities;
            
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            helper.vacancyZanyat = "Полная занятость";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            helper.vacancyZanyat = "Частичная занятость";
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            helper.vacancyZanyat = "Проектная работа или разовое задание";
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            helper.vacancyZanyat = "Волонтерство";
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            helper.vacancyZanyat = "Стажировка";
        }

        private void RadioButton_Checked_5(object sender, RoutedEventArgs e)
        {
            helper.vacancyGrafik = "Полный день";
        }

        private void RadioButton_Checked_6(object sender, RoutedEventArgs e)
        {
            helper.vacancyGrafik = "Сменный график";
        }

        private void RadioButton_Checked_7(object sender, RoutedEventArgs e)
        {
            helper.vacancyGrafik = "Гибкий график";
        }

        private void RadioButton_Checked_8(object sender, RoutedEventArgs e)
        {
            helper.vacancyGrafik = "Удаленная работа";
        }

        private void RadioButton_Checked_9(object sender, RoutedEventArgs e)
        {
            helper.vacancyGrafik = "Вахтовый метод";
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (vacancyName.Text.Length < 1 | OpisanieVacansi.Text.Length < 100 | zarplatatxt.Text.Length < 1 | cmbcity.SelectedItem == null | adrestxt.Text.Length < 1 | helper.vacancyGrafik == "" | helper.vacancyGrafik == "")
            {
                MessageBox.Show("Пожалуйста заполните все данные перед публикацией вакансии");
            }
            else
            {
                DateTime currentDate = DateTime.Now;
                using (WebResponse response = WebRequest.Create("http://www.microsoft.com").GetResponse())
                    currentDate = DateTime.ParseExact(response.Headers["date"], "ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.AssumeUniversal);
                var p = cmbcity.SelectedItem as City;
                var l = (from empl in App.bdhelp.employers where empl.login == helper.lognuj select empl).FirstOrDefault();
                vacancy newvacancy = new vacancy
                {

                    name = vacancyName.Text,
                    description = OpisanieVacansi.Text,
                    salary = Convert.ToInt32(zarplatatxt.Text),
                    currency = valytacmb.Text,
                    city = p.name,
                    public_time = currentDate,
                    address = adrestxt.Text,
                    schedule = helper.vacancyGrafik,
                    type_of_employment = helper.vacancyZanyat,
                    employer_id = l.id,
                    from_or_to = otcmb.Text
                    



                };
                App.bdhelp.vacancies.Add(newvacancy);
                App.bdhelp.SaveChanges();
                MessageBox.Show("Ваша вакансия успешно опубликована");
                NavigationService.Navigate(new Myvacancies());
            }
        }
    }
}
