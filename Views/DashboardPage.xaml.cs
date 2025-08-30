using System;
using Microsoft.Maui.Controls;

namespace MyMauiApp.Views
{
    public partial class DashboardPage : ContentPage
    {
        private System.Timers.Timer timer;

        public DashboardPage()
        {
            InitializeComponent();
            UpdateTime();
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += (s, e) => MainThread.BeginInvokeOnMainThread(UpdateTime);
            timer.Start();
        }

        void UpdateTime()
        {
            TimeLabel.Text = DateTime.Now.ToString();
        }

        void OnDashboardClicked(object sender, EventArgs e)
        {
            ContentArea.Content = new Label { Text = "Dashboard Overview", FontSize = 24, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
        }

        void OnAppointmentClicked(object sender, EventArgs e)
        {
            ContentArea.Content = new AppointmentPage().Content;
        }

        void OnCustomerClicked(object sender, EventArgs e)
        {
            ContentArea.Content = new CustomerPage().Content;
        }

        void OnVehiclesClicked(object sender, EventArgs e)
        {
            ContentArea.Content = new VehiclesPage().Content;
        }

        void OnRentalListsClicked(object sender, EventArgs e)
        {
            ContentArea.Content = new Label { Text = "Rental Lists Page", FontSize = 24, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
        }

        void OnMaintenanceClicked(object sender, EventArgs e)
        {
            ContentArea.Content = new Label { Text = "Maintenance Page", FontSize = 24, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
        }

        void OnLogoutClicked(object sender, EventArgs e)
        {
            if (Application.Current.Windows.Count > 0)
            {
                Application.Current.Windows[0].Page = new LoginPage();
            }

        }
    }
}