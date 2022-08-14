using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp3
{
    public class LastItemConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            IEnumerable<message> items = value as IEnumerable<message>;
            if (items != null)
            {
                message p = items.LastOrDefault();

                return p.message1;
            }
            else return Binding.DoNothing;
           
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
