namespace FolkerKinzel.Strings;

public static partial class SpanPolyfillExtension
{
    /// <summary>Specifies the zero-based index of the last occurrence of a specified string
    /// in <paramref name="span" />. A parameter specifies the type of search for the specified
    /// string.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="value">The <see cref="string" /> to search for, or <c>null</c>.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies the rules
    /// for the comparison.</param>
    /// <returns>The zero-based index of <paramref name="value" /> if that string is found,
    /// or -1 if it is not.</returns>
    /// <exception cref="ArgumentException"> <paramref name="comparisonType" /> is not a
    /// defined value of the <see cref="StringComparison" /> enum.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET462 || NETSTANDARD2_0
    public static int LastIndexOf(
        this Span<char> span, string? value, StringComparison comparisonType)
#else
    public static int LastIndexOf(
        Span<char> span, string? value, StringComparison comparisonType)
#endif
        => ((ReadOnlySpan<char>)span).LastIndexOf(value.AsSpan(), comparisonType);

    /// <summary>Specifies the zero based index position of the last occurrence of a specified
    /// character sequence in <paramref name="span" />. The search begins at a specified
    /// character position and runs backwards to the beginning of the character span for
    /// a specified number of character positions. A parameter specifies the type of comparison
    /// to be performed when searching for the specified character sequence.</summary>
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
    /// 
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="span" /> is not <see cref="Span{T}.Empty" /> and <paramref name="startIndex" /> is less
    /// than zero or greater than or equal to the length of <paramref name="span" />
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="span" /> is not <see cref="Span{T}.Empty" /> and <paramref name="count"/> is negative or
    /// <paramref name="startIndex" /> - <paramref name="count" /> + 1 is less than zero.
    /// </para>
    /// </exception>
    /// 
    /// <exception cref="ArgumentException"> <paramref name="comparisonType" /> is not a
    /// defined value of the <see cref="StringComparison" /> enum.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET462 || NETSTANDARD2_0
    public static int LastIndexOf(this Span<char> span,
#else
    public static int LastIndexOf(Span<char> span,
#endif
                                  string? value,
                                  int startIndex,
                                  int count,
                                  StringComparison comparisonType)

        => ReadOnlySpanExtension.LastIndexOf(span,
                                             value.AsSpan(),
                                             startIndex,
                                             count,
                                             comparisonType);
}

