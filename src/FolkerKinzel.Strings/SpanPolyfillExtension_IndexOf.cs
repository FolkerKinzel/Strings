namespace FolkerKinzel.Strings;

public static partial class SpanPolyfillExtension
{
    // Place this preprocessor directive inside the class to let .NET 6.0 and above have an empty class!
#if NET461 || NETSTANDARD2_0

    /// <summary>
    /// Reports the zero-based index of the first occurrence of the specified 
    /// <paramref name="value"/> in the current <paramref name="span"/>.
    /// </summary>
    /// <param name="span">The source span.</param>
    /// <param name="value">The value to seek within the source span.</param>
    /// <param name="comparisonType">An enumeration value that determines how 
    /// <paramref name="span"/> and <paramref name="value"/> are compared.</param>
    /// <returns>The index of the first occurrence of <paramref name="value"/> in the 
    /// <paramref name="span"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOf(
        this Span<char> span, string? value, StringComparison comparisonType)
        => MemoryExtensions.IndexOf(span, value.AsSpan(), comparisonType);

#endif
}
