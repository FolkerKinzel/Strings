using System.Runtime.CompilerServices;

namespace FolkerKinzel.Strings;

public static partial class StringExtension
{
    // This is a polyfill, but it should NOT be in the namespace FolkerKinzel.Strings.Polyfills
    // to be available for .NET Core 3.1:
#if NET5_0 || NETSTANDARD || NET45

    /// <summary>
    /// Ersetzt alle Newlinesequenzen in <paramref name="s"/> durch <see cref="Environment.NewLine"/>.
    /// </summary>
    /// <param name="s">Der Quell-<see cref="string"/>.</param>
    /// <returns>Eine <see cref="string"/>, dessen Inhalt mit <paramref name="s"/> übereinstimmt - außer, dass alle Newlinesequenzen durch 
    /// <see cref="Environment.NewLine"/> ersetzt wurden.</returns>
    /// <remarks>
    /// <para>
    /// Die Methode ist ein Polyfill für die .NET 6.0-Methode String.ReplaceLineEndings(). Die Methode sollte deshalb nur in der 
    /// Erweiterungsmethodensyntax verwendet werden. Sie wirft eine <see cref="NullReferenceException"/>, wenn <paramref name="s"/>&#160;
    /// <c>null</c> ist, um ein identisches Verhalten mit der originalen .NET-Methode zu zeigen.
    /// </para>
    /// <para>
    /// Diese Methode sucht nach allen Newlinesequenzen innerhalb von <paramref name="s"/> und kanonisiert sie so, dass sie mit der 
    /// Newlinesequenz für die aktuelle Umgebung übereinstimmen. Wenn z.B. auf Windows ausgeführt wird, werden alle Vorkommen von Nicht-Windows 
    /// Newlinesequenzen durch die Sequenz CRLF ersetzt. Bei der Ausführung unter Unix werden alle Vorkommen von Nicht-Unix-Newlinesequenzen durch
    /// ein einzelnes LF-Zeichen ersetzt.
    /// </para>
    /// <para>
    /// Die Liste der behandelten Newlinesequenzen ist:
    /// </para>
    /// <list type="bullet">
    /// <item>CR (U+000D)</item>
    /// <item>LF (U+000A)</item>
    /// <item>CRLF (U+000D U+000A)</item>
    /// <item>NEL(U+0085)</item>
    /// <item>LS(U+2028)</item>
    /// <item>FF(U+000C)</item>
    /// <item>PS(U+2029)</item>
    /// </list>
    /// <para>
    /// Diese Liste ist vom Unicode-Standard vorgegeben (Sec. 5.8, Recommendation R4 und Table 5-2).
    /// </para>
    /// </remarks>
    /// <exception cref="NullReferenceException"><paramref name="s"/> ist <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ReplaceLineEndings(this string s)
        => s.ReplaceLineEndings(Environment.NewLine);


    /// <summary>
    /// Ersetzt alle Newlinesequenzen in <paramref name="s"/> durch <paramref name="replacementText"/>.
    /// </summary>
    /// <param name="s">Der Quell-<see cref="string"/>.</param>
    /// <param name="replacementText">Der Text, der als Ersatz verwendet werden soll. Wenn <paramref name="replacementText"/>&#160;
    /// <see cref="string.Empty"/> ist, werden alle Newlinesequenzen entfernt.</param>
    /// <returns>Ein <see cref="string"/>, dessen Inhalt mit <paramref name="s"/> übereinstimmt - außer, dass alle Newlinesequenzen durch 
    /// <paramref name="replacementText"/> ersetzt wurden.</returns>
    /// <remarks>
    /// <para>
    /// Die Methode ist ein Polyfill für die .NET 6.0-Methode String.ReplaceLineEndings(String). Die Methode sollte deshalb nur in der 
    /// Erweiterungsmethodensyntax verwendet werden. Sie wirft eine <see cref="NullReferenceException"/>, wenn <paramref name="s"/>&#160;
    /// <c>null</c> ist, um ein identisches Verhalten mit der originalen .NET-Methode zu zeigen.
    /// </para>
    /// <para>
    /// Die Liste der behandelten Newlinesequenzen ist:
    /// </para>
    /// <list type="bullet">
    /// <item>CR (U+000D)</item>
    /// <item>LF (U+000A)</item>
    /// <item>CRLF (U+000D U+000A)</item>
    /// <item>NEL(U+0085)</item>
    /// <item>LS(U+2028)</item>
    /// <item>FF(U+000C)</item>
    /// <item>PS(U+2029)</item>
    /// </list>
    /// <para>
    /// Diese Liste ist vom Unicode-Standard vorgegeben (Sec. 5.8, Recommendation R4 und Table 5-2).
    /// </para>
    /// </remarks>
    /// <exception cref="NullReferenceException"><paramref name="s"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="replacementText"/> ist <c>null</c>.</exception>
    public static string ReplaceLineEndings(this string s, string replacementText)
    {
        if (s is null)
        {
            throw new NullReferenceException();
        }

        if (replacementText is null)
        {
            throw new ArgumentNullException(nameof(replacementText));
        }

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

}
