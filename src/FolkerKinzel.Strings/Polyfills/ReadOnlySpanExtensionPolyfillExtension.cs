using System.Runtime.CompilerServices;

namespace FolkerKinzel.Strings.Polyfills;

    /// <summary>Extension methods, which act as Polyfills for the extension methods of the
    /// class <see cref="ReadOnlySpanExtension" />.</summary>
public static class ReadOnlySpanExtensionPolyfillExtension
{
    // Place this preprocessor directive inside the class to let .NET 5.0 have an empty class!
#if NET45 || NETSTANDARD2_0
    /// <summary>Specifies the zero based index position of the last occurrence of a specified
    /// string in <paramref name="span" />. The search begins at a specified character position
    /// and runs backwards to the beginning of the character span for a specified number
    /// of character positions. A parameter specifies the type of comparison to be performed
    /// when searching for the specified string.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="value">The <see cref="string" /> to search for, or <c>null</c>.</param>
    /// <param name="startIndex">The start index of the search. The search is done backwards
    /// to the beginning of <paramref name="span" />.</param>
    /// <param name="count">The number of character positions to examine.</param>
    /// <param name="comparisonType">One of the enumeration values that specifies the rules
    /// for the comparison.</param>
    /// <returns>The zero-based start index of the <paramref name="value" /> parameter if
    /// this character sequence was found, or -1 if it was not found or <paramref name="span"
    /// /> is empty.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="count" /> is a negative value
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="span" /> is not <see cref="ReadOnlySpan{T}.Empty" />, and <paramref
    /// name="startIndex" /> is a negative value.
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="span" /> is not <see cref="ReadOnlySpan{T}.Empty" />, and <paramref
    /// name="startIndex" /> is greater than the length of <paramref name="span" />.
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="span" /> is not <see cref="ReadOnlySpan{T}.Empty" />, and <paramref
    /// name="startIndex" /> + 1 - <paramref name="count" /> indicates a position that is
    /// not within <paramref name="span" />.
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="span" /> is <see cref="ReadOnlySpan{T}.Empty" />, and <paramref name="startIndex"
    /// /> is less than -1 or greater than 0.
    /// </para>
    /// </exception>
    /// <exception cref="ArgumentException"> <paramref name="comparisonType" /> is not a
    /// defined value of the <see cref="StringComparison" /> enum.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOf(this ReadOnlySpan<char> span, string? value, int startIndex, int count, StringComparison comparisonType)
        => span.LastIndexOf(value.AsSpan(), startIndex, count, comparisonType);


    /// <summary>Indicates whether a read-only character span contains one of the Unicode
    /// characters that are passed to the method as a string.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="values">A string containing the characters to search for, or <c>null</c>.</param>
    /// <returns> <c>true</c> if <paramref name="span" /> contains one of the characters
    /// passed with <paramref name="values" />. If <paramref name="span" /> is empty or <paramref
    /// name="values" /> is <c>null</c> or empty, <c>false</c> is returned.</returns>
    /// <remarks>If the length of <paramref name="values" /> is less than 5, the method uses
    /// <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T}, ReadOnlySpan{T})">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> for the comparison. If the length of <paramref name="values"
    /// /> is greater, <see cref="string.IndexOfAny(char[])">String.IndexOfAny(char[])</see>
    /// is used to avoid performance issues.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAny(this ReadOnlySpan<char> span, string? values)
        => span.ContainsAny(values.AsSpan());

    /// <summary>Searches for the zero-based index of the first occurrence of one of the
    /// specified Unicode characters.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="values">A string containing the characters to search for, or <c>null</c>.</param>
    /// <returns>The zero-based index of the first occurrence of one of the specified Unicode
    /// characters in <paramref name="span" /> or -1 if none of these characters have been
    /// found. If <paramref name="values" /> is <c>null</c> or empty, the method returns
    /// -1.</returns>
    /// <remarks>If the length of <paramref name="values" /> is less than 5, the method uses
    /// <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T}, ReadOnlySpan{T})">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> for the comparison. If the length of <paramref name="values"
    /// /> is greater, <see cref="string.IndexOfAny(char[])">String.IndexOfAny(char[])</see>
    /// is used to avoid performance issues.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAny(this ReadOnlySpan<char> span, string? values)
        => span.IndexOfAny(values.AsSpan());

    /// <summary>Searches for the zero-based index of the last occurrence of one of the specified
    /// Unicode characters.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="values">A string containing the characters to search for, or <c>null</c>.</param>
    /// <returns>The zero-based index of the last occurrence of one of the specified Unicode
    /// characters in <paramref name="span" /> or -1 if none of these characters have been
    /// found. If <paramref name="values" /> is <c>null</c> or empty, the method returns
    /// -1.</returns>
    /// <remarks>
    /// If the length of <paramref name="values" /> is less than 5, the method uses
    /// <see cref="MemoryExtensions.LastIndexOfAny{T}(Span{T},
    /// ReadOnlySpan{T})">MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> for the comparison. If the length of <paramref name="values"
    /// /> is greater, <see cref="string.LastIndexOfAny(char[])">String.LastIndexOfAny(char[])</see>
    /// is used to avoid performance issues.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOfAny(this ReadOnlySpan<char> span, string? values)
        => span.LastIndexOfAny(values.AsSpan());

    /// <summary>Returns the zero-based index of the last occurrence of one of the specified
    /// characters in <paramref name="span" />. The search begins at a specified character
    /// position and runs a specified number of character positions backwards to the beginning
    /// of the <paramref name="span" />.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="values">A string containing the characters to search for, or <c>null</c>.</param>
    /// <param name="startIndex">The start index of the search. The search is done backwards
    /// to the beginning of <paramref name="span" />.</param>
    /// <param name="count">The number of characters positions to examine in <paramref name="span"
    /// />.</param>
    /// <returns>The zero-based index of the last occurrence of one of the specified Unicode
    /// characters in <paramref name="span" /> or -1 if none of these characters have been
    /// found.</returns>
    /// <remarks> 
    /// If the length of <paramref name="values" /> is less than 5, the method uses
    /// <see cref="MemoryExtensions.LastIndexOfAny{T}(Span{T},
    /// ReadOnlySpan{T})">MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> for the comparison. If the length of <paramref name="values"
    /// /> is greater, <see cref="string.LastIndexOfAny(char[])">String.LastIndexOfAny(char[])</see>
    /// is used to avoid performance issues.</remarks>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="span" /> is not <see cref="ReadOnlySpan{T}.Empty" /> and <paramref
    /// name="startIndex" /> is less than zero or greater than or equal to the length of
    /// <paramref name="span" />
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="span" /> is not <see cref="ReadOnlySpan{T}.Empty" /> and <paramref
    /// name="startIndex" /> - <paramref name="count" /> + 1 is less than zero.
    /// </para>
    /// </exception>
    public static int LastIndexOfAny(this ReadOnlySpan<char> span, string? values, int startIndex, int count)
        => span.LastIndexOfAny(values.AsSpan(), startIndex, count);
#endif

}
