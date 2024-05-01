namespace FolkerKinzel.Strings;

/// <summary>Named constants to specify the type of hashcode for Char sequences.</summary>
public enum HashType
{
    /// <summary>Ordinal comparison of the characters.</summary>
    Ordinal = 1,

    /// <summary>Ordinal comparison of the characters without taking upper and lower case
    /// into account.</summary>
    OrdinalIgnoreCase = 2,

    /// <summary>Only letters and decimal digits are hashed. The case is not considered.</summary>
    AlphaNumericIgnoreCase = 3,
}
