using FolkerKinzel.Strings.Intls;
using FolkerKinzel.Strings.Properties;

namespace FolkerKinzel.Strings;

/// <summary>Encapsulates methods that support creating appropriate instances of the
/// <see cref="Encoding" /> class.</summary>
public static class TextEncodingConverter
{
    internal const int UTF_8 = 65001;
    private const int CODEPAGE_MIN = 1;
    private const int CODEPAGE_MAX = 65535;

    /// <summary>Returns a corresponding <see cref="Encoding" /> object for the specified
    /// identifier of a character set.</summary>
    /// <param name="encodingWebName">The identifier of the character set.</param>
    /// <param name="throwOnInvalidWebName">Pass <c>true</c> to have the method throw an
    /// <see cref="ArgumentException" /> if <paramref name="encodingWebName" /> could not
    /// be converted.</param>
    /// <returns>An <see cref="Encoding" /> object that corresponds to the specified character
    /// set identifier. If no match is found, <see cref="Encoding.UTF8" /> is returned by
    /// default. If the method is called with <c>true</c> as an argument for the <paramref
    /// name="throwOnInvalidWebName" /> parameter, an <see cref="ArgumentException" /> will
    /// be thrown instead.</returns>
    /// <remarks>
    /// <para>
    /// .NET Standard and .NET 5.0 or later only recognize a small number of character sets
    /// by default. The method overrides this default.
    /// </para>
    /// <para>
    /// The properties <see cref="Encoding.EncoderFallback" /> and <see cref="Encoding.DecoderFallback"
    /// /> of the generated <see cref="Encoding" /> object are set to ReplacementFallback.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentException"> <paramref name="encodingWebName" /> could not
    /// be mapped to a <see cref="Encoding" /> object. An exception is only thrown if the
    /// optional parameter <paramref name="throwOnInvalidWebName" /> is <c>true</c>.</exception>
    public static Encoding GetEncoding(string? encodingWebName, bool throwOnInvalidWebName = false)
    {
        return throwOnInvalidWebName
            ? TryGetEncodingInternal(
                encodingWebName, null, null, out Encoding? encoding, out Exception? exception)
                ? encoding
                : throw exception
            : TryGetEncoding(encodingWebName, out encoding)
                ? encoding
                : Encoding.UTF8;
    }

    /// <summary>Returns a corresponding <see cref="Encoding" /> object for the specified
    /// identifier of a character set, whose properties <see cref="Encoding.EncoderFallback"
    /// /> and <see cref="Encoding.DecoderFallback" /> are set to the desired values.</summary>
    /// <param name="encodingWebName">The identifier of the character set.</param>
    /// <param name="encoderFallback">An object that provides an error handling mechanism
    /// if a character cannot be encoded with the <see cref="Encoding" /> object.</param>
    /// <param name="decoderFallback">An object that provides an error handling mechanism
    /// if a <see cref="byte" /> sequence cannot be decoded with the <see cref="Encoding"
    /// /> object .</param>
    /// <param name="throwOnInvalidWebName">Pass <c>true</c> to have the method throw an
    /// <see cref="ArgumentException" /> if <paramref name="encodingWebName" /> could not
    /// be converted.</param>
    /// <returns>An <see cref="Encoding" /> object that corresponds to the specified identifier
    /// of a character set and whose properties <see cref="Encoding.EncoderFallback" /> and
    /// <see cref="Encoding.DecoderFallback" /> are set to the desired values. If no match
    /// is found, a corresponding <see cref="P:System.Text.Encoding" /> object for UTF-8
    /// is returned by default. If the method is called with <c>true</c> as an argument for
    /// the <paramref name="throwOnInvalidWebName" /> parameter, an <see cref="ArgumentException"
    /// /> will be thrown instead.</returns>
    /// <remarks>.NET Standard and .NET 5.0 or higher recognize by default only a small number
    /// of character sets. The method overrides this default setting.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="encoderFallback" /> or <paramref
    /// name="decoderFallback" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException"> <paramref name="encodingWebName" /> could not
    /// be mapped to a <see cref="Encoding" /> object. An exception is only thrown if the
    /// optional parameter <paramref name="throwOnInvalidWebName" /> is <c>true</c>.</exception>
    public static Encoding GetEncoding(string? encodingWebName,
                                       EncoderFallback encoderFallback,
                                       DecoderFallback decoderFallback,
                                       bool throwOnInvalidWebName = false)
    {
        ThrowOnEncoderAndDecoderFallbackNull(encoderFallback, decoderFallback);

        return throwOnInvalidWebName
            ? TryGetEncodingInternal(encodingWebName,
                                     encoderFallback,
                                     decoderFallback,
                                     out Encoding? encoding,
                                     out Exception? exception)
                ? encoding
                : throw exception
            : TryGetEncodingInternal(
                encodingWebName, encoderFallback, decoderFallback, out encoding)
                ? encoding
                : CreateFallBack(encoderFallback, decoderFallback);
    }

