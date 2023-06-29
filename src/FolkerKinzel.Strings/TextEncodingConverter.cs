using System.Xml.Linq;
using FolkerKinzel.Strings.Polyfills;
using FolkerKinzel.Strings.Properties;

namespace FolkerKinzel.Strings;

/// <summary>
/// Erzeugt aus verschiedenen Datentypen eine
/// Instanz der <see cref="Encoding"/>-Klasse.
/// </summary>
public static class TextEncodingConverter
{
    private const int UTF_8 = 65001;
    private const int CODEPAGE_MIN = 1;
    private const int CODEPAGE_MAX = 65535;

    /// <summary>
    /// Gibt für den Bezeichner eines Zeichensatzes ein entsprechendes <see cref="Encoding"/>-Objekt
    /// zurück, bei dem <see cref="Encoding.EncoderFallback"/> und <see cref="Encoding.DecoderFallback"/>
    /// auf ReplacementFallback eingestellt sind.
    /// </summary>
    /// 
    /// <param name="encodingWebName">Der Bezeichner eines Zeichensatzes.</param>
    /// <param name="throwOnInvalidName">Optionales Argument. Geben Sie <c>true</c> an, damit die Methode
    /// eine <see cref="ArgumentException"/> wirft, falls <paramref name="encodingWebName"/> nicht übersetzt werden konnte.</param>
    /// 
    /// <returns>Ein <see cref="Encoding"/>-Objekt, das dem angegebenen Bezeichner des Zeichensatzes
    /// entspricht. Falls keine Entsprechung gefunden wurde, wird in der Standardeinstellung <see cref="Encoding.UTF8"/> zurückgegeben.
    /// Wenn die Methode mit <c>true</c> als Argument für den Parameter <paramref name="throwOnInvalidName"/> aufgerufen wird, wird
    /// in diesem Fall eine <see cref="ArgumentException"/> geworfen.</returns>
    /// 
    /// <remarks>
    /// .NET Standard und .NET 5.0 oder höher erkennen in der Standardeinstellung nur eine geringe Anzahl von Zeichensätzen.
    /// Die Methode überschreibt diese Standardeinstellung.
    /// </remarks>
    /// 
    /// <exception cref="ArgumentException">
    /// <paramref name="encodingWebName"/> konnte keinem <see cref="Encoding"/>-Objekt zugeordnet werden. Eine Ausnahme wird nur dann geworfen, wenn
    /// die Option <paramref name="throwOnInvalidName"/> auf <c>true</c> gesetzt ist.
    /// </exception>
    public static Encoding GetEncoding(string? encodingWebName, bool throwOnInvalidName = false)
    {
        if (string.IsNullOrWhiteSpace(encodingWebName))
        {
            return throwOnInvalidName
                ? throw new ArgumentException(Res.ArgumentNullOrWhiteSpace, nameof(encodingWebName)) 
                : Encoding.UTF8;
        }

        EnableAnsiEncodings();

        try
        {
            return Encoding.GetEncoding(PrepareEncodingName(encodingWebName));
        }
        catch(Exception e)
        {
            return throwOnInvalidName 
                ? throw new ArgumentException(e.Message, nameof(encodingWebName), e)
                : Encoding.UTF8;
        }
    }


