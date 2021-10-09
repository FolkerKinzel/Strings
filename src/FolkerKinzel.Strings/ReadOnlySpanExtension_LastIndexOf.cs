using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings
{
    public static partial class ReadOnlySpanExtension
    {
        /// <summary>
        /// Gibt die NULL-basierte Indexposition des letzten Vorkommens einer angegebenen Zeichenfolge in dieser Instanz an. Die Suche beginnt an einer angegebenen Zeichenposition 
        /// und verläuft für eine angegebene Anzahl von Zeichenpositionen rückwärts zum Anfang der Zeichenfolge. Ein Parameter gibt den Typ des bei der Suche nach der angegebenen 
        /// Zeichenfolge auszuführenden Vergleichs an.
        /// </summary>
        /// <param name="span">Die zu durchsuchende Zeichenspanne.</param>
        /// <param name="value">Die zu suchende Zeichenspanne.</param>
        /// <param name="startIndex">Die Anfangsposition der Suche. Die Suche wird von <paramref name="startIndex"/> bis zum Anfang von <paramref name="span"/> fortgesetzt.</param>
        /// <param name="count">Die Anzahl der zu überprüfenden Zeichenpositionen.</param>
        /// <param name="comparisonType">Einer der Enumerationswerte, der die Regeln für die Suche angibt.</param>
        /// <returns>Die nullbasierte Anfangsindexposition des <paramref name="value"/>-Parameters, wenn diese Zeichenfolge gefunden wurde, oder -1, wenn sie nicht 
        /// gefunden wurde oder <paramref name="span"/> leer ist.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>
        /// <paramref name="count"/> ist ein negativer Wert
        /// </para>
        /// <para>
        /// - oder -
        /// </para>
        /// <para>
        /// <paramref name="span"/> ist nicht <see cref="ReadOnlySpan{T}.Empty"/>, und <paramref name="startIndex"/> ist ein negativer Wert.
        /// </para>
        /// <para>
        /// - oder -
        /// </para>
        /// <para>
        /// <paramref name="span"/> ist nicht <see cref="ReadOnlySpan{T}.Empty"/>, und <paramref name="startIndex"/> ist größer als die Länge von <paramref name="span"/>.
        /// </para>
        /// <para>
        /// - oder -
        /// </para>
        /// <para>
        /// <paramref name="span"/> ist nicht <see cref="ReadOnlySpan{T}.Empty"/>, und <paramref name="startIndex"/> + 1 - <paramref name="count"/> gibt eine Position an, 
        /// die nicht innerhalb von <paramref name="span"/> liegt.
        /// </para>
        /// <para>
        /// - oder -
        /// </para>
        /// <para>
        /// <paramref name="span"/> ist <see cref="ReadOnlySpan{T}.Empty"/>, und <paramref name="startIndex"/> ist kleiner als -1 oder größer als 0 (null).
        /// </para>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="comparisonType"/> ist kein gültiger <see cref="StringComparison"/>-Wert.
        /// </exception>
        public static int LastIndexOf(this ReadOnlySpan<char> span, ReadOnlySpan<char> value, int startIndex, int count, StringComparison comparisonType)
        {
TryAgain:

            if ((uint)startIndex >= (uint)span.Length)
            {
                if (startIndex == -1 && span.Length == 0)
                {
                    count = 0; // normalize
                }
                else if (startIndex == span.Length)
                {
                    // The caller likely had an off-by-one error when invoking the API. The Framework has historically
                    // allowed for this and tried to fix up the parameters, so we'll continue to do so for compat.

                    startIndex--;
                    if (count > 0)
                    {
                        count--;
                    }

                    goto TryAgain; // guaranteed never to loop more than once
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(startIndex));
                }
            }

            startIndex = startIndex - count + 1;

            int matchIndex = span.Slice(startIndex, count).LastIndexOf(value, comparisonType);
            return matchIndex == -1 ? -1 : matchIndex + startIndex;
        }


    }
}
