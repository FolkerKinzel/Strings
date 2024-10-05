namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanPolyfillExtension
{
    // CAUTION: With .NET 9 this will conflict with MemoryExtensions!

    /// <summary>Indicates whether a read-only character span begins with the 
    /// specified Unicode character.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <returns> <c>true</c> if <paramref name="span" /> starts with <paramref name="value"
    /// />, otherwise <c>false</c>.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool StartsWith(this ReadOnlySpan<char> span, char value)
     => !span.IsEmpty && span[0] == value;

    /// <summary>Indicates whether a read-only span of characters starts with the specified
    /// <see cref="string" />.</summary>
    /// <param name="span">The source span.</param>
    /// <param name="value">The <see cref="string" /> to compare with the beginning of the
    /// source span.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> matches the beginning of <paramref
    /// name="span" />, otherwise <c>false</c>.</returns>
    /// <remarks>The method performs an ordinal character comparison. If <paramref name="value"
    /// /> is <c>null</c> or <see cref="string.Empty" /> the method returns <c>true</c>.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET461 || NETSTANDARD2_0
    public static bool StartsWith(this ReadOnlySpan<char> span, string? value)
#else
    public static bool StartsWith(ReadOnlySpan<char> span, string? value)
#endif
        => span.StartsWith(value.AsSpan());

    /// <summary>Indicates whether a read-only character span begins with a specified <see
    /// cref="string" /> when compared using a specified <see cref="StringComparison" />
    /// value.</summary>
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
        this ReadOnlySpan<char> span, string? value, StringComparison comparisonType)
#else
    public static bool StartsWith(
        ReadOnlySpan<char> span, string? value, StringComparison comparisonType)
#endif
        => span.StartsWith(value.AsSpan(), comparisonType);
}

