using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FolkerKinzel.Strings
{
    /// <summary>
    /// Erweiterungsmethoden für die <see cref="char"/>-Struktur.
    /// </summary>
    public static class CharExtension
    {
        /// <summary>
        /// Gibt an, ob das Unicode-Zeichen zum ASCII-Zeichensatz gehört.
        /// </summary>
        /// <param name="c">Das zu überprüfende Unicode-Zeichen.</param>
        /// <returns><c>true</c> wenn <paramref name="c"/> ein Zeichen des ASCII-Zeichensatzes ist,
        /// anderenfalls <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAscii(this char c) => 128u > c;



        /// <summary>
        /// Gibt an, ob das Unicode-Zeichen eine Dezimalziffer (0-9) darstellt.
        /// </summary>
        /// <param name="c">Das zu überprüfende Unicode-Zeichen.</param>
        /// <returns><c>true</c>, wenn <paramref name="c"/> eine Dezimalziffer
        /// darstellt, anderenfalls <c>false</c>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0078:Musterabgleich verwenden", Justification = "<Ausstehend>")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsDecimalDigit(this char c) => 47u < c && 58u > c;
    }
}
