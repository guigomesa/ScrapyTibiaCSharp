using System;
using System.Globalization;

namespace TibiaApi.Comum.Extensions
{
    public static class DateTimeExtensions
    {
        public static string[] TibiaFormatDate = new[]
            {
                "MMM dd yyyy, HH:mm:ss CEST",
                "MMM dd yyyy, HH:mm:ss CET"
            };


        public static DateTime ConvertDateFromSite(string dataStr)
        {
            if (DateTime.TryParseExact(dataStr, TibiaFormatDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out var retorno))
            {
                return retorno;
            }

            return DateTime.MinValue;
        }
    }
}
