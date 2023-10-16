namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    #region Trim

    /// <summary>Removes all leading and trailing white-space characters from the <see cref="StringBuilder"
    /// />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder Trim(this StringBuilder builder)
        => builder is null ? throw new ArgumentNullException(nameof(builder)) : builder.DoTrimEnd().DoTrimStart();


    /// <summary>Removes all leading and trailing instances of a character from the <see
    /// cref="StringBuilder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="trimChar">A Unicode character to remove.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder Trim(this StringBuilder builder, char trimChar)
        => builder is null ? throw new ArgumentNullException(nameof(builder)) : builder.DoTrimEnd(trimChar).DoTrimStart(trimChar);


    /// <summary>Removes all leading and trailing occurrences of a set of characters specified
    /// in an array from the <see cref="StringBuilder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="trimChars">An array of Unicode characters to remove, or <c>null</c>.
    /// If <paramref name="trimChars" /> is <c>null</c> or an empty array, Unicode white-space
    /// characters are removed instead.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder Trim(this StringBuilder builder, params char[]? trimChars)
       => builder is null
           ? throw new ArgumentNullException(nameof(builder))
           : trimChars is null || trimChars.Length == 0
               ? builder.DoTrimEnd().DoTrimStart()
               : builder.DoTrimEnd(trimChars).DoTrimStart(trimChars);


    /// <summary>Removes all leading and trailing occurrences of a set of characters specified
    /// in a Span from the <see cref="StringBuilder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="trimChars">A Span of Unicode characters to remove. If <paramref name="trimChars"
    /// /> is an empty Span, Unicode white-space characters are removed instead.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder Trim(this StringBuilder builder, ReadOnlySpan<char> trimChars)
       => builder is null
           ? throw new ArgumentNullException(nameof(builder))
           : trimChars.Length == 0
               ? builder.DoTrimEnd().DoTrimStart()
               : builder.DoTrimEnd(trimChars).DoTrimStart(trimChars);

    #endregion

}
