using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringPolyfillExtension
{
    /// <summary>Generates a <see cref="string" /> from which all leading and trailing 
    /// occurrences of the characters in the specified read-only span are removed.</summary>
    /// <param name="s">The <see cref="string" /> to change.</param>
    /// <param name="trimChars">A read-only span of Unicode characters to remove. If 
    /// <paramref name="trimChars" /> is an empty span, Unicode white-space characters are 
    /// removed instead.</param>
    /// <returns>The resulting <see cref="string" /> after removing all characters passed
    /// in the <paramref name="trimChars" /> parameter from the beginning and end of the
    /// <see cref="string" />.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
#if NET8_0 || NET7_0 || NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET461
    public static string Trim(this string s, ReadOnlySpan<char> trimChars)
    {
        _NullReferenceException.ThrowIfNull(s, nameof(s));

        ReadOnlySpan<char> span = s.AsSpan().Trim(trimChars);

        return span.Length == s.Length
            ? s
            : span.Length == 0
                ? string.Empty
                : span.ToString();
    }
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Trim(string s, ReadOnlySpan<char> trimChars)
        => s.Trim(trimChars);
#endif

    /// <summary>Generates a <see cref="string" /> from which all trailing occurrences of
    /// the characters in the specified read-only span are removed.</summary>
    /// <param name="s">The <see cref="string" /> to change.</param>
    /// <param name="trimChars">A read-only span of Unicode characters to remove. If 
    /// <paramref name="trimChars" /> is an empty span, Unicode white-space characters are 
    /// removed instead.</param>
    /// <returns>The resulting <see cref="string" /> after removing all characters passed
    /// in the <paramref name="trimChars" /> parameter from the end of the 
    /// <see cref="string" />.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
#if NET8_0 || NET7_0 || NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET461
    public static string TrimEnd(this string s, ReadOnlySpan<char> trimChars)
    {
        _NullReferenceException.ThrowIfNull(s, nameof(s));

        ReadOnlySpan<char> span = s.AsSpan().TrimEnd(trimChars);

        return span.Length == s.Length
            ? s
            : span.Length == 0
                ? string.Empty
                : span.ToString();
    }
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string TrimEnd(string s, ReadOnlySpan<char> trimChars)
     => s.TrimEnd(trimChars);
#endif

    /// <summary>Generates a <see cref="string" /> from which all leading occurrences of
    /// the characters in the specified read-only span are removed.</summary>
    /// <param name="s">The <see cref="string" /> to change.</param>
    /// <param name="trimChars">A read-only span of Unicode characters to remove. If 
    /// <paramref name="trimChars" /> is an empty span, Unicode white-space characters are 
    /// removed instead.</param>
    /// <returns>The resulting <see cref="string" /> after removing all characters passed
    /// in the <paramref name="trimChars" /> parameter from the beginning of the 
    /// <see cref="string" />.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
#if NET8_0 || NET7_0 || NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET461
    public static string TrimStart(this string s, ReadOnlySpan<char> trimChars)
    {
        _NullReferenceException.ThrowIfNull(s, nameof(s));

        ReadOnlySpan<char> span = s.AsSpan().TrimStart(trimChars);

        return span.Length == s.Length
            ? s
            : span.Length == 0
                ? string.Empty
                : span.ToString();
    }
#else
    public static string TrimStart(string s, ReadOnlySpan<char> trimChars)
        => s.TrimStart(trimChars);
#endif

    /// <summary>Generates a <see cref="string" /> from which all leading and trailing 
    /// occurrences of the characters in the specified read-only span are removed.</summary>
    /// <param name="s">The <see cref="string" /> to change.</param>
    /// <param name="trimChars">A <see cref="string"/> that contains the Unicode characters to remove or <c>null</c>. If 
    /// <paramref name="trimChars" /> is <c>null</c> or an empty string, Unicode white-space characters are 
    /// removed instead.</param>
    /// <returns>The resulting <see cref="string" /> after removing all characters passed
    /// in the <paramref name="trimChars" /> parameter from the beginning and end of the
    /// <see cref="string" />.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
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
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
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
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET461 || NETSTANDARD2_0
    public static string TrimStart(this string s, string? trimChars)
#else
    public static string TrimStart(string s, string? trimChars)
#endif
        => s.TrimStart(trimChars.AsSpan());
}

