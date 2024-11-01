namespace FolkerKinzel.Strings;

public static partial class SpanPolyfillExtension
{
    /// <summary>Removes all leading and trailing white space characters from a character
    /// span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <returns>The sliced span.</returns>
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> Trim(this Span<char> span) => span.TrimStart().TrimEnd();
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> Trim(Span<char> span)
        => MemoryExtensions.Trim(span);
#endif

    /// <summary>Removes all leading white space characters from a character span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <returns>The sliced span.</returns>
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1
    public static Span<char> TrimStart(this Span<char> span)
        => span.Slice(span.Length - ((ReadOnlySpan<char>)span).TrimStart().Length);
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> TrimStart(Span<char> span)
    => MemoryExtensions.TrimStart(span);
#endif

    /// <summary>Removes all trailing white space characters from a character span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <returns>The sliced span.</returns>
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1
    public static Span<char> TrimEnd(this Span<char> span)
        => span.Slice(0, ((ReadOnlySpan<char>)span).TrimEnd().Length);
#else
    [MethodImpl (MethodImplOptions.AggressiveInlining)]
    public static Span<char> TrimEnd(Span<char> span)
        => MemoryExtensions.TrimEnd(span);
#endif

    /// <summary>Removes all leading and trailing occurrences of <paramref name="trimElement"/> from a character
    /// span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="trimElement">The specified <see cref="char"/> to look for and remove.</param>
    /// <returns>The sliced span.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> Trim(this Span<char> span, char trimElement)
        => span.TrimStart(trimElement).TrimEnd(trimElement);
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> Trim(Span<char> span, char trimElement)
        => MemoryExtensions.Trim(span, trimElement);
#endif

    /// <summary>Removes all leading occurrences of <paramref name="trimElement"/> from a character span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="trimElement">The specified <see cref="char"/> to look for and remove.</param>
    /// <returns>The sliced span.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1
    public static Span<char> TrimStart(this Span<char> span, char trimElement)
        => span.Slice(span.Length - ((ReadOnlySpan<char>)span).TrimStart(trimElement).Length);
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> TrimStart(Span<char> span, char trimElement)
        => MemoryExtensions.TrimStart(span, trimElement);
#endif

    /// <summary>Removes all trailing occurrences of <paramref name="trimElement"/> from a character span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="trimElement">The specified <see cref="char"/> to look for and remove.</param>
    /// <returns>The sliced span.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1
    public static Span<char> TrimEnd(this Span<char> span, char trimElement)
        => span.Slice(0, ((ReadOnlySpan<char>)span).TrimEnd(trimElement).Length);
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> TrimEnd(Span<char> span, char trimElement)
        => MemoryExtensions.TrimEnd(span, trimElement);
#endif

    /// <summary>Removes all leading and trailing occurrences of a set of characters specified in a 
    /// read-only span from a character span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="trimElements">The span, which contains the set of characters to remove.</param>
    /// <returns>The sliced span.</returns>
    /// <remarks>
    /// <para>
    /// If <paramref name="trimElements"/> is empty, the span is returned unaltered.
    /// </para>
    /// <para>
    /// The method performs an ordinal character comparison.
    /// </para>
    /// </remarks>
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> Trim(this Span<char> span, ReadOnlySpan<char> trimElements)
        => span.TrimStart(trimElements).TrimEnd(trimElements);
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> Trim(Span<char> span, ReadOnlySpan<char> trimElements)
        => MemoryExtensions.Trim(span, trimElements);
#endif

    /// <summary>Removes all leading occurrences of a set of characters specified in a read-only span 
    /// from a character span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="trimElements">The span, which contains the set of characters to remove.</param>
    /// <returns>The sliced span.</returns>
    /// <remarks>
    /// <para>
    /// If <paramref name="trimElements"/> is empty, the span is returned unaltered.
    /// </para>
    /// <para>
    /// The method performs an ordinal character comparison.
    /// </para>
    /// </remarks>
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1
    public static Span<char> TrimStart(this Span<char> span, ReadOnlySpan<char> trimElements)
    {
        int idx = ReadOnlySpanPolyfillExtension.IndexOfAnyExcept(span, trimElements);
        return idx == -1 ? [] : span.Slice(idx);
    }
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> TrimStart(Span<char> span, ReadOnlySpan<char> trimElements)
        => MemoryExtensions.TrimStart(span, trimElements);
#endif

    /// <summary>Removes all trailing occurrences of a set of characters specified in a read-only span 
    /// from a character span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="trimElements">The span, which contains the set of characters to remove.</param>
    /// <returns>The sliced span.</returns>
    /// <remarks>
    /// <para>
    /// If <paramref name="trimElements"/> is empty, the span is returned unaltered.
    /// </para>
    /// <para>
    /// The method performs an ordinal character comparison.
    /// </para>
    /// </remarks>
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1
    public static Span<char> TrimEnd(this Span<char> span, ReadOnlySpan<char> trimElements)
        => span.Slice(0, ReadOnlySpanPolyfillExtension.LastIndexOfAnyExcept(span, trimElements) + 1);
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> TrimEnd(Span<char> span, ReadOnlySpan<char> trimElements)
        => MemoryExtensions.TrimEnd(span, trimElements);
#endif

    /// <summary>Removes all leading and trailing occurrences of a set of characters specified in a 
    /// <see cref="string"/> from a character span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="trimElements">The <see cref="string"/>, which contains the set of characters to 
    /// remove, or <c>null</c>.</param>
    /// <returns>The sliced span.</returns>
    /// <remarks>
    /// <para>
    /// If <paramref name="trimElements"/> is <c>null</c> or <see cref="string.Empty"/>, the span is returned unaltered.
    /// </para>
    /// <para>
    /// The method performs an ordinal character comparison.
    /// </para>
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET461 || NETSTANDARD2_0
    public static Span<char> Trim(this Span<char> span, string? trimElements)
#else
    public static Span<char> Trim(Span<char> span, string? trimElements)
#endif
        => span.Trim(trimElements.AsSpan());

    /// <summary>Removes all leading occurrences of a set of characters specified in a <see cref="string"/> 
    /// from a character span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="trimElements">The <see cref="string"/>, which contains the set of characters to remove, or <c>null</c>.</param>
    /// <returns>The sliced span.</returns>
    /// <remarks>
    /// <para>
    /// If <paramref name="trimElements"/> is <c>null</c> or <see cref="string.Empty"/>, the span is returned unaltered.
    /// </para>
    /// <para>
    /// The method performs an ordinal character comparison.
    /// </para>
    /// </remarks>
#if NET461 || NETSTANDARD2_0
    public static Span<char> TrimStart(this Span<char> span, string? trimElements)
#else
    public static Span<char> TrimStart(Span<char> span, string? trimElements)
#endif
        => span.TrimStart(trimElements.AsSpan());

    /// <summary>Removes all trailing occurrences of a set of characters specified in a <see cref="string"/> 
    /// from a character span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="trimElements">The <see cref="string"/>, which contains the set of characters to remove, or <c>null</c>.</param>
    /// <returns>The sliced span.</returns>
    /// <remarks>
    /// <para>
    /// If <paramref name="trimElements"/> is <c>null</c> or <see cref="string.Empty"/>, the span is returned unaltered.
    /// </para>
    /// <para>
    /// The method performs an ordinal character comparison.
    /// </para>
    /// </remarks>
#if NET461 || NETSTANDARD2_0
    public static Span<char> TrimEnd(this Span<char> span, string? trimElements)
#else
    public static Span<char> TrimEnd(Span<char> span, string? trimElements)
#endif
        => span.TrimEnd(trimElements.AsSpan());
}

