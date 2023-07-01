using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;
using FolkerKinzel.Strings.Polyfills;
using FolkerKinzel.Strings.Properties;

namespace FolkerKinzel.Strings;

/// <summary>
/// Kapselt Methoden, die das Erzeugen geeigneter Instanzen der <see cref="Encoding"/>-Klasse unterstützen.
/// </summary>
public static class TextEncodingConverter
{
    private const int UTF_8 = 65001;
    private const int CODEPAGE_MIN = 1;
    private const int CODEPAGE_MAX = 65535;

    /// <summary>
    /// Gibt für den angegebenen Bezeichner eines Zeichensatzes ein entsprechendes <see cref="Encoding"/>-Objekt
    /// zurück.
    /// </summary>
    /// 
    /// <param name="encodingWebName">Der Bezeichner des Zeichensatzes.</param>
    /// <param name="throwOnInvalidWebName">Geben Sie <c>true</c> an, damit die Methode
    /// eine <see cref="ArgumentException"/> wirft, falls <paramref name="encodingWebName"/> nicht übersetzt werden konnte.</param>
    /// 
    /// <returns>Ein <see cref="Encoding"/>-Objekt, das dem angegebenen Bezeichner des Zeichensatzes
    /// entspricht. Falls keine Entsprechung gefunden wurde, wird in der Standardeinstellung <see cref="Encoding.UTF8"/> zurückgegeben.
    /// Wenn die Methode mit <c>true</c> als Argument für den Parameter <paramref name="throwOnInvalidWebName"/> aufgerufen wird, wird
    /// in diesem Fall eine <see cref="ArgumentException"/> geworfen.</returns>
    /// 
    /// <remarks>
    /// <para>
    /// .NET Standard und .NET 5.0 oder höher erkennen in der Standardeinstellung nur eine geringe Anzahl von Zeichensätzen.
    /// Die Methode überschreibt diese Standardeinstellung.
    /// </para>
    /// <para>
    /// Die Eigenschaften <see cref="Encoding.EncoderFallback"/> und <see cref="Encoding.DecoderFallback"/> des erzeugten
    /// <see cref="Encoding"/>-Objekts sind auf ReplacementFallback eingestellt.
    /// </para>
    /// </remarks>
    /// 
    /// <exception cref="ArgumentException">
    /// <paramref name="encodingWebName"/> konnte keinem <see cref="Encoding"/>-Objekt zugeordnet werden. Eine Ausnahme wird nur dann geworfen, wenn
    /// für den optionalen Parameter <paramref name="throwOnInvalidWebName"/>&#160;<c>true</c> übergeben wurde.
    /// </exception>
    public static Encoding GetEncoding(string? encodingWebName, bool throwOnInvalidWebName = false)
    {
        return throwOnInvalidWebName
            ? TryGetEncodingInternal(encodingWebName, null, null, out Encoding? encoding, out Exception? exception)
                ? encoding
                : throw exception
            : TryGetEncoding(encodingWebName, out encoding)
                ? encoding
                : Encoding.UTF8;
    }


