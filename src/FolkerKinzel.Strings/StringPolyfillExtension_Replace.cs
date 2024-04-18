using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringPolyfillExtension
{
#if NET461 || NETSTANDARD2_0

    /// <summary>Returns a new <see cref="string" /> in which all occurrences of a specified
    /// <see cref="string" /> in the current <see cref="string" /> are replaced with another
    /// specified <see cref="string" />, using the provided comparison type.</summary>
    /// <param name="s">The source <see cref="string" />.</param>
    /// <param name="oldValue">The string to replace.</param>
    /// <param name="newValue">The <see cref="string" /> to replace all occurrences of <paramref
    /// name="oldValue" />.</param>
    /// <param name="comparisonType">An enumeration value that specifies the rules for the
    /// comparison.</param>
    /// <returns>A <see cref="string" /> that is equivalent to <paramref name="s" /> except
    /// that all instances of <paramref name="oldValue" /> are replaced with <paramref name="newValue"
    /// />. If <paramref name="oldValue" /> is not found in <paramref name="s" />, the method
    /// returns <paramref name="s" /> unchanged.</returns>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentNullException"> <paramref name="oldValue" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">
    /// <para>
    /// <paramref name="oldValue" /> is <see cref="string.Empty" />
    /// </para>
    /// <para>
    /// - or -
    /// </para>
    /// <para>
    /// <paramref name="comparisonType" /> is not a defined value of the <see cref="StringComparison"
    /// /> enumeration.
    /// </para>
    /// </exception>
    public static string Replace(
        this string s, string oldValue, string? newValue, StringComparison comparisonType)
    {
        if (comparisonType == StringComparison.Ordinal)
        {
            return s.Replace(oldValue, newValue);
        }

        _NullReferenceException.ThrowIfNull(s, nameof(s));
        _ArgumentNullException.ThrowIfNull(oldValue, nameof(oldValue));

        if (oldValue.Length == 0)
        {
            throw new ArgumentException(string.Format("{0} is an empty String.", nameof(oldValue)),
                                        nameof(oldValue));
        }

        if (s.Length < oldValue.Length)
        {
            return s;
        }

        newValue ??= string.Empty;

        var builder = new StringBuilder(
                          newValue.Length > oldValue.Length ? s.Length + s.Length / 2 : s.Length);
        _ = builder.Append(s);

        int idx = s.Length;

        while (idx > -1)
        {
            idx = s.LastIndexOf(oldValue, idx, comparisonType);
            if (idx != -1)
            {
                _ = builder.Remove(idx, oldValue.Length).Insert(idx, newValue);
            }
            --idx;
        }

        return builder.ToString();
    }

#endif
}

