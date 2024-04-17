using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

/// <summary>Extension methods for the <see cref="StringBuilder" /> class, which are
/// used in .NET Framework 4.5 and .NET Standard 2.0 as polyfills for methods from current
/// .NET versions.</summary>
/// <remarks>The methods of this class should only be used in the extension method syntax
/// to simulate the original methods of the <see cref="string" /> class, which exist
/// in more modern frameworks. To match the behavior of the original methods, these extension
/// methods throw a <see cref="NullReferenceException" /> when called on <c>null</c>.</remarks>
public static class StringBuilderPolyfillExtension
{
    // Place this preprocessor directive inside the class to let .NET Core 3.1 and above have an empty class!
#if NET461 || NETSTANDARD2_0

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
        if (builder is null)
        {
            throw new NullReferenceException();
        }

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

    /// <summary>Appends a copy of a sequence of Unicode characters that comes from a <see
    /// cref="StringBuilder" /> to the existing content of <paramref name="builder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    /// <param name="value">The <see cref="StringBuilder" /> from which the characters are
    /// copied.</param>
    /// <param name="startIndex">The zero-based index in <paramref name="value" /> at which
    /// the copy operation starts.</param>
    /// <param name="count">The number of Unicode characters to copy.</param>
    /// <returns>A reference to <paramref name="builder" />.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="startIndex" /> or <paramref name="count" /> are smaller than zero
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="startIndex" /> + <paramref name="count" /> is larger than the number
    /// of characters in <paramref name="value" />.
    /// </para>
    /// </exception>
    /// <exception cref="ArgumentNullException"> <paramref name="value" /> is <c>null</c>
    /// and the values of <paramref name="startIndex" /> or <paramref name="count" /> are
    /// greater than zero.</exception>
    public static StringBuilder Append(
        this StringBuilder builder, StringBuilder? value, int startIndex, int count)
    {
        if (builder is null)
        {
            throw new NullReferenceException();
        }

        if (startIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex));
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        if (value is null)
        {
            return startIndex == 0 &&
                   count == 0 ? builder
                              : throw new ArgumentNullException(nameof(value));
        }

        if (count == 0)
        {
            return builder;
        }

        int length = startIndex + count;
        if (length > value.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        _ = builder.EnsureCapacity(builder.Length + count);


        for (int i = startIndex; i < length; i++)
        {
            _ = builder.Append(value[i]);
        }

        return builder;
    }

    /// <summary>Appends the string representation of a specified read-only character span
    /// to a <see cref="StringBuilder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to which the characters are
    /// appended.</param>
    /// <param name="value">The read-only character span to append.</param>
    /// <returns>A reference to <paramref name="builder" /> after the append operation has
    /// completed.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Increasing the capacity of <paramref
    /// name="builder" /> would exceed <see cref="StringBuilder.MaxCapacity" />.</exception>
    public static StringBuilder Append(this StringBuilder builder, ReadOnlySpan<char> value)
    {
        if (builder is null)
        {
            throw new NullReferenceException();
        }

        _ = builder.EnsureCapacity(builder.Length + value.Length);

        for (int i = 0; i < value.Length; i++)
        {
            _ = builder.Append(value[i]);
        }
        return builder;
    }

    /// <summary>Inserts the content of a read-only character span at the specified index
    /// position into <paramref name="builder" />.</summary>
    /// <param name="builder">The <see cref="StringBuilder" /> into which the characters
    /// are inserted.</param>
    /// <param name="index">The zero-based index in <paramref name="builder" /> at which
    /// the characters are inserted.</param>
    /// <param name="value">The character span to insert.</param>
    /// <returns>A reference to <paramref name="builder" /> after the insert operation is
    /// completed.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="builder" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="index" /> is less
    /// than zero or greater than the number of characters in <paramref name="builder" />.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder Insert(
        this StringBuilder builder, int index, ReadOnlySpan<char> value)
        => builder.Insert(index, value.ToString());

    // Don't call StringBuilder.Insert(int, char) multiple times here because StringBuilder will allocate new
    // memory with each call

#endif

}
