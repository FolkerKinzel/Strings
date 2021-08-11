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
        /// Gibt an, ob das angegebene Unicode-Zeichen zum ASCII-Zeichensatz gehört.
        /// </summary>
        /// <param name="c">Das zu überprüfende Unicode-Zeichen.</param>
        /// <returns><c>true</c> wenn <paramref name="c"/> ein Zeichen des ASCII-Zeichensatzes ist,
        /// anderenfalls <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAscii(this char c) => 128u > c;
    }
}
