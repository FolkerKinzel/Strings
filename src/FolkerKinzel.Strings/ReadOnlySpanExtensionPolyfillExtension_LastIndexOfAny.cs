namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtensionPolyfillExtension
{
    /// <summary>Returns the zero-based index of the last occurrence of one of the specified
    /// characters in <paramref name="span" />. The search begins at a specified character
    /// position and runs a specified number of character positions backwards to the beginning
    /// of the <paramref name="span" />.</summary>
    /// <param name="span">The span to search.</param>
    /// <param name="values">A string containing the characters to search for, or <c>null</c>.</param>
    /// <param name="startIndex">The start index of the search. The search is done backwards
    /// to the beginning of <paramref name="span" />.</param>
    /// <param name="count">The number of character positions to examine in <paramref name="span"
    /// />.</param>
    /// <returns>The zero-based index of the last occurrence of one of the specified Unicode
    /// characters in <paramref name="span" /> or -1 if none of these characters have been
    /// found.</returns>
    /// <remarks> 
    /// 
    /// <see cref="MemoryExtensions.LastIndexOfAny{T}(Span{T},
    /// ReadOnlySpan{T})">MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> is used for the comparison.</remarks>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="span"/> is not <see cref="ReadOnlySpan{T}.Empty"/> and
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <paramref name="startIndex" /> is less than zero or greater than or equal to the length of
    /// <paramref name="span" />
    /// </item>
    /// <item>
    /// - or -
    /// </item>
    /// <item>
    /// <paramref name="count"/> is negative or <paramref name="startIndex" /> - <paramref name="count" /> + 1 is less than zero.
    /// </item>
    /// </list>
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET462 || NETSTANDARD2_0
    public static int LastIndexOfAny(this ReadOnlySpan<char> span, string? values, int startIndex, int count)
#else
    public static int LastIndexOfAny(ReadOnlySpan<char> span, string? values, int startIndex, int count)
#endif
        => ReadOnlySpanExtension.LastIndexOfAny(span, values.AsSpan(), startIndex, count);
}

