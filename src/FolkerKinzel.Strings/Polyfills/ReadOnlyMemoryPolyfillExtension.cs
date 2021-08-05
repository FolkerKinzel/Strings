using System;
using System.Collections.Generic;
using System.Text;

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
        /// Entfernt alle führenden und nachfolgenden Leerzeichen aus einem schreibgeschützten Zeichenspeicherbereich.
        /// </summary>
        /// <param name="memory">Der Quellspeicher, aus dem die Zeichen entfernt werden.</param>
        /// <returns>Der zugeschnittene Zeichenspeicherbereich.</returns>
        public static ReadOnlyMemory<char> Trim(this ReadOnlyMemory<char> memory)
        {
            ReadOnlySpan<char> span = memory.Span;
            int start = span.GetTrimmedStart();
            int length = span.Slice(start).GetTrimmedLength();
            return memory.Slice(start, length);
        }
 
        /// <summary>
        /// Entfernt alle führenden Leerzeichen aus einem schreibgeschützten Speicherbereich.
        /// </summary>
        /// <param name="memory">Der Quellspeicher, aus dem die Zeichen entfernt werden.</param>
        /// <returns>Der zugeschnittene Zeichenspeicherbereich.</returns>
        public static ReadOnlyMemory<char> TrimStart(this ReadOnlyMemory<char> memory)
            => memory.Slice(memory.Span.GetTrimmedStart());
 
        /// <summary>
        /// Entfernt alle nachfolgenden Leerzeichen aus einem schreibgeschützten Zeichenspeicherbereich.
        /// </summary>
        /// <param name="memory">Der Quellspeicher, aus dem die Zeichen entfernt werden.</param>
        /// <returns>Der zugeschnittene Zeichenspeicherbereich.</returns>
        public static ReadOnlyMemory<char> TrimEnd(this ReadOnlyMemory<char> memory)
            => memory.Slice(0, memory.Span.GetTrimmedLength());

        #endif
    }
}
