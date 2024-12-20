using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

/// <summary>Simulates static methods of the <see cref="string" /> class for .NET versions
/// in which they are not available, and forwards the method calls in .NET versions in
/// which the methods are available directly to the BCL methods.</summary>
public static class StaticStringMethod
{
    /// <summary>Creates a new <see cref="string"/> with a specified length and, once created, 
    /// initializes it using the specified callback.</summary>
    /// <typeparam name="TState">The type of the element to be passed to <paramref name="action"
    /// />.</typeparam>
    /// <param name="length">The length of the <see cref="string" /> to be created.</param>
    /// <param name="state">The element to be passed to <paramref name="action" />.</param>
    /// <param name="action">A callback to initialize the string.</param>
    /// <returns>The <see cref="string" /> created.</returns>
    /// <remarks>The method simulates the static method String.Create&lt;TState&gt;(int,
    /// TState, SpanAction&lt;char,TState&gt;). In newer .NET versions, the call is forwarded
    /// directly to the existing method of the <see cref="string" /> class. In .NET Framework
    /// and .NET Standard 2.0, the simulation makes it possible, when creating short <see
    /// cref="string" />s, to have only one heap allocation.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="action" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="length" /> is negative.</exception>
#if NET462 || NETSTANDARD2_0
    public static string Create<TState>(int length, TState state, SpanAction<char, TState> action)
    {
        _ArgumentNullException.ThrowIfNull(action, nameof(action));

        if (length <= 0)
        {
            return length == 0 ? string.Empty : throw new ArgumentOutOfRangeException(nameof(length));
        }

        if (length > Const.StackallocCharThreshold)
        {
            using ArrayPoolHelper.SharedArray<char> shared = ArrayPoolHelper.Rent<char>(length);
            Span<char> span = shared.Array.AsSpan(0, length);
            action(span, state);
            return span.ToString();
        }
        else
        {
            Span<char> span = stackalloc char[length];
            action(span, state);
            return span.ToString();
        }
    }
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Create<TState>(int length, TState state, SpanAction<char, TState> action)
        => string.Create(length, state, action);
#endif

    /// <summary>
    /// Concatenates the items of a read-only span of read-only character
    /// memory regions to a <see cref="string"/>.
    /// </summary>
    /// <param name="values">The read-only character
    /// memory regions to concatenate.</param>
    /// <returns>The characters in <paramref name="values"/> concatenated to 
    /// a <see cref="string"/>.</returns>
    public static string Concat(ReadOnlySpan<ReadOnlyMemory<char>> values)
    {
        if (values.Length == 1)
        {
            return values[0].ToString();
        }

        int length = 0;

        for (int i = 0; i < values.Length; i++)
        {
            length += values[i].Length;
        }

        if (length == 0)
        {
            return string.Empty;
        }

        if (length > Const.StackallocCharThreshold)
        {
            using ArrayPoolHelper.SharedArray<char> buf = ArrayPoolHelper.Rent<char>(length);
            Span<char> bufSpan = buf.Array.AsSpan();
            FillBuf(values, bufSpan);
            return new string(buf.Array, 0, length);
        }
        else
        {
            Span<char> bufSpan = stackalloc char[length];
            FillBuf(values, bufSpan);
            return bufSpan.ToString();
        }

        /////////////////////////////////////////////////////////

        static void FillBuf(ReadOnlySpan<ReadOnlyMemory<char>> values, Span<char> bufSpan)
        {
            for (int i = 0; i < values.Length; i++)
            {
                ReadOnlySpan<char> span = values[i].Span;
                span.CopyTo(bufSpan);
                bufSpan = bufSpan.Slice(span.Length);
            }
        }
    }

#if NETCOREAPP3_1_OR_GREATER

    /// <summary>Concatenates the string representations of four specified read-only character
    /// spans.</summary>
    /// <param name="str0">The first read-only character span to concatenate.</param>
    /// <param name="str1">The first read-only character span to concatenate.</param>
    /// <param name="str2">The third read-only character span to concatenate.</param>
    /// <param name="str3">The fourth read-only character span to concatenate.</param>
    /// <returns>The concatenated string representations of the values of <paramref name="str0"
    /// />, <paramref name="str1" />, <paramref name="str2" /> and <paramref name="str3"
    /// />.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Concat(ReadOnlySpan<char> str0, ReadOnlySpan<char> str1, ReadOnlySpan<char> str2, ReadOnlySpan<char> str3)
        => string.Concat(str0, str1, str2, str3);

    /// <summary>Concatenates the string representations of three specified read-only character
    /// spans.</summary>
    /// <param name="str0">The first read-only character span to concatenate.</param>
    /// <param name="str1">The first read-only character span to concatenate.</param>
    /// <param name="str2">The third read-only character span to concatenate.</param>
    /// <returns>The concatenated string representations of the values of <paramref name="str0"
    /// />, <paramref name="str1" /> and <paramref name="str2" />.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Concat(ReadOnlySpan<char> str0, ReadOnlySpan<char> str1, ReadOnlySpan<char> str2)
        => string.Concat(str0, str1, str2);

