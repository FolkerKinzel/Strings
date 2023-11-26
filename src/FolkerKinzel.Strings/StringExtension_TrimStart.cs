using FolkerKinzel.Strings.Intls;
using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings;

public static partial class StringExtension
{
    /// <summary>Generates a <see cref="string" /> from which all leading occurrences of
    /// the characters in the specified read-only span are removed.</summary>
    /// <param name="s">The <see cref="string" /> to change.</param>
    /// <param name="trimChars">A read-only span of Unicode characters to remove. If 
    /// <paramref name="trimChars" /> is an empty Span, Unicode white-space characters are 
    /// removed instead.</param>
    /// <returns>The resulting <see cref="string" /> after removing all characters passed
    /// in the <paramref name="trimChars" /> parameter from the beginning of the 
    /// <see cref="string" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    public static string TrimStart(this string s, ReadOnlySpan<char> trimChars)
    {
        _ArgumentNullException.ThrowIfNull(s, nameof(s));

        if (trimChars.Length == 0)
        {
            return s.TrimStart();
        }

        ReadOnlySpan<char> span = s.AsSpan().DoTrimStart(trimChars);

        return span.Length == s.Length
            ? s
            : span.Length == 0
                ? string.Empty
                : span.ToString();
    }

    private static ReadOnlySpan<char> DoTrimStart(
        this ReadOnlySpan<char> span, ReadOnlySpan<char> trimChars)
    {
        int length = span.Length;

        for (int j = 0; j < length; j++)
        {
            if (trimChars.Contains(span[j]))
            {
                continue;
            }
            else
            {
                return span.Slice(j);
            }
        }

        return [];
    }
}
