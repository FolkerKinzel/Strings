using System.Text;

namespace FolkerKinzel.Strings
{
    /// <summary>
    /// Wandelt einen <see cref="string"/>, der eine Bezeichnung für einen Zeichensatz darstellt in eine
    /// Instanz der <see cref="Encoding"/>-Klasse um.
    /// </summary>
    public static class TextEncodingConverter
    {
        /// <summary>
        /// Gibt für den Bezeichner eines Zeichensatzes ein entsprechendes <see cref="Encoding"/>-Objekt
        /// zurück. <see cref="Encoding.UTF8"/> ist der Fallback-Wert.
        /// </summary>
        /// <param name="s">Der Bezeichner eines Zeichensatzes oder <c>null</c>.</param>
        /// <returns>Ein <see cref="Encoding"/>-Objekt, das dem angegebenen Bezeichner des Zeichensatzes
        /// entspricht oder <see cref="Encoding.UTF8"/>, falls keine Entsprechung gefunden wurde.</returns>
        /// <remarks>
        /// .NET Standard und .NET 5.0 erkennen in der Standardeinstellung nur eine geringe Anzahl von Zeichensätzen.
        /// Die Methode überschreibt diese Standardeinstellung.
        /// </remarks>
        public static Encoding GetEncoding(string? s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return Encoding.UTF8;
            }

#if NETSTANDARD2_0_OR_GREATER || NET5_0_OR_GREATER
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
#endif

            try
            {
                return Encoding.GetEncoding(s);
            }
            catch
            {
                return Encoding.UTF8;
            }
        }
    }
}
