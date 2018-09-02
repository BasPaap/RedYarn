using System;
using System.Collections.Generic;
using System.Text;

namespace Bas.RedYarn.Extensions
{
    static class StringExtensions
    {
        public static string Sanitize(this string originalString)
        {
            string[] invalidCharacters = new [] { "\0", "\a", "\b", "\f", "\n", "\r", "\t" };
            var stringBuilder = new StringBuilder(originalString);

            foreach (var invalidCharacter in invalidCharacters)
            {
                stringBuilder.Replace(invalidCharacter, string.Empty);
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
