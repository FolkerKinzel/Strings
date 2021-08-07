﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FolkerKinzel.Strings
{
    public static partial class StringBuilderExtension
    {
        /// <summary>
        /// Gibt an, ob ein angegebenes Zeichen im <see cref="StringBuilder"/> vorkommt.
        /// </summary>
        /// <param name="builder">Der zu durchsuchende <see cref="StringBuilder"/>.</param>
        /// <param name="value">Das zu suchende Zeichen.</param>
        /// <returns><c>true</c>, wenn <paramref name="value"/> in <paramref name="builder"/>
        /// gefunden wird, anderenfalls <c>false</c>.</returns>
        /// <remarks>
        /// Die Methode verwendet <see cref="char.Equals(char)"/> für den Vergleich.
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
        public static bool Contains(this StringBuilder builder, char value)
            => builder is null ? throw new ArgumentNullException(nameof(builder)) : builder.IndexOf(value) != -1;

    }
}