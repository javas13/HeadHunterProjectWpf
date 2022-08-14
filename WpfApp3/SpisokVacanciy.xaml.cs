using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для SpisokVacanciy.xaml
    /// </summary>
    public partial class SpisokVacanciy : Page
    {
        public SpisokVacanciy()
        {
            InitializeComponent();
            vacancylistbox.ItemsSource = App.bdhelp.vacancies.ToList();
            kolvo.Text = Convert.ToString(App.bdhelp.vacancies.Count());
            var p = (from unempl in App.bdhelp.unemployeds where unempl.login == helper.lognuj select unempl).FirstOrDefault();
            favorites_for_unemployed lol1 = new favorites_for_unemployed();


            OnClickCommand = new ActionCommand(x =>
            {
                var lel = x as vacancy;
                var p2 = (from favor in App.bdhelp.favorites_for_unemployed where favor.vacancy_id == lel.id & favor.unemployed_id == p.id select favor);
                if (p2.Count() > 0)
                {
                    MessageBox.Show("Эта вакансия уже находится в избранном");
                }
                else
                {
                    lol1.unemployed_id = p.id;
                    lol1.vacancy = x as vacancy;
                    App.bdhelp.favorites_for_unemployed.Add(lol1);
                    App.bdhelp.SaveChanges();
                    MessageBox.Show("Вакансия успешно добавлена в избранное");
                }


            });



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var l = popit.SelectedItem as TextBlock;
            var k = carcmb.SelectedItem as TextBlock;
            var m = valyta.SelectedItem as TextBlock;
            int zarp1 = 0;
            int zarp2 = 1000000;
            try
            {
                zarp1 = Convert.ToInt32(zp1.Text);
                zarp2 = Convert.ToInt32(zp2.Text);
            }
            catch
            {
                MessageBox.Show("Заполните графу зарплаты");
            }





            if (l.Text == "Не имеет значения")
            {
                if (k.Text == "Не имеет значения")
                {
                    
                   
                        var p = from Vacancy in App.bdhelp.vacancies where Vacancy.name.Contains(poisk.Text) && Vacancy.city.Contains(cit.Text) && Vacancy.salary > zarp1 && Vacancy.salary < zarp2 && Vacancy.currency.Contains(m.Text) select Vacancy;
                        vacancylistbox.ItemsSource = p.ToList();
                        kolvo.Text = Convert.ToString(p.Count());
                    

                }
                else
                {
                   
                  
                        var p = from Vacancy in App.bdhelp.vacancies where Vacancy.name.Contains(poisk.Text) && Vacancy.city.Contains(cit.Text) && Vacancy.type_of_employment.Contains(k.Text) && Vacancy.salary > zarp1 && Vacancy.salary < zarp2 && Vacancy.currency.Contains(m.Text) select Vacancy;
                        vacancylistbox.ItemsSource = p.ToList();
                        kolvo.Text = Convert.ToString(p.Count());
                    
                }
            }
            else
            {
                if (k.Text == "Не имеет значения")
                {
                   
                    
                        var p = from Vacancy in App.bdhelp.vacancies where Vacancy.name.Contains(poisk.Text) && Vacancy.city.Contains(cit.Text) && Vacancy.type_of_employment.Contains(l.Text) && Vacancy.salary > zarp1 && Vacancy.salary < zarp2 && Vacancy.currency.Contains(m.Text) select Vacancy;
                        vacancylistbox.ItemsSource = p.ToList();
                        kolvo.Text = Convert.ToString(p.Count());
                    

                }
                else
                {
                    
                    
                        var p = from Vacancy in App.bdhelp.vacancies where Vacancy.name.Contains(poisk.Text) && Vacancy.city.Contains(cit.Text) && Vacancy.schedule.Contains(l.Text) && Vacancy.type_of_employment.Contains(k.Text)  && Vacancy.salary > zarp1 && Vacancy.salary < zarp2 && Vacancy.currency.Contains(m.Text) select Vacancy;
                        vacancylistbox.ItemsSource = p.ToList();
                        kolvo.Text = Convert.ToString(p.Count());
                    

                }
            }

        }

        private void TextBlock_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void poisk_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                var l = popit.SelectedItem as TextBlock;
                var k = carcmb.SelectedItem as TextBlock;
                var m = valyta.SelectedItem as TextBlock;
                int zarp1 = 0;
                int zarp2 = 1000000;
                try
                {
                    zarp1 = Convert.ToInt32(zp1.Text);
                    zarp2 = Convert.ToInt32(zp2.Text);
                }
                catch
                {
                    MessageBox.Show("Заполните графу зарплаты");
                }





                if (l.Text == "Не имеет значения")
                {
                    if (k.Text == "Не имеет значения")
                    {


                        var p = from Vacancy in App.bdhelp.vacancies where Vacancy.name.Contains(poisk.Text) && Vacancy.city.Contains(cit.Text) && Vacancy.salary > zarp1 && Vacancy.salary < zarp2 && Vacancy.currency.Contains(m.Text) select Vacancy;
                        vacancylistbox.ItemsSource = p.ToList();
                        kolvo.Text = Convert.ToString(p.Count());


                    }
                    else
                    {


                        var p = from Vacancy in App.bdhelp.vacancies where Vacancy.name.Contains(poisk.Text) && Vacancy.city.Contains(cit.Text) && Vacancy.type_of_employment.Contains(k.Text) && Vacancy.salary > zarp1 && Vacancy.salary < zarp2 && Vacancy.currency.Contains(m.Text) select Vacancy;
                        vacancylistbox.ItemsSource = p.ToList();
                        kolvo.Text = Convert.ToString(p.Count());

                    }
                }
                else
                {
                    if (k.Text == "Не имеет значения")
                    {


                        var p = from Vacancy in App.bdhelp.vacancies where Vacancy.name.Contains(poisk.Text) && Vacancy.city.Contains(cit.Text) && Vacancy.type_of_employment.Contains(l.Text) && Vacancy.salary > zarp1 && Vacancy.salary < zarp2 && Vacancy.currency.Contains(m.Text) select Vacancy;
                        vacancylistbox.ItemsSource = p.ToList();
                        kolvo.Text = Convert.ToString(p.Count());


                    }
                    else
                    {


                        var p = from Vacancy in App.bdhelp.vacancies where Vacancy.name.Contains(poisk.Text) && Vacancy.city.Contains(cit.Text) && Vacancy.schedule.Contains(l.Text) && Vacancy.type_of_employment.Contains(k.Text) && Vacancy.salary > zarp1 && Vacancy.salary < zarp2 && Vacancy.currency.Contains(m.Text) select Vacancy;
                        vacancylistbox.ItemsSource = p.ToList();
                        kolvo.Text = Convert.ToString(p.Count());


                    }
                }
            }
        }

        private void popit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var p = popit.SelectedItem as TextBlock;
            if (p.Text == "Не имеет значения")
            {
                helper.kakoypoisk = 0;
            }
            else if (p.Text == "Нет опыта работы")
            {
                helper.kakoypoisk = 1;
            }
            else if (p.Text == "Есть опыт работы")
            {
                helper.kakoypoisk = 2;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SpisokVacanciy());
        }
        public ICommand OnClickCommand { get; set; }
        public class ActionCommand : ICommand
        {
            private readonly Action<object> Action;
            private readonly Predicate<object> Predicate;

            public ActionCommand(Action<object> action) : this(action, x => true)
            {

            }
            public ActionCommand(Action<object> action, Predicate<object> predicate)
            {
                Action = action;
                Predicate = predicate;
            }

            public bool CanExecute(object parameter)
            {
                return Predicate(parameter);
            }
            public void Execute(object parameter)
            {
                Action(parameter);
            }

            //These lines are here to tie into WPF-s Can execute changed pipeline. Don't worry about it.
            public event EventHandler CanExecuteChanged
            {
                add
                {
                    CommandManager.RequerySuggested += value;
                }
                remove
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {




        }

        private void rezumeslistbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            

        }

        private void vacancylistbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var p = vacancylistbox.SelectedItem as vacancy;
            
            if (p != null)
            {
                var p1 = (from empl in App.bdhelp.employers where empl.login == p.employer.login select empl).FirstOrDefault();
                helper.rezumId = p.id;
                NavigationService.Navigate(new VacancyPodrobno(p.name, p.description, Convert.ToString(p.salary), p.city, p.address, p.type_of_employment, p.schedule, p.currency, p.from_or_to, p1.email, vacancylistbox, p1));
            }
        }

        private void zp1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void zp2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
    }

