namespace FolkerKinzel.Strings;

public static partial class StringExtension
{
    // Avoid overloads which pass the span around: This is for performance!

    /// <summary>Returns the zero-based index of the first occurrence of one of the the specified
    /// characters in <paramref name="s" />. The search begins at a specified index and a
    /// specified number of character positions are checked.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="anyOf">A read-only character span that contains the characters to search
    /// for.</param>
    /// <param name="startIndex">The zero-based index in <paramref name="s" /> at which the
    /// search starts.</param>
    /// <param name="count">The number of characters positions to examine in <paramref name="s"
    /// />.</param>
    /// <returns>The zero-based index of the first occurrence of one of the specified Unicode
    /// characters in <paramref name="s" /> or -1 if none of these characters have been found.
    /// If <paramref name="anyOf" /> is an empty span, the method returns -1.</returns>
    /// <remarks>If the length of <paramref name="anyOf" /> is less than 5, the method uses
    /// <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T}, ReadOnlySpan{T})">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> for the comparison. If the length of <paramref name="anyOf"
    /// /> is greater, <see cref="string.IndexOfAny(char[])">String.IndexOfAny(char[])</see>
    /// is used.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> or <paramref name="anyOf"
    /// /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="startIndex" /> or <paramref name="count" /> are smaller than zero
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="startIndex" /> + <paramref name="count" /> is larger than the number
    /// of characters in <paramref name="value" />.
    /// </para>
    /// </exception>
    public static int IndexOfAny(this string s, ReadOnlySpan<char> anyOf, int startIndex, int count)
    {
        if (s is null)
        {
            throw new ArgumentNullException(nameof(s));
        }

        // string.IndexOfAny returns -1 if anyOf is an empty array (although MSDN says it would return 0).
        // MemoryExtensions.IndexOfAny returns 0 if the span with the characters to search for is empty.
        // This makes it consistent:
        if (count == 0 || anyOf.IsEmpty)
        {
            return -1;
        }

        if (anyOf.Length <= 5)
        {
            int matchIndex = MemoryExtensions.IndexOfAny(s.AsSpan(startIndex, count), anyOf);
            return matchIndex == -1 ? -1 : matchIndex + startIndex;
        }

        return s.IndexOfAny(anyOf.ToArray(), startIndex, count);
    }
}
