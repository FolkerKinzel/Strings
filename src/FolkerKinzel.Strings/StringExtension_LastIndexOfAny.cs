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
        /// Gibt die nullbasierte Indexposition des letzten Vorkommens eines der angegebenen Zeichen 
        /// in <paramref name="s"/> an. Die Suche beginnt an einer angegebenen Zeichenposition 
        /// und verläuft für eine angegebene Anzahl von Zeichenpositionen rückwärts zum Anfang der Zeichenfolge.
        /// </summary>
        /// <param name="s">Der zu durchsuchende <see cref="string"/>.</param>
        /// <param name="anyOf">Eine schreibgeschützte Zeichenspanne, die die zu suchenden Zeichen enthält.</param>
        /// <param name="startIndex">Die Anfangsposition der Suche. Die Suche erfolgt rückwärts zum Anfang 
        /// von <paramref name="s"/>.</param>
        /// <param name="count">Die Anzahl der zu überprüfenden Zeichenpositionen.</param>
        /// <returns>Der nullbasierte Index des letzten Vorkommens eines beliebigen Zeichens aus <paramref name="anyOf"/>
        /// in <paramref name="s"/> oder -1, wenn keines dieser Zeichen gefunden wurde.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> ist <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>
        /// <paramref name="s"/> ist nicht <see cref="string.Empty"/> und <paramref name="startIndex"/> ist kleiner als 0 oder größer 
        /// oder gleich der Länge von <paramref name="s"/>
        /// </para>
        /// <para>
        /// - oder -
        /// </para>
        /// <para>
        /// <paramref name="s"/> ist nicht <see cref="string.Empty"/> und <paramref name="startIndex"/> - <paramref name="count"/> + 1 
        /// ist kleiner als 0.
        /// </para>
        /// </exception>
        /// <remarks>
        /// Wenn die Länge von <paramref name="anyOf"/> kleiner als 5 ist, verwendet die Methode für den Vergleich 
        /// <see cref="MemoryExtensions.LastIndexOfAny{T}(ReadOnlySpan{T}, ReadOnlySpan{T})"/>. Ist die Länge von <paramref name="anyOf"/>
        /// größer, wird <see cref="string.LastIndexOfAny(char[])"/> verwendet.
        /// </remarks>
        public static int LastIndexOfAny(this string s, ReadOnlySpan<char> anyOf, int startIndex, int count)
        {
            if (s is null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            // string.LastIndexOfAny returns -1 if anyOf is an empty array (although MSDN says it would return 0).
            // MemoryExtensions.LastIndexOfAny returns 0 if the span with the characters to search for is empty.
            // This makes it consistent:
            if (count == 0 || anyOf.IsEmpty)
            {
                return -1;
            }

            if (anyOf.Length <= 5)
            {
                // MemoryExtensions.LastIndexOfAny throws ArgumentOutOfRangeExceptions even if s is ""
                // string.LastIndexOfAny does not.
                if(s.Length == 0)
                {
                    return -1;
                }
                int matchIndex = MemoryExtensions.LastIndexOfAny(s.AsSpan(startIndex - count + 1, count), anyOf);
                return matchIndex == -1 ? -1 : matchIndex + startIndex - count + 1;
            }

            return s.LastIndexOfAny(anyOf.ToArray(), startIndex, count);
        }
    }
}
