using System.Text.RegularExpressions;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtensionPolyfillExtension
{
    /// <summary>Appends the content of a <see cref="string" /> as URL-encoded character
    /// sequence to the end of a <see cref="StringBuilder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to which the characters are
    /// appended.</param>
    /// <param name="value">The <see cref="string" /> containing the characters to encode
    /// and append, or <c>null</c>.</param>
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
#if NET462 || NETSTANDARD2_0
    public static StringBuilder AppendUrlEncoded(this StringBuilder builder, string? value)
#else
    public static StringBuilder AppendUrlEncoded(StringBuilder builder, string? value)
#endif
        => UrlEncoding.AppendEncodedTo(builder, value.AsSpan());
}


