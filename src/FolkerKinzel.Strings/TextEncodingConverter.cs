using System.Text;

namespace FolkerKinzel.Strings
{
    /// <summary>
    /// Wandelt einen <see cref="string"/>, der eine Bezeichnung für einen Zeichensatz darstellt in eine
    /// Instanz der <see cref="Encoding"/>-Klasse um.
    /// </summary>
    public static class TextEncodingConverter
    {
        private const int UTF_8 = 65001;
        private const int CODEPAGE_MAX = 65535;

        /// <summary>
        /// Gibt für den Bezeichner eines Zeichensatzes ein entsprechendes <see cref="Encoding"/>-Objekt
        /// zurück, bei dem <see cref="Encoding.EncoderFallback"/> und <see cref="Encoding.DecoderFallback"/>
        /// auf ReplacementFallback eingestellt sind. <see cref="Encoding.UTF8"/> ist der Fallback-Wert.
        /// </summary>
        /// <param name="name">Der Bezeichner eines Zeichensatzes oder <c>null</c> für <see cref="Encoding.UTF8"/>.</param>
        /// <returns>Ein <see cref="Encoding"/>-Objekt, das dem angegebenen Bezeichner des Zeichensatzes
        /// entspricht oder <see cref="Encoding.UTF8"/>, falls keine Entsprechung gefunden wurde.</returns>
        /// <remarks>
        /// .NET Standard und .NET 5.0 erkennen in der Standardeinstellung nur eine geringe Anzahl von Zeichensätzen.
        /// Die Methode überschreibt diese Standardeinstellung.
        /// </remarks>
        public static Encoding GetEncoding(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Encoding.UTF8;
            }

#if NETSTANDARD2_0_OR_GREATER || NET5_0_OR_GREATER
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
#endif
            try
            {
                return Encoding.GetEncoding(name);
            }
            catch
            {
                return Encoding.UTF8;
            }
        }

        /// <summary>
        /// Gibt für den Bezeichner eines Zeichensatzes ein entsprechendes <see cref="Encoding"/>-Objekt
        /// zurück, dessen Eigenschaften <see cref="Encoding.EncoderFallback"/> und <see cref="Encoding.DecoderFallback"/>
        /// auf die gewünschten Werte eingestellt sind.
        /// </summary>
        /// <param name="name">Der Bezeichner eines Zeichensatzes oder <c>null</c> für den UTF-8-Zeichensatz.</param>
        /// <returns>Ein <see cref="Encoding"/>-Objekt, das dem angegebenen Bezeichner des Zeichensatzes
        /// entspricht oder ein <see cref="Encoding"/>-Objekt für den UTF-8 Zeichensatz, falls keine Entsprechung
        /// gefunden wurde.</returns>
        /// <param name="encoderFallback">Ein Objekt, das einen Fehlerbehandlungsmechanismus zur Verfügung stellt,
        /// falls ein Zeichen mit dem <see cref="Encoding"/>-Objekt nicht enkodiert werden kann.</param>
        /// <param name="decoderFallback">
        /// Ein Objekt, das einen Fehlerbehandlungsmechanismus zur Verfügung stellt,
        /// falls eine <see cref="byte"/>-Sequenz mit dem <see cref="Encoding"/>-Objekt nicht dekodiert werden kann.</param>
        /// <remarks>
        /// .NET Standard und .NET 5.0 erkennen in der Standardeinstellung nur eine geringe Anzahl von Zeichensätzen.
        /// Die Methode überschreibt diese Standardeinstellung.
        /// </remarks>
        public static Encoding GetEncoding(string? name, EncoderFallback encoderFallback, DecoderFallback decoderFallback)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Encoding.GetEncoding(UTF_8, encoderFallback, decoderFallback);
            }

#if NETSTANDARD2_0_OR_GREATER || NET5_0_OR_GREATER
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
#endif

            try
            {
                return Encoding.GetEncoding(name, encoderFallback, decoderFallback);
            }
            catch
            {
                return Encoding.GetEncoding(UTF_8, encoderFallback, decoderFallback);
            }
        }

        /// <summary>
        /// Gibt für die Nummer einer Codepage ein entsprechendes <see cref="Encoding"/>-Objekt
        /// zurück, bei dem <see cref="Encoding.EncoderFallback"/> und <see cref="Encoding.DecoderFallback"/>
        /// auf ReplacementFallback eingestellt sind. <see cref="Encoding.UTF8"/> ist der Fallback-Wert.
        /// </summary>
        /// <param name="codepage">Die Nummer der Codepage oder 0 für <see cref="Encoding.Default"/>.</param>
        /// <returns>Ein <see cref="Encoding"/>-Objekt, das der angegebenen Nummer der Codepage
        /// entspricht oder <see cref="Encoding.UTF8"/>, falls keine Entsprechung gefunden wurde.</returns>
        /// <remarks>
        /// .NET Standard und .NET 5.0 erkennen in der Standardeinstellung nur eine geringe Anzahl von Zeichensätzen.
        /// Die Methode überschreibt diese Standardeinstellung.
        /// </remarks>
        public static Encoding GetEncoding(int codepage)
        {
            if(codepage is < 0 or > CODEPAGE_MAX)
            {
                return Encoding.UTF8;
            }

#if NETSTANDARD2_0_OR_GREATER || NET5_0_OR_GREATER
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
#endif
            try
            {
                return Encoding.GetEncoding(codepage);
            }
            catch
            {
                return Encoding.UTF8;
            }
        }

        /// <summary>
        /// Gibt für die Nummer einer Codepage ein entsprechendes <see cref="Encoding"/>-Objekt
        /// zurück, dessen Eigenschaften <see cref="Encoding.EncoderFallback"/> und <see cref="Encoding.DecoderFallback"/>
        /// auf die gewünschten Werte eingestellt sind.
        /// </summary>
        /// <param name="codepage">Die Nummer der Codepage oder 0 für <see cref="Encoding.Default"/>.</param>
        /// <returns>Ein <see cref="Encoding"/>-Objekt, das der angegebenen Nummer der Codepage
        /// entspricht oder ein <see cref="Encoding"/>-Objekt für den UTF-8 Zeichensatz, falls keine Entsprechung
        /// gefunden wurde.</returns>
        /// <param name="encoderFallback">Ein Objekt, das einen Fehlerbehandlungsmechanismus zur Verfügung stellt,
        /// falls ein Zeichen mit dem <see cref="Encoding"/>-Objekt nicht enkodiert werden kann.</param>
        /// <param name="decoderFallback">
        /// Ein Objekt, das einen Fehlerbehandlungsmechanismus zur Verfügung stellt,
        /// falls eine <see cref="byte"/>-Sequenz mit dem <see cref="Encoding"/>-Objekt nicht dekodiert werden kann.</param>
        /// <remarks>
        /// .NET Standard und .NET 5.0 erkennen in der Standardeinstellung nur eine geringe Anzahl von Zeichensätzen.
        /// Die Methode überschreibt diese Standardeinstellung.
        /// </remarks>
        public static Encoding GetEncoding(int codepage, EncoderFallback encoderFallback, DecoderFallback decoderFallback)
        {
            if(codepage is < 0 or > CODEPAGE_MAX)
            {
                return Encoding.GetEncoding(UTF_8, encoderFallback, decoderFallback);
            }

#if NETSTANDARD2_0_OR_GREATER || NET5_0_OR_GREATER
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
#endif
            try
            {
                return Encoding.GetEncoding(codepage, encoderFallback, decoderFallback);
            }
            catch
            {
                return Encoding.GetEncoding(UTF_8, encoderFallback, decoderFallback);
            }
        }

    }
}
