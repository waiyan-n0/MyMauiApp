using System;
using Microsoft.Maui.Controls;

namespace MyMauiApp.Views
{
    public partial class AppointmentPage : ContentPage
    {
        private int currentStep = 1; // Track current progress step

        public AppointmentPage()
        {
            InitializeComponent();

            // Default values
            NameEntry.Text = "John Doe";
            AddressEntry.Text = "123 Main Street";
            PhoneEntry.Text = "555-1234";
            StartDate.Date = DateTime.Today;
            StartTime.Time = new TimeSpan(9, 0, 0);
            EndDate.Date = DateTime.Today.AddDays(1);
            EndTime.Time = new TimeSpan(17, 0, 0);

            LicenceSwitch.IsToggled = true; // default: user has licence

            // Events
            LicenceSwitch.Toggled += LicenceSwitch_Toggled;
            SubmitButton.Clicked += SubmitButton_Clicked;

            UpdateProgress();
        }

        private void LicenceSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            DriverFrame.IsVisible = !e.Value; // Show driver option if NO licence
        }

        private async void SubmitButton_Clicked(object sender, EventArgs e)
        {
            if (currentStep == 1)
            {
                // Step 1 → Move to Step 2
                if (LicenceSwitch.IsToggled)
                {
                    // Has licence → ask for licence photo
                    LicencePhotoFrame.IsVisible = true;
                    DriverFrame.IsVisible = false;
                    await DisplayAlert("Step 2", "Please upload your licence photo.", "OK");
                }
                else
                {
                    // No licence → ask to select driver
                    DriverFrame.IsVisible = true;
                    LicencePhotoFrame.IsVisible = false;
                    await DisplayAlert("Step 2", "Please select a company driver.", "OK");
                }

                currentStep = 2;
                UpdateProgress();
                return;
            }

            if (currentStep == 2)
            {
                // Step 2 → Move to Step 3 (Payment)
                PaymentFrame.IsVisible = true;
                await DisplayAlert("Step 3", "Proceeding to payment.", "OK");

                currentStep = 3;
                UpdateProgress();
                return;
            }

            if (currentStep == 3)
            {
                // Final Step → Show booking summary
                string summary =
                    $"Name: {NameEntry.Text}\n" +
                    $"Address: {AddressEntry.Text}\n" +
                    $"Phone: {PhoneEntry.Text}\n" +
                    $"Licence: {(LicenceSwitch.IsToggled ? "Yes" : "No")}\n" +
                    $"Start: {StartDate.Date:d} {StartTime.Time}\n" +
                    $"End: {EndDate.Date:d} {EndTime.Time}\n";

                if (!LicenceSwitch.IsToggled)
                {
                    summary += $"Driver Required: {(DriverSwitch.IsToggled ? "Yes" : "No")}\n";
                }
                else
                {
                    summary += "Licence Photo: [uploaded]\n";
                }

                summary += "Payment: [done]";

                await DisplayAlert("Booking Summary", summary, "Finish");
            }
        }

        private void UpdateProgress()
        {
            // Reset all step colors
            Step1Box.BackgroundColor = Colors.LightGray;
            Step2Box.BackgroundColor = Colors.LightGray;
            Step3Box.BackgroundColor = Colors.LightGray;

            // Highlight current step in green
            if (currentStep == 1)
                Step1Box.BackgroundColor = Colors.Green;
            else if (currentStep == 2)
                Step2Box.BackgroundColor = Colors.Green;
            else if (currentStep == 3)
                Step3Box.BackgroundColor = Colors.Green;
        }
    }
}
