using System;
using System.Collections.Generic;
using System.Text;
using FolkerKinzel.Strings.Polyfills;
using System.Text.RegularExpressions;

namespace FolkerKinzel.Strings
{
    public static partial class StringExtension
    {
        /// <summary>
        /// Erzeugt einen neuen <see cref="string"/>, in dem alle Sequenzen von Leerzeichen in <paramref name="s"/> durch 
        /// <paramref name="replacement"/> ersetzt sind.
        /// </summary>
        /// <param name="builder">Der Quell-<see cref="string"/>.</param>
        /// <param name="replacement">Eine schreibgeschützte Zeichenspanne, durch deren Inhalt die Leerzeichen-Sequenzen
        /// ersetzt werden.</param>
        /// <returns>Ein neuer <see cref="string"/>, in in dem alle Sequenzen von Leerzeichen in <paramref name="s"/> durch 
        /// <paramref name="replacement"/> ersetzt sind. Wenn <paramref name="s"/> kein Leerzeichen enthält, wird <paramref name="s"/>
        /// zurückgegeben.</returns>
        /// <remarks>
        /// Die Methode verwendet <see cref="char.IsWhiteSpace(char)"/> zur Identifizierung von Leerraumzeichen und arbeitet
        /// damit gründlicher als 
        /// <see cref="Regex.Replace(string, string, string)">Regex.Replace(string input, @"\s+", string replacement)</see>.
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        public static string ReplaceWhiteSpaceWith(
            this string s,
            ReadOnlySpan<char> replacement)
        {
            if (s is null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            if(!s.ContainsWhiteSpace())
            {
                return s;
            }

            var sb = new StringBuilder(s.Length + s.Length / 2);
            return sb.Append(s).ReplaceWhiteSpaceWith(replacement).ToString();
        }
        


    }
}
