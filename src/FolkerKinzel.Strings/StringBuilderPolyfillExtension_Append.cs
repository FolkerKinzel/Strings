using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

/// <summary>Extension methods for the <see cref="StringBuilder" /> class, which are
/// used in .NET Framework 4.5 and .NET Standard 2.0 as polyfills for methods from current
/// .NET versions.</summary>
/// <remarks>The methods of this class should only be used in the extension method syntax
/// to simulate the original methods of the <see cref="string" /> class, which exist
/// in more modern frameworks. To match the behavior of the original methods, these extension
/// methods throw a <see cref="NullReferenceException" /> when called on <c>null</c>.</remarks>
public static partial class StringBuilderPolyfillExtension
{
    // Place this preprocessor directive inside the class to let .NET Core 3.1 and above have an empty class!
#if NET461 || NETSTANDARD2_0

    // This doesn't bind! StringBuilder.Append(object?) is called instead:

    ///// <summary>
    ///// Appends a copy of a sequence of Unicode characters that comes from a <see
    ///// cref="StringBuilder" />
    ///// to the existing content of <paramref name="builder" />..
    ///// </summary>
    ///// <param name="builder">The <see cref="StringBuilder" /> whose content is changed.</param>
    ///// <param name="value">The <see cref="StringBuilder"/> to append.</param>
    ///// <returns>A reference to <paramref name="builder" />.</returns>
    //public static StringBuilder Append (this StringBuilder builder, StringBuilder? value)
    //    => value is null ? builder ?? throw new NullReferenceException(nameof(builder))
    //                     : builder.Append(value, 0, value.Length);

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
        _NullReferenceException.ThrowIfNull(builder, nameof(builder));

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
        _NullReferenceException.ThrowIfNull(builder, nameof(builder));

        _ = builder.EnsureCapacity(builder.Length + value.Length);

        for (int i = 0; i < value.Length; i++)
        {
            _ = builder.Append(value[i]);
        }
        return builder;
    }

#endif

#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1

    /// <summary>
    /// Appends the string representation of a specified read-only character memory region to 
    /// a <see cref="StringBuilder" />.
    /// </summary>
    /// <param name="builder">The <see cref="StringBuilder" /> to which the characters are
    /// appended.</param>
    /// <param name="value">The read-only character memory region to append.</param>
    /// <returns>A reference to <paramref name="builder" /> after the append operation has
    /// completed.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="builder" /> is <c>null</c>.</exception>
    public static StringBuilder Append(this StringBuilder builder, ReadOnlyMemory<char> value)
        => builder.Append(value.Span);

#endif

}
