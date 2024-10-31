namespace FolkerKinzel.Strings;

public static partial class SpanPolyfillExtension
{
    /// <summary>
    /// Searches for the first index of any value outside of the range between <paramref name="lowInclusive"/> and 
    /// <paramref name="highInclusive"/>, inclusive.
    /// </summary>
    /// <param name="span">The span to search.</param>
    /// <param name="lowInclusive">The lower bound, inclusive, of the excluded range.</param>
    /// <param name="highInclusive">The upper bound, inclusive, of the excluded range.</param>
    /// <returns>The index in the span of the first occurrence of any value outside of the specified range. If all
    /// of the values are inside of the specified range, returns -1.</returns>
#if NET8_0_OR_GREATER
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAnyExceptInRange(Span<char> span, char lowInclusive, char highInclusive)
        => MemoryExtensions.IndexOfAnyExceptInRange((ReadOnlySpan<char>)span, lowInclusive, highInclusive);
#else
    public static int IndexOfAnyExceptInRange(this Span<char> span, char lowInclusive, char highInclusive)
     => ReadOnlySpanPolyfillExtension.IndexOfAnyExceptInRange(span, lowInclusive, highInclusive);
#endif
}
