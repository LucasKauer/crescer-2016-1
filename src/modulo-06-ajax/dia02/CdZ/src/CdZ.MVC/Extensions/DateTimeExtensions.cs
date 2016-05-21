using System;
using System.Globalization;

namespace CdZ.MVC.Extensions
{
    public static class DateTimeExtensions
    {
        // Adaptado de http://stackoverflow.com/a/115034
        public static string FromDateTimeToISOString(this DateTime date)
        {
            return date.ToString("s", CultureInfo.InvariantCulture);
        }
    }
}