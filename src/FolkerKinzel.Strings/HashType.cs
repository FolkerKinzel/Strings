﻿using System;
using System.ComponentModel;

namespace FolkerKinzel.Strings
{
    /// <summary>
    /// Benannte Konstanten, um die Art eines Hashcodes für Zeichenfolgen festzulegen.
    /// </summary>
    public enum HashType
    {
        /// <summary>
        /// Ordinalvergleich der Zeichen.
        /// </summary>
        Ordinal,

        /// <summary>
        /// Ordinalvergleich der Zeichen ohne Berücksichtigung der Groß- und Kleinschreibung.
        /// </summary>
        OrdinalIgnoreCase,

        /// <summary>
        /// Nur Buchstaben und Dezimalziffern werden gehasht. Die Groß- und Kleinschreibung wird nicht berücksichtigt.
        /// </summary>
        AlphaNumericIgnoreCase,

        /// <summary>
        /// Obsolete.
        /// </summary>
        [Obsolete("Use AlphanumericIgnoreCase instead!", true)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        AlphaNumericNoCase = AlphaNumericIgnoreCase
    }
}
