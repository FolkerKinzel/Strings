namespace FolkerKinzel.Strings;

public static partial class SpanPolyfillExtension
{
    /// <summary>Determines the length of any common prefix shared between <paramref name="span"/> and <paramref name="other"/>.</summary>
    /// <param name="span">The first sequence to compare.</param>
    /// <param name="other">The second sequence to compare or <c>null</c>.</param>
    /// <returns>The length of the common prefix shared by the two spans. If there's no shared prefix, 0 is returned.</returns>
    /// <remarks>
    /// The method performs an ordinal character comparison.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET461 || NETSTANDARD2_0
    public static int CommonPrefixLength(this Span<char> span, string? other)
#else
    public static int CommonPrefixLength(Span<char> span, string? other)
#endif
        => ReadOnlySpanPolyfillExtension.CommonPrefixLength(span, other.AsSpan());

    /// <summary>Determines the length of any common prefix shared between <paramref name="span"/> and <paramref name="other"/>.</summary>
    /// <param name="span">The first sequence to compare.</param>
    /// <param name="other">The second sequence to compare or <c>null</c>.</param>
    /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> implementation to use when comparing elements, or <c>null</c> 
    /// to use the default <see cref="IEqualityComparer{T}"/> for the type of <see cref="char"/>.</param>
    /// <returns>The length of the common prefix shared by the two spans. If there's no shared prefix, 0 is returned.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET461 || NETSTANDARD2_0
    public static int CommonPrefixLength(this Span<char> span, string? other, IEqualityComparer<char>? comparer)
#else
    public static int CommonPrefixLength(Span<char> span, string? other, IEqualityComparer<char>? comparer)
#endif
        => ReadOnlySpanPolyfillExtension.CommonPrefixLength(span, other.AsSpan(), comparer);


    /// <summary>Determines the length of any common prefix shared between <paramref name="span"/> and <paramref name="other"/>.</summary>
    /// <param name="span">The first sequence to compare.</param>
    /// <param name="other">The second sequence to compare.</param>
    /// <returns>The length of the common prefix shared by the two spans. If there's no shared prefix, 0 is returned.</returns>
    /// <remarks>
    /// The method performs an ordinal character comparison.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET7_0_OR_GREATER
    public static int CommonPrefixLength(Span<char> span, ReadOnlySpan<char> other)
        => MemoryExtensions.CommonPrefixLength(span, other);
#else
    public static int CommonPrefixLength(this Span<char> span, ReadOnlySpan<char> other)
        => ReadOnlySpanPolyfillExtension.CommonPrefixLength(span, other);
#endif

    /// <summary>Determines the length of any common prefix shared between <paramref name="span"/> and <paramref name="other"/>.</summary>
    /// <param name="span">The first sequence to compare.</param>
    /// <param name="other">The second sequence to compare.</param>
    /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> implementation to use when comparing elements, or <c>null</c> 
    /// to use the default <see cref="IEqualityComparer{T}"/> for the type of <see cref="char"/>.</param>
    /// <returns>The length of the common prefix shared by the two spans. If there's no shared prefix, 0 is returned.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET7_0_OR_GREATER
    public static int CommonPrefixLength(Span<char> span, ReadOnlySpan<char> other, IEqualityComparer<char>? comparer)
        => MemoryExtensions.CommonPrefixLength(span, other, comparer);
#else
    public static int CommonPrefixLength(this Span<char> span, ReadOnlySpan<char> other, IEqualityComparer<char>? comparer)
        => ReadOnlySpanPolyfillExtension.CommonPrefixLength(span, other, comparer);
#endif
}
