namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    // Benchmarks show that accessing the StringBuilder directly using a simple algorithm
    // is the most effective method here.

    /// <summary>Removes all the trailing white-space characters from the <paramref name="builder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder TrimEnd(this StringBuilder builder)
        => builder is null ? throw new ArgumentNullException(nameof(builder))
                           : builder.TrimEndIntl();

    /// <summary>Removes all the trailing white-space characters from <paramref name="builder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="trimChar">A Unicode character to remove.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder TrimEnd(this StringBuilder builder, char trimChar)
        => builder is null ? throw new ArgumentNullException(nameof(builder))
                           : builder.TrimEndIntl(trimChar);

    /// <summary>Removes all the trailing occurrences of a set of characters specified in
    /// an array from <paramref name="builder"/>.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="trimChars">An array of Unicode characters to remove, or <c>null</c>.
    /// If <paramref name="trimChars" /> is <c>null</c> or an empty array, Unicode white-space
    /// characters are removed instead.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder TrimEnd(this StringBuilder builder, params char[]? trimChars)
        => builder.TrimEnd(trimChars.AsSpan());

    /// <summary>Removes all trailing occurrences of a set of characters specified in a read-only 
    /// span from <paramref name="builder"/>.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="trimChars">A read-only span of Unicode characters to remove. If 
    /// <paramref name="trimChars" /> is an empty span, Unicode white-space characters are removed 
    /// instead.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder TrimEnd(this StringBuilder builder, ReadOnlySpan<char> trimChars)
    {
        return builder is null
            ? throw new ArgumentNullException(nameof(builder))
            : trimChars.Length == 0
                ? builder.TrimEndIntl()
                : builder.TrimEndIntl(trimChars);
    }

    private static StringBuilder TrimEndIntl(this StringBuilder builder)
    {
        int length = builder.Length;

        for (int i = length - 1; i >= 0; i--)
        {
            if (char.IsWhiteSpace(builder[i]))
            {
                --length;
            }
            else
            {
                break;
            }
        }

        builder.Length = length;
        return builder;
    }

    private static StringBuilder TrimEndIntl(this StringBuilder builder, char trimChar)
    {
        int length = builder.Length;

        for (int i = length - 1; i >= 0; i--)
        {
            if (trimChar == builder[i])
            {
                --length;
            }
            else
            {
                break;
            }
        }

        builder.Length = length;
        return builder;
    }

    private static StringBuilder TrimEndIntl(this StringBuilder builder,
                                             ReadOnlySpan<char> trimChars)
    {
        int length = builder.Length;

        for (int i = length - 1; i >= 0; i--)
        {
            if (trimChars.Contains(builder[i]))
            {
                --length;
            }
            else
            {
                break;
            }
        }

        builder.Length = length;
        return builder;
    }
}
