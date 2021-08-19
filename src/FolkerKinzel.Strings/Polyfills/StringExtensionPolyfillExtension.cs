using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FolkerKinzel.Strings.Polyfills
{
    /// <summary>
    /// Erweiterungsmethoden, die als Polyfills für die Erweiterungsmethoden der Klasse <see cref="StringExtension"/>
    /// dienen.
    /// </summary>
    public static class StringExtensionPolyfillExtension
    {
#if NET45 || NETSTANDARD2_0
        /// <summary>
        /// Erzeugt einen neuen <see cref="string"/>, in dem alle Sequenzen von Leerzeichen in <paramref name="s"/> durch 
        /// <paramref name="replacement"/> ersetzt sind.
        /// </summary>
        /// <param name="builder">Der Quell-<see cref="string"/>.</param>
        /// <param name="replacement">Ein <see cref="string"/>, durch den Inhalt die Leerraumzeichen-Sequenzen
        /// ersetzt werden, oder <c>null</c>, um alle Leerzeichen zu entfernen.</param>
        /// <returns>Ein neuer <see cref="string"/>, in in dem alle Sequenzen von Leerzeichen in <paramref name="s"/> durch 
        /// <paramref name="replacement"/> ersetzt sind. Wenn <paramref name="s"/> kein Leerzeichen enthält, wird <paramref name="s"/>
        /// zurückgegeben.</returns>
        /// <remarks>
        /// <para>
        /// Die Methode verwendet <see cref="char.IsWhiteSpace(char)"/> zur Identifizierung von Leerraumzeichen und arbeitet
        /// damit gründlicher als 
        /// <see cref="Regex.Replace(string, string, string)">Regex.Replace(string input, @"\s+", string replacement)</see>.
        /// </para>
        /// <para>
        /// Diese Überladung ist nützlich, da die implizite Umwandlung von <see cref="string"/> in 
        /// <see cref="ReadOnlySpan{T}">ReadOnlySpan&lt;Char&gt;</see> erst ab .NET Standard 2.1 unterstützt wird.
        /// </para>
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        public static string ReplaceWhiteSpaceWith(
            this string s,
            string? replacement)
            => s.ReplaceWhiteSpaceWith(replacement.AsSpan());
#endif
    }
}
