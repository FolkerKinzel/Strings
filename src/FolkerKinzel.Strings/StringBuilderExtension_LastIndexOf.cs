using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>Returns the zero-based index of the last occurrence of the specified character
    /// in <paramref name="builder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <returns>The zero-based index of the last occurence of <paramref name="value" />
    /// if that character is found, or -1 if it's not.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.
    /// </exception>
    public static int LastIndexOf(this StringBuilder builder, char value)
        => builder is null
                ? throw new ArgumentNullException(nameof(builder))
                : LastIndexOfIntl(builder, value);

    /// <summary>Returns the zero-based index of the last occurrence of the specified character
    /// in <paramref name="builder" />. The search begins at a specified character position
    /// and runs backwards to the beginning of the <see cref="StringBuilder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <param name="startIndex">The start index of the search. The search is done backwards
    /// to the beginning of <paramref name="builder" />.</param>
    /// <returns>The zero-based index of the last occurence of <paramref name="value" />
    /// if that character is found, or -1 if it's not.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="builder" /> is not
    /// empty and <paramref name="startIndex" /> is less than zero or greater than or equal
    /// to the length of <paramref name="builder" />.</exception>
    public static int LastIndexOf(this StringBuilder builder, char value, int startIndex)
        => builder is null
            ? throw new ArgumentNullException(nameof(builder))
            : builder.Length == 0
                ? -1
                : (uint)startIndex >= (uint)builder.Length
                    ? throw new ArgumentOutOfRangeException(nameof(startIndex))
                    : LastIndexOfIntl(builder, value, startIndex, startIndex + 1);

    /// <summary>Specifies the zero-based index of the last occurrence of the specified character
    /// in <paramref name="builder" />. The search begins at a specified index and runs backwards
    /// for a specified number of character positions to the beginning of the 
    /// <see cref="StringBuilder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <param name="startIndex">The start index of the search. The search is done backwards
    /// to the beginning of <paramref name="builder" />.</param>
    /// <param name="count">The number of character positions to examine.</param>
    /// <returns>If <paramref name="value" /> was found, the zero-based index position of
    /// its last occurrence within the section to be searched, otherwise -1.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="builder" /> is not empty and <paramref name="startIndex" /> is less
    /// than zero or greater than or equal to the length of <paramref name="builder" />
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="builder" /> is not empty and <paramref name="startIndex" /> - <paramref
    /// name="count" /> + 1 is less than zero.
    /// </para>
    /// </exception>
    public static int LastIndexOf(
        this StringBuilder builder, char value, int startIndex, int count)
    {
        _ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        return builder.Length == 0
            ? -1
            : (uint)startIndex >= (uint)builder.Length
                ? throw new ArgumentOutOfRangeException(nameof(startIndex))
                : (uint)count > (uint)startIndex + 1
                    ? throw new ArgumentOutOfRangeException(nameof(count))
                    : LastIndexOfIntl(builder, value, startIndex, count);
    }

#if NETSTANDARD2_1 || NETSTANDARD2_0 || NET461

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int LastIndexOfIntl(this StringBuilder builder, char value)
      => builder.Length == 0 
            ? -1 
            : LastIndexOfIntl(builder, value, builder.Length - 1, builder.Length);

    private static int LastIndexOfIntl(StringBuilder builder, char value, int startIndex, int count)
    {
        Debug.Assert(builder != null);

        return count > SIMPLE_ALGORITHM_THRESHOLD
            ? LastIndexOfCopy(builder, value, startIndex, count)
            : LastIndexOfSimple(builder, value, startIndex, count);
    }

    private static int LastIndexOfCopy(StringBuilder builder, char value, int startIndex, int count)
    {
        using ArrayPoolHelper.SharedArray<char> shared = ArrayPoolHelper.Rent<char>(count);
        builder.CopyTo(startIndex + 1 - count, shared.Array, 0, count);
        return shared.Array.AsSpan(0, count).LastIndexOf(value);
    }

    private static int LastIndexOfSimple(StringBuilder builder, char value, int startIndex, int count)
    {
        int lastSearchIndex = startIndex + 1 - count;

        for (int i = startIndex; i >= lastSearchIndex; i--)
        {
            if (value == builder[i])
            {
                return i;
            }
        }

        return -1;
    }

#else

    private static int LastIndexOfIntl(StringBuilder builder, char value)
    {
        int pos = builder.Length - 1;

        while (TryGetChunk(builder, pos, out int chunkStart, out ReadOnlySpan<char> span))
        {
            int idx = span.LastIndexOf(value);

            if (idx != -1)
            {
                return chunkStart + idx;
            }

            pos = chunkStart - 1;
        }

        return -1;
    }


    private static int LastIndexOfIntl(StringBuilder builder, char value, int startIndex, int count)
    {
        while (TryGetChunk(builder, startIndex, out int chunkStart, out ReadOnlySpan<char> span))
        {
            int evaluatedLength = startIndex + 1 - chunkStart;
            span = span.Slice(0, evaluatedLength);
            int idx = span.LastIndexOf(value);

            if (evaluatedLength >= count)
            {
                return idx == -1 ? -1 : chunkStart + idx;
            }

            if (idx != -1)
            {
                return chunkStart + idx;
            }

            startIndex -= evaluatedLength;
            count -= evaluatedLength;
        }

        return -1;
    }


    private static bool TryGetChunk(StringBuilder builder, int index, out int chunkStartIndex, out ReadOnlySpan<char> span)
    {
        chunkStartIndex = 0;

        if (index < 0)
        {
            span = default;
            return false;
        }

        foreach (ReadOnlyMemory<char> chunk in builder.GetChunks())
        {
            if (index < chunkStartIndex + chunk.Length)
            {
                span = chunk.Span;
                return true;
            }

            chunkStartIndex += chunk.Length;
        }

        span = default;
        return false;
    }

#endif
}
