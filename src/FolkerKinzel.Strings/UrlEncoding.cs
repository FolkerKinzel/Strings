using System.Text;
using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

    /// <summary>Static class that provides methods for handling URL encoding (RFC 3986).</summary>
public static class UrlEncoding
{
    private const int SHORT_ARRAY = 256;

    /// <summary>Factor by which the number of bytes to be encoded is multiplied to estimate
    /// the length of the encoded output.</summary>
    public const double EncodedLengthFactor = 2.5;

    private static class TextEncodingHelper
    {
        private const string UTF_8 = "utf-8";

        internal static Encoding InitThrowing(string? charSetName)
        => TextEncodingConverter.GetEncoding(string.IsNullOrEmpty(charSetName) ? UTF_8 : charSetName,
                                            EncoderFallback.ExceptionFallback,
                                            DecoderFallback.ExceptionFallback,
                                            true);

        internal static Encoding InitThrowing(int codePage)
        => TextEncodingConverter.GetEncoding(codePage,
                                            EncoderFallback.ExceptionFallback,
                                            DecoderFallback.ExceptionFallback,
                                            true);

        internal static Encoding InitThrowingUtf8()
        => TextEncodingConverter.GetEncoding(TextEncodingConverter.UTF_8,
                                             EncoderFallback.ExceptionFallback,
                                             DecoderFallback.ExceptionFallback);
    }

    #region Encode

    internal static StringBuilder AppendUrlEncodedTo(StringBuilder builder, ReadOnlySpan<byte> value)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        AppendData(builder, value);
        return builder;
    }


    internal static StringBuilder AppendUrlEncodedTo(StringBuilder builder, ReadOnlySpan<char> value)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }


#if NET45 || NETSTANDARD2_0
        byte[] encoded = Encoding.UTF8.GetBytes(value);
#else
        int length = Encoding.UTF8.GetByteCount(value);
        Span<byte> encoded = length > SHORT_ARRAY ? new byte[length] : stackalloc byte[length];
        Encoding.UTF8.GetBytes(value, encoded);
#endif

        AppendData(builder, encoded);
        return builder;
    }


    private static void AppendData(StringBuilder builder, ReadOnlySpan<byte> encoded)
    {
        _ = builder.EnsureCapacity((int)(builder.Length + encoded.Length * EncodedLengthFactor));

        for (int i = 0; i < encoded.Length; i++)
        {
            builder.AppendCharacter((char)encoded[i]);
        }
    }

    private static void AppendCharacter(this StringBuilder sb, char c)
    {
        if (MustEncode(c))
        {
            sb.AppendHexEncoded(c);
        }
        else
        {
            _ = sb.Append(c);
        }
    }

    private static void AppendHexEncoded(this StringBuilder sb, char c)
        => _ = sb.Append('%').Append(ToHexDigit(c >> 4)).Append(ToHexDigit(c & 0x0F));

    private static char ToHexDigit(int i) =>
        (char)(i < 10 ? i + '0' : i + 'A' - 10);

    private static bool MustEncode(char c) =>
         !(c.IsAsciiLetterOrDigit() || c is '.' or '-' or '_' or '~');

    #endregion

