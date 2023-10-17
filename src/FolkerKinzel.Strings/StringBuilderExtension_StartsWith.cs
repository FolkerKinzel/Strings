namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>Indicates whether the specified Unicode character matches the beginning
    /// of <paramref name="builder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is examined.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <returns> <c>true</c> if value matches the beginning of <paramref name="builder"
    /// />; otherwise, <c>false</c>.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static bool StartsWith(this StringBuilder builder, char value)
     => builder is null ? throw new ArgumentNullException(nameof(builder))
                        : builder.Length != 0 && builder[0] == value;

}
