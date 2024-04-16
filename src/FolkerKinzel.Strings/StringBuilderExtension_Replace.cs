namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>Replaces all occurrences of a specified string in a substring of <paramref
    /// name="builder" /> with another specified string.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="oldValue">The string to replace.</param>
    /// <param name="newValue">The string that replaces <paramref name="oldValue" />, or
    /// <c>null</c>.</param>
    /// <param name="startIndex">The position in <paramref name="builder" /> where the substring
    /// begins.</param>
    /// <returns>A reference to <paramref name="builder" /> with all instances of <paramref
    /// name="oldValue" /> replaced by <paramref name="newValue" /> in the range from <paramref
    /// name="startIndex" /> to the end of <paramref name="builder" />.</returns>
    /// <remarks>This method performs an ordinal, case-sensitive comparison to identify occurrences
    /// of <paramref name="oldValue" /> in the specified substring. If 
    /// <paramref name="newValue" /> is <c>null</c> or <see cref="string.Empty" />, all occurrences 
    /// of <paramref name="oldValue" /> are removed.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> or <paramref
    /// name="oldValue" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException"> <paramref name="oldValue" /> is <see cref="string.Empty"
    /// />.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="startIndex" /> is less than zero.
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="startIndex" /> indicates a character position not within 
    /// <paramref name="builder" />.
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// Increasing the capacity of <paramref name="builder" /> would exceed 
    /// <see cref="StringBuilder.MaxCapacity" />.
    /// </para>
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder Replace(this StringBuilder builder,
                                        string oldValue,
                                        string? newValue,
                                        int startIndex)
        => builder?.Replace(oldValue, newValue, startIndex, builder.Length - startIndex) 
                  ?? throw new ArgumentNullException(nameof(builder));

    /// <summary>Replaces, within a substring of <paramref name="builder" />, all occurrences
    /// of a specified character with another specified character.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="oldChar">The character to replace.</param>
    /// <param name="newChar">The character that replaces <paramref name="oldChar" />.</param>
    /// <param name="startIndex">The position in <paramref name="builder" /> where the substring
    /// begins.</param>
    /// <returns>A reference to <paramref name="builder" /> with 
    /// <paramref name="oldChar" /> replaced by <paramref name="newChar" /> in the range from 
    /// <paramref name="startIndex" /> to the end of <paramref name="builder" />.</returns>
    /// <remarks>This method performs an ordinal, case-sensitive comparison to identify occurrences
    /// of <paramref name="oldChar" /> in the current instance. The size of 
    /// <paramref name="builder" /> is unchanged after the replacement.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="startIndex" /> is less than zero.
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="startIndex" /> indicates a character position not within <paramref
    /// name="builder" />.
    /// </para>
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder Replace(this StringBuilder builder,
                                        char oldChar,
                                        char newChar,
                                        int startIndex)
        => builder?.Replace(oldChar, newChar, startIndex, builder.Length - startIndex) 
                  ?? throw new ArgumentNullException(nameof(builder));

}
