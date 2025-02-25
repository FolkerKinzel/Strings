namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    /// <summary>
    /// Removes all leading and trailing occurrences of a set of characters specified in a
    /// <see cref="SearchValuesPolyfill{T}">SearchValuesPolyfill&lt;Char&gt;</see> instance from a character span.
    /// </summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="values">The <see cref="SearchValuesPolyfill{T}">SearchValuesPolyfill&lt;Char&gt;</see> instance, which 
    /// specifies the set of characters to remove.</param>
    /// <returns>The trimmed character span.</returns>
    /// <remarks>If <paramref name="values"/> is empty, the method returns <paramref name="span"/> unchanged.</remarks>
    /// 
    /// <exception cref="ArgumentNullException"><paramref name="values"/> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> Trim(this Span<char> span, SearchValuesPolyfill<char> values)
        => span.TrimStart(values).TrimEnd(values);

    /// <summary>
    /// Removes all leading occurrences of a set of characters specified in a
    /// <see cref="SearchValuesPolyfill{T}">SearchValuesPolyfill&lt;Char&gt;</see> instance from a character span.
    /// </summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="values">The <see cref="SearchValuesPolyfill{T}">SearchValuesPolyfill&lt;Char&gt;</see> instance, which 
    /// specifies the set of characters to remove.</param>
    /// <returns>The trimmed character span.</returns>
    /// <remarks>If <paramref name="values"/> is empty, the method returns <paramref name="span"/> unchanged.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="values"/> is <c>null</c>.</exception>
    public static Span<char> TrimStart(this Span<char> span, SearchValuesPolyfill<char> values)
    {
        _ArgumentNullException.ThrowIfNull(values, nameof(values));
        int idx = ((ReadOnlySpan<char>)span).IndexOfAnyExcept(values.Value);
        return idx == -1 ? [] : span.Slice(idx);
    }

    /// <summary>
    /// Removes all trailing occurrences of a set of characters specified in a
    /// <see cref="SearchValuesPolyfill{T}">SearchValuesPolyfill&lt;Char&gt;</see> instance from a character span.
    /// </summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="values">The <see cref="SearchValuesPolyfill{T}">SearchValuesPolyfill&lt;Char&gt;</see> instance, which 
    /// specifies the set of characters to remove.</param>
    /// <returns>The trimmed character span.</returns>
    /// <remarks>If <paramref name="values"/> is empty, the method returns <paramref name="span"/> unchanged.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="values"/> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> TrimEnd(this Span<char> span, SearchValuesPolyfill<char> values)
    {
        _ArgumentNullException.ThrowIfNull(values, nameof(values));
        return span.Slice(0, ((ReadOnlySpan<char>)span).LastIndexOfAnyExcept(values.Value) + 1);
    }
}


