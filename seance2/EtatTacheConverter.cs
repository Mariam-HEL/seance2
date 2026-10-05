using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace seance2
{
    public class EtatTacheConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isDone = value is bool b && b;
            string mode = parameter as string;

            if (mode == "Couleur")
            {
                return isDone ? Brushes.Gray : Brushes.Black;
            }

            if (mode == "Barre")
            {
                return isDone ? TextDecorations.Strikethrough : null;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
