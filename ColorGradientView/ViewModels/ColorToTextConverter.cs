using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ColorGradientView.ViewModels
{
    public class ColorToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not Color)
            {
                return "";
            }
            Color color = (Color)value;

            return string.Format("#{0}{1}{2}", color.R.ToString("x2"), color.G.ToString("x2"), color.B.ToString("x2"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
