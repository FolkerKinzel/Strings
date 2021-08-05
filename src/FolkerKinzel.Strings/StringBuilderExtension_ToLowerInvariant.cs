﻿using System;
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
        ///// <summary>
        ///// Converts the whole content of a <see cref="StringBuilder"/> to lower case using the rules
        ///// of the invariant culture.
        ///// </summary>
        ///// <param name="builder">The <see cref="StringBuilder"/> whose content is modified.</param>
        ///// <returns>A reference to <paramref name="builder"/>.</returns>
        ///// <exception cref="ArgumentNullException"><paramref name="builder"/> is <c>null</c>.</exception>
        
        /// <summary>
        /// Wandelt den gesamten Inhalt eines <see cref="StringBuilder"/>s in Kleinbuchstaben um und verwendet
        /// dabei die Regeln der invarianten Kultur.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt bearbeitet wird.</param>
        /// <returns>Eine Referenz auf <paramref name="builder"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        public static StringBuilder ToLowerInvariant(this StringBuilder builder)
            => builder is null ? throw new ArgumentNullException(nameof(builder))
                               : builder.ToLowerInvariant(0, builder.Length);

        ///// <summary>
        ///// Converts the content of a <see cref="StringBuilder"/> beginning at <paramref name="startIndex"/>
        ///// to lower case using the rules of the invariant culture.
        ///// </summary>
        ///// <param name="builder">The <see cref="StringBuilder"/> whose content is modified.</param>
        ///// <param name="startIndex">The zero-based index in <paramref name="builder"/> where the conversion
        ///// starts.</param>
        ///// <returns>A reference to <paramref name="builder"/>.</returns>
        ///// <exception cref="ArgumentNullException"><paramref name="builder"/> is <c>null</c>.</exception>
        
        /// <summary>
        /// Wandelt den Inhalt eines <see cref="StringBuilder"/>s beginnend bei <paramref name="startIndex"/>
        /// in Kleinbuchstaben um und verwendet
        /// dabei die Regeln der invarianten Kultur.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt bearbeitet wird.</param>
        /// <param name="startIndex">Der nullbasierte Index in <paramref name="builder"/>, an dem die Umwandlung
        /// beginnt.</param>
        /// <returns>Eine Referenz auf <paramref name="builder"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/> ist kleiner als 0 oder
        /// größer als die Anzahl der Zeichen in <paramref name="builder"/>.</exception>
        public static StringBuilder ToLowerInvariant(this StringBuilder builder, int startIndex)
            => builder is null ? throw new ArgumentNullException(nameof(builder))
                               : builder.ToLowerInvariant(startIndex, builder.Length - startIndex);

        ///// <summary>
        ///// Converts a range of chars in a <see cref="StringBuilder"/>, which begins at <paramref name="startIndex"/>
        ///// and has the length of <paramref name="count"/> characters, to lower case using the rules of the invariant culture.
        ///// </summary>
        ///// <param name="builder">The <see cref="StringBuilder"/> whose content is modified.</param>
        ///// <param name="startIndex">The zero-based index in <paramref name="builder"/> where the conversion
        ///// starts.</param>
        ///// <param name="count">The number of <see cref="char"/>s to convert.</param>
        ///// <returns>A reference to <paramref name="builder"/>.</returns>
        ///// <exception cref="ArgumentNullException"><paramref name="builder"/> is <c>null</c>.</exception>
        
        /// <summary>
        /// Wandelt den Inhalt eines Abschnitts in <see cref="StringBuilder"/>, der bei <paramref name="startIndex"/>
        /// beginnt und <paramref name="length"/> Zeichen umfasst, in Kleinbuchstaben um und verwendet
        /// dabei die Regeln der invarianten Kultur.
        /// </summary>
        /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt bearbeitet wird.</param>
        /// <param name="startIndex">Der nullbasierte Index in <paramref name="builder"/>, an dem die Umwandlung
        /// beginnt.</param>
        /// <param name="length">Die Anzahl der zu bearbeitenden Zeichen.</param>
        /// <returns>Eine Referenz auf <paramref name="builder"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>
        /// <paramref name="startIndex"/> oder <paramref name="length"/> sind kleiner als 0 oder
        /// größer als die Anzahl der Zeichen in <paramref name="builder"/>.
        /// </para>
        /// <para>
        /// - oder -
        /// </para>
        /// <para>
        /// <paramref name="startIndex"/> + <paramref name="length"/> ist größer als die Anzahl der Zeichen in
        /// <paramref name="builder"/>.
        /// </para></exception>
        public static StringBuilder ToLowerInvariant(this StringBuilder builder, int startIndex, int length)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (startIndex < 0 || startIndex > builder.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (length < 0 || (length += startIndex) > builder.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            for (int i = startIndex; i < length; i++)
            {
                char current = builder[i];
                builder[i] = char.ToLowerInvariant(current);
            }

            return builder;
        }



    }
}