using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;


public static partial class ReadOnlySpanPolyfillExtension
{
    /// <summary>
    /// Searches for the zero-based index of the first occurrence of one of the
    /// specified Unicode characters.
    /// </summary>
    /// <param name="span">The read-only span to search.</param>
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
    public static int IndexOfAny(this ReadOnlySpan<char> span, SearchValuesPolyfill<char> values)
    {
        // Don't address MemoryExtensions here directly because the library method
        // polyfills a bug in the nuget package System.Memory for .NET Framework and
        // .NET Standard 2.0

        _ArgumentNullException.ThrowIfNull(values, nameof(values));
        return span.IndexOfAny(values.Value);
    }

    /// <summary>Searches for the zero-based index of the first occurrence of one of the
    /// specified Unicode characters.</summary>
    /// <param name="span">The read-only span to search.</param>
    /// <param name="values">A read-only character span that contains the characters to search
    /// for.</param>
    /// <returns>The zero-based index of the first occurrence of one of the specified Unicode
    /// characters in <paramref name="span" /> or -1 if none of these characters have been
    /// found. If <paramref name="values" /> is an empty span, the method returns <c>-1</c>.</returns>
#if NET461 || NETSTANDARD2_0
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAny(this ReadOnlySpan<char> span, ReadOnlySpan<char> values)
         // The nuget package System.Memory has a bug: It returns 0 if the span with the characters
         // to search for is empty. The BCL returns -1 in this case. This makes it consistent:
         => values.IsEmpty ? -1 : MemoryExtensions.IndexOfAny(span, values);
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAny(ReadOnlySpan<char> span, ReadOnlySpan<char> values)
        => MemoryExtensions.IndexOfAny(span, values);
#endif

    /// <summary>Searches for the zero-based index of the first occurrence of one of the
    /// specified Unicode characters.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="values">A string containing the characters to search for, or <c>null</c>.</param>
    /// <returns>The zero-based index of the first occurrence of one of the specified Unicode
    /// characters in <paramref name="span" /> or -1 if none of these characters have been
    /// found. If <paramref name="values" /> is <c>null</c> or empty, the method returns
    /// <c>0</c>.</returns>
#if NET461 || NETSTANDARD2_0
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAny(this ReadOnlySpan<char> span, string? values)
        // Don't address MemoryExtensions here directly because the library method
        // polyfills a bug in the nuget package System.Memory for .NET Framework and
        // .NET Standard 2.0
        => span.IndexOfAny(values.AsSpan());
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAny(ReadOnlySpan<char> span, string? values)
    => MemoryExtensions.IndexOfAny<char>(span, values);
#endif

}

