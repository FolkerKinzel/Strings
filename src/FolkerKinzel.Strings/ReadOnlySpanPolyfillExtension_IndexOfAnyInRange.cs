namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanPolyfillExtension
{
    /// <summary>
    /// Searches for the first index of any value in the range between <paramref name="lowInclusive"/> and 
    /// <paramref name="highInclusive"/>, inclusive.
    /// </summary>
    /// <param name="span">The span to search.</param>
    /// <param name="lowInclusive">The lower bound, inclusive, of the range for which to search.</param>
    /// <param name="highInclusive">The upper bound, inclusive, of the range for which to search.</param>
    /// <returns>The index in the span of the first occurrence of any value in the specified range. If all 
    /// of the values are outside of the specified range, returns -1.</returns>
#if NET8_0_OR_GREATER
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAnyInRange(ReadOnlySpan<char> span, char lowInclusive, char highInclusive)
        => MemoryExtensions.IndexOfAnyInRange(span, lowInclusive, highInclusive);
#else
    public static int IndexOfAnyInRange(this ReadOnlySpan<char> span, char lowInclusive, char highInclusive)
    {
        if (span.Length == 0) { return -1; }

        if (lowInclusive > highInclusive)
        {
            return 0;
        }

        if (lowInclusive == highInclusive)
        {
            return span.IndexOf(lowInclusive);
        }

        for (int i = 0; i < span.Length; i++)
        {
            char c = span[i];

            if ((c >= lowInclusive) && (c <= highInclusive))
            {
                return i;
            }
        }

        return -1;
    }
#endif
}
