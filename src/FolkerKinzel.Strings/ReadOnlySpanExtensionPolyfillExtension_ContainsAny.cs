namespace FolkerKinzel.Strings;

/// <summary>Extension methods, which act as Polyfills for the extension methods of the
/// <see cref="ReadOnlySpanExtension" /> class.</summary>
public static partial class ReadOnlySpanExtensionPolyfillExtension
{
    // Place this preprocessor directive inside the class to let .NET 5.0 have an empty class!
#if NET461 || NETSTANDARD2_0

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


#endif
}
