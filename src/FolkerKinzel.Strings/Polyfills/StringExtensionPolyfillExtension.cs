using System.Runtime.CompilerServices;
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
    /// name="replacement" />. If <paramref name="s" /> doesn't contain a newline character,
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
#endif
}
