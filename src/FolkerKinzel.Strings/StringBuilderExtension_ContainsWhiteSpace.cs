using FolkerKinzel.Helpers.Polyfills;
using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>Indicates whether the <see cref="StringBuilder" /> contains white space.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <returns> <c>true</c> if <paramref name="builder" /> contains white space, otherwise
    /// <c>false</c>.</returns>
    /// <remarks> <see cref="char.IsWhiteSpace(char)" /> is used to identify white space.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static bool ContainsWhiteSpace(this StringBuilder builder)
        => builder is null
                ? throw new ArgumentNullException(nameof(builder))
                : ContainsWhiteSpaceIntl(builder);

    /// <summary>Examines a section of the <see cref="StringBuilder" /> that begins at <paramref
    /// name="startIndex" /> to see whether it contains white space.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <param name="startIndex">The zero-based index in <paramref name="builder" /> at which
    /// the examination begins.</param>
    /// <returns> <c>true</c> if the specified section in <paramref name="builder" /> contains
    /// white space, otherwise <c>false</c>.</returns>
    /// <remarks> <see cref="char.IsWhiteSpace(char)" /> is used to identify white space.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="startIndex" /> is
    /// less than zero or greater than the number of characters in 
    /// <paramref name="builder" />.</exception>
    public static bool ContainsWhiteSpace(this StringBuilder builder, int startIndex)
    {
        _ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        return (uint)startIndex > (uint)builder.Length
            ? throw new ArgumentOutOfRangeException(nameof(startIndex))
            : builder.ContainsWhiteSpace(startIndex, builder.Length - startIndex);
    }

    /// <summary>Examines a section of the <see cref="StringBuilder" /> that begins at <paramref
    /// name="startIndex" /> and includes <paramref name="count" /> characters to determine
    /// whether this section contains white space.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to search.</param>
    /// <param name="startIndex">The zero-based index in <paramref name="builder" /> at which
    /// the examination begins.</param>
    /// <param name="count">The number of character positions to examine.</param>
    /// <returns> <c>true</c> if the specified section in <paramref name="builder" /> contains
    /// white space, otherwise <c>false</c>.</returns>
    /// <remarks> <see cref="char.IsWhiteSpace(char)" /> is used to identify white space.</remarks>
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
    public static bool ContainsWhiteSpace(this StringBuilder builder, int startIndex, int count)
    {
        _ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        return (uint)startIndex > (uint)builder.Length
            ? throw new ArgumentOutOfRangeException(nameof(startIndex))
            : (uint)count > (uint)(builder.Length - startIndex)
                ? throw new ArgumentOutOfRangeException(nameof(count))
                : ContainsWhiteSpaceIntl(builder, startIndex, count);
    }

#if NETSTANDARD2_1 || NETSTANDARD2_0 || NET462

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool ContainsWhiteSpaceIntl(StringBuilder builder)
        => ContainsWhiteSpaceIntl(builder, 0, builder.Length);

    private static bool ContainsWhiteSpaceIntl(StringBuilder builder, int startIndex, int count)
    {
        return count > SIMPLE_ALGORITHM_THRESHOLD
            ? ContainsWhiteSpaceCopy(builder, startIndex, count)
            : ContainsWhiteSpaceSimple(builder, startIndex, count);
    }

    private static bool ContainsWhiteSpaceCopy(StringBuilder builder, int startIndex, int count)
    {
        using ArrayPoolHelper.SharedArray<char> shared = ArrayPoolHelper.Rent<char>(count);
        builder.CopyTo(startIndex, shared.Array, 0, count);
        return shared.Array.AsSpan(0, count).ContainsWhiteSpace();
    }

    private static bool ContainsWhiteSpaceSimple(StringBuilder builder, int startIndex, int count)
    {
        int length = startIndex + count;

        for (; startIndex < length; startIndex++)
        {
            if (char.IsWhiteSpace(builder[startIndex]))
            {
                return true;
            }
        }

        return false;
    }
#else
    private static bool ContainsWhiteSpaceIntl(StringBuilder builder)
    {
        foreach (ReadOnlyMemory<char> chunk in builder.GetChunks())
        {
            if (chunk.Span.ContainsWhiteSpace())
            {
                return true;
            }
        }

        return false;
    }

    private static bool ContainsWhiteSpaceIntl(StringBuilder builder, int startIndex, int count)
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

            if (chunk.Span.Slice(spanStart, evaluatedLength).ContainsWhiteSpace())
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
