using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>Converts the entire content of a <see cref="StringBuilder" /> to uppercase
    /// letters using the rules of the invariant culture.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder ToUpperInvariant(this StringBuilder builder)
        => builder is null ? throw new ArgumentNullException(nameof(builder))
                           : ToUpperInvariantIntl(builder, 0, builder.Length);

    /// <summary>Converts the content of a <see cref="StringBuilder" /> starting with <paramref
    /// name="startIndex" /> into uppercase letters and uses the rules of the invariant culture.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="startIndex">The zero-based index in <paramref name="builder" /> at which
    /// the conversion starts.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="startIndex" /> is
    /// less than zero or greater than the number of characters in <paramref name="builder"
    /// />.</exception>
    public static StringBuilder ToUpperInvariant(this StringBuilder builder, int startIndex)
    {
        _ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        return (uint)startIndex > (uint)builder.Length
            ? throw new ArgumentOutOfRangeException(nameof(startIndex))
            : ToUpperInvariantIntl(builder, startIndex, builder.Length - startIndex);
    }

    /// <summary>Converts the content of a section in <see cref="StringBuilder" /> that begins
    /// at <paramref name="startIndex" /> and includes <paramref name="count" /> characters
    /// to uppercase using the rules of the invariant culture.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="startIndex">The zero-based index in <paramref name="builder" /> at which
    /// the conversion starts.</param>
    /// <param name="count">The number of characters to convert.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
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
    public static StringBuilder ToUpperInvariant(
        this StringBuilder builder, int startIndex, int count)
    {
        _ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        return (uint)startIndex > (uint)builder.Length
            ? throw new ArgumentOutOfRangeException(nameof(startIndex))
            : (uint)count > (uint)(builder.Length - startIndex)
                ? throw new ArgumentOutOfRangeException(nameof(count))
                : ToUpperInvariantIntl(builder, startIndex, count);
    }

    private static StringBuilder ToUpperInvariantIntl(StringBuilder builder, int startIndex, int count)
    {
        return count > SIMPLE_ALGORITHM_THRESHOLD
            ? ToUpperInvariantCopy(builder, startIndex, count)
            : ToUpperInvariantSimple(builder, startIndex, count);
    }

    private static StringBuilder ToUpperInvariantCopy(StringBuilder builder, int startIndex, int count)
    {
        int chunkLength = builder.Length - startIndex;
        using ArrayPoolHelper.SharedArray<char> shared = ArrayPoolHelper.Rent<char>(chunkLength);
        builder.CopyTo(startIndex, shared.Array, 0, chunkLength);
        _ = shared.Array.AsSpan(0, count).ToUpperInvariant();

        builder.Length = startIndex;
        return builder.Append(shared.Array, 0, chunkLength);
    }

#if NET462 || NETSTANDARD2_0 || NETSTANDARD2_1

    private static StringBuilder ToUpperInvariantSimple(StringBuilder builder, int startIndex, int count)
    {
        int length = startIndex + count;

        for (; startIndex < length; startIndex++)
        {
            builder[startIndex] = char.ToUpperInvariant(builder[startIndex]);
        }

        return builder;
    }

#else

    private static StringBuilder ToUpperInvariantSimple(StringBuilder builder, int startIndex, int count)
    {
        if (count == 0)
        {
            return builder;
        }

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
            ReadOnlySpan<char> span = chunk.Span.Slice(spanStart, evaluatedLength);

            for (int i = 0; i < span.Length; i++)
            {
                builder[i + startIndex] = char.ToUpperInvariant(span[i]);
            }

            if (evaluatedLength == count)
            {
                break;
            }

            chunkStart += chunk.Length;
            count -= evaluatedLength;
            startIndex = chunkStart;
        }

        return builder;
    }
#endif
}
