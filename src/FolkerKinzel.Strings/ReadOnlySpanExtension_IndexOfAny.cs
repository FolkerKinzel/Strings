using System.Runtime.CompilerServices;

namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    /// <summary>Searches for the zero-based index of the first occurrence of one of the
    /// specified Unicode characters.</summary>
    /// <param name="span">The read-only span to examine.</param>
    /// <param name="values">A read-only character span that contains the characters to search
    /// for.</param>
    /// <returns>The zero-based index of the first occurrence of one of the specified Unicode
    /// characters in <paramref name="span" /> or -1 if none of these characters have been
    /// found. If <paramref name="values" /> is an empty span, the method returns <c>-1</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAny(this ReadOnlySpan<char> span, ReadOnlySpan<char> values)
    {
        // string.IndexOfAny returns -1 if anyOf is an empty array (although MSDN says it
        // would return 0).
        // MemoryExtensions.IndexOfAny returns 0 if the span with the characters to search
        // for is empty for .NETSTANDARD 2.0 and -1 with .NET 8.0 . This makes it consistent:
        return values.IsEmpty
            ? -1
            : MemoryExtensions.IndexOfAny(span, values);
    }
}
