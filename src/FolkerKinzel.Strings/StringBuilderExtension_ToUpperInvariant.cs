using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>Converts the entire content of a <see cref="StringBuilder" /> to uppercase
    /// letters using the rules of the invariant culture.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder ToUpperInvariant(this StringBuilder builder)
        => builder is null ? throw new ArgumentNullException(nameof(builder))
                           : builder.ToUpperInvariant(0, builder.Length);

    /// <summary>Converts the content of a <see cref="StringBuilder" /> starting with <paramref
    /// name="startIndex" /> into uppercase letters and uses the rules of the invariant culture.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="startIndex">The zero-based index in <paramref name="builder" /> at which
    /// the conversion starts.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="startIndex" /> is
    /// less than zero or greater than the number of characters in <paramref name="builder"
    /// />.</exception>
    public static StringBuilder ToUpperInvariant(this StringBuilder builder, int startIndex)
        => builder is null ? throw new ArgumentNullException(nameof(builder))
                           : builder.ToUpperInvariant(startIndex, builder.Length - startIndex);

    /// <summary>Converts the content of a section in <see cref="StringBuilder" /> that begins
    /// at <paramref name="startIndex" /> and includes <paramref name="count" /> characters
    /// to uppercase using the rules of the invariant culture.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="startIndex">The zero-based index in <paramref name="builder" /> at which
    /// the conversion starts.</param>
    /// <param name="count">The number of characters to convert.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
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
    public static StringBuilder ToUpperInvariant(
        this StringBuilder builder, int startIndex, int count)
    {
        _ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        if (startIndex < 0 || startIndex > builder.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex));
        }

        if (count < 0 || (count += startIndex) > builder.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        for (int i = startIndex; i < count; i++)
        {
            builder[i] = char.ToUpperInvariant(builder[i]);
        }

        return builder;
    }
}
