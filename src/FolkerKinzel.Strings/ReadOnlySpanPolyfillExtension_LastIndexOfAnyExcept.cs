using FolkerKinzel.Helpers.Polyfills;
using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanPolyfillExtension
{
    /// <summary>
    /// Searches for the last index of any character other than the specified <paramref name="values"/>.
    /// </summary>
    /// <param name="span">The span to search.</param>
    /// <param name="values">The characters to avoid.</param>
    /// <returns>The index in the span of the last occurrence of any character other than those in 
    /// <paramref name="values"/>. If all of the characters are in <paramref name="values"/>, returns -1.</returns>
    /// 
    /// <remarks>
    /// <note type="caution">
    /// This is a polyfill that does not have the performance benefits of System.Buffers.SearchValues&lt;T&gt;
    /// when used with framework versions lower than .NET 8.0.
    /// </note>
    /// </remarks>
    /// 
    /// <exception cref="ArgumentNullException"><paramref name="values"/> is <c>null</c>.</exception>
    public static int LastIndexOfAnyExcept(this ReadOnlySpan<char> span, SearchValuesPolyfill<char> values)
    {
        _ArgumentNullException.ThrowIfNull(values, nameof(values));
        return span.LastIndexOfAnyExcept(values.Value);
    }

    /// <summary>Returns the index of the last character in the 
    /// read-only span that is not equal to <paramref name="value"/>.</summary>
    /// <param name="span">The read-only span to search.</param>
    /// <param name="value">The <see cref="char"/> to avoid.</param>
    /// <returns>The index in the span of the last occurrence of any character other 
    /// than <paramref name="value"/>. If all of the characters are <paramref name="value"/>, 
    /// returns -1.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
#if NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET462
    public static int LastIndexOfAnyExcept(this ReadOnlySpan<char> span, char value)
    {
        // For performance reasons this has to be a separate method.

        int i;

        for (i = span.Length - 1; i >= 0; i--)
        {
            if (value != span[i])
            {
                break;
            }
        }

        return i;
    }
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOfAnyExcept(ReadOnlySpan<char> span, char value)
        => MemoryExtensions.LastIndexOfAnyExcept(span, value);
#endif

    /// <summary>
    /// Searches for the last index of any character other than the specified <paramref name="value0"/> 
    /// or <paramref name="value1"/>.
    /// </summary>
    /// <param name="span">The span to search.</param>
    /// <param name="value0">A character to avoid.</param>
    /// <param name="value1">A character to avoid.</param>
    /// <returns>The index in the span of the last occurrence of any character other than 
    /// <paramref name="value0"/> or <paramref name="value1"/>.
    /// If all of the characters are <paramref name="value0"/> or <paramref name="value1"/>,
    /// returns -1.</returns>
#if NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET462
    public static int LastIndexOfAnyExcept(this ReadOnlySpan<char> span, char value0, char value1)
     => LastIndexOfAnyExcept(span, stackalloc char[] { value0, value1 });
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOfAnyExcept(ReadOnlySpan<char> span, char value0, char value1)
       => MemoryExtensions.LastIndexOfAnyExcept(span, value0, value1);
#endif

    /// <summary>
    /// Searches for the last index of any character other than the specified <paramref name="value0"/>, 
    /// <paramref name="value1"/>, or <paramref name="value2"/>.
    /// </summary>
    /// <param name="span">The span to search.</param>
    /// <param name="value0">A character to avoid.</param>
    /// <param name="value1">A character to avoid.</param>
    /// <param name="value2">A character to avoid.</param>
    /// <returns>The index in the span of the last occurrence of any character other than 
    /// <paramref name="value0"/>, <paramref name="value1"/>, and <paramref name="value2"/>.
    /// If all of the characters are <paramref name="value0"/>, <paramref name="value1"/>, and 
    /// <paramref name="value2"/>, returns -1.</returns>
#if NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET462
    public static int LastIndexOfAnyExcept(this ReadOnlySpan<char> span, char value0, char value1, char value2)
     => LastIndexOfAnyExcept(span, stackalloc char[] { value0, value1, value2 });
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOfAnyExcept(ReadOnlySpan<char> span, char value0, char value1, char value2)
       => MemoryExtensions.LastIndexOfAnyExcept(span, value0, value1, value2);
#endif

    /// <summary>
    /// Searches for the last index of any character other than the specified <paramref name="values"/>.
    /// </summary>
    /// <param name="span">The span to search.</param>
    /// <param name="values">The characters to avoid.</param>
    /// <returns>The index in the span of the last occurrence of any character other than those in 
    /// <paramref name="values"/>. If all of the characters are in <paramref name="values"/>, returns -1.</returns>
#if NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET462
    public static int LastIndexOfAnyExcept(this ReadOnlySpan<char> span, ReadOnlySpan<char> values)
    {
        int i;

        for (i = span.Length - 1; i >= 0; i--)
        {
            if (!values.Contains(span[i]))
            {
                break;
            }
        }

        return i;
    }
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOfAnyExcept(ReadOnlySpan<char> span, ReadOnlySpan<char> values)
       => MemoryExtensions.LastIndexOfAnyExcept(span, values);
#endif

    /// <summary>
    /// Searches for the last index of any character other than the specified <paramref name="values"/>.
    /// </summary>
    /// <param name="span">The span to search.</param>
    /// <param name="values">A <see cref="string"/> containing the characters to avoid or <c>null</c>.</param>
    /// <returns>The index in the span of the last occurrence of any character other than those in 
    /// <paramref name="values"/>. If all of the characters are in <paramref name="values"/>, returns -1.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETSTANDARD2_0 || NET462
    public static int LastIndexOfAnyExcept(this ReadOnlySpan<char> span, string? values)
#else
    public static int LastIndexOfAnyExcept(ReadOnlySpan<char> span, string? values)
#endif
        => span.LastIndexOfAnyExcept(values.AsSpan());

}
