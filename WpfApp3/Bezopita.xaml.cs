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
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;

namespace WpfApp3
{   
    public partial class Bezopita : Page
    {

        public Bezopita()
        {

            InitializeComponent();
            if (helper.Experience == "Нет опыта работы")
            {
                kakoyopit.Text = helper.kakoytext;
            }
            else if (helper.Experience == "Есть опыт работы")
            {
                kakoyopit.Text = helper.kakoytext1;
            }
            rodnoucmb.ItemsSource = helper.languages;
            inolangcmb1.ItemsSource = helper.languages;
            inolangcmb2.ItemsSource = helper.languages;
            inolangcmb3.ItemsSource = helper.languages;
            inolangcmb4.ItemsSource = helper.languages;
            inolangcmb5.ItemsSource = helper.languages;
        }
        private void obracmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (obracmb.SelectedIndex != 0)
            {
                helper.educatLvl = obracmb.Text;
                obrazurovframe.Content = new ObrazovUrovPage();
                helper.CountObrazov = 1;                             
            }
            else if (obracmb.SelectedIndex == 0)
            {
                helper.educatLvl = obracmb.Text;
                obrazurovframe.Content = null;
                helper.CountObrazov = 0;
            }
        }

        private void Hyperlink_Click_1(object sender, RoutedEventArgs e)
        {
            inolang1.Visibility = Visibility.Visible;
            eshe1.Visibility = Visibility.Collapsed;
            eshe2.Visibility = Visibility.Visible;
            helper.Countlang = 1;
        }

        private void Hyperlink_Click_2(object sender, RoutedEventArgs e)
        {
            inolang2.Visibility = Visibility.Visible;
            eshe2.Visibility = Visibility.Collapsed;
            eshe3.Visibility = Visibility.Visible;
            crest1.Visibility = Visibility.Collapsed;
            helper.Countlang = 2;


        }

        private void Hyperlink_Click_3(object sender, RoutedEventArgs e)
        {
            inolang3.Visibility = Visibility.Visible;
            eshe3.Visibility = Visibility.Collapsed;
            eshe4.Visibility = Visibility.Visible;
            crest2.Visibility = Visibility.Collapsed;
            helper.Countlang = 3;
        }

        private void Hyperlink_Click_4(object sender, RoutedEventArgs e)
        {
            inolang4.Visibility = Visibility.Visible;
            eshe4.Visibility = Visibility.Collapsed;
            eshe5.Visibility = Visibility.Visible;
            crest3.Visibility = Visibility.Collapsed;
            helper.Countlang = 4;
        }

