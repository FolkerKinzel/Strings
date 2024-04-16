namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>Specifies the zero-based index of the first occurrence of the specified
    /// character in <paramref name="builder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <returns>The zero-based index position of <paramref name="value" /> from the beginning
    /// of the <see cref="StringBuilder" />, if this character was found, otherwise -1.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static int IndexOf(this StringBuilder builder, char value)
        => builder is null
                ? throw new ArgumentNullException(nameof(builder))
                : builder.IndexOf(value, 0, builder.Length);

    /// <summary>Returns the zero-based index of the first occurrence of the specified character
    /// in <paramref name="builder" />. The search starts at the specified index.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <param name="startIndex">The start index of the search.</param>
    /// <returns>The zero-based index position of <paramref name="value" /> from the beginning
    /// of the <see cref="StringBuilder" />, if this character was found, otherwise -1.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="startIndex" /> is
    /// less than zero or greater than the number of characters in <paramref name="builder"
    /// />.</exception>
    public static int IndexOf(this StringBuilder builder, char value, int startIndex)
        => builder is null
            ? throw new ArgumentNullException(nameof(builder))
            : builder.IndexOf(value, startIndex, builder.Length - startIndex);

    /// <summary>Returns the zero-based index of the first occurrence of the specified character
    /// in <paramref name="builder" />. The search begins at a specified index and a specified
    /// number of character positions are checked.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <param name="startIndex">The start index of the search.</param>
    /// <param name="count">The number of character positions to examine.</param>
    /// <returns>The zero-based index position of <paramref name="value" /> from the beginning
    /// of the <see cref="StringBuilder" />, if this character was found, otherwise -1.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="startIndex" /> or <paramref name="count" /> are smaller than zero
    /// or larger than the number of characters in <paramref name="builder" />
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="startIndex" /> + <paramref name="count" /> is larger than the number
    /// of characters in <paramref name="builder" />.
    /// </para>
    /// </exception>
    public static int IndexOf(this StringBuilder builder, char value, int startIndex, int count)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        if (startIndex < 0 || startIndex > builder.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex));
        }

        if (count < 0 || (count += startIndex) > builder.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        for (int i = startIndex; i < count; ++i)
        {
            if (value == builder[i])
            {
                return i;
            }
        }
        return -1;
    }
}
