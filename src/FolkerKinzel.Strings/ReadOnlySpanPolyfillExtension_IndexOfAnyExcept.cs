using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;


public static partial class ReadOnlySpanPolyfillExtension
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
#if NET7_0 || NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET461
    public static int IndexOfAnyExcept(this ReadOnlySpan<char> span, SearchValues<char> values)
    {
        _ArgumentNullException.ThrowIfNull(values, nameof(values));
        return span.IndexOfAnyExcept(values.Span);
    }
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAnyExcept(ReadOnlySpan<char> span, SearchValues<char> values)
    => MemoryExtensions.IndexOfAnyExcept(span, values);
#endif


    /// <summary>Returns the index of the first character in the 
    /// read-only span that is not equal to <paramref name="value"/>.</summary>
    /// <param name="span">The read-only span to search.</param>
    /// <param name="value">The <see cref="char"/> to avoid.</param>
    /// <returns>The index in the span of the first occurrence of any character other 
    /// than <paramref name="value"/>. If all of the characters are <paramref name="value"/>, 
    /// returns -1.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
#if NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET461
    public static int IndexOfAnyExcept(this ReadOnlySpan<char> span, char value)
    {
        // For performance reasons this is a separate method.
        for (int i = 0; i < span.Length; i++)
        {
            if (value != span[i])
            {
                return i;
            }
        }

        return -1;
    }
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAnyExcept(ReadOnlySpan<char> span, char value)
        => MemoryExtensions.IndexOfAnyExcept(span, value);
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
#if NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET461
    public static int IndexOfAnyExcept(this ReadOnlySpan<char> span, char value0, char value1)
     => span.IndexOfAnyExcept(stackalloc char[] { value0, value1});
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAnyExcept(ReadOnlySpan<char> span, char value0, char value1)
        => MemoryExtensions.IndexOfAnyExcept(span, value0, value1);
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
#if NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET461
    public static int IndexOfAnyExcept(this ReadOnlySpan<char> span, char value0, char value1, char value2)
     => span.IndexOfAnyExcept(stackalloc char[] { value0, value1, value2 });
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAnyExcept(ReadOnlySpan<char> span, char value0, char value1, char value2)
    => MemoryExtensions.IndexOfAnyExcept(span, value0, value1, value2);
#endif

    /// <summary>
    /// Searches for the first index of any character other than the specified <paramref name="values"/>.
    /// </summary>
    /// <param name="span">The span to search.</param>
    /// <param name="values">The characters to avoid.</param>
    /// <returns>The index in the span of the first occurrence of any character other than those in 
    /// <paramref name="values"/>. If all of the characters are in <paramref name="values"/>, returns -1.</returns>
#if NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET461
    public static int IndexOfAnyExcept(this ReadOnlySpan<char> span, ReadOnlySpan<char> values)
    {
        for (int i = 0; i < span.Length; i++)
        {
            if (!values.Contains(span[i]))
            {
                return i;
            }
        }

        return -1;
    }
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAnyExcept(ReadOnlySpan<char> span, ReadOnlySpan<char> values)
        => MemoryExtensions.IndexOfAnyExcept(span, values);
#endif


    /// <summary>
    /// Searches for the first index of any character other than the specified <paramref name="values"/>.
    /// </summary>
    /// <param name="span">The span to search.</param>
    /// <param name="values">A <see cref="string"/> containing the characters to avoid or <c>null</c>.</param>
    /// <returns>The index in the span of the first occurrence of any character other than those in 
    /// <paramref name="values"/>. If all of the characters are in <paramref name="values"/>, returns -1.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETSTANDARD2_0 || NET461
    public static int IndexOfAnyExcept(this ReadOnlySpan<char> span, string? values)
#else
    public static int IndexOfAnyExcept(ReadOnlySpan<char> span, string? values)
#endif
        => span.IndexOfAnyExcept(values.AsSpan());

}

