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
    /// Логика взаимодействия для FavoritesForEmpl.xaml
    /// </summary>
    public partial class FavoritesForEmpl : Page
    {
        public FavoritesForEmpl()
        {
            InitializeComponent();
            var p = (from empl in App.bdhelp.employers where empl.login == helper.lognuj select empl).FirstOrDefault();
            var l = from fav in App.bdhelp.favorites_for_employer where fav.employer.id == p.id select fav;
            rezumeslistbox.ItemsSource = l.ToList();
            kolvo.Text = Convert.ToString(l.Count());
            OnClickCommand = new ActionCommand(x =>
            {
                var lel = x as favorites_for_employer;
                var favor = (from favorit in App.bdhelp.favorites_for_employer where favorit.rezume_id == lel.rezume_id & favorit.employer_id == p.id select favorit).FirstOrDefault();                                  
                App.bdhelp.favorites_for_employer.Remove(favor);                                               
                App.bdhelp.SaveChanges();
                rezumeslistbox.ItemsSource = l.ToList();
                kolvo.Text = Convert.ToString(l.Count());
                MessageBox.Show("Резюме удалено из избранного");
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

        private void rezumeslistbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var p = rezumeslistbox.SelectedItem as favorites_for_employer;

            if (p != null)
            {
                NavigationService.Navigate(new RezumePodrobno(p.rezume.phone_number, p.rezume.city, p.rezume.gender, p.rezume.citizenship, p.rezume.experience_job, p.rezume.WhyNot, p.rezume.career_objective, Convert.ToInt32(p.rezume.salary), p.rezume.currency, p.rezume.education_lvl, p.rezume.native_language, p.rezume.about_myself, p.rezume.moving, p.rezume.busyness, p.rezume.schedule, p.rezume.is_have_car, p.rezume.category_of_rights, rezumeslistbox, p.rezume.id, p.rezume.unemployed));
            }
        }
    }
}
