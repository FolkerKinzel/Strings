namespace FolkerKinzel.Strings;

#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1

public static partial class SpanPolyfillExtension
{
    /// <summary>Indicates whether a character span contains a specified Unicode character.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> has been found, <c>false</c> otherwise.</returns>
    /// <remarks><see cref="MemoryExtensions.IndexOf{T}(Span{T}, T)">
    /// MemoryExtensions.IndexOf(this Span&lt;T&gt;, T)</see> is used for the comparison.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(this Span<char> span, char value)
        => span.IndexOf(value) != -1;

#if NET461 || NETSTANDARD2_0

    /// <summary>Indicates whether a specified value occurs within a character span when
    /// compared using a specified <see cref="StringComparison" /> value.</summary>
    /// <param name="span">The source span.</param>
    /// <param name="value">The value to seek within the source span. <paramref name="value"
    /// /> can be <c>null</c>.</param>
    /// <param name="comparisonType">An enumeration value that determines how <paramref name="span"
    /// /> and <paramref name="value" /> are compared.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> has been found, <c>false</c> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(
        this Span<char> span, string? value, StringComparison comparisonType)
        => ((ReadOnlySpan<char>)span).Contains(value.AsSpan(), comparisonType);

#endif
}

#endif