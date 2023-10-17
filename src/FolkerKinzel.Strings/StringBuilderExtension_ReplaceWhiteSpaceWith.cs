using System.Text.RegularExpressions;
using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>Replaces in <paramref name="builder" /> all sequences of white space with
    /// <paramref name="replacement" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="replacement">A read-only character span that is the replacement for
    /// all white space sequences. If an empty span is passed to the parameter, each white
    /// space will be completely removed.</param>
    /// <param name="skipNewLines">Pass <c>true</c> to exclude newline characters from the
    /// replacement. The default value is <c>false</c>.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
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
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder ReplaceWhiteSpaceWith(
        this StringBuilder builder,
        ReadOnlySpan<char> replacement,
        bool skipNewLines = false)
    => builder is null ? throw new ArgumentNullException(nameof(builder))
                       : builder.ReplaceWhiteSpaceWith(replacement, 0, builder.Length, skipNewLines);

    /// <summary>Replaces in a section of <paramref name="builder" />, which starts at <paramref
    /// name="startIndex" /> and extends to the end of <paramref name="builder" />, all sequences
    /// of white space with <paramref name="replacement" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="replacement">A read-only character span that is the replacement for
    /// all white space sequences. If an empty span is passed to the parameter, each white
    /// space will be completely removed.</param>
    /// <param name="startIndex">The zero-based index in <paramref name="builder" /> at which
    /// the replacement starts.</param>
    /// <param name="skipNewLines">Pass <c>true</c> to exclude newline characters from the
    /// replacement. The default value is <c>false</c>.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
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
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="startIndex" /> is
    /// less than zero or greater than the number of characters in <paramref name="builder"
    /// />.</exception>
    public static StringBuilder ReplaceWhiteSpaceWith(
        this StringBuilder builder,
        ReadOnlySpan<char> replacement,
        int startIndex,
        bool skipNewLines = false)
    => builder is null ? throw new ArgumentNullException(nameof(builder))
                       : builder.ReplaceWhiteSpaceWith(replacement,
                                                       startIndex,
                                                       builder.Length - startIndex,
                                                       skipNewLines);

    /// <summary>Replaces in a section of <paramref name="builder" />, which starts at <paramref
    /// name="startIndex" /> and which is <paramref name="count" /> characters long, all
    /// sequences of white space with <paramref name="replacement" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="replacement">A read-only character span that is the replacement for
    /// all white space sequences. If an empty span is passed to the parameter, each white
    /// space will be completely removed.</param>
    /// <param name="startIndex">The zero-based index in <paramref name="builder" /> at which
    /// the replacement starts.</param>
    /// <param name="count">The length of the specified section in <paramref name="builder"
    /// /> where replacement operations take place.</param>
    /// <param name="skipNewLines">Pass <c>true</c> to exclude newline characters from the
    /// replacement. The default value is <c>false</c>.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
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
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="startIndex" /> or <paramref name="count" /> are smaller than zero
    /// or larger than the number of characters in <paramref name="builder" />
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="startIndex" /> + <paramref name="count" /> is larger than the number
    /// of characters in <paramref name="builder" />.
    /// </para>
    /// </exception>
    public static StringBuilder ReplaceWhiteSpaceWith(this StringBuilder builder,
                                                      ReadOnlySpan<char> replacement,
                                                      int startIndex,
                                                      int count,
                                                      bool skipNewLines = false)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        if (startIndex < 0 || startIndex > builder.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex));
        }

        if (count < 0 || (count + startIndex) > builder.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        int wsLength = 0;

        for (int i = startIndex + count - 1; i >= startIndex; i--)
        {
            char current = builder[i];

            if (char.IsWhiteSpace(current) && (!skipNewLines || !current.IsNewLine()))
            {
                wsLength++;
            }
            else if (wsLength != 0)
            {
                int replacementIdx = i + 1;
                _ = builder.Remove(replacementIdx, wsLength).Insert(replacementIdx, replacement);
                wsLength = 0;
            }
        }

        if (wsLength != 0)
        {
            _ = builder.Remove(0, wsLength).Insert(0, replacement);
        }

        return builder;
    }

}
