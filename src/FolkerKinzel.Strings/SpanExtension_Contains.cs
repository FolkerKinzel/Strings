namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    /// <summary>Indicates whether a specified sequence of Unicode characters occurs within
    /// a character span.</summary>
    /// <param name="span">The source span.</param>
    /// <param name="value">The character sequence to search for.</param>
    /// <param name="comparisonType">An enumeration value that determines how <paramref name="span"
    /// /> and <paramref name="value" /> are compared.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> has been found, <c>false</c> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(
        this Span<char> span, ReadOnlySpan<char> value, StringComparison comparisonType)
        => ((ReadOnlySpan<char>)span).Contains(value, comparisonType);

}
