using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    /// <summary>Returns the zero-based index of the last occurrence of one of the specified
    /// characters in <paramref name="span" />. The search begins at a specified character
    /// position and runs a specified number of character positions backwards to the beginning
    /// of the <paramref name="span" />.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="values">A read-only character span that contains the characters to search
    /// for.</param>
    /// <param name="startIndex">The start index of the search. The search is done backwards
    /// to the beginning of <paramref name="span" />.</param>
    /// <param name="count">The number of characters positions to examine in <paramref name="span"
    /// />.</param>
    /// <returns>The zero-based index of the last occurrence of one of the specified Unicode
    /// characters in <paramref name="span" /> or -1 if none of these characters have been
    /// found.</returns>
    /// <remarks><see cref="MemoryExtensions.LastIndexOfAny{T}(ReadOnlySpan{T},
    /// ReadOnlySpan{T})">MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> is used for the comparison.</remarks>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="span"/> is not <see cref="ReadOnlySpan{T}.Empty"/> and
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <paramref name="startIndex" /> is less than zero or greater than or equal to the length of
    /// <paramref name="span" />
    /// </item>
    /// <item>
    /// - or -
    /// </item>
    /// <item>
    /// <paramref name="count"/> is negative or <paramref name="startIndex" /> - <paramref name="count" /> + 1 is less than zero.
    /// </item>
    /// </list>
    /// </exception>
    public static int LastIndexOfAny(this ReadOnlySpan<char> span,
                                     ReadOnlySpan<char> values,
                                     int startIndex,
                                     int count)
    {
        if (span.Length == 0)
        {
            return -1;
        }

        int matchIndex = span.Slice(startIndex - count + 1, count).LastIndexOfAny(values);
        return matchIndex == -1 ? -1 : matchIndex + startIndex - count + 1;
    }


    /// <summary>Returns the zero-based index of the last occurrence of one of the specified
    /// characters in <paramref name="span" />. The search begins at a specified character
    /// position and runs a specified number of character positions backwards to the beginning
    /// of the <paramref name="span" />.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="values">A set of Unicode characters to search
    /// for.</param>
    /// <param name="startIndex">The start index of the search. The search is done backwards
    /// to the beginning of <paramref name="span" />.</param>
    /// <param name="count">The number of characters positions to examine in <paramref name="span"
    /// />.</param>
    /// <returns>The zero-based index of the last occurrence of one of the specified Unicode
    /// characters in <paramref name="span" /> or -1 if none of these characters have been
    /// found.</returns>
    /// 
    /// <remarks>
    /// <note type="caution">
    /// In frameworks older than .NET 8.0, the method does not benefit from the performance benefits 
    /// of System.Buffers.SearchValues&lt;T&gt;.
    /// </note>
    /// </remarks>
    /// 
    /// <exception cref="ArgumentNullException"><paramref name="values"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="span"/> is not <see cref="ReadOnlySpan{T}.Empty"/> and
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <paramref name="startIndex" /> is less than zero or greater than or equal to the length of
    /// <paramref name="span" />
    /// </item>
    /// <item>
    /// - or -
    /// </item>
    /// <item>
    /// <paramref name="count"/> is negative or <paramref name="startIndex" /> - <paramref name="count" /> + 1 is less than zero.
    /// </item>
    /// </list>
    /// </exception>
    public static int LastIndexOfAny(this ReadOnlySpan<char> span,
                                     SearchValuesPolyfill<char> values,
                                     int startIndex,
                                     int count)
    {
        _ArgumentNullException.ThrowIfNull(values, nameof(values));

        if (span.Length == 0)
        {
            return -1;
        }

        int matchIndex = span.Slice(startIndex - count + 1, count).LastIndexOfAny(values.Value);
        return matchIndex == -1 ? -1 : matchIndex + startIndex - count + 1;
    }
}
