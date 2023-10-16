namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    /// <summary>Indicates whether a read-only span of characters contains white space.</summary>
    /// <param name="span">The span to search.</param>
    /// <returns> <c>true</c> if <paramref name="span" /> contains white space, otherwise
    /// <c>false</c>.</returns>
    /// <remarks> <see cref="char.IsWhiteSpace(char)" /> is used for the comparison.</remarks>
    public static bool ContainsWhiteSpace(this ReadOnlySpan<char> span)
    {
        for (int i = 0; i < span.Length; i++)
        {
            if (char.IsWhiteSpace(span[i]))
            {
                return true;
            }
        }

        return false;
    }
}
