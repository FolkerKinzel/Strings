using System.Runtime.CompilerServices;

namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    /// <summary>
    /// Gibt an, ob in einer schreibgeschüzten Zeichenspanne eines der Zeichen vorkommt,
    /// die der Methode in einer anderen schreibgeschützten Zeichenspanne übergeben werden.
    /// </summary>
    /// <param name="span">Die zu untersuchende Spanne.</param>
    /// <param name="values">Eine schreibgeschützte Zeichenspanne, die die zu suchenden Zeichen enthält.</param>
    /// <returns><c>true</c>, wenn in <paramref name="span"/> eines der in <paramref name="values"/> enthaltenen
    /// Zeichen vorkommt. Wenn <paramref name="span"/> oder <paramref name="values"/> leere Spannen sind,
    /// wird <c>false</c> zurückgegeben.</returns>
    /// <remarks>
    /// Wenn die Länge von <paramref name="values"/> kleiner als 5 ist, verwendet die Methode für den Vergleich 
    /// MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;). 
    /// Ist die Länge von <paramref name="values"/>
    /// größer, wird - um Performanceprobleme zu vermeiden - <see cref="string.IndexOfAny(char[])"/> verwendet.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAny(this ReadOnlySpan<char> span, ReadOnlySpan<char> values)
        => !values.IsEmpty && span.IndexOfAny(values) != -1;


    /// <summary>
    /// Gibt an, ob in einer schreibgeschüzten Zeichenspanne eines der beiden Zeichen vorkommt,
    /// die der Methode als Argumente übergeben werden.
    /// </summary>
    /// <param name="span">Die zu untersuchende Spanne.</param>
    /// <param name="value0">Das erste zu suchende Zeichen.</param>
    /// <param name="value1">Das zweite zu suchende Zeichen.</param>
    /// <returns><c>true</c>, wenn eines der zu suchenden Zeichen in der Spanne gefunden wird, andernfalls <c>false</c>.</returns>
    /// <remarks>
    /// Für den Vergleich wird MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, T, T) verwendet.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAny(this ReadOnlySpan<char> span, char value0, char value1)
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
    /// Für den Vergleich wird MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, T, T, T) verwendet.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAny(this ReadOnlySpan<char> span, char value0, char value1, char value2)
        => span.IndexOfAny(value0, value1, value2) != -1;


}
