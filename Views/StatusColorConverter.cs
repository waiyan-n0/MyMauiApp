using Microsoft.Maui.Controls;
using System;
using System.Globalization;

namespace MyMauiApp.Converters
{
    public class StatusColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string status)
            {
                switch (status.ToLower())
                {
                    case "available":
                        return Color.FromArgb("#28a745");  // Green (Available)
                    case "maintenance":
                        return Color.FromArgb("#ffc107");  // Yellow (Maintenance)
                    case "inrent":
                        return Color.FromArgb("#dc3545");  // Red (In Rent)
                    default:
                        return Color.FromArgb("#28a745");  // Default color for unknown status
                }
            }
            return Color.FromArgb("#28a745");  // Default if status is not set or null
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
