using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn.Extensions
{
    static class StringExtensions
    {
        public static string ToSanitized(this string regularText)
        {
            return $"{regularText}TEST";
        }

        public static string ToUnsanitized(this string regularText)
        {
            return $" \0\a \b\f{regularText}\nTEST\n\t\r    ";
        }
    }
}
