namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>Removes all the leading white-space characters from <paramref name="builder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder TrimStart(this StringBuilder builder)
        => builder is null ? throw new ArgumentNullException(nameof(builder)) : builder.DoTrimStart();

    /// <summary>Removes all the leading occurrences of a specified character from 
    /// <paramref name="builder"/>.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="trimChar">A Unicode character to remove.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder TrimStart(this StringBuilder builder, char trimChar)
       => builder is null ? throw new ArgumentNullException(nameof(builder)) : builder.DoTrimStart(trimChar);

    /// <summary>Removes all the leading occurrences of a set of characters specified in
    /// an array from <paramref name="builder"/>.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="trimChars">An array of Unicode characters to remove, or <c>null</c>.
    /// If <paramref name="trimChars" /> is <c>null</c> or an empty array, Unicode white-space
    /// characters are removed instead.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder TrimStart(this StringBuilder builder, params char[]? trimChars)
       => builder is null
            ? throw new ArgumentNullException(nameof(builder))
            : trimChars is null || trimChars.Length == 0
                ? builder.DoTrimStart()
                : builder.DoTrimStart(trimChars);

    /// <summary>Removes all leading occurrences of a set of characters specified in a read-only
    /// span from <paramref name="builder"/>.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="trimChars">A read-only span of Unicode characters to remove. If 
    /// <paramref name="trimChars" /> is an empty span, Unicode white-space characters are removed 
    /// instead.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder TrimStart(this StringBuilder builder, ReadOnlySpan<char> trimChars)
       => builder is null
            ? throw new ArgumentNullException(nameof(builder))
            : trimChars.Length == 0
                ? builder.DoTrimStart()
                : builder.DoTrimStart(trimChars);

    private static StringBuilder DoTrimStart(this StringBuilder stringBuilder)
    {
        int length = stringBuilder.Length;

        for (int j = 0; j < length; j++)
        {
            if (char.IsWhiteSpace(stringBuilder[j]))
            {
                continue;
            }
            else
            {
                return stringBuilder.Remove(0, j);
            }
        }

        return stringBuilder.Clear();
    }

    private static StringBuilder DoTrimStart(this StringBuilder stringBuilder, char trimChar)
    {
        int length = stringBuilder.Length;

        for (int j = 0; j < length; j++)
        {
            if (trimChar == stringBuilder[j])
            {
                continue;
            }
            else
            {
                return stringBuilder.Remove(0, j);
            }
        }

        return stringBuilder.Clear();
    }

    private static StringBuilder DoTrimStart(this StringBuilder stringBuilder, ReadOnlySpan<char> trimChars)
    {
        int length = stringBuilder.Length;

        for (int j = 0; j < length; j++)
        {
            if (trimChars.Contains(stringBuilder[j]))
            {
                continue;
            }
            else
            {
                return stringBuilder.Remove(0, j);
            }
        }

        return stringBuilder.Clear();
    }
}
