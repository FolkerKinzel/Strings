using System.Runtime.CompilerServices;

namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    /// <summary>
    /// Gibt an, ob in einer Zeichenspanne eines der Zeichen vorkommt,
    /// die der Methode in einer schreibgeschützten Zeichenspanne übergeben werden.
    /// </summary>
    /// <param name="span">Die zu untersuchende Spanne.</param>
    /// <param name="values">Eine schreibgeschützte Zeichenspanne, die die zu suchenden Zeichen enthält.</param>
    /// <returns><c>true</c>, wenn in <paramref name="span"/> eines der in <paramref name="values"/> enthaltenen
    /// Zeichen vorkommt. Wenn <paramref name="span"/> oder <paramref name="values"/> leere Spannen sind,
    /// wird <c>false</c> zurückgegeben.</returns>
    /// <remarks>
    /// Wenn die Länge von <paramref name="values"/> kleiner als 5 ist, verwendet die Methode für den Vergleich 
    /// <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T}, ReadOnlySpan{T})">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;)</see>. 
    /// Ist die Länge von <paramref name="values"/>
    /// größer, wird - um Performanceprobleme zu vermeiden - <see cref="string.IndexOfAny(char[])">String.IndexOfAny(char[])</see> verwendet.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAny(this Span<char> span, ReadOnlySpan<char> values)
        => ((ReadOnlySpan<char>)span).ContainsAny(values);


    /// <summary>
    /// Gibt an, ob in einer Zeichenspanne eines der beiden Zeichen vorkommt,
    /// die der Methode als Argumente übergeben werden.
    /// </summary>
    /// <param name="span">Die zu untersuchende Spanne.</param>
    /// <param name="value0">Das erste zu suchende Zeichen.</param>
    /// <param name="value1">Das zweite zu suchende Zeichen.</param>
    /// <returns><c>true</c>, wenn eines der zu suchenden Zeichen in der Spanne gefunden wird, andernfalls <c>false</c>.</returns>
    /// <remarks>
    /// Für den Vergleich wird 
    /// <see cref="MemoryExtensions.IndexOfAny{T}(Span{T}, T, T)">MemoryExtensions.IndexOfAny&lt;T&gt;(Span&lt;T&gt;, T, T)</see> verwendet.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAny(this Span<char> span, char value0, char value1)
        => span.IndexOfAny(value0, value1) != -1;

    /// <summary>
    /// Gibt an, ob in einer schreibgeschüzten Zeichenspanne eines der drei Zeichen vorkommt,
    /// die der Methode als Argumente übergeben werden.
    /// </summary>
    /// <param name="span">Die zu untersuchende Spanne.</param>
    /// <param name="value0">Das erste zu suchende Zeichen.</param>
    /// <param name="value1">Das zweite zu suchende Zeichen.</param>
    /// <param name="value2">Das dritte zu suchende Zeichen.</param>
    /// <returns><c>true</c>, wenn eines der zu suchenden Zeichen in der Spanne gefunden wird, andernfalls <c>false</c>.</returns>
    /// <remarks>
    /// Für den Vergleich wird <see cref="MemoryExtensions.IndexOfAny{T}(Span{T}, T, T, T)">MemoryExtensions.IndexOfAny&lt;T&gt;(Span&lt;T&gt;, T, T, T)</see> verwendet.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAny(this Span<char> span, char value0, char value1, char value2)
        => span.IndexOfAny(value0, value1, value2) != -1;


}
