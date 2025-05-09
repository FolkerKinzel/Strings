namespace FolkerKinzel.Strings;

public static partial class SpanPolyfillExtension
{
    /// <summary>Indicates whether a character span ends with the specified <see cref="string"
    /// />.</summary>
    /// <param name="span">The source span.</param>
    /// <param name="value">The <see cref="string" /> to compare with the end of the source
    /// span.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> matches the end of <paramref name="span"
    /// />, otherwise <c>false</c>.</returns>
    /// <remarks>The method performs an ordinal character comparison. If <paramref name="value"
    /// /> is <c>null</c> or <see cref="string.Empty" /> the method returns <c>true</c>.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET462 || NETSTANDARD2_0
    public static bool EndsWith(this Span<char> span, string? value)
#else
    public static bool EndsWith(Span<char> span, string? value)
#endif
        => MemoryExtensions.EndsWith((ReadOnlySpan<char>)span, value.AsSpan());

    /// <summary>Indicates whether a character span ends with a specified <see cref="string"
    /// /> when compared using a specified <see cref="StringComparison" /> value.</summary>
    /// <param name="span">The source span.</param>
    /// <param name="value">The <see cref="string" /> to compare with the end of the source
    /// span.</param>
    /// <param name="comparisonType">An enumeration value that determines how <paramref name="span"
    /// /> and <paramref name="value" /> are compared.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> matches the end of <paramref name="span"
    /// />, otherwise <c>false</c>.</returns>
    /// <remarks>If <paramref name="value" /> is <c>null</c> or <see cref="string.Empty"
    /// /> the method returns <c>true</c>.</remarks>
    /// <exception cref="ArgumentException"> <paramref name="comparisonType" /> is not a
    /// defined value of the <see cref="StringComparison" /> enum.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET462 || NETSTANDARD2_0
    public static bool EndsWith(
        this Span<char> span, string? value, StringComparison comparisonType)
#else
    public static bool EndsWith(
        Span<char> span, string? value, StringComparison comparisonType)
#endif
        => MemoryExtensions.EndsWith(span, value.AsSpan(), comparisonType);
}

