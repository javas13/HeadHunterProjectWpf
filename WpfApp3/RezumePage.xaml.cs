using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class RezumePage : Page
    {
        public RezumePage()
        {
            
            InitializeComponent();
            this.DataContext = citview;
            cmbcity.ItemsSource = helper.cities;
            OnClickCommand = new ActionCommand(x => citview.Remove(x as Country) );
            conwinlist.ItemsSource = helper.countries;





        }
        public static ObservableCollection<Country> citview { get; set; }       
        private void Button_Click(object sender, RoutedEventArgs e)
        {                      
            if (listGrajd.Visibility == Visibility.Visible) 
            {
                if (newgrajd.Items.Count == 0)
                {
                    conwinlist.ItemsSource = helper.cities;
                    conwinlist.ItemsSource = helper.countries;
                }
                listGrajd.Visibility = Visibility.Collapsed;
            }
            else if (listGrajd.Visibility == Visibility.Collapsed)
            {
                if (newgrajd.Items.Count == 0)
                {
                conwinlist.ItemsSource = helper.cities;
                conwinlist.ItemsSource = helper.countries;
                }
                listGrajd.Visibility = Visibility.Visible;
            }                                 
        }     
        public ICommand OnClickCommand { get; set; }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            helper.Experience = "Есть опыт работы";
            dopka.Content = new Bezopita();          
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            helper.phoneNumber = phonetxt.Text;
        }
        private void cmbcity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var p = cmbcity.SelectedItem as City;
            helper.City = p.Name;
        }
        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            helper.Gender = "Мужской";
        }      
        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            helper.Gender = "Женский";
        }       

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            helper.Experience = "Нет опыта работы";
            dopka.Content = new Bezopita();
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            citview = new ObservableCollection<Country>(conwinlist.SelectedItems.Cast<Country>().ToList());
            newgrajd.ItemsSource = citview;
            listGrajd.Visibility = Visibility.Collapsed;
            
        }

        private void conwinlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (conwinlist.SelectedItems.Count > 3)
            {
                conwinlist.SelectedItems.RemoveAt(3);
            }
        }

        private void phonetxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }

    //This implementation of ICommand executes an action.
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
