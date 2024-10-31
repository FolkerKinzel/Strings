namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanPolyfillExtension
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
#if NET8_0_OR_GREATER
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOfAnyExceptInRange(ReadOnlySpan<char> span, char lowInclusive, char highInclusive)
        => MemoryExtensions.LastIndexOfAnyExceptInRange(span, lowInclusive, highInclusive);
#else
    public static int LastIndexOfAnyExceptInRange(this ReadOnlySpan<char> span, char lowInclusive, char highInclusive)
    {
        if (span.Length == 0) { return -1; }

        if (lowInclusive > highInclusive)
        {
            return - 1;
        }

        if (lowInclusive == highInclusive)
        {
            return span.LastIndexOfAnyExcept(lowInclusive);
        }

        int i;

        for (i = span.Length - 1; i >= 0; i--)
        {
            char c = span[i];

            if ((c < lowInclusive) || (c > highInclusive))
            {
                break;
            }
        }

        return i;
    }
#endif
}
