using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    /// <summary>
    /// Removes all leading and trailing occurrences of a set of characters specified in a
    /// <see cref="SearchValuesPolyfill{T}">SearchValuesPolyfill&lt;Char&gt;</see> instance from a read-only character span.
    /// </summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="values">The <see cref="SearchValuesPolyfill{T}">SearchValuesPolyfill&lt;Char&gt;</see> instance, which 
    /// specifies the set of characters to remove.</param>
    /// <returns>The trimmed read-only character span.</returns>
    /// <remarks>If <paramref name="values"/> is empty, the method returns <paramref name="span"/> unchanged.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="values"/> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlySpan<char> Trim(this ReadOnlySpan<char> span, SearchValuesPolyfill<char> values)
        => span.TrimStart(values).TrimEnd(values);

    /// <summary>
    /// Removes all leading occurrences of a set of characters specified in a
    /// <see cref="SearchValuesPolyfill{T}">SearchValuesPolyfill&lt;Char&gt;</see> instance from a read-only character span.
    /// </summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="values">The <see cref="SearchValuesPolyfill{T}">SearchValuesPolyfill&lt;Char&gt;</see> instance, which 
    /// specifies the set of characters to remove.</param>
    /// <returns>The trimmed read-only character span.</returns>
    /// <remarks>If <paramref name="values"/> is empty, the method returns <paramref name="span"/> unchanged.</remarks>
    /// 
    /// <exception cref="ArgumentNullException"><paramref name="values"/> is <c>null</c>.</exception>
    public static ReadOnlySpan<char> TrimStart(this ReadOnlySpan<char> span, SearchValuesPolyfill<char> values)
    {
        _ArgumentNullException.ThrowIfNull(values, nameof(values));
        int idx = span.IndexOfAnyExcept(values.Value);
        return idx == -1 ? [] : span.Slice(idx);
    }

    /// <summary>
    /// Removes all trailing occurrences of a set of characters specified in a
    /// <see cref="SearchValuesPolyfill{T}">SearchValuesPolyfill&lt;Char&gt;</see> instance from a read-only character span.
    /// </summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="values">The <see cref="FolkerKinzel.Strings.SearchValuesPolyfill{T}">SearchValuesPolyfill&lt;Char&gt;</see> 
    /// instance, which specifies the set of characters to remove.</param>
    /// <returns>The trimmed read-only character span.</returns>
    /// <remarks>If <paramref name="values"/> is empty, the method returns <paramref name="span"/> unchanged.</remarks>
    /// 
    /// <exception cref="ArgumentNullException"><paramref name="values"/> is <c>null</c>.</exception>
    public static ReadOnlySpan<char> TrimEnd(this ReadOnlySpan<char> span, SearchValuesPolyfill<char> values)
    {
        _ArgumentNullException.ThrowIfNull(values, nameof(values));
        return span.Slice(0, span.LastIndexOfAnyExcept(values.Value) + 1);
    }
}


