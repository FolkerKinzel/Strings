using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class SpanPolyfillExtension
{
    /// <summary>
    /// Searches for the first index of any character other than the specified <paramref name="values"/>.
    /// </summary>
    /// <param name="span">The span to search.</param>
    /// <param name="values">The characters to avoid.</param>
    /// <returns>The index in the span of the first occurrence of any character other than those in 
    /// <paramref name="values"/>. If all of the characters are in <paramref name="values"/>, returns -1.</returns>
    /// 
    /// <remarks>
    /// <note type="caution">
    /// This is a polyfill that does not have the excellent performance of System.Buffers.SearchValues&lt;T&gt;
    /// when used with framework versions lower than .NET 8.0.
    /// </note>
    /// </remarks>
    /// 
    /// <exception cref="ArgumentNullException"><paramref name="values"/> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAnyExcept(this Span<char> span, SearchValuesPolyfill<char> values)
        => ReadOnlySpanPolyfillExtension.IndexOfAnyExcept(span, values);

    /// <summary>Returns the index of the first character in the 
    /// span that is not equal to <paramref name="value"/>.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="value">The <see cref="char"/> to avoid.</param>
    /// <returns>The index in the span of the first occurrence of any character other 
    /// than <paramref name="value"/>. If all of the characters are <paramref name="value"/>, 
    /// returns -1.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET462
    public static int IndexOfAnyExcept(this Span<char> span, char value)
        => ReadOnlySpanPolyfillExtension.IndexOfAnyExcept(span, value);
#else
    public static int IndexOfAnyExcept(Span<char> span, char value)
        => MemoryExtensions.IndexOfAnyExcept((ReadOnlySpan<char>)span, value);
#endif

    /// <summary>
    /// Searches for the first index of any character other than the specified <paramref name="value0"/> 
    /// or <paramref name="value1"/>.
    /// </summary>
    /// <param name="span">The span to search.</param>
    /// <param name="value0">A character to avoid.</param>
    /// <param name="value1">A character to avoid.</param>
    /// <returns>The index in the span of the first occurrence of any character other than 
    /// <paramref name="value0"/> or <paramref name="value1"/>.
    /// If all of the characters are <paramref name="value0"/> or <paramref name="value1"/>,
    /// returns -1.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET462
    public static int IndexOfAnyExcept(this Span<char> span, char value0, char value1)
     => ReadOnlySpanPolyfillExtension.IndexOfAnyExcept(span, value0, value1);
#else
    public static int IndexOfAnyExcept(Span<char> span, char value0, char value1)
     => MemoryExtensions.IndexOfAnyExcept((ReadOnlySpan<char>)span, value0, value1);
#endif

    /// <summary>
    /// Searches for the first index of any character other than the specified <paramref name="value0"/>, 
    /// <paramref name="value1"/>, or <paramref name="value2"/>.
    /// </summary>
    /// <param name="span">The span to search.</param>
    /// <param name="value0">A character to avoid.</param>
    /// <param name="value1">A character to avoid.</param>
    /// <param name="value2">A character to avoid.</param>
    /// <returns>The index in the span of the first occurrence of any character other than 
    /// <paramref name="value0"/>, <paramref name="value1"/>, and <paramref name="value2"/>.
    /// If all of the characters are <paramref name="value0"/>, <paramref name="value1"/>, and 
    /// <paramref name="value2"/>, returns -1.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET462
    public static int IndexOfAnyExcept(this Span<char> span, char value0, char value1, char value2)
     => ReadOnlySpanPolyfillExtension.IndexOfAnyExcept(span, value0, value1, value2);
#else
    public static int IndexOfAnyExcept(Span<char> span, char value0, char value1, char value2)
     => MemoryExtensions.IndexOfAnyExcept((ReadOnlySpan<char>)span, value0, value1, value2);
#endif

    /// <summary>
    /// Searches for the first index of any character other than the specified <paramref name="values"/>.
    /// </summary>
    /// <param name="span">The span to search.</param>
    /// <param name="values">The characters to avoid.</param>
    /// <returns>The index in the span of the first occurrence of any character other than those in 
    /// <paramref name="values"/>. If all of the characters are in <paramref name="values"/>, returns -1.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET462
    public static int IndexOfAnyExcept(this Span<char> span, ReadOnlySpan<char> values)
    => ReadOnlySpanPolyfillExtension.IndexOfAnyExcept(span, values);
#else
    public static int IndexOfAnyExcept(Span<char> span, ReadOnlySpan<char> values)
    => MemoryExtensions.IndexOfAnyExcept((ReadOnlySpan<char>)span, values);
#endif

    /// <summary>
    /// Searches for the first index of any character other than the specified <paramref name="values"/>.
    /// </summary>
    /// <param name="span">The span to search.</param>
    /// <param name="values">A <see cref="string"/> containing the characters to avoid or <c>null</c>.</param>
    /// <returns>The index in the span of the first occurrence of any character other than those in 
    /// <paramref name="values"/>. If all of the characters are in <paramref name="values"/>, returns -1.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETSTANDARD2_0 || NET462
    public static int IndexOfAnyExcept(this Span<char> span, string? values)
#else
    public static int IndexOfAnyExcept(Span<char> span, string? values)
#endif
        => ((ReadOnlySpan<char>)span).IndexOfAnyExcept(values);
}