    /// <summary>Returns a corresponding <see cref="Encoding" /> object for the specified
    /// code page number.</summary>
    /// <param name="codePage">
    /// <para>
    /// The code page number.
    /// </para>
    /// <note type="caution">
    /// <c>0</c> is treated as an invalid argument. This behavior is different from that
    /// of the <see cref="Encoding" /> class.
    /// </note>
    /// </param>
    /// <param name="throwOnInvalidCodePage">Pass <c>true</c> to have the method throw an
    /// <see cref="ArgumentException" /> if <paramref name="codePage" /> could not be converted.</param>
    /// <returns>An <see cref="Encoding" /> object that corresponds to the specified code
    /// page number. If no match is found, <see cref="Encoding.UTF8" /> is returned by default.
    /// If the method is called with <c>true</c> as an argument for the <paramref name="throwOnInvalidCodePage"
    /// /> parameter, an <see cref="ArgumentException" /> will be thrown instead.</returns>
    /// <remarks>
    /// <para>
    /// .NET Standard and .NET 5.0 or later only recognize a small number of character sets
    /// by default. The method overrides this default.
    /// </para>
    /// <para>
    /// The properties <see cref="Encoding.EncoderFallback" /> and <see cref="Encoding.DecoderFallback"
    /// /> of the generated <see cref="Encoding" /> object are set to ReplacementFallback.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="codePage" /> is less
    /// than 1 or greater than 65535. This exception is only thrown if the optional parameter
    /// <paramref name="throwOnInvalidCodePage" /> is <c>true</c>.</exception>
    /// <exception cref="ArgumentException"> <paramref name="codePage" /> could not be mapped
    /// to a <see cref="Encoding" /> object. This exception is only thrown if the optional
    /// parameter <paramref name="throwOnInvalidCodePage" /> is <c>true</c>.</exception>
    public static Encoding GetEncoding(int codePage, bool throwOnInvalidCodePage = false)
    {
        return throwOnInvalidCodePage
            ? TryGetEncodingInternal(
                codePage, null, null, out Encoding? encoding, out Exception? exception)
                ? encoding
                : throw exception
            : TryGetEncoding(codePage, out encoding)
                ? encoding
                : Encoding.UTF8;
    }

    /// <summary>Returns a corresponding <see cref="Encoding" /> object for a specified code
    /// page number, whose properties <see cref="Encoding.EncoderFallback" /> and 
    /// <see cref="Encoding.DecoderFallback" /> are set to the desired values.</summary>
    /// <param name="codePage">
    /// <para>
    /// The code page number.
    /// </para>
    /// <note type="caution">
    /// <c>0</c> is treated as an invalid argument. This behavior is different from that
    /// of the <see cref="Encoding" /> class.
    /// </note>
    /// </param>
    /// <param name="encoderFallback">An object that provides an error handling mechanism
    /// if a character cannot be encoded with the <see cref="Encoding" /> object.</param>
    /// <param name="decoderFallback">An object that provides an error handling mechanism
    /// if a <see cref="byte" /> sequence cannot be decoded with the <see cref="Encoding"
    /// /> object .</param>
    /// <param name="throwOnInvalidCodePage">Pass <c>true</c> to have the method throw an
    /// <see cref="ArgumentException" /> if <paramref name="codePage" /> could not be converted.</param>
    /// <returns>An <see cref="Encoding" /> object that corresponds to the specified code
    /// page number and whose properties <see cref="Encoding.EncoderFallback" /> and <see
    /// cref="Encoding.DecoderFallback" /> are set to the desired values. If no match is
    /// found, a corresponding <see cref="P:System.Text.Encoding" /> object for UTF-8 is
    /// returned by default. If the method is called with <c>true</c> as an argument for
    /// the <paramref name="throwOnInvalidCodePage" /> parameter, an <see cref="ArgumentException"
    /// /> will be thrown instead.</returns>
    /// <remarks>.NET Standard and .NET 5.0 or higher recognize by default only a small number
    /// of character sets. The method overrides this default setting.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="encoderFallback" /> or <paramref
    /// name="decoderFallback" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="codePage" /> is less
    /// than 1 or greater than 65535. This exception is only thrown if the optional parameter
    /// <paramref name="throwOnInvalidCodePage" /> is <c>true</c>.</exception>
    /// <exception cref="ArgumentException"> <paramref name="codePage" /> could not be mapped
    /// to a <see cref="Encoding" /> object. This exception is only thrown if the optional
    /// parameter <paramref name="throwOnInvalidCodePage" /> is <c>true</c>.</exception>
    public static Encoding GetEncoding(int codePage,
                                       EncoderFallback encoderFallback,
                                       DecoderFallback decoderFallback,
                                       bool throwOnInvalidCodePage = false)
    {
        ThrowOnEncoderAndDecoderFallbackNull(encoderFallback, decoderFallback);

        return throwOnInvalidCodePage
           ? TryGetEncodingInternal(codePage,
                                    encoderFallback,
                                    decoderFallback,
                                    out Encoding? encoding,
                                    out Exception? exception)
               ? encoding
               : throw exception
           : TryGetEncodingInternal(
               codePage, encoderFallback, decoderFallback, out encoding)
                ? encoding
                : CreateFallBack(encoderFallback, decoderFallback);
    }

