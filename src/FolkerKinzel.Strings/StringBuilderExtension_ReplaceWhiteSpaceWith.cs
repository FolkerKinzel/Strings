using System.Text.RegularExpressions;
using FolkerKinzel.Helpers.Polyfills;
using FolkerKinzel.Strings.Intls;

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
    /// 
    public static StringBuilder ReplaceWhiteSpaceWith(this StringBuilder builder,
                                                      ReadOnlySpan<char> replacement,
                                                      int startIndex,
                                                      int count,
                                                      bool skipNewLines = false)
    {
        _ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        if ((uint)startIndex > (uint)builder.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex));
        }

        if ((uint)count > (uint)(builder.Length - startIndex))
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        if (count == 0)
        {
            return builder;
        }

        using ArrayPoolHelper.SharedArray<char> source = ArrayPoolHelper.Rent<char>(count);
        builder.CopyTo(startIndex, source.Array, 0, count);
        ReadOnlySpan<char> sourceSpan = source.Array.AsSpan(0, count);

        int firstWhiteSpaceIdx = sourceSpan.IndexOfWhiteSpace();

        if (firstWhiteSpaceIdx == -1)
        {
            return builder;
        }

        int lastWhiteSpaceIdx = sourceSpan.LastIndexOfWhiteSpace();
        ReadOnlySpan<char> processedSpan = sourceSpan.Slice(firstWhiteSpaceIdx, lastWhiteSpaceIdx + 1 - firstWhiteSpaceIdx);

        int capacity = ComputeMaxCapacity(processedSpan.Length, replacement.Length);

        using ArrayPoolHelper.SharedArray<char> buf = ArrayPoolHelper.Rent<char>(capacity);
        int outLength = processedSpan.ReplaceWhiteSpaceWith(replacement, buf.Array, skipNewLines);

        if (startIndex + count == builder.Length)
        {
            builder.Length = startIndex + firstWhiteSpaceIdx;
            builder.Append(buf.Array, 0, outLength);
            int startOfRemaining = lastWhiteSpaceIdx + 1;
            builder.Append(source.Array, startOfRemaining, sourceSpan.Length - startOfRemaining);
        }
        else if (!processedSpan.Equals(buf.Array.AsSpan(0, outLength), StringComparison.Ordinal))
        {
            using ArrayPoolHelper.SharedArray<char> trailing = CopyTrailingChunk(builder, startIndex + count, out int trailingChunkLength);

            builder.Length = startIndex + firstWhiteSpaceIdx;
            builder.Append(buf.Array, 0, outLength);
            int startOfRemaining = lastWhiteSpaceIdx + 1;
            builder.Append(source.Array, startOfRemaining, sourceSpan.Length - startOfRemaining);
            builder.Append(trailing.Array, 0, trailingChunkLength);
        }

        return builder;

        //////////////////////////////////////////////////////////////////////////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static int ComputeMaxCapacity(int sourceLength, int replacementLength)
        {
            int halfEven = (sourceLength + 1) >> 1;
            return halfEven * Math.Max(1, replacementLength) + halfEven;
        }

        static ArrayPoolHelper.SharedArray<char> CopyTrailingChunk(StringBuilder builder, int remainingStart, out int remainingLength)
        {
            remainingLength = builder.Length - remainingStart;
            ArrayPoolHelper.SharedArray<char> copy = ArrayPoolHelper.Rent<char>(remainingLength);
            builder.CopyTo(remainingStart, copy.Array, 0, remainingLength);
            return copy;
        }
    }
}
