﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FolkerKinzel.Strings
{
    public static partial class StringExtension
    {
        /// <summary>
        /// Gibt an, ob der <see cref="string"/> ein Zeilenwechselzeichen enthält.
        /// </summary>
        /// <param name="s">Der zu durchsuchende <see cref="string"/> oder <c>null</c>.</param>
        /// <returns><c>true</c>, wenn <paramref name="s"/> ein Leerraumzeichen enthält, andernfalls <c>false</c>.</returns>
        /// <remarks>Für den Vergleich wird <see cref="CharExtension.IsNewLine(char)"/> verwendet.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsNewLine(this string? s)
            => s.AsSpan().ContainsNewLine();
    }
}