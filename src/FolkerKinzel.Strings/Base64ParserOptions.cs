namespace FolkerKinzel.Strings;

/// <summary>Named constants to specify options for the parsing of Base64-encoded strings.
/// The flags can be combined.</summary>
[Flags]
public enum Base64ParserOptions
{
    /// <summary>None of the flags has been set.</summary>
    None,

    /// <summary>Setting the flag lets the parser automatically add missing padding 
    /// characters at the end of the Base64-encoded data.</summary>
    AcceptMissingPadding,

    /// <summary> 
    /// Setting the flag lets the parser accept Base64Url too (RFC 4648, chapter 5). 
    /// (The flag should normally be combined with <see cref="AcceptMissingPadding" />.)
    /// </summary>
    AcceptBase64Url
}
