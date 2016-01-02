using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;

namespace RestaurantManager.Extensions
{
    public class BoolToColorConverter : IValueConverter
    {
        public Color TrueColor { get; set; }
        public Color FalseColor { get; set; }

        public BoolToColorConverter()
        {
            this.TrueColor = Colors.Green;
            this.FalseColor = Colors.Red;
        }

    public object Convert(object value, Type targetType, object parameter, string language)
        {
            var b = value as bool?;

            if (b.HasValue)
            {
                return (b.Value) ? TrueColor : FalseColor;
            }

            return Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var c = value as Color?;

            if (c.HasValue)
            {
                return c.Value == TrueColor;
            }

            return null;
        }
    }
}
