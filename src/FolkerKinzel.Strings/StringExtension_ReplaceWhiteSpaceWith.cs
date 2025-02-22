using System.Text.RegularExpressions;
using FolkerKinzel.Helpers.Polyfills;
using FolkerKinzel.Strings.Intls;

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
    public static string ReplaceWhiteSpaceWith(this string s,
                                               ReadOnlySpan<char> replacement,
                                               bool skipNewLines = false)
    {
        _ArgumentNullException.ThrowIfNull(s, nameof(s));

        ReadOnlySpan<char> inputSpan = s.AsSpan();
        int firstIdx = inputSpan.IndexOfWhiteSpace();

        if (firstIdx == -1)
        {
            return s;
        }

        int lastIdx = inputSpan.LastIndexOfWhiteSpace();
        ReadOnlySpan<char> processedSpan = inputSpan.Slice(firstIdx, lastIdx + 1 - firstIdx);

        int capacity = ComputeMaxCapacity(processedSpan.Length, replacement.Length);

        if (capacity > Const.StackallocCharThreshold)
        {
            using ArrayPoolHelper.SharedArray<char> buf = ArrayPoolHelper.Rent<char>(capacity);
            int outLength = processedSpan.ReplaceWhiteSpaceWith(replacement, buf.Array, skipNewLines);
            ReadOnlySpan<char> outSpan = buf.Array.AsSpan(0, outLength);
            return processedSpan.Equals(outSpan, StringComparison.Ordinal)
                ? s
                : StaticStringMethod.Concat(inputSpan.Slice(0, firstIdx), outSpan, inputSpan.Slice(lastIdx + 1));
        }
        else
        {
            Span<char> destination = stackalloc char[capacity];
            int outLength = processedSpan.ReplaceWhiteSpaceWith(replacement, destination, skipNewLines);
            ReadOnlySpan<char> outSpan = destination.Slice(0, outLength);
            return processedSpan.Equals(outSpan, StringComparison.Ordinal)
                ? s
                : StaticStringMethod.Concat(inputSpan.Slice(0, firstIdx), outSpan, inputSpan.Slice(lastIdx + 1));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static int ComputeMaxCapacity(int sourceLength, int replacementLength)
        {
            int halfEven = (sourceLength + 1) >> 1;
            return halfEven * Math.Max(1, replacementLength) + halfEven;
        }
    }
}
