namespace FolkerKinzel.Strings;

    /// <summary>Named constants to specify options for the parsing of Base64-encoded strings.
    /// The flags can be combined.</summary>
[Flags]
public enum Base64ParserOptions
{
    /// <summary>None of the flags has been set.</summary>
    None,

    /// <summary>Setting the flag lets the parser automatically add missing padding characters
    /// at the end of the Base64-encoded data.</summary>
    AcceptMissingPadding,

    /// <summary> Setzen des Flags bewirkt, dass Base64Url (RFC 4648, Kapitel 5) vom Parser
    /// akzeptiert wird. (Das Flag sollte i.d.R. mit <see cref="AcceptMissingPadding" />
    /// kombiniert werden.) </summary>
    AcceptBase64Url
}
