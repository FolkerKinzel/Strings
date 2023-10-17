namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>Returns the zero-based index of the last occurrence of the specified character
    /// in <paramref name="builder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <returns>The zero-based index of the last occurence of <paramref name="value" />
    /// if that character is found, or -1 if it's not.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.
    /// </exception>
    public static int LastIndexOf(this StringBuilder builder, char value)
        => builder is null
                ? throw new ArgumentNullException(nameof(builder))
                : builder.LastIndexOf(value, builder.Length - 1, builder.Length);

    /// <summary>Returns the zero-based index of the last occurrence of the specified character
    /// in <paramref name="builder" />. The search begins at a specified character position
    /// and runs backwards to the beginning of the <see cref="StringBuilder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <param name="startIndex">The start index of the search. The search is done backwards
    /// to the beginning of <paramref name="builder" />.</param>
    /// <returns>The zero-based index of the last occurence of <paramref name="value" />
    /// if that character is found, or -1 if it's not.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="builder" /> is not
    /// empty and <paramref name="startIndex" /> is less than zero or greater than or equal
    /// to the length of <paramref name="builder" />.</exception>
    public static int LastIndexOf(this StringBuilder builder, char value, int startIndex)
        => builder is null
            ? throw new ArgumentNullException(nameof(builder))
            : builder.LastIndexOf(value, startIndex, startIndex + 1);


    /// <summary>Specifies the zero-based index of the last occurrence of the specified character
    /// in <paramref name="builder" />. The search begins at a specified index and runs backwards
    /// for a specified number of character positions to the beginning of the 
    /// <see cref="StringBuilder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <param name="startIndex">The start index of the search. The search is done backwards
    /// to the beginning of <paramref name="builder" />.</param>
    /// <param name="count">The number of character positions to examine.</param>
    /// <returns>If <paramref name="value" /> was found, the zero-based index position of
    /// its last occurrence within the section to be searched, otherwise -1.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="builder" /> is not empty and <paramref name="startIndex" /> is less
    /// than zero or greater than or equal to the length of <paramref name="builder" />
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="builder" /> is not empty and <paramref name="startIndex" /> - <paramref
    /// name="count" /> + 1 is less than zero.
    /// </para>
    /// </exception>
    public static int LastIndexOf(
        this StringBuilder builder, char value, int startIndex, int count)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        if (builder.Length == 0 || count == 0)
        {
            return -1;
        }

        if (startIndex < 0 || startIndex >= builder.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex));
        }

        int lastSearchIndex = startIndex - count + 1;
        if (count < 0 || lastSearchIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        for (int i = startIndex; i >= lastSearchIndex; i--)
        {
            if (value == builder[i])
            {
                return i;
            }
        }

        return -1;
    }

}
