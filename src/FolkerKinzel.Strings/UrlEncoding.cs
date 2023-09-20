using System.Text;
using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

/// <summary>
/// Statische Klasse, die Methoden zur Behandlung von URL-Enkodierung (RFC 3986) zur Verfügung stellt.
/// </summary>
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
        _ = builder.EnsureCapacity((int)(builder.Length + encoded.Length * 2.5));

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

    /// <summary>
    /// Versucht, einen URL-kodierten <see cref="string"/> unter Verwendung eines angegebenen
    /// Zeichensatzes zu dekodieren und erlaubt es anzugeben, ob Pluszeichen ('+', U+002B) als Leerzeichen (' ', U+0020)
    /// dekodiert werden.
    /// </summary>
    /// <param name="value">Der zu dekodierende <see cref="string"/>.</param>
    /// <param name="encodingWebName">Der standardisierte Internetname des zu verwendenden Zeichensatzes oder <c>null</c>
    /// bzw. ein leerer <see cref="string"/> als Ersatz für "utf-8".</param>
    /// <param name="decodePlusChars"><c>true</c>, um Pluszeichen ('+', U+002B) als Leerzeichen (' ', U+0020) zu
    /// dekodieren oder <c>false</c>, um Pluszeichen unverändert in <paramref name="decoded"/> zu übertragen.</param>
    /// <param name="decoded">Enthält nach erfolgreicher Beendigung der Methode einen <see cref="string"/>, der den
    /// dekodierten Inhalt von <paramref name="value"/> repräsentiert.</param>
    /// <returns><c>true</c>, wenn die Dekodierung erfolgreich war, andernfalls <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryDecode(string? value,
                                 string? encodingWebName,
                                 bool decodePlusChars,
                                 [NotNullWhen(true)] out string? decoded)
        => TryDecode(value.AsSpan(), encodingWebName, decodePlusChars, out decoded);


    /// <summary>
    /// Versucht, einen URL-kodierten <see cref="string"/> unter Verwendung einer angegebenen
    /// Codepage zu dekodieren und erlaubt es anzugeben, ob Pluszeichen ('+', U+002B) als Leerzeichen (' ', U+0020)
    /// dekodiert werden.
    /// </summary>
    /// <param name="value">Der zu dekodierende <see cref="string"/>.</param>
    /// <param name="codePage">Die Codepage des zu verwendenden Zeichensatzes.</param>
    /// <param name="decodePlusChars"><c>true</c>, um Pluszeichen ('+', U+002B) als Leerzeichen (' ', U+0020) zu
    /// dekodieren oder <c>false</c>, um Pluszeichen unverändert in <paramref name="decoded"/> zu übertragen.</param>
    /// <param name="decoded">Enthält nach erfolgreicher Beendigung der Methode einen <see cref="string"/>, der den
    /// dekodierten Inhalt von <paramref name="value"/> repräsentiert.</param>
    /// <returns><c>true</c>, wenn die Dekodierung erfolgreich war, andernfalls <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryDecode(string? value,
                                 int codePage,
                                 bool decodePlusChars,
                                 [NotNullWhen(true)] out string? decoded)
        => TryDecode(value.AsSpan(), codePage, decodePlusChars, out decoded);


    /// <summary>
    /// Versucht, einen URL-kodierten <see cref="string"/> unter Verwendung des UTF-8-Zeichensatzes
    /// zu dekodieren und erlaubt es anzugeben, ob Pluszeichen ('+', U+002B) als Leerzeichen (' ', U+0020)
    /// dekodiert werden.
    /// </summary>
    /// <param name="value">Der zu dekodierende <see cref="string"/>.</param>
    /// <param name="decodePlusChars"><c>true</c>, um Pluszeichen ('+', U+002B) als Leerzeichen (' ', U+0020) zu
    /// dekodieren oder <c>false</c>, um Pluszeichen unverändert in <paramref name="decoded"/> zu übertragen.</param>
    /// <param name="decoded">Enthält nach erfolgreicher Beendigung der Methode einen <see cref="string"/>, der den
    /// dekodierten Inhalt von <paramref name="value"/> repräsentiert.</param>
    /// <returns><c>true</c>, wenn die Dekodierung erfolgreich war, andernfalls <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryDecode(string? value,
                                 bool decodePlusChars,
                                 [NotNullWhen(true)] out string? decoded)
        => TryDecode(value.AsSpan(), decodePlusChars, out decoded);


    /// <summary>
    /// Versucht, einen URL-kodierten <see cref="string"/> als <see cref="byte"/>-Array
    /// zu dekodieren.
    /// </summary>
    /// <param name="value">Der zu dekodierende <see cref="string"/>.</param>
    /// <param name="bytes">Enthält nach erfolgreicher Beendigung der Methode ein <see cref="byte"/>-Array, das
    /// den dekodierten Inhalt von <paramref name="value"/> repräsentiert.</param>
    /// <returns><c>true</c>, wenn die Dekodierung erfolgreich war, andernfalls <c>false</c>.</returns>
    /// <remarks>Die Methode dekodiert Pluszeichen ('+', U+002B) als <c>0x20</c>.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryDecodeToBytes(string? value, [NotNullWhen(true)] out byte[]? bytes)
        => TryDecodeToBytes(value.AsSpan(), out bytes);

