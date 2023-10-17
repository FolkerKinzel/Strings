namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    /// <summary>Checks whether the character span contains only Unicode characters that
    /// belong to the ASCII character set.</summary>
    /// <param name="span">A span of Unicode characters.</param>
    /// <returns> <c>false</c> if <paramref name="span" /> contains a Unicode character,
    /// which doesn't belong to the ASCII character set, otherwise <c>true</c>.</returns>
    public static bool IsAscii(this Span<char> span) => ((ReadOnlySpan<char>)span).IsAscii();

}
