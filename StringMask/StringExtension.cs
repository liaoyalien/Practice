using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringMask
{
    public static class StringExtension
    {
        //遮住字首以後的其餘字元
        public static string ToMask(this string str, char maskcharacter)
        {
            return $"{str.Substring(0, 1)}{string.Concat(Enumerable.Repeat(maskcharacter, str.Length - 1))}";

        }
    }
}
