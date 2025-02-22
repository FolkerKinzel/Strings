using FolkerKinzel.Helpers.Polyfills;
using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringExtension
{
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
    /// characters in the specified part of <paramref name="s" /> or -1 if none of these characters 
    /// have been found in this area.
    /// If <paramref name="anyOf" /> is an empty span, the method returns -1.</returns>
    /// <remarks><see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T}, 
    /// ReadOnlySpan{T})">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> is used for the comparison.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="startIndex" /> or <paramref name="count" /> are smaller than zero
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="startIndex" /> + <paramref name="count" /> is larger than the number
    /// of characters in <paramref name="s" />.
    /// </para>
    /// </exception>
    public static int IndexOfAny(
        this string s, ReadOnlySpan<char> anyOf, int startIndex, int count)
    {
        _ArgumentNullException.ThrowIfNull(s, nameof(s));

        // Don't address System.MemoryExtensions here directly: The nuget package System.MemoryExtensions
        // used for NETSTANDARD2_0 and NET462 has a bug. The library polyfills the bug:
        int matchIndex = s.AsSpan(startIndex, count).IndexOfAny(anyOf);
        return matchIndex == -1 ? -1 : matchIndex + startIndex;
    }

    /// <summary>Returns the zero-based index of the first occurrence of one of the the specified
    /// characters in <paramref name="s" />. The search starts at the specified 
    /// <paramref name="startIndex"/>.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="anyOf">A read-only character span that contains the characters to search
    /// for.</param>
    /// <param name="startIndex">The zero-based index in <paramref name="s" /> at which the
    /// search starts.</param>
    /// <returns>The zero-based index of the first occurrence of one of the specified Unicode
    /// characters in the specified part of <paramref name="s" /> or -1 if none of these characters 
    /// have been found in this area.
    /// If <paramref name="anyOf" /> is an empty span, the method returns -1.</returns>
    /// <remarks>If the length of <paramref name="anyOf" /> is less than 5, the method uses
    /// <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T}, 
    /// ReadOnlySpan{T})">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> for the comparison. If the length of <paramref name="anyOf"
    /// /> is greater, <see cref="string.IndexOfAny(char[])">String.IndexOfAny(char[])</see>
    /// is used.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="startIndex" /> is not a valid index in <paramref name="s"/>.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAny(this string s, ReadOnlySpan<char> anyOf, int startIndex)
        => s.IndexOfAny(anyOf, startIndex, s?.Length - startIndex ?? throw new ArgumentNullException(nameof(s)));

    /// <summary>Returns the zero-based index of the first occurrence of one of the the specified
    /// characters in <paramref name="s" />. </summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="anyOf">A read-only character span that contains the characters to search
    /// for.</param>
    /// <returns>The zero-based index of the first occurrence of one of the specified Unicode
    /// characters in <paramref name="s" /> or -1 if none of these characters have been found.
    /// If <paramref name="anyOf" /> is an empty span, the method returns -1.</returns>
    /// <remarks>If the length of <paramref name="anyOf" /> is less than 5, the method uses
    /// <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T}, 
    /// ReadOnlySpan{T})">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> for the comparison. If the length of <paramref name="anyOf"
    /// /> is greater, <see cref="string.IndexOfAny(char[])">String.IndexOfAny(char[])</see>
    /// is used.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAny(this string s, ReadOnlySpan<char> anyOf)
        => s.IndexOfAny(anyOf, 0, s?.Length ?? throw new ArgumentNullException(nameof(s)));
}
