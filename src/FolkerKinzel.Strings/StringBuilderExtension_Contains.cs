namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>Indicates whether a specified Unicode character is found in a 
    /// <see cref="StringBuilder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> has been found, 
    /// <c>false</c> otherwise.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is 
    /// <c>null</c>.</exception>
    public static bool Contains(this StringBuilder builder, char value)
        => builder is null ? throw new ArgumentNullException(nameof(builder))
                           : StringBuilderExtension.IndexOf(builder, value) != -1;

    /// <summary>Indicates whether a specified Unicode character is found in a 
    /// <see cref="StringBuilder" />. The search starts at the specified index.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <param name="startIndex">The start index of the search.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> is found, or <c>false</c> if 
    /// it's not.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="startIndex" /> is
    /// less than zero or greater than the number of characters in 
    /// <paramref name="builder" />.</exception>
    public static bool Contains(this StringBuilder builder, char value, int startIndex)
        => builder is null ? throw new ArgumentNullException(nameof(builder))
                           : StringBuilderExtension.IndexOf(builder, value, startIndex) != -1;

    /// <summary>Indicates whether a specified Unicode character is found in a <see cref="StringBuilder"
    /// />. The search begins at a specified index and a specified number of character positions
    /// are checked.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <param name="startIndex">The start index of the search.</param>
    /// <param name="count">The number of character positions to examine.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> is found, or <c>false</c> if it's
    /// not.</returns>
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
    public static bool Contains(this StringBuilder builder, char value, int startIndex, int count)
       => builder is null ? throw new ArgumentNullException(nameof(builder))
                          : StringBuilderExtension.IndexOf(builder, value, startIndex, count) != -1;
}
