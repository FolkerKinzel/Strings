using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

#if NET461 || NETSTANDARD2_0

public static partial class StringBuilderPolyfillExtension
{
    /// <summary>Concatenates the <see cref="string"/>s of the provided array, using the specified 
    /// <see cref="char"/> separator between each <see cref="string"/>, then appends the result to 
    /// <paramref name="builder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to which the characters are
    /// appended.</param>
    /// <param name="separator">The character to use as a separator. <paramref name="separator"
    /// /> is included in the joined strings only if <paramref name="values" /> has more
    /// than one element.</param>
    /// <param name="values">An array that contains the strings to concatenate and append
    /// to <paramref name="builder" />.</param>
    /// <returns>A reference to <paramref name="builder" /> after the append operation has
    /// completed.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentNullException"> <paramref name="values" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendJoin(
        this StringBuilder builder, char separator, params string?[] values)
        => builder.AppendJoin(stackalloc char[] { separator }, values);

    /// <summary>Concatenates the string representations of the elements in the provided
    /// array of objects, using the specified separator character between each member, then
    /// appends the result to <paramref name="builder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to which the characters are
    /// appended.</param>
    /// <param name="separator">The character to use as a separator. <paramref name="separator"
    /// /> is included in the joined strings only if <paramref name="values" /> has more
    /// than one element.</param>
    /// <param name="values">An array that contains the objects whose string representations
    /// have to be concatenated and appended to <paramref name="builder" />.</param>
    /// <returns>A reference to <paramref name="builder" /> after the append operation has
    /// completed.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentNullException"> <paramref name="values" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendJoin(
        this StringBuilder builder, char separator, params object?[] values)
        => builder.AppendJoin(stackalloc char[] { separator }, values);

    /// <summary>Concatenates the string representations of the elements in the provided
    /// collection, using the specified separator character between each member, then appends
    /// the result to <paramref name="builder" />.</summary>
    /// <typeparam name="T">The type of the members of <paramref name="values" />.</typeparam>
    /// <param name="builder">The <see cref="StringBuilder" /> to which the characters are
    /// appended.</param>
    /// <param name="separator">The character to use as a separator. <paramref name="separator"
    /// /> is included in the joined strings only if <paramref name="values" /> has more
    /// than one element.</param>
    /// <param name="values">A collection that contains the objects whose string representations
    /// have to be concatenated and appended to <paramref name="builder" />.</param>
    /// <returns>A reference to <paramref name="builder" /> after the append operation has
    /// completed.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentNullException"> <paramref name="values" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendJoin<T>(
        this StringBuilder builder, char separator, IEnumerable<T> values)
        => builder.AppendJoin(stackalloc char[] { separator }, values);

    /// <summary>Concatenates the <see cref="string"/>s in the provided array of objects, 
    /// using the specified separator between each member, then appends the result to 
    /// <paramref name="builder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to which the characters are
    /// appended.</param>
    /// <param name="separator">The string to use as a separator. <paramref name="separator"
    /// /> is included in the joined strings only if <paramref name="values" /> has more
    /// than one element.</param>
    /// <param name="values">An array that contains the strings to concatenate and append
    /// to <paramref name="builder" />.</param>
    /// <returns>A reference to <paramref name="builder" /> after the append operation has
    /// completed.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentNullException"> <paramref name="values" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendJoin(
        this StringBuilder builder, string? separator, params string?[] values)
        => builder.AppendJoin(separator.AsSpan(), values);

    /// <summary>Concatenates the string representations of the elements in the provided
    /// array of objects, using the specified separator between each member, then appends
    /// the result to <paramref name="builder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to which the characters are
    /// appended.</param>
    /// <param name="separator">The string to use as a separator. <paramref name="separator"
    /// /> is included in the joined strings only if <paramref name="values" /> has more
    /// than one element.</param>
    /// <param name="values">An array that contains the objects whose string representations
    /// have to be concatenated and appended to <paramref name="builder" />.</param>
    /// <returns>A reference to <paramref name="builder" /> after the append operation has
    /// completed.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentNullException"> <paramref name="values" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendJoin(
        this StringBuilder builder, string? separator, params object?[] values)
        => builder.AppendJoin(separator.AsSpan(), values);

    /// <summary>Concatenates the string representations of the elements in the provided
    /// collection, using the specified separator between each member, then appends the result
    /// to <paramref name="builder" />.</summary>
    /// <typeparam name="T">The type of the members of <paramref name="values" />.</typeparam>
    /// <param name="builder">The <see cref="StringBuilder" /> to which the characters are
    /// appended.</param>
    /// <param name="separator">The string to use as a separator. <paramref name="separator"
    /// /> is included in the joined strings only if <paramref name="values" /> has more
    /// than one element.</param>
    /// <param name="values">A collection that contains the objects whose string representations
    /// have to be concatenated and appended to <paramref name="builder" />.</param>
    /// <returns>A reference to <paramref name="builder" /> after the append operation has
    /// completed.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentNullException"> <paramref name="values" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendJoin<T>(
        this StringBuilder builder, string? separator, IEnumerable<T> values)
        => builder.AppendJoin(separator.AsSpan(), values);

    private static StringBuilder AppendJoin<T>(
        this StringBuilder builder, ReadOnlySpan<char> separator, IEnumerable<T> values)
    {
        _NullReferenceException.ThrowIfNull(builder, nameof(builder));
        _ArgumentNullException.ThrowIfNull(values, nameof(values));

        using (IEnumerator<T> en = values.GetEnumerator())
        {
            if (!en.MoveNext())
            {
                return builder;
            }

            T value = en.Current;
            _ = builder.Append(value?.ToString());

            while (en.MoveNext())
            {
                _ = builder.Append(separator);
                value = en.Current;
                _ = builder.Append(value?.ToString());
            }
        }
        return builder;
    }
}

#endif