    /// <summary>Tries to return a corresponding <see cref="Encoding" /> object for the specified
    /// identifier of a character set.</summary>
    /// <param name="encodingWebName">The identifier of the character set.</param>
    /// <param name="encoding">When this method returns <c>true</c>, contains an <see cref="Encoding"
    /// /> object that matches the specified identifier of a character set, <c>null</c> otherwise.
    /// This parameter is passed uninitialized.</param>
    /// <returns> <c>true</c> if the conversion was successful, <c>false</c> otherwise.</returns>
    /// <remarks>
    /// <para>
    /// .NET Standard and .NET 5.0 or later only recognize a small number of character sets
    /// by default. The method overrides this default.
    /// </para>
    /// <para>
    /// The properties <see cref="Encoding.EncoderFallback" /> and <see cref="Encoding.DecoderFallback"
    /// /> of the generated <see cref="Encoding" /> object are set to ReplacementFallback.
    /// </para>
    /// </remarks>
    public static bool TryGetEncoding(string? encodingWebName, [NotNullWhen(true)] out Encoding? encoding)
    {
        encoding = null;
        return !IsWebNameEmpty(encodingWebName) &&
                BuildEncoding(encodingWebName, null, null, ref encoding, out _);
    }

    /// <summary>Tries to return a corresponding <see cref="Encoding" /> object for the specified
    /// identifier of a character set, whose properties <see cref="Encoding.EncoderFallback"
    /// /> and <see cref="Encoding.DecoderFallback" /> are set to the desired values.</summary>
    /// <param name="encodingWebName">The identifier of the character set.</param>
    /// <param name="encoderFallback">An object that provides an error handling mechanism
    /// if a character cannot be encoded with the <see cref="Encoding" /> object.</param>
    /// <param name="decoderFallback">An object that provides an error handling mechanism
    /// if a <see cref="byte" /> sequence cannot be decoded with the <see cref="Encoding"
    /// /> object .</param>
    /// <param name="encoding">When this method returns <c>true</c>, contains an <see cref="Encoding"
    /// /> object that matches the specified identifier of a character set and whose properties
    /// <see cref="Encoding.EncoderFallback" /> und <see cref="Encoding.DecoderFallback"
    /// /> are set to the desired values, <c>null</c> otherwise. This parameter is passed
    /// uninitialized.</param>
    /// <returns> <c>true</c> if the conversion was successful, <c>false</c> otherwise.</returns>
    /// <remarks>.NET Standard and .NET 5.0 or higher recognize by default only a small number
    /// of character sets. The method overrides this default setting.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="encoderFallback" /> or <paramref
    /// name="decoderFallback" /> is <c>null</c>.</exception>
    public static bool TryGetEncoding(string? encodingWebName,
                                      EncoderFallback encoderFallback,
                                      DecoderFallback decoderFallback,
                                      [NotNullWhen(true)] out Encoding? encoding)
    {
        ThrowOnEncoderAndDecoderFallbackNull(encoderFallback, decoderFallback);
        return TryGetEncodingInternal(encodingWebName,
                                      encoderFallback,
                                      decoderFallback,
                                      out encoding);
    }

