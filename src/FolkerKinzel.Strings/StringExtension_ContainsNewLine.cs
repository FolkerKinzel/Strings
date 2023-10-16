namespace FolkerKinzel.Strings;

public static partial class StringExtension
{
    /// <summary>Indicates whether the <see cref="string" /> contains a newline character.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <returns> <c>true</c> if <paramref name="s" /> contains white space, otherwise <c>false</c>.</returns>
    /// <remarks> <see cref="CharExtension.IsNewLine(char)" /> is used for the comparison.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    public static bool ContainsNewLine(this string s)
        => s is null ? throw new ArgumentNullException(nameof(s)) : s.AsSpan().ContainsNewLine();
}
