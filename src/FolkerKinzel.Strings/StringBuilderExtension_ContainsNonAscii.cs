using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using FolkerKinzel.Strings.Properties;
using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings
{
    public static partial class StringBuilderExtension
    {
        /// <summary>
        /// Untersucht, ob der <see cref="StringBuilder"/> Unicode-Zeichen enthält,
        /// die nicht zum ASCII-Zeichensatz gehören.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt untersucht wird.</param>
        /// <returns><c>true</c>, wenn <paramref name="builder"/> ein Unicode-Zeichen enthält, das nicht zum 
        /// ASCII-Zeichensatz gehört, anderenfalls <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        public static bool ContainsNonAscii(this StringBuilder builder)
            => builder is null
                    ? throw new ArgumentNullException(nameof(builder)) 
                    : builder.ContainsNonAscii(0, builder.Length);


        /// <summary>
        /// Untersucht einen Abschnitt des <see cref="StringBuilder"/>s, der bei <paramref name="startIndex"/> beginnt,
        /// daraufhin, ob er Unicode-Zeichen enthält,
        /// die nicht zum ASCII-Zeichensatz gehören.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt untersucht wird.</param>
        /// <param name="startIndex">Der nullbasierte Index in <paramref name="builder"/>, an dem die Untersuchung
        /// beginnt.</param>
        /// <returns><c>true</c>, wenn der Abschnitt in <paramref name="builder"/> ein Unicode-Zeichen enthält, das nicht zum 
        /// ASCII-Zeichensatz gehört, anderenfalls <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/> ist kleiner als 0 oder
        /// größer als die Anzahl der Zeichen in <paramref name="builder"/>.</exception>
        public static bool ContainsNonAscii(this StringBuilder builder, int startIndex)
            => builder is null
                ? throw new ArgumentNullException(nameof(builder))
                : builder.ContainsNonAscii(startIndex, builder.Length - startIndex);


        /// <summary>
        /// Untersucht einen Abschnitt des <see cref="StringBuilder"/>s, der bei <paramref name="startIndex"/> beginnt und
        /// <paramref name="count"/> Zeichen umfasst, daraufhin, ob dieser Abschnitt Unicode-Zeichen enthält,
        /// die nicht zum ASCII-Zeichensatz gehören.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt untersucht wird.</param>
        /// <param name="startIndex">Der nullbasierte Index in <paramref name="builder"/>, an dem die Untersuchung
        /// beginnt.</param>
        /// <param name="count">Die Länge des zu untersuchenden Abschnitts.</param>
        /// <returns><c>true</c>, wenn der Abschnitt in <paramref name="builder"/> ein Unicode-Zeichen enthält, das nicht zum 
        /// ASCII-Zeichensatz gehört, anderenfalls <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>
        /// <paramref name="startIndex"/> oder <paramref name="count"/> sind kleiner als 0 oder
        /// größer als die Anzahl der Zeichen in <paramref name="builder"/>.
        /// </para>
        /// <para>
        /// - oder -
        /// </para>
        /// <para>
        /// <paramref name="startIndex"/> + <paramref name="count"/> ist größer als die Anzahl der Zeichen in
        /// <paramref name="builder"/>.
        /// </para></exception>
        public static bool ContainsNonAscii(this StringBuilder builder, int startIndex, int count)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (startIndex < 0 || startIndex > builder.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (count < 0 || (count += startIndex) > builder.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            for (int i = startIndex; i < count; ++i)
            {
                if (!builder[i].IsAscii())
                {
                    return true;
                }
            }
            return false;
        }


    }
}
