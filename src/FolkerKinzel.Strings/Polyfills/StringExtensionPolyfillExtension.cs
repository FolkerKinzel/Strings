using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace FolkerKinzel.Strings.Polyfills;

/// <summary>
/// Erweiterungsmethoden, die als Polyfills für die Erweiterungsmethoden der Klasse <see cref="StringExtension"/>
/// dienen.
/// </summary>
/// <remarks>
/// Die Polyfills sind verfügbar für .NET Framework 4.5 und .NET Standard 2.0.
/// </remarks>
public static class StringExtensionPolyfillExtension
{
    // Place this preprocessor directive inside the class to let .NET 5.0 have an empty class!
#if NET45 || NETSTANDARD2_0
    /// <summary>
    /// Erzeugt einen neuen <see cref="string"/>, in dem alle Sequenzen von Leerzeichen in <paramref name="s"/> durch 
    /// <paramref name="replacement"/> ersetzt sind.
    /// </summary>
    /// <param name="s">Der Quell-<see cref="string"/>.</param>
    /// <param name="replacement">Ein <see cref="string"/>, durch den die Leerraumzeichen-Sequenzen
    /// ersetzt werden, oder <c>null</c>, um alle Leerzeichen zu entfernen.</param>
    /// <param name="skipNewLines">Übergeben Sie <c>true</c>, um Zeilenumbruchzeichen von der 
    /// Ersetzung auszunehmen. Der Standardwert ist <c>false</c>.</param>
    /// <returns>Ein neuer <see cref="string"/>, in in dem alle Sequenzen von Leerzeichen in <paramref name="s"/> durch 
    /// <paramref name="replacement"/> ersetzt sind. Wenn <paramref name="s"/> kein Leerzeichen enthält, wird <paramref name="s"/>
    /// zurückgegeben.</returns>
    /// <remarks>
    /// <para>
    /// Die Methode verwendet <see cref="char.IsWhiteSpace(char)"/> zur Identifizierung von Leerraumzeichen und arbeitet
    /// damit gründlicher als 
    /// <see cref="Regex.Replace(string, string, string)">Regex.Replace(string input, @"\s+", string replacement)</see>.
    /// </para>
    /// <para>Zur Identifizierung von Zeilenumbruchzeichen wird <see cref="CharExtension.IsNewLine(char)"/>
    /// verwendet.
    /// </para>
    /// <para>
    /// Diese Überladung ist nützlich, da die implizite Umwandlung von <see cref="string"/> in 
    /// <see cref="ReadOnlySpan{T}">ReadOnlySpan&lt;Char&gt;</see> erst ab .NET Standard 2.1 unterstützt wird.
    /// </para>
    /// 
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> ist <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ReplaceWhiteSpaceWith(
        this string s,
        string? replacement,
        bool skipNewLines = false)
        => s.ReplaceWhiteSpaceWith(replacement.AsSpan(), skipNewLines);


    /// <summary>
    /// Erzeugt einen neuen <see cref="string"/>, in dem alle Zeilenumbrüche
    /// durch <paramref name="newLine"/> ersetzt sind.
    /// </summary>
    /// <param name="s">Der Quellstring.</param>
    /// <param name="newLine">Ein <see cref="string"/>, durch den jeder Zeilenumbruch
    /// ersetzt wird, oder <c>null</c>, um alle Zeilenumbrüche zu entfernen.</param>
    /// <returns>Ein neuer <see cref="string"/>, in dem alle Zeilenumbrüche
    /// durch <paramref name="newLine"/> ersetzt sind. Wenn <paramref name="s"/> keine Zeilenwechselzeichen
    /// enthält, wird <paramref name="s"/> unverändert zurückgegeben.</returns>
    /// <remarks>
    /// <para>
    /// Für die Identifizierung von Zeilenwechselzeichen wird <see cref="CharExtension.IsNewLine(char)"/> 
    /// verwendet. Die Sequenzen CRLF und LFCR werden als ein Zeilenumbruch behandelt.
    /// </para>
    /// <note type="caution">
    /// Diese Methode unterscheidet sich von <see cref="StringExtension.ReplaceLineEndings(string, string)"/> dahingehend,
    /// dass sie zusätzlich LFCR-Sequenzen und Vertical Tab (VT: U+000B) als Zeilenwechsel behandelt.
    /// </note>
    /// <para>
    /// Diese Überladung ist nützlich, da die implizite Umwandlung von <see cref="string"/> in 
    /// <see cref="ReadOnlySpan{T}">ReadOnlySpan&lt;Char&gt;</see> erst ab .NET Standard 2.1 unterstützt wird.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> ist <c>null</c>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [Obsolete("Use ReplaceLineEndings instead.", false)]
    public static string NormalizeNewLinesTo(this string s, string? newLine)
        => s.NormalizeNewLinesTo(newLine.AsSpan());
#endif
}
