namespace FolkerKinzel.Strings;

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
#if NET461 || NETSTANDARD2_0
    public static StringBuilder Trim(this StringBuilder builder, string? trimChars)
#else
    public static StringBuilder Trim(StringBuilder builder, string? trimChars)
#endif
       => builder.Trim(trimChars.AsSpan());

    /// <summary>Removes all trailing occurrences of a set of characters specified in a 
    /// <see cref="string"/> from <paramref name="builder"/>.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="trimChars">A <see cref="string"/> that contains the Unicode characters to remove. If 
    /// <paramref name="trimChars" /> is an empty string, Unicode white-space characters are removed 
    /// instead.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET461 || NETSTANDARD2_0
    public static StringBuilder TrimEnd(this StringBuilder builder, string? trimChars)
#else
    public static StringBuilder TrimEnd(StringBuilder builder, string? trimChars)
#endif
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
#if NET461 || NETSTANDARD2_0
    public static StringBuilder TrimStart(this StringBuilder builder, string? trimChars)
#else
    public static StringBuilder TrimStart(StringBuilder builder, string? trimChars)
#endif
       => builder.TrimStart(trimChars.AsSpan());
}