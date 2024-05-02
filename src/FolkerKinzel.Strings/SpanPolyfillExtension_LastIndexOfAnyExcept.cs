namespace FolkerKinzel.Strings;

#if NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET461

public static partial class SpanPolyfillExtension
{
    /// <summary>Returns the index of the last character in the 
    /// span that is not equal to <paramref name="value"/>.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="value">The <see cref="char"/> to avoid.</param>
    /// <returns>The index in the span of the last occurrence of any character other 
    /// than <paramref name="value"/>. If all of the characters are <paramref name="value"/>, 
    /// returns -1.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOfAnyExcept(this Span<char> span, char value)
    => ((ReadOnlySpan<char>)span).LastIndexOfAnyExcept(value);
}
#endif
