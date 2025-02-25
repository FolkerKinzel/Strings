namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    /// <summary>Specifies the zero based index position of the last occurrence of a specified
    /// character sequence in <paramref name="span" />. The search begins at a specified
    /// character position and runs backwards to the beginning of the character span for
    /// a specified number of character positions. A parameter specifies the type of comparison
    /// to be performed when searching for the specified character sequence.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="value">The character span to search for.</param>
    /// <param name="startIndex">The start index of the search. The search is done backwards
    /// to the beginning of <paramref name="span" />.</param>
    /// <param name="count">The number of character positions to examine.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies the rules
    /// for the comparison.</param>
    /// <returns>The zero-based start index of the <paramref name="value" /> parameter if
    /// this character sequence was found, or -1 if it was not found or <paramref name="span"
    /// /> is empty.</returns>
    /// 
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="span" /> is not <see cref="ReadOnlySpan{T}.Empty" /> and <paramref name="startIndex" /> is less
    /// than zero or greater than or equal to the length of <paramref name="span" />
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="span" /> is not <see cref="ReadOnlySpan{T}.Empty" /> and <paramref name="count"/> is negative or
    /// <paramref name="startIndex" /> - <paramref name="count" /> + 1 is less than zero.
    /// </para>
    /// </exception>
    /// 
    /// 
    /// <exception cref="ArgumentException"> <paramref name="comparisonType" /> is not 
    /// a defined value of the <see cref="StringComparison" /> enum.</exception>
    public static int LastIndexOf(this ReadOnlySpan<char> span,
                                  ReadOnlySpan<char> value,
                                  int startIndex,
                                  int count,
                                  StringComparison comparisonType)
    {
        if (span.Length == 0)
        {
            return -1;
        }

        if ((uint)startIndex >= (uint)span.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex));
        }

        if ((uint)count > (uint)startIndex + 1)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex));
        }


        startIndex = startIndex - count + 1;

        int matchIndex = span.Slice(startIndex, count).LastIndexOf(value, comparisonType);
        return matchIndex == -1 ? -1 : matchIndex + startIndex;
    }
}
