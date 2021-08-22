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
        /// Untersucht, ob der <see cref="string"/> Unicode-Zeichen enthält,
        /// die nicht zum ASCII-Zeichensatz gehören.
        /// </summary>
        /// <param name="s">Der zu durchsuchende <see cref="string"/> oder <c>null</c>.</param>
        /// <returns><c>false</c>, wenn <paramref name="s"/> ein Unicode-Zeichen enthält, das nicht zum 
        /// ASCII-Zeichensatz gehört, andernfalls <c>true</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAscii(this string? s) => s.AsSpan().IsAscii();

    }
}
