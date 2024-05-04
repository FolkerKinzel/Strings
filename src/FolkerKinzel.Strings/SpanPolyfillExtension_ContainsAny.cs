namespace FolkerKinzel.Strings;

#if NET7_0 || NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET461

public static partial class SpanPolyfillExtension
{
    /// <summary>Indicates whether a character span contains one of the Unicode characters
    /// that are passed to the method as a read-only character span.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="values">A read-only character span that contains the characters to search
    /// for.</param>
    /// <returns> <c>true</c> if <paramref name="span" /> contains one of the characters
    /// passed with <paramref name="values" />. If <paramref
    /// name="values" /> is empty, <c>false</c> is returned.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAny(this Span<char> span, ReadOnlySpan<char> values)
        => span.IndexOfAny(values) != -1;

    /// <summary>Indicates whether a character span contains one of the two characters that
    /// are passed to the method as arguments.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="value0">The first character to search for.</param>
    /// <param name="value1">The second character to search for.</param>
    /// <returns> <c>true</c> if one of the characters to be searched for is found in the
    /// span, otherwise <c>false</c>.</returns>
    /// <remarks> <see cref="MemoryExtensions.IndexOfAny{T}(Span{T},
    /// T, T)">MemoryExtensions.IndexOfAny&lt;T&gt;(Span&lt;T&gt;, T, T)</see> is used
    /// for the comparison.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAny(this Span<char> span, char value0, char value1)
        => span.IndexOfAny(value0, value1) != -1;

    /// <summary>Indicates whether a character span contains one of the three characters
    /// that are passed to the method as arguments.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="value0">The first character to search for.</param>
    /// <param name="value1">The second character to search for.</param>
    /// <param name="value2">The third character to search for.</param>
    /// <returns> <c>true</c> if one of the characters to be searched for is found in the
    /// span, otherwise <c>false</c>.</returns>
    /// <remarks><see cref="MemoryExtensions.IndexOfAny{T}(Span{T},
    /// T, T, T)">MemoryExtensions.IndexOfAny&lt;T&gt;(Span&lt;T&gt;, T, T, T)</see> is used
    /// for the comparison.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAny(
        this Span<char> span, char value0, char value1, char value2)
        => span.IndexOfAny(value0, value1, value2) != -1;

#if NET461 || NETSTANDARD2_0

    /// <summary>Indicates whether a character span contains one of the Unicode characters
    /// that are passed to the method as a string.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="values">A string containing the characters to search for, or <c>null</c>.</param>
    /// <returns> <c>true</c> if <paramref name="span" /> contains one of the characters
    /// passed with <paramref name="values" />. If <paramref
    /// name="values" /> is <c>null</c> or empty, <c>false</c> is returned.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAny(this Span<char> span, string? values)
        => span.ContainsAny(values.AsSpan());

#endif
}

#endif
