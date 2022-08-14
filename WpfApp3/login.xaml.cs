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
    public partial class login : Page
    {
        public login()
        {
            InitializeComponent();
            
        }

        private void TextBox_MouseEnter(object sender, MouseEventArgs e)
        {


            mailborder.BorderBrush = Brushes.BurlyWood;
        }

        private void TextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            mailborder.BorderBrush = Brushes.Gray;
        }

        private void mailborder_MouseEnter(object sender, MouseEventArgs e)
        {
            mailborder.BorderBrush = Brushes.BurlyWood;
        }

        private void mailborder_MouseLeave(object sender, MouseEventArgs e)
        {
            mailborder.BorderBrush = Brushes.Gray;
        }

        private void TextBox_MouseEnter_1(object sender, MouseEventArgs e)
        {
            passwordborder.BorderBrush = Brushes.BurlyWood;
        }

        private void TextBox_MouseLeave_1(object sender, MouseEventArgs e)
        {
            passwordborder.BorderBrush = Brushes.Gray;
        }

        private void passwordborder_MouseEnter(object sender, MouseEventArgs e)
        {
            passwordborder.BorderBrush = Brushes.BurlyWood;
        }

        private void passwordborder_MouseLeave(object sender, MouseEventArgs e)
        {
            passwordborder.BorderBrush = Brushes.Gray;
        }

        private void gridlogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            gridlogin.Focus();
        }

        private void loginbutton_Click(object sender, RoutedEventArgs e)
        {
            var p = from Unempl in App.bdhelp.unemployeds where Unempl.login == log.Text & Unempl.password == passwordboxtext.Text select Unempl;
            var p2 = from Unempl in App.bdhelp.employers where Unempl.login == log.Text & Unempl.password == passwordboxtext.Text select Unempl;
            if (p.Count() > 0)
            {
                var p3 = (from Unempl in App.bdhelp.unemployeds where Unempl.login == log.Text & Unempl.password == passwordboxtext.Text select Unempl).FirstOrDefault();
                helper.lognuj = p3.login;
                NavigationService.Navigate(new mainpage());
            }
            else if (p2.Count() > 0)
            {
                var p4 = (from Unempl in App.bdhelp.employers where Unempl.login == log.Text & Unempl.password == passwordboxtext.Text select Unempl).FirstOrDefault();
                helper.lognuj = p4.login;
                NavigationService.Navigate(new mainPageForRabotaGiver());
            }
            else
            {
                MessageBox.Show("Данные для входа неверны, попробуйте еще раз или нажмите Забыли пароль");
            }
        }
    }
}
