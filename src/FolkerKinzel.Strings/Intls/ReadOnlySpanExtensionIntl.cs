using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkerKinzel.Strings.Intls;
internal static class ReadOnlySpanExtensionIntl
{
    internal static int ReplaceLineEndings(this ReadOnlySpan<char> source, ReadOnlySpan<char> replacement, Span<char> destination)
    {
        bool rFound = false;
        int outputLength = 0;

        for (int i = 0; i < source.Length; i++)
        {
            char c = source[i];

            switch (c)
            {
                case '\r': // CR: Carriage Return
                    rFound = true;
                    _ = replacement.TryCopyTo(destination.Slice(outputLength));
                    outputLength += replacement.Length;
                    break;
                case '\n': // LF: Line Feed
                    if (rFound)
                    {
                        rFound = false;
                        continue;
                    }
                    _ = replacement.TryCopyTo(destination.Slice(outputLength));
                    outputLength += replacement.Length;
                    break;
                //case '\u000B': // VT: Vertical Tab
                case '\u000C': // FF: Form Feed
                case '\u0085': // NEL: Next Line
                case '\u2028': // LS: Line Separator
                case '\u2029': // PS: Paragraph Separator
                    rFound = false;
                    _ = replacement.TryCopyTo(destination.Slice(outputLength));
                    outputLength += replacement.Length;
                    break;
                default:
                    rFound = false;
                    destination[outputLength++] = c;
                    break;
            }
        }

        return outputLength;
    }

    internal static void ReplaceLineEndings(this ReadOnlySpan<char> source,
                                           ReadOnlySpan<char> replacement,
                                           Span<char> destination,
                                           ref bool rFound,
                                           ref int outputLength)
    {
        for (int i = 0; i < source.Length; i++)
        {
            char c = source[i];

            switch (c)
            {
                case '\r': // CR: Carriage Return
                    rFound = true;
                    _ = replacement.TryCopyTo(destination.Slice(outputLength));
                    outputLength += replacement.Length;
                    break;
                case '\n': // LF: Line Feed
                    if (rFound)
                    {
                        rFound = false;
                        continue;
                    }
                    _ = replacement.TryCopyTo(destination.Slice(outputLength));
                    outputLength += replacement.Length;
                    break;
                //case '\u000B': // VT: Vertical Tab
                case '\u000C': // FF: Form Feed
                case '\u0085': // NEL: Next Line
                case '\u2028': // LS: Line Separator
                case '\u2029': // PS: Paragraph Separator
                    rFound = false;
                    _ = replacement.TryCopyTo(destination.Slice(outputLength));
                    outputLength += replacement.Length;
                    break;
                default:
                    rFound = false;
                    destination[outputLength++] = c;
                    break;
            }
        }
    }
}
