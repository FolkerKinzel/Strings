using FolkerKinzel.Helpers.Polyfills;
using FolkerKinzel.Strings.Intls;

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
        _ArgumentNullException.ThrowIfNull(encoding, nameof(encoding));

#if NET462 || NETSTANDARD2_0
        int length = chars.Length;
        using ArrayPoolHelper.SharedArray<char> shared = ArrayPoolHelper.Rent<char>(length);
        var arr = shared.Array;
        chars.CopyTo(arr);
        return encoding.GetBytes(arr, 0, length);
#else
        byte[] bytes = new byte[encoding.GetByteCount(chars)];

        _ = encoding.GetBytes(chars, bytes);
        return bytes;
#endif
    }

    /// <summary>Decodes all bytes in the specified read-only span into a <see cref="string"/>.</summary>
    /// <param name="encoding">The <see cref="Encoding" /> object on which the extension
    /// method is executed.</param>
    /// <param name="bytes">A read-only <see cref="byte"/> span that is converted to a <see cref="string"/>.</param>
    /// <returns>A <see cref="string"/> decoded from the specified <see cref="byte"/> span.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="encoding" /> is <c>null</c>.</exception>
    /// <remarks>This method is a polyfill for the instance method of current .NET versions.
    /// Use this method in the extension method syntax only.</remarks>
#if NET462 || NETSTANDARD2_0
    public static string GetString(this Encoding encoding, ReadOnlySpan<byte> bytes)
    {
        _NullReferenceException.ThrowIfNull(encoding, nameof(encoding));

        int length = bytes.Length;
        using ArrayPoolHelper.SharedArray<byte> shared = ArrayPoolHelper.Rent<byte>(length);
        var arr = shared.Array;
        bytes.CopyTo(arr);
        return encoding.GetString(arr, 0, length);
    }
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetString(Encoding encoding, ReadOnlySpan<byte> bytes)
        => encoding.GetString(bytes);
#endif
}
