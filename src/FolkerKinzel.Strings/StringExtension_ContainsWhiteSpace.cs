namespace FolkerKinzel.Strings;

public static partial class StringExtension
{
    /// <summary>Indicates whether a <see cref="string" /> contains white space.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <returns> <c>true</c> if <paramref name="s" /> contains white space, otherwise <c>false</c>.</returns>
    /// <remarks> <see cref="char.IsWhiteSpace(char)" /> is used for the comparison.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    public static bool ContainsWhiteSpace(this string s)
        => s is null ? throw new ArgumentNullException(nameof(s)) : s.AsSpan().ContainsWhiteSpace();
}
