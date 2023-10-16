namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    /// <summary>Indicates whether a character span contains a newline character.</summary>
    /// <param name="span">The span to search.</param>
    /// <returns> <c>true</c> if <paramref name="span" /> contains a newline character, otherwise
    /// <c>false</c>.</returns>
    /// <remarks> <see cref="CharExtension.IsNewLine(char)" /> is used for the comparison.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsNewLine(this Span<char> span)
    => ((ReadOnlySpan<char>)span).ContainsNewLine();
}
