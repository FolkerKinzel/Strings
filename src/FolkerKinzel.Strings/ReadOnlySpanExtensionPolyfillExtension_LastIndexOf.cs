namespace FolkerKinzel.Strings;

#if NET461 || NETSTANDARD2_0

public static partial class ReadOnlySpanExtensionPolyfillExtension
{
    /// <summary>Specifies the zero based index position of the last occurrence of a specified
    /// string in <paramref name="span" />. The search begins at a specified character position
    /// and runs backwards to the beginning of the character span for a specified number
    /// of character positions. A parameter specifies the type of comparison to be performed
    /// when searching for the specified string.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="value">The <see cref="string" /> to search for, or <c>null</c>.</param>
    /// <param name="startIndex">The start index of the search. The search is done backwards
    /// to the beginning of <paramref name="span" />.</param>
    /// <param name="count">The number of character positions to examine.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies the rules
    /// for the comparison.</param>
    /// <returns>The zero-based start index of the <paramref name="value" /> parameter if
    /// this character sequence was found, or -1 if it was not found or <paramref name="span"
    /// /> is empty.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="count" /> is a negative value
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="span" /> is not <see cref="ReadOnlySpan{T}.Empty" />, and <paramref
    /// name="startIndex" /> is a negative value.
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="span" /> is not <see cref="ReadOnlySpan{T}.Empty" />, and <paramref
    /// name="startIndex" /> is greater than the length of <paramref name="span" />.
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="span" /> is not <see cref="ReadOnlySpan{T}.Empty" />, and <paramref
    /// name="startIndex" /> + 1 - <paramref name="count" /> indicates a position that is
    /// not within <paramref name="span" />.
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="span" /> is <see cref="ReadOnlySpan{T}.Empty" />, and <paramref name="startIndex"
    /// /> is less than -1 or greater than 0.
    /// </para>
    /// </exception>
    /// <exception cref="ArgumentException"> <paramref name="comparisonType" /> is not a
    /// defined value of the <see cref="StringComparison" /> enum.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOf(this ReadOnlySpan<char> span,
                                  string? value,
                                  int startIndex,
                                  int count,
                                  StringComparison comparisonType)
        => span.LastIndexOf(value.AsSpan(), startIndex, count, comparisonType);
}

#endif

