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
    /// Логика взаимодействия для Myrezumes.xaml
    /// </summary>
    public partial class Myrezumes : Page
    {
        public Myrezumes()
        {
            InitializeComponent();
            var p = (from unemp in App.bdhelp.unemployeds where unemp.login == helper.lognuj select unemp).FirstOrDefault();
            var l = from rez in App.bdhelp.rezumes where rez.unemployed.id == p.id select rez;
            rezumeslistbox.ItemsSource = l.ToList();
            kolvo.Text = Convert.ToString(l.Count());
            OnClickCommand = new ActionCommand(x =>
            {
                var lel = x as rezume;
                var p2 = (from educ in App.bdhelp.educations where educ.rezume_id == lel.id select educ);
                var inol = from inolang in App.bdhelp.inolanguages where inolang.rezume_id == lel.id select inolang;
                var favor = from favorit in App.bdhelp.favorites_for_employer where favorit.rezume_id == lel.id select favorit;
                if (p2.Count() > 0)
                {
                    foreach(var p3 in p2)
                    {
                        App.bdhelp.educations.Remove(p3);
                    }
                }
                if (inol.Count() > 0)
                {
                    foreach(var l2 in inol)
                    {
                        App.bdhelp.inolanguages.Remove(l2);
                    }
                }
                if (favor.Count() > 0)
                {
                    foreach(var lil in favor)
                    {
                        App.bdhelp.favorites_for_employer.Remove(lil);
                    }
                }



                App.bdhelp.rezumes.Remove(lel);
                App.bdhelp.SaveChanges();
                rezumeslistbox.ItemsSource = l.ToList();
                kolvo.Text = Convert.ToString(l.Count());
                MessageBox.Show("Резюме успешно удалено");

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
