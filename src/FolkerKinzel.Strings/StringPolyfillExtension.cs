using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

/// <summary>Extension methods for the <see cref="string" /> class, which are used
/// as polyfills for methods from current .NET versions.</summary>
/// <remarks>To match the behavior of the original methods, these extension methods throw
/// a <see cref="NullReferenceException" /> when called on a <c>null</c> string.</remarks>
public static partial class StringPolyfillExtension
{
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1 ||  NETCOREAPP3_1 || NET5_0 

    /// <summary>Replaces all newlines in <paramref name="s" /> with 
    /// <see cref="Environment.NewLine" />.</summary>
    /// <param name="s">The source <see cref="string" />.</param>
    /// <returns>A <see cref="string" /> whose contents match the content of 
    /// <paramref name="s" />, but with all newline sequences replaced with 
    /// <see cref="Environment.NewLine" />.</returns>
    /// <remarks>
    /// <para>
    /// This is a polyfill for the .NET 6.0 method String.ReplaceLineEndings(). The method
    /// should therefore only be used in the extension method syntax. It throws a 
    /// <see cref="NullReferenceException" /> if <paramref name="s" /> is <c>null</c> in order 
    /// to show identical behavior to the original .NET method.
    /// </para>
    /// <para>
    /// The method searches for all newline sequences within <paramref name="s" /> and canonicalizes
    /// them to match the newline sequence for the current environment. For example, when
    /// running on Windows, all occurrences of non-Windows Newline sequences are replaced
    /// with the sequence CRLF. When running on Unix, all occurrences of non-Unix Newline
    /// sequences are replaced with a single LF character.
    /// </para>
    /// <para>
    /// The list of recognized newline sequences is:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// CR (U+000D)
    /// </item>
    /// <item>
    /// LF (U+000A)
    /// </item>
    /// <item>
    /// CRLF (U+000D U+000A)
    /// </item>
    /// <item>
    /// NEL (U+0085)
    /// </item>
    /// <item>
    /// LS (U+2028)
    /// </item>
    /// <item>
    /// FF (U+000C)
    /// </item>
    /// <item>
    /// PS (U+2029)
    /// </item>
    /// </list>
    /// <para>
    /// This list is specified by the Unicode standard (Sec. 5.8, Recommendation R4 and Table
    /// 5-2).
    /// </para>
    /// </remarks>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ReplaceLineEndings(this string s)
        => s.ReplaceLineEndings(Environment.NewLine);

    /// <summary>Replaces all newlines in <paramref name="s" /> with 
    /// <paramref name="replacementText" />.</summary>
    /// <param name="s">The source <see cref="string" />.</param>
    /// <param name="replacementText">The text to use as replacement. If 
    /// <paramref name="replacementText" /> is <see cref="string.Empty" />, all newline 
    /// sequences within <paramref name="s" /> will be removed.</param>
    /// <returns>A <see cref="string" /> whose contents match the content of 
    /// <paramref name="s" />, but with all newline sequences replaced with 
    /// <paramref name="replacementText" />.</returns>
    /// <remarks>
    /// <para>
    /// This is a polyfill for the .NET 6.0 method String.ReplaceLineEndings(String). The
    /// method should therefore only be used in the extension method syntax. It throws a
    /// <see cref="NullReferenceException" /> if <paramref name="s" /> is <c>null</c> in
    /// order to show identical behavior to the original .NET method.
    /// </para>
    /// <para>
    /// The method searches for all newline sequences within <paramref name="s" /> and 
    /// canonicalizes them to match <paramref name="replacementText" />.
    /// </para>
    /// <para>
    /// The list of recognized newline sequences is:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// CR (U+000D)
    /// </item>
    /// <item>
    /// LF (U+000A)
    /// </item>
    /// <item>
    /// CRLF (U+000D U+000A)
    /// </item>
    /// <item>
    /// NEL (U+0085)
    /// </item>
    /// <item>
    /// LS (U+2028)
    /// </item>
    /// <item>
    /// FF (U+000C)
    /// </item>
    /// <item>
    /// PS (U+2029)
    /// </item>
    /// </list>
    /// <para>
    /// This list is specified by the Unicode standard (Sec. 5.8, Recommendation R4 and Table
    /// 5-2).
    /// </para>
    /// </remarks>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentNullException"> <paramref name="replacementText" /> is <c>null</c>.
    /// </exception>
    public static string ReplaceLineEndings(this string s, string replacementText)
    {
        if (s is null)
        {
            throw new NullReferenceException();
        }

        _ArgumentNullException.ThrowIfNull(replacementText, nameof(replacementText));

        for (int i = 0; i < s.Length; i++)
        {
            switch (s[i])
            {
                case '\r': // CR: Carriage Return
                case '\n': // LF: Line Feed
                //case '\u000B': // VT: Vertical Tab
                case '\u000C': // FF: Form Feed
                case '\u0085': // NEL: Next Line
                case '\u2028': // LS: Line Separator
                case '\u2029': // PS: Paragraph Separator
                    var sb = new StringBuilder(s.Length + s.Length / 2);
                    return sb.Append(s).ReplaceLineEndings(replacementText, i).ToString();
                default:
                    break;
            }
        }

        return s;
    }

#endif


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
    public static int IndexOf(this string s, char value, StringComparison comparisonType)
        => s is null ? throw new NullReferenceException()
                     : s.AsSpan().IndexOf(stackalloc[] { value }, comparisonType);

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

    /// <summary>Indicates whether <paramref name="s" /> starts with the specified character.</summary>
    /// <param name="s">The <see cref="string" /> to search.</param>
    /// <param name="value">The Unicode character to compare.</param>
    /// <returns> <c>true</c> if value matches the beginning of <paramref name="s" />; otherwise,
    /// <c>false</c>.</returns>
    /// <remarks>This method performs a word (case-sensitive and culture-sensitive) comparison
    /// using the current culture.</remarks>
    /// <exception cref="NullReferenceException"> <paramref name="s" /> is <c>null</c>.</exception>
    public static bool StartsWith(this string s, char value)
        => s is null ? throw new NullReferenceException()
                     : s.AsSpan().StartsWith(stackalloc char[] { value }, StringComparison.CurrentCulture);

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

        if (s is null)
        {
            throw new NullReferenceException();
        }

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

