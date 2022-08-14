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
    /// Логика взаимодействия для Myvacancies.xaml
    /// </summary>
    public partial class Myvacancies : Page
    {
        public Myvacancies()
        {
            InitializeComponent();
            var p = (from empl in App.bdhelp.employers where empl.login == helper.lognuj select empl).FirstOrDefault();
            var l = from vac in App.bdhelp.vacancies where vac.employer.id == p.id select vac;
            vacancylistbox.ItemsSource = l.ToList();
            kolvo.Text = Convert.ToString(l.Count());
            OnClickCommand = new ActionCommand(x =>
            {
                var lel = x as vacancy;
                var favor = from favorit in App.bdhelp.favorites_for_unemployed where favorit.vacancy_id == lel.id select favorit;
                if (favor.Count() > 0)
                {
                    foreach (var p3 in favor)
                    {
                        App.bdhelp.favorites_for_unemployed.Remove(p3);
                    }                   
                }
                App.bdhelp.vacancies.Remove(lel);
                App.bdhelp.SaveChanges();
                vacancylistbox.ItemsSource = l.ToList();
                kolvo.Text = Convert.ToString(l.Count());
                MessageBox.Show("Вакансия успешно удалена");
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
    }
}
