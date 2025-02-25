namespace FolkerKinzel.Strings;

public static partial class StringExtension
{
    /// <summary>Indicates whether the <see cref="string" /> contains Unicode characters
    /// that do not belong to the ASCII character set.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <returns> <c>false</c> if <paramref name="s" /> contains a Unicode character, which
    /// doesn't belong to the ASCII character set; otherwise, <c>true</c>.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    public static bool IsAscii(this string s)
        => s is null ? throw new ArgumentNullException(nameof(s))
                     : s.AsSpan().IsAscii();
}