#if NET45 || NETSTANDARD2_0

    /// <summary>Tries to decode a URL-encoded <see cref="string" /> using a specified character
    /// set and allows to specify whether or not PLUS characters ('+', U+002B) should be
    /// decoded as SPACE characters (' ', U+0020).</summary>
    /// <param name="value">The <see cref="string" /> to decode, or <c>null</c>.</param>
    /// <param name="encodingWebName">The standardized web name of the character set to use,
    /// or <c>null</c> or <see cref="string.Empty" /> as a replacement for "utf-8".</param>
    /// <param name="decodePlusChars"> <c>true</c> to decode PLUS characters ('+', U+002B)
    /// as SPACE characters (' ', U+0020), or <c>false</c> to include the PLUS characters
    /// unchanged in <paramref name="decoded" />.</param>
    /// <param name="decoded">After the method completes successfully, contains a <see cref="string"
    /// /> that represents the decoded content of <paramref name="value" />.</param>
    /// <returns> <c>true</c> if the decoding was successful, otherwise <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryDecode(string? value,
                                 string? encodingWebName,
                                 bool decodePlusChars,
                                 [NotNullWhen(true)] out string? decoded)
        => TryDecode(value.AsSpan(), encodingWebName, decodePlusChars, out decoded);


    /// <summary>Tries to decode a URL-encoded <see cref="string" /> using a specified code
    /// page and allows to specify whether or not PLUS characters ('+', U+002B) should be
    /// decoded as SPACE characters (' ', U+0020).</summary>
    /// <param name="value">The <see cref="string" /> to decode, or <c>null</c>.</param>
    /// <param name="codePage">The code page to use.</param>
    /// <param name="decodePlusChars"> <c>true</c> to decode PLUS characters ('+', U+002B)
    /// as SPACE characters (' ', U+0020), or <c>false</c> to include the PLUS characters
    /// unchanged in <paramref name="decoded" />.</param>
    /// <param name="decoded">After the method completes successfully, contains a <see cref="string"
    /// /> that represents the decoded content of <paramref name="value" />.</param>
    /// <returns> <c>true</c> if the decoding was successful, otherwise <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryDecode(string? value,
                                 int codePage,
                                 bool decodePlusChars,
                                 [NotNullWhen(true)] out string? decoded)
        => TryDecode(value.AsSpan(), codePage, decodePlusChars, out decoded);


    /// <summary>Tries to decode a URL-encoded <see cref="string" /> using the UTF-8 character
    /// set and allows to specify whether or not PLUS characters ('+', U+002B) should be
    /// decoded as SPACE characters (' ', U+0020).</summary>
    /// <param name="value">The <see cref="string" /> to decode, or <c>null</c>.</param>
    /// <param name="decodePlusChars"> <c>true</c> to decode PLUS characters ('+', U+002B)
    /// as SPACE characters (' ', U+0020), or <c>false</c> to include the PLUS characters
    /// unchanged in <paramref name="decoded" />.</param>
    /// <param name="decoded">After the method completes successfully, contains a <see cref="string"
    /// /> that represents the decoded content of <paramref name="value" />.</param>
    /// <returns> <c>true</c> if the decoding was successful, otherwise <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryDecode(string? value,
                                 bool decodePlusChars,
                                 [NotNullWhen(true)] out string? decoded)
        => TryDecode(value.AsSpan(), decodePlusChars, out decoded);


    /// <summary>Tries to decode a URL-encoded <see cref="string" /> to a <see cref="byte"
    /// /> array and allows to specify whether or not PLUS characters ('+', U+002B) should
    /// be decoded to <c>0x20</c> (SPACE ' ').</summary>
    /// <param name="value">The <see cref="string" /> to decode, or <c>null</c>.</param>
    /// <param name="decodePlusChars"> <c>true</c> to decode PLUS characters ('+', U+002B)
    /// to <c>0x20</c> (SPACE ' '), or <c>false</c> to include the PLUS characters unchanged
    /// as <c>0x2B</c> in <paramref name="bytes" />.</param>
    /// <param name="bytes">After the method completes successfully, contains a <see cref="byte"
    /// /> array that represents the decoded content of <paramref name="value" />.</param>
    /// <returns> <c>true</c> if the decoding was successful, otherwise <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryDecodeToBytes(string? value,
                                        bool decodePlusChars,
                                        [NotNullWhen(true)] out byte[]? bytes)
        => TryDecodeToBytes(value.AsSpan(), decodePlusChars, out bytes);

