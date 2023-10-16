namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    /// <summary>Searches for the zero-based index of the first occurrence of one of the
    /// specified Unicode characters.</summary>
    /// <param name="span">The read-only span to examine.</param>
    /// <param name="values">A read-only character span that contains the characters to search
    /// for.</param>
    /// <returns>The zero-based index of the first occurrence of one of the specified Unicode
    /// characters in <paramref name="span" /> or -1 if none of these characters have been
    /// found. If <paramref name="values" /> is an empty span, the method returns -1.</returns>
    /// <remarks>If the length of <paramref name="values" /> is less than 5, the method uses
    /// <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T}, ReadOnlySpan{T})">
    /// MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> for the comparison. If the length of <paramref name="values"
    /// /> is greater, <see cref="string.IndexOfAny(char[])">String.IndexOfAny(char[])</see>
    /// is used to avoid performance issues.</remarks>
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