#endif

    /// <summary>
    /// Versucht, den URL-kodierten Inhalt einer schreibgeschützten Zeichenspanne unter Verwendung eines angegebenen
    /// Zeichensatzes zu dekodieren und erlaubt es anzugeben, ob Pluszeichen ('+', U+002B) als Leerzeichen (' ', U+0020)
    /// dekodiert werden.
    /// </summary>
    /// <param name="value">Die zu dekodierende schreibgeschützte Zeichenspanne.</param>
    /// <param name="encodingWebName">Der standardisierte Internetname des zu verwendenden Zeichensatzes oder <c>null</c>
    /// bzw. ein leerer <see cref="string"/> als Ersatz für "utf-8".</param>
    /// <param name="decodePlusChars"><c>true</c>, um Pluszeichen ('+', U+002B) als Leerzeichen (' ', U+0020) zu
    /// dekodieren oder <c>false</c>, um Pluszeichen unverändert in <paramref name="decoded"/> zu übertragen.</param>
    /// <param name="decoded">Enthält nach erfolgreicher Beendigung der Methode einen <see cref="string"/>, der den
    /// dekodierten Inhalt von <paramref name="value"/> repräsentiert.</param>
    /// <returns><c>true</c>, wenn die Dekodierung erfolgreich war, andernfalls <c>false</c>.</returns>
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


    /// <summary>
    /// Versucht, den URL-kodierten Inhalt einer schreibgeschützten Zeichenspanne unter Verwendung einer angegebenen
    /// Codepage zu dekodieren und erlaubt es anzugeben, ob Pluszeichen ('+', U+002B) als Leerzeichen (' ', U+0020)
    /// dekodiert werden.
    /// </summary>
    /// <param name="value">Die zu dekodierende schreibgeschützte Zeichenspanne.</param>
    /// <param name="codePage">Die Codepage des zu verwendenden Zeichensatzes.</param>
    /// <param name="decodePlusChars"><c>true</c>, um Pluszeichen ('+', U+002B) als Leerzeichen (' ', U+0020) zu
    /// dekodieren oder <c>false</c>, um Pluszeichen unverändert in <paramref name="decoded"/> zu übertragen.</param>
    /// <param name="decoded">Enthält nach erfolgreicher Beendigung der Methode einen <see cref="string"/>, der den
    /// dekodierten Inhalt von <paramref name="value"/> repräsentiert.</param>
    /// <returns><c>true</c>, wenn die Dekodierung erfolgreich war, andernfalls <c>false</c>.</returns>
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

    /// <summary>
    /// Versucht, den URL-kodierten Inhalt einer schreibgeschützten Zeichenspanne unter Verwendung des UTF-8-Zeichensatzes
    /// zu dekodieren und erlaubt es anzugeben, ob Pluszeichen ('+', U+002B) als Leerzeichen (' ', U+0020)
    /// dekodiert werden.
    /// </summary>
    /// <param name="value">Die zu dekodierende schreibgeschützte Zeichenspanne.</param>
    /// <param name="decodePlusChars"><c>true</c>, um Pluszeichen ('+', U+002B) als Leerzeichen (' ', U+0020) zu
    /// dekodieren oder <c>false</c>, um Pluszeichen unverändert in <paramref name="decoded"/> zu übertragen.</param>
    /// <param name="decoded">Enthält nach erfolgreicher Beendigung der Methode einen <see cref="string"/>, der den
    /// dekodierten Inhalt von <paramref name="value"/> repräsentiert.</param>
    /// <returns><c>true</c>, wenn die Dekodierung erfolgreich war, andernfalls <c>false</c>.</returns>
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


    /// <summary>
    /// Versucht, den URL-kodierten Inhalt einer schreibgeschützten Zeichenspanne als <see cref="byte"/>-Array
    /// zu dekodieren.
    /// </summary>
    /// <param name="value">Die zu dekodierende schreibgeschützte Zeichenspanne.</param>
    /// <param name="bytes">Enthält nach erfolgreicher Beendigung der Methode ein <see cref="byte"/>-Array, das
    /// den dekodierten Inhalt von <paramref name="value"/> repräsentiert.</param>
    /// <returns><c>true</c>, wenn die Dekodierung erfolgreich war, andernfalls <c>false</c>.</returns>
    /// <remarks>Die Methode dekodiert Pluszeichen ('+', U+002B) als <c>0x20</c>.</remarks>
    public static bool TryDecodeToBytes(ReadOnlySpan<char> value, [NotNullWhen(true)] out byte[]? bytes)
    {
        Span<byte> decoded = value.Length > SHORT_ARRAY ? new byte[value.Length]
                                                        : stackalloc byte[value.Length];

        try
        {
            bytes = FillBytes(value, true, decoded).ToArray();
            return true;
        }
        catch
        {
            bytes = null;
            return false;
        }
    }

    /// <summary>
    /// Removes URL encoding from <paramref name="value"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="encoding"></param>
    /// <param name="decodePlusSigns"></param>
    /// <returns></returns>
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
