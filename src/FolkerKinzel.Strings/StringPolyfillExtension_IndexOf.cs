using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;


public static partial class StringPolyfillExtension
{
    /// <summary>Returns the zero-based index of the first occurrence of the specified Unicode
    /// character in this <see cref="string" />. A parameter specifies the type of search
    /// to use for the specified character.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <param name="comparisonType">An enumeration value that specifies the rules for the
    /// search.</param>
    /// <returns>The zero-based index of <paramref name="value" /> if that character is found,
    /// or -1 if it is not.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException"> <paramref name="comparisonType" /> is not a
    /// defined value of the <see cref="StringComparison" /> enum.</exception>
#if NET461 || NETSTANDARD2_0
    public static int IndexOf(this string s, char value, StringComparison comparisonType)
        => s is null ? throw new NullReferenceException()
                     : s.AsSpan().IndexOf(stackalloc[] { value }, comparisonType);
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOf(string s, char value, StringComparison comparisonType)
        => s.IndexOf(value, comparisonType);
#endif

}


