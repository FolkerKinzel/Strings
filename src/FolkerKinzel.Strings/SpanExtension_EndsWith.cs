namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    /// <summary>Indicates whether a character span ends with the specified Unicode character.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <returns> <c>true</c> if <paramref name="span" /> ends with <paramref name="value"
    /// />, otherwise <c>false</c>.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EndsWith(this Span<char> span, char value)
     => ((ReadOnlySpan<char>)span).EndsWith(value);

    /// <summary>Indicates whether <paramref name="span" /> ends with <paramref name="value"
    /// /> when compared using a specified <see cref="StringComparison" /> value.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="value">The character sequence to compare with the end of <paramref name="span"
    /// />.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies the rules
    /// for the comparison.</param>
    /// <returns> <c>true</c> if <paramref name="span" /> ends with <paramref name="value"
    /// />, otherwise <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EndsWith(
        this Span<char> span, ReadOnlySpan<char> value, StringComparison comparisonType)
        => ((ReadOnlySpan<char>)span).EndsWith(value, comparisonType);

}
