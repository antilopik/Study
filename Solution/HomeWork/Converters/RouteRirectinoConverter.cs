using System.Globalization;
using System.Windows.Data;
using HomeWork.Models;

namespace HomeWork.Converters
{
    public sealed class RouteRirectinoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Direction direction)
            {
                switch (direction)
                {
                    case Direction.LeftToRight:
                        return " -> ";
                    case Direction.RightToLeft:
                        return " <- ";
                }
            }
            throw new NotSupportedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
    }
}
