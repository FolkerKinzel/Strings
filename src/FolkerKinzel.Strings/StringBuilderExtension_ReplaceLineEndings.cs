namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>Replaces all newlines in <paramref name="builder" /> with 
    /// <paramref name="newLine" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="replacementText">The text to use as replacement. If 
    /// <paramref name="replacementText" /> is <c>null</c> or <see cref="string.Empty" />, all 
    /// newlines will be removed.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <remarks>
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
    /// This list is given by the Unicode Standard, Sec. 5.8, Recommendation R4 and Table
    /// 5-2.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder ReplaceLineEndings(this StringBuilder builder, string? replacementText)
        => builder is null ? throw new ArgumentNullException(nameof(builder))
                           : ReplaceLineEndings(builder, replacementText, 0);


    internal static StringBuilder ReplaceLineEndings(this StringBuilder builder,
                                                     string? replacementText,
                                                     int startIndex)
    {
        bool nFound = false;

        for (int i = builder.Length - 1; i >= startIndex; i--)
        {
            switch (builder[i])
            {
                case '\r': // CR: Carriage Return
                    _ = nFound ? builder.Remove(i, 2) : builder.Remove(i, 1);
                    nFound = false;
                    _ = builder.Insert(i, replacementText);
                    break;
                case '\n': // LF: Line Feed
                    if (nFound)
                    {
                        int nextIdx = i + 1;
                        _ = builder.Remove(nextIdx, 1).Insert(nextIdx, replacementText);
                    }
                    nFound = true;
                    break;
                //case '\u000B': // VT: Vertical Tab
                case '\u000C': // FF: Form Feed
                case '\u0085': // NEL: Next Line
                case '\u2028': // LS: Line Separator
                case '\u2029': // PS: Paragraph Separator
                    if (nFound)
                    {
                        int nextIdx = i + 1;
                        _ = builder.Remove(nextIdx, 1).Insert(nextIdx, replacementText);
                    }
                    nFound = false;
                    _ = builder.Remove(i, 1).Insert(i, replacementText);
                    break;
                default:
                    if (nFound)
                    {
                        _ = builder.Remove(i + 1, 1).Insert(i + 1, replacementText);

                        nFound = false;
                    }
                    break;
            }
        }

        if (nFound)
        {
            _ = builder.Remove(startIndex, 1).Insert(startIndex, replacementText);
        }

        return builder;
    }

}
