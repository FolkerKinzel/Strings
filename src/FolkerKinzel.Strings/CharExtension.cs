using System.ComponentModel;
using FolkerKinzel.Strings.Properties;

namespace FolkerKinzel.Strings;

/// <summary>Extension methods for the <see cref="char" /> struct.</summary>
public static class CharExtension
{
    /// <summary>Indicates whether a character is within the specified inclusive range.</summary>
    /// <param name="c">The character to evaluate.</param>
    /// <param name="minInclusive">The lower bound, inclusive.</param>
    /// <param name="maxInclusive">The upper bound, inclusive.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> is within the specified range; otherwise,
    /// false.</returns>
    /// <remarks>The method does not validate that <paramref name="maxInclusive" /> is greater
    /// than or equal to <paramref name="minInclusive" />. If <paramref name="maxInclusive"
    /// /> is less than <paramref name="minInclusive" />, the behavior is undefined.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsBetween(this char c, char minInclusive, char maxInclusive)
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1 || NETCOREAPP3_1 || NET5_0 || NET6_0 
        => (c >= minInclusive) && (c <= maxInclusive);
#else
        => char.IsBetween(c, minInclusive, maxInclusive);
#endif

    /// <summary>Indicates whether a character is categorized as a lowercase ASCII letter.</summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> is a lowercase ASCII letter; otherwise
    /// <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAsciiLetterLower(this char c)
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1 || NETCOREAPP3_1 || NET5_0 || NET6_0 
        => c.IsBetween('a', 'z');
#else
        => char.IsAsciiLetterLower(c);
#endif

    /// <summary>Indicates whether a character is categorized as an uppercase ASCII letter.</summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> is an uppercase ASCII letter; otherwise
    /// <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAsciiLetterUpper(this char c)
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1 || NETCOREAPP3_1 || NET5_0 || NET6_0 
        => c.IsBetween('A', 'Z');
#else
        => char.IsAsciiLetterUpper(c);
#endif

    /// <summary>Examines whether the Unicode character is an ASCII letter.</summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> is an ASCII letter, otherwise <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAsciiLetter(this char c)
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1 || NETCOREAPP3_1 || NET5_0 || NET6_0 
        => ((char)(c | 32)).IsAsciiLetterLower();
#else
        => char.IsAsciiLetter(c);
#endif

    /// <summary>Indicates whether a character is categorized as an ASCII letter [A-Za-z]
    /// or digit [0-9].</summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> is an ASCII letter or digit, otherwise
    /// <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAsciiLetterOrDigit(this char c)
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1 || NETCOREAPP3_1 || NET5_0 || NET6_0 
        => c.IsAsciiLetter() || c.IsAsciiDigit();
#else
        => char.IsAsciiLetterOrDigit(c);
#endif

    /// <summary>Gets the value of a hexadecimal digit.</summary>
    /// <param name="digit">The hexadecimal digit to convert (0-9, a-f, A-F).</param>
    /// <returns>A number from 0 to 15 that corresponds to the specified hexadecimal digit.</returns>
    /// <remarks>Ruft <see cref="Uri.FromHex(char)" /> auf.</remarks>
    /// <exception cref="ArgumentException"> <paramref name="digit" /> is not a valid hexadecimal
    /// digit (0-9, a-f, A-F).</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ParseHexDigit(this char digit)
        => Uri.FromHex(digit);

    /// <summary>Tries to interpret a character as a hexadecimal digit and to return the
    /// value that this hexadecimal digit represents.</summary>
    /// <param name="digit">The Unicode character to analyze.</param>
    /// <param name="value">After the method has been successfully completed, it contains
    /// the value that <paramref name="digit" /> represents as a hexadecimal digit, otherwise
    /// <c>null</c>. The parameter is passed uninitialized.</param>
    /// <returns> <c>true</c> if <paramref name="digit" /> represents a hexadecimal digit,
    /// otherwise <c>false</c>.</returns>
    public static bool TryParseHexDigit(this char digit, [NotNullWhen(true)] out int? value)
    {
        if (digit.IsAsciiHexDigit())
        {
            value = Uri.FromHex(digit);
            return true;
        }

        value = null;
        return false;
    }

