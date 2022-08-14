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
    /// Логика взаимодействия для FavoritesForUnempl.xaml
    /// </summary>
    public partial class FavoritesForUnempl : Page
    {
        public FavoritesForUnempl()
        {
            InitializeComponent();
            var p = (from unempl in App.bdhelp.unemployeds where unempl.login == helper.lognuj select unempl).FirstOrDefault();
            var l = from fav in App.bdhelp.favorites_for_unemployed where fav.unemployed_id == p.id select fav;
            vacancylistbox.ItemsSource = l.ToList();
            kolvo.Text = Convert.ToString(l.Count());
            OnClickCommand = new ActionCommand(x =>
            {
                var lel = x as favorites_for_unemployed;
                var p2 = (from favor in App.bdhelp.favorites_for_unemployed where favor.vacancy_id == lel.vacancy_id & favor.unemployed_id == p.id select favor).FirstOrDefault();                                                            
                App.bdhelp.favorites_for_unemployed.Remove(p2);
                App.bdhelp.SaveChanges();
                vacancylistbox.ItemsSource = l.ToList();
                kolvo.Text = Convert.ToString(l.Count());
                MessageBox.Show("Вакансия удалена из избранного");               
            });
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

        private void vacancylistbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var p = vacancylistbox.SelectedItem as favorites_for_unemployed;

            if (p != null)
            {
                var p1 = (from empl in App.bdhelp.employers where empl.login == p.vacancy.employer.login select empl).FirstOrDefault();
                helper.rezumId = p.id;
                NavigationService.Navigate(new VacancyPodrobno(p.vacancy.name, p.vacancy.description, Convert.ToString(p.vacancy.salary), p.vacancy.city, p.vacancy.address, p.vacancy.type_of_employment, p.vacancy.schedule, p.vacancy.currency, p.vacancy.from_or_to, p1.email, vacancylistbox, p1));
            }
        }
    }
}
