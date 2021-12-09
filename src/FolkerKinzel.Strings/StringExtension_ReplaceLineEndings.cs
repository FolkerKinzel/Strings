using System.Runtime.CompilerServices;

namespace FolkerKinzel.Strings;

public static partial class StringExtension
{
    // This is a polyfill, but it should NOT be in the namespace FolkerKinzel.Strings.Polyfills
    // to be available for .NET Core 3.1:
#if NET5_0 || NETSTANDARD || NET45

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ReplaceLineEndings(this string s)
        => s.ReplaceLineEndings(Environment.NewLine);


    public static string ReplaceLineEndings(this string s, string replacementText)
    {
        if (s is null)
        {
            throw new NullReferenceException();
        }

        if (replacementText is null)
        {
            throw new ArgumentNullException();
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
