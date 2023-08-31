namespace FolkerKinzel.Strings.Polyfills;

/// <summary>
/// Erweiterungsmethoden für die <see cref="Span{T}">Span&lt;Char&gt;</see>-Struktur, die in .NET Framework 4.5, .NET Standard 2.0 
/// und .NET Standard 2.1 als
/// Polyfills für Methoden aus aktuellen .NET-Versionen dienen.
/// </summary>
/// <remarks>
/// Die Methoden dieser Klasse sollten ausschließlich in der Erweiterungsmethodensyntax verwendet zu werden, um die 
/// in moderneren Frameworks vorhandenen Originalmethoden der<see cref="Span{T}">Span&lt;Char&gt;</see>-Struktur zu simulieren.
/// </remarks>
public static class SpanPolyfillExtension
{
    // Place this preprocessor directive inside the class to let .NET 6.0 and above have an empty class!
#if NET45 || NETSTANDARD2_0 || NETSTANDARD2_1
    /// <summary>
    /// Gibt an, ob ein angegebenes Unicodezeichen in der Spanne gefunden wird. 
    /// Zum Vergleich wird MemoryExtensions.IndexOf(this Span&lt;T&gt;, T) verwendet.
    /// </summary>
    /// <param name="span">Die zu durchsuchende Spanne.</param>
    /// <param name="value">Das zu suchende Unicodezeichen.</param>
    /// <returns><c>true</c>, wenn <paramref name="value"/> gefunden wurde, andernfalls <c>false</c>.</returns>
    /// <remarks>Verfügbar für .NET Framework 4.5, .NET Standard 2.0 und .NET Standard 2.1.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(this Span<char> span, char value)
        => span.IndexOf(value) != -1;
#endif
}
