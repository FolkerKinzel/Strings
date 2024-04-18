using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringPolyfillExtension
{
#if NET461 || NETSTANDARD2_0

    /// <summary>Indicates whether the end of <paramref name="s" /> matches the specified
    /// character.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="value">The Unicode character to compare.</param>
    /// <returns> <c>true</c> if value matches the end of <paramref name="s" />; otherwise,
    /// <c>false</c>.</returns>
    /// <remarks>This method performs a word (case-sensitive and culture-sensitive) comparison
    /// using the current culture.</remarks>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
    public static bool EndsWith(this string s, char value)
        => s is null ? throw new NullReferenceException()
                     : s.AsSpan().EndsWith(stackalloc char[] { value }, StringComparison.CurrentCulture);

#endif
}

