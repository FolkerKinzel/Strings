using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>Appends a copy of the specified read-only character span followed by the
    /// standard line terminator to the end of a <see cref="StringBuilder" /> object.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to which the characters are
    /// appended.</param>
    /// <param name="value">The read-only character span to append.</param>
    /// <returns>A reference to <paramref name="builder" /> after the append operation has
    /// completed.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Increasing the capacity of <paramref
    /// name="builder" /> would exceed <see cref="StringBuilder.MaxCapacity" />.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendLine(this StringBuilder builder, ReadOnlySpan<char> value)
        => builder.Append(value).AppendLine();


    /// <summary>Appends a copy of the specified read-only character memory region followed
    /// by the standard line terminator to the end of a <see cref="StringBuilder" /> object.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to which the characters are
    /// appended.</param>
    /// <param name="value">The read-only character memory region to append.</param>
    /// <returns>A reference to <paramref name="builder" /> after the append operation has
    /// completed.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Increasing the capacity of <paramref
    /// name="builder" /> would exceed <see cref="StringBuilder.MaxCapacity" />.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendLine(this StringBuilder builder, ReadOnlyMemory<char> value)
        => builder.Append(value.Span).AppendLine();

}
