using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using FolkerKinzel.Strings.Properties;
using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings
{
    /// <summary>
    /// Erweiterungsmethoden für die <see cref="string"/>-Klasse.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    public static partial class StringExtension
    {
        /// <summary>
        /// Erzeugt einen <see cref="string"/>, aus dem alle führenden Vorkommen der Zeichen in der angegebenen Spanne entfernt sind.
        /// </summary>
        /// <param name="s">Die zu untersuchende Zeichenfolge.</param>
        /// <param name="trimChars">Eine Spanne mit den zu entfernenden Unicode-Zeichen. Wenn <paramref name="trimChars"/> eine leere Spanne ist,
        /// werden stattdessen Leerzeichen entfernt.</param>
        /// <returns>Die resultierende Zeichenfolge, nachdem alle im <paramref name="trimChars"/>-Parameter übergebenen Zeichen am Anfang der 
        /// Zeichenfolge entfernt wurden. </returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> ist <c>null</c>.</exception>
        public static string TrimStart(this string s, ReadOnlySpan<char> trimChars)
        {
            if (s is null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            if (trimChars.Length == 0)
            {
                return s.TrimStart();
            }

            ReadOnlySpan<char> span = s.AsSpan().DoTrimStart(trimChars);

            return span.Length == s.Length
                ? s
                : span.Length == 0
                    ? string.Empty
                    : span.ToString();
        }

        private static ReadOnlySpan<char> DoTrimStart(this ReadOnlySpan<char> span, ReadOnlySpan<char> trimChars)
        {
            int length = span.Length;

            for (int j = 0; j < length; j++)
            {
                if (trimChars.Contains(span[j]))
                {
                    continue;
                }
                else
                {
                    return span.Slice(j);
                }
            }

            return ReadOnlySpan<char>.Empty;
        }
    }
}
