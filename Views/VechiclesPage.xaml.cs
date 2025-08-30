using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
namespace MyMauiApp.Views
{
    public partial class VehiclesPage : ContentPage
    {
        public List<Vehicle> vehicles { get; set; } = new List<Vehicle>();
        public VehiclesPage()
        {
            InitializeComponent();
            LoadVehicles();
        }
        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = VehicleSearchBar.Text.ToLower();

            // Filter based on model, brand, or license plate
            var filteredVehicles = vehicles.Where(v =>
                v.Model.ToLower().Contains(searchText) ||
                v.Brand.ToLower().Contains(searchText) ||
                v.LicencePlate.ToLower().Contains(searchText)).ToList();

            VehiclesCollectionView.ItemsSource = filteredVehicles;
        }
        private void LoadVehicles()
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle { No = 1, Model = "Corolla", Brand = "Toyota", LicencePlate = "YGN-1234", CarId = "C001", PricePerHour = 20,Status = "Maintenance" },
                new Vehicle { No = 2, Model = "Civic", Brand = "Honda", LicencePlate = "MDY-5678", CarId = "C002", PricePerHour = 25,Status = "Maintenance" },
                new Vehicle { No = 3, Model = "Elantra", Brand = "Hyundai", LicencePlate = "NPT-9012", CarId = "C003", PricePerHour = 22 ,Status = "Maintenance"},
            };

            VehiclesCollectionView.ItemsSource = vehicles;
        }

        public class Vehicle
        {
            public int No { get; set; }
            public string Model { get; set; } = string.Empty;
            public string Brand { get; set; } = string.Empty;
            public string LicencePlate { get; set; } = string.Empty;
            public string CarId { get; set; } = string.Empty;
            public decimal PricePerHour { get; set; }
            public string Status { get; set; } = string.Empty;
        }
    }
}