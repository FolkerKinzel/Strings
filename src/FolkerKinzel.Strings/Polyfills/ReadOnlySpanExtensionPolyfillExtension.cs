using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FolkerKinzel.Strings.Polyfills
{
   /// <summary>
   /// Erweiterungsmethoden, die als Polyfills für die Erweiterungsmethoden der Klasse <see cref="ReadOnlySpanExtension"/>
    /// dienen.
    /// </summary>
    /// <remarks>
    /// Die Polyfills sind verfügbar für .NET Framework 4.5 und .NET Standard 2.0.
    /// </remarks>
    public static class ReadOnlySpanExtensionPolyfillExtension
    {
        // Place this preprocessor directive inside the class to let .NET 5.0 have an empty class!
#if NET45 || NETSTANDARD2_0

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LastIndexOf(this ReadOnlySpan<char> span, string? value, int startIndex, int count, StringComparison comparisonType)
            => span.LastIndexOf(value.AsSpan(), startIndex, count, comparisonType);
        

#endif

    }
}
