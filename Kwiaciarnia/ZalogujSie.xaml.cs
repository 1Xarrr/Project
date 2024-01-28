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
using System.Windows.Shapes;

namespace Kwiaciarnia
{
    public partial class ZalogujSie : Window
    {
        public ZalogujSie()
        {
            InitializeComponent();
        }

        private void Button_ZalogujSie(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();

            if (login.Length < 3)
            {
                textBoxLogin.ToolTip = "Błąd wypełnienia pola!";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 3)
            {
                passBox.ToolTip = "Błąd wypełnienia pola!";
                passBox.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                User authUser = null;
                using (ApplicationContext context = new ApplicationContext())
                {
                    authUser = context.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
                }
                if (authUser != null)
                {
                    MessageBox.Show("Wszystko w porządku!");

                    if (login == "Admin")
                    {
                        Administrator administrator = new Administrator();
                        administrator.Show();
                    }
                    else
                    {
                        Klienci klienci = new Klienci();
                        klienci.Show();
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show("Wpisałeś coś nieprawidłowo!");
                }
            }
        }

        private void Button_ZalogujSie_(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Już jesteś na tej stronie!");
        }

        private void Button_Click_Rejestracja(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
