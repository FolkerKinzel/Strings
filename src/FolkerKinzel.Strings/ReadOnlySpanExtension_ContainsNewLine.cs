namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    /// <summary>Indicates whether a read-only character span contains a newline character.</summary>
    /// <param name="span">The span to search.</param>
    /// <returns> <c>true</c> if <paramref name="span" /> contains a newline character, otherwise
    /// <c>false</c>.</returns>
    /// <remarks> <see cref="CharExtension.IsNewLine(char)" /> is used for the comparison.</remarks>
    public static bool ContainsNewLine(this ReadOnlySpan<char> span)
    {
        for (int i = 0; i < span.Length; i++)
        {
            if (span[i].IsNewLine())
            {
                return true;
            }
        }

        return false;
    }
}
