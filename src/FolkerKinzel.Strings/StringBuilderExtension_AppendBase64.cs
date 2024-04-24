using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>Appends the content of a <see cref="byte" /> collection as Base64-encoded
    /// character sequence to the end of a <see cref="StringBuilder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to which the characters are
    /// appended.</param>
    /// <param name="bytes">The <see cref="byte" /> collection that contains the data, or
    /// <c>null</c>.</param>
    /// <param name="options">An enumeration value that allows specifying whether line breaks
    /// should be automatically inserted into the Base64.</param>
    /// <returns>A reference to <paramref name="builder" /> after the append operation has
    /// completed.</returns>
    /// <remarks>The method uses it's own Base64 implementation that is a little slower than
    /// the BCL methods but allocates much less heap memory.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Increasing the capacity of <paramref
    /// name="builder" /> would exceed <see cref="StringBuilder.MaxCapacity" />.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendBase64(this StringBuilder builder,
                                             IEnumerable<byte>? bytes,
                                             Base64FormattingOptions options = Base64FormattingOptions.None)
        => bytes is null ? builder
                         : Base64.AppendEncodedTo(builder, CollectionConverter.AsReadOnlySpan(bytes), options);

    /// <summary>Appends the content of a <see cref="byte" /> array as Base64-encoded character
    /// sequence to the end of a <see cref="StringBuilder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to which the characters are
    /// appended.</param>
    /// <param name="bytes">The <see cref="byte" /> array that contains the data, or <c>null</c>.</param>
    /// <param name="options">An enumeration value that allows specifying whether line breaks
    /// should be automatically inserted into the Base64.</param>
    /// <returns>A reference to <paramref name="builder" /> after the append operation has
    /// completed.</returns>
    /// <remarks>The method uses it's own Base64 implementation that is a little slower than
    /// the BCL methods but allocates much less heap memory.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Increasing the capacity of <paramref
    /// name="builder" /> would exceed <see cref="StringBuilder.MaxCapacity" />.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendBase64(this StringBuilder builder,
                                             byte[]? bytes,
                                             Base64FormattingOptions options = Base64FormattingOptions.None)
        => Base64.AppendEncodedTo(builder, bytes.AsSpan(), options);

    /// <summary>Appends the content of a read-only <see cref="byte" /> span as Base64-encoded
    /// character sequence to the end of a <see cref="StringBuilder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to which the characters are
    /// appended.</param>
    /// <param name="bytes">The read-only <see cref="byte" /> span that contains the data.</param>
    /// <param name="options">An enumeration value that allows specifying whether line breaks
    /// should be automatically inserted into the Base64.</param>
    /// <returns>A reference to <paramref name="builder" /> after the append operation has
    /// completed.</returns>
    /// <remarks>The method uses it's own Base64 implementation that is a little slower than
    /// the BCL methods but allocates much less heap memory.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Increasing the capacity of <paramref
    /// name="builder" /> would exceed <see cref="StringBuilder.MaxCapacity" />.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendBase64(this StringBuilder builder,
                                             ReadOnlySpan<byte> bytes,
                                             Base64FormattingOptions options = Base64FormattingOptions.None)
        => Base64.AppendEncodedTo(builder, bytes, options);
}