        private void Hyperlink_Click_5(object sender, RoutedEventArgs e)
        {
            inolang5.Visibility = Visibility.Visible;
            eshe5.Visibility = Visibility.Collapsed;
            crest4.Visibility = Visibility.Collapsed;
            helper.Countlang = 5;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            inolang1.Visibility = Visibility.Collapsed;
            eshe2.Visibility = Visibility.Collapsed;
            eshe1.Visibility = Visibility.Visible;
            helper.Countlang = 0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            inolang2.Visibility = Visibility.Collapsed;
            eshe3.Visibility = Visibility.Collapsed;
            eshe2.Visibility = Visibility.Visible;
            crest1.Visibility = Visibility.Visible;
            helper.Countlang = 1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            inolang3.Visibility = Visibility.Collapsed;
            eshe4.Visibility = Visibility.Collapsed;
            eshe3.Visibility = Visibility.Visible;
            crest2.Visibility = Visibility.Visible;
            helper.Countlang = 2;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            inolang4.Visibility = Visibility.Collapsed;
            eshe5.Visibility = Visibility.Collapsed;
            eshe4.Visibility = Visibility.Visible;
            crest3.Visibility = Visibility.Visible;
            helper.Countlang = 3;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            inolang5.Visibility = Visibility.Collapsed;
            eshe5.Visibility = Visibility.Visible;
            crest4.Visibility = Visibility.Visible;
            helper.Countlang = 4;

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            helper.polnayaZanyat = "Полная занятость";
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            helper.polnayaZanyat = "";
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            helper.chastichnayaZanyat = "Частичная занятость";
        }

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            helper.chastichnayaZanyat = "";
        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
            helper.proektnayaZanyat = "Проектная работа";
        }

        private void CheckBox_Unchecked_2(object sender, RoutedEventArgs e)
        {
            helper.proektnayaZanyat = "";
        }

        private void CheckBox_Checked_3(object sender, RoutedEventArgs e)
        {
            helper.Volonterstvo = "Волонтерство";
        }

        private void CheckBox_Unchecked_3(object sender, RoutedEventArgs e)
        {
            helper.Volonterstvo = "";
        }

        private void CheckBox_Checked_4(object sender, RoutedEventArgs e)
        {
            helper.Stajirovka = "Стажировка";
        }

        private void CheckBox_Unchecked_4(object sender, RoutedEventArgs e)
        {
            helper.Stajirovka = "";
        }

        private void CheckBox_Checked_5(object sender, RoutedEventArgs e)
        {
            helper.polniyDen = "Полный день";
        }

        private void CheckBox_Unchecked_5(object sender, RoutedEventArgs e)
        {
            helper.polniyDen = "";
        }

        private void CheckBox_Checked_6(object sender, RoutedEventArgs e)
        {
            helper.smenniyGrafik = "Сменный график";
        }

        private void CheckBox_Unchecked_6(object sender, RoutedEventArgs e)
        {
            helper.smenniyGrafik = "";
        }

        private void CheckBox_Checked_7(object sender, RoutedEventArgs e)
        {
            helper.gibkiyGrafik = "Гибкий график";
        }

        private void CheckBox_Unchecked_7(object sender, RoutedEventArgs e)
        {
            helper.gibkiyGrafik = "";
        }

        private void CheckBox_Checked_8(object sender, RoutedEventArgs e)
        {
            helper.udalennayaRabota = "Удаленная работа";
        }

        private void CheckBox_Unchecked_8(object sender, RoutedEventArgs e)
        {
            helper.udalennayaRabota = "";
        }

        private void CheckBox_Checked_9(object sender, RoutedEventArgs e)
        {
            helper.vahtoviyMetod = "Вахтовый метод";
        }

        private void CheckBox_Unchecked_9(object sender, RoutedEventArgs e)
        {
            helper.vahtoviyMetod = "";
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (helper.phoneNumber == "" | helper.City == "" | helper.Gender == "" | RezumePage.citview == null | popit.Text == "" | jelaemaya.Text == "" | zarplata.Text == "" | helper.rodnoy == "" | omne.Text == "" | helper.pereezd == "" )
            {
                MessageBox.Show("Пожалуйста заполните все данные!");
            }
            else
            {
                foreach (var c in RezumePage.citview)
                {
                    if (RezumePage.citview.IndexOf(c) == RezumePage.citview.Count - 1)
                    {
                        helper.noviylist = helper.noviylist + c.Name;
                    }
                    else
                    {
                        helper.noviylist = helper.noviylist + c.Name + ", ";
                    }
                }
                foreach (var b in prava.SelectedItems)
                {
                    if (prava.SelectedItems.IndexOf(b) == prava.SelectedItems.Count - 1)
                    {
                        var lol = b as ListBoxItem;
                        helper.pravki = helper.pravki + lol.Content;
                    }
                    else
                    {
                        var lol = b as ListBoxItem;
                        helper.pravki = helper.pravki + lol.Content + ", ";
                    }                 
                }
                var un1 = (from unempl in App.bdhelp.unemployeds where unempl.login == helper.lognuj select unempl).FirstOrDefault();
                DateTime currentDate = DateTime.Now;
                using (WebResponse response = WebRequest.Create("http://www.microsoft.com").GetResponse())
                    currentDate = DateTime.ParseExact(response.Headers["date"], "ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.AssumeUniversal);
                rezume newrezume = new rezume
                {

                    phone_number = helper.phoneNumber,
                    city = helper.City,
                    gender = helper.Gender,
                    citizenship = helper.noviylist,
                    experience_job = helper.Experience,
                    WhyNot = popit.Text,
                    career_objective = jelaemaya.Text,
                    salary = Convert.ToInt32(zarplata.Text),
                    currency = valyta.Text,
                    education_lvl = helper.Educationlvlll,
                    native_language = helper.rodnoy,
                    about_myself = omne.Text,
                    moving = helper.pereezd,
                    busyness = helper.polnayaZanyat + " " + helper.chastichnayaZanyat + " " + helper.proektnayaZanyat + " " + helper.Volonterstvo + " " + helper.Stajirovka,
                    schedule = helper.polniyDen + " " + helper.smenniyGrafik + " " + helper.gibkiyGrafik + " " + helper.udalennayaRabota + " " + helper.vahtoviyMetod,
                    is_have_car = helper.HaveACar,
                    category_of_rights = helper.pravki,
                    datetime_of_public = currentDate,
                    unemployed_id = un1.id


                };
                if (helper.CountObrazov == 1)
                {
                    education neweduc = new education()
                    {
                        educational_institution = helper.Zavedenie,
                        faculty = helper.Facultet,
                        specialization = helper.Specialization,
                        year_of_end = helper.GodOkonchaniya,
                        rezume_id = newrezume.id
                    };
                    App.bdhelp.educations.Add(neweduc);
                }
                else if (helper.CountObrazov == 2)
                {
                    education neweduc = new education()
                    {
                        educational_institution = helper.Zavedenie,
                        faculty = helper.Facultet,
                        specialization = helper.Specialization,
                        year_of_end = helper.GodOkonchaniya,
                        rezume_id = newrezume.id
                    };
                    education neweduc2 = new education()
                    {
                        educational_institution = helper.Zavedenie1,
                        faculty = helper.Facultet1,
                        specialization = helper.Specialization1,
                        year_of_end = helper.GodOkonchaniya1,
                        rezume_id = newrezume.id
                    };
                    App.bdhelp.educations.Add(neweduc);
                    App.bdhelp.educations.Add(neweduc2);
                }
                    
                    if (helper.Countlang == 1)
                    {
                    inolanguage newino = new inolanguage()
                    {
                        name = inolangcmb1.Text,
                        lvl = lvlLang1.Text,
                        rezume_id = newrezume.id
                    };
                    App.bdhelp.inolanguages.Add(newino);
                }
                else if (helper.Countlang == 2)
                {
                    inolanguage newino = new inolanguage()
                    {
                        name = inolangcmb1.Text,
                        lvl = lvlLang1.Text,
                        rezume_id = newrezume.id
                    };
                    inolanguage newino2 = new inolanguage()
                    {
                        name = inolangcmb2.Text,
                        lvl = lvlLang2.Text,
                        rezume_id = newrezume.id
                    };
                    App.bdhelp.inolanguages.Add(newino);
                    App.bdhelp.inolanguages.Add(newino2);
                }
                else if (helper.Countlang == 3)
                {
                    inolanguage newino = new inolanguage()
                    {
                        name = inolangcmb1.Text,
                        lvl = lvlLang1.Text,
                        rezume_id = newrezume.id
                    };
                    inolanguage newino2 = new inolanguage()
                    {
                        name = inolangcmb2.Text,
                        lvl = lvlLang2.Text,
                        rezume_id = newrezume.id
                    };
                    inolanguage newino3 = new inolanguage()
                    {
                        name = inolangcmb3.Text,
                        lvl = lvlLang3.Text,
                        rezume_id = newrezume.id
                    };
                    App.bdhelp.inolanguages.Add(newino);
                    App.bdhelp.inolanguages.Add(newino2);
                    App.bdhelp.inolanguages.Add(newino3);

                }
                else if (helper.Countlang == 4)
                {
                    inolanguage newino = new inolanguage()
                    {
                        name = inolangcmb1.Text,
                        lvl = lvlLang1.Text,
                        rezume_id = newrezume.id
                    };
                    inolanguage newino2 = new inolanguage()
                    {
                        name = inolangcmb2.Text,
                        lvl = lvlLang2.Text,
                        rezume_id = newrezume.id
                    };
                    inolanguage newino3 = new inolanguage()
                    {
                        name = inolangcmb3.Text,
                        lvl = lvlLang3.Text,
                        rezume_id = newrezume.id
                    };
                    inolanguage newino4 = new inolanguage()
                    {
                        name = inolangcmb4.Text,
                        lvl = lvlLang4.Text,
                        rezume_id = newrezume.id
                    };
                    App.bdhelp.inolanguages.Add(newino);
                    App.bdhelp.inolanguages.Add(newino2);
                    App.bdhelp.inolanguages.Add(newino3);
                    App.bdhelp.inolanguages.Add(newino4);

                }
                else if (helper.Countlang == 5)
                {
                    inolanguage newino = new inolanguage()
                    {
                        name = helper.inostan1,
                        lvl = lvlLang1.Text,
                        rezume_id = newrezume.id
                    };
                    inolanguage newino2 = new inolanguage()
                    {
                        name = helper.inostan2,
                        lvl = lvlLang2.Text,
                        rezume_id = newrezume.id
                    };
                    inolanguage newino3 = new inolanguage()
                    {
                        name = helper.inostan3,
                        lvl = lvlLang3.Text,
                        rezume_id = newrezume.id
                    };
                    inolanguage newino4 = new inolanguage()
                    {
                        name = helper.inostan4,
                        lvl = lvlLang4.Text,
                        rezume_id = newrezume.id
                    };
                    inolanguage newino5 = new inolanguage()
                    {
                        name = helper.inostan1,
                        lvl = lvlLang5.Text,
                        rezume_id = newrezume.id
                    };
                    App.bdhelp.inolanguages.Add(newino);
                    App.bdhelp.inolanguages.Add(newino2);
                    App.bdhelp.inolanguages.Add(newino3);
                    App.bdhelp.inolanguages.Add(newino4);
                    App.bdhelp.inolanguages.Add(newino5);
                }


                App.bdhelp.rezumes.Add(newrezume);
                //App.bdhelp.educations.Add(neweduc);
                //App.bdhelp.inolanguages.Add(newino);
                App.bdhelp.SaveChanges();
                MessageBox.Show("Ваше резюме успешно опубликовано!");
                
            }
            
            }

            private void RadioButton_Checked(object sender, RoutedEventArgs e)
            {
                helper.pereezd = "Невозможен";
            }

            private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
            {
                helper.pereezd = "Возможен";
            }

            private void CheckBox_Checked_10(object sender, RoutedEventArgs e)
            {
                helper.HaveACar = "Есть личный автомобиль";
            }

            private void CheckBox_Unchecked_10(object sender, RoutedEventArgs e)
            {
                helper.HaveACar = "Нет личного автомобиля";
            }

        private void inolangcmb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var p = inolangcmb1.SelectedItem as Languagee;
            helper.inostan1 = p.Name;
        }

        private void inolangcmb2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var p = inolangcmb2.SelectedItem as Languagee;
            helper.inostan2 = p.Name;
        }

        private void inolangcmb3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var p = inolangcmb3.SelectedItem as Languagee;
            helper.inostan3 = p.Name;
        }

        private void inolangcmb4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var p = inolangcmb4.SelectedItem as Languagee;
            helper.inostan4 = p.Name;
        }

        private void inolangcmb5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var p = inolangcmb5.SelectedItem as Languagee;
            helper.inostan5 = p.Name;
        }

       
        private void rodnoucmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var p = rodnoucmb.SelectedItem as Languagee;
            helper.rodnoy = p.Name;
        }

        private void zarplata_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void valyta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            helper.Valuta = valyta.Text;
        }
    }
    }


