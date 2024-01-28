using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Data.Entity;

namespace Kwiaciarnia
{
    public partial class Klienci : Window
    {
        ApplicationContext db;

        public Klienci()
        {
            InitializeComponent();
            db = new ApplicationContext();
            var flowerNames = db.Flowers.Select(f => f.Name).ToList();
            comboBoxFlowers.ItemsSource = flowerNames;
        }

        private void Button_Zamow(object sender, RoutedEventArgs e)
        {
            string selectedFlower = comboBoxFlowers.SelectedItem as string;
            DateTime selectedDeliveryDate = datePickerDeliveryDate.SelectedDate ?? DateTime.Now;
            int quantity;
            bool isQuantityValid = int.TryParse(textBoxQuantity.Text, out quantity);
            string address = textBoxAddress.Text.Trim();
            string firstName = textBoxFirstName.Text.Trim();
            string lastName = textBoxLastName.Text.Trim();
            string phoneNumber = textBoxPhoneNumber.Text.Trim();

            if (string.IsNullOrEmpty(selectedFlower) || selectedDeliveryDate <= DateTime.Now || !isQuantityValid || quantity <= 0 || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Proszę poprawnie wypełnić wszystkie pola!");
                return;
            }

            Flower flower = db.Flowers.FirstOrDefault(f => f.Name == selectedFlower);
            if (flower == null)
            {
                MessageBox.Show("Wybranego kwiatu nie znaleziono w bazie danych!");
                return;
            }

            Order order = new Order()
            {
                FlowerId = flower.flowerId,
                Quantity = quantity,
                Address = address,
                Date = selectedDeliveryDate.ToString("yyyy-MM-dd"),
                Phone = phoneNumber,
                FirstName = firstName,
                LastName = lastName
            };

            db.Orders.Add(order);
            db.SaveChanges();

            MessageBox.Show("Zamówienie złożone!");
            ClearForm();
        }

        private User GetLoggedInUser(string login)
        {
            return db.Users.FirstOrDefault(u => u.Login == login);
        }

        private void ClearForm()
        {
            comboBoxFlowers.SelectedIndex = -1;
            datePickerDeliveryDate.SelectedDate = DateTime.Now;
            textBoxQuantity.Clear();
            textBoxAddress.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxPhoneNumber.Clear();
        }
    }
}
