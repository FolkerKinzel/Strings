namespace FolkerKinzel.Strings;


public static partial class ReadOnlySpanPolyfillExtension
{
    /// <summary>Specifies the zero-based index of the last occurrence of a specified string
    /// in <paramref name="span" />. A parameter specifies the type of search for the specified
    /// string.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="value">The span to search for.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies the rules
    /// for the comparison.</param>
    /// <returns>The zero-based index of <paramref name="value" /> if that character sequence
    /// is found, or -1 if it is not. If <paramref name="value" /> is <see cref="ReadOnlySpan{T}.Empty"
    /// />, the last index position in <paramref name="span" /> is returned. In the specific
    /// case that <paramref name="span" /> is <see cref="ReadOnlySpan{T}.Empty" />, that
    /// is <c>0</c>.</returns>
    /// <remarks>
    /// The behavior of the method is identical to that of <see cref="string.LastIndexOf(string,
    /// StringComparison)" /> of the respective framework version. This has changed with .NET 5.0: Since 
    /// then <paramref name="span" />.Length is returned if value is <see cref="ReadOnlySpan{T}.Empty" />.
    /// </remarks>
    /// <exception cref="ArgumentException"> <paramref name="comparisonType" /> is not a
    /// defined value of the <see cref="StringComparison" /> enum.</exception>
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1
    public static int LastIndexOf(
        this ReadOnlySpan<char> span, ReadOnlySpan<char> value, StringComparison comparisonType)
        => value.IsEmpty
            ? span.IsEmpty ? 0 : span.Length - 1
            : comparisonType == StringComparison.Ordinal
                ? span.LastIndexOf(value)
                : span.ToString().LastIndexOf(value.ToString(), comparisonType);
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOf(
        ReadOnlySpan<char> span, ReadOnlySpan<char> value, StringComparison comparisonType)
        => MemoryExtensions.LastIndexOf(span, value, comparisonType);
#endif



    /// <summary>Specifies the zero-based index of the last occurrence of a specified string
    /// in <paramref name="span" />. A parameter specifies the type of search for the specified
    /// string.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="value">The <see cref="string" /> to search for, or <c>null</c>.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies the rules
    /// for the comparison.</param>
    /// <returns>The zero-based index of <paramref name="value" /> if that character sequence
    /// is found, or -1 if it is not. If <paramref name="value" /> is <see cref="P:System.String.Empty"
    /// /> or <c>null</c>, the last index position in <paramref name="span" /> is returned.
    /// In the specific case that <paramref name="span" /> is <see cref="ReadOnlySpan{T}.Empty"
    /// />, that is <c>0</c>.</returns>
    /// <remarks> 
    /// The behavior of the method is identical to that of <see cref="string.LastIndexOf(string,
    /// StringComparison)" /> of the respective framework version. This has changed with .NET 5.0: Since 
    /// then <paramref name="span" />.Length is returned if value is <see cref="ReadOnlySpan{T}.Empty" />.
    /// </remarks>
    /// <exception cref="ArgumentException"> <paramref name="comparisonType" /> is not a
    /// defined value of the <see cref="StringComparison" /> enum.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET461 || NETSTANDARD2_0
    public static int LastIndexOf(
        this ReadOnlySpan<char> span, string? value, StringComparison comparisonType)
#else
    public static int LastIndexOf(
        ReadOnlySpan<char> span, string? value, StringComparison comparisonType)
#endif
        => span.LastIndexOf(value.AsSpan(), comparisonType);

}

