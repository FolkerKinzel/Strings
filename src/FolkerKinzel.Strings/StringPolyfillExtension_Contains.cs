using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

/// <summary>Extension methods for the <see cref="string" /> class, which are used
/// as polyfills for methods from current .NET versions.</summary>
/// <remarks>To match the behavior of the original methods, these extension methods throw
/// a <see cref="NullReferenceException" /> when called on a <c>null</c> string.</remarks>
public static partial class StringPolyfillExtension
{
#if NET461 || NETSTANDARD2_0

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
    public static bool Contains(this string s, char value, StringComparison comparisonType)
        => s is null ? throw new NullReferenceException()
                     : s.AsSpan().Contains(stackalloc[] { value }, comparisonType);

    /// <summary>Returns a value indicating whether a specified character appears in the
    /// <see cref="string" />.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> has been found, <c>false</c> otherwise.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    public static bool Contains(this string s, char value)
        => s is null ? throw new NullReferenceException()
                     : s.AsSpan().Contains(value);

    /// <summary>Returns a value indicating whether a specified <see cref="string" /> occurs
    /// within <paramref name="s" />, using the specified comparison rules.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="value">The span to search for.</param>
    /// <param name="comparisonType">An enumeration value that specifies the rules for the
    /// comparison.</param>
    /// <returns> <c>true</c> if <paramref name="value" /> has been found, <c>false</c> otherwise.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(
        this string s, string value, StringComparison comparisonType)
        => s.IndexOf(value, comparisonType) != -1;

#endif
}

