using System.Text.RegularExpressions;

namespace FolkerKinzel.Strings;

public static partial class StringExtensionPolyfillExtension
{
    // Place this preprocessor directive inside the class to let .NET 5.0 and above have an empty class!
#if NET461 || NETSTANDARD2_0

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
    /// This method differs from <see cref="StringPolyfillExtension.ReplaceLineEndings(string, string)" /> 
    /// in that it also treats LFCR sequences and vertical tab (VT: U+000B ) as a line break. 
    /// </note>
    /// </remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [Obsolete("Use ReplaceLineEndings instead.", false)]
    public static string NormalizeNewLinesTo(this string s, string? newLine)
        => s.NormalizeNewLinesTo(newLine.AsSpan());

#endif
}
