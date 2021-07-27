using System;
using System.Collections.Generic;
using System.Text;
using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings.Polyfills
{
    /// <summary>
    /// Erweiterungsmethoden für die <see cref="ReadOnlyMemory{T}">ReadOnlyMemory&lt;Char&gt;</see>-Struktur, die in .NET Framework 4.5, .NET Standard 2.0 
    /// und .NET Standard 2.1 als
    /// Polyfills für Methoden aus aktuellen .NET-Versionen dienen.
    /// </summary>
    /// <remarks>
    /// Die Methoden dieser Klasse sollten ausschließlich in der Erweiterungsmethodensyntax verwendet zu werden, um die 
    /// in moderneren Frameworks vorhandenen Originalmethoden der<see cref="ReadOnlyMemory{T}">ReadOnlyMemory&lt;Char&gt;</see>-Struktur zu simulieren.
    /// </remarks>
    public static class ReadOnlyMemoryPolyfillExtension
    {
        # if NET45 || NETSTANDARD2_0 || NETSTANDARD2_1  

        /// <summary>
        /// Entfernt alle führenden und nachgestellten Leerraumzeichen aus dem <see cref="ReadOnlyMemory{T}">ReadOnlyMemory&lt;Char&gt;</see>.
        /// </summary>
        /// <param name="memory">Der <see cref="ReadOnlyMemory{T}">ReadOnlyMemory&lt;Char&gt;</see> aus dem die Zeichen entfernt werden.</param>
        public static ReadOnlyMemory<char> Trim(this ReadOnlyMemory<char> memory)
        {
            ReadOnlySpan<char> span = memory.Span;
            int start = span.ClampStart();
            int length = span.ClampEnd(start);
            return memory.Slice(start, length);
        }
 
        /// <summary>
        /// Entfernt alle führenden Leerraumzeichen aus dem <see cref="ReadOnlyMemory{T}">ReadOnlyMemory&lt;Char&gt;</see>.
        /// </summary>
        /// <param name="memory">Der <see cref="ReadOnlyMemory{T}">ReadOnlyMemory&lt;Char&gt;</see> aus dem die Zeichen entfernt werden.</param>
        public static ReadOnlyMemory<char> TrimStart(this ReadOnlyMemory<char> memory)
            => memory.Slice(memory.Span.ClampStart());
 
        /// <summary>
        /// Entfernt alle nachgestellten Leerraumzeichen aus dem <see cref="ReadOnlyMemory{T}">ReadOnlyMemory&lt;Char&gt;</see>.
        /// </summary>
        /// <param name="memory">Der <see cref="ReadOnlyMemory{T}">ReadOnlyMemory&lt;Char&gt;</see> aus dem die Zeichen entfernt werden.</param>
        public static ReadOnlyMemory<char> TrimEnd(this ReadOnlyMemory<char> memory)
            => memory.Slice(0, memory.Span.ClampEnd(0));

        #endif
    }
}
