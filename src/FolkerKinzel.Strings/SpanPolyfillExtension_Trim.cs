namespace FolkerKinzel.Strings;

#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1

public static partial class SpanPolyfillExtension
{
    /// <summary>Removes all leading and trailing white space characters from a character
    /// span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <returns>The sliced span.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> Trim(this Span<char> span) => span.TrimStart().TrimEnd();

    /// <summary>Removes all leading white space characters from a character span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <returns>The sliced span.</returns>
    public static Span<char> TrimStart(this Span<char> span)
        => span.Slice(span.Length - ((ReadOnlySpan<char>)span).TrimStart().Length);

    /// <summary>Removes all trailing white space characters from a character span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <returns>The sliced span.</returns>
    public static Span<char> TrimEnd(this Span<char> span)
        => span.Slice(0, ((ReadOnlySpan<char>)span).TrimEnd().Length);

    /// <summary>Removes all leading and trailing occurrences of <paramref name="trimElement"/> from a character
    /// span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="trimElement">The specified <see cref="char"/> to look for and remove.</param>
    /// <returns>The sliced span.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> Trim(this Span<char> span, char trimElement)
        => span.TrimStart(trimElement).TrimEnd(trimElement);

    /// <summary>Removes all leading occurrences of <paramref name="trimElement"/> from a character span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="trimElement">The specified <see cref="char"/> to look for and remove.</param>
    /// <returns>The sliced span.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    public static Span<char> TrimStart(this Span<char> span, char trimElement)
        => span.Slice(span.Length - ((ReadOnlySpan<char>)span).TrimStart(trimElement).Length);

    /// <summary>Removes all trailing occurrences of <paramref name="trimElement"/> from a character span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="trimElement">The specified <see cref="char"/> to look for and remove.</param>
    /// <returns>The sliced span.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    public static Span<char> TrimEnd(this Span<char> span, char trimElement)
        => span.Slice(0, ((ReadOnlySpan<char>)span).TrimEnd(trimElement).Length);

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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> Trim(this Span<char> span, ReadOnlySpan<char> trimElements)
        => span.TrimStart(trimElements).TrimEnd(trimElements);

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
    public static Span<char> TrimStart(this Span<char> span, ReadOnlySpan<char> trimElements)
    {
        int idx = span.IndexOfAnyExcept(trimElements);
        return idx == -1 ? [] : span.Slice(idx);
    }

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
    public static Span<char> TrimEnd(this Span<char> span, ReadOnlySpan<char> trimElements) 
        => span.Slice(0, span.LastIndexOfAnyExcept(trimElements) + 1);

#if NET461 || NETSTANDARD2_0
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
    public static Span<char> Trim(this Span<char> span, string? trimElements)
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
    public static Span<char> TrimStart(this Span<char> span, string? trimElements)
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
    public static Span<char> TrimEnd(this Span<char> span, string? trimElements)
        => span.TrimEnd(trimElements.AsSpan());
#endif
}

#endif
