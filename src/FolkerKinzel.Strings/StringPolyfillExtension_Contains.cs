using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringPolyfillExtension
{
    /// <summary>Returns a value indicating whether a specified character occurs within this
    /// <see cref="string" />, using the specified comparison rules.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <param name="comparisonType">An enumeration value that specifies the rules for the
    /// comparison.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> has been found, <c>false</c> otherwise.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException"> <paramref name="comparisonType" /> is not a
    /// defined value of the <see cref="StringComparison" /> enum.</exception>
#if NET462 || NETSTANDARD2_0
    public static bool Contains(this string s, char value, StringComparison comparisonType)
        => s is null ? throw new NullReferenceException()
                     : s.AsSpan().Contains(stackalloc[] { value }, comparisonType);
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(string s, char value, StringComparison comparisonType)
        => s.Contains(value, comparisonType);
#endif

    /// <summary>Returns a value indicating whether a specified character appears in the
    /// <see cref="string" />.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> has been found, <c>false</c> otherwise.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
#if NET462 || NETSTANDARD2_0
    public static bool Contains(this string s, char value)
        => s is null ? throw new NullReferenceException()
                     : s.AsSpan().Contains(value);
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(string s, char value)
        => s.Contains(value);
#endif

    /// <summary>Returns a value indicating whether a specified <see cref="string" /> occurs
    /// within <paramref name="s" />, using the specified comparison rules.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="value">The span to search for.</param>
    /// <param name="comparisonType">An enumeration value that specifies the rules for the
    /// comparison.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> has been found, <c>false</c> otherwise.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
#if NET462 || NETSTANDARD2_0
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(
        this string s, string value, StringComparison comparisonType)
        => s.IndexOf(value, comparisonType) != -1;
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(
        string s, string value, StringComparison comparisonType)
        => s.Contains(value, comparisonType);
#endif

}


