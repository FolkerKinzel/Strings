using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

#if NET7_0 || NET6_0 || NET5_0 || NETCOREAPP3_1 || NETSTANDARD2_1 || NETSTANDARD2_0 || NET461

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
    /// This is a polyfill that does not have the performance benefits of System.Buffers.SearchValues&lt;T&gt;.
    /// </note>
    /// </remarks>
    /// 
    /// <exception cref="ArgumentNullException"><paramref name="values"/> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAny(this Span<char> span, SearchValues<char> values)
        => ((ReadOnlySpan<char>)span).IndexOfAny(values);

#if NET461 || NETSTANDARD2_0

    /// <summary>Searches for the zero-based index of the first occurrence of one of the
    /// specified Unicode characters.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="values">A read-only character span that contains the characters to search
    /// for.</param>
    /// <returns>The zero-based index of the first occurrence of one of the specified Unicode
    /// characters in <paramref name="span" /> or -1 if none of these characters have been
    /// found. If <paramref name="values" /> is an empty span, the method returns <c>-1</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAny(this Span<char> span, ReadOnlySpan<char> values)
    {
        // The nuget package System.Memory has a bug: It returns 0 if the span with the characters
        // to search for is empty. The BCL returns -1 in this case. This makes it consistent:
        return values.IsEmpty
            ? -1
            : MemoryExtensions.IndexOfAny(span, values);
    }

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
    public static int IndexOfAny(this Span<char> span, string? values)
        => span.IndexOfAny(values.AsSpan());
#endif
}

#endif
