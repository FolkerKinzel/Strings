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




}
