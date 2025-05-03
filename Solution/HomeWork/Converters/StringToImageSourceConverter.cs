using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace HomeWork.Converters
{
    public sealed class StringToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string fileName)
            {
                var bimage = new BitmapImage();
                bimage.BeginInit();
                bimage.UriSource = new Uri($"pack://application:,,,/Images/{fileName}", UriKind.Absolute);
                bimage.EndInit();
                return bimage;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
    }
}
