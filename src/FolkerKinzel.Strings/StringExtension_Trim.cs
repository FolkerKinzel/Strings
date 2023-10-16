namespace FolkerKinzel.Strings;

public static partial class StringExtension
{
    /// <summary>Generates a <see cref="string" /> from which all leading and trailing occurrences
    /// of the characters in the specified Span are removed.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="trimChars">A Span of Unicode characters to remove. If <paramref name="trimChars"
    /// /> is an empty Span, Unicode white-space characters are removed instead.</param>
    /// <returns>The resulting <see cref="string" /> after removing all characters passed
    /// in the <paramref name="trimChars" /> parameter from the beginning and end of the
    /// <see cref="string" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    public static string Trim(this string s, ReadOnlySpan<char> trimChars)
    {
        if (s is null)
        {
            throw new ArgumentNullException(nameof(s));
        }
        if (trimChars.Length == 0)
        {
            return s.Trim();
        }

        ReadOnlySpan<char> span = s.AsSpan().DoTrimEnd(trimChars).DoTrimStart(trimChars);

        return span.Length == s.Length
            ? s
            : span.Length == 0
                ? string.Empty
                : span.ToString();
    }

}
