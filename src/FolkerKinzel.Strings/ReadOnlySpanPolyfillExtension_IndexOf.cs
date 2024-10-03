namespace FolkerKinzel.Strings;


public static partial class ReadOnlySpanPolyfillExtension
{
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
#if NET461 || NETSTANDARD2_0
    public static int IndexOf(
        this ReadOnlySpan<char> span, string? value, StringComparison comparisonType)
#else
    public static int IndexOf(
        ReadOnlySpan<char> span, string? value, StringComparison comparisonType)
#endif
        => span.IndexOf(value.AsSpan(), comparisonType);
}


