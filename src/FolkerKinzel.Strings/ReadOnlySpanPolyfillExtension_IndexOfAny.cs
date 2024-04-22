namespace FolkerKinzel.Strings;


public static partial class ReadOnlySpanPolyfillExtension
{
    // Place this preprocessor directive inside the class to let .NET 5.0 have an empty class!
#if NET461 || NETSTANDARD2_0

    /// <summary>Searches for the zero-based index of the first occurrence of one of the
    /// specified Unicode characters.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="values">A string containing the characters to search for, or <c>null</c>.</param>
    /// <returns>The zero-based index of the first occurrence of one of the specified Unicode
    /// characters in <paramref name="span" /> or -1 if none of these characters have been
    /// found. If <paramref name="values" /> is <c>null</c> or empty, the method returns
    /// <c>0</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAny(this ReadOnlySpan<char> span, string? values)
        => span.IndexOfAny(values.AsSpan());

#endif
}
