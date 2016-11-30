﻿using System;
using System.Globalization;

#if NETFX || WINDOWS_PHONE
using System.Windows;
#elif (NETFX_CORE)
using Windows.UI.Xaml;
#endif

namespace ValueConverters
{
    public class DateTimeConverter : DateTimeConverterBase<DateTimeConverter>
    {
        /// <summary>
        ///     The datetime format property.
        ///     Check MSDN for information about predefined datetime formats:
        ///     http://msdn.microsoft.com/en-us/library/362btx8f(v=vs.90).aspx.
        /// </summary>
        public static readonly DependencyProperty FormatProperty = DependencyProperty.Register(
            "Format",
            typeof(string),
            typeof(DateTimeConverter),
            new PropertyMetadata(DefaultFormat));

        public static readonly DependencyProperty MinValueStringProperty = DependencyProperty.Register(
            "MinValueString",
            typeof(string),
            typeof(DateTimeConverter),
            new PropertyMetadata(DefaultMinValueString));

        public override string Format
        {
            get
            {
                return (string)this.GetValue(FormatProperty);
            }
            set
            {
                this.SetValue(FormatProperty, value);
            }
        }

        public override string MinValueString
        {
            get
            {
                return (string)this.GetValue(MinValueStringProperty);
            }
            set
            {
                this.SetValue(MinValueStringProperty, value);
            }
        }
    }
}