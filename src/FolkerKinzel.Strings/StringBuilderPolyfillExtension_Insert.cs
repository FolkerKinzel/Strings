using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderPolyfillExtension
{
    // Place this preprocessor directive inside the class to let .NET Core 3.1 and above have an empty class!
#if NET461 || NETSTANDARD2_0

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
