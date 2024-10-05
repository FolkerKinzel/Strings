namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanPolyfillExtension
{
    /// <summary>
    /// Searches for any character other than the specified <paramref name="values"/>.
    /// </summary>
    /// <param name="span">The span to search.</param>
    /// <param name="values">A set of characters to avoid.</param>
    /// <returns><c>true</c> if any character other than those in <paramref name="values"/> is present in the span. 
    /// If all of the characters are in <paramref name="values"/>, returns <c>false</c>.
    /// </returns>
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
    public static bool ContainsAnyExcept(this ReadOnlySpan<char> span, SearchValuesPolyfill<char> values)
        => span.IndexOfAnyExcept(values) != -1;

    /// <summary>Searches for any character other than the specified <paramref name="values"/>.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="values">A read-only character span that contains the characters to avoid.</param>
    /// <returns><c>true</c> if any character other than those in <paramref name="values"/> is present in the span. 
    /// If all of the characters are in <paramref name="values"/>, returns <c>false</c>.
    /// </returns>
#if NET7_0 || NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET461
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAnyExcept(this ReadOnlySpan<char> span, ReadOnlySpan<char> values)
        => span.IndexOfAnyExcept(values) != -1;
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAnyExcept(ReadOnlySpan<char> span, ReadOnlySpan<char> values)
        => MemoryExtensions.ContainsAnyExcept(span, values);
#endif

    /// <summary>Searches for any character other than <paramref name="value"/>.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="value">The character to avoid.</param>
    /// <returns> <c>true</c> if any character other than <paramref name="value"/> is present in the span.
    /// If all of the characters are <paramref name="value"/>, returns <c>false</c>.</returns>
#if NET7_0 || NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET461
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAnyExcept(this ReadOnlySpan<char> span, char value)
        => span.IndexOfAnyExcept(value) != -1;
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAnyExcept(ReadOnlySpan<char> span, char value)
        => MemoryExtensions.ContainsAnyExcept(span, value);
#endif

    /// <summary>Searches for any character other than <paramref name="value0"/> or <paramref name="value1"/>.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="value0">A character to avoid.</param>
    /// <param name="value1">A character to avoid.</param>
    /// <returns> <c>true</c> if any character other than <paramref name="value0"/> or <paramref name="value1"/>
    /// is present in the span.
    /// If all of the characters are <paramref name="value0"/> or <paramref name="value1"/>, returns <c>false</c>.</returns>
#if NET7_0 || NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET461
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAnyExcept(this ReadOnlySpan<char> span, char value0, char value1)
        => span.IndexOfAnyExcept(value0, value1) != -1;
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAnyExcept(ReadOnlySpan<char> span, char value0, char value1)
        => MemoryExtensions.ContainsAnyExcept(span, value0, value1);
#endif

    /// <summary>Indicates whether a character span contains one of the three characters
    /// that are passed to the method as arguments.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="value0">A character to avoid.</param>
    /// <param name="value1">A character to avoid.</param>
    /// <param name="value2">A character to avoid.</param>
    /// <returns> <c>true</c> if any character other than <paramref name="value0"/>, <paramref name="value1"/>,
    /// and <paramref name="value2"/> is present in the span.
    /// If all of the characters are <paramref name="value0"/>, <paramref name="value1"/>,
    /// and <paramref name="value2"/>, returns <c>false</c>.</returns>
#if NET7_0 || NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET461
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAnyExcept(this ReadOnlySpan<char> span, char value0, char value1, char value2)
        => span.IndexOfAnyExcept(value0, value1, value2) != -1;
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAnyExcept(ReadOnlySpan<char> span, char value0, char value1, char value2)
        => MemoryExtensions.ContainsAnyExcept(span, value0, value1, value2);
#endif

    /// <summary>Searches for any character other than the specified <paramref name="values"/>.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="values">A <see cref="string"/> containing the characters to avoid, or <c>null</c>.</param>
    /// <returns><c>true</c> if any character other than those in <paramref name="values"/> is present in the span. 
    /// If all of the characters are in <paramref name="values"/>, returns <c>false</c>.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET461 || NETSTANDARD2_0
    public static bool ContainsAnyExcept(this ReadOnlySpan<char> span, string? values)
#else
    public static bool ContainsAnyExcept(ReadOnlySpan<char> span, string? values)
#endif
        => span.ContainsAnyExcept(values.AsSpan());
}

