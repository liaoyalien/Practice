using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ERPWebSite.Common.Extensions
{
    public static class StringExtension
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static bool IsInt(this string value)
        {
            return int.TryParse(value, out int _);
        }

        public static string ToImageUrl(this string text)
        {
            // to replace url e.g. from 'http://www.moshi.com/package/Helios.jpg' to '<a href="http://file.moshi.com/package/Helios.jpg" target="_blank"><img src="http://file.moshi.com/package/Helios.jpg" border="0" height="100"></a>'
            text = Regex.Replace(
                            text,
                            @"((http(s?):)([/|.|\w|\s|-])*\.(?:jpg|gif|png))",
                            "<a href=\"$1\" target=\"_blank\"><img src=\"$1\" border=\"0\" height=\"80\"></a>",
                            RegexOptions.IgnoreCase)
                        .Replace("www.moshi.com", "file.moshi.com");

            return text;
        }
    }
}
