using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>Replaces all newlines in <paramref name="builder" /> with 
    /// <paramref name="replacementText" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="replacementText">The text to use as replacement. If 
    /// <paramref name="replacementText" /> is <c>null</c> or <see cref="string.Empty" />, all 
    /// newlines will be removed.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <remarks>
    /// <para>
    /// The list of recognized newline sequences is:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// CR (U+000D)
    /// </item>
    /// <item>
    /// LF (U+000A)
    /// </item>
    /// <item>
    /// CRLF (U+000D U+000A)
    /// </item>
    /// <item>
    /// NEL (U+0085)
    /// </item>
    /// <item>
    /// LS (U+2028)
    /// </item>
    /// <item>
    /// FF (U+000C)
    /// </item>
    /// <item>
    /// PS (U+2029)
    /// </item>
    /// </list>
    /// <para>
    /// This list is given by the Unicode Standard, Sec. 5.8, Recommendation R4 and Table
    /// 5-2.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder ReplaceLineEndings(this StringBuilder builder, string? replacementText)
        => builder is null ? throw new ArgumentNullException(nameof(builder))
                           : ReplaceLineEndings(builder, replacementText.AsSpan());

#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1

    private static StringBuilder ReplaceLineEndings(StringBuilder builder, ReadOnlySpan<char> replacement)
    {
        if (builder.Length == 0)
        {
            return builder;
        }

        using ArrayPoolHelper.SharedArray<char> source = ArrayPoolHelper.Rent<char>(builder.Length);
        builder.CopyTo(0, source.Array, 0, builder.Length);

        ReadOnlySpan<char> lineEndings = SearchValuesStorage.NEW_LINE_CHARS.AsSpan();
        ReadOnlySpan<char> inputSpan = source.Array.AsSpan(0, builder.Length);

        int firstIdx = inputSpan.IndexOfAny(lineEndings);

        if (firstIdx == -1)
        {
            return builder;
        }

        int lastIdx = inputSpan.LastIndexOfAny(lineEndings);
        ReadOnlySpan<char> processedSpan = inputSpan.Slice(firstIdx, lastIdx + 1 - firstIdx);

        int capacity = ComputeMaxReplaceLineEndingsCapacity(processedSpan.Length, replacement.Length);

        using ArrayPoolHelper.SharedArray<char> buf = ArrayPoolHelper.Rent<char>(capacity);
        int outLength = processedSpan.ReplaceLineEndings(replacement, buf.Array);

        if (!processedSpan.Equals(buf.Array.AsSpan(0, outLength), StringComparison.Ordinal))
        {
            builder.Length = firstIdx;
            builder.Append(buf.Array, 0, outLength);
            int startIdxOfRemaining = lastIdx + 1;
            builder.Append(source.Array, startIdxOfRemaining, inputSpan.Length - startIdxOfRemaining);
        }

        return builder;
    }

#else

    private static StringBuilder ReplaceLineEndings(StringBuilder input, ReadOnlySpan<char> replacement)
    {
        if (input.Length == 0)
        {
            return input;
        }

        using ArrayPoolHelper.SharedArray<char> buf =
            ArrayPoolHelper.Rent<char>(ComputeMaxReplaceLineEndingsCapacity(input.Length, replacement.Length));

        Span<char> outSpan = buf.Array.AsSpan();
        bool rFound = false;
        int outLength = 0;

        foreach (ReadOnlyMemory<char> chunk in input.GetChunks())
        {
            chunk.Span.ReplaceLineEndings(replacement, outSpan, ref rFound, ref outLength);
        }

        input.Length = 0;
        input.Append(outSpan.Slice(0, outLength));

        return input;
    }

#endif

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int ComputeMaxReplaceLineEndingsCapacity(int sourceLength, int replacementLength)
        => sourceLength * Math.Max(1, replacementLength);
}
