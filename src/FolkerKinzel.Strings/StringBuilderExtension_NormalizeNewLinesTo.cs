using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>Replaces all newlines in <paramref name="builder" /> with <paramref name="newLine"
    /// />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="newLine">A read-only character span that is the replacement for all
    /// newlines. If an empty span is passed to the parameter, all newline characters will
    /// be completely removed.</param>
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
    public static StringBuilder NormalizeNewLinesTo(this StringBuilder builder, ReadOnlySpan<char> newLine)
    {
        _ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        bool skipR = false, skipN = false;
        for (int i = builder.Length - 1; i >= 0; i--)
        {
            char c = builder[i];

            if (skipR)
            {
                skipR = false;

                if (c == '\r')
                {
                    _ = builder.Remove(i, 2).Insert(i, newLine);
                    continue;
                }
                else
                {
                    _ = builder.Remove(i + 1, 1).Insert(i + 1, newLine);
                }
            }
            else if (skipN)
            {
                skipN = false;
                if (c == '\n')
                {
                    _ = builder.Remove(i, 2).Insert(i, newLine);
                    continue;
                }
                else
                {
                    _ = builder.Remove(i + 1, 1).Insert(i + 1, newLine);
                }
            }

            if (c == '\r')
            {
                skipN = true;
                continue;
            }
            else if (c == '\n')
            {
                skipR = true;
                continue;
            }
            else if (c.IsNewLine())
            {
                _ = builder.Remove(i, 1).Insert(i, newLine);
            }
        } //for

        if (skipN || skipR)
        {
            _ = builder.Remove(0, 1).Insert(0, newLine);
        }

        return builder;
    }
}
