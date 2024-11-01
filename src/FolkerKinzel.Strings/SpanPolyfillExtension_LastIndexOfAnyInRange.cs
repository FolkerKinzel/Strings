namespace FolkerKinzel.Strings;

public static partial class SpanPolyfillExtension
{
    /// <summary>
    /// Searches for the last index of any value in the range between <paramref name="lowInclusive"/> and 
    /// <paramref name="highInclusive"/>, inclusive.
    /// </summary>
    /// <param name="span">The span to search.</param>
    /// <param name="lowInclusive">The lower bound, inclusive, of the range for which to search.</param>
    /// <param name="highInclusive">The upper bound, inclusive, of the range for which to search.</param>
    /// <returns>The index in the span of the last occurrence of any value in the specified range. If all 
    /// of the values are outside of the specified range, returns -1.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET8_0_OR_GREATER
    public static int LastIndexOfAnyInRange(Span<char> span, char lowInclusive, char highInclusive)
        => MemoryExtensions.LastIndexOfAnyInRange((ReadOnlySpan<char>)span, lowInclusive, highInclusive);
#else
    public static int LastIndexOfAnyInRange(this Span<char> span, char lowInclusive, char highInclusive)
     => ReadOnlySpanPolyfillExtension.LastIndexOfAnyInRange(span, lowInclusive, highInclusive);
#endif
}