    /// <summary>Tries to interpret a character as a decimal digit (0-9) and to return the
    /// value that this decimal digit represents.</summary>
    /// <param name="digit">The Unicode character to analyze.</param>
    /// <param name="value">After the method has been successfully completed, it contains
    /// the value that <paramref name="digit" /> represents as a decimal digit, otherwise
    /// <c>null</c>. The parameter is passed uninitialized.</param>
    /// <returns> <c>true</c> if <paramref name="digit" /> represents a decimal digit, otherwise
    /// <c>false</c>.</returns>
    public static bool TryParseDecimalDigit(this char digit, [NotNullWhen(true)] out int? value)
    {
        if (digit.IsAsciiDigit())
        {
            value = (int)digit - 48;
            return true;
        }

        value = null;
        return false;
    }

    /// <summary>Tries to interpret a character as a binary digit (0 or 1) and to return
    /// the value that this binary digit represents.</summary>
    /// <param name="digit">The Unicode character to analyze.</param>
    /// <param name="value">After the method has been successfully completed, it contains
    /// the value that <paramref name="digit" /> represents as a binary digit, otherwise
    /// <c>null</c>. The parameter is passed uninitialized.</param>
    /// <returns> <c>true</c> if <paramref name="digit" /> represents a binary digit, otherwise
    /// <c>false</c>.</returns>
    public static bool TryParseBinaryDigit(this char digit, [NotNullWhen(true)] out int? value)
    {
        if (digit.IsBinaryDigit())
        {
            value = digit == '1' ? 1 : 0;
            return true;
        }

        value = null;
        return false;
    }

    /// <summary>Gets the value of a binary digit.</summary>
    /// <param name="digit">The binary digit to convert (0 or 1).</param>
    /// <returns>A number that corresponds to the specified binary digit.</returns>
    /// <exception cref="ArgumentException"> <paramref name="digit" /> is not a valid binary
    /// digit (0 or 1).</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ParseBinaryDigit(this char digit)
        => TryParseBinaryDigit(digit, out int? value)
            ? value.Value
            : throw new ArgumentException(
                string.Format(Res.NoBinaryDigit, nameof(digit)), nameof(digit));

    /// <summary>Gets the value of a decimal digit (0-9).</summary>
    /// <param name="digit">The decimal digit to convert (0-9).</param>
    /// <returns>A number from 0 to 9 that corresponds to the specified decimal digit.</returns>
    /// <exception cref="ArgumentException"> <paramref name="digit" /> is not a valid decimal
    /// digit (0-9).</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ParseDecimalDigit(this char digit)
        => TryParseDecimalDigit(digit, out int? value)
            ? value.Value
            : throw new ArgumentException(
                string.Format(Res.NoDecimalDigit, nameof(digit)), nameof(digit));

    /// <summary>Indicates whether the Unicode character belongs to the ASCII character set.</summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> is part of the ASCII character set,
    /// otherwise <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAscii(this char c)
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1 || NETCOREAPP3_1 || NET5_0 
        => 128u > c;
#else
        => char.IsAscii(c);
#endif

    /// <summary>Indicates whether a character is categorized as an ASCII digit [0-9].</summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> is an ASCII digit, otherwise <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAsciiDigit(this char c)
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1 || NETCOREAPP3_1 || NET5_0 || NET6_0 
        => c.IsBetween('0', '9');
#else
        => char.IsAsciiDigit(c);
#endif

    /// <summary>Indicates whether a character is categorized as an ASCII hexademical digit
    /// [0-9a-fA-F].</summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> is a hexadecimal digit; otherwise
    /// <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAsciiHexDigit(this char c)
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1 || NETCOREAPP3_1 || NET5_0 || NET6_0 
        => Uri.IsHexDigit(c);
#else
        => char.IsAsciiHexDigit(c);
#endif

    /// <summary>Indicates whether a character is categorized as an ASCII lower-case hexademical
    /// digit [0-9a-f].</summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> is a lower-case hexadecimal digit;
    /// otherwise <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAsciiHexDigitLower(this char c)
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1 || NETCOREAPP3_1 || NET5_0 || NET6_0 
        => c.IsAsciiHexDigit() && !c.IsAsciiLetterUpper();
#else
        => char.IsAsciiHexDigitLower(c);
#endif