    /// <summary>
    /// Gibt für den angegebenen Bezeichner eines Zeichensatzes ein entsprechendes <see cref="Encoding"/>-Objekt
    /// zurück, dessen Eigenschaften <see cref="Encoding.EncoderFallback"/> und <see cref="Encoding.DecoderFallback"/>
    /// auf die gewünschten Werte eingestellt sind.
    /// </summary>
    /// 
    /// <param name="encodingWebName">Der Bezeichner des Zeichensatzes.</param>
    /// <param name="encoderFallback">Ein Objekt, das einen Fehlerbehandlungsmechanismus zur Verfügung stellt,
    /// falls ein Zeichen mit dem <see cref="Encoding"/>-Objekt nicht enkodiert werden kann.</param>
    /// <param name="decoderFallback">
    /// Ein Objekt, das einen Fehlerbehandlungsmechanismus zur Verfügung stellt,
    /// falls eine <see cref="byte"/>-Sequenz mit dem <see cref="Encoding"/>-Objekt nicht dekodiert werden kann.</param>
    /// <param name="throwOnInvalidWebName">Geben Sie <c>true</c> an, damit die Methode
    /// eine <see cref="ArgumentException"/> wirft, falls <paramref name="encodingWebName"/> nicht übersetzt werden konnte.</param>
    /// 
    /// <returns>Ein <see cref="Encoding"/>-Objekt, das dem angegebenen Bezeichner des Zeichensatzes
    /// entspricht und dessen Eigenschaften <see cref="Encoding.EncoderFallback"/> und <see cref="Encoding.DecoderFallback"/>
    /// auf die gewünschten Werte eingestellt sind. Falls keine Entsprechung gefunden wurde, wird in der Standardeinstellung 
    /// ein entsprechendes <see cref="Encoding"/>-Objekt für UTF-8 zurückgegeben.
    /// Wenn die Methode mit <c>true</c> als Argument für den Parameter <paramref name="throwOnInvalidWebName"/> aufgerufen wird, wird
    /// in diesem Fall eine <see cref="ArgumentException"/> geworfen.</returns>
    /// 
    /// <remarks>
    /// .NET Standard und .NET 5.0 oder höher erkennen in der Standardeinstellung nur eine geringe Anzahl von Zeichensätzen.
    /// Die Methode überschreibt diese Standardeinstellung.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="encoderFallback"/> oder <paramref name="decoderFallback"/> ist <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="encodingWebName"/> konnte keinem <see cref="Encoding"/>-Objekt zugeordnet werden. Diese Ausnahme wird nur dann geworfen, wenn
    /// für den optionalen Parameter <paramref name="throwOnInvalidWebName"/>&#160;<c>true</c> übergeben wurde.
    /// </exception>
    public static Encoding GetEncoding(string? encodingWebName,
                                       EncoderFallback encoderFallback,
                                       DecoderFallback decoderFallback,
                                       bool throwOnInvalidWebName = false)
    {
        ThrowOnEncoderAndDecoderFallbackNull(encoderFallback, decoderFallback);

        return throwOnInvalidWebName
            ? TryGetEncodingInternal(encodingWebName, encoderFallback, decoderFallback, out Encoding? encoding, out Exception? exception)
                ? encoding
                : throw exception
            : TryGetEncodingInternal(encodingWebName, encoderFallback, decoderFallback, out encoding)
                ? encoding 
                : CreateFallBack(encoderFallback, decoderFallback);
    }


    /// <summary>
    /// Gibt für die angegebene Nummer einer Codepage ein entsprechendes <see cref="Encoding"/>-Objekt
    /// zurück.
    /// </summary>
    /// <param name="codePage">
    /// <para>
    /// Die Nummer der Codepage.
    /// </para>
    /// <note type="caution">
    /// <c>0</c> wird als ungültiges Argument behandelt. Das Verhalten unterscheidet sich damit von dem der
    /// <see cref="Encoding"/>-Klasse.
    /// </note>
    /// </param>
    /// <param name="throwOnInvalidCodePage">Geben Sie <c>true</c> an, damit die Methode
    /// eine <see cref="ArgumentException"/> wirft, falls <paramref name="codePage"/> nicht übersetzt werden konnte.</param>
    /// 
    /// <returns>
    /// Ein <see cref="Encoding"/>-Objekt, das der angegebenen Nummer der Codepage
    /// entspricht. Falls keine Entsprechung gefunden wurde, wird in der Standardeinstellung <see cref="Encoding.UTF8"/> zurückgegeben.
    /// Wenn die Methode mit <c>true</c> als Argument für den Parameter <paramref name="throwOnInvalidCodePage"/> aufgerufen wird, wird
    /// in diesem Fall eine <see cref="ArgumentException"/> geworfen.
    /// </returns>
    /// 
    /// <remarks>
    /// <para>
    /// .NET Standard und .NET 5.0 oder höher erkennen in der Standardeinstellung nur eine geringe Anzahl von Zeichensätzen.
    /// Die Methode überschreibt diese Standardeinstellung.
    /// </para>
    /// <para>
    /// Die Eigenschaften <see cref="Encoding.EncoderFallback"/> und <see cref="Encoding.DecoderFallback"/> des erzeugten
    /// <see cref="Encoding"/>-Objekts sind auf ReplacementFallback eingestellt.
    /// </para>
    /// </remarks>
    /// 
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="codePage"/> ist kleiner als 1 oder größer als 65535. Diese Ausnahme wird nur dann geworfen, wenn
    /// für den optionalen Parameter <paramref name="throwOnInvalidCodePage"/>&#160;<c>true</c> übergeben wurde.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="codePage"/> konnte keinem <see cref="Encoding"/>-Objekt zugeordnet werden. Diese Ausnahme wird nur dann geworfen, wenn
    /// für den optionalen Parameter <paramref name="throwOnInvalidCodePage"/>&#160;<c>true</c> übergeben wurde.
    /// </exception>
    /// 
    public static Encoding GetEncoding(int codePage, bool throwOnInvalidCodePage = false)
    {
        return throwOnInvalidCodePage
            ? TryGetEncodingInternal(codePage, null, null, out Encoding? encoding, out Exception? exception)
                ? encoding
                : throw exception
            : TryGetEncoding(codePage, out encoding)
                ? encoding 
                : Encoding.UTF8;
    }

