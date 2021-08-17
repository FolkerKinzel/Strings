﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FolkerKinzel.Strings
{
    public static partial class StringBuilderExtension
    {
        /// <summary>
        /// Gibt an, ob der Inhalt eines <see cref="StringBuilder"/>s mit dem angegebenen
        /// Unicode-Zeichen beginnt.
        /// </summary>
        /// <param name="builder">Der zu untersuchende <see cref="StringBuilder"/>.</param>
        /// <param name="value">Das Zeichen, nach dem gesucht wird.</param>
        /// <returns><c>true</c>, wenn <paramref name="builder"/> mit <paramref name="value"/>
        /// beginnt, andernfalls <c>false</c>.</returns>
        /// <remarks>
        /// Die Methode führt einen Ordinalzeichenvergleich durch.
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        public static bool StartsWith(this StringBuilder builder, char value)
         => builder is null ? throw new ArgumentNullException(nameof(builder))
                            : builder.Length != 0 && builder[0] == value;
    }
}
