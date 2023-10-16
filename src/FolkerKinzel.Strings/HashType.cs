namespace FolkerKinzel.Strings;

/// <summary>Named constants to specify the type of hashcode for Char sequences.</summary>
public enum HashType
{
    /// <summary>Ordinal comparison of the characters.</summary>
    Ordinal,

    /// <summary>Ordinal comparison of the characters without taking upper and lower case
    /// into account.</summary>
    OrdinalIgnoreCase,

    /// <summary>Only letters and decimal digits are hashed. The case is not considered.</summary>
    AlphaNumericIgnoreCase,
}
