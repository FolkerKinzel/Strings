namespace FolkerKinzel.Strings;

/// <summary>Extension methods for the <see cref="Span{T}">Span&lt;Char&gt;</see> struct
/// used in the .NET Framework 4.5, .NET Standard 2.0, and .NET Standard 2.1 as polyfills
/// for methods from current .NET versions.</summary>
/// <remarks>The methods of this class should only be used in the extension method syntax
/// to simulate the methods of the <see cref="Span{T}">Span&lt;Char&gt;</see> struct,
/// which exist in current frameworks.</remarks>
public static class SpanPolyfillExtension
{
    // Place this preprocessor directive inside the class to let .NET 6.0 and above have an empty class!
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1

    /// <summary>Indicates whether a character span contains a specified Unicode character.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> has been found, <c>false</c> otherwise.</returns>
    /// <remarks><see cref="MemoryExtensions.IndexOf{T}(Span{T}, T)">
    /// MemoryExtensions.IndexOf(this Span&lt;T&gt;, T)</see> is used for the comparison.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(this Span<char> span, char value)
        => span.IndexOf(value) != -1;

    /// <summary>Removes all leading and trailing white space characters from a character
    /// span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <returns>The sliced span.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> Trim(this Span<char> span) => span.TrimStart().TrimEnd();

    /// <summary>Removes all leading white space characters from a character span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <returns>The sliced span.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> TrimStart(this Span<char> span)
        => span.Slice(span.GetTrimmedStart());

