using System;
using System.Globalization;

namespace CdZ.MVC.Extensions
{
    public static class StringExtensions
    {
        // Adaptado de http://stackoverflow.com/a/3556188
        public static DateTime FromISOToDateTime(this string isoDate)
        {
            return DateTime.Parse(isoDate, null, DateTimeStyles.RoundtripKind);
        }
    }
}