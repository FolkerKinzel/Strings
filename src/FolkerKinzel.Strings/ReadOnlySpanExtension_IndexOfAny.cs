namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    /// <summary>
    /// Sucht nach dem NULL-basierten Index des ersten Vorkommens eines der angegebenen Unicode-Zeichen.
    /// </summary>
    /// <param name="span">Die zu untersuchende Spanne.</param>
    /// <param name="values">Eine schreibgeschützte Zeichenspanne, die die zu suchenden Zeichen enthält.</param>
    /// <returns>Der NULL-basierte Index des ersten Vorkommens eines beliebigen Zeichens aus <paramref name="values"/>
    /// in <paramref name="span"/> oder -1, wenn keines der Zeichen gefunden wurde. Wenn <paramref name="values"/> eine 
    /// leere Spanne ist, gibt die Methode -1 zurück.</returns>
    /// <remarks>
    /// Wenn die Länge von <paramref name="values"/> kleiner als 5 ist, verwendet die Methode für den Vergleich 
    /// <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T}, ReadOnlySpan{T})">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;)</see>. 
    /// Ist die Länge von <paramref name="values"/>
    /// größer, wird  - um Performanceprobleme zu vermeiden - <see cref="string.IndexOfAny(char[])">String.IndexOfAny(char[])</see> verwendet.
    /// </remarks>
    public static int IndexOfAny(this ReadOnlySpan<char> span, ReadOnlySpan<char> values)
    {
        // string.IndexOfAny returns -1 if anyOf is an empty array (although MSDN says it would return 0).
        // MemoryExtensions.IndexOfAny returns 0 if the span with the characters to search for is empty.
        // This makes it consistent:
        return span.IsEmpty || values.IsEmpty
            ? -1
            : values.Length > 5 && span.Length > 2
                ? span.ToString().IndexOfAny(values.ToArray())
                : MemoryExtensions.IndexOfAny(span, values);
    }

}
