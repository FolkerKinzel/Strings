namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    /// <summary>Indicates whether a character span contains a white space character.</summary>
    /// <param name="span">The span to search.</param>
    /// <returns> <c>true</c> if <paramref name="span" /> contains white space, otherwise
    /// <c>false</c>.</returns>
    /// <remarks> <see cref="char.IsWhiteSpace(char)" /> is used for the comparison.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsWhiteSpace(this Span<char> span)
    => ((ReadOnlySpan<char>)span).ContainsWhiteSpace();
}
