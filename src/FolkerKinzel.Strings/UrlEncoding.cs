using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static class UrlEncoding
{
    private const int SHORT_ARRAY = 256;

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
    internal static StringBuilder AppendUrlEncodedTo(StringBuilder builder, ReadOnlySpan<char> value)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        _ = builder.EnsureCapacity((int)(builder.Length + value.Length * 2.3));

#if NET45 || NETSTANDARD2_0
        byte[] encoded = Encoding.UTF8.GetBytes(value);
#else
        int length = Encoding.UTF8.GetByteCount(value);
        Span<byte> encoded = length > SHORT_ARRAY ? new byte[length] : stackalloc byte[length];
        Encoding.UTF8.GetBytes(value, encoded);
#endif
        for (int i = 0; i < encoded.Length; i++)
        {
            builder.AppendCharacter((char)encoded[i]);
        }

        return builder;
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
         !(c.IsAsciiLetter() || c.IsDecimalDigit() || c is '.' or '-' or '_' or '~');

    #endregion

#if NET45 || NETSTANDARD2_0

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryDecode(string? value, string? encodingWebName, [NotNullWhen(true)] out string? decoded)
        => TryDecode(value.AsSpan(), encodingWebName, out decoded);


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryDecode(string? value, int codePage, [NotNullWhen(true)] out string? decoded)
        => TryDecode(value.AsSpan(), codePage, out decoded);


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryDecode(string? value, [NotNullWhen(true)] out string? decoded)
        => TryDecode(value.AsSpan(), out decoded);

#endif


    public static bool TryDecode(ReadOnlySpan<char> value, string? encodingWebName, [NotNullWhen(true)] out string? decoded)
    {
        try
        {
            decoded = UnescapeValueFromUrlEncoding(value, TextEncodingHelper.InitThrowing(encodingWebName));
            return true;
        }
        catch
        {
            decoded = null;
            return false;
        }
    }

    public static bool TryDecode(ReadOnlySpan<char> value, int codePage, [NotNullWhen(true)] out string? decoded)
    {
        try
        {
            decoded = UnescapeValueFromUrlEncoding(value, TextEncodingHelper.InitThrowing(codePage));
            return true;
        }
        catch
        {
            decoded = null;
            return false;
        }
    }

    public static bool TryDecode(ReadOnlySpan<char> value, [NotNullWhen(true)] out string? decoded)
    {
        try
        {
            decoded = UnescapeValueFromUrlEncoding(value, TextEncodingHelper.InitThrowingUtf8());
            return true;
        }
        catch
        {
            decoded = null;
            return false;
        }
    }

    /// <summary>
    /// Removes URL encoding from <paramref name="value"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    /// <exception cref="DecoderFallbackException"></exception>
    /// <exception cref="EncoderFallbackException"></exception>
    private static string UnescapeValueFromUrlEncoding(ReadOnlySpan<char> value, Encoding encoding)
    {
        const byte spaceChar = (byte)' ';

        Span<byte> bytes = value.Length > SHORT_ARRAY ? new byte[value.Length]
                                                      : stackalloc byte[value.Length];

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
                    bytes[byteIndex++] = spaceChar;
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

        return encoding.GetString(bytes.Slice(0, byteIndex));
    }

}
