using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringExtension
{
    /// <summary>Generates a <see cref="string" /> from which all trailing occurrences of
    /// the characters in the specified read-only span are removed.</summary>
    /// <param name="s">The <see cref="string" /> to change.</param>
    /// <param name="trimChars">A read-only span of Unicode characters to remove. If 
    /// <paramref name="trimChars" /> is an empty span, Unicode white-space characters are 
    /// removed instead.</param>
    /// <returns>The resulting <see cref="string" /> after removing all characters passed
    /// in the <paramref name="trimChars" /> parameter from the end of the 
    /// <see cref="string" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    public static string TrimEnd(this string s, ReadOnlySpan<char> trimChars)
    {
        _ArgumentNullException.ThrowIfNull(s, nameof(s));

        ReadOnlySpan<char> span = s.AsSpan().TrimEnd(trimChars);

        return span.Length == s.Length
            ? s
            : span.Length == 0
                ? string.Empty
                : span.ToString();
    }
}
