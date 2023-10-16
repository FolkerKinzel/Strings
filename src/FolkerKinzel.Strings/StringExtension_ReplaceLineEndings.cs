namespace FolkerKinzel.Strings;

public static partial class StringExtension
{
    // This is a polyfill, but it should NOT be in the namespace FolkerKinzel.Strings.Polyfills
    // to be available for .NET Core 3.1:
#if NET5_0 || NETSTANDARD || NET45

    /// <summary>Replaces all newlines in <paramref name="s" /> with <see cref="Environment.NewLine"
    /// />.</summary>
    /// <param name="s">The source <see cref="string" />.</param>
    /// <returns>A <see cref="string" /> whose contents match the content of <paramref name="s"
    /// />, but with all newline sequences replaced with <see cref="Environment.NewLine"
    /// />.</returns>
    /// <remarks>
    /// <para>
    /// This is a polyfill for the .NET 6.0 method String.ReplaceLineEndings(). The method
    /// should therefore only be used in the extension method syntax. It throws a <see cref="NullReferenceException"
    /// /> if <paramref name="s" /> is <c>null</c> in order to show identical behavior to
    /// the original .NET method.
    /// </para>
    /// <para>
    /// The method searches for all newline sequences within <paramref name="s" /> and canonicalizes
    /// them to match the newline sequence for the current environment. For example, when
    /// running on Windows, all occurrences of non-Windows Newline sequences are replaced
    /// with the sequence CRLF. When running on Unix, all occurrences of non-Unix Newline
    /// sequences are replaced with a single LF character.
    /// </para>
    /// <para>
    /// The list of recognized newline sequences is:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// CR (U+000D)
    /// </item>
    /// <item>
    /// LF (U+000A)
    /// </item>
    /// <item>
    /// CRLF (U+000D U+000A)
    /// </item>
    /// <item>
    /// NEL (U+0085)
    /// </item>
    /// <item>
    /// LS (U+2028)
    /// </item>
    /// <item>
    /// FF (U+000C)
    /// </item>
    /// <item>
    /// PS (U+2029)
    /// </item>
    /// </list>
    /// <para>
    /// This list is specified by the Unicode standard (Sec. 5.8, Recommendation R4 and Table
    /// 5-2).
    /// </para>
    /// </remarks>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ReplaceLineEndings(this string s)
        => s.ReplaceLineEndings(Environment.NewLine);


    /// <summary>Replaces all newlines in <paramref name="s" /> with <paramref name="replacementText"
    /// />.</summary>
    /// <param name="s">The source <see cref="string" />.</param>
    /// <param name="replacementText">The text to use as replacement. If <paramref name="replacementText"
    /// /> is <see cref="string.Empty" />, all newline sequences within <paramref name="s"
    /// /> will be removed.</param>
    /// <returns>A <see cref="string" /> whose contents match the content of <paramref name="s"
    /// />, but with all newline sequences replaced with <paramref name="replacementText"
    /// />.</returns>
    /// <remarks>
    /// <para>
    /// This is a polyfill for the .NET 6.0 method String.ReplaceLineEndings(String). The
    /// method should therefore only be used in the extension method syntax. It throws a
    /// <see cref="NullReferenceException" /> if <paramref name="s" /> is <c>null</c> in
    /// order to show identical behavior to the original .NET method.
    /// </para>
    /// <para>
    /// The method searches for all newline sequences within <paramref name="s" /> and canonicalizes
    /// them to match <paramref name="replacementText" />.
    /// </para>
    /// <para>
    /// The list of recognized newline sequences is:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// CR (U+000D)
    /// </item>
    /// <item>
    /// LF (U+000A)
    /// </item>
    /// <item>
    /// CRLF (U+000D U+000A)
    /// </item>
    /// <item>
    /// NEL (U+0085)
    /// </item>
    /// <item>
    /// LS (U+2028)
    /// </item>
    /// <item>
    /// FF (U+000C)
    /// </item>
    /// <item>
    /// PS (U+2029)
    /// </item>
    /// </list>
    /// <para>
    /// This list is specified by the Unicode standard (Sec. 5.8, Recommendation R4 and Table
    /// 5-2).
    /// </para>
    /// </remarks>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentNullException"> <paramref name="replacementText" /> is <c>null</c>.</exception>
    public static string ReplaceLineEndings(this string s, string replacementText)
    {
        if (s is null)
        {
            throw new NullReferenceException();
        }

        if (replacementText is null)
        {
            throw new ArgumentNullException(nameof(replacementText));
        }

        for (int i = 0; i < s.Length; i++)
        {
            switch (s[i])
            {
                case '\r': // CR: Carriage Return
                case '\n': // LF: Line Feed
                //case '\u000B': // VT: Vertical Tab
                case '\u000C': // FF: Form Feed
                case '\u0085': // NEL: Next Line
                case '\u2028': // LS: Line Separator
                case '\u2029': // PS: Paragraph Separator
                    var sb = new StringBuilder(s.Length + s.Length / 2);
                    return sb.Append(s).ReplaceLineEndings(replacementText, i).ToString();
                default:
                    break;
            }
        }

        return s;
    }

#endif

}
