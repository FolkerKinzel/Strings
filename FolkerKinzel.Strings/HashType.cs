namespace FolkerKinzel.Strings
{
    /// <summary>
    /// Benannte Konstanten, um die Art eines String-Hashcodes festzulegen.
    /// </summary>
    public enum HashType
    {
        /// <summary>
        /// Ordinalvergleich der Zeichen
        /// </summary>
        Ordinal,

        /// <summary>
        /// Ordinalvergleich der Zeichen ohne Berücksichtigung der Groß- und Kleinschreibung.
        /// </summary>
        OrdinalIgnoreCase,

        /// <summary>
        /// Nur Buchstaben und Ziffern werden gehasht. Die Groß- und Kleinschreibung wird nicht berücksichtigt.
        /// </summary>
        AlphaNumericNoCase
    }
}
