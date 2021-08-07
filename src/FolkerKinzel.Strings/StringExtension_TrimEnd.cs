using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using FolkerKinzel.Strings.Properties;
using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings
{
    public static partial class StringExtension
    {
        /// <summary>
        /// Erzeugt einen <see cref="string"/>, aus dem alle nachgestellten Vorkommen der Zeichen in der angegebenen Spanne entfernt sind.
        /// </summary>
        /// <param name="s">Die zu untersuchende Zeichenfolge.</param>
        /// <param name="trimChars">Eine Spanne mit den zu entfernenden Unicode-Zeichen. Wenn <paramref name="trimChars"/> eine leere Spanne ist,
        /// werden stattdessen Leerzeichen entfernt.</param>
        /// <returns>Die resultierende Zeichenfolge, nachdem alle im <paramref name="trimChars"/>-Parameter übergebenen Zeichen am Ende der 
        /// Zeichenfolge entfernt wurden. </returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> ist <c>null</c>.</exception>
        public static string TrimEnd(this string s, ReadOnlySpan<char> trimChars)
        {
            if (s is null)
            {
                throw new ArgumentNullException(nameof(s));
            }
            if (trimChars.Length == 0)
            {
                return s.TrimEnd();
            }

            ReadOnlySpan<char> span = s.AsSpan().DoTrimEnd(trimChars);

            return span.Length == s.Length
                ? s
                : span.Length == 0
                    ? string.Empty
                    : span.ToString();
        }

        private static ReadOnlySpan<char> DoTrimEnd(this ReadOnlySpan<char> span, ReadOnlySpan<char> trimChars)
        {
            int length = span.Length;

            for (int i = length - 1; i >= 0; i--)
            {
                if (trimChars.Contains(span[i]))
                {
                    --length;  
                }
                else
                {
                    break;
                }
            }

            return span.Slice(0, length);
        }
        

    }
}
