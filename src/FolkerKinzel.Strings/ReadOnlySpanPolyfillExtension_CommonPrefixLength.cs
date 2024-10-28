namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanPolyfillExtension
{
    /// <summary>Determines the length of any common prefix shared between <paramref name="span"/> and <paramref name="other"/>.</summary>
    /// <param name="span">The first sequence to compare.</param>
    /// <param name="other">The second sequence to compare.</param>
    /// <returns>The length of the common prefix shared by the two spans. If there's no shared prefix, 0 is returned.</returns>
    /// <remarks>
    /// The method performs an ordinal character comparison.
    /// </remarks>
#if NET7_0_OR_GREATER
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CommonPrefixLength(ReadOnlySpan<char> span, ReadOnlySpan<char> other)
        => MemoryExtensions.CommonPrefixLength(span, other);
#else
    public static int CommonPrefixLength(this ReadOnlySpan<char> span, ReadOnlySpan<char> other)
    {
        // Shrink one of the spans if necessary to ensure they're both the same length. We can then iterate until
        // the Length of one of them and at least have bounds checks removed from that one.
        SliceLongerSpanToMatchShorterLength(ref span, ref other);

        for (int i = 0; i < span.Length; i++)
        {
            if (span[i] != other[i])
            {
                return i;
            }
        }

        return span.Length;
    }
#endif

    /// <summary>Determines the length of any common prefix shared between <paramref name="span"/> and <paramref name="other"/>.</summary>
    /// <param name="span">The first sequence to compare.</param>
    /// <param name="other">The second sequence to compare.</param>
    /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> implementation to use when comparing elements, or <c>null</c> 
    /// to use the default <see cref="IEqualityComparer{T}"/> for the type of <see cref="char"/>.</param>
    /// <returns>The length of the common prefix shared by the two spans. If there's no shared prefix, 0 is returned.</returns>
#if NET7_0_OR_GREATER
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CommonPrefixLength(ReadOnlySpan<char> span, ReadOnlySpan<char> other, IEqualityComparer<char>? comparer)
        => MemoryExtensions.CommonPrefixLength(span, other, comparer);
#else
    public static int CommonPrefixLength(this ReadOnlySpan<char> span, ReadOnlySpan<char> other, IEqualityComparer<char>? comparer)
    {
        // If the comparer is null or the default, we want to use EqualityComparer<T>.Default.Equals
        // directly.
        if (comparer is null || comparer == EqualityComparer<char>.Default)
        {
            return CommonPrefixLength(span, other);
        }

        // Shrink one of the spans if necessary to ensure they're both the same length. We can then iterate until
        // the Length of one of them and at least have bounds checks removed from that one.
        SliceLongerSpanToMatchShorterLength(ref span, ref other);

        for (int i = 0; i < span.Length; i++)
        {
            if (!comparer.Equals(span[i], other[i]))
            {
                return i;
            }
        }

        return span.Length;
    }

    /// <summary>Determines if one span is longer than the other, and slices the longer one to match the length of the shorter.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void SliceLongerSpanToMatchShorterLength(ref ReadOnlySpan<char> span, ref ReadOnlySpan<char> other)
    {
        if (other.Length > span.Length)
        {
            other = other.Slice(0, span.Length);
        }
        else if (span.Length > other.Length)
        {
            span = span.Slice(0, other.Length);
        }

        Debug.Assert(span.Length == other.Length);
    }
#endif
}
