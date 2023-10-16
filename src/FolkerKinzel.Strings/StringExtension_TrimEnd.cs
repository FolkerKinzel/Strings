using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings;

public static partial class StringExtension
{
    /// <summary>Generates a <see cref="string" /> from which all trailing occurrences of
    /// the characters in the specified Span are removed.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="trimChars">A Span of Unicode characters to remove. If <paramref name="trimChars"
    /// /> is an empty Span, Unicode white-space characters are removed instead.</param>
    /// <returns>The resulting <see cref="string" /> after removing all characters passed
    /// in the <paramref name="trimChars" /> parameter from the end of the <see cref="string"
    /// />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    public static string TrimEnd(this string s, ReadOnlySpan<char> trimChars)
    {
        if (s is null)
        {
            throw new ArgumentNullException(nameof(s));
        }
        if (trimChars.Length == 0)
        {
            return s.TrimEnd();
        }

        ReadOnlySpan<char> span = s.AsSpan().DoTrimEnd(trimChars);

        return span.Length == s.Length
            ? s
            : span.Length == 0
                ? string.Empty
                : span.ToString();
    }

    private static ReadOnlySpan<char> DoTrimEnd(this ReadOnlySpan<char> span, ReadOnlySpan<char> trimChars)
    {
        int length = span.Length;

        for (int i = length - 1; i >= 0; i--)
        {
            if (trimChars.Contains(span[i]))
            {
                --length;
            }
            else
            {
                break;
            }
        }

        return span.Slice(0, length);
    }


}
