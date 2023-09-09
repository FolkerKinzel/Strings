using System.Runtime.CompilerServices;

namespace FolkerKinzel.Strings.Polyfills;

/// <summary>
/// Erweiterungsmethoden, die als Polyfills für die Erweiterungsmethoden der Klasse <see cref="ReadOnlySpanExtension"/>
/// dienen.
/// </summary>
public static class ReadOnlySpanExtensionPolyfillExtension
{
    // Place this preprocessor directive inside the class to let .NET 5.0 have an empty class!
#if NET45 || NETSTANDARD2_0
    /// <summary>
    /// Gibt die NULL-basierte Indexposition des letzten Vorkommens einer angegebenen Zeichenfolge <paramref name="span"/> an. Die Suche beginnt an einer angegebenen Zeichenposition 
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
    /// <paramref name="span"/> ist nicht <see cref="ReadOnlySpan{T}.Empty"/>, und <paramref name="startIndex"/> ist ein negativer Wert.
    /// </para>
    /// <para>
    /// - oder -
    /// </para>
    /// <para>
    /// <paramref name="span"/> ist nicht <see cref="ReadOnlySpan{T}.Empty"/>, und <paramref name="startIndex"/> ist größer als die Länge von <paramref name="span"/>.
    /// </para>
    /// <para>
    /// - oder -
    /// </para>
    /// <para>
    /// <paramref name="span"/> ist nicht <see cref="ReadOnlySpan{T}.Empty"/>, und <paramref name="startIndex"/> + 1 - <paramref name="count"/> gibt eine Position an, 
    /// die nicht innerhalb von <paramref name="span"/> liegt.
    /// </para>
    /// <para>
    /// - oder -
    /// </para>
    /// <para>
    /// <paramref name="span"/> ist <see cref="ReadOnlySpan{T}.Empty"/>, und <paramref name="startIndex"/> ist kleiner als -1 oder größer als 0.
    /// </para>
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="comparisonType"/> ist kein gültiger <see cref="StringComparison"/>-Wert.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOf(this ReadOnlySpan<char> span, string? value, int startIndex, int count, StringComparison comparisonType)
        => span.LastIndexOf(value.AsSpan(), startIndex, count, comparisonType);


    /// <summary>
    /// Gibt an, ob in einer schreibgeschüzten Zeichenspanne eines der Zeichen vorkommt,
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
    public static bool ContainsAny(this ReadOnlySpan<char> span, string? values)
        => span.ContainsAny(values.AsSpan());

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
    /// Diese Spezialisierung der Erweiterungsmethode MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;)
    /// für den Datentyp <see cref="char"/> wird benötigt, um Performanceprobleme zu vermeiden.
    /// </para>
    /// <para>
    /// Wenn die Länge von <paramref name="values"/> kleiner als 5 ist, verwendet die Methode für den Vergleich 
    /// <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T}, ReadOnlySpan{T})">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;)</see>. 
    /// Ist die Länge von <paramref name="values"/>
    /// größer, wird <see cref="string.IndexOfAny(char[])">String.IndexOfAny(char[])</see> verwendet.
    /// </para>
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAny(this ReadOnlySpan<char> span, string? values)
        => span.IndexOfAny(values.AsSpan());

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
    /// Diese Spezialisierung der Erweiterungsmethode MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;)
    /// für den Datentyp <see cref="char"/> wird benötigt, um Performanceprobleme zu vermeiden.
    /// </para>
    /// <para>
    /// Wenn die Länge von <paramref name="values"/> kleiner als 5 ist, verwendet die Methode für den Vergleich 
    /// <see cref="MemoryExtensions.LastIndexOfAny{T}(Span{T}, ReadOnlySpan{T})">MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;)</see>.
    /// Ist die Länge von <paramref name="values"/>
    /// größer, wird <see cref="string.LastIndexOfAny(char[])">String.LastIndexOfAny(char[])</see> verwendet.
    /// </para>
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOfAny(this ReadOnlySpan<char> span, string? values)
        => span.LastIndexOfAny(values.AsSpan());

    /// <summary>
    /// Gibt die nullbasierte Indexposition des letzten Vorkommens eines der angegebenen Zeichen 
    /// in <paramref name="span"/> an. Die Suche beginnt an einer angegebenen Zeichenposition 
    /// und verläuft für eine angegebene Anzahl von Zeichenpositionen rückwärts zum Anfang der Zeichenfolge.
    /// </summary>
    /// <param name="span">Die zu durchsuchende schreibgeschützte Zeichenspanne.</param>
    /// <param name="values">Eine Zeichenfolge, die die zu suchenden Zeichen enthält oder <c>null</c>.</param>
    /// <param name="startIndex">Die Anfangsposition der Suche. Die Suche erfolgt rückwärts zum Anfang 
    /// von <paramref name="span"/>.</param>
    /// <param name="count">Die Anzahl der zu überprüfenden Zeichenpositionen in <paramref name="span"/>.</param>
    /// <returns>Der nullbasierte Index des letzten Vorkommens eines beliebigen Zeichens aus <paramref name="values"/>
    /// in <paramref name="span"/> oder -1, wenn keines dieser Zeichen gefunden wurde.</returns>
    /// <remarks>
    /// Wenn die Länge von <paramref name="values"/> kleiner als 5 ist, verwendet die Methode für den Vergleich 
    /// <see cref="MemoryExtensions.LastIndexOfAny{T}(Span{T}, ReadOnlySpan{T})">MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;)</see>.
    /// Ist die Länge von <paramref name="values"/>
    /// größer, wird <see cref="string.LastIndexOfAny(char[])">String.LastIndexOfAny(char[])</see> verwendet.
    /// </remarks>
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
    /// 
    public static int LastIndexOfAny(this ReadOnlySpan<char> span, string? values, int startIndex, int count)
        => span.LastIndexOfAny(values.AsSpan(), startIndex, count);
#endif

}
