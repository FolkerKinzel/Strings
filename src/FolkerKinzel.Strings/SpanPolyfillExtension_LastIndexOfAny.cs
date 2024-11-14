using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class SpanPolyfillExtension
{
    /// <summary>
    /// Searches for the last index of any of the specified Unicode characters.
    /// </summary>
    /// <param name="span">The span to search.</param>
    /// <param name="values">The set of characters to search for.</param>
    /// <returns>The zero-based index of the last occurrence of one of the specified Unicode
    /// characters in <paramref name="span" /> or -1 if none of these characters have been
    /// found.</returns>
    /// 
    /// <remarks>
    /// <note type="caution">
    /// This is a polyfill that does not have the performance benefits of System.Buffers.SearchValues&lt;T&gt;
    /// when used with framework versions lower than .NET 8.0.
    /// </note>
    /// </remarks>
    /// 
    /// <exception cref="ArgumentNullException"><paramref name="values"/> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOfAny(this Span<char> span, SearchValuesPolyfill<char> values)
        => ReadOnlySpanPolyfillExtension.LastIndexOfAny(span, values);

    /// <summary>Searches for the zero-based index of the last occurrence of one of the specified
    /// Unicode characters.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="values">A read-only character span that contains the characters to search
    /// for.</param>
    /// <returns>The zero-based index of the last occurrence of one of the specified Unicode
    /// characters in <paramref name="span" /> or -1 if none of these characters have been
    /// found. If <paramref name="values" /> is an empty span, the method returns -1.</returns>
    /// <remarks> 
    /// If the length of <paramref name="values" /> is less than 5, the method uses
    /// <see cref="MemoryExtensions.LastIndexOfAny{T}(Span{T},
    /// ReadOnlySpan{T})">MemoryExtensions.LastIndexOfAny&lt;T&gt;(Span&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> for the comparison. If the length of <paramref name="values"
    /// /> is greater, <see cref="string.LastIndexOfAny(char[])">String.LastIndexOfAny(char[])</see>
    /// is used to avoid performance issues. 
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET462 || NETSTANDARD2_0
    public static int LastIndexOfAny(this Span<char> span, ReadOnlySpan<char> values)
        // Don't address MemoryExtensions here directly because the library method
        // polyfills a bug in the nuget package System.Memory for .NET Framework and
        // .NET Standard 2.0
        => ReadOnlySpanPolyfillExtension.LastIndexOfAny(span, values);
#else
    public static int LastIndexOfAny(Span<char> span, ReadOnlySpan<char> values)
        => MemoryExtensions.LastIndexOfAny((ReadOnlySpan<char>)span, values);
#endif

    /// <summary>Searches for the zero-based index of the last occurrence of one of the specified
    /// Unicode characters.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="values">A string containing the characters to search for, or <c>null</c>.</param>
    /// <returns>The zero-based index of the last occurrence of one of the specified Unicode
    /// characters in <paramref name="span" /> or -1 if none of these characters have been
    /// found. If <paramref name="values" /> is <c>null</c> or empty, the method returns
    /// -1.</returns>
    /// <remarks>If the length of <paramref name="values" /> is less than 5, the method uses
    /// <see cref="MemoryExtensions.LastIndexOfAny{T}(ReadOnlySpan{T}, 
    /// ReadOnlySpan{T})">MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> for the comparison. If the length of <paramref name="values"
    /// /> is greater, <see cref="string.LastIndexOfAny(char[])">String.LastIndexOfAny(char[])</see>
    /// is used to avoid performance issues.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET462 || NETSTANDARD2_0
    public static int LastIndexOfAny(this Span<char> span, string? values)
        // Don't address MemoryExtensions here directly because the library method
        // polyfills a bug in the nuget package System.Memory for .NET Framework and
        // .NET Standard 2.0
        => ReadOnlySpanPolyfillExtension.LastIndexOfAny(span, values.AsSpan());
#else
    public static int LastIndexOfAny(Span<char> span, string? values)
        => MemoryExtensions.LastIndexOfAny<char>((ReadOnlySpan<char>)span, values);
#endif

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
    /// <remarks><see cref="MemoryExtensions.LastIndexOfAny{T}(ReadOnlySpan{T},
    /// ReadOnlySpan{T})">MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> is used for the comparison.</remarks>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="span"/> is not <see cref="Span{T}.Empty"/> and
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
    public static int LastIndexOfAny(
            this Span<char> span, string? values, int startIndex, int count)
#else
    public static int LastIndexOfAny(
                Span<char> span, string? values, int startIndex, int count)
#endif
            => ReadOnlySpanExtension.LastIndexOfAny(span, values.AsSpan(), startIndex, count);
}