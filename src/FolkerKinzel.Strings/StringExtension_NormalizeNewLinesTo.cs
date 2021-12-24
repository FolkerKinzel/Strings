namespace FolkerKinzel.Strings;

public static partial class StringExtension
{
    /// <summary>
    /// Erzeugt einen neuen <see cref="string"/>, in dem alle Zeilenumbrüche
    /// durch <paramref name="newLine"/> ersetzt sind.
    /// </summary>
    /// <param name="s">Der Quellstring.</param>
    /// <param name="newLine">Eine schreibgeschützte Zeichenspanne, durch deren Inhalt jeder Zeilenumbruch
    /// ersetzt wird. Wenn eine leere Spanne übergeben wird, werden alle Zeilenumbrüche entfernt.</param>
    /// <returns>Ein neuer <see cref="string"/>, in dem alle Zeilenumbrüche
    /// durch <paramref name="newLine"/> ersetzt sind. Wenn <paramref name="s"/> keine Zeilenwechselzeichen
    /// enthält, wird <paramref name="s"/> unverändert zurückgegeben.</returns>
    /// <remarks>
    /// <para>
    /// Für die Identifizierung von Zeilenwechselzeichen wird <see cref="CharExtension.IsNewLine(char)"/> 
    /// verwendet. Die Sequenzen CRLF und LFCR werden als ein Zeilenumbruch behandelt.
    /// </para>
    /// <note type="caution">
    /// Diese Methode unterscheidet sich von <see cref="ReplaceLineEndings(string, string)"/> dahingehend,
    /// dass sie zusätzlich LFCR-Sequenzen und Vertical Tab (VT: U+000B) als Zeilenwechsel behandelt.
    /// </note>
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> ist <c>null</c>.</exception>
    [Obsolete("Use ReplaceLineEndings instead.", false)]
    public static string NormalizeNewLinesTo(this string s, ReadOnlySpan<char> newLine)
    {
        if (s is null)
        {
            throw new ArgumentNullException(nameof(s));
        }

        if (!s.ContainsNewLine())
        {
            return s;
        }

        var sb = new StringBuilder(s.Length + s.Length / 2);
        return sb.Append(s).NormalizeNewLinesTo(newLine).ToString();
    }


}
