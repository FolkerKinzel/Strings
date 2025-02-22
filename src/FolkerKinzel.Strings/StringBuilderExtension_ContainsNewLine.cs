using FolkerKinzel.Helpers.Polyfills;
using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>Indicates whether the <see cref="StringBuilder" /> contains a newline character.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <returns> <c>true</c> if <paramref name="builder" /> contains a newline character,
    /// otherwise <c>false</c>.</returns>
    /// <remarks> <see cref="CharExtension.IsNewLine(char)" /> is used to identify newline
    /// characters.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static bool ContainsNewLine(this StringBuilder builder)
        => builder is null
                ? throw new ArgumentNullException(nameof(builder))
                : ContainsNewLineIntl(builder);

    /// <summary>Examines a section of the <see cref="StringBuilder" /> that begins at <paramref
    /// name="startIndex" /> to see whether it contains a newline character.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <param name="startIndex">The zero-based index in <paramref name="builder" /> at which
    /// the examination begins.</param>
    /// <returns> <c>true</c> if the specified section in <paramref name="builder" /> contains
    /// a newline character, otherwise <c>false</c>.</returns>
    /// <remarks> <see cref="CharExtension.IsNewLine(char)" /> is used to identify newline
    /// characters.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="startIndex" /> is
    /// less than zero or greater than the number of characters in <paramref name="builder"
    /// />.</exception>
    public static bool ContainsNewLine(this StringBuilder builder, int startIndex)
    {
        _ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        return (uint)startIndex > (uint)builder.Length
            ? throw new ArgumentOutOfRangeException(nameof(startIndex))
            : ContainsNewLineIntl(builder, startIndex, builder.Length - startIndex);
    }

    /// <summary>Examines a section of the <see cref="StringBuilder" /> that begins at <paramref
    /// name="startIndex" /> and includes <paramref name="count" /> characters to determine
    /// whether this section contains a newline character.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <param name="startIndex">The zero-based index in <paramref name="builder" /> at which
    /// the examination begins.</param>
    /// <param name="count">The number of character positions to examine.</param>
    /// <returns> <c>true</c> if the specified section in <paramref name="builder" /> contains
    /// a newline character, otherwise <c>false</c>.</returns>
    /// <remarks> <see cref="CharExtension.IsNewLine(char)" /> is used to identify newline
    /// characters.</remarks>
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
    public static bool ContainsNewLine(this StringBuilder builder, int startIndex, int count)
    {
        _ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        return (uint)startIndex > (uint)builder.Length
            ? throw new ArgumentOutOfRangeException(nameof(startIndex))
            : (uint)count > (uint)(builder.Length - startIndex)
                ? throw new ArgumentOutOfRangeException(nameof(count))
                : ContainsNewLineIntl(builder, startIndex, count);
    }

#if NET462 || NETSTANDARD2_0 || NETSTANDARD2_1

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool ContainsNewLineIntl(StringBuilder builder)
      => ContainsNewLineIntl(builder, 0, builder.Length);

    private static bool ContainsNewLineIntl(StringBuilder builder, int startIndex, int count)
    {
        return count > SIMPLE_ALGORITHM_THRESHOLD
            ? ContainsNewLineCopy(builder, startIndex, count)
            : ContainsNewLineSimple(builder, startIndex, count);
    }

    private static bool ContainsNewLineCopy(StringBuilder builder, int startIndex, int count)
    {
        using ArrayPoolHelper.SharedArray<char> shared = ArrayPoolHelper.Rent<char>(count);
        builder.CopyTo(startIndex, shared.Array, 0, count);
        return shared.Array.AsSpan(0, count).ContainsNewLine();
    }

    private static bool ContainsNewLineSimple(StringBuilder builder, int startIndex, int count)
    {
        int length = startIndex + count;

        for (; startIndex < length; startIndex++)
        {
            if (builder[startIndex].IsNewLine())
            {
                return true;
            }
        }

        return false;
    }

#else

    private static bool ContainsNewLineIntl(StringBuilder builder)
    {
        foreach (ReadOnlyMemory<char> chunk in builder.GetChunks())
        {
            if (chunk.Span.ContainsNewLine())
            {
                return true;
            }
        }

        return false;
    }

    private static bool ContainsNewLineIntl(StringBuilder builder, int startIndex, int count)
    {
        int chunkStart = 0;

        foreach (ReadOnlyMemory<char> chunk in builder.GetChunks())
        {
            if (startIndex >= chunk.Length + chunkStart)
            {
                chunkStart += chunk.Length;
                continue;
            }

            int spanStart = startIndex - chunkStart;
            int evaluatedLength = Math.Min(chunk.Length - spanStart, count);

            if (chunk.Span.Slice(spanStart, evaluatedLength).ContainsNewLine())
            {
                return true;
            }

            if (evaluatedLength == count)
            {
                break;
            }

            chunkStart += chunk.Length;
            count -= evaluatedLength;
            startIndex = chunkStart;
        }

        return false;
    }

#endif
}
