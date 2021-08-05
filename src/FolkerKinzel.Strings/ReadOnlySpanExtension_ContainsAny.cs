using System;
using System.Collections.Generic;
using System.Text;
using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings
{
    public static partial class ReadOnlySpanExtension
    {
        /// <summary>
        /// Gibt an, ob in einer schreibgeschüzten Zeichenspanne eines der Zeichen vorkommt,
        /// die der Methode in einer anderen schreibgeschützten Zeichenspanne übergeben werden.
        /// </summary>
        /// <param name="span">Die zu untersuchende Spanne.</param>
        /// <param name="chars">Eine schreibgeschützte Zeichenspanne, die die zu suchenden Zeichen enthält.</param>
        /// <returns><c>true</c>, wenn in <paramref name="span"/> eines der in <paramref name="chars"/> enthaltenen
        /// Zeichen vorkommt. Wenn <paramref name="span"/> oder <paramref name="chars"/> leere Spannen sind,
        /// wird <c>false</c> zurückgegeben.</returns>
        /// <remarks>
        /// Die Methode verwendet für den Vergleich <see cref="char.Equals(char)"/>.
        /// </remarks>
        public static bool ContainsAny(this ReadOnlySpan<char> span, ReadOnlySpan<char> chars)
        {
            for (int i = 0; i < chars.Length; i++)
            {
                if (span.Contains(chars[i]))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
