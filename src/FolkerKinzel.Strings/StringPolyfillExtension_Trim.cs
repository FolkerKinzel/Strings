using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

#if NET461 || NETSTANDARD2_0

public static partial class StringPolyfillExtension
{
    /// <summary>Generates a <see cref="string" /> from which all leading and trailing 
    /// occurrences of the characters in the specified read-only span are removed.</summary>
    /// <param name="s">The <see cref="string" /> to change.</param>
    /// <param name="trimChars">A <see cref="string"/> that contains the Unicode characters to remove. If 
    /// <paramref name="trimChars" /> is an empty string, Unicode white-space characters are 
    /// removed instead.</param>
    /// <returns>The resulting <see cref="string" /> after removing all characters passed
    /// in the <paramref name="trimChars" /> parameter from the beginning and end of the
    /// <see cref="string" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    public static string Trim(this string s, string? trimChars)
        => s.Trim(trimChars.AsSpan());

    /// <summary>Generates a <see cref="string" /> from which all trailing occurrences of
    /// the characters in the specified read-only span are removed.</summary>
    /// <param name="s">The <see cref="string" /> to change.</param>
    /// <param name="trimChars">A <see cref="string"/> that contains the Unicode characters to remove. If 
    /// <paramref name="trimChars" /> is an empty string, Unicode white-space characters are 
    /// removed instead.</param>
    /// <returns>The resulting <see cref="string" /> after removing all characters passed
    /// in the <paramref name="trimChars" /> parameter from the end of the 
    /// <see cref="string" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    public static string TrimEnd(this string s, string? trimChars)
        => s.TrimEnd(trimChars.AsSpan());

    /// <summary>Generates a <see cref="string" /> from which all leading occurrences of
    /// the characters in the specified read-only span are removed.</summary>
    /// <param name="s">The <see cref="string" /> to change.</param>
    /// <param name="trimChars">A <see cref="string"/> that contains the Unicode characters to remove. If 
    /// <paramref name="trimChars" /> is an empty string, Unicode white-space characters are 
    /// removed instead.</param>
    /// <returns>The resulting <see cref="string" /> after removing all characters passed
    /// in the <paramref name="trimChars" /> parameter from the beginning of the 
    /// <see cref="string" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    public static string TrimStart(this string s, string? trimChars)
        => s.TrimStart(trimChars.AsSpan());
}

#endif
