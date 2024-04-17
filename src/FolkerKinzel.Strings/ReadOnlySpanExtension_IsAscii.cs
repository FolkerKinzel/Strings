namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    /// <summary>Checks whether the read-only character span contains only Unicode 
    /// characters that belong to the ASCII character set.</summary>
    /// <param name="span">A read-only span of Unicode characters.</param>
    /// <returns> <c>false</c> if <paramref name="span" /> contains a Unicode character,
    /// which doesn't belong to the ASCII character set, otherwise <c>true</c>.</returns>
    public static bool IsAscii(this ReadOnlySpan<char> span)
    {
        for (int i = 0; i < span.Length; ++i)
        {
            if (!span[i].IsAscii())
            {
                return false;
            }
        }
        return true;
    }
}
