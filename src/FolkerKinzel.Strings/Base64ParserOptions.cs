namespace FolkerKinzel.Strings;

/// <summary>
/// Benannte Konstanten, um Optionen für das Parsen Base64-kodierter Zeichenfolgen anzugeben.
/// Die Flags können kombiniert werden.
/// </summary>
[Flags]
public enum Base64ParserOptions
{
    /// <summary>
    /// Keines der anderen Flags ist gesetzt.
    /// </summary>
    None,

    /// <summary>
    /// Setzen des Flags bewirkt, dass evtl. fehlende Füllzeichen ('=') am Ende der Base64-Daten vom
    /// Parser automatisch ergänzt werden.
    /// </summary>
    AcceptMissingPadding,

    /// <summary>
    /// Setzen des Flags bewirkt, dass Base64Url (RFC 4648, Kapitel 5) vom Parser akzeptiert wird. (Das
    /// Flag sollte i.d.R. mit <see cref="AcceptMissingPadding"/> kombiniert werden.)
    /// </summary>
    AcceptBase64Url
}