    /// <summary>Tries to return a corresponding <see cref="Encoding" /> object for the specified
    /// code page number.</summary>
    /// <param name="codePage">
    /// <para>
    /// The code page number.
    /// </para>
    /// <note type="caution">
    /// <c>0</c> is treated as an invalid argument. This behavior is different from that
    /// of the <see cref="Encoding" /> class.
    /// </note>
    /// </param>
    /// <param name="encoding">When this method returns <c>true</c>, contains an <see cref="Encoding"
    /// /> object that matches the specified code page number, <c>null</c> otherwise. This
    /// parameter is passed uninitialized.</param>
    /// <returns> <c>true</c> if the conversion was successful, <c>false</c> otherwise.</returns>
    /// <remarks>
    /// <para>
    /// .NET Standard and .NET 5.0 or later only recognize a small number of character sets
    /// by default. The method overrides this default.
    /// </para>
    /// <para>
    /// The properties <see cref="Encoding.EncoderFallback" /> and <see cref="Encoding.DecoderFallback"
    /// /> of the generated <see cref="Encoding" /> object are set to ReplacementFallback.
    /// </para>
    /// </remarks>
    public static bool TryGetEncoding(int codePage, [NotNullWhen(true)] out Encoding? encoding)
    {
        encoding = null;
        return !CodepageOutOfRange(codePage) && BuildEncoding(codePage, null, null, ref encoding, out _);
    }

    /// <summary>Tries to return a corresponding <see cref="Encoding" /> object for the specified
    /// code page number, whose properties <see cref="Encoding.EncoderFallback" /> and <see
    /// cref="Encoding.DecoderFallback" /> are set to the desired values.</summary>
    /// <param name="codePage">
    /// <para>
    /// The code page number.
    /// </para>
    /// <note type="caution">
    /// <c>0</c> is treated as an invalid argument. This behavior is different from that
    /// of the <see cref="Encoding" /> class.
    /// </note>
    /// </param>
    /// <param name="encoderFallback">An object that provides an error handling mechanism
    /// if a character cannot be encoded with the <see cref="Encoding" /> object.</param>
    /// <param name="decoderFallback">An object that provides an error handling mechanism
    /// if a <see cref="byte" /> sequence cannot be decoded with the <see cref="Encoding"
    /// /> object .</param>
    /// <param name="encoding">When this method returns <c>true</c>, contains an <see cref="Encoding"
    /// /> object that matches the specified code page number and whose properties <see cref="Encoding.EncoderFallback"
    /// /> und <see cref="Encoding.DecoderFallback" /> are set to the desired values, <c>null</c>
    /// otherwise. This parameter is passed uninitialized.</param>
    /// <returns> <c>true</c> if the conversion was successful, <c>false</c> otherwise.</returns>
    /// <remarks>.NET Standard and .NET 5.0 or higher recognize by default only a small number
    /// of character sets. The method overrides this default setting.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="encoderFallback" /> or <paramref
    /// name="decoderFallback" /> is <c>null</c>.</exception>
    public static bool TryGetEncoding(int codePage,
                                       EncoderFallback encoderFallback,
                                       DecoderFallback decoderFallback,
                                       [NotNullWhen(true)] out Encoding? encoding)
    {
        ThrowOnEncoderAndDecoderFallbackNull(encoderFallback, decoderFallback);
        return TryGetEncodingInternal(codePage, encoderFallback, decoderFallback, out encoding);
    }

    #region GetEncoding_private

    private static bool TryGetEncodingInternal(string? encodingWebName,
                                               EncoderFallback encoderFallback,
                                               DecoderFallback decoderFallback,
                                               [NotNullWhen(true)] out Encoding? encoding)
    {
        AssertEncoderAndDecoderFallbackNotNull(encoderFallback, decoderFallback);

        encoding = null;
        return !IsWebNameEmpty(encodingWebName) && BuildEncoding(encodingWebName, encoderFallback, decoderFallback, ref encoding, out _);
    }

    private static bool TryGetEncodingInternal(int codePage,
                                               EncoderFallback encoderFallback,
                                               DecoderFallback decoderFallback,
                                               [NotNullWhen(true)] out Encoding? encoding)
    {
        AssertEncoderAndDecoderFallbackNotNull(encoderFallback, decoderFallback);

        encoding = null;
        return !CodepageOutOfRange(codePage) && BuildEncoding(codePage, encoderFallback, decoderFallback, ref encoding, out _);
    }

