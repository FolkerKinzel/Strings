namespace FolkerKinzel.Strings;

public static partial class SpanPolyfillExtension
{
    /// <summary>
    /// Searches for the last index of any value outside of the range between <paramref name="lowInclusive"/> and 
    /// <paramref name="highInclusive"/>, inclusive.
    /// </summary>
    /// <param name="span">The span to search.</param>
    /// <param name="lowInclusive">The lower bound, inclusive, of the excluded range.</param>
    /// <param name="highInclusive">The upper bound, inclusive, of the excluded range.</param>
    /// <returns>The index in the span of the last occurrence of any value outside of the specified range. If all 
    /// of the values are inside of the specified range, returns -1.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET8_0_OR_GREATER
    public static int LastIndexOfAnyExceptInRange(Span<char> span, char lowInclusive, char highInclusive)
        => MemoryExtensions.LastIndexOfAnyExceptInRange((ReadOnlySpan<char>)span, lowInclusive, highInclusive);
#else
    public static int LastIndexOfAnyExceptInRange(this Span<char> span, char lowInclusive, char highInclusive)
        => ReadOnlySpanPolyfillExtension.LastIndexOfAnyExceptInRange(span, lowInclusive, highInclusive);
#endif
}
