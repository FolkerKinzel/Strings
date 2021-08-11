using System;
using System.Collections.Generic;
using System.Text;

namespace FolkerKinzel.Strings
{
    public static partial class StringBuilderExtension
    {
        /// <summary>
        /// Gibt den NULL-basierten Index des letzten Vorkommens des angegebenen Zeichens in <paramref name="builder"/> an.
        /// </summary>
        /// <param name="builder">Der zu durchsuchende <see cref="StringBuilder"/>.</param>
        /// <param name="value">Das zu suchende Unicode-Zeichen.</param>
        /// <returns>Die nullbasierte Indexposition des letzten Vorkommens von <paramref name="value"/>,
        /// wenn dieses Zeichen gefunden wurde, andernfalls -1.</returns>
        /// <remarks>
        /// Die Methode führt einen Ordinalzeichenvergleich durch.
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        public static int LastIndexOf(this StringBuilder builder, char value)
            => builder is null
                    ? throw new ArgumentNullException(nameof(builder))
                    : builder.LastIndexOf(value, builder.Length - 1, builder.Length);

        /// <summary>
        /// Gibt den NULL-basierten Index des letzten Vorkommens des angegebenen Zeichens in <paramref name="builder"/> an. 
        /// Die Suche beginnt an einer angegebenen Zeichenposition und verläuft
        /// rückwärts zum Anfang des <see cref="StringBuilder"/>s.
        /// </summary>
        /// <param name="builder">Der zu durchsuchende <see cref="StringBuilder"/>.</param>
        /// <param name="value">Das zu suchende Unicode-Zeichen.</param>
        /// <param name="startIndex">Die Anfangsposition der Suche. Die Suche erfolgt rückwärts zum Anfang 
        /// von <paramref name="builder"/>.</param>
        /// <returns>Die nullbasierte Indexposition des letzten Vorkommens von <paramref name="value"/>,
        /// wenn dieses Zeichen gefunden wurde, andernfalls -1.</returns>
        /// <remarks>
        /// Die Methode führt einen Ordinalzeichenvergleich durch.
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="builder"/> ist nicht leer und 
        /// <paramref name="startIndex"/> ist kleiner als 0 oder größer 
        /// oder gleich der Länge von <paramref name="builder"/>.</exception>
        public static int LastIndexOf(this StringBuilder builder, char value, int startIndex)
            => builder is null
                ? throw new ArgumentNullException(nameof(builder))
                : builder.LastIndexOf(value, startIndex, startIndex + 1);


        /// <summary>
        /// Gibt den NULL-basierten Index des letzten Vorkommens des angegebenen Zeichens in <paramref name="builder"/> an. 
        /// Die Suche beginnt an einer angegebenen Zeichenposition und verläuft für eine angegebene Anzahl von Zeichenpositionen 
        /// rückwärts zum Anfang des <see cref="StringBuilder"/>s.
        /// </summary>
        /// <param name="builder">Der zu durchsuchende <see cref="StringBuilder"/>.</param>
        /// <param name="value">Das zu suchende Unicode-Zeichen.</param>
        /// <param name="startIndex">Die Anfangsposition der Suche. Die Suche erfolgt rückwärts zum Anfang 
        /// von <paramref name="builder"/>.</param>
        /// <param name="count">Die Anzahl der zu überprüfenden Zeichenpositionen.</param>
        /// <returns>Die nullbasierte Indexposition des letzten Vorkommens von <paramref name="value"/>,
        /// innerhalb des zu durchsuchenden Abschnitts wenn dieses Zeichen gefunden wurde, andernfalls -1.</returns>
        /// <remarks>
        /// Die Methode führt einen Ordinalzeichenvergleich durch.
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>
        /// <paramref name="builder"/> ist nicht leer und <paramref name="startIndex"/> ist kleiner als 0 oder größer 
        /// oder gleich der Länge von <paramref name="builder"/>
        /// </para>
        /// <para>
        /// - oder -
        /// </para>
        /// <para>
        /// <paramref name="builder"/> ist nicht leer und <paramref name="startIndex"/> - <paramref name="count"/> + 1 
        /// ist kleiner als 0.
        /// </para></exception>
        public static int LastIndexOf(this StringBuilder builder, char value, int startIndex, int count)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (builder.Length == 0 || count == 0)
            {
                return -1;
            }

            if (startIndex < 0 || startIndex >= builder.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            int lastSearchIndex = startIndex - count + 1;
            if (count < 0 || lastSearchIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            for (int i = startIndex; i >= lastSearchIndex; i--)
            {
                if (value == builder[i])
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