    /// <summary>
    /// Gibt für die angegebene Nummer einer Codepage ein entsprechendes <see cref="Encoding"/>-Objekt
    /// zurück, dessen Eigenschaften <see cref="Encoding.EncoderFallback"/> und <see cref="Encoding.DecoderFallback"/>
    /// auf die gewünschten Werte eingestellt sind.
    /// </summary>
    /// 
    /// <param name="codePage">
    /// <para>
    /// Die Nummer der Codepage.
    /// </para>
    /// <note type="caution">
    /// <c>0</c> wird als ungültiges Argument behandelt. Das Verhalten unterscheidet sich damit von
    /// dem der <see cref="Encoding"/>-Klasse.
    /// </note></param>
    /// 
    /// <param name="encoderFallback">Ein Objekt, das einen Fehlerbehandlungsmechanismus zur Verfügung stellt,
    /// falls ein Zeichen mit dem <see cref="Encoding"/>-Objekt nicht enkodiert werden kann.</param>
    /// <param name="decoderFallback">
    /// Ein Objekt, das einen Fehlerbehandlungsmechanismus zur Verfügung stellt,
    /// falls eine <see cref="byte"/>-Sequenz mit dem <see cref="Encoding"/>-Objekt nicht dekodiert werden kann.</param>
    /// <param name="throwOnInvalidCodePage">Geben Sie <c>true</c> an, damit die Methode
    /// eine <see cref="ArgumentException"/> wirft, falls <paramref name="codePage"/> nicht übersetzt werden konnte.</param>
    ///  
    /// <returns>Ein <see cref="Encoding"/>-Objekt, das der angegebenen Nummer der Codepage
    /// entspricht und dessen Eigenschaften <see cref="Encoding.EncoderFallback"/> und <see cref="Encoding.DecoderFallback"/>
    /// auf die gewünschten Werte eingestellt sind. Falls keine Entsprechung gefunden wurde, wird in der Standardeinstellung 
    /// ein entsprechendes <see cref="Encoding"/>-Objekt für UTF-8 zurückgegeben.
    /// Wenn die Methode mit <c>true</c> als Argument für den Parameter <paramref name="throwOnInvalidCodePage"/> aufgerufen wird, wird
    /// in diesem Fall eine <see cref="ArgumentException"/> geworfen.</returns>
    /// 
    /// <remarks>
    /// .NET Standard und .NET 5.0 oder höher erkennen in der Standardeinstellung nur eine geringe Anzahl von Zeichensätzen.
    /// Die Methode überschreibt diese Standardeinstellung.
    /// </remarks>
    /// 
    /// <exception cref="ArgumentNullException">
    /// <paramref name="encoderFallback"/> oder <paramref name="decoderFallback"/> ist <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="codePage"/> ist kleiner als 1 oder größer als 65535. Diese Ausnahme wird nur dann geworfen, wenn
    /// für den optionalen Parameter <paramref name="throwOnInvalidCodePage"/>&#160;<c>true</c> übergeben wurde.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="codePage"/> konnte keinem <see cref="Encoding"/>-Objekt zugeordnet werden. Diese Ausnahme wird nur dann geworfen, wenn
    /// für den optionalen Parameter <paramref name="throwOnInvalidCodePage"/>&#160;<c>true</c> übergeben wurde.
    /// </exception>
    public static Encoding GetEncoding(int codePage,
                                       EncoderFallback encoderFallback,
                                       DecoderFallback decoderFallback,
                                       bool throwOnInvalidCodePage = false)
    {
        ThrowOnEncoderAndDecoderFallbackNull(encoderFallback, decoderFallback);

        return throwOnInvalidCodePage
           ? TryGetEncodingInternal(codePage, encoderFallback, decoderFallback, out Encoding? encoding, out Exception? exception)
               ? encoding
               : throw exception
           : TryGetEncodingInternal(codePage, encoderFallback, decoderFallback, out encoding)
                ? encoding 
                : CreateFallBack(encoderFallback, decoderFallback);
    }


