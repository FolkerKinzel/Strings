using System.Runtime.CompilerServices;

namespace FolkerKinzel.Strings.Polyfills;


/// <summary>
/// Erweiterungsmethoden für die <see cref="ReadOnlySpan{T}">ReadOnlySpan&lt;Char&gt;</see>-Struktur, die in .NET Framework 4.5, .NET Standard 2.0 
/// und .NET Standard 2.1 als
/// Polyfills für Methoden aus aktuellen .NET-Versionen dienen.
/// </summary>
/// <remarks>
/// Die Methoden dieser Klasse sollten ausschließlich in der Erweiterungsmethodensyntax verwendet zu werden, um die 
/// in moderneren Frameworks vorhandenen Originalmethoden der<see cref="ReadOnlySpan{T}">ReadOnlySpan&lt;Char&gt;</see>-Struktur zu simulieren.
/// </remarks>
public static class ReadOnlySpanPolyfillExtension
{
    // Place this preprocessor directive inside the class to let .NET 6.0 and above have an empty class!
#if NET45 || NETSTANDARD2_0 || NETSTANDARD2_1
    /// <summary>
    /// Gibt an, ob ein angegebenes Unicodezeichen in der Spanne gefunden wird. 
    /// Zum Vergleich wird MemoryExtensions.IndexOf(this ReadOnlySpan&lt;T&gt;, T) verwendet.
    /// </summary>
    /// <param name="span">Die zu durchsuchende Spanne.</param>
    /// <param name="value">Das zu suchende Unicodezeichen.</param>
    /// <returns><c>true</c>, wenn <paramref name="value"/> gefunden wurde, andernfalls <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(this ReadOnlySpan<char> span, char value)
        => span.IndexOf(value) != -1;



    /// <summary>
    /// Gibt den NULL-basierten Index des letzten Vorkommens einer angegebenen Zeichenfolge in <paramref name="span"/> an. 
    /// Ein Parameter gibt den Typ der Suche für die angegebene Zeichenfolge an.
    /// </summary>
    /// <param name="span">Die zu durchsuchende Zeichenspanne.</param>
    /// <param name="value">Die zu suchende Zeichenfolge.</param>
    /// <param name="comparisonType">Einer der Enumerationswerte, der die Regeln für die Suche angibt.</param>
    /// <returns>Die nullbasierte Indexposition des <paramref name="value"/>-Parameters, wenn diese Zeichenfolge gefunden wurde, andernfalls -1.</returns>
    /// 
    /// <exception cref="ArgumentException"><paramref name="comparisonType"/> ist kein gültiger <see cref="StringComparison"/>-Wert.</exception>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0046:In bedingten Ausdruck konvertieren", Justification = "<Ausstehend>")]
    public static int LastIndexOf(this ReadOnlySpan<char> span, ReadOnlySpan<char> value, StringComparison comparisonType)
    {
        //if (value.IsEmpty)
        //{
        //    return span.Length;
        //}

        //if (comparisonType == StringComparison.Ordinal)
        //{
        //    return span.LastIndexOf(value);
        //}

        return span.ToString().LastIndexOf(value.ToString(), comparisonType);
    }
#endif


#if NET45 || NETSTANDARD2_0

    /// <summary>
    /// Bestimmt, ob dieser <paramref name="span"/> und der angegebene <paramref name="other"/>-<see cref="string"/> 
    /// dieselben Zeichen aufweisen, wenn sie mit der angegebenen <paramref name="comparisonType"/>-Option verglichen
    /// werden.
    /// </summary>
    /// <param name="span">Die Quellspanne.</param>
    /// <param name="other">Der Wert, der mit der Quellspanne verglichen werden soll.</param>
    /// <param name="comparisonType">Ein Enumerationswert, der bestimmt, wie <paramref name="span"/> und 
    /// <paramref name="other"/> verglichen werden.</param>
    /// <returns><c>true</c>, sofern identisch, andernfalls <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Equals(this ReadOnlySpan<char> span, string? other, StringComparison comparisonType) =>
        span.Equals(other.AsSpan(), comparisonType);


    /// <summary>
    /// Gibt an, ob ein angegebener Wert innerhalb einer schreibgeschützten Zeichenspanne auftritt.
    /// </summary>
    /// <param name="span">Die Quellspanne.</param>
    /// <param name="value">Der innerhalb der Quellspanne zu suchende Wert. <paramref name="value"/> darf <c>null</c> sein.</param>
    /// <param name="comparisonType">Ein Enumerationswert, der bestimmt, wie die Zeichen in <paramref name="span"/> und 
    /// <paramref name="value"/> verglichen werden.</param>
    /// <returns><c>true</c>, wenn <paramref name="value"/> innerhalb der Spanne auftritt, andernfalls <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(this ReadOnlySpan<char> span, string? value, StringComparison comparisonType)
        => span.Contains(value.AsSpan(), comparisonType);


