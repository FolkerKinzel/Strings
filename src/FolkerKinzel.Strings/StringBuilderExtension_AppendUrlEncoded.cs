using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>Appends the content of a read-only character span as URL-encoded string
    /// to the end of a <see cref="StringBuilder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to which the characters are
    /// appended.</param>
    /// <param name="value">The read-only character span that provides the characters that
    /// have to be encoded and appended.</param>
    /// <returns>A reference to <paramref name="builder" /> after the append operation has
    /// completed.</returns>
    /// <remarks>The method replaces all characters in <paramref name="value" /> except unreserved
    /// RFC 3986 characters into their hexadecimal representation. All Unicode characters
    /// are converted to UTF-8 format before being escaped. This method assumes that there
    /// are no escape sequences in <paramref name="value" />.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Increasing the capacity of <paramref
    /// name="builder" /> would exceed <see cref="StringBuilder.MaxCapacity" />.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendUrlEncoded(this StringBuilder builder, ReadOnlySpan<char> value)
        => UrlEncoding.AppendEncodedTo(builder, value);


    /// <summary>Appends the content of a <see cref="byte" /> collection as URL-encoded character
    /// sequence to the end of a <see cref="StringBuilder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to which the characters are
    /// appended.</param>
    /// <param name="value">The <see cref="byte" /> collection that contains the data, or
    /// <c>null</c>.</param>
    /// <returns>A reference to <paramref name="builder" /> after the append operation has
    /// completed.</returns>
    /// <remarks>The method treats all <see cref="byte" />s in <paramref name="value" />
    /// as 8-Bit characters and replaces all of them - except unreserved RFC 3986 characters
    /// - with their hexadecimal representation.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Increasing the capacity of <paramref
    /// name="builder" /> would exceed <see cref="StringBuilder.MaxCapacity" />.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendUrlEncoded(this StringBuilder builder, IEnumerable<byte>? value)
        => value is null
               ? builder
               : builder.AppendUrlEncoded(CollectionConverter.AsReadOnlySpan(value));


    /// <summary>Appends the content of a <see cref="byte" /> array as URL-encoded character
    /// sequence to the end of a <see cref="StringBuilder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to which the characters are
    /// appended.</param>
    /// <param name="value">The <see cref="byte" /> array that contains the data, or <c>null</c>.</param>
    /// <returns>A reference to <paramref name="builder" /> after the append operation has
    /// completed.</returns>
    /// <remarks>The method treats all <see cref="byte" />s in <paramref name="value" />
    /// as 8-Bit characters and replaces all of them - except unreserved RFC 3986 characters
    /// - with their hexadecimal representation.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Increasing the capacity of <paramref
    /// name="builder" /> would exceed <see cref="StringBuilder.MaxCapacity" />.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendUrlEncoded(this StringBuilder builder, byte[]? value)
        => UrlEncoding.AppendEncodedTo(builder, value.AsSpan());


    /// <summary>Appends the content of a read-only <see cref="byte" /> span as URL-encoded
    /// character sequence to the end of a <see cref="StringBuilder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to which the characters are
    /// appended.</param>
    /// <param name="value">The read-only <see cref="byte" /> span that contains the data.</param>
    /// <returns>A reference to <paramref name="builder" /> after the append operation has
    /// completed.</returns>
    /// <remarks>The method treats all <see cref="byte" />s in <paramref name="value" />
    /// as 8-Bit characters and replaces all of them - except unreserved RFC 3986 characters
    /// - with their hexadecimal representation.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Increasing the capacity of <paramref
    /// name="builder" /> would exceed <see cref="StringBuilder.MaxCapacity" />.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendUrlEncoded(this StringBuilder builder, ReadOnlySpan<byte> value)
        => UrlEncoding.AppendEncodedTo(builder, value);

}
