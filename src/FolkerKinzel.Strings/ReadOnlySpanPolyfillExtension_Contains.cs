namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanPolyfillExtension
{
    /// <summary>Indicates whether a read-only character span contains the Unicode character
    /// that is passed to the method as argument.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> has been found, <c>false</c> otherwise.</returns>
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(this ReadOnlySpan<char> span, char value)
        => MemoryExtensions.IndexOf(span, value) != -1;
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(ReadOnlySpan<char> span, char value)
        => MemoryExtensions.Contains(span, value);
#endif

    /// <summary>Indicates whether a specified value occurs within a read-only character
    /// span.</summary>
    /// <param name="span">The source span.</param>
    /// <param name="value">The value to seek within the source span. <paramref name="value"
    /// /> can be <c>null</c>.</param>
    /// <param name="comparisonType">An enumeration value that determines how <paramref name="span"
    /// /> and <paramref name="value" /> are compared.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> has been found, <c>false</c> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET461 || NETSTANDARD2_0
    public static bool Contains(
        this ReadOnlySpan<char> span, string? value, StringComparison comparisonType)
#else
    public static bool Contains(
        ReadOnlySpan<char> span, string? value, StringComparison comparisonType)
#endif
        => MemoryExtensions.Contains(span, value.AsSpan(), comparisonType);
}

