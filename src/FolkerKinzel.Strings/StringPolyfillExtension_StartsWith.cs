using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringPolyfillExtension
{
    /// <summary>Indicates whether <paramref name="s" /> starts with the specified character.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="value">The Unicode character to compare.</param>
    /// <returns> <c>true</c> if value matches the beginning of <paramref name="s" />; otherwise,
    /// <c>false</c>.</returns>
    /// <remarks>This method performs a word (case-sensitive and culture-sensitive) comparison
    /// using the current culture.</remarks>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
#if NET462 || NETSTANDARD2_0
    public static bool StartsWith(this string s, char value)
        => s is null ? throw new NullReferenceException()
                     : s.AsSpan().StartsWith(stackalloc char[] { value }, StringComparison.CurrentCulture);
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool StartsWith(string s, char value)
        => s.StartsWith(value);
#endif
}


