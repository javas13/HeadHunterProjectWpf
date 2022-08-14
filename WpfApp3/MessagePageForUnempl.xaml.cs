using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для MessagePageForUnempl.xaml
    /// </summary>
    public partial class MessagePageForUnempl : Page
    {
        public MessagePageForUnempl(int emplid, int chanid)
        {
            InitializeComponent();
            var lo = (from employerr in App.bdhelp.employers where employerr.id == helper.unemploylId1 select employerr).FirstOrDefault();
            var unempl = (from unemploy in App.bdhelp.unemployeds where unemploy.login == helper.lognuj select unemploy).FirstOrDefault();
            var p = (from chan in App.bdhelp.channels where chan.id == chanid select chan).FirstOrDefault();
            var mes = from mesag in App.bdhelp.messages where mesag.channel.id == chanid select mesag;
            first.Text = p.employer.firstname;
            last.Text = " " + p.employer.lastname;
            messageList.ItemsSource = mes.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var unempl = (from unemploy in App.bdhelp.unemployeds where unemploy.login == helper.lognuj select unemploy).FirstOrDefault();
            var p = (from chan in App.bdhelp.channels where chan.unemployer_id == unempl.id & chan.employer_id == helper.unemploylId1 select chan).FirstOrDefault();
            var mes = from mesag in App.bdhelp.messages where mesag.channel.id == p.id select mesag;
            DateTime currentDate = DateTime.Now;
            using (WebResponse response = WebRequest.Create("http://www.microsoft.com").GetResponse())
                currentDate = DateTime.ParseExact(response.Headers["date"], "ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.AssumeUniversal);
            if (p.messages.Count() > 0)
            {
                message mesnew = new message()
                {
                    message1 = messtxt.Text,
                    channel_id = p.id,
                    sender_name = unempl.firstname,
                    time_of_send = currentDate

                };

                App.bdhelp.messages.Add(mesnew);
                App.bdhelp.SaveChanges();
                messtxt.Text = "";
                messageList.ItemsSource = mes.ToList();
            }
            else
            {

                message mesnew = new message()
                {
                    message1 = messtxt.Text,
                    channel_id = p.id,
                    sender_name = unempl.firstname,
                    time_of_send = currentDate

                };
                p.is_created = 1;
                App.bdhelp.messages.Add(mesnew);
                App.bdhelp.SaveChanges();
                messtxt.Text = "";
                messageList.ItemsSource = mes.ToList();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
