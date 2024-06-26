using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

#if NET7_0 || NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET461

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
    /// This is a polyfill that does not have the performance benefits of System.Buffers.SearchValues&lt;T&gt;.
    /// </note>
    /// </remarks>
    /// 
    /// <exception cref="ArgumentNullException"><paramref name="values"/> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAnyExcept(this Span<char> span, SearchValues<char> values)
     => ((ReadOnlySpan<char>)span).IndexOfAnyExcept(values);

#if NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET461

    /// <summary>Returns the index of the first character in the 
    /// span that is not equal to <paramref name="value"/>.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="value">The <see cref="char"/> to avoid.</param>
    /// <returns>The index in the span of the first occurrence of any character other 
    /// than <paramref name="value"/>. If all of the characters are <paramref name="value"/>, 
    /// returns -1.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAnyExcept(this Span<char> span, char value)
        =>((ReadOnlySpan<char>)span).IndexOfAnyExcept(value);

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
    public static int IndexOfAnyExcept(this Span<char> span, char value0, char value1)
     => ((ReadOnlySpan<char>)span).IndexOfAnyExcept(value0, value1);

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
    public static int IndexOfAnyExcept(this Span<char> span, char value0, char value1, char value2)
     => ((ReadOnlySpan<char>)span).IndexOfAnyExcept(value0, value1, value2);

    /// <summary>
    /// Searches for the first index of any character other than the specified <paramref name="values"/>.
    /// </summary>
    /// <param name="span">The span to search.</param>
    /// <param name="values">The characters to avoid.</param>
    /// <returns>The index in the span of the first occurrence of any character other than those in 
    /// <paramref name="values"/>. If all of the characters are in <paramref name="values"/>, returns -1.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAnyExcept(this Span<char> span, ReadOnlySpan<char> values)
    => ((ReadOnlySpan<char>)span).IndexOfAnyExcept(values);

#if NETSTANDARD2_0 || NET461

    /// <summary>
    /// Searches for the first index of any character other than the specified <paramref name="values"/>.
    /// </summary>
    /// <param name="span">The span to search.</param>
    /// <param name="values">A <see cref="string"/> containing the characters to avoid or <c>null</c>.</param>
    /// <returns>The index in the span of the first occurrence of any character other than those in 
    /// <paramref name="values"/>. If all of the characters are in <paramref name="values"/>, returns -1.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAnyExcept(this Span<char> span, string? values)
        => ((ReadOnlySpan<char>)span).IndexOfAnyExcept(values);

#endif
#endif
}

#endif
