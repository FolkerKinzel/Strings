namespace FolkerKinzel.Strings;

public static partial class StringExtension
{
    /// <summary>Generates a <see cref="string" /> in which all newlines are replaced by
    /// <paramref name="newLine" />.</summary>
    /// <param name="s">The source <see cref="string" />.</param>
    /// <param name="newLine">A read-only character span that is the replacement for all
    /// newlines. If an empty span is passed to the parameter, all newline characters will
    /// be completely removed.</param>
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
    /// string)" /> in that it also treats LFCR sequences and vertical tab (VT: U+000B ) as a line 
    /// break. 
    /// </note>
    /// </remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    [Obsolete("Use ReplaceLineEndings instead.", false)]
    public static string NormalizeNewLinesTo(this string s, ReadOnlySpan<char> newLine)
    {
        if (s is null)
        {
            throw new ArgumentNullException(nameof(s));
        }

        if (!s.ContainsNewLine())
        {
            return s;
        }

        var sb = new StringBuilder(s.Length + s.Length / 2);
        return sb.Append(s).NormalizeNewLinesTo(newLine).ToString();
    }

}
