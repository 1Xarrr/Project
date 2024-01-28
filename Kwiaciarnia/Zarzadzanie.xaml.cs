using System.Linq;
using System.Windows;

namespace Kwiaciarnia
{
    public partial class Zarzadzanie : Window
    {
        private readonly ApplicationContext db;

        public Zarzadzanie()
        {
            InitializeComponent();
            db = new ApplicationContext();
            dataGridFlowers.ItemsSource = db.Flowers.ToList();
        }

        private void Button_AddNewFlower(object sender, RoutedEventArgs e)
        {
            string newFlowerName = textBoxNewFlowerName.Text.Trim();
            string newFlowerPriceText = textBoxNewFlowerPrice.Text.Trim();

            if (string.IsNullOrEmpty(newFlowerName) || string.IsNullOrEmpty(newFlowerPriceText) || !double.TryParse(newFlowerPriceText, out double newFlowerPrice))
            {
                MessageBox.Show("Podaj prawidłową nazwę i cenę nowego kwiatu.");
                return;
            }

            Flower newFlower = new Flower
            {
                Name = newFlowerName,
                Price = newFlowerPrice
            };

            db.Flowers.Add(newFlower);
            db.SaveChanges();

            dataGridFlowers.ItemsSource = db.Flowers.ToList();

            textBoxNewFlowerName.Clear();
            textBoxNewFlowerPrice.Clear();

            MessageBox.Show("Nowy kwiat został pomyślnie dodany!");
        }

        private void Button_UpdateSelectedFlower(object sender, RoutedEventArgs e)
        {
            Flower selectedFlower = dataGridFlowers.SelectedItem as Flower;

            if (selectedFlower == null)
            {
                MessageBox.Show("Wybierz kwiat do aktualizacji.");
                return;
            }

            string updatedFlowerName = textBoxSelectedFlowerName.Text.Trim();
            string updatedFlowerPriceText = textBoxSelectedFlowerPrice.Text.Trim();

            if (string.IsNullOrEmpty(updatedFlowerName) && string.IsNullOrEmpty(updatedFlowerPriceText))
            {
                MessageBox.Show("Podaj nową nazwę lub nową cenę wybranego kwiatu.");
                return;
            }

            if (!string.IsNullOrEmpty(updatedFlowerName))
            {
                selectedFlower.Name = updatedFlowerName;
            }

            if (!string.IsNullOrEmpty(updatedFlowerPriceText) && double.TryParse(updatedFlowerPriceText, out double updatedFlowerPrice))
            {
                selectedFlower.Price = updatedFlowerPrice;
            }

            db.SaveChanges();

            dataGridFlowers.ItemsSource = db.Flowers.ToList();

            textBoxSelectedFlowerName.Clear();
            textBoxSelectedFlowerPrice.Clear();

            MessageBox.Show("Selected flower updated successfully!");
        }

        private void Button_DeleteSelectedFlower(object sender, RoutedEventArgs e)
        {
            Flower selectedFlower = dataGridFlowers.SelectedItem as Flower;

            if (selectedFlower == null)
            {
                MessageBox.Show("Wybrany kwiat został pomyślnie zaktualizowany!");
                return;
            }

            db.Flowers.Remove(selectedFlower);
            db.SaveChanges();

            dataGridFlowers.ItemsSource = db.Flowers.ToList();

            MessageBox.Show("Wybrany kwiat został pomyślnie usunięty!");
        }
    }
}
