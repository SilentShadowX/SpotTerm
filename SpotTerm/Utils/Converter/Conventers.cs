﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace SpotTerm.Utils.Converter
{
    public class Conventers
    {
        class ImageConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                try
                {
                    BitmapImage image = new BitmapImage(new Uri((string)value));
                    int a = 1;
                    return image;
                }
                catch (Exception e)
                {
                    return new BitmapImage();
                }

            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}