﻿using System;
using System.Globalization;

#if (NETFX || WINDOWS_PHONE)
using System.Windows;
using System.Windows.Data;

#elif (WINDOWS_APP || WINDOWS_PHONE_APP)
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
#endif

namespace ValueConverters
{
    public abstract class ConverterBase : DependencyObject, IValueConverter
    {
        protected abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        protected virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException(string.Format("Converter '{0}' does not support backward conversion.", this.GetType().Name));
        }

#if NETFX || WINDOWS_PHONE
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return this.Convert(value, targetType, parameter, culture);
            }
            catch
            {
                return DependencyProperty.UnsetValue;
            }
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return this.ConvertBack(value, targetType, parameter, culture);
            }
            catch
            {
                return DependencyProperty.UnsetValue;
            }
        }
#elif (WINDOWS_APP || WINDOWS_PHONE_APP)
        object IValueConverter.Convert(object value, Type targetType, object parameter, string culture)
        {
            try
            {
                return this.Convert(value, targetType, parameter, new CultureInfo(culture));
            }
            catch
            {
                return DependencyProperty.UnsetValue;
            }
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            try
            {
                return this.ConvertBack(value, targetType, parameter, new CultureInfo(culture));
            }
            catch
            {
                return DependencyProperty.UnsetValue;
            }
        }
#endif
    }
}