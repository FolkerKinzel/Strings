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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(this Span<char> span, char value)
        => span.IndexOf(value) != -1;

    /// <summary>
    /// Entfernt alle führenden und nachfolgenden Leerzeichen aus einer schreibgeschützten Zeichenspanne.
    /// </summary>
    /// <param name="span">Die Quellspanne, aus der die Zeichen entfernt werden.</param>
    /// <returns>Die zugeschnittene Zeichenspanne.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> Trim(this Span<char> span) => span.TrimStart().TrimEnd();


    /// <summary>
    /// Entfernt alle führenden Leerzeichen aus einer schreibgeschützten Zeichenspanne.
    /// </summary>
    /// <param name="span">Die Quellspanne, aus der die Zeichen entfernt werden.</param>
    /// <returns>Die zugeschnittene Zeichenspanne.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> TrimStart(this Span<char> span)
        => span.Slice(span.GetTrimmedStart());

    /// <summary>
    /// Entfernt alle nachfolgenden Leerzeichen aus einer schreibgeschützten Zeichenspanne.
    /// </summary>
    /// <param name="span">Die Quellspanne, aus der die Zeichen entfernt werden.</param>
    /// <returns>Die zugeschnittene Zeichenspanne.</returns>
    public static Span<char> TrimEnd(this Span<char> span)
        => span.Slice(0, span.GetTrimmedLength());
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
    public static bool Equals(this Span<char> span, string? other, StringComparison comparisonType) 
        => ((ReadOnlySpan<char>)span).Equals(other.AsSpan(), comparisonType);
        

    /// <summary>
    /// Gibt an, ob ein angegebener Wert innerhalb einer Zeichenspanne auftritt.
    /// </summary>
    /// <param name="span">Die Quellspanne.</param>
    /// <param name="value">Der innerhalb der Quellspanne zu suchende Wert. <paramref name="value"/> darf <c>null</c> sein.</param>
    /// <param name="comparisonType">Ein Enumerationswert, der bestimmt, wie die Zeichen in <paramref name="span"/> und 
    /// <paramref name="value"/> verglichen werden.</param>
    /// <returns><c>true</c>, wenn <paramref name="value"/> innerhalb der Spanne auftritt, andernfalls <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(this Span<char> span, string? value, StringComparison comparisonType)
        => ((ReadOnlySpan<char>)span).Contains(value.AsSpan(), comparisonType);


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
    public static int LastIndexOf(this Span<char> span, string? value, StringComparison comparisonType)
        => ((ReadOnlySpan<char>) span).LastIndexOf(value.AsSpan(), comparisonType);

    /// <summary>
    /// Bestimmt, ob eine Zeichenspanne mit einem angegebenen <see cref="string"/> beginnt.
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
    public static bool StartsWith(this Span<char> span, string? value)
        => ((ReadOnlySpan<char>) span).StartsWith(value.AsSpan());

    /// <summary>
    /// Bestimmt, ob eine Zeichenspanne mit einem angegebenen <see cref="string"/> beginnt,
    /// wenn sie unter Verwendung eines angegebenen <see cref="StringComparison"/>-Werts verglichen wird.
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
    /// 
    /// <exception cref="ArgumentException"><paramref name="comparisonType"/> ist kein definierter <see cref="StringComparison"/>-Wert.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool StartsWith(this Span<char> span, string? value, StringComparison comparisonType)
        => ((ReadOnlySpan<char>)span).StartsWith(value.AsSpan(), comparisonType);


    /// <summary>
    /// Bestimmt, ob eine Zeichenspanne mit einem angegebenen <see cref="string"/> endet.
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
    public static bool EndsWith(this Span<char> span, string? value)
        => ((ReadOnlySpan<char>)span).EndsWith(value.AsSpan());

    /// <summary>
    /// Bestimmt, ob eine Zeichenspanne mit einem angegebenen <see cref="string"/> endet,
    /// wenn sie unter Verwendung eines angegebenen <see cref="StringComparison"/>-Werts verglichen wird.
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
    /// 
    /// <exception cref="ArgumentException"><paramref name="comparisonType"/> ist kein definierter <see cref="StringComparison"/>-Wert.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EndsWith(this Span<char> span, string? value, StringComparison comparisonType)
        => ((ReadOnlySpan<char>)span).EndsWith(value.AsSpan(), comparisonType);

    /// <summary>
    /// Gibt die NULL-basierte Indexposition des letzten Vorkommens einer angegebenen Zeichenfolge in <paramref name="span"/> an. Die Suche beginnt an einer angegebenen Zeichenposition 
    /// und verläuft für eine angegebene Anzahl von Zeichenpositionen rückwärts zum Anfang der Zeichenspanne. Ein Parameter gibt den Typ des bei der Suche nach der angegebenen 
    /// Zeichenfolge auszuführenden Vergleichs an.
    /// </summary>
    /// <param name="span">Die zu durchsuchende Zeichenspanne.</param>
    /// <param name="value">Der zu suchende <see cref="string"/> oder <c>null</c>.</param>
    /// <param name="startIndex">Die Anfangsposition der Suche. Die Suche wird von <paramref name="startIndex"/> bis zum Anfang von <paramref name="span"/> fortgesetzt.</param>
    /// <param name="count">Die Anzahl der zu überprüfenden Zeichenpositionen.</param>
    /// <param name="comparisonType">Einer der Enumerationswerte, der die Regeln für die Suche angibt.</param>
    /// <returns>Die nullbasierte Anfangsindexposition des <paramref name="value"/>-Parameters, wenn diese Zeichenfolge gefunden wurde, oder -1, wenn sie nicht 
    /// gefunden wurde oder <paramref name="span"/> leer ist.</returns>
    /// 
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="count"/> ist ein negativer Wert
    /// </para>
    /// <para>
    /// - oder -
    /// </para>
    /// <para>
    /// <paramref name="span"/> ist nicht <see cref="Span{T}.Empty"/>, und <paramref name="startIndex"/> ist ein negativer Wert.
    /// </para>
    /// <para>
    /// - oder -
    /// </para>
    /// <para>
    /// <paramref name="span"/> ist nicht <see cref="Span{T}.Empty"/>, und <paramref name="startIndex"/> ist größer als die Länge von <paramref name="span"/>.
    /// </para>
    /// <para>
    /// - oder -
    /// </para>
    /// <para>
    /// <paramref name="span"/> ist nicht <see cref="Span{T}.Empty"/>, und <paramref name="startIndex"/> + 1 - <paramref name="count"/> gibt eine Position an, 
    /// die nicht innerhalb von <paramref name="span"/> liegt.
    /// </para>
    /// <para>
    /// - oder -
    /// </para>
    /// <para>
    /// <paramref name="span"/> ist <see cref="Span{T}.Empty"/>, und <paramref name="startIndex"/> ist kleiner als -1 oder größer als 0.
    /// </para>
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="comparisonType"/> ist kein gültiger <see cref="StringComparison"/>-Wert.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOf(this Span<char> span, string? value, int startIndex, int count, StringComparison comparisonType)
        => ((ReadOnlySpan<char>)span).LastIndexOf(value.AsSpan(), startIndex, count, comparisonType);


    /// <summary>
    /// Gibt an, ob in einer Zeichenspanne eines der Zeichen vorkommt,
    /// die der Methode als Zeichenfolge übergeben werden.
    /// </summary>
    /// <param name="span">Die zu untersuchende Spanne.</param>
    /// <param name="values">Eine Zeichenfolge, die die zu suchenden Zeichen enthält oder <c>null</c>.</param>
    /// <returns><c>true</c>, wenn in <paramref name="span"/> eines der in <paramref name="values"/> enthaltenen
    /// Zeichen vorkommt. Wenn <paramref name="span"/> eine leere Spanne oder <paramref name="values"/>&#160;<c>null</c> 
    /// oder eine leere Zeichenfolge ist, wird <c>false</c> zurückgegeben.</returns>
    /// <remarks>
    /// Wenn die Länge von <paramref name="values"/> kleiner als 5 ist, verwendet die Methode für den Vergleich 
    /// MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;). 
    /// Ist die Länge von <paramref name="values"/>
    /// größer, wird - um Performanceprobleme zu vermeiden - <see cref="string.IndexOfAny(char[])"/> verwendet.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAny(this Span<char> span, string? values)
        => ((ReadOnlySpan<char>)span).ContainsAny(values.AsSpan());

    /// <summary>
    /// Sucht nach dem NULL-basierten Index des ersten Vorkommens eines der angegebenen Unicode-Zeichen.
    /// </summary>
    /// <param name="span">Die zu untersuchende Spanne.</param>
    /// <param name="values">Eine Zeichenfolge, die die zu suchenden Zeichen enthält oder <c>null</c>.</param>
    /// <returns>Der NULL-basierte Index des ersten Vorkommens eines beliebigen Zeichens aus <paramref name="values"/>
    /// in <paramref name="span"/> oder -1, wenn keines der Zeichen gefunden wurde. Wenn <paramref name="values"/>&#160;<c>null</c> oder eine 
    /// leere Zeichenfolge ist, gibt die Methode -1 zurück.</returns>
    /// <remarks>
    /// <para>
    /// Diese Spezialisierung der Erweiterungsmethode MemoryExtensions.IndexOfAny&lt;T&gt;(Span&lt;T&gt;, ReadOnlySpan&lt;T&gt;)
    /// für den Datentyp <see cref="char"/> wird benötigt, um Performanceprobleme zu vermeiden.
    /// </para>
    /// <para>
    /// Wenn die Länge von <paramref name="values"/> kleiner als 5 ist, verwendet die Methode für den Vergleich 
    /// MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;). Ist die Länge von <paramref name="values"/>
    /// größer, wird <see cref="string.IndexOfAny(char[])"/> verwendet.
    /// </para>
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAny(this Span<char> span, string? values)
        => ((ReadOnlySpan<char>)span).IndexOfAny(values.AsSpan());

    /// <summary>
    /// Sucht nach dem NULL-basierten Index des letzten Vorkommens eines der angegebenen Unicode-Zeichen.
    /// </summary>
    /// <param name="span">Die zu untersuchende Spanne.</param>
    /// <param name="values">Eine Zeichenfolge, die die zu suchenden Zeichen enthält oder <c>null</c>.</param>
    /// <returns>Der NULL-basierte Index des letzten Vorkommens eines beliebigen Zeichens aus <paramref name="values"/>
    /// in <paramref name="span"/> oder -1, wenn keines der Zeichen gefunden wurde. Wenn <paramref name="values"/>&#160;<c>null</c>
    /// oder eine leere Zeichenfolge ist, wird -1 zurückgegeben</returns>
    /// <remarks>
    /// <para>
    /// Diese Spezialisierung der Erweiterungsmethode MemoryExtensions.LastIndexOfAny&lt;T&gt;(Span&lt;T&gt;, ReadOnlySpan&lt;T&gt;)
    /// für den Datentyp <see cref="char"/> wird benötigt, um Performanceprobleme zu vermeiden.
    /// </para>
    /// <para>
    /// Wenn die Länge von <paramref name="values"/> kleiner als 5 ist, verwendet die Methode für den Vergleich 
    /// MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;).
    /// Ist die Länge von <paramref name="values"/>
    /// größer, wird <see cref="string.LastIndexOfAny(char[])"/> verwendet.
    /// </para>
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOfAny(this Span<char> span, string? values)
        => ((ReadOnlySpan<char>)span).LastIndexOfAny(values.AsSpan());

    /// <summary>
    /// Gibt die nullbasierte Indexposition des letzten Vorkommens eines der angegebenen Zeichen 
    /// in <paramref name="span"/> an. Die Suche beginnt an einer angegebenen Zeichenposition 
    /// und verläuft für eine angegebene Anzahl von Zeichenpositionen rückwärts zum Anfang der Zeichenfolge.
    /// </summary>
    /// <param name="span">Die zu durchsuchende Zeichenspanne.</param>
    /// <param name="values">Eine Zeichenfolge, die die zu suchenden Zeichen enthält oder <c>null</c>.</param>
    /// <param name="startIndex">Die Anfangsposition der Suche. Die Suche erfolgt rückwärts zum Anfang 
    /// von <paramref name="span"/>.</param>
    /// <param name="count">Die Anzahl der zu überprüfenden Zeichenpositionen in <paramref name="span"/>.</param>
    /// <returns>Der nullbasierte Index des letzten Vorkommens eines beliebigen Zeichens aus <paramref name="values"/>
    /// in <paramref name="span"/> oder -1, wenn keines dieser Zeichen gefunden wurde.</returns>
    /// <remarks>
    /// Wenn die Länge von <paramref name="values"/> kleiner als 5 ist, verwendet die Methode für den Vergleich 
    /// <see cref="MemoryExtensions.LastIndexOfAny{T}(ReadOnlySpan{T}, ReadOnlySpan{T})"/>. Ist die Länge von <paramref name="values"/>
    /// größer, wird <see cref="string.LastIndexOfAny(char[])"/> verwendet.
    /// </remarks>
    /// 
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="span"/> ist nicht <see cref="ReadOnlySpan{T}.Empty"/> und <paramref name="startIndex"/> ist 
    /// kleiner als 0 oder größer oder gleich der Länge von <paramref name="span"/>
    /// </para>
    /// <para>
    /// - oder -
    /// </para>
    /// <para>
    /// <paramref name="span"/> ist nicht <see cref="ReadOnlySpan{T}.Empty"/> und <paramref name="startIndex"/> - <paramref name="count"/> + 1 
    /// ist kleiner als 0.
    /// </para>
    /// </exception>
    public static int LastIndexOfAny(this Span<char> span, string? values, int startIndex, int count)
        => ((ReadOnlySpan<char>)span).LastIndexOfAny(values.AsSpan(), startIndex, count);

#endif
}