    /// <summary>Indicates whether a character is categorized as an ASCII upper-case hexadecimal
    /// digit [0-9A-F].</summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> is an upper-case hexadecimal digit;
    /// otherwise <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAsciiHexDigitUpper(this char c)
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1 || NETCOREAPP3_1 || NET5_0 || NET6_0 
        => c.IsAsciiHexDigit() && !c.IsAsciiLetterLower();
#else
        => char.IsAsciiHexDigitUpper(c);
#endif

    /// <summary>Indicates whether the Unicode character is a binary digit (0 or 1).</summary>
    /// <param name="c">The character to evaluate.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> represents a binary digit, otherwise
    /// <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsBinaryDigit(this char c) => c is '0' or '1';

    /// <summary>Indicates whether the Unicode character is categorized as a control character.</summary>
    /// <param name="c">The Unicode character to examine.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> is categorized as a control character,
    /// otherwise <c>false</c>.</returns>
    /// <remarks> Calls <see cref="char.IsControl(char)" />. </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsControl(this char c) => char.IsControl(c);

    /// <summary>Indicates whether the Unicode character is categorized as a member of the
    /// Unicode category "Decimal Digit Number".</summary>
    /// <param name="c">The Unicode character to examine.</param>
    /// <returns> <c>true</c>, if <paramref name="c" /> is categorized as a member of the
    /// Unicode category "Decimal Digit Number", otherwise <c>false</c>.</returns>
    /// <remarks>
    /// <para>
    /// Calls <see cref="char.IsDigit(char)" />.
    /// </para>
    /// <note type="tip">
    /// The Unicode category "Decimal Digit Number" includes many more characters than the 
    /// digits 0-9. Use the method <see cref="CharExtension.IsAsciiDigit(char)" /> if you want 
    /// to check for the characters 0-9. 
    /// </note>
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDigit(this char c) => char.IsDigit(c);

    /// <summary>Indicates whether the Unicode character is a high surrogate.</summary>
    /// <param name="c">The Unicode character to examine.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> is a high surrogate, otherwise <c>false</c>.</returns>
    /// <remarks> Calls <see cref="char.IsHighSurrogate(char)" />. </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsHighSurrogate(this char c) => char.IsHighSurrogate(c);

    /// <summary>Indicates whether the Unicode character is a low surrogate.</summary>
    /// <param name="c">The Unicode character to examine.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> is a low surrogate, otherwise <c>false</c>.</returns>
    /// <remarks> Calls <see cref="char.IsLowSurrogate(char)" />. </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLowSurrogate(this char c) => char.IsLowSurrogate(c);

    /// <summary>Indicates whether the Unicode character has a surrogate code unit.</summary>
    /// <param name="c">The Unicode character to examine.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> has a surrogate code unit, otherwise
    /// <c>false</c>.</returns>
    /// <remarks> Calls <see cref="char.IsSurrogate(char)" />. </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsSurrogate(this char c) => char.IsSurrogate(c);

    /// <summary>Indicates whether the Unicode character is categorized as a Unicode letter.</summary>
    /// <param name="c">The Unicode character to examine.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> is categorized as a Unicode letter,
    /// otherwise <c>false</c>.</returns>
    /// <remarks> Calls <see cref="char.IsLetter(char)" />. </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLetter(this char c) => char.IsLetter(c);

    /// <summary>Indicates whether the Unicode character is categorized as a Unicode letter
    /// or decimal digit.</summary>
    /// <param name="c">The Unicode character to examine.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> is categorized as a Unicode letter
    /// or decimal digit, otherwise <c>false</c>.</returns>
    /// <remarks> Calls <see cref="char.IsLetterOrDigit(char)" />. </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLetterOrDigit(this char c) => char.IsLetterOrDigit(c);

    /// <summary>Indicates whether the Unicode character is categorized as a lowercase letter.</summary>
    /// <param name="c">The Unicode character to examine.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> is categorized as a lowercase letter,
    /// otherwise <c>false</c>.</returns>
    /// <remarks> Calls <see cref="char.IsLower(char)" />. </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLower(this char c) => char.IsLower(c);

    /// <summary>Indicates whether the Unicode character is categorized as a uppercase letter.</summary>
    /// <param name="c">The Unicode character to examine.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> is categorized as a uppercase letter,
    /// otherwise <c>false</c>.</returns>
    /// <remarks> Calls <see cref="char.IsUpper(char)" />. </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsUpper(this char c) => char.IsUpper(c);

