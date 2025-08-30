using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.Controls;

namespace MyMauiApp.Views
{
    public partial class CustomerPage : ContentPage
    {
        ObservableCollection<Customer> allCustomers;

        public CustomerPage()
        {
            InitializeComponent();

            // Example data
            allCustomers = new ObservableCollection<Customer>
            {
                new Customer { No=1, Name="John Doe", PhoneNumber="123456789", Address="Yangon" },
                new Customer { No=2, Name="Jane Smith", PhoneNumber="987654321", Address="Mandalay" }
            };

            CustomerCollection.ItemsSource = allCustomers;
        }

        private void CustomerSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = e.NewTextValue.ToLower();
            CustomerCollection.ItemsSource = string.IsNullOrWhiteSpace(keyword)
                ? allCustomers
                : new ObservableCollection<Customer>(
                    allCustomers.Where(c =>
                        c.Name.ToLower().Contains(keyword) ||
                        c.PhoneNumber.Contains(keyword)));
        }
    }

    public class Customer
    {
        public int No { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
