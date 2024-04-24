using System.Text.RegularExpressions;

namespace FolkerKinzel.Strings;

#if NET461 || NETSTANDARD2_0

public static partial class StringExtensionPolyfillExtension
{
    /// <summary>Returns the zero-based index position of the last occurrence of one of the
    /// specified characters in <paramref name="s" />. The search begins at a specified index
    /// and runs backwards to the beginning of the <see cref="string" /> for a specified
    /// number of character positions.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="anyOf">A <see cref="string"/> that contains the characters to search
    /// for or <c>null</c>.</param>
    /// <param name="startIndex">The start index of the search. The search is done backwards
    /// to the beginning of <paramref name="s" />.</param>
    /// <param name="count">The number of character positions to examine.</param>
    /// <returns>The zero-based index of the last occurrence of one of the specified Unicode
    /// characters in the specified part of <paramref name="s" /> or -1 if none of these
    /// characters have been found in this area.</returns>
    /// <remarks>If the length of <paramref name="anyOf" /> is less than 5, the method uses
    /// MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;)
    /// for the comparison. If the length of <paramref name="anyOf" /> is greater, <see
    /// cref="string.LastIndexOfAny(char[])" /> is used.</remarks>
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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOfAny(this string s, string? anyOf, int startIndex, int count)
        => s.LastIndexOfAny(anyOf.AsSpan(), startIndex, count);

    /// <summary>Returns the zero-based index position of the last occurrence of one of the
    /// specified characters in <paramref name="s" />. The search starts at the specified 
    /// <paramref name="startIndex"/> and runs backwards to the beginning of <paramref name="s"/>.
    /// </summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="anyOf">A <see cref="string"/> that contains the characters to search
    /// for or <c>null</c>.</param>
    /// <param name="startIndex">The start index of the search. The search is done backwards
    /// to the beginning of <paramref name="s" />.</param>
    /// <returns>The zero-based index of the last occurrence of one of the specified Unicode
    /// characters in the specified part of <paramref name="s" /> or -1 if none of these
    /// characters have been found in this area.</returns>
    /// 
    /// <remarks>If the length of <paramref name="anyOf" /> is less than 5, the method uses
    /// MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;)
    /// for the comparison. If the length of <paramref name="anyOf" /> is greater, <see
    /// cref="string.LastIndexOfAny(char[])" /> is used.</remarks>
    /// 
    /// <exception cref = "ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="s" /> is not <see cref="string.Empty" /> and <paramref name="startIndex"
    /// /> is less than zero or greater than or equal to the length of <paramref name="s" />
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOfAny(this string s, string? anyOf, int startIndex)
        => s.LastIndexOfAny(anyOf.AsSpan(), startIndex, startIndex + 1);

    /// <summary>Returns the zero-based index position of the last occurrence of one of the
    /// specified characters in <paramref name="s" />.
    /// </summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="anyOf">A <see cref="string"/> that contains the characters to search
    /// for or <c>null</c>.</param>
    /// <returns>The zero-based index of the last occurrence of one of the specified Unicode
    /// characters in <paramref name="s" /> or -1 if none of these
    /// characters have been found.</returns>
    /// <remarks>If the length of <paramref name="anyOf" /> is less than 5, the method uses
    /// MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;)
    /// for the comparison. If the length of <paramref name="anyOf" /> is greater, <see
    /// cref="string.LastIndexOfAny(char[])" /> is used.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOfAny(this string s, string? anyOf)
    {
        return s is null ? throw new ArgumentNullException(nameof(s))
                         : s.LastIndexOfAny(anyOf.AsSpan(), s.Length - 1, s.Length);
    }
}

#endif
