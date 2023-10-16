namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    /// <summary>Indicates whether a read-only span of Unicode characters contains one of
    /// the Unicode characters that are passed to the method in another span.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="values">A read-only character span that contains the characters to search
    /// for.</param>
    /// <returns> <c>true</c> if <paramref name="span" /> contains one of the characters
    /// passed with <paramref name="values" />. If <paramref name="span" /> or <paramref
    /// name="values" /> are empty, <c>false</c> is returned.</returns>
    /// <remarks>If the length of <paramref name="values" /> is less than 5, the method uses
    /// <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T}, ReadOnlySpan{T})">
    /// MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> for the comparison. If the length of <paramref name="values"
    /// /> is greater, <see cref="string.IndexOfAny(char[])">String.IndexOfAny(char[])</see>
    /// is used to avoid performance issues.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAny(this ReadOnlySpan<char> span, ReadOnlySpan<char> values)
        => !values.IsEmpty && span.IndexOfAny(values) != -1;


    /// <summary>Indicates whether a read-only character span contains one of the two characters
    /// that are passed to the method as arguments.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="value0">The first character to search for.</param>
    /// <param name="value1">The second character to search for.</param>
    /// <returns> <c>true</c> if one of the characters to be searched for is found in the
    /// span, otherwise <c>false</c>.</returns>
    /// <remarks> <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T},
    /// T, T)">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, T, T)</see> 
    /// is used for the comparison.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAny(this ReadOnlySpan<char> span, char value0, char value1)
        => span.IndexOfAny(value0, value1) != -1;

    /// <summary>Indicates whether a character span contains one of the three characters
    /// that are passed to the method as arguments.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="value0">The first character to search for.</param>
    /// <param name="value1">The second character to search for.</param>
    /// <param name="value2">The third character to search for.</param>
    /// <returns> <c>true</c> if one of the characters to be searched for is found in the
    /// span, otherwise <c>false</c>.</returns>
    /// <remarks> <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T},
    /// T, T, T)">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, T, T, T) </see>
    /// is used for the comparison.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAny(this ReadOnlySpan<char> span, char value0, char value1, char value2)
        => span.IndexOfAny(value0, value1, value2) != -1;


}
