namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>Indicates whether the <see cref="StringBuilder" /> contains white space.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <returns> <c>true</c> if <paramref name="builder" /> contains white space, otherwise
    /// <c>false</c>.</returns>
    /// <remarks> <see cref="char.IsWhiteSpace(char)" /> is used to identify white space.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static bool ContainsWhiteSpace(this StringBuilder builder)
        => builder is null
                ? throw new ArgumentNullException(nameof(builder))
                : builder.ContainsWhiteSpace(0, builder.Length);


    /// <summary>Examines a section of the <see cref="StringBuilder" /> that begins at <paramref
    /// name="startIndex" /> to see whether it contains white space.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <param name="startIndex">The zero-based index in <paramref name="builder" /> at which
    /// the examination begins.</param>
    /// <returns> <c>true</c> if the specified section in <paramref name="builder" /> contains
    /// white space, otherwise <c>false</c>.</returns>
    /// <remarks> <see cref="char.IsWhiteSpace(char)" /> is used to identify white space.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="startIndex" /> is
    /// less than zero or greater than the number of characters in <paramref name="builder"
    /// />.</exception>
    public static bool ContainsWhiteSpace(this StringBuilder builder, int startIndex)
        => builder is null
            ? throw new ArgumentNullException(nameof(builder))
            : builder.ContainsWhiteSpace(startIndex, builder.Length - startIndex);


    /// <summary>Examines a section of the <see cref="StringBuilder" /> that begins at <paramref
    /// name="startIndex" /> and includes <paramref name="count" /> characters to determine
    /// whether this section contains white space.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <param name="startIndex">The zero-based index in <paramref name="builder" /> at which
    /// the examination begins.</param>
    /// <param name="count">The number of character positions to examine.</param>
    /// <returns> <c>true</c> if the specified section in <paramref name="builder" /> contains
    /// white space, otherwise <c>false</c>.</returns>
    /// <remarks> <see cref="char.IsWhiteSpace(char)" /> is used to identify white space.</remarks>
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
    public static bool ContainsWhiteSpace(this StringBuilder builder, int startIndex, int count)
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
            if (char.IsWhiteSpace(builder[i]))
            {
                return true;
            }
        }
        return false;
    }


}