    /// <summary>
    /// Gibt für den Bezeichner eines Zeichensatzes ein entsprechendes <see cref="Encoding"/>-Objekt
    /// zurück, dessen Eigenschaften <see cref="Encoding.EncoderFallback"/> und <see cref="Encoding.DecoderFallback"/>
    /// auf die gewünschten Werte eingestellt sind.
    /// </summary>
    /// 
    /// <param name="encodingWebName">Der Bezeichner eines Zeichensatzes oder <c>null</c> für den UTF-8-Zeichensatz.</param>
    /// <param name="encoderFallback">Ein Objekt, das einen Fehlerbehandlungsmechanismus zur Verfügung stellt,
    /// falls ein Zeichen mit dem <see cref="Encoding"/>-Objekt nicht enkodiert werden kann.</param>
    /// <param name="decoderFallback">
    /// Ein Objekt, das einen Fehlerbehandlungsmechanismus zur Verfügung stellt,
    /// falls eine <see cref="byte"/>-Sequenz mit dem <see cref="Encoding"/>-Objekt nicht dekodiert werden kann.</param>
    /// <param name="throwOnInvalidName">Optionales Argument. Geben Sie <c>true</c> an, damit die Methode
    /// eine <see cref="ArgumentException"/> wirft, falls <paramref name="encodingWebName"/> nicht übersetzt werden konnte.</param>
    /// 
    /// <returns>Ein <see cref="Encoding"/>-Objekt, das dem angegebenen Bezeichner des Zeichensatzes
    /// entspricht und dessen Eigenschaften <see cref="Encoding.EncoderFallback"/> und <see cref="Encoding.DecoderFallback"/>
    /// auf die gewünschten Werte eingestellt sind. Falls keine Entsprechung gefunden wurde, wird in der Standardeinstellung 
    /// ein entsprechendes <see cref="Encoding"/>-Objekt für UTF-8 zurückgegeben.
    /// Wenn die Methode mit <c>true</c> als Argument für den Parameter <paramref name="throwOnInvalidName"/> aufgerufen wird, wird
    /// in diesem Fall eine <see cref="ArgumentException"/> geworfen.</returns>
    /// 
    /// <remarks>
    /// .NET Standard und .NET 5.0 oder höher erkennen in der Standardeinstellung nur eine geringe Anzahl von Zeichensätzen.
    /// Die Methode überschreibt diese Standardeinstellung.
    /// </remarks>
    /// <exception cref="ArgumentException">
    /// <paramref name="encodingWebName"/> konnte keinem <see cref="Encoding"/>-Objekt zugeordnet werden. Eine Ausnahme wird nur dann geworfen, wenn
    /// die Option <paramref name="throwOnInvalidName"/> auf <c>true</c> gesetzt ist.
    /// </exception>
    public static Encoding GetEncoding(string? encodingWebName,
                                       EncoderFallback encoderFallback,
                                       DecoderFallback decoderFallback,
                                       bool throwOnInvalidName = false)
    {
        if (string.IsNullOrWhiteSpace(encodingWebName))
        {
            return throwOnInvalidName
                ? throw new ArgumentException(Res.ArgumentNullOrWhiteSpace, nameof(encodingWebName))
                : CreateFallBack();
        }
        
        EnableAnsiEncodings();

        try
        {
            return Encoding.GetEncoding(PrepareEncodingName(encodingWebName), encoderFallback, decoderFallback);
        }
        catch(Exception e)
        {
            return throwOnInvalidName
                ? throw new ArgumentException(e.Message, nameof(encodingWebName), e)
                : CreateFallBack();
        }

        Encoding CreateFallBack() => Encoding.GetEncoding(UTF_8, encoderFallback, decoderFallback);
    }

    /// <summary>
    /// Gibt für die Nummer einer Codepage ein entsprechendes <see cref="Encoding"/>-Objekt
    /// zurück, bei dem <see cref="Encoding.EncoderFallback"/> und <see cref="Encoding.DecoderFallback"/>
    /// auf ReplacementFallback eingestellt sind.
    /// </summary>
    /// <param name="codePage">
    /// <para>
    /// Die Nummer der Codepage.
    /// </para>
    /// <note type="caution">
    /// <c>0</c> wird als ungültiges Argument behandelt. Das Verhalten der Methode unterscheidet sich damit von
    /// <see cref="Encoding.GetEncoding(int)"/>.
    /// </note>
    /// </param>
    /// <param name="throwOnInvalidCodePage">Optionales Argument. Geben Sie <c>true</c> an, damit die Methode
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
    /// .NET Standard und .NET 5.0 oder höher erkennen in der Standardeinstellung nur eine geringe Anzahl von Zeichensätzen.
    /// Die Methode überschreibt diese Standardeinstellung.
    /// </remarks>
    /// 
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="codePage"/> ist kleiner als 1 oder größer als 65535. Die Ausnahme wird nur dann geworfen, wenn
    /// die Option <paramref name="throwOnInvalidCodePage"/> auf <c>true</c> gesetzt ist.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="encodingWebName"/> konnte keinem <see cref="Encoding"/>-Objekt zugeordnet werden. Die Ausnahme wird nur dann geworfen, wenn
    /// die Option <paramref name="throwOnInvalidCodePage"/> auf <c>true</c> gesetzt ist.
    /// </exception>
    /// 
    public static Encoding GetEncoding(int codePage, bool throwOnInvalidCodePage = false)
    {
        if (codePage is < CODEPAGE_MIN or > CODEPAGE_MAX)
        {
            return throwOnInvalidCodePage
                ? throw new ArgumentOutOfRangeException(nameof(codePage))
                : Encoding.UTF8;
        }

        EnableAnsiEncodings();

        try
        {
            return Encoding.GetEncoding(codePage);
        }
        catch(Exception e)
        {
            return throwOnInvalidCodePage
                ? throw new ArgumentException(e.Message, nameof(codePage), e)
                : Encoding.UTF8;
        }
    }

