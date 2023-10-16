namespace FolkerKinzel.Strings;

/// <summary>Extension methods for the <see cref="Encoding" /> class.</summary>
public static class EncodingExtension
{
    /// <summary>Encodes all characters of the read-only character span to a corresponding
    /// <see cref="byte"/> array.</summary>
    /// <param name="encoding">The <see cref="Encoding" /> object on which the extension
    /// method is executed.</param>
    /// <param name="chars">The read-only character span that provides the characters that
    /// have to be encoded.</param>
    /// <returns>A <see cref="byte"/> array containing the results of the encoding.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="encoding" /> is <c>null</c>.</exception>
    public static byte[] GetBytes(this Encoding encoding, ReadOnlySpan<char> chars)
    {
        if (encoding == null)
        {
            throw new ArgumentNullException(nameof(encoding));
        }
#if NET45 || NETSTANDARD2_0
        return encoding.GetBytes(chars.ToArray());
#else
        byte[] bytes = new byte[encoding.GetByteCount(chars)];

        _ = encoding.GetBytes(chars, bytes);
        return bytes;
#endif
    }

    // Don't move this polyfill to the namespace FolkerKinzel.Strings.Polyfills because it polyfills an
    // instance method.
#if NET45 || NETSTANDARD2_0
    /// <summary>Decodes all bytes in the specified read-only span into a <see cref="string"/>.</summary>
    /// <param name="encoding">The <see cref="Encoding" /> object on which the extension
    /// method is executed.</param>
    /// <param name="bytes">A read-only <see cref="byte"/> span that is converted to a <see cref="string"/>.</param>
    /// <returns>A <see cref="string"/> decoded from the specified <see cref="byte"/> span.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="encoding" /> is <c>null</c>.</exception>
    /// <remarks>This method is a polyfill for the instance method of current .NET versions.
    /// Use this method in the extension method syntax only.</remarks>
    public static string GetString(this Encoding encoding, ReadOnlySpan<byte> bytes) =>
        encoding == null ? throw new NullReferenceException()
                         : encoding.GetString(bytes.ToArray());
#endif
}
