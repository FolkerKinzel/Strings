using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using FolkerKinzel.Strings.Properties;

namespace FolkerKinzel.Strings
{
    public static partial class ReadOnlySpanExtension
    {
        /// <summary>
        /// Gibt an, ob eine schreibgeschützte Zeichenspanne mit dem angegebenen
        /// Unicode-Zeichen endet.
        /// </summary>
        /// <param name="span">Die zu untersuchende Spanne.</param>
        /// <param name="value">Das Zeichen, nach dem gesucht wird.</param>
        /// <returns><c>true</c>, wenn <paramref name="span"/> mit <paramref name="value"/>
        /// endet, andernfalls <c>false</c>.</returns>
        /// <remarks>
        /// Die Methode führt einen Ordinalzeichenvergleich durch.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EndsWith(this ReadOnlySpan<char> span, char value)
         => !span.IsEmpty && span[span.Length - 1] == value;


    }
}