    /// <summary>
    /// Versucht, für den angegebenen Bezeichner eines Zeichensatzes ein entsprechendes <see cref="Encoding"/>-Objekt
    /// zurückzugeben.
    /// </summary>
    /// 
    /// <param name="encodingWebName">Der Bezeichner des Zeichensatzes.</param>
    /// <param name="encoding">Enthält nach dem erfolgreichen Beenden der Methode ein <see cref="Encoding"/>-Objekt, 
    /// das dem angegebenen Bezeichner des Zeichensatzes entspricht, andernfalls <c>null</c>. Der Parameter wird 
    /// uninitialisiert übergeben.</param>
    /// 
    /// <returns><c>true</c>, wenn die Konvertierung erfolgreich war, andernfalls <c>false</c>.</returns>
    /// 
    /// <remarks>
    /// <para>
    /// .NET Standard und .NET 5.0 oder höher erkennen in der Standardeinstellung nur eine geringe Anzahl von Zeichensätzen.
    /// Die Methode überschreibt diese Standardeinstellung.
    /// </para>
    /// <para>
    /// Die Eigenschaften <see cref="Encoding.EncoderFallback"/> und <see cref="Encoding.DecoderFallback"/> des erzeugten
    /// <see cref="Encoding"/>-Objekts sind auf ReplacementFallback eingestellt.
    /// </para>
    /// </remarks>
    public static bool TryGetEncoding(string? encodingWebName, [NotNullWhen(true)] out Encoding? encoding)
    {
        encoding = null;
        return !IsWebNameEmpty(encodingWebName) && BuildEncoding(encodingWebName, null, null, ref encoding, out _);
    }

    /// <summary>
    /// Versucht, für den angegebenen Bezeichner eines Zeichensatzes ein entsprechendes <see cref="Encoding"/>-Objekt
    /// zurückzugeben, dessen Eigenschaften <see cref="Encoding.EncoderFallback"/> und <see cref="Encoding.DecoderFallback"/>
    /// auf die gewünschten Werte eingestellt sind.
    /// </summary>
    /// 
    /// <param name="encodingWebName">Der Bezeichner des Zeichensatzes.</param>
    /// <param name="encoderFallback">Ein Objekt, das einen Fehlerbehandlungsmechanismus zur Verfügung stellt,
    /// falls ein Zeichen mit dem <see cref="Encoding"/>-Objekt nicht enkodiert werden kann.</param>
    /// <param name="decoderFallback">
    /// Ein Objekt, das einen Fehlerbehandlungsmechanismus zur Verfügung stellt,
    /// falls eine <see cref="byte"/>-Sequenz mit dem <see cref="Encoding"/>-Objekt nicht dekodiert werden kann.</param>
    /// <param name="encoding">Enthält nach dem erfolgreichen Beenden der Methode ein <see cref="Encoding"/>-Objekt, 
    /// das dem angegebenen Bezeichner des Zeichensatzes entspricht und dessen Eigenschaften <see cref="Encoding.EncoderFallback"/> 
    /// und <see cref="Encoding.DecoderFallback"/> auf die gewünschten Werte eingestellt sind, andernfalls <c>null</c>. Der Parameter wird 
    /// uninitialisiert übergeben.</param>
    /// 
    /// <returns><c>true</c>, wenn die Konvertierung erfolgreich war, andernfalls <c>false</c>.</returns>
    /// 
    /// <remarks>
    /// .NET Standard und .NET 5.0 oder höher erkennen in der Standardeinstellung nur eine geringe Anzahl von Zeichensätzen.
    /// Die Methode überschreibt diese Standardeinstellung.
    /// </remarks>
    /// 
    /// <exception cref="ArgumentNullException">
    /// <paramref name="encoderFallback"/> oder <paramref name="decoderFallback"/> ist <c>null</c>.
    /// </exception>
    public static bool TryGetEncoding(string? encodingWebName,
                                      EncoderFallback encoderFallback,
                                      DecoderFallback decoderFallback,
                                      [NotNullWhen(true)] out Encoding? encoding)
    {
        ThrowOnEncoderAndDecoderFallbackNull(encoderFallback, decoderFallback);
        return TryGetEncodingInternal(encodingWebName, encoderFallback, decoderFallback, out encoding);
    }