    /// <summary>
    /// Gibt den NULL-basierten Index des letzten Vorkommens einer angegebenen Zeichenfolge in <paramref name="span"/> an. 
    /// Ein Parameter gibt den Typ der Suche für die angegebene Zeichenfolge an.
    /// </summary>
    /// <param name="span">Die zu durchsuchende Zeichenspanne.</param>
    /// <param name="value">Der zu suchende <see cref="string"/> oder <c>null</c>.</param>
    /// <param name="comparisonType">Einer der Enumerationswerte, der die Regeln für die Suche angibt.</param>
    /// <returns>Die nullbasierte Indexposition des <paramref name="value"/>-Parameters, wenn diese Zeichenfolge gefunden wurde, andernfalls -1.</returns>
    /// 
    /// <exception cref="ArgumentException"><paramref name="comparisonType"/> ist kein gültiger <see cref="StringComparison"/>-Wert.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOf(this ReadOnlySpan<char> span, string? value, StringComparison comparisonType)
        => span.LastIndexOf(value.AsSpan(), comparisonType);

    /// <summary>
    /// Bestimmt, ob eine schreibgeschützte Zeichenspanne mit einem angegebenen <see cref="string"/> beginnt.
    /// </summary>
    /// <param name="span">Die Quellspanne.</param>
    /// <param name="value">Der <see cref="string"/>, der mit dem Anfang der Quellspanne verglichen werden soll.</param>
    /// <returns><c>true</c>, wenn <paramref name="value"/> mit dem Anfang von <paramref name="span"/> übereinstimmt,
    /// andernfalls <c>false</c>.</returns>
    /// <remarks>
    /// Die Methode führt einen Ordinalzeichenvergleich durch. Wenn <paramref name="value"/>&#160;<c>null</c> oder <see cref="string.Empty"/> ist
    /// wird <c>true</c> zurückgegeben.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool StartsWith(this ReadOnlySpan<char> span, string? value)
        => span.StartsWith(value.AsSpan());

    /// <summary>
    /// Bestimmt, ob eine schreibgeschützte Zeichenspanne mit einem angegebenen <see cref="string"/> beginnt,
    /// wenn sie mit einem angegebenen <see cref="StringComparison"/> verglichen wird.
    /// </summary>
    /// <param name="span">Die Quellspanne.</param>
    /// <param name="value">Der <see cref="string"/>, der mit dem Anfang der Quellspanne verglichen werden soll.</param>
    /// <param name="comparisonType">Ein Enumerationswert, der bestimmt, wie <paramref name="span"/> und 
    /// <paramref name="value"/> verglichen werden.</param>
    /// <returns><c>true</c>, wenn <paramref name="value"/> mit dem Anfang von <paramref name="span"/> übereinstimmt,
    /// andernfalls <c>false</c>.</returns>
    /// <remarks>
    /// Wenn <paramref name="value"/>&#160;<c>null</c> oder <see cref="string.Empty"/> ist
    /// wird <c>true</c> zurückgegeben.
    /// </remarks>
    /// <exception cref="ArgumentException"><paramref name="comparisonType"/> ist kein definierter <see cref="StringComparison"/>-Wert.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool StartsWith(this ReadOnlySpan<char> span, string? value, StringComparison comparisonType)
        => span.StartsWith(value.AsSpan(), comparisonType);


    /// <summary>
    /// Bestimmt, ob eine schreibgeschützte Zeichenspanne mit einem angegebenen <see cref="string"/> endet.
    /// </summary>
    /// <param name="span">Die Quellspanne.</param>
    /// <param name="value">Der <see cref="string"/>, der mit dem Ende der Quellspanne verglichen werden soll.</param>
    /// <returns><c>true</c>, wenn <paramref name="value"/> mit dem Ende von <paramref name="span"/> übereinstimmt,
    /// andernfalls <c>false</c>.</returns>
    /// <remarks>
    /// Die Methode führt einen Ordinalzeichenvergleich durch. Wenn <paramref name="value"/>&#160;<c>null</c> oder <see cref="string.Empty"/> ist
    /// wird <c>true</c> zurückgegeben.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EndsWith(this ReadOnlySpan<char> span, string? value)
        => span.EndsWith(value.AsSpan());

    /// <summary>
    /// Bestimmt, ob eine schreibgeschützte Zeichenspanne mit einem angegebenen <see cref="string"/> endet,
    /// wenn sie mit einem angegebenen <see cref="StringComparison"/> verglichen wird.
    /// </summary>
    /// <param name="span">Die Quellspanne.</param>
    /// <param name="value">Der <see cref="string"/>, der mit dem Ende der Quellspanne verglichen werden soll.</param>
    /// <param name="comparisonType">Ein Enumerationswert, der bestimmt, wie <paramref name="span"/> und 
    /// <paramref name="value"/> verglichen werden.</param>
    /// <returns><c>true</c>, wenn <paramref name="value"/> mit dem Ende von <paramref name="span"/> übereinstimmt,
    /// andernfalls <c>false</c>.</returns>
    /// <remarks>
    /// Wenn <paramref name="value"/>&#160;<c>null</c> oder <see cref="string.Empty"/> ist
    /// wird <c>true</c> zurückgegeben.
    /// </remarks>
    /// <exception cref="ArgumentException"><paramref name="comparisonType"/> ist kein definierter <see cref="StringComparison"/>-Wert.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EndsWith(this ReadOnlySpan<char> span, string? value, StringComparison comparisonType)
        => span.EndsWith(value.AsSpan(), comparisonType);


#endif

}