    private static bool TryGetEncodingInternal(int codePage,
                                       EncoderFallback? encoderFallback,
                                       DecoderFallback? decoderFallback,
                                       [NotNullWhen(true)] out Encoding? encoding,
                                       [NotNullWhen(false)] out Exception? exception)
    {
        encoding = null;

        if (CodepageOutOfRange(codePage))
        {
            exception = new ArgumentOutOfRangeException(nameof(codePage));
            return false;
        }

        return BuildEncoding(
            codePage, encoderFallback, decoderFallback, ref encoding, out exception);
    }

    private static bool BuildEncoding(int codePage,
                                      EncoderFallback? encoderFallback,
                                      DecoderFallback? decoderFallback,
                                      [NotNullWhen(true)] ref Encoding? encoding,
                                      [NotNullWhen(false)] out Exception? exception)
    {
        AssertEncoderAndDecoderFallbackBothNullOrBothNotNull(encoderFallback, decoderFallback);

        EnableAnsiEncodings();

        try
        {
            encoding = encoderFallback is null ? Encoding.GetEncoding(codePage)
                                               : Encoding.GetEncoding(codePage,
                                                                      encoderFallback,
                                                                      decoderFallback!);
        }
        catch (Exception e)
        {
            exception = new ArgumentException(e.Message, nameof(codePage), e);
            return false;
        }

        exception = null;
        return true;
    }

    private static bool TryGetEncodingInternal(string? encodingWebName,
                                               EncoderFallback? encoderFallback,
                                               DecoderFallback? decoderFallback,
                                               [NotNullWhen(true)] out Encoding? encoding,
                                               [NotNullWhen(false)] out Exception? exception)
    {
        encoding = null;

        if (IsWebNameEmpty(encodingWebName))
        {
            exception = new ArgumentException(Res.ArgumentNullOrWhiteSpace, nameof(encodingWebName));
            return false;
        }

        return BuildEncoding(
            encodingWebName, encoderFallback, decoderFallback, ref encoding, out exception);
    }

