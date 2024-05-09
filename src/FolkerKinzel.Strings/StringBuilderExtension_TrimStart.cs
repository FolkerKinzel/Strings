namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    // Benchmarks show that accessing the StringBuilder directly using a simple algorithm
    // is the most effective method here.

    /// <summary>Removes all the leading white-space characters from <paramref name="builder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder TrimStart(this StringBuilder builder)
        => builder is null ? throw new ArgumentNullException(nameof(builder)) 
                           : builder.TrimStartIntl();

    /// <summary>Removes all the leading occurrences of a specified character from 
    /// <paramref name="builder"/>.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="trimChar">A Unicode character to remove.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder TrimStart(this StringBuilder builder, char trimChar)
       => builder is null ? throw new ArgumentNullException(nameof(builder)) 
                          : builder.TrimStartIntl(trimChar);

    /// <summary>Removes all the leading occurrences of a set of characters specified in
    /// an array from <paramref name="builder"/>.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="trimChars">An array of Unicode characters to remove, or <c>null</c>.
    /// If <paramref name="trimChars" /> is <c>null</c> or an empty array, Unicode white-space
    /// characters are removed instead.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder TrimStart(this StringBuilder builder, params char[]? trimChars)
       => builder.TrimStart(trimChars.AsSpan());

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
                ? builder.TrimStartIntl()
                : builder.TrimStartIntl(trimChars);

    private static StringBuilder TrimStartIntl(this StringBuilder builder)
    {
        int length = builder.Length;

        for (int j = 0; j < length; j++)
        {
            if (char.IsWhiteSpace(builder[j]))
            {
                continue;
            }
            else
            {
                return builder.Remove(0, j);
            }
        }

        return builder.Clear();
    }

    private static StringBuilder TrimStartIntl(this StringBuilder builder, char trimChar)
    {
        int length = builder.Length;

        for (int j = 0; j < length; j++)
        {
            if (trimChar == builder[j])
            {
                continue;
            }
            else
            {
                return builder.Remove(0, j);
            }
        }

        return builder.Clear();
    }

    private static StringBuilder TrimStartIntl(this StringBuilder builder, ReadOnlySpan<char> trimChars)
    {
        int length = builder.Length;

        for (int j = 0; j < length; j++)
        {
            if (trimChars.Contains(builder[j]))
            {
                continue;
            }
            else
            {
                return builder.Remove(0, j);
            }
        }

        return builder.Clear();
    }
}
