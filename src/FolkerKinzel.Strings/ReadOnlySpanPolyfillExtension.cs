namespace FolkerKinzel.Strings;


/// <summary>Extension methods for the <see cref="ReadOnlySpan{T}">ReadOnlySpan&lt;Char&gt;</see>
/// struct, which are used in .NET Framework 4.5, .NET Standard 2.0 and .NET Standard
/// 2.1 as polyfills for methods from current .NET versions.</summary>
/// <remarks>The methods of this class should only be used in the extension method syntax
/// to simulate the methods of the <see cref="ReadOnlySpan{T}">ReadOnlySpan&lt;Char&gt;</see>
/// struct, which exist in more modern frameworks.</remarks>
public static class ReadOnlySpanPolyfillExtension
{
    // Place this preprocessor directive inside the class to let .NET 6.0 and above have an empty class!
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1

    /// <summary>Indicates whether a read-only character span contains the Unicode character
    /// that is passed to the method as argument.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> has been found, <c>false</c> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(this ReadOnlySpan<char> span, char value)
        => span.IndexOf(value) != -1;

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
    public static int LastIndexOf(
        this ReadOnlySpan<char> span, ReadOnlySpan<char> value, StringComparison comparisonType)
        => value.IsEmpty
            ? span.IsEmpty ? 0 : span.Length - 1
            : comparisonType == StringComparison.Ordinal
                ? span.LastIndexOf(value)
                : span.ToString().LastIndexOf(value.ToString(), comparisonType);
#endif

#if NET461 || NETSTANDARD2_0

