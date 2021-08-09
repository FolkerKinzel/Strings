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
        // Avoid overloads which pass the span around: This is for performance!

        /// <summary>
        /// Sucht nach dem NULL-basierten Index des ersten Vorkommens eines beliebigen Zeichens aus einer
        /// schreibgeschützten Zeichenspanne in <paramref name="s"/>. Die Suche beginnt an einer angegebenen 
        /// Zeichenposition, und es wird eine angegebene Anzahl von Zeichenpositionen überprüft.
        /// </summary>
        /// <param name="s">Der zu durchsuchende <see cref="string"/>.</param>
        /// <param name="anyOf">Eine schreibgeschützte Zeichenspanne, die die zu suchenden Zeichen enthält.</param>
        /// <param name="startIndex">Der NULL-basierte Index in <paramref name="s"/>, an dem die Suche beginnt.</param>
        /// <param name="count">Die Anzahl der in <paramref name="s"/> zu überprüfenden Zeichen.</param>
        /// <returns>Der NULL-basierte Index des ersten Vorkommens eines beliebigen Zeichens aus <paramref name="anyOf"/>
        /// in <paramref name="s"/> oder -1, wenn keines dieser Zeichen gefunden wurde.</returns>
        /// <remarks>
        /// Wenn die Länge von <paramref name="anyOf"/> kleiner als 5 ist, verwendet die Methode für den Vergleich 
        /// MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;). Ist die Länge von <paramref name="anyOf"/>
        /// größer, wird <see cref="string.IndexOfAny(char[])"/> verwendet.
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="s"/> ist <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>
        /// <paramref name="startIndex"/> oder <paramref name="count"/> sind kleiner als 0
        /// </para>
        /// <para>
        /// - oder -
        /// </para>
        /// <para>
        /// <paramref name="startIndex"/> + <paramref name="count"/> ist größer als die Anzahl der Zeichen in
        /// <paramref name="s"/>.
        /// </para>
        /// </exception>
        public static int IndexOfAny(this string s, ReadOnlySpan<char> anyOf, int startIndex, int count)
            => s is null
                ? throw new ArgumentNullException(nameof(s))
                : count == 0
                    ? -1
                    : anyOf.Length <= 5
                        ? s.AsSpan(startIndex, count).IndexOfAny(anyOf)
                        : s.IndexOfAny(anyOf.ToArray(), startIndex, count);

    }
}
