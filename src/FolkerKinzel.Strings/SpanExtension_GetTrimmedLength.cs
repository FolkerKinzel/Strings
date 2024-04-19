namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    /// <summary>Returns the length that the character span would have without trailing white
    /// space.</summary>
    /// <param name="span">The span to examine.</param>
    /// <returns>The length that the span would have without trailing white space.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetTrimmedLength(this Span<char> span)
    => ((ReadOnlySpan<char>)span).GetTrimmedLength();

    /// <summary>Returns the length that the character span would have without trailing occurrences
    /// of <paramref name="trimChar"/>.</summary>
    /// <param name="span">The character span to examine.</param>
    /// <param name="trimChar">The <see cref="char"/> to remove from the end of <paramref name="span"/>.</param>
    /// <returns>The length that the span would have without trailing occurrences
    /// of <paramref name="trimChar"/>.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetTrimmedLength(this Span<char> span, char trimChar)
        => ((ReadOnlySpan<char>)span).GetTrimmedLength(trimChar);
}
