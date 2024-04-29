namespace FolkerKinzel.Strings;

#if !NET8_0_OR_GREATER

public static partial class ReadOnlySpanPolyfillExtension
{
    /// <summary>Indicates whether a read-only span of Unicode characters contains one of
    /// the Unicode characters that are passed to the method in another span.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="values">A read-only character span that contains the characters to search
    /// for.</param>
    /// <returns> <c>true</c> if <paramref name="span" /> contains one of the characters
    /// passed with <paramref name="values" />. If <paramref name="values" /> is empty, <c>false</c> 
    /// is returned.</returns>
    /// <remarks> <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T},
    /// ReadOnlySpan{T})">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;)</see> 
    /// is used for the comparison.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAny(this ReadOnlySpan<char> span, ReadOnlySpan<char> values)
        // Don't address MemoryExtensions here explicitely because the library method
        // polyfills a bug in the nuget package System.Memory for .NET Framework and
        // .NET Standard 2.0
        => span.IndexOfAny(values) != -1;

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

#if NET461 || NETSTANDARD2_0

    /// <summary>Indicates whether a read-only character span contains one of the Unicode
    /// characters that are passed to the method as a string.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="values">A <see cref="string"/> containing the characters to search for, or <c>null</c>.</param>
    /// <returns> <c>true</c> if <paramref name="span" /> contains one of the characters
    /// passed with <paramref name="values" />. If <paramref
    /// name="values" /> is <c>null</c> or empty, <c>false</c> is returned.</returns>
    /// <remarks> <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T},
    /// ReadOnlySpan{T})">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;)</see> 
    /// is used for the comparison.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAny(this ReadOnlySpan<char> span, string? values)
        => span.ContainsAny(values.AsSpan());

#endif
}

#endif