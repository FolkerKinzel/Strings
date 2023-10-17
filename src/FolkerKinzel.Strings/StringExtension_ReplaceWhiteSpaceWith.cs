using System.Text.RegularExpressions;

namespace FolkerKinzel.Strings;

public static partial class StringExtension
{
    /// <summary>Generates a <see cref="string" /> in which all sequences of white space
    /// are replaced by <paramref name="replacement" />.</summary>
    /// <param name="s">The source <see cref="string" />.</param>
    /// <param name="replacement">A read-only character span that is the replacement for
    /// all white space sequences. If an empty span is passed to the parameter, each white
    /// space will be completely removed.</param>
    /// <param name="skipNewLines">Pass <c>true</c> to exclude newline characters from the
    /// replacement. The default value is <c>false</c>.</param>
    /// <returns>A new <see cref="string" /> in which all sequences of white space are replaced
    /// by <paramref name="replacement" />. If <paramref name="s" /> doesn't contain a white
    /// space character, <paramref name="s" /> is returned.</returns>
    /// <remarks>
    /// <para>
    /// The method uses <see cref="char.IsWhiteSpace(char)" /> to identify white space characters
    /// and works more thoroughly with it than <see cref="Regex.Replace(string, string, string)">
    /// Regex.Replace(string input, @"\s+", string replacement)</see>. 
    /// </para>
    /// <para>
    /// <see cref="CharExtension.IsNewLine(char)" /> is used to identify newline characters.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    public static string ReplaceWhiteSpaceWith(
        this string s,
        ReadOnlySpan<char> replacement,
        bool skipNewLines = false)
    {
        if (s is null)
        {
            throw new ArgumentNullException(nameof(s));
        }

        if (!s.ContainsWhiteSpace())
        {
            return s;
        }

        var sb = new StringBuilder(s.Length + s.Length / 2);
        return sb.Append(s)
                 .ReplaceWhiteSpaceWith(replacement, 0, sb.Length, skipNewLines)
                 .ToString();
    }

}
