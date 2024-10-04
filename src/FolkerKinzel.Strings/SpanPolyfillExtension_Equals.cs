namespace FolkerKinzel.Strings;


public static partial class SpanPolyfillExtension
{
    /// <summary>Determines whether this <paramref name="span" /> and the specified other
    /// <paramref name="other" />&#160;<see cref="string" /> have the same characters when
    /// compared using the specified <paramref name="comparisonType" /> option.</summary>
    /// <param name="span">The source span.</param>
    /// <param name="other">The value to compare with the source span.</param>
    /// <param name="comparisonType">An enumeration value that determines how <paramref name="span"
    /// /> and <paramref name="other" /> are compared.</param>
    /// <returns> <c>true</c> if identical, <c>false</c> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET461 || NETSTANDARD2_0
    public static bool Equals(
        this Span<char> span, string? other, StringComparison comparisonType)
#else
    public static bool Equals(
        Span<char> span, string? other, StringComparison comparisonType)
#endif
        => ((ReadOnlySpan<char>)span).Equals(other.AsSpan(), comparisonType);
}


