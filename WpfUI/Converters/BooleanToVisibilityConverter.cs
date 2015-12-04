namespace WpfUI.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    sealed class BooleanToVisibilityConverter : IValueConverter
    {
        private bool _isInverse;

        public bool IsInverse
        {
            get { return _isInverse; }
            set { _isInverse = value; }
        }

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = Convert.ToBoolean(value);
            if (_isInverse)
                boolValue = !boolValue;
            return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibility = (Visibility)value;
            bool converted = Visibility.Visible == visibility ? true : false;
            return _isInverse ? !converted : converted;
        }
    }
}
