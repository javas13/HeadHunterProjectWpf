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
using System.Text.RegularExpressions;

namespace WpfApp3
{
    public partial class succescodpage : Page
    {
        public succescodpage()
        {
            InitializeComponent();
        }

        private void cod_GotFocus(object sender, RoutedEventArgs e)
        {
            if(cod.Text == "Код")
            {
                cod.Text = "";
            }
        }

        private void cod_LostFocus(object sender, RoutedEventArgs e)
        {
            if(cod.Text == "")
            {
                cod.Text = "Код";
            }
        }

        private void loginbutton_Click(object sender, RoutedEventArgs e)
        {
            if(cod.Text != helper.cod.ToString())
            {
                MessageBox.Show("Код неверный попробуйте еще раз");
            }
            else if (cod.Text == helper.cod.ToString())
            {
                if (helper.WhoAreU == true)
                {
                    int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                    int dob = int.Parse(helper.Datarojd.ToString("yyyyMMdd"));
                    double age1 = (now - dob) / 10000;
                    Math.Truncate(age1);
                    unemployed newbomj = new unemployed()
                    {
                        firstname = helper.Name,
                        lastname = helper.Family,
                        date_of_birth = Convert.ToDateTime(helper.Datarojd),
                        login = helper.Login,
                        password = helper.Password,
                        email = helper.Mail,
                        age = Convert.ToInt32(age1)

                    };
                    App.bdhelp.unemployeds.Add(newbomj);
                    App.bdhelp.SaveChanges();
                }
                else if (helper.WhoAreU == false)
                {
                    employer newemp = new employer()
                    {
                        firstname = helper.Name,
                        lastname = helper.Family,
                        date_of_birth = Convert.ToDateTime(helper.Datarojd),
                        login = helper.Login,
                        password = helper.Password,
                        email = helper.Mail
                    };
                    App.bdhelp.employers.Add(newemp);
                    App.bdhelp.SaveChanges();
                }
                MessageBox.Show("Поздравляем с успешной регистрацией!");
                NavigationService.Navigate(new login());
            }
        }

        private void cod_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }
       
    }
}
