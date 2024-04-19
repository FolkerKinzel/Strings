namespace FolkerKinzel.Strings;

public static partial class SpanPolyfillExtension
{
    // Place this preprocessor directive inside the class to let .NET 6.0 and above have an empty class!
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1

    /// <summary>Removes all leading and trailing white space characters from a character
    /// span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <returns>The sliced span.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> Trim(this Span<char> span) => span.TrimStart().TrimEnd();

    /// <summary>Removes all leading white space characters from a character span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <returns>The sliced span.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> TrimStart(this Span<char> span)
        => span.Slice(span.GetTrimmedStart());

    /// <summary>Removes all trailing white space characters from a character span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <returns>The sliced span.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> TrimEnd(this Span<char> span)
        => span.Slice(0, span.GetTrimmedLength());

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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> TrimStart(this Span<char> span, char trimElement)
        => span.Slice(span.GetTrimmedStart(trimElement));

    /// <summary>Removes all trailing occurrences of <paramref name="trimElement"/> from a character span.</summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="trimElement">The specified <see cref="char"/> to look for and remove.</param>
    /// <returns>The sliced span.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<char> TrimEnd(this Span<char> span, char trimElement)
        => span.Slice(0, span.GetTrimmedLength(trimElement));

#endif

}
