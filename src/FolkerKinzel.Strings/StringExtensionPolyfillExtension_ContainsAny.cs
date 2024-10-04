using System.Text.RegularExpressions;

namespace FolkerKinzel.Strings;

/// <summary> Extension methods, which act as Polyfills for the extension methods of the 
/// <see cref="StringExtension" /> class.</summary>
/// <remarks>The polyfills are available for .NET Framework 4.5 and .NET Standard 2.0.</remarks>
public static partial class StringExtensionPolyfillExtension
{
    /// <summary>Indicates whether a <see cref="string" /> contains one of the Unicode characters
    /// that are passed to the method in a read-only span.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="anyOf">A <see cref="string"/> that contains the characters to search
    /// for or <c>null</c>.</param>
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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NET461 || NETSTANDARD2_0
    public static bool ContainsAny(this string s, string? anyOf)
#else
    public static bool ContainsAny(string s, string? anyOf)
#endif
        => s.ContainsAny(anyOf.AsSpan());
}
