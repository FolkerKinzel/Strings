using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    /// <summary>
    /// Removes all leading and trailing occurrences of a set of characters specified in a
    /// <see cref="SearchValues{T}">SearchValues&lt;Char&gt;</see> instance from a character span.
    /// </summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="values">The <see cref="SearchValues{T}">SearchValues&lt;Char&gt;</see> instance, which 
    /// specifies the set of characters to remove.</param>
    /// <returns>The trimmed character span.</returns>
    /// <remarks>If <paramref name="values"/> is empty, the method returns <paramref name="span"/> unchanged.</remarks>
    /// 
    /// <exception cref="ArgumentNullException"><paramref name="values"/> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> Trim(this Span<char> span, SearchValues<char> values)
        => span.TrimStart(values).TrimEnd(values);

    /// <summary>
    /// Removes all leading occurrences of a set of characters specified in a
    /// <see cref="SearchValues{T}">SearchValues&lt;Char&gt;</see> instance from a character span.
    /// </summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="values">The <see cref="SearchValues{T}">SearchValues&lt;Char&gt;</see> instance, which 
    /// specifies the set of characters to remove.</param>
    /// <returns>The trimmed character span.</returns>
    /// <remarks>If <paramref name="values"/> is empty, the method returns <paramref name="span"/> unchanged.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="values"/> is <c>null</c>.</exception>
    public static Span<char> TrimStart(this Span<char> span, SearchValues<char> values)
    {
        int idx = span.IndexOfAnyExcept(values);
        return idx == -1 ? [] : span.Slice(idx);
    }

    /// <summary>
    /// Removes all trailing occurrences of a set of characters specified in a
    /// <see cref="SearchValues{T}">SearchValues&lt;Char&gt;</see> instance from a character span.
    /// </summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="values">The <see cref="SearchValues{T}">SearchValues&lt;Char&gt;</see> instance, which 
    /// specifies the set of characters to remove.</param>
    /// <returns>The trimmed character span.</returns>
    /// <remarks>If <paramref name="values"/> is empty, the method returns <paramref name="span"/> unchanged.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="values"/> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> TrimEnd(this Span<char> span, SearchValues<char> values)
        => span.Slice(0, span.LastIndexOfAnyExcept(values) + 1);

}


