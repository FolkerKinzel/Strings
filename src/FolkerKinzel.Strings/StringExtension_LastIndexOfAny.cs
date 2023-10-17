namespace FolkerKinzel.Strings;

public static partial class StringExtension
{
    /// <summary>Returns the zero-based index position of the last occurrence of one of the
    /// specified characters in <paramref name="s" />. The search begins at a specified index
    /// and runs backwards to the beginning of the <see cref="string" /> for a specified
    /// number of character positions.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="anyOf">A read-only character span that contains the characters to search
    /// for.</param>
    /// <param name="startIndex">The start index of the search. The search is done backwards
    /// to the beginning of <paramref name="s" />.</param>
    /// <param name="count">The number of character positions to examine.</param>
    /// <returns>The zero-based index of the last occurrence of one of the specified Unicode
    /// characters in the specified part of <paramref name="s" /> or -1 if none of these
    /// characters have been found in this area.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="s" /> is not <see cref="string.Empty" /> and <paramref name="startIndex"
    /// /> is less than zero or greater than or equal to the length of <paramref name="s"
    /// />
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="s" /> is not <see cref="string.Empty" /> and <paramref name="startIndex"
    /// /> - <paramref name="count" /> + 1 is less than zero.
    /// </para>
    /// </exception>
    /// <remarks>If the length of <paramref name="anyOf" /> is less than 5, the method uses
    /// MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;)
    /// for the comparison. If the length of <paramref name="anyOf" /> is greater, <see
    /// cref="string.LastIndexOfAny(char[])" /> is used.</remarks>
    public static int LastIndexOfAny(this string s, ReadOnlySpan<char> anyOf, int startIndex, int count)
    {
        if (s is null)
        {
            throw new ArgumentNullException(nameof(s));
        }

        // string.LastIndexOfAny returns -1 if anyOf is an empty array (although MSDN says it would return 0).
        // MemoryExtensions.LastIndexOfAny returns 0 if the span with the characters to search for is empty.
        // This makes it consistent:
        if (count == 0 || anyOf.IsEmpty)
        {
            return -1;
        }

        if (anyOf.Length <= 5)
        {
            // MemoryExtensions.LastIndexOfAny throws ArgumentOutOfRangeExceptions even if s is ""
            // string.LastIndexOfAny does not.
            if (s.Length == 0)
            {
                return -1;
            }
            int matchIndex = MemoryExtensions.LastIndexOfAny(s.AsSpan(startIndex - count + 1, count), anyOf);
            return matchIndex == -1 ? -1 : matchIndex + startIndex - count + 1;
        }

        return s.LastIndexOfAny(anyOf.ToArray(), startIndex, count);
    }

}
