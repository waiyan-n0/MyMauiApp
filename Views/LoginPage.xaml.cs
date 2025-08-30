using Microsoft.Maui.Controls;

namespace MyMauiApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void OnLoginClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            // TODO: Add your login logic here
            DisplayAlert("Login", $"Username: {username}\nPassword: {password}", "OK");
        }
    }
}