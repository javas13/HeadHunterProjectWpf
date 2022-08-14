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
    /// Логика взаимодействия для SpisokRezume.xaml
    /// </summary>
    public partial class SpisokRezume : Page
    {

        public SpisokRezume()
        {
            InitializeComponent();

            rezumeslistbox.ItemsSource = App.bdhelp.rezumes.ToList();
            kolvo.Text = Convert.ToString(App.bdhelp.rezumes.Count());
            var p = (from empl in App.bdhelp.employers where empl.login == helper.lognuj select empl).FirstOrDefault();
            favorites_for_employer lol1 = new favorites_for_employer();


            OnClickCommand = new ActionCommand(x =>
            {
                var lel = x as rezume;
                var p2 = (from favor in App.bdhelp.favorites_for_employer where favor.rezume_id == lel.id & favor.employer_id == p.id  select favor);
                if (p2.Count() > 0)
                {
                    MessageBox.Show("Это резюме уже находится в избранном");
                }
                else
                {
                    lol1.employer_id = p.id;
                    lol1.rezume = x as rezume;
                    App.bdhelp.favorites_for_employer.Add(lol1);
                    App.bdhelp.SaveChanges();
                    MessageBox.Show("Резюме успешно добавлено в избранное");
                }


            });



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var l = popit.SelectedItem as TextBlock;
            var k = carcmb.SelectedItem as TextBlock;
            var o = lvleduc.SelectedItem as TextBlock;
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
                    if (o.Text == "Не имеет значения")
                    {
                        
                        var p = from Rezum in App.bdhelp.rezumes where Rezum.career_objective.Contains(poisk.Text) && Rezum.city.Contains(cit.Text) && Rezum.salary > zarp1 && Rezum.salary < zarp2 && Rezum.currency.Contains(m.Text) select Rezum;
                        rezumeslistbox.ItemsSource = p.ToList();
                        kolvo.Text = Convert.ToString(p.Count());
                    }
                    else
                    {
                        var p = from Rezum in App.bdhelp.rezumes where Rezum.career_objective.Contains(poisk.Text) && Rezum.city.Contains(cit.Text) && Rezum.education_lvl.Contains(o.Text) && Rezum.salary > zarp1 && Rezum.salary < zarp2 && Rezum.currency.Contains(m.Text) select Rezum;
                        rezumeslistbox.ItemsSource = p.ToList();
                        kolvo.Text = Convert.ToString(p.Count());
                    }
                    
                }
                else
                {
                    if(o.Text == "Не имеет значения")
                    {
                        var p = from Rezum in App.bdhelp.rezumes where Rezum.career_objective.Contains(poisk.Text) && Rezum.city.Contains(cit.Text) && Rezum.is_have_car.Contains(k.Text) && Rezum.salary > zarp1 && Rezum.salary < zarp2 && Rezum.currency.Contains(m.Text) select Rezum;
                        rezumeslistbox.ItemsSource = p.ToList();
                        kolvo.Text = Convert.ToString(p.Count());
                    }
                    else
                    {
                        var p = from Rezum in App.bdhelp.rezumes where Rezum.career_objective.Contains(poisk.Text) && Rezum.city.Contains(cit.Text) && Rezum.is_have_car.Contains(k.Text) && Rezum.education_lvl.Contains(o.Text) && Rezum.salary > zarp1 && Rezum.salary < zarp2 && Rezum.currency.Contains(m.Text) select Rezum;
                        rezumeslistbox.ItemsSource = p.ToList();
                        kolvo.Text = Convert.ToString(p.Count());
                    }
                }
            }
            else
            {
                if (k.Text == "Не имеет значения")
                {
                    if (o.Text == "Не имеет значения")
                    {
                        
                        var p = from Rezum in App.bdhelp.rezumes where Rezum.career_objective.Contains(poisk.Text) && Rezum.city.Contains(cit.Text) && Rezum.experience_job.Contains(l.Text) && Rezum.salary > zarp1 && Rezum.salary < zarp2 && Rezum.currency.Contains(m.Text) select Rezum;
                        rezumeslistbox.ItemsSource = p.ToList();
                        kolvo.Text = Convert.ToString(p.Count());
                    }
                    else
                    {
                        var p = from Rezum in App.bdhelp.rezumes where Rezum.career_objective.Contains(poisk.Text) && Rezum.city.Contains(cit.Text) && Rezum.experience_job.Contains(l.Text) && Rezum.education_lvl.Contains(o.Text) && Rezum.salary > zarp1 && Rezum.salary < zarp2 && Rezum.currency.Contains(m.Text) select Rezum;
                        rezumeslistbox.ItemsSource = p.ToList();
                        kolvo.Text = Convert.ToString(p.Count());
                    }
                    
                }
                else
                {
                    if (o.Text == "Не имеет значения")
                    {
                        var p = from Rezum in App.bdhelp.rezumes where Rezum.career_objective.Contains(poisk.Text) && Rezum.city.Contains(cit.Text) && Rezum.experience_job.Contains(l.Text) && Rezum.is_have_car.Contains(k.Text) && Rezum.salary > zarp1 && Rezum.salary < zarp2 && Rezum.currency.Contains(m.Text) select Rezum;
                        rezumeslistbox.ItemsSource = p.ToList();
                        kolvo.Text = Convert.ToString(p.Count());
                    }
                    else
                    {
                        var p = from Rezum in App.bdhelp.rezumes where Rezum.career_objective.Contains(poisk.Text) && Rezum.city.Contains(cit.Text) && Rezum.experience_job.Contains(l.Text) && Rezum.is_have_car.Contains(k.Text) && Rezum.education_lvl.Contains(o.Text) && Rezum.salary > zarp1 && Rezum.salary < zarp2 && Rezum.currency.Contains(m.Text) select Rezum;
                        rezumeslistbox.ItemsSource = p.ToList();
                        kolvo.Text = Convert.ToString(p.Count());
                    }
                    
                }
            }

        }

        private void TextBlock_TextInput(object sender, TextCompositionEventArgs e)
        {
           
        }

        private void poisk_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                var l = popit.SelectedItem as TextBlock;
                var k = carcmb.SelectedItem as TextBlock;
                if (l.Text == "Не имеет значения")
                {
                    if (k.Text == "Не имеет значения")
                    {
                        var p = from Rezum in App.bdhelp.rezumes where Rezum.career_objective.Contains(poisk.Text) && Rezum.city.Contains(cit.Text) select Rezum;
                        rezumeslistbox.ItemsSource = p.ToList();
                        kolvo.Text = Convert.ToString(p.Count());
                    }
                    else
                    {
                        var p = from Rezum in App.bdhelp.rezumes where Rezum.career_objective.Contains(poisk.Text) && Rezum.city.Contains(cit.Text) && Rezum.is_have_car.Contains(k.Text) select Rezum;
                        rezumeslistbox.ItemsSource = p.ToList();
                        kolvo.Text = Convert.ToString(p.Count());
                    }
                }
                else
                {
                    if (k.Text == "Не имеет значения")
                    {
                        var p = from Rezum in App.bdhelp.rezumes where Rezum.career_objective.Contains(poisk.Text) && Rezum.city.Contains(cit.Text) && Rezum.experience_job.Contains(l.Text) select Rezum;
                        rezumeslistbox.ItemsSource = p.ToList();
                        kolvo.Text = Convert.ToString(p.Count());
                    }
                    else
                    {
                        var p = from Rezum in App.bdhelp.rezumes where Rezum.career_objective.Contains(poisk.Text) && Rezum.city.Contains(cit.Text) && Rezum.experience_job.Contains(l.Text) && Rezum.is_have_car.Contains(k.Text) select Rezum;
                        rezumeslistbox.ItemsSource = p.ToList();
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
            NavigationService.Navigate(new SpisokRezume());
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
            
            var p = rezumeslistbox.SelectedItem as rezume;
            
            if (p != null)
            {
                NavigationService.Navigate(new RezumePodrobno(p.phone_number, p.city, p.gender, p.citizenship, p.experience_job, p.WhyNot, p.career_objective, Convert.ToInt32(p.salary), p.currency, p.education_lvl, p.native_language, p.about_myself, p.moving, p.busyness, p.schedule, p.is_have_car, p.category_of_rights, rezumeslistbox, p.id, p.unemployed));
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
