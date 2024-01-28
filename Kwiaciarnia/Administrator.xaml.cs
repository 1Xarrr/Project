using System.Linq;
using System.Windows;

namespace Kwiaciarnia
{
    public partial class Administrator : Window
    {
        private ApplicationContext db;

        public Administrator()
        {
            InitializeComponent();
            db = new ApplicationContext();

            LoadOrders();
        }

        private void LoadOrders()
        {
            var orders = db.Orders.ToList();
            dataGridOrders.ItemsSource = orders;
        }

        private void Button_Flowers(object sender, RoutedEventArgs e)
        {
            Zarzadzanie zarzadzanie = new Zarzadzanie();
            zarzadzanie.Show();
        }
    }
}
