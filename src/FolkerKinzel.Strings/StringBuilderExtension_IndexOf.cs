using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>Specifies the zero-based index of the first occurrence of the specified
    /// character in <paramref name="builder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <returns>The zero-based index position of <paramref name="value" /> from the beginning
    /// of the <see cref="StringBuilder" />, if this character was found, otherwise -1.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static int IndexOf(this StringBuilder builder, char value)
        => builder is null
                ? throw new ArgumentNullException(nameof(builder))
                : IndexOfIntl(builder, value);

    /// <summary>Returns the zero-based index of the first occurrence of the specified character
    /// in <paramref name="builder" />. The search starts at the specified index.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <param name="startIndex">The start index of the search.</param>
    /// <returns>The zero-based index position of <paramref name="value" /> from the beginning
    /// of the <see cref="StringBuilder" />, if this character was found, otherwise -1.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="startIndex" /> is
    /// less than zero or greater than the number of characters in <paramref name="builder"
    /// />.</exception>
    public static int IndexOf(this StringBuilder builder, char value, int startIndex)
    {
        _ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        return startIndex < 0 || startIndex > builder.Length
            ? throw new ArgumentOutOfRangeException(nameof(startIndex))
            : IndexOfIntl(builder, value, startIndex, builder.Length - startIndex);
    }

    /// <summary>Returns the zero-based index of the first occurrence of the specified character
    /// in <paramref name="builder" />. The search begins at a specified index and a specified
    /// number of character positions are checked.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <param name="startIndex">The start index of the search.</param>
    /// <param name="count">The number of character positions to examine.</param>
    /// <returns>The zero-based index position of <paramref name="value" /> from the beginning
    /// of the <see cref="StringBuilder" />, if this character was found, otherwise -1.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
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
    public static int IndexOf(this StringBuilder builder, char value, int startIndex, int count)
    {
        _ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        if (startIndex < 0 || startIndex > builder.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex));
        }

        if (count < 0 || (count += startIndex) > builder.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        return IndexOfIntl(builder, value, startIndex, builder.Length - startIndex);
    }

#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int IndexOfIntl(this StringBuilder builder, char value)
      => IndexOfIntl(builder, value, 0, builder.Length);

    private static int IndexOfIntl(StringBuilder builder, char value, int startIndex, int count)
    {
        Debug.Assert(builder != null);

        return count > SIMPLE_ALGORITHM_THRESHOLD
            ? IndexOfCopy(builder, value, startIndex, count)
            : IndexOfSimple(builder, value, startIndex, count);
    }

    private static int IndexOfCopy(StringBuilder sb, char c, int startIndex, int count)
    {
        using ArrayPoolHelper.SharedArray<char> shared = ArrayPoolHelper.Rent<char>(count);
        sb.CopyTo(startIndex, shared.Array, 0, count);
        return shared.Array.AsSpan(0, count).IndexOf(c);
    }

    private static int IndexOfSimple(StringBuilder builder, char value, int startIndex, int count)
    {
        for (int i = startIndex; i < count; ++i)
        {
            if (value == builder[i])
            {
                return i;
            }
        }

        return -1;
    }

#else

    private static int IndexOfIntl(StringBuilder builder, char value)
    {
        Debug.Assert(builder != null);

        int pos = 0;

        foreach (ReadOnlyMemory<char> chunk in builder.GetChunks())
        {
            ReadOnlySpan<char> span = chunk.Span;
            int i = span.IndexOf(value);

            if (i != -1)
            {
                return pos + i;
            }

            pos += span.Length;
        }

        return -1;
    }

    private static int IndexOfIntl(StringBuilder sb, char c, int startIndex, int count)
    {
        int pos = 0;

        foreach (ReadOnlyMemory<char> chunk in sb.GetChunks())
        {
            if (startIndex >= chunk.Length + pos)
            {
                pos += chunk.Length;
                continue;
            }

            int spanStart = startIndex - pos;
            int evaluatedLength = chunk.Length - spanStart;
            ReadOnlySpan<char> span = chunk.Span;
            int idx;

            if (evaluatedLength >= count)
            {
                span = span.Slice(spanStart, count);
                idx = span.IndexOf(c);
                return idx == -1 ? -1 : pos + idx;
            }

            span = span.Slice(spanStart);

            idx = span.IndexOf(c);

            if (idx != -1)
            {
                return pos + idx;
            }

            pos += chunk.Length;
            count -= evaluatedLength;
            startIndex = pos;
        }

        return -1;
    }

#endif

}
