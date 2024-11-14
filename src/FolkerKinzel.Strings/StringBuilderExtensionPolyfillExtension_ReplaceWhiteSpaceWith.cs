using System.Text.RegularExpressions;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtensionPolyfillExtension
{
    /// <summary>Replaces in <paramref name="builder" /> all sequences of white space with
    /// <paramref name="replacement" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="replacement">A <see cref="string" /> that is the replacement for all
    /// sequences of white space, or <c>null</c> to completely remove all white space.</param>
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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder ReplaceWhiteSpaceWith(
#if NET462 || NETSTANDARD2_0
        this StringBuilder builder,
#else
        StringBuilder builder,
#endif
        string? replacement,
        bool skipNewLines = false)
        => builder.ReplaceWhiteSpaceWith(replacement.AsSpan(), skipNewLines);

    /// <summary>Replaces in a section of <paramref name="builder" />, which starts at <paramref
    /// name="startIndex" /> and extends to the end of <paramref name="builder" />, all sequences
    /// of white space with <paramref name="replacement" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="replacement">A <see cref="string" /> that is the replacement for all
    /// sequences of white space, or <c>null</c> to completely remove all white space.</param>
    /// <param name="skipNewLines">Pass <c>true</c> to exclude newline characters from the
    /// replacement. The default value is <c>false</c>.</param>
    /// <param name="startIndex">The zero-based index in <paramref name="builder" /> at which
    /// the replacement starts.</param>
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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder ReplaceWhiteSpaceWith(
#if NET462 || NETSTANDARD2_0
        this StringBuilder builder,
#else
        StringBuilder builder,
#endif
        string? replacement,
        int startIndex,
        bool skipNewLines = false)
    => builder.ReplaceWhiteSpaceWith(replacement.AsSpan(), startIndex, skipNewLines);

    /// <summary>Replaces in a section of <paramref name="builder" />, which starts at <paramref
    /// name="startIndex" /> and which is <paramref name="count" /> characters long, all
    /// sequences of white space with <paramref name="replacement" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="replacement">A <see cref="string" /> that is the replacement for all
    /// sequences of white space, or <c>null</c> to completely remove all white space.</param>
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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder ReplaceWhiteSpaceWith(
#if NET462 || NETSTANDARD2_0
        this StringBuilder builder,
#else
        StringBuilder builder,
#endif
        string? replacement,
        int startIndex,
        int count,
        bool skipNewLines = false)
    => builder.ReplaceWhiteSpaceWith(replacement.AsSpan(), startIndex, count, skipNewLines);
}

