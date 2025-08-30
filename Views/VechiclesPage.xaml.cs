using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;

namespace MyMauiApp.Views
{
    public partial class VehiclesPage : ContentPage
    {
        // Vehicles list to hold the vehicle data
        public List<Vehicle> vehicles { get; set; } = new List<Vehicle>();


        public VehiclesPage()
{
    InitializeComponent();

            vehicles.Add(new Vehicle { No = 1, Model = "Corolla", Brand = "Toyota", LicencePlate = "YGN-1234", CarId = "C001", PricePerHour = 20, Status = "Available" });
            vehicles.Add(new Vehicle { No = 2, Model = "Civic", Brand = "Honda", LicencePlate = "MDY-5678", CarId = "C002", PricePerHour = 25, Status = "On Rent" });
            vehicles.Add(new Vehicle { No = 3, Model = "Elantra", Brand = "Hyundai", LicencePlate = "NPT-9012", CarId = "C003", PricePerHour = 22, Status = "Maintenance" });
            this.BindingContext = this;  // Set the BindingContext to the current page
}



        // Method to load vehicle data




        // Filter vehicles based on the search bar
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

        // Add Vehicle button clicked
        private async void OnAddVehicleClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Add Vehicle", "This is where you can add a new vehicle.", "OK");
        }

        // Vehicle class to represent the vehicle data
        public class Vehicle
{
    public int No { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public string LicencePlate { get; set; }
    public string CarId { get; set; }
    public double PricePerHour { get; set; }
    public string Status { get; set; }
}

    }
}
