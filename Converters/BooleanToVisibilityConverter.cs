using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace TestProject.Converters {
    public class BooleanToVisibilityConverter : IValueConverter {
        private readonly System.Windows.Controls.BooleanToVisibilityConverter _converter;

        public BooleanToVisibilityConverter() {
            _converter = new System.Windows.Controls.BooleanToVisibilityConverter();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return _converter.Convert((bool)value, targetType, parameter, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            var ret = _converter.ConvertBack(value, targetType, parameter, culture);
            return (bool)ret;
        }
    }
}