#endif

    /// <summary>Tries to decode a URL-encoded read-only character span using a specified
    /// character set and allows to specify whether or not PLUS characters ('+', U+002B)
    /// should be decoded as SPACE characters (' ', U+0020).</summary>
    /// <param name="value">The read-only character span to decode.</param>
    /// <param name="encodingWebName">The standardized web name of the character set to use,
    /// or <c>null</c> or <see cref="string.Empty" /> as a replacement for "utf-8".</param>
    /// <param name="decodePlusChars"> <c>true</c> to decode PLUS characters ('+', U+002B)
    /// as SPACE characters (' ', U+0020), or <c>false</c> to include the PLUS characters
    /// unchanged in <paramref name="decoded" />.</param>
    /// <param name="decoded">After the method completes successfully, contains a <see cref="string"
    /// /> that represents the decoded content of <paramref name="value" />.</param>
    /// <returns> <c>true</c> if the decoding was successful, otherwise <c>false</c>.</returns>
    public static bool TryDecode(ReadOnlySpan<char> value,
                                 string? encodingWebName,
                                 bool decodePlusChars,
                                 [NotNullWhen(true)] out string? decoded)
    {
        try
        {
            decoded = UnescapeValueFromUrlEncoding(value, TextEncodingHelper.InitThrowing(encodingWebName), decodePlusChars);
            return true;
        }
        catch
        {
            decoded = null;
            return false;
        }
    }


    /// <summary>Tries to decode a URL-encoded read-only character span using a specified
    /// code page and allows to specify whether or not PLUS characters ('+', U+002B) should
    /// be decoded as SPACE characters (' ', U+0020).</summary>
    /// <param name="value">The read-only character span to decode.</param>
    /// <param name="codePage">The code page to use.</param>
    /// <param name="decodePlusChars"> <c>true</c> to decode PLUS characters ('+', U+002B)
    /// as SPACE characters (' ', U+0020), or <c>false</c> to include the PLUS characters
    /// unchanged in <paramref name="decoded" />.</param>
    /// <param name="decoded">After the method completes successfully, contains a <see cref="string"
    /// /> that represents the decoded content of <paramref name="value" />.</param>
    /// <returns> <c>true</c> if the decoding was successful, otherwise <c>false</c>.</returns>
    public static bool TryDecode(ReadOnlySpan<char> value,
                                 int codePage,
                                 bool decodePlusChars,
                                 [NotNullWhen(true)] out string? decoded)
    {
        try
        {
            decoded = UnescapeValueFromUrlEncoding(value, TextEncodingHelper.InitThrowing(codePage), decodePlusChars);
            return true;
        }
        catch
        {
            decoded = null;
            return false;
        }
    }

    /// <summary>Tries to decode a URL-encoded read-only character span using the UTF-8 character
    /// set and allows to specify whether or not PLUS characters ('+', U+002B) should be
    /// decoded as SPACE characters (' ', U+0020).</summary>
    /// <param name="value">The read-only character span to decode.</param>
    /// <param name="decodePlusChars"> <c>true</c> to decode PLUS characters ('+', U+002B)
    /// as SPACE characters (' ', U+0020), or <c>false</c> to include the PLUS characters
    /// unchanged in <paramref name="decoded" />.</param>
    /// <param name="decoded">After the method completes successfully, contains a <see cref="string"
    /// /> that represents the decoded content of <paramref name="value" />.</param>
    /// <returns> <c>true</c> if the decoding was successful, otherwise <c>false</c>.</returns>
    public static bool TryDecode(ReadOnlySpan<char> value,
                                 bool decodePlusChars,
                                 [NotNullWhen(true)] out string? decoded)
    {
        try
        {
            decoded = UnescapeValueFromUrlEncoding(value, TextEncodingHelper.InitThrowingUtf8(), decodePlusChars);
            return true;
        }
        catch
        {
            decoded = null;
            return false;
        }
    }


    /// <summary>Tries to decode a URL-encoded read-only character span to a <see cref="byte"
    /// /> array and allows to specify whether or not PLUS characters ('+', U+002B) should
    /// be decoded as <c>0x20</c> (SPACE ' ').</summary>
    /// <param name="value">The read-only character span to decode.</param>
    /// <param name="decodePlusChars"> <c>true</c> to decode PLUS characters ('+', U+002B)
    /// to <c>0x20</c> (SPACE ' '), or <c>false</c> to include the PLUS characters unchanged
    /// as <c>0x2B</c> in <paramref name="bytes" />.</param>
    /// <param name="bytes">After the method completes successfully, contains a <see cref="byte"
    /// /> array that represents the decoded content of <paramref name="value" />.</param>
    /// <returns> <c>true</c> if the decoding was successful, otherwise <c>false</c>.</returns>
    public static bool TryDecodeToBytes(ReadOnlySpan<char> value,
                                        bool decodePlusChars,
                                        [NotNullWhen(true)] out byte[]? bytes)
    {
        Span<byte> decoded = value.Length > SHORT_ARRAY ? new byte[value.Length]
                                                        : stackalloc byte[value.Length];

        try
        {
            bytes = FillBytes(value, decodePlusChars, decoded).ToArray();
            return true;
        }
        catch
        {
            bytes = null;
            return false;
        }
    }

    /// <summary />
    /// <param name="value" />
    /// <param name="encoding" />
    /// <param name="decodePlusSigns" />
    /// <returns />
    private static string UnescapeValueFromUrlEncoding(ReadOnlySpan<char> value, Encoding encoding, bool decodePlusSigns)
    {
        Span<byte> bytes = value.Length > SHORT_ARRAY ? new byte[value.Length]
                                                      : stackalloc byte[value.Length];

        return encoding.GetString(FillBytes(value, decodePlusSigns, bytes));
    }


    private static ReadOnlySpan<byte> FillBytes(ReadOnlySpan<char> value, bool decodePlusSigns, Span<byte> bytes)
    {
        const byte spaceChar = (byte)' ';
        const byte plusChar = (byte)'+';

        int byteIndex = 0;

        for (int i = 0; i < value.Length; i++)
        {
            char c = value[i];

            if (c > 127)
            {
                throw new EncoderFallbackException();
            }

            switch (c)
            {
                case '+':
                    bytes[byteIndex++] = decodePlusSigns ? spaceChar : plusChar;
                    continue;
                case '%':
#if NET45 || NETSTANDARD2_0
                    bytes[byteIndex++] = byte.Parse(value.Slice(i + 1, 2).ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);
#else
                    bytes[byteIndex++] = byte.Parse(value.Slice(i + 1, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
#endif
                    i += 2;
                    continue;
                default:
                    bytes[byteIndex++] = (byte)c;
                    continue;
            }
        }

        return bytes.Slice(0, byteIndex);
    }
}
