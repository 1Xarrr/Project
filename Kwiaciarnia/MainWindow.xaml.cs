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

namespace Kwiaciarnia
{
    public partial class MainWindow : Window
    {
        ApplicationContext db;

        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void Button_Rejestracja(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass_2 = passBox_2.Password.Trim();
            string email = textBoxEmail.Text.ToLower().Trim();

            if(login.Length < 3)
            {
                textBoxLogin.ToolTip = "Błąd wypełnienia pola!";
                textBoxLogin.Background = Brushes.DarkRed;
            } 
            else if(pass.Length < 3)
            {
                passBox.ToolTip = "Błąd wypełnienia pola!";
                passBox.Background = Brushes.DarkRed;
            }
            else if(pass_2 != pass)
            {
                passBox_2.ToolTip = "Błąd wypełnienia pola!";
                passBox_2.Background = Brushes.DarkRed;
            }
            else if(email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Błąd wypełnienia pola!";
                textBoxEmail.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
                passBox_2.ToolTip = "";
                passBox_2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Wszystko jest w porządku!");
                User user = new User(login, email, pass);

                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        private void Button_Click_Zaloguj_Sie(object sender, RoutedEventArgs e)
        {
            ZalogujSie zalogujSie = new ZalogujSie();
            zalogujSie.Show();
            Close();
        }

        private void Button_Click_Rejestracja_(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Już jesteś na tej stronie!");
        }
    }
}
