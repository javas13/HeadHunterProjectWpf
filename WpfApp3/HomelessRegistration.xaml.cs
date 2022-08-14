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
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace WpfApp3
{
    public partial class HomelessRegistration : Page
    {
        public HomelessRegistration()
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

        private void passwordborder_MouseEnter(object sender, MouseEventArgs e)
        {
            passwordborder.BorderBrush = Brushes.BurlyWood;
        }

        private void passwordborder_MouseLeave(object sender, MouseEventArgs e)
        {
            passwordborder.BorderBrush = Brushes.Gray;
        }

        private void TextBox_MouseEnter_1(object sender, MouseEventArgs e)
        {
            mailborder.BorderBrush = Brushes.BurlyWood;
        }

        private void TextBox_MouseLeave_1(object sender, MouseEventArgs e)
        {
            mailborder.BorderBrush = Brushes.BurlyWood;
        }

        private void nameborder_MouseEnter(object sender, MouseEventArgs e)
        {
            nameborder.BorderBrush = Brushes.BurlyWood;
        }

        private void nameborder_MouseLeave(object sender, MouseEventArgs e)
        {
            nameborder.BorderBrush = Brushes.Gray;
        }

        private void nametextbox_MouseEnter(object sender, MouseEventArgs e)
        {
            nameborder.BorderBrush = Brushes.BurlyWood;
        }

        private void nametextbox_MouseLeave(object sender, MouseEventArgs e)
        {
            nameborder.BorderBrush = Brushes.Gray;
        }

        private void familyborder_MouseEnter(object sender, MouseEventArgs e)
        {
            familyborder.BorderBrush = Brushes.BurlyWood;
        }

        private void familyborder_MouseLeave(object sender, MouseEventArgs e)
        {
            familyborder.BorderBrush = Brushes.Gray;
        }

        private void familytextbox_MouseEnter(object sender, MouseEventArgs e)
        {
            familyborder.BorderBrush = Brushes.BurlyWood;
        }

        private void familytextbox_MouseLeave(object sender, MouseEventArgs e)
        {
            familyborder.BorderBrush = Brushes.Gray;
        }

       

        private void loginborder_MouseEnter(object sender, MouseEventArgs e)
        {
            loginborder.BorderBrush = Brushes.BurlyWood;
        }

        private void loginborder_MouseLeave(object sender, MouseEventArgs e)
        {
            loginborder.BorderBrush = Brushes.Gray;
        }

        private void logintextbox_MouseEnter(object sender, MouseEventArgs e)
        {
            loginborder.BorderBrush = Brushes.BurlyWood;
        }

        private void logintextbox_MouseLeave(object sender, MouseEventArgs e)
        {
            loginborder.BorderBrush = Brushes.Gray;
        }

        private void passwordtextbox_MouseEnter(object sender, MouseEventArgs e)
        {
            passwordborder.BorderBrush = Brushes.BurlyWood;
        }

        private void passwordtextbox_MouseLeave(object sender, MouseEventArgs e)
        {
            passwordborder.BorderBrush = Brushes.Gray;
        }

        private void mailborder_MouseEnter_1(object sender, MouseEventArgs e)
        {
            mailborder.BorderBrush = Brushes.BurlyWood;
        }

        private void mailborder_MouseLeave_1(object sender, MouseEventArgs e)
        {
            mailborder.BorderBrush = Brushes.Gray;
        }

        private void mailtextbox_MouseEnter(object sender, MouseEventArgs e)
        {
            mailborder.BorderBrush = Brushes.BurlyWood;
        }

        private void mailtextbox_MouseLeave(object sender, MouseEventArgs e)
        {
            mailborder.BorderBrush = Brushes.Gray;
        }

        private async void loginbutton_Click(object sender, RoutedEventArgs e)
        {
            string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            if (nametextbox.Text == "" | familytextbox.Text == "" | datarojd.Text == "" | logintextbox.Text == "" | passwordtextbox.Text == "" | mailtextbox.Text == "")
            {
                MessageBox.Show("Пожалуйста введите все данные");
            }
            else
            {
                var p = from Client in App.bdhelp.unemployeds  where Client.login == logintextbox.Text select Client;
                var pp = from Client in App.bdhelp.employers where Client.login == logintextbox.Text select Client;
                var p1 = from Clin in App.bdhelp.unemployeds where Clin.email == mailtextbox.Text select Clin;
                var p2 = from Clin in App.bdhelp.employers where Clin.email == mailtextbox.Text select Clin;

                if (p.Count() > 0 | pp.Count() > 0)
                {
                    MessageBox.Show("Упсс, Похоже пользователь с таким логином уже зарегистрирован( Попробуйте придумать другой");
                }

                else if (p1.Count() > 0 | p2.Count() > 0)
                {
                    MessageBox.Show("Упсс, Похоже пользователь с таким майлом уже зарегистрирован( Укажите другой адрес электронной почты");
                }
                else
                {
                    if (Regex.IsMatch(mailtextbox.Text, pattern, RegexOptions.IgnoreCase))
                    {

                        MailAddress fromAddress = new MailAddress("kadrovoeagenstvo12@gmail.com", "KadrovoeAgenstvo");
                        MailAddress toAddress = new MailAddress(mailtextbox.Text);
                        MailMessage newmes = new MailMessage(fromAddress, toAddress);
                        Random generator = new Random();
                        var cod = generator.Next(10000, 99999);
                        newmes.Body = ($"Здравствуйте, ваш код подтверждения {cod}, Никому не показывате этот код!");
                        newmes.Subject = "Подтвержение почты";
                        SmtpClient smtpClient = new SmtpClient();
                        smtpClient.Host = "smtp.gmail.com";
                        smtpClient.Port = 587;
                        smtpClient.EnableSsl = true;
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential(fromAddress.Address, "lada3022A");
                        await Task.Factory.StartNew(() => smtpClient.Send(newmes));
                        helper.cod = cod;
                        helper.Login = logintextbox.Text;
                        helper.Password = passwordtextbox.Text;
                        helper.Mail = mailtextbox.Text;
                        helper.Name = nametextbox.Text;
                        helper.Family = familytextbox.Text;
                        helper.Datarojd = Convert.ToDateTime(datarojd.Text);
                        MessageBox.Show("Отлично! Для завершения регистрации потребуется ввести код который пришел вам на электронную почту");
                        NavigationService.Navigate(new succescodpage());


                    }
                    else
                    {
                        MessageBox.Show("Неверный формат электронной почты! Попробуйте еще раз");
                    }
                   
                }
            }                                   
}
 
        private void ageboddrder_MouseEnter(object sender, MouseEventArgs e)
        {
            ageboddrder.BorderBrush = Brushes.BurlyWood;
        }

        private void ageboddrder_MouseLeave(object sender, MouseEventArgs e)
        {
            ageboddrder.BorderBrush = Brushes.Gray;
        }

        private void datarojd_MouseEnter(object sender, MouseEventArgs e)
        {
            ageboddrder.BorderBrush = Brushes.BurlyWood;
        }

        private void datarojd_MouseLeave(object sender, MouseEventArgs e)
        {
            ageboddrder.BorderBrush = Brushes.Gray;
        }

        private void nametextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z | а-яА-Я]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void nametextbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void familytextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z | а-яА-Я]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void familytextbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
