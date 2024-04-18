using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringPolyfillExtension
{
#if NET461 || NETSTANDARD2_0

    /// <summary>Splits a <see cref="string" /> into substrings based on a specified delimiting
    /// character and, optionally, options.</summary>
    /// <param name="s">The <see cref="string" /> to split.</param>
    /// <param name="separator">A character that delimits the substrings in <paramref name="s"
    /// />.</param>
    /// <param name="options">An enumeration value that specifies whether to include empty
    /// substrings.</param>
    /// <returns>An array whose elements contain the substrings from <paramref name="s" />
    /// that are delimited by <paramref name="separator" />.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string[] Split(
        this string s, char separator, StringSplitOptions options = StringSplitOptions.None)
        => s.Split(new char[] { separator }, options);

    /// <summary>Splits a <see cref="string" /> into a maximum number of substrings based
    /// on the provided character separator, optionally omitting empty substrings from the
    /// result.</summary>
    /// <param name="s">The <see cref="string" /> to split.</param>
    /// <param name="separator">A character that delimits the substrings in <paramref name="s"
    /// />.</param>
    /// <param name="count">The maximum number of elements expected in the array.</param>
    /// <param name="options">An enumeration value that specifies whether to include empty
    /// substrings.</param>
    /// <returns>An array that contains at most <paramref name="count" /> substrings from
    /// <paramref name="s" /> that are delimited by <paramref name="separator" />.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="count" /> is negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string[] Split(
        this string s, char separator, int count, StringSplitOptions options = StringSplitOptions.None)
        => s.Split(new char[] { separator }, count, options);


    /// <summary>Splits a <see cref="string" /> into a maximum number of substrings based
    /// on the provided separator, optionally omitting empty substrings from the result.</summary>
    /// <param name="s">The <see cref="string" /> to split.</param>
    /// <param name="separator">A <see cref="string" /> that delimits the substrings in <paramref
    /// name="s" />.</param>
    /// <param name="count">The maximum number of elements expected in the array.</param>
    /// <param name="options">An enumeration value that specifies whether to include empty
    /// substrings.</param>
    /// <returns>An array that contains at most <paramref name="count" /> substrings from
    /// <paramref name="s" /> that are delimited by <paramref name="separator" />.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="count" /> is negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string[] Split(
        this string s, string? separator, int count, StringSplitOptions options = System.StringSplitOptions.None)
        => s is null
            ? throw new NullReferenceException()
            : count < 0
                ? throw new ArgumentOutOfRangeException(nameof(count))
                : count == 0 || (s.Length == 0 && (options & StringSplitOptions.RemoveEmptyEntries) == StringSplitOptions.RemoveEmptyEntries)
                     ? []
                     : string.IsNullOrEmpty(separator)
                         ? [s]
                         : s.Split(new string[] { separator }, count, options);


    /// <summary>Splits a <see cref="string" /> into substrings based on the provided separator,
    /// optionally omitting empty substrings from the result.</summary>
    /// <param name="s">The <see cref="string" /> to split.</param>
    /// <param name="separator">A <see cref="string" /> that delimits the substrings in <paramref
    /// name="s" />.</param>
    /// <param name="options">An enumeration value that specifies whether to include empty
    /// substrings.</param>
    /// <returns>An array whose elements contain the substrings from <paramref name="s" />
    /// that are delimited by <paramref name="separator" />.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string[] Split(
        this string s, string? separator, StringSplitOptions options = System.StringSplitOptions.None)
         => s is null
            ? throw new NullReferenceException()
                : (s.Length == 0 &&
                   (options & StringSplitOptions.RemoveEmptyEntries) == StringSplitOptions.RemoveEmptyEntries)
                        ? []
                        : string.IsNullOrEmpty(separator)
                            ? [s]
                            : s.Split(new string[] { separator }, options);

#endif
}

