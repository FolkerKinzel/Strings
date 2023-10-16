using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    #region TrimEnd

    /// <summary>Removes all the trailing white-space characters from the <see cref="StringBuilder"
    /// />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder TrimEnd(this StringBuilder builder)
        => builder is null ? throw new ArgumentNullException(nameof(builder)) : builder.DoTrimEnd();


    /// <summary>Removes all the trailing white-space characters from the <see cref="StringBuilder"
    /// />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="trimChar">A Unicode character to remove.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder TrimEnd(this StringBuilder builder, char trimChar)
        => builder is null ? throw new ArgumentNullException(nameof(builder)) : builder.DoTrimEnd(trimChar);


    /// <summary>Removes all the trailing occurrences of a set of characters specified in
    /// an array from the <see cref="StringBuilder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="trimChars">An array of Unicode characters to remove, or <c>null</c>.
    /// If <paramref name="trimChars" /> is <c>null</c> or an empty array, Unicode white-space
    /// characters are removed instead.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder TrimEnd(this StringBuilder builder, params char[]? trimChars)
    {
        return builder is null
            ? throw new ArgumentNullException(nameof(builder))
            : trimChars is null || trimChars.Length == 0
                ? builder.DoTrimEnd()
                : builder.DoTrimEnd(trimChars);
    }


    /// <summary>Removes all trailing occurrences of a set of characters specified in a Span
    /// from the <see cref="StringBuilder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="trimChars">A Span of Unicode characters to remove. If <paramref name="trimChars"
    /// /> is an empty Span, Unicode white-space characters are removed instead.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder TrimEnd(this StringBuilder builder, ReadOnlySpan<char> trimChars)
    {
        return builder is null
            ? throw new ArgumentNullException(nameof(builder))
            : trimChars.Length == 0
                ? builder.DoTrimEnd()
                : builder.DoTrimEnd(trimChars);
    }

    #endregion

    #region private Methods

    #region DoTrimEnd

    private static StringBuilder DoTrimEnd(this StringBuilder stringBuilder)
    {
        int length = stringBuilder.Length;

        for (int i = length - 1; i >= 0; i--)
        {
            if (char.IsWhiteSpace(stringBuilder[i]))
            {
                --length;
            }
            else
            {
                break;
            }
        }

        stringBuilder.Length = length;
        return stringBuilder;
    }


    private static StringBuilder DoTrimEnd(this StringBuilder stringBuilder, char trimChar)
    {
        int length = stringBuilder.Length;

        for (int i = length - 1; i >= 0; i--)
        {
            if (trimChar == stringBuilder[i])
            {
                --length;
            }
            else
            {
                break;
            }
        }

        stringBuilder.Length = length;
        return stringBuilder;
    }


    private static StringBuilder DoTrimEnd(this StringBuilder stringBuilder, ReadOnlySpan<char> trimChars)
    {
        int length = stringBuilder.Length;

        for (int i = length - 1; i >= 0; i--)
        {
            if (trimChars.Contains(stringBuilder[i]))
            {
                --length;
            }
            else
            {
                break;
            }
        }

        stringBuilder.Length = length;
        return stringBuilder;
    }

    #endregion

    #endregion

}
