using System.Text.RegularExpressions;

namespace FolkerKinzel.Strings.Polyfills;

/// <summary> Extension methods, which act as Polyfills for the extension methods of the 
/// <see cref="StringExtension" /> class.</summary>
/// <remarks>The polyfills are available for .NET Framework 4.5 and .NET Standard 2.0.</remarks>
public static class StringExtensionPolyfillExtension
{
    // Place this preprocessor directive inside the class to let .NET 5.0 and above have an empty class!
#if NET45 || NETSTANDARD2_0
    /// <summary>Generates a <see cref="string" /> in which all sequences of white space
    /// are replaced by <paramref name="replacement" />.</summary>
    /// <param name="s">The source <see cref="string" />.</param>
    /// <param name="replacement">A <see cref="string" />, which replaces the white space,
    /// or <c>null</c> to remove all white space.</param>
    /// <param name="skipNewLines">Pass <c>true</c> to exclude newline characters from the
    /// replacement. The default value is <c>false</c>.</param>
    /// <returns>A new <see cref="string" /> in which all sequences of white space are replaced
    /// by <paramref name="replacement" />. If <paramref name="s" /> doesn't contain a white
    /// space character, <paramref name="s" /> is returned.</returns>
    /// <remarks>
    /// <para>
    /// The method uses <see cref="char.IsWhiteSpace(char)" /> to identify white space characters
    /// and works more thoroughly with it than <see cref="Regex.Replace(string, string, string)">
    /// Regex.Replace(string input, @"\s+", string replacement)</see>. 
    /// </para>
    /// <para>
    /// <see cref="CharExtension.IsNewLine(char)" /> is used to identify newline characters.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ReplaceWhiteSpaceWith(
        this string s,
        string? replacement,
        bool skipNewLines = false)
        => s.ReplaceWhiteSpaceWith(replacement.AsSpan(), skipNewLines);

    /// <summary>Generates a <see cref="string" /> in which all newlines are replaced by
    /// <paramref name="newLine" />.</summary>
    /// <param name="s">The source <see cref="string" />.</param>
    /// <param name="newLine">A <see cref="string" /> that is the replacement for all newlines,
    /// or <c>null</c> to completely remove all newline characters.</param>
    /// <returns>A new <see cref="string" /> in which all newlines are replaced by <paramref
    /// name="newLine" />. If <paramref name="s" /> doesn't contain a newline character,
    /// <paramref name="s" /> is returned.</returns>
    /// <remarks>
    /// <para>
    /// <see cref="CharExtension.IsNewLine(char)" /> is used to identify newline characters. The 
    /// sequences CRLF and LFCR are treated as one line break.
    /// </para>
    /// <note type="caution">
    /// This method differs from <see cref="StringExtension.ReplaceLineEndings(string,
    /// string)" /> in that it also treats LFCR sequences and vertical tab (VT: U+000B ) as a line break. 
    /// </note>
    /// </remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [Obsolete("Use ReplaceLineEndings instead.", false)]
    public static string NormalizeNewLinesTo(this string s, string? newLine)
        => s.NormalizeNewLinesTo(newLine.AsSpan());

    /// <summary>Returns the zero-based index of the first occurrence of one of the the specified
    /// characters in <paramref name="s" />. The search begins at a specified index and a
    /// specified number of character positions are checked.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="anyOf">A <see cref="string"/> that contains the characters to search
    /// for or <c>null</c>.</param>
    /// <param name="startIndex">The zero-based index in <paramref name="s" /> at which the
    /// search starts.</param>
    /// <param name="count">The number of characters positions to examine in <paramref name="s"
    /// />.</param>
    /// <returns>The zero-based index of the first occurrence of one of the specified Unicode
    /// characters in the specified part of <paramref name="s" /> or -1 if none of these characters 
    /// have been found in this area.
    /// If <paramref name="anyOf" /> is an empty span, the method returns -1.</returns>
    /// <remarks>If the length of <paramref name="anyOf" /> is less than 5, the method uses
    /// <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T}, 
    /// ReadOnlySpan{T})">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> for the comparison. If the length of <paramref name="anyOf"
    /// /> is greater, <see cref="string.IndexOfAny(char[])">String.IndexOfAny(char[])</see>
    /// is used.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="startIndex" /> or <paramref name="count" /> are smaller than zero
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="startIndex" /> + <paramref name="count" /> is larger than the number
    /// of characters in <paramref name="s" />.
    /// </para>
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAny(this string s, string? anyOf, int startIndex, int count)
        => s.IndexOfAny(anyOf.AsSpan(), startIndex, count);


    /// <summary>Returns the zero-based index of the first occurrence of one of the the specified
    /// characters in <paramref name="s" />. The search starts at the specified 
    /// <paramref name="startIndex"/>.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="anyOf">A <see cref="string"/> that contains the characters to search
    /// for or <c>null</c>.</param>
    /// <param name="startIndex">The zero-based index in <paramref name="s" /> at which the
    /// search starts.</param>
    /// <returns>The zero-based index of the first occurrence of one of the specified Unicode
    /// characters in the specified part of <paramref name="s" /> or -1 if none of these 
    /// characters have been found in this area.
    /// If <paramref name="anyOf" /> is an empty span, the method returns -1.</returns>
    /// <remarks>If the length of <paramref name="anyOf" /> is less than 5, the method uses
    /// <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T}, 
    /// ReadOnlySpan{T})">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> for the comparison. If the length of <paramref name="anyOf"
    /// /> is greater, <see cref="string.IndexOfAny(char[])">String.IndexOfAny(char[])</see>
    /// is used.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="startIndex" /> is not a valid index in <paramref name="s"/>.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAny(this string s, string? anyOf, int startIndex)
        => s.IndexOfAny(anyOf.AsSpan(), 
                        startIndex, 
                        s?.Length - startIndex ?? throw new ArgumentNullException(nameof(s)));

    /// <summary>Returns the zero-based index of the first occurrence of one of the the specified
    /// characters in <paramref name="s" />. </summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="anyOf">A <see cref="string"/> that contains the characters to search
    /// for or <c>null</c>.</param>
    /// <returns>The zero-based index of the first occurrence of one of the specified Unicode
    /// characters in <paramref name="s" /> or -1 if none of these characters have been found.
    /// If <paramref name="anyOf" /> is an empty span, the method returns -1.</returns>
    /// <remarks>If the length of <paramref name="anyOf" /> is less than 5, the method uses
    /// <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T}, 
    /// ReadOnlySpan{T})">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> for the comparison. If the length of <paramref name="anyOf"
    /// /> is greater, <see cref="string.IndexOfAny(char[])">String.IndexOfAny(char[])</see>
    /// is used.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAny(this string s, string? anyOf)
        => s.IndexOfAny(anyOf.AsSpan(), 0, s?.Length ?? throw new ArgumentNullException(nameof(s)));

    /// <summary>Returns the zero-based index position of the last occurrence of one of the
    /// specified characters in <paramref name="s" />. The search begins at a specified index
    /// and runs backwards to the beginning of the <see cref="string" /> for a specified
    /// number of character positions.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="anyOf">A <see cref="string"/> that contains the characters to search
    /// for or <c>null</c>.</param>
    /// <param name="startIndex">The start index of the search. The search is done backwards
    /// to the beginning of <paramref name="s" />.</param>
    /// <param name="count">The number of character positions to examine.</param>
    /// <returns>The zero-based index of the last occurrence of one of the specified Unicode
    /// characters in the specified part of <paramref name="s" /> or -1 if none of these
    /// characters have been found in this area.</returns>
    /// <remarks>If the length of <paramref name="anyOf" /> is less than 5, the method uses
    /// MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;)
    /// for the comparison. If the length of <paramref name="anyOf" /> is greater, <see
    /// cref="string.LastIndexOfAny(char[])" /> is used.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="s" /> is not <see cref="string.Empty" /> and <paramref name="startIndex"
    /// /> is less than zero or greater than or equal to the length of <paramref name="s"
    /// />
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="s" /> is not <see cref="string.Empty" /> and <paramref name="startIndex"
    /// /> - <paramref name="count" /> + 1 is less than zero.
    /// </para>
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOfAny(this string s, string? anyOf, int startIndex, int count)
        => s.LastIndexOfAny(anyOf.AsSpan(), startIndex, count);

    /// <summary>Returns the zero-based index position of the last occurrence of one of the
    /// specified characters in <paramref name="s" />. The search starts at the specified 
    /// <paramref name="startIndex"/> and runs backwards to the beginning of <paramref name="s"/>.
    /// </summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="anyOf">A <see cref="string"/> that contains the characters to search
    /// for or <c>null</c>.</param>
    /// <param name="startIndex">The start index of the search. The search is done backwards
    /// to the beginning of <paramref name="s" />.</param>
    /// <returns>The zero-based index of the last occurrence of one of the specified Unicode
    /// characters in the specified part of <paramref name="s" /> or -1 if none of these
    /// characters have been found in this area.</returns>
    /// 
    /// <remarks>If the length of <paramref name="anyOf" /> is less than 5, the method uses
    /// MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;)
    /// for the comparison. If the length of <paramref name="anyOf" /> is greater, <see
    /// cref="string.LastIndexOfAny(char[])" /> is used.</remarks>
    /// 
    /// <exception cref = "ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="s" /> is not <see cref="string.Empty" /> and <paramref name="startIndex"
    /// /> is less than zero or greater than or equal to the length of <paramref name="s" />
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOfAny(this string s, string? anyOf, int startIndex)
        => s.LastIndexOfAny(anyOf.AsSpan(), startIndex, startIndex + 1);

    /// <summary>Returns the zero-based index position of the last occurrence of one of the
    /// specified characters in <paramref name="s" />.
    /// </summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="anyOf">A <see cref="string"/> that contains the characters to search
    /// for or <c>null</c>.</param>
    /// <returns>The zero-based index of the last occurrence of one of the specified Unicode
    /// characters in <paramref name="s" /> or -1 if none of these
    /// characters have been found.</returns>
    /// <remarks>If the length of <paramref name="anyOf" /> is less than 5, the method uses
    /// MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;)
    /// for the comparison. If the length of <paramref name="anyOf" /> is greater, <see
    /// cref="string.LastIndexOfAny(char[])" /> is used.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOfAny(this string s, string? anyOf)
    {
        return s is null ? throw new ArgumentNullException(nameof(s))
                         : s.LastIndexOfAny(anyOf.AsSpan(), s.Length - 1, s.Length);
    }

    /// <summary>Indicates whether a <see cref="string" /> contains one of the Unicode characters
    /// that are passed to the method in a read-only span.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="anyOf">A <see cref="string"/> that contains the characters to search
    /// for or <c>null</c>.</param>
    /// <returns> <c>true</c> if one of the characters to be searched for is found in <paramref
    /// name="s" />, otherwise <c>false</c>. If <paramref name="s" /> or <paramref name="anyOf"
    /// /> have the length zero, <c>false</c> is returned.</returns>
    /// <remarks>If the length of <paramref name="anyOf" /> is less than 5, the method uses
    /// <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T}, 
    /// ReadOnlySpan{T})">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> for the comparison. If the length of <paramref name="anyOf"
    /// /> is greater, <see cref="string.IndexOfAny(char[])">String.IndexOfAny(char[])</see>
    /// is used.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAny(this string s, string? anyOf)
        => s.ContainsAny(anyOf.AsSpan());
#endif
}
