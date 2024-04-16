using System.Text.RegularExpressions;

namespace FolkerKinzel.Strings;

/// <summary> Extension methods, which act as Polyfills for the extension methods of the 
/// <see cref="StringBuilderExtension" /> class.</summary>
/// <remarks>The polyfills are available for .NET Framework 4.5 and .NET Standard 2.0.</remarks>
public static class StringBuilderExtensionPolyfillExtension
{
    // Place this preprocessor directive inside the class to let .NET Core 3.1 and above have an empty class!
#if NET45 || NETSTANDARD2_0

    /// <summary>Appends the content of a <see cref="string" /> as URL-encoded character
    /// sequence to the end of a <see cref="StringBuilder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to which the characters are
    /// appended.</param>
    /// <param name="value">The <see cref="string" /> containing the characters to encode
    /// and append, or <c>null</c>.</param>
    /// <returns>A reference to <paramref name="builder" /> after the append operation has
    /// completed.</returns>
    /// <remarks>The method replaces all characters in <paramref name="value" /> except unreserved
    /// RFC 3986 characters into their hexadecimal representation. All Unicode characters
    /// are converted to UTF-8 format before being escaped. This method assumes that there
    /// are no escape sequences in <paramref name="value" />.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Increasing the capacity of <paramref
    /// name="builder" /> would exceed <see cref="StringBuilder.MaxCapacity" />.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendUrlEncoded(this StringBuilder builder, string? value)
        => UrlEncoding.AppendEncodedTo(builder, value.AsSpan());

    /// <summary>Replaces in <paramref name="builder" /> all sequences of white space with
    /// <paramref name="replacement" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="replacement">A <see cref="string" /> that is the replacement for all
    /// sequences of white space, or <c>null</c> to completely remove all white space.</param>
    /// <param name="skipNewLines">Pass <c>true</c> to exclude newline characters from the
    /// replacement. The default value is <c>false</c>.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
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
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder ReplaceWhiteSpaceWith(
        this StringBuilder builder,
        string? replacement,
        bool skipNewLines = false)
    => builder is null ? throw new ArgumentNullException(nameof(builder))
                       : builder.ReplaceWhiteSpaceWith(replacement.AsSpan(),
                                                       0,
                                                       builder.Length,
                                                       skipNewLines);

    /// <summary>Replaces in a section of <paramref name="builder" />, which starts at <paramref
    /// name="startIndex" /> and extends to the end of <paramref name="builder" />, all sequences
    /// of white space with <paramref name="replacement" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="replacement">A <see cref="string" /> that is the replacement for all
    /// sequences of white space, or <c>null</c> to completely remove all white space.</param>
    /// <param name="skipNewLines">Pass <c>true</c> to exclude newline characters from the
    /// replacement. The default value is <c>false</c>.</param>
    /// <param name="startIndex">The zero-based index in <paramref name="builder" /> at which
    /// the replacement starts.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
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
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="startIndex" /> is
    /// less than zero or greater than the number of characters in <paramref name="builder"
    /// />.</exception>
    public static StringBuilder ReplaceWhiteSpaceWith(
        this StringBuilder builder,
        string? replacement,
        int startIndex,
        bool skipNewLines = false)
    => builder is null ? throw new ArgumentNullException(nameof(builder))
                       : builder.ReplaceWhiteSpaceWith(replacement.AsSpan(),
                                                       startIndex,
                                                       builder.Length - startIndex,
                                                       skipNewLines);

    /// <summary>Replaces in a section of <paramref name="builder" />, which starts at <paramref
    /// name="startIndex" /> and which is <paramref name="count" /> characters long, all
    /// sequences of white space with <paramref name="replacement" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="replacement">A <see cref="string" /> that is the replacement for all
    /// sequences of white space, or <c>null</c> to completely remove all white space.</param>
    /// <param name="startIndex">The zero-based index in <paramref name="builder" /> at which
    /// the replacement starts.</param>
    /// <param name="count">The length of the specified section in <paramref name="builder"
    /// /> where replacement operations take place.</param>
    /// <param name="skipNewLines">Pass <c>true</c> to exclude newline characters from the
    /// replacement. The default value is <c>false</c>.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
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
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="startIndex" /> or <paramref name="count" /> are smaller than zero
    /// or larger than the number of characters in <paramref name="builder" />
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="startIndex" /> + <paramref name="count" /> is larger than the number
    /// of characters in <paramref name="builder" />.
    /// </para>
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder ReplaceWhiteSpaceWith(
        this StringBuilder builder,
        string? replacement,
        int startIndex,
        int count,
        bool skipNewLines = false)
    => builder.ReplaceWhiteSpaceWith(replacement.AsSpan(), startIndex, count, skipNewLines);

    /// <summary>Replaces all newlines in <paramref name="builder" /> with <paramref name="newLine"
    /// />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="newLine">A <see cref="string" /> that is the replacement for all newlines,
    /// or <c>null</c> to completely remove all newline characters.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <remarks>
    /// <para>
    /// <see cref="CharExtension.IsNewLine(char)" /> is used to identify newline characters. The 
    /// sequences CRLF and LFCR are treated as one line break.
    /// </para>
    /// <note type="caution">
    /// This method differs from <see cref="StringBuilderExtension.ReplaceLineEndings(StringBuilder,
    /// string?)" /> in that it also treats LFCR sequences and vertical tab (VT: U+000B ) as a line break. 
    /// </note>
    /// </remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    [Obsolete("Use ReplaceLineEndings instead.", false)]
    public static StringBuilder NormalizeNewLinesTo(this StringBuilder builder, string? newLine)
        => builder.NormalizeNewLinesTo(newLine.AsSpan());

#endif
}
