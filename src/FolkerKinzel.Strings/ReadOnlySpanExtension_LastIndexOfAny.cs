namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    /// <summary>Searches for the zero-based index of the last occurrence of one of the specified
    /// Unicode characters.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="values">A read-only character span that contains the characters to search
    /// for.</param>
    /// <returns>The zero-based index of the last occurrence of one of the specified Unicode
    /// characters in <paramref name="span" /> or -1 if none of these characters have been
    /// found. If <paramref name="values" /> is an empty span, the method returns -1.</returns>
    /// <remarks> Wenn die Länge von <paramref name="values" /> kleiner als 5 ist, verwendet
    /// die Methode für den Vergleich <see cref="MemoryExtensions.LastIndexOfAny{T}(Span{T},
    /// ReadOnlySpan{T})">MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see>. Ist die Länge von <paramref name="values" /> größer,
    /// wird - um Performanceprobleme zu vermeiden - <see cref="string.LastIndexOfAny(char[])">String.LastIndexOfAny(char[])</see>
    /// verwendet. </remarks>
    public static int LastIndexOfAny(this ReadOnlySpan<char> span, ReadOnlySpan<char> values)
    {
        // string.LastIndexOfAny returns -1 if anyOf is an empty array (although MSDN says it would return 0).
        // MemoryExtensions.LastIndexOfAny returns 0 if the span with the characters to search for is empty.
        // This makes it consistent:
        return span.IsEmpty || values.IsEmpty
            ? -1
            : values.Length > 5 && span.Length > 2
                ? span.ToString().LastIndexOfAny(values.ToArray())
                : MemoryExtensions.LastIndexOfAny(span, values);
    }


    /// <summary>Returns the zero-based index of the last occurrence of one of the specified
    /// characters in <paramref name="span" />. The search begins at a specified character
    /// position and runs a specified number of character positions backwards to the beginning
    /// of the <paramref name="span" />.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="values">A read-only character span that contains the characters to search
    /// for.</param>
    /// <param name="startIndex">The start index of the search. The search is done backwards
    /// to the beginning of <paramref name="span" />.</param>
    /// <param name="count">The number of characters positions to examine in <paramref name="span"
    /// />.</param>
    /// <returns>The zero-based index of the last occurrence of one of the specified Unicode
    /// characters in <paramref name="span" /> or -1 if none of these characters have been
    /// found.</returns>
    /// <remarks> Wenn die Länge von <paramref name="values" /> kleiner als 5 ist, verwendet
    /// die Methode für den Vergleich <see cref="MemoryExtensions.LastIndexOfAny{T}(Span{T},
    /// ReadOnlySpan{T})">MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see>. Ist die Länge von <paramref name="values" /> größer,
    /// wird - um Performanceprobleme zu vermeiden - <see cref="string.LastIndexOfAny(char[])">String.LastIndexOfAny(char[])</see>
    /// verwendet. </remarks>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="span" /> is not <see cref="ReadOnlySpan{T}.Empty" /> and <paramref
    /// name="startIndex" /> is less than zero or greater than or equal to the length of
    /// <paramref name="span" />
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="span" /> is not <see cref="ReadOnlySpan{T}.Empty" /> and <paramref
    /// name="startIndex" /> - <paramref name="count" /> + 1 is less than zero.
    /// </para>
    /// </exception>
    public static int LastIndexOfAny(this ReadOnlySpan<char> span, ReadOnlySpan<char> values, int startIndex, int count)
    {
        // string.LastIndexOfAny returns -1 if anyOf is an empty array (although MSDN says it would return 0).
        // MemoryExtensions.LastIndexOfAny returns 0 if the span with the characters to search for is empty.
        // This makes it consistent:
        if (count == 0 || values.IsEmpty)
        {
            return -1;
        }

        if (values.Length <= 5)
        {
            // MemoryExtensions.LastIndexOfAny throws ArgumentOutOfRangeExceptions even if s is ""
            // string.LastIndexOfAny does not.
            if (span.Length == 0)
            {
                return -1;
            }
            int matchIndex = MemoryExtensions.LastIndexOfAny(span.Slice(startIndex - count + 1, count), values);
            return matchIndex == -1 ? -1 : matchIndex + startIndex - count + 1;
        }

        return span.ToString().LastIndexOfAny(values.ToArray(), startIndex, count);
    }


}
