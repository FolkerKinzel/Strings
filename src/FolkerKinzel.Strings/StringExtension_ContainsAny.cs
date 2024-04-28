namespace FolkerKinzel.Strings;

public static partial class StringExtension
{
    /// <summary>Indicates whether a <see cref="string" /> contains one of the two characters
    /// that are passed to the method as arguments.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="value0">The first character to search for.</param>
    /// <param name="value1">The second character to search for.</param>
    /// <returns> <c>true</c> if one of the characters to be searched for is found, otherwise
    /// <c>false</c>.</returns>
    /// <remarks> <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T},
    /// T, T)">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, T, T)</see> 
    /// is used for the comparison.
    /// </remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    public static bool ContainsAny(this string s, char value0, char value1)
        => s is null ? throw new ArgumentNullException(nameof(s))
                     : s.AsSpan().ContainsAny(value0, value1);

    /// <summary>Indicates whether a <see cref="string" /> contains one of the 3 characters
    /// that are passed to the method as arguments.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="value0">The first character to search for.</param>
    /// <param name="value1">The second character to search for.</param>
    /// <param name="value2">The third character to search for.</param>
    /// <returns> <c>true</c> if one of the characters to be searched for is found, otherwise
    /// <c>false</c>.</returns>
    /// <remarks> <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T},
    /// T, T, T)">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, T, T, T)</see>
    /// is used for the comparison.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    public static bool ContainsAny(this string s, char value0, char value1, char value2)
        => s is null ? throw new ArgumentNullException(nameof(s))
                     : s.AsSpan().ContainsAny(value0, value1, value2);

    /// <summary>Indicates whether a <see cref="string" /> contains one of the Unicode characters
    /// that are passed to the method in a read-only span.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="anyOf">A read-only character span that contains the characters to search
    /// for.</param>
    /// <returns> <c>true</c> if one of the characters to be searched for is found in <paramref
    /// name="s" />, otherwise <c>false</c>. If <paramref name="s" /> or <paramref name="anyOf"
    /// /> have the length zero, <c>false</c> is returned.</returns>
    /// <remarks>If the length of <paramref name="anyOf" /> is less than 5, the method uses
    /// <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T}, 
    /// ReadOnlySpan{T})">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;,
    /// ReadOnlySpan&lt;T&gt;)</see> for the comparison. If the length of <paramref name="anyOf"
    /// /> is greater, <see cref="string.IndexOfAny(char[])">String.IndexOfAny(char[])</see>
    /// is used.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> is <c>null</c>.</exception>
    public static bool ContainsAny(this string s, ReadOnlySpan<char> anyOf)
        => s is null ? throw new ArgumentNullException(nameof(s))
                     : s.IndexOfAny(anyOf, 0, s.Length) != -1;

    /// <summary>Indicates whether a <see cref="string" /> contains one of the Unicode characters
    /// that are passed to the method as an array.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="anyOf">An array, which contains the characters to search for.</param>
    /// <returns> <c>true</c> if one of the characters to be searched for is found in <paramref
    /// name="s" />, otherwise <c>false</c>. If <paramref name="s" /> or <paramref name="anyOf"
    /// /> have the length zero, <c>false</c> is returned.</returns>
    /// <remarks> <see cref="string.IndexOfAny(char[])" /> is used for the comparison.</remarks>
    /// <exception cref="ArgumentNullException"> <paramref name="s" /> or <paramref name="anyOf"
    /// /> is <c>null</c>.</exception>
    public static bool ContainsAny(this string s, char[] anyOf)
        => s is null ? throw new ArgumentNullException(nameof(s))
                     : s.IndexOfAny(anyOf) != -1;
}
