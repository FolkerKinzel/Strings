using System.Text.RegularExpressions;

namespace FolkerKinzel.Strings;

#if NET461 || NETSTANDARD2_0

public static partial class StringBuilderExtensionPolyfillExtension
{
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
}

#endif