    private static bool BuildEncoding(string encodingWebName,
                                      EncoderFallback? encoderFallback,
                                      DecoderFallback? decoderFallback,
                                      [NotNullWhen(true)] ref Encoding? encoding,
                                      [NotNullWhen(false)] out Exception? exception)
    {
        AssertEncoderAndDecoderFallbackBothNullOrBothNotNull(encoderFallback, decoderFallback);

        EnableAnsiEncodings();
        encodingWebName = PrepareEncodingName(encodingWebName);
        try
        {
            encoding = encoderFallback is null ? Encoding.GetEncoding(encodingWebName)
                                               : Encoding.GetEncoding(encodingWebName,
                                                                      encoderFallback,
                                                                      decoderFallback!);
        }
        catch (Exception e)
        {
            exception = new ArgumentException(e.Message, nameof(encodingWebName), e);
            return false;
        }

        exception = null;
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void ThrowOnEncoderAndDecoderFallbackNull(EncoderFallback encoderFallback,
                                                             DecoderFallback decoderFallback)
    {
        _ArgumentNullException.ThrowIfNull(encoderFallback, nameof(encoderFallback));
        _ArgumentNullException.ThrowIfNull(decoderFallback, nameof(decoderFallback));
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsWebNameEmpty([NotNullWhen(false)] string? encodingWebName)
        => string.IsNullOrWhiteSpace(encodingWebName);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string PrepareEncodingName(string name)
        => name.Replace(" ", "", StringComparison.Ordinal);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool CodepageOutOfRange(int codePage)
        => codePage is < CODEPAGE_MIN or > CODEPAGE_MAX;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Encoding CreateFallBack(EncoderFallback encoderFallback,
                                           DecoderFallback decoderFallback)
        => Encoding.GetEncoding(UTF_8, encoderFallback, decoderFallback);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void EnableAnsiEncodings()
    {
#if NETSTANDARD2_0_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#pragma warning disable IDE0022 // Use expression body for method
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
#pragma warning restore IDE0022 // Use expression body for method
#endif
    }

    #region Assert

    [Conditional("DEBUG")]
    [ExcludeFromCodeCoverage]
    private static void AssertEncoderAndDecoderFallbackNotNull(EncoderFallback encoderFallback,
                                                               DecoderFallback decoderFallback)
    {
        Debug.Assert(encoderFallback != null);
        Debug.Assert(decoderFallback != null);
    }

    [Conditional("DEBUG")]
    [ExcludeFromCodeCoverage]
    private static void AssertEncoderAndDecoderFallbackBothNullOrBothNotNull(EncoderFallback? encoderFallback,
                                                                             DecoderFallback? decoderFallback)
        => Debug.Assert((encoderFallback is null && decoderFallback is null) ||
                     (encoderFallback is not null && decoderFallback is not null));

    #endregion
    #endregion

    /// <summary>Examines a read-only <see cref="byte" /> span, that represents the contents
    /// of a text file, to see if it starts with a Byte Order Mark (BOM), and returns an
    /// appropriate code page. (The fallback value is 65001 for UTF-8.)</summary>
    /// <param name="data">The span to examine.</param>
    /// <param name="bomLength">When the method returns, it contains the length of the BOM
    /// found or zero if no BOM was found. The parameter is passed uninitialized.</param>
    /// <returns>An appropriate code page for <paramref name="data" /> or the code page for
    /// UTF-8 (65001) if the code page could not be determined from <paramref name="data"
    /// />.</returns>
    /// <remarks>The method recognizes the Byte Order Marks for the following character sets:
    /// <list type="bullet">
    /// <item>
    /// UTF-8
    /// </item>
    /// <item>
    /// UTF-16LE
    /// </item>
    /// <item>
    /// UTF-16BE
    /// </item>
    /// <item>
    /// UTF-32LE
    /// </item>
    /// <item>
    /// UTF-32BE
    /// </item>
    /// <item>
    /// UTF-7
    /// </item>
    /// <item>
    /// GB18030
    /// </item>
    /// </list>
    /// <para>
    /// UTF-16LE, UTF-16BE, UTF-32LE and UTF-32BE can also be recognized by the method from
    /// the data if there is no Byte Order Mark.
    /// </para>
    /// </remarks>
    public static int GetCodePage(ReadOnlySpan<byte> data, out int bomLength)
    {
        const int UTF16LE = 1200;
        const int UTF16BE = 1201;
        const int UTF32LE = 12000;
        const int UTF32BE = 12001;
        const int GB18030 = 54936;
        const int UTF7 = 65000;

        if (data.Length >= 4)
        {
            if (data[0] == 0xFF && data[1] == 0xFE && data[2] == 0x00 && data[3] == 0x00)
            {
                bomLength = 4;
                return UTF32LE;
            }

            if (data[0] == 0x00 && data[1] == 0x00 && data[2] == 0xFE && data[3] == 0xFF)
            {
                bomLength = 4;
                return UTF32BE;
            }

            if (data[0] == 0x84 && data[1] == 0x31 && data[2] == 0x95 && data[3] == 0x33)
            {
                bomLength = 4;
                return GB18030;
            }

            if (data[0] == 0x2B && data[1] == 0x2F && data[2] == 0x76 &&
               (data[3] == 0x38 || data[3] == 0x39 || data[3] == 0x2B || data[3] == 0x2F))
            {
                bomLength = 4;
                return UTF7;
            }

            if ((data[0] != 0x00 || data[1] != 0x00) && data[2] == 0x00 && data[3] == 0x00)
            {
                bomLength = 0;
                return UTF32LE;
            }

            if (data[0] == 0x00 && data[1] == 0x00 && (data[2] != 0x00 || data[3] != 0x00))
            {
                bomLength = 0;
                return UTF32BE;
            }
        }

        if (data.Length >= 3 && data[0] == 0xEF && data[1] == 0xBB && data[2] == 0xBF)
        {
            bomLength = 3;
            return UTF_8;
        }

        if (data.Length >= 2)
        {
            if (data[0] == 0xFF && data[1] == 0xFE)
            {
                bomLength = 2;
                return UTF16LE;
            }

            if (data[0] == 0xFE && data[1] == 0xFF)
            {
                bomLength = 2;
                return UTF16BE;
            }

            if (data[0] != 0x00 && data[1] == 0x00)
            {
                bomLength = 0;
                return UTF16LE;
            }

            if (data[0] == 0x00 && data[1] != 0x00)
            {
                bomLength = 0;
                return UTF16BE;
            }
        }

        bomLength = 0;
        return UTF_8;
    }
}
