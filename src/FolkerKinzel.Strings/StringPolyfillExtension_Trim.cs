namespace FolkerKinzel.Strings;

public static partial class StringPolyfillExtension
{
    /// <summary>Generates a <see cref="string" /> from which all leading and trailing 
    /// occurrences of the characters in the specified read-only span are removed.</summary>
    /// <param name="s">The <see cref="string" /> to change.</param>
    /// <param name="trimChars">A <see cref="string"/> that contains the Unicode characters to remove or <c>null</c>. If 
    /// <paramref name="trimChars" /> is <c>null</c> or an empty string, Unicode white-space characters are 
    /// removed instead.</param>
    /// <returns>The resulting <see cref="string" /> after removing all characters passed
    /// in the <paramref name="trimChars" /> parameter from the beginning and end of the
    /// <see cref="string" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET461 || NETSTANDARD2_0
    public static string Trim(this string s, string? trimChars)
#else
    public static string Trim(string s, string? trimChars)
#endif
        => s.Trim(trimChars.AsSpan());

    /// <summary>Generates a <see cref="string" /> from which all trailing occurrences of
    /// the characters in the specified read-only span are removed.</summary>
    /// <param name="s">The <see cref="string" /> to change.</param>
    /// <param name="trimChars">A <see cref="string"/> that contains the Unicode characters to remove or <c>null</c>. If 
    /// <paramref name="trimChars" /> is <c>null</c> or an empty string, Unicode white-space characters are 
    /// removed instead.</param>
    /// <returns>The resulting <see cref="string" /> after removing all characters passed
    /// in the <paramref name="trimChars" /> parameter from the end of the 
    /// <see cref="string" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET461 || NETSTANDARD2_0
    public static string TrimEnd(this string s, string? trimChars)
#else
    public static string TrimEnd(string s, string? trimChars)
#endif
        => s.TrimEnd(trimChars.AsSpan());

    /// <summary>Generates a <see cref="string" /> from which all leading occurrences of
    /// the characters in the specified read-only span are removed.</summary>
    /// <param name="s">The <see cref="string" /> to change.</param>
    /// <param name="trimChars">A <see cref="string"/> that contains the Unicode characters to remove or <c>null</c>. If 
    /// <paramref name="trimChars" /> is <c>null</c> or an empty string, Unicode white-space characters are 
    /// removed instead.</param>
    /// <returns>The resulting <see cref="string" /> after removing all characters passed
    /// in the <paramref name="trimChars" /> parameter from the beginning of the 
    /// <see cref="string" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET461 || NETSTANDARD2_0
    public static string TrimStart(this string s, string? trimChars)
#else
    public static string TrimStart(string s, string? trimChars)
#endif
        => s.TrimStart(trimChars.AsSpan());
}