    /// <summary>Concatenates the string representations of two specified read-only character
    /// spans.</summary>
    /// <param name="str0">The first read-only character span to concatenate.</param>
    /// <param name="str1">The first read-only character span to concatenate.</param>
    /// <returns>The concatenated string representations of the values of <paramref name="str0"
    /// /> and <paramref name="str1" />.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Concat(ReadOnlySpan<char> str0, ReadOnlySpan<char> str1)
        => string.Concat(str0, str1);

#else

    /// <summary>Concatenates the string representations of four specified read-only character
    /// spans.</summary>
    /// <param name="str0">The first read-only character span to concatenate.</param>
    /// <param name="str1">The first read-only character span to concatenate.</param>
    /// <param name="str2">The third read-only character span to concatenate.</param>
    /// <param name="str3">The fourth read-only character span to concatenate.</param>
    /// <returns>The concatenated string representations of the values of <paramref name="str0"
    /// />, <paramref name="str1" />, <paramref name="str2" /> and <paramref name="str3"
    /// />.</returns>
    public static string Concat(ReadOnlySpan<char> str0, ReadOnlySpan<char> str1, ReadOnlySpan<char> str2, ReadOnlySpan<char> str3)
    {
        if (str0.Length == 0)
        {
            return Concat(str1, str2, str3);
        }

        int length = str0.Length + str1.Length + str2.Length + str3.Length;

        if (length == str0.Length)
        {
            return str0.ToString();
        }

        if (length > Const.StackallocCharThreshold)
        {
            using ArrayPoolHelper.SharedArray<char> shared = ArrayPoolHelper.Rent<char>(length);
            return DoConcat(shared.Array.AsSpan(0, length), str0, str1, str2, str3);
        }
        else
        {
            return DoConcat(stackalloc char[length], str0, str1, str2, str3);
        }

        static string DoConcat(Span<char> span, ReadOnlySpan<char> str0, ReadOnlySpan<char> str1, ReadOnlySpan<char> str2, ReadOnlySpan<char> str3)
        {
            str0.CopyTo(span);
            Span<char> spanPart = span.Slice(str0.Length);
            str1.CopyTo(spanPart);
            spanPart = spanPart.Slice(str1.Length);
            str2.CopyTo(spanPart);
            spanPart = spanPart.Slice(str2.Length);
            str3.CopyTo(spanPart);

            return span.ToString();
        }
    }

    /// <summary>Concatenates the string representations of three specified read-only character
    /// spans.</summary>
    /// <param name="str0">The first read-only character span to concatenate.</param>
    /// <param name="str1">The first read-only character span to concatenate.</param>
    /// <param name="str2">The third read-only character span to concatenate.</param>
    /// <returns>The concatenated string representations of the values of <paramref name="str0"
    /// />, <paramref name="str1" /> and <paramref name="str2" />.</returns>
    public static string Concat(ReadOnlySpan<char> str0, ReadOnlySpan<char> str1, ReadOnlySpan<char> str2)
    {
        if (str0.Length == 0)
        {
            return Concat(str1, str2);
        }

        int length = str0.Length + str1.Length + str2.Length;

        if (length == str0.Length)
        {
            return str0.ToString();
        }

        if (length > Const.StackallocCharThreshold)
        {
            using ArrayPoolHelper.SharedArray<char> shared = ArrayPoolHelper.Rent<char>(length);
            return DoConcat(shared.Array.AsSpan(0, length), str0, str1, str2);
        }
        else
        {
            return DoConcat(stackalloc char[length], str0, str1, str2);
        }

        static string DoConcat(Span<char> span, ReadOnlySpan<char> str0, ReadOnlySpan<char> str1, ReadOnlySpan<char> str2)
        {
            str0.CopyTo(span);
            Span<char> spanPart = span.Slice(str0.Length);
            str1.CopyTo(spanPart);
            spanPart = spanPart.Slice(str1.Length);
            str2.CopyTo(spanPart);

            return span.ToString();
        }
    }

    /// <summary>Concatenates the string representations of two specified read-only character
    /// spans.</summary>
    /// <param name="str0">The first read-only character span to concatenate.</param>
    /// <param name="str1">The first read-only character span to concatenate.</param>
    /// <returns>The concatenated string representations of the values of <paramref name="str0"
    /// /> and <paramref name="str1" />.</returns>
    public static string Concat(ReadOnlySpan<char> str0, ReadOnlySpan<char> str1)
    {
        int length = str0.Length + str1.Length;

        if (length > Const.StackallocCharThreshold)
        {
            if (length == str0.Length)
            {
                return str0.ToString();
            }

            if (length == str1.Length)
            {
                return str1.ToString();
            }

            using ArrayPoolHelper.SharedArray<char> shared = ArrayPoolHelper.Rent<char>(length);
            return DoConcat(shared.Array.AsSpan(0, length), str0, str1);
        }
        else
        {
            return length == 0
                ? string.Empty
                : length == str0.Length
                    ? str0.ToString()
                    : length == str1.Length
                        ? str1.ToString()
                        : DoConcat(stackalloc char[length], str0, str1);
        }

        static string DoConcat(Span<char> span, ReadOnlySpan<char> str0, ReadOnlySpan<char> str1)
        {
            str0.CopyTo(span);
            Span<char> spanPart = span.Slice(str0.Length);
            str1.CopyTo(spanPart);

            return span.ToString();
        }
    }

#endif
}