    /// <summary>Indicates whether the Unicode character is categorized as a number.</summary>
    /// <param name="c">The Unicode character to examine.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> is categorized as a number, otherwise
    /// <c>false</c>.</returns>
    /// <remarks> Calls <see cref="char.IsNumber(char)" />. </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNumber(this char c) => char.IsNumber(c);

    /// <summary>Indicates whether the Unicode character is categorized as a punctuation
    /// mark.</summary>
    /// <param name="c">The Unicode character to examine.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> is categorized as a punctuation mark,
    /// otherwise <c>false</c>.</returns>
    /// <remarks> Calls <see cref="char.IsPunctuation(char)" />. </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsPunctuation(this char c) => char.IsPunctuation(c);

    /// <summary>Indicates whether the Unicode character is categorized as a separator character.</summary>
    /// <param name="c">The Unicode character to examine.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> is categorized as a separator character,
    /// otherwise <c>false</c>.</returns>
    /// <remarks> Calls <see cref="char.IsSeparator(char)" />. </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsSeparator(this char c) => char.IsSeparator(c);

    /// <summary>Indicates whether the Unicode character is categorized as a symbol character.</summary>
    /// <param name="c">The Unicode character to examine.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> is categorized as a symbol character,
    /// otherwise <c>false</c>.</returns>
    /// <remarks> Calls <see cref="char.IsSymbol(char)" />. </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsSymbol(this char c) => char.IsSymbol(c);

    /// <summary>Indicates whether the Unicode character is categorized as white space.</summary>
    /// <param name="c">The Unicode character to examine.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> is categorized as white space, otherwise
    /// <c>false</c>.</returns>
    /// <remarks>Calls <see cref="char.IsWhiteSpace(char)" />.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsWhiteSpace(this char c) => char.IsWhiteSpace(c);

    /// <summary>Converts the value of a Unicode character to its lowercase equivalent using
    /// the casing rules of the invariant culture.</summary>
    /// <param name="c">The Unicode character to convert.</param>
    /// <returns>The lowercase equivalent of the <paramref name="c" /> parameter, or the
    /// unchanged value of <paramref name="c" />, if <paramref name="c" /> is already lowercase
    /// or not alphabetic.</returns>
    /// <remarks> Calls <see cref="char.ToLowerInvariant(char)" />. </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToLowerInvariant(this char c) => char.ToLowerInvariant(c);

    /// <summary>Converts the value of a Unicode character to its uppercase equivalent using
    /// the casing rules of the invariant culture.</summary>
    /// <param name="c">The Unicode character to convert.</param>
    /// <returns>The uppercase equivalent of the <paramref name="c" /> parameter, or the
    /// unchanged value of <paramref name="c" />, if <paramref name="c" /> is already uppercase
    /// or not alphabetic.</returns>
    /// <remarks> Calls <see cref="char.ToUpperInvariant(char)" />. </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToUpperInvariant(this char c) => char.ToUpperInvariant(c);

    /// <summary>Indicates whether the Unicode character is categorized as a newline character.</summary>
    /// <param name="c">The Unicode character to examine.</param>
    /// <returns> <c>true</c> if <paramref name="c" /> is categorized as a newline character,
    /// otherwise <c>false</c>.</returns>
    /// <remarks>
    /// <para>
    /// The following characters are recognized as newline characters:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// CR: Carriage Return (U+000D)
    /// </item>
    /// <item>
    /// LF: Line Feed (U+000A)
    /// </item>
    /// <item>
    /// FF: Form Feed (U+000C)
    /// </item>
    /// <item>
    /// NEL: Next Line (U+0085)
    /// </item>
    /// <item>
    /// LS: Line Separator (U+2028)
    /// </item>
    /// <item>
    /// PS: Paragraph Separator (U+2029)
    /// </item>
    /// </list>
    /// </remarks>
    [SuppressMessage("Style", "IDE0066:Convert switch statement to expression", 
        Justification = "More readable")]
    public static bool IsNewLine(this char c)
    {
        switch (c)
        {
            case '\r': // CR: Carriage Return
            case '\n': // LF: Line Feed
            //case '\u000B': // VT: Vertical Tab
            case '\f': // FF: Form Feed
            //case '\u000C': // FF: Form Feed
            case '\u0085': // NEL: Next Line
            case '\u2028': // LS: Line Separator
            case '\u2029': // PS: Paragraph Separator
                return true;
            default:
                return false;
        }
    }
}
