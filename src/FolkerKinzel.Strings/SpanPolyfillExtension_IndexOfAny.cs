using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class SpanPolyfillExtension
{
    /// <summary>
    /// Searches for the zero-based index of the first occurrence of one of the
    /// specified Unicode characters.
    /// </summary>
    /// <param name="span">The span to search.</param>
    /// <param name="values">The set of characters to search for.</param>
    /// <returns>The zero-based index of the first occurrence of one of the specified Unicode
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
    public static int IndexOfAny(this Span<char> span, SearchValuesPolyfill<char> values)
        => ReadOnlySpanPolyfillExtension.IndexOfAny(span, values);

    /// <summary>Searches for the zero-based index of the first occurrence of one of the
    /// specified Unicode characters.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="values">A read-only character span that contains the characters to search
    /// for.</param>
    /// <returns>The zero-based index of the first occurrence of one of the specified Unicode
    /// characters in <paramref name="span" /> or -1 if none of these characters have been
    /// found. If <paramref name="values" /> is an empty span, the method returns <c>-1</c>.</returns>
#if NET462 || NETSTANDARD2_0
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAny(this Span<char> span, ReadOnlySpan<char> values)
        // The nuget package System.Memory has a bug: It returns 0 if the span with the characters
        // to search for is empty. The BCL returns -1 in this case. This makes it consistent:
        => ReadOnlySpanPolyfillExtension.IndexOfAny(span, values);
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAny(Span<char> span, ReadOnlySpan<char> values)
        => MemoryExtensions.IndexOfAny((ReadOnlySpan<char>)span, values);
#endif

    /// <summary>Searches for the zero-based index of the first occurrence of one of the
    /// specified Unicode characters.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="values">A string containing the characters to search for, or <c>null</c>.</param>
    /// <returns>The zero-based index of the first occurrence of one of the specified Unicode
    /// characters in <paramref name="span" /> or -1 if none of these characters have been
    /// found. If <paramref name="values" /> is <c>null</c> or empty, the method returns
    /// -1.</returns>
    /// <remarks><see cref="IndexOfAny(Span{char}, ReadOnlySpan{char})">
    /// IndexOfAny(Span&lt;T&gt;, ReadOnlySpan&lt;T&gt;)</see> is used for the comparison.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET462 || NETSTANDARD2_0
    public static int IndexOfAny(this Span<char> span, string? values)
        // The nuget package System.Memory has a bug: It returns 0 if the span with the characters
        // to search for is empty. The BCL returns -1 in this case. This makes it consistent:
        => ReadOnlySpanPolyfillExtension.IndexOfAny(span, values.AsSpan());
#else
    public static int IndexOfAny(Span<char> span, string? values)
        => MemoryExtensions.IndexOfAny((ReadOnlySpan<char>)span, values);
#endif
}

