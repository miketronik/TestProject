using NLog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TestProject.Converters {

    public class DateTimeConverter : IValueConverter {
        private static readonly ILogger Log = LogManager.GetCurrentClassLogger();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null) {
                return "";
            }
            var time = (DateTime)value;
            return time.ToLocalTime().ToString("dd.MM.yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            try {
                string format = "d.M.yyyy";
                DateTime MyDateTime = DateTime.ParseExact(value.ToString(), format, culture);
                return MyDateTime;
            } catch (Exception e) {
                Log.Error(e.StackTrace);
                //throw e;
            }
            return null;
        }
    }

}