    /// <summary>Removes all trailing white space characters from a character span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <returns>The sliced span.</returns>
    public static Span<char> TrimEnd(this Span<char> span)
        => span.Slice(0, span.GetTrimmedLength());
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
        this Span<char> span, string? other, StringComparison comparisonType)
        => ((ReadOnlySpan<char>)span).Equals(other.AsSpan(), comparisonType);

    /// <summary>Indicates whether a specified value occurs within a character span when
    /// compared using a specified <see cref="StringComparison" /> value.</summary>
    /// <param name="span">The source span.</param>
    /// <param name="value">The value to seek within the source span. <paramref name="value"
    /// /> can be <c>null</c>.</param>
    /// <param name="comparisonType">An enumeration value that determines how <paramref name="span"
    /// /> and <paramref name="value" /> are compared.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> has been found, <c>false</c> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(
        this Span<char> span, string? value, StringComparison comparisonType)
        => ((ReadOnlySpan<char>)span).Contains(value.AsSpan(), comparisonType);

    /// <summary>Indicates whether a read-only character span begins with a specified <see
    /// cref="string" />.</summary>
    /// <param name="span">The source span.</param>
    /// <param name="value">The <see cref="string" /> to compare with the beginning of the
    /// source span.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> matches the beginning of <paramref
    /// name="span" />, otherwise <c>false</c>.</returns>
    /// <remarks>The method performs an ordinal character comparison. If <paramref name="value"
    /// /> is <c>null</c> or <see cref="string.Empty" /> the method returns <c>true</c>.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool StartsWith(this Span<char> span, string? value)
        => ((ReadOnlySpan<char>)span).StartsWith(value.AsSpan());

    /// <summary>Indicates whether a character span begins with a specified <see cref="string"
    /// /> when compared using a specified <see cref="StringComparison" /> value.</summary>
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
        this Span<char> span, string? value, StringComparison comparisonType)
        => ((ReadOnlySpan<char>)span).StartsWith(value.AsSpan(), comparisonType);

    /// <summary>Indicates whether a character span ends with the specified <see cref="string"
    /// />.</summary>
    /// <param name="span">The source span.</param>
    /// <param name="value">The <see cref="string" /> to compare with the end of the source
    /// span.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> matches the end of <paramref name="span"
    /// />, otherwise <c>false</c>.</returns>
    /// <remarks>The method performs an ordinal character comparison. If <paramref name="value"
    /// /> is <c>null</c> or <see cref="string.Empty" /> the method returns <c>true</c>.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EndsWith(this Span<char> span, string? value)
        => ((ReadOnlySpan<char>)span).EndsWith(value.AsSpan());

    /// <summary>Indicates whether a character span ends with a specified <see cref="string"
    /// /> when compared using a specified <see cref="StringComparison" /> value.</summary>
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
        this Span<char> span, string? value, StringComparison comparisonType)
        => ((ReadOnlySpan<char>)span).EndsWith(value.AsSpan(), comparisonType);

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
    public static int LastIndexOf(
        this Span<char> span, string? value, StringComparison comparisonType)
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
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="count" /> is a negative value
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="span" /> is not <see cref="Span{T}.Empty" />, and <paramref name="startIndex"
    /// /> is a negative value.
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="span" /> is not <see cref="Span{T}.Empty" />, and <paramref name="startIndex"
    /// /> is greater than the length of <paramref name="span" />.
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="span" /> is not <see cref="Span{T}.Empty" />, and <paramref name="startIndex"
    /// /> + 1 - <paramref name="count" /> indicates a position that is not within <paramref
    /// name="span" />.
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="span" /> is <see cref="Span{T}.Empty" />, and <paramref name="startIndex"
    /// /> is less than -1 or greater than 0.
    /// </para>
    /// </exception>
    /// <exception cref="ArgumentException"> <paramref name="comparisonType" /> is not a
    /// defined value of the <see cref="StringComparison" /> enum.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOf(this Span<char> span,
                                  string? value,
                                  int startIndex,
                                  int count,
                                  StringComparison comparisonType)
        => ((ReadOnlySpan<char>)span).LastIndexOf(value.AsSpan(),
                                                  startIndex,
                                                  count,
                                                  comparisonType);

    /// <summary>Indicates whether a character span contains one of the Unicode characters
    /// that are passed to the method as a string.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="values">A string containing the characters to search for, or <c>null</c>.</param>
    /// <returns> <c>true</c> if <paramref name="span" /> contains one of the characters
    /// passed with <paramref name="values" />. If <paramref name="span" /> is empty or <paramref
    /// name="values" /> is <c>null</c> or empty, <c>false</c> is returned.</returns>
    /// <remarks>If the length of <paramref name="values" /> is less than 5, the method uses
    /// <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T}, 
    /// ReadOnlySpan{T})">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> for the comparison. If the length of <paramref name="values"
    /// /> is greater, <see cref="string.IndexOfAny(char[])">String.IndexOfAny(char[])</see>
    /// is used to avoid performance issues.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAny(this Span<char> span, string? values)
        => ((ReadOnlySpan<char>)span).ContainsAny(values.AsSpan());

    /// <summary>Searches for the zero-based index of the first occurrence of one of the
    /// specified Unicode characters.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="values">A string containing the characters to search for, or <c>null</c>.</param>
    /// <returns>The zero-based index of the first occurrence of one of the specified Unicode
    /// characters in <paramref name="span" /> or -1 if none of these characters have been
    /// found. If <paramref name="values" /> is <c>null</c> or empty, the method returns
    /// -1.</returns>
    /// <remarks>If the length of <paramref name="values" /> is less than 5, the method uses
    /// <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T}, 
    /// ReadOnlySpan{T})">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> for the comparison. If the length of <paramref name="values"
    /// /> is greater, <see cref="string.IndexOfAny(char[])">String.IndexOfAny(char[])</see>
    /// is used to avoid performance issues.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAny(this Span<char> span, string? values)
        => ((ReadOnlySpan<char>)span).IndexOfAny(values.AsSpan());

    /// <summary>Searches for the zero-based index of the last occurrence of one of the specified
    /// Unicode characters.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="values">A string containing the characters to search for, or <c>null</c>.</param>
    /// <returns>The zero-based index of the last occurrence of one of the specified Unicode
    /// characters in <paramref name="span" /> or -1 if none of these characters have been
    /// found. If <paramref name="values" /> is <c>null</c> or empty, the method returns
    /// -1.</returns>
    /// <remarks>If the length of <paramref name="values" /> is less than 5, the method uses
    /// <see cref="MemoryExtensions.LastIndexOfAny{T}(ReadOnlySpan{T}, 
    /// ReadOnlySpan{T})">MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> for the comparison. If the length of <paramref name="values"
    /// /> is greater, <see cref="string.LastIndexOfAny(char[])">String.LastIndexOfAny(char[])</see>
    /// is used to avoid performance issues.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOfAny(this Span<char> span, string? values)
        => ((ReadOnlySpan<char>)span).LastIndexOfAny(values.AsSpan());

    /// <summary>Returns the zero-based index of the last occurrence of one of the specified
    /// characters in <paramref name="span" />. The search begins at a specified character
    /// position and runs a specified number of character positions backwards to the beginning
    /// of the <paramref name="span" />.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="values">A string containing the characters to search for, or <c>null</c>.</param>
    /// <param name="startIndex">The start index of the search. The search is done backwards
    /// to the beginning of <paramref name="span" />.</param>
    /// <param name="count">The number of characters positions to examine in <paramref name="span"
    /// />.</param>
    /// <returns>The zero-based index of the last occurrence of one of the specified Unicode
    /// characters in <paramref name="span" /> or -1 if none of these characters have been
    /// found.</returns>
    /// <remarks>If the length of <paramref name="values" /> is less than 5, the method uses
    /// <see cref="MemoryExtensions.LastIndexOfAny{T}(ReadOnlySpan{T}, 
    /// ReadOnlySpan{T})">MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> for the comparison. If the length of <paramref name="values"
    /// /> is greater, <see cref="string.LastIndexOfAny(char[])">String.LastIndexOfAny(char[])</see>
    /// is used to avoid performance issues.</remarks>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="span" /> is not <see cref="Span{T}.Empty" /> and <paramref name="startIndex"
    /// /> is less than zero or greater than or equal to the length of <paramref name="span"
    /// />
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="span" /> is not <see cref="Span{T}.Empty" /> and <paramref name="startIndex"
    /// /> - <paramref name="count" /> + 1 is less than zero.
    /// </para>
    /// </exception>
    public static int LastIndexOfAny(
        this Span<char> span, string? values, int startIndex, int count)
        => ((ReadOnlySpan<char>)span).LastIndexOfAny(values.AsSpan(), startIndex, count);

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
        this Span<char> span, string? value, StringComparison comparisonType)
        => MemoryExtensions.IndexOf(span, value.AsSpan(), comparisonType);

#endif
}
