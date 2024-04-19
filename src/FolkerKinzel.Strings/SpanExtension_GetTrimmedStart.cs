namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    /// <summary>Returns the index of the first non-white-space character in the span.</summary>
    /// <param name="span">The span to examine.</param>
    /// <returns>The index of the first non-white-space character found in the span. If the
    /// span is empty or consists only of white space, the length of the span is returned.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetTrimmedStart(this Span<char> span)
    => ((ReadOnlySpan<char>)span).GetTrimmedStart();

    /// <summary>Returns the index of the first character in the 
    /// span that is not equal to <paramref name="trimChar"/>.</summary>
    /// <param name="span">The character span to examine.</param>
    /// <param name="trimChar">The <see cref="char"/> to remove from the beginning of <paramref name="span"/>.</param>
    /// <returns>The index of the first first character in the 
    /// span that is not equal to <paramref name="trimChar"/>. If the
    /// span is empty or consists only of <paramref name="trimChar"/>s, <c>0</c> is returned.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    public static int GetTrimmedStart(this Span<char> span, char trimChar)
        => ((ReadOnlySpan<char>)span).GetTrimmedStart(trimChar);
}
