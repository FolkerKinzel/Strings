namespace FolkerKinzel.Strings;

public static partial class SpanPolyfillExtension
{
    /// <summary>Indicates whether a read-only character span begins with a specified <see
    /// cref="string" />.</summary>
    /// <param name="span">The source span.</param>
    /// <param name="value">The <see cref="string" /> to compare with the beginning of the
    /// source span.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> matches the beginning of <paramref
    /// name="span" />, otherwise <c>false</c>.</returns>
    /// <remarks>The method performs an ordinal character comparison. If <paramref name="value"
    /// /> is <c>null</c> or <see cref="string.Empty" /> the method returns <c>true</c>.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET461 || NETSTANDARD2_0
    public static bool StartsWith(this Span<char> span, string? value)
#else
    public static bool StartsWith(Span<char> span, string? value)
#endif
        => ((ReadOnlySpan<char>)span).StartsWith(value.AsSpan());

    /// <summary>Indicates whether a character span begins with a specified <see cref="string"
    /// /> when compared using a specified <see cref="StringComparison" /> value.</summary>
    /// <param name="span">The source span.</param>
    /// <param name="value">The <see cref="string" /> to compare with the beginning of the
    /// source span.</param>
    /// <param name="comparisonType">An enumeration value that determines how <paramref name="span"
    /// /> and <paramref name="value" /> are compared.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> matches the beginning of <paramref
    /// name="span" />, otherwise <c>false</c>.</returns>
    /// <remarks>If <paramref name="value" /> is <c>null</c> or <see cref="string.Empty"
    /// /> the method returns <c>true</c>.</remarks>
    /// <exception cref="ArgumentException"> <paramref name="comparisonType" /> is not a
    /// defined value of the <see cref="StringComparison" /> enum.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET461 || NETSTANDARD2_0
    public static bool StartsWith(
        this Span<char> span, string? value, StringComparison comparisonType)
#else
    public static bool StartsWith(
        Span<char> span, string? value, StringComparison comparisonType)
#endif
        => ((ReadOnlySpan<char>)span).StartsWith(value.AsSpan(), comparisonType);
}