namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>Indicates whether the specified Unicode character matches the end of the
    /// <see cref="StringBuilder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is examined.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> matches the end of <paramref name="builder"
    /// />; otherwise, <c>false</c>.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static bool EndsWith(this StringBuilder builder, char value)
     => builder is null ? throw new ArgumentNullException(nameof(builder))
                        : builder.Length != 0 && builder[builder.Length - 1] == value;
}
