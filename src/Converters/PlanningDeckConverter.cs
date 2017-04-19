using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace PlanningPoker.Converters
{
    public class PlanningDeckConverter : IValueConverter
    {
        /// <summary>
        /// Converts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var enumValue = (Enum)(value);
            DisplayAttribute attribute = enumValue.GetType()
                .GetField(enumValue.ToString())
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .SingleOrDefault() as DisplayAttribute;

            return attribute == null 
                ? enumValue.ToString() 
                : attribute.Description;
        }

        /// <summary>
        /// Converts the back.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return Convert(value, targetType, parameter, language);
        }
    }
}
