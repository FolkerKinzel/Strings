namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanPolyfillExtension
{
    /// <summary>
    /// Searches for any value in the range between <paramref name="lowInclusive"/> and 
    /// <paramref name="highInclusive"/>, inclusive.
    /// </summary>
    /// <param name="span">The span to search.</param>
    /// <param name="lowInclusive">The lower bound, inclusive, of the range for which to search.</param>
    /// <param name="highInclusive">The upper bound, inclusive, of the range for which to search.</param>
    /// <returns><c>true</c> if found. If not found, returns <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET8_0_OR_GREATER
    public static bool ContainsAnyInRange(ReadOnlySpan<char> span, char lowInclusive, char highInclusive)
        => MemoryExtensions.ContainsAnyInRange(span, lowInclusive, highInclusive);
#else
    public static bool ContainsAnyInRange(this ReadOnlySpan<char> span, char lowInclusive, char highInclusive)
        => IndexOfAnyInRange(span, lowInclusive, highInclusive) != -1;
#endif
}
