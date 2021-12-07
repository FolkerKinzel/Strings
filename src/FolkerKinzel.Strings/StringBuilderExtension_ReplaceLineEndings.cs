using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{

    public static StringBuilder ReplaceLineEndings(this StringBuilder builder, string? replacementText)
        => builder is null ? throw new ArgumentNullException(nameof(builder))
                           : ReplaceLineEndings(builder, replacementText, 0);

    internal static StringBuilder ReplaceLineEndings(this StringBuilder builder, string? replacementText, int startIndex)
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