    /// <summary>
    /// Gibt für die Nummer einer Codepage ein entsprechendes <see cref="Encoding"/>-Objekt
    /// zurück, dessen Eigenschaften <see cref="Encoding.EncoderFallback"/> und <see cref="Encoding.DecoderFallback"/>
    /// auf die gewünschten Werte eingestellt sind.
    /// </summary>
    /// 
    /// <param name="codePage">
    /// <para>
    /// Die Nummer der Codepage.
    /// </para>
    /// <note type="caution">
    /// <c>0</c> wird als ungültiges Argument behandelt. Das Verhalten der Methode unterscheidet sich damit von
    /// <see cref="Encoding.GetEncoding(int)"/>.
    /// </note></param>
    /// 
    /// <param name="encoderFallback">Ein Objekt, das einen Fehlerbehandlungsmechanismus zur Verfügung stellt,
    /// falls ein Zeichen mit dem <see cref="Encoding"/>-Objekt nicht enkodiert werden kann.</param>
    /// <param name="decoderFallback">
    /// Ein Objekt, das einen Fehlerbehandlungsmechanismus zur Verfügung stellt,
    /// falls eine <see cref="byte"/>-Sequenz mit dem <see cref="Encoding"/>-Objekt nicht dekodiert werden kann.</param>
    /// <param name="throwOnInvalidCodePage">Optionales Argument. Geben Sie <c>true</c> an, damit die Methode
    /// eine <see cref="ArgumentException"/> wirft, falls <paramref name="codePage"/> nicht übersetzt werden konnte.</param>
    ///  
    /// <returns>Ein <see cref="Encoding"/>-Objekt, das der angegebenen Nummer der Codepage
    /// entspricht und dessen Eigenschaften <see cref="Encoding.EncoderFallback"/> und <see cref="Encoding.DecoderFallback"/>
    /// auf die gewünschten Werte eingestellt sind. Falls keine Entsprechung gefunden wurde, wird in der Standardeinstellung 
    /// ein entsprechendes <see cref="Encoding"/>-Objekt für UTF-8 zurückgegeben.
    /// Wenn die Methode mit <c>true</c> als Argument für den Parameter <paramref name="throwOnInvalidName"/> aufgerufen wird, wird
    /// in diesem Fall eine <see cref="ArgumentException"/> geworfen.</returns>
    /// 
    /// <remarks>
    /// .NET Standard und .NET 5.0 oder höher erkennen in der Standardeinstellung nur eine geringe Anzahl von Zeichensätzen.
    /// Die Methode überschreibt diese Standardeinstellung.
    /// </remarks>
    /// 
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="codePage"/> ist kleiner als 1 oder größer als 65535. Die Ausnahme wird nur dann geworfen, wenn
    /// die Option <paramref name="throwOnInvalidCodePage"/> auf <c>true</c> gesetzt ist.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="encodingWebName"/> konnte keinem <see cref="Encoding"/>-Objekt zugeordnet werden. Die Ausnahme wird nur dann geworfen, wenn
    /// die Option <paramref name="throwOnInvalidCodePage"/> auf <c>true</c> gesetzt ist.
    /// </exception>
    public static Encoding GetEncoding(int codePage,
                                       EncoderFallback encoderFallback,
                                       DecoderFallback decoderFallback,
                                       bool throwOnInvalidCodePage = false)
    {
        if (codePage is < CODEPAGE_MIN or > CODEPAGE_MAX)
        {
            return throwOnInvalidCodePage
                ? throw new ArgumentOutOfRangeException(nameof(codePage))
                : CreateFallBack();
        }

        EnableAnsiEncodings();

        try
        {
            return Encoding.GetEncoding(codePage, encoderFallback, decoderFallback);
        }
        catch(Exception e )
        {
            return throwOnInvalidCodePage
                ? throw new ArgumentException(e.Message, nameof(codePage), e)
                : CreateFallBack();
        }

        Encoding CreateFallBack() => Encoding.GetEncoding(UTF_8, encoderFallback, decoderFallback);
    }


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


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string PrepareEncodingName(string name) => name.Replace(" ", "", StringComparison.Ordinal);


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void EnableAnsiEncodings()
    {
#if NETSTANDARD2_0_OR_GREATER || NET5_0_OR_GREATER
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
#endif
    }

}