    /// <summary>Determines whether this <paramref name="span" /> and the specified other
    /// <paramref name="other" />&#160;<see cref="string" /> have the same characters when
    /// compared using the specified <paramref name="comparisonType" /> option.</summary>
    /// <param name="span">The source span.</param>
    /// <param name="other">The value to compare with the source span.</param>
    /// <param name="comparisonType">An enumeration value that determines how <paramref name="span"
    /// /> and <paramref name="other" /> are compared.</param>
    /// <returns> <c>true</c> if identical, <c>false</c> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Equals(
        this ReadOnlySpan<char> span, string? other, StringComparison comparisonType) 
        => span.Equals(other.AsSpan(), comparisonType);

    /// <summary>Indicates whether a specified value occurs within a read-only character
    /// span.</summary>
    /// <param name="span">The source span.</param>
    /// <param name="value">The value to seek within the source span. <paramref name="value"
    /// /> can be <c>null</c>.</param>
    /// <param name="comparisonType">An enumeration value that determines how <paramref name="span"
    /// /> and <paramref name="value" /> are compared.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> has been found, <c>false</c> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(
        this ReadOnlySpan<char> span, string? value, StringComparison comparisonType)
        => span.Contains(value.AsSpan(), comparisonType);

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
    public static int LastIndexOf(
        this ReadOnlySpan<char> span, string? value, StringComparison comparisonType)
        => span.LastIndexOf(value.AsSpan(), comparisonType);

    /// <summary>Indicates whether a read-only span of characters starts with the specified
    /// <see cref="string" />.</summary>
    /// <param name="span">The source span.</param>
    /// <param name="value">The <see cref="string" /> to compare with the beginning of the
    /// source span.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> matches the beginning of <paramref
    /// name="span" />, otherwise <c>false</c>.</returns>
    /// <remarks>The method performs an ordinal character comparison. If <paramref name="value"
    /// /> is <c>null</c> or <see cref="string.Empty" /> the method returns <c>true</c>.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool StartsWith(this ReadOnlySpan<char> span, string? value)
        => span.StartsWith(value.AsSpan());

    /// <summary>Indicates whether a read-only character span begins with a specified <see
    /// cref="string" /> when compared using a specified <see cref="StringComparison" />
    /// value.</summary>
    /// <param name="span">The source span.</param>
    /// <param name="value">The <see cref="string" /> to compare with the beginning of the
    /// source span.</param>
    /// <param name="comparisonType">An enumeration value that determines how <paramref name="span"
    /// /> and <paramref name="value" /> are compared.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> matches the beginning of <paramref
    /// name="span" />, otherwise <c>false</c>.</returns>
    /// <remarks>If <paramref name="value" /> is <c>null</c> or <see cref="string.Empty"
    /// /> the method returns <c>true</c>.</remarks>
    /// <exception cref="ArgumentException"> <paramref name="comparisonType" /> is not a
    /// defined value of the <see cref="StringComparison" /> enum.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool StartsWith(
        this ReadOnlySpan<char> span, string? value, StringComparison comparisonType)
        => span.StartsWith(value.AsSpan(), comparisonType);

    /// <summary>Indicates whether <paramref name="span" /> ends with the specified <see cref="string"
    /// />.</summary>
    /// <param name="span">The source span.</param>
    /// <param name="value">The <see cref="string" /> to compare with the end of the source
    /// span.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> matches the end of <paramref name="span"
    /// />, otherwise <c>false</c>.</returns>
    /// <remarks>The method performs an ordinal character comparison. If <paramref name="value"
    /// /> is <c>null</c> or <see cref="string.Empty" /> the method returns <c>true</c>.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EndsWith(this ReadOnlySpan<char> span, string? value)
        => span.EndsWith(value.AsSpan());

    /// <summary>Indicates whether a read-only character span ends with a specified <see
    /// cref="string" /> when compared using a specified <see cref="StringComparison" />
    /// value.</summary>
    /// <param name="span">The source span.</param>
    /// <param name="value">The <see cref="string" /> to compare with the end of the source
    /// span.</param>
    /// <param name="comparisonType">An enumeration value that determines how <paramref name="span"
    /// /> and <paramref name="value" /> are compared.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> matches the end of <paramref name="span"
    /// />, otherwise <c>false</c>.</returns>
    /// <remarks>If <paramref name="value" /> is <c>null</c> or <see cref="string.Empty"
    /// /> the method returns <c>true</c>.</remarks>
    /// <exception cref="ArgumentException"> <paramref name="comparisonType" /> is not a
    /// defined value of the <see cref="StringComparison" /> enum.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EndsWith(
        this ReadOnlySpan<char> span, string? value, StringComparison comparisonType)
        => span.EndsWith(value.AsSpan(), comparisonType);

    /// <summary>
    /// Reports the zero-based index of the first occurrence of the specified 
    /// <paramref name="value"/> in the current <paramref name="span"/>.
    /// </summary>
    /// <param name="span">The source span.</param>
    /// <param name="value">The value to seek within the source span.</param>
    /// <param name="comparisonType">An enumeration value that determines how 
    /// <paramref name="span"/> and <paramref name="value"/> are compared.</param>
    /// <returns>The index of the first occurrence of <paramref name="value"/> in the 
    /// <paramref name="span"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOf(
        this ReadOnlySpan<char> span, string? value, StringComparison comparisonType)
        => span.IndexOf(value.AsSpan(), comparisonType);

    /// <summary>
    /// Removes all leading and trailing occurrences of a set of characters specified in a <see cref="string"/>
    /// from a read-only character span.
    /// </summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="trimChars">The <see cref="string"/> which contains the set of characters to remove or <c>null</c>
    /// to remove whitespace characters.</param>
    /// <returns>The trimmed read-only character span.</returns>
    /// <remarks>
    /// If <paramref name="trimChars"/> is <c>null</c> or empty, whitespace characters are removed instead.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlySpan<char> Trim(this ReadOnlySpan<char> span, string? trimChars)
        => span.Trim(trimChars.AsSpan());

    /// <summary>
    /// Removes all leading occurrences of a set of characters specified in a <see cref="string"/>
    /// from a read-only character span.
    /// </summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="trimChars">The <see cref="string"/> which contains the set of characters to remove or <c>null</c>
    /// to remove whitespace characters.</param>
    /// <returns>The trimmed read-only character span.</returns>
    /// <remarks>
    /// If <paramref name="trimChars"/> is <c>null</c> or empty, whitespace characters are removed instead.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlySpan<char> TrimStart(this ReadOnlySpan<char> span, string? trimChars)
        => span.TrimStart(trimChars.AsSpan());

    /// <summary>
    /// Removes all trailing occurrences of a set of characters specified in a <see cref="string"/>
    /// from a read-only character span.
    /// </summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="trimChars">The <see cref="string"/> which contains the set of characters to remove or <c>null</c>
    /// to remove whitespace characters.</param>
    /// <returns>The trimmed read-only character span.</returns>
    /// <remarks>
    /// If <paramref name="trimChars"/> is <c>null</c> or empty, whitespace characters are removed instead.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlySpan<char> TrimEnd(this ReadOnlySpan<char> span, string? trimChars)
        => span.TrimEnd(trimChars.AsSpan());

#endif
}