    /// <summary>
    /// Versucht, für die angegebene Nummer einer Codepage ein entsprechendes <see cref="Encoding"/>-Objekt
    /// zurückzugeben.
    /// </summary>
    /// 
    /// <param name="codePage">
    /// <para>
    /// Die Nummer der Codepage.
    /// </para>
    /// <note type="caution">
    /// <c>0</c> wird als ungültiges Argument behandelt. Das Verhalten unterscheidet sich damit von
    /// dem der <see cref="Encoding"/>-Klasse.
    /// </note></param>
    /// <param name="encoding">Enthält nach dem erfolgreichen Beenden der Methode ein <see cref="Encoding"/>-Objekt, 
    /// das der angegebenen Nummer der Codepage entspricht, andernfalls <c>null</c>. Der Parameter wird 
    /// uninitialisiert übergeben.</param>
    /// 
    /// <returns><c>true</c>, wenn die Konvertierung erfolgreich war, andernfalls <c>false</c>.</returns>
    /// 
    /// <remarks>
    /// <para>
    /// .NET Standard und .NET 5.0 oder höher erkennen in der Standardeinstellung nur eine geringe Anzahl von Zeichensätzen.
    /// Die Methode überschreibt diese Standardeinstellung.
    /// </para>
    /// <para>
    /// Die Eigenschaften <see cref="Encoding.EncoderFallback"/> und <see cref="Encoding.DecoderFallback"/> des erzeugten
    /// <see cref="Encoding"/>-Objekts sind auf ReplacementFallback eingestellt.
    /// </para>
    /// </remarks>
    public static bool TryGetEncoding(int codePage, [NotNullWhen(true)] out Encoding? encoding)
    {
        encoding = null;
        return !CodepageOutOfRange(codePage) && BuildEncoding(codePage, null, null, ref encoding, out _);
    }

    /// <summary>
    /// Versucht, für die angegebene Nummer einer Codepage ein entsprechendes <see cref="Encoding"/>-Objekt
    /// zurückzugeben, dessen Eigenschaften <see cref="Encoding.EncoderFallback"/> und <see cref="Encoding.DecoderFallback"/>
    /// auf die gewünschten Werte eingestellt sind.
    /// </summary>
    /// 
    /// <param name="codePage">
    /// <para>
    /// Die Nummer der Codepage.
    /// </para>
    /// <note type="caution">
    /// <c>0</c> wird als ungültiges Argument behandelt. Das Verhalten unterscheidet sich damit von
    /// dem der <see cref="Encoding"/>-Klasse.
    /// </note></param>
    /// 
    /// <param name="encoderFallback">Ein Objekt, das einen Fehlerbehandlungsmechanismus zur Verfügung stellt,
    /// falls ein Zeichen mit dem <see cref="Encoding"/>-Objekt nicht enkodiert werden kann.</param>
    /// <param name="decoderFallback">
    /// Ein Objekt, das einen Fehlerbehandlungsmechanismus zur Verfügung stellt,
    /// falls eine <see cref="byte"/>-Sequenz mit dem <see cref="Encoding"/>-Objekt nicht dekodiert werden kann.</param>
    /// <param name="encoding">Enthält nach dem erfolgreichen Beenden der Methode ein <see cref="Encoding"/>-Objekt, 
    /// das der angegebenen Nummer der Codepage entspricht und dessen Eigenschaften <see cref="Encoding.EncoderFallback"/> 
    /// und <see cref="Encoding.DecoderFallback"/> auf die gewünschten Werte eingestellt sind, andernfalls <c>null</c>. Der Parameter wird 
    /// uninitialisiert übergeben.</param>
    /// 
    /// <returns><c>true</c>, wenn die Konvertierung erfolgreich war, andernfalls <c>false</c>.</returns>
    /// 
    /// <remarks>
    /// .NET Standard und .NET 5.0 oder höher erkennen in der Standardeinstellung nur eine geringe Anzahl von Zeichensätzen.
    /// Die Methode überschreibt diese Standardeinstellung.
    /// </remarks>
    /// 
    /// <exception cref="ArgumentNullException">
    /// <paramref name="encoderFallback"/> oder <paramref name="decoderFallback"/> ist <c>null</c>.
    /// </exception>
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

