namespace FolkerKinzel.Strings;

public static partial class SpanPolyfillExtension
{
    /// <summary>
    /// Searches for an occurrence of any of the specified characters and returns <c>true</c> 
    /// if found. If not found, returns <c>false</c>.
    /// </summary>
    /// <param name="span">The span to search.</param>
    /// <param name="values">The set of characters to search for.</param>
    /// <returns><c>true</c> if any of the specified characters have been found. 
    /// If not, returns <c>false</c>.</returns>
    /// 
    /// <remarks>
    /// <note type="caution">
    /// This is a polyfill that does not have the performance benefits of System.Buffers.SearchValues&lt;T&gt;
    /// when used with framework versions lower than .NET 8.0.
    /// </note>
    /// </remarks>
    /// 
    /// <exception cref="ArgumentNullException"><paramref name="values"/> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAny(this Span<char> span, SearchValuesPolyfill<char> values)
        => ReadOnlySpanPolyfillExtension.IndexOfAny(span, values) != -1;

    /// <summary>Indicates whether a character span contains one of the Unicode characters
    /// that are passed to the method as a read-only character span.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="values">A read-only character span that contains the characters to search
    /// for.</param>
    /// <returns> <c>true</c> if <paramref name="span" /> contains one of the characters
    /// passed with <paramref name="values" />. If <paramref
    /// name="values" /> is empty, <c>false</c> is returned.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET7_0 || NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET462
    public static bool ContainsAny(this Span<char> span, ReadOnlySpan<char> values)
        // Don't use MemoryExtensions here directly because this method polyfills
        // a bug in the System.Memory package for NET462 and NETSTANDARD2_0 
        => ReadOnlySpanPolyfillExtension.IndexOfAny(span, values) != -1;
#else
    public static bool ContainsAny(Span<char> span, ReadOnlySpan<char> values)
        => MemoryExtensions.ContainsAny((ReadOnlySpan<char>)span, values);
#endif

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
#if NET7_0 || NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET462
    public static bool ContainsAny(this Span<char> span, char value0, char value1)
        => MemoryExtensions.IndexOfAny((ReadOnlySpan<char>)span, value0, value1) != -1;
#else
    public static bool ContainsAny(Span<char> span, char value0, char value1)
        => MemoryExtensions.ContainsAny((ReadOnlySpan<char>)span, value0, value1);
#endif

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
#if NET7_0 || NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET462
    public static bool ContainsAny(
        this Span<char> span, char value0, char value1, char value2)
        => MemoryExtensions.IndexOfAny((ReadOnlySpan<char>)span, value0, value1, value2) != -1;
#else
    public static bool ContainsAny(
        Span<char> span, char value0, char value1, char value2)
        => MemoryExtensions.ContainsAny((ReadOnlySpan<char>)span, value0, value1, value2);
#endif

    /// <summary>Indicates whether a character span contains one of the Unicode characters
    /// that are passed to the method as a string.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="values">A string containing the characters to search for, or <c>null</c>.</param>
    /// <returns> <c>true</c> if <paramref name="span" /> contains one of the characters
    /// passed with <paramref name="values" />. If <paramref
    /// name="values" /> is <c>null</c> or empty, <c>false</c> is returned.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET462 || NETSTANDARD2_0
    public static bool ContainsAny(this Span<char> span, string? values)
#else
    public static bool ContainsAny(Span<char> span, string? values)
#endif
        => ((ReadOnlySpan<char>)span).ContainsAny(values.AsSpan());
}