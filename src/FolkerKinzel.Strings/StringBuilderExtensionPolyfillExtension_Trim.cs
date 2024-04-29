namespace FolkerKinzel.Strings;

#if NET461 || NETSTANDARD2_0

public static partial class StringBuilderExtensionPolyfillExtension
{
    /// <summary>Removes all leading and trailing occurrences of a set of characters specified
    /// in a <see cref="string"/> from <paramref name="builder"/>.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="trimChars">A <see cref="string"/> that contains the Unicode characters to remove. If 
    /// <paramref name="trimChars" /> is an empty string, Unicode white-space characters are removed 
    /// instead.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder Trim(this StringBuilder builder, string? trimChars)
       => builder.Trim(trimChars.AsSpan());

    /// <summary>Removes all trailing occurrences of a set of characters specified in a 
    /// <see cref="string"/> from <paramref name="builder"/>.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="trimChars">A read-only span of Unicode characters to remove. If 
    /// <param name="trimChars">A <see cref="string"/> that contains the Unicode characters to remove. If 
    /// <paramref name="trimChars" /> is an empty string, Unicode white-space characters are removed 
    /// instead.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder TrimEnd(this StringBuilder builder, string? trimChars)
        => builder.TrimEnd(trimChars.AsSpan());

    /// <summary>Removes all leading occurrences of a set of characters specified in a 
    /// <see cref="string"/> from <paramref name="builder"/>.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="trimChars">A <see cref="string"/> that contains the Unicode characters to remove. If 
    /// <paramref name="trimChars" /> is an empty string, Unicode white-space characters are removed 
    /// instead.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder TrimStart(this StringBuilder builder, string? trimChars)
       => builder.TrimStart(trimChars.AsSpan());
}

#endif