        return BuildEncoding(codePage, encoderFallback, decoderFallback, ref encoding, out exception);
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
                                               : Encoding.GetEncoding(codePage, encoderFallback, decoderFallback!);
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

        return BuildEncoding(encodingWebName, encoderFallback, decoderFallback, ref encoding, out exception);
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
                                               : Encoding.GetEncoding(encodingWebName, encoderFallback, decoderFallback!);
        }
        catch (Exception e)
        {
            exception = new ArgumentException(e.Message, nameof(encodingWebName), e);
            return false;
        }

        exception = null;
        return true;
    }

    private static void ThrowOnEncoderAndDecoderFallbackNull(EncoderFallback encoderFallback, DecoderFallback decoderFallback)
    {
        if (encoderFallback is null)
        {
            throw new ArgumentNullException(nameof(encoderFallback));
        }

        if (decoderFallback is null)
        {
            throw new ArgumentNullException(nameof(decoderFallback));
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsWebNameEmpty([NotNullWhen(false)] string? encodingWebName) => string.IsNullOrWhiteSpace(encodingWebName);


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string PrepareEncodingName(string name) => name.Replace(" ", "", StringComparison.Ordinal);


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool CodepageOutOfRange(int codePage) => codePage is < CODEPAGE_MIN or > CODEPAGE_MAX;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Encoding CreateFallBack(EncoderFallback encoderFallback, DecoderFallback decoderFallback) =>
        Encoding.GetEncoding(UTF_8, encoderFallback, decoderFallback);


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void EnableAnsiEncodings()
    {
#if NETSTANDARD2_0_OR_GREATER || NET5_0_OR_GREATER
#pragma warning disable IDE0022 // Ausdruckskörper für Methode verwenden
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
#pragma warning restore IDE0022 // Ausdruckskörper für Methode verwenden
#endif
    }

    #region Assert

    [Conditional("DEBUG")]
    [ExcludeFromCodeCoverage]
    private static void AssertEncoderAndDecoderFallbackNotNull(EncoderFallback encoderFallback, DecoderFallback decoderFallback)
    {
        Debug.Assert(encoderFallback != null);
        Debug.Assert(decoderFallback != null);
    }

    [Conditional("DEBUG")]
    [ExcludeFromCodeCoverage]
    private static void AssertEncoderAndDecoderFallbackBothNullOrBothNotNull(EncoderFallback? encoderFallback, DecoderFallback? decoderFallback) =>
        Debug.Assert((encoderFallback is null && decoderFallback is null) || (encoderFallback is not null && decoderFallback is not null));

    #endregion
    #endregion

    /// <summary>
    /// Untersucht eine schreibgeschützte <see cref="byte"/>-Spanne, die den Inhalt
    /// einer Textdatei darstellt, daraufhin, ob
    /// sie mit einem Byte Order Mark (BOM) beginnt und gibt eine geeignete Codepage
    /// zurück. (Das Fallback-Value ist 65001 für UTF-8.)
    /// </summary>
    /// <param name="data">Die zu untersuchende Spanne.</param>
    /// <param name="bomLength">Enthält nach Beendigung der Methode die Länge des gefundenen BOM oder 0, wenn kein BOM
    /// gefunden wurde. Der Parameter wird uninitialisiert übergeben.</param>
    /// <returns>Eine geeignete Codepage für <paramref name="data"/> oder die Codepage
    /// für UTF-8 (65001), falls die Codepage nicht aus <paramref name="data"/> ermittelt
    /// werden konnte.</returns>
    /// <remarks>
    /// Die Methode erkennt die Byte Order Marks für die folgenden Zeichensätze:
    /// <list type="bullet">
    /// <item>UTF-8</item>
    /// <item>UTF-16LE</item>
    /// <item>UTF-16BE</item>
    /// <item>UTF-32LE</item>
    /// <item>UTF-32BE</item>
    /// <item>UTF-7</item>
    /// <item>GB18030</item>
    /// </list>
    /// <para>
    /// UTF-16LE, UTF-16BE, UTF-32LE und UTF-32BE können von der Methode u.U. auch dann aus den
    /// Daten erkannt werden, wenn kein Byte Order Mark vorliegt.
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

            if (data[0] == 0x2B && data[1] == 0x2F && data[2] == 0x76 && (data[3] == 0x38 || data[3] == 0x39 || data[3] == 0x2B || data[3] == 0x2F))
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
