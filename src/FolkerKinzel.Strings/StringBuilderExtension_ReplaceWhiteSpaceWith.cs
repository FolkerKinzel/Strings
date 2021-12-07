using System.Text.RegularExpressions;
using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>
    /// Ersetzt in <paramref name="builder"/> alle Sequenzen von Leerzeichen durch <paramref name="replacement"/>.
    /// </summary>
    /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt bearbeitet wird.</param>
    /// <param name="replacement">Eine schreibgeschützte Zeichenspanne, durch deren Inhalt die Leerzeichen-Sequenzen
    /// ersetzt werden.</param>
    /// <param name="skipNewLines">Übergeben Sie <c>true</c>, um Zeilenumbruchzeichen von der 
    /// Ersetzung auszunehmen. Der Standardwert ist <c>false</c>.</param>
    /// <returns>Eine Referenz auf <paramref name="builder"/></returns>
    /// <remarks>
    /// <para>
    /// Die Methode verwendet <see cref="char.IsWhiteSpace(char)"/> zur Identifizierung von Leerraumzeichen und arbeitet
    /// damit gründlicher als 
    /// <see cref="Regex.Replace(string, string, string)">Regex.Replace(string input, @"\s+", string replacement)</see>.
    /// </para>
    /// <para>(Zur Identifizierung von Zeilenumbruchzeichen wird <see cref="CharExtension.IsNewLine(char)"/>
    /// verwendet.)
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
    public static StringBuilder ReplaceWhiteSpaceWith(
        this StringBuilder builder,
        ReadOnlySpan<char> replacement,
        bool skipNewLines = false)
    => builder is null ? throw new ArgumentNullException(nameof(builder))
                       : builder.ReplaceWhiteSpaceWith(replacement, 0, builder.Length, skipNewLines);

    /// <summary>
    /// Ersetzt in einem Abschnitt von <paramref name="builder"/>, der bei <paramref name="startIndex"/> beginnt
    /// und bis zum Ende von <paramref name="builder"/> reicht, alle Sequenzen von Leerzeichen durch <paramref name="replacement"/>.
    /// </summary>
    /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt bearbeitet wird.</param>
    /// <param name="replacement">Eine schreibgeschützte Zeichenspanne, durch deren Inhalt die Leerzeichen-Sequenzen
    /// ersetzt werden.</param>
    /// <param name="startIndex">Der nullbasierte Index in <paramref name="builder"/>, an dem der Abschnitt beginnt,
    /// in dem die Ersetzungen vorgenommen werden.</param>
    /// <param name="skipNewLines">Übergeben Sie <c>true</c>, um Zeilenumbruchzeichen von der 
    /// Ersetzung auszunehmen. Der Standardwert ist <c>false</c>.</param>
    /// <returns>Eine Referenz auf <paramref name="builder"/></returns>
    /// <remarks>
    /// <para>
    /// Die Methode verwendet <see cref="char.IsWhiteSpace(char)"/> zur Identifizierung von Leerraumzeichen und arbeitet
    /// damit gründlicher als 
    /// <see cref="Regex.Replace(string, string, string)">Regex.Replace(string input, @"\s+", string replacement)</see>.
    /// </para>
    /// <para>(Zur Identifizierung von Zeilenumbruchzeichen wird <see cref="CharExtension.IsNewLine(char)"/>
    /// verwendet.)
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="startIndex"/> ist kleiner als 0 oder größer als die Anzahl der Zeichen in <paramref name="builder"/>.
    /// </exception>
    public static StringBuilder ReplaceWhiteSpaceWith(
        this StringBuilder builder,
        ReadOnlySpan<char> replacement,
        int startIndex,
        bool skipNewLines = false)
    => builder is null ? throw new ArgumentNullException(nameof(builder))
                       : builder.ReplaceWhiteSpaceWith(replacement, startIndex, builder.Length - startIndex, skipNewLines);

    /// <summary>
    /// Ersetzt in einem Abschnitt von <paramref name="builder"/>, der bei <paramref name="startIndex"/> beginnt
    /// und <paramref name="count"/> Zeichen umfasst, alle Sequenzen von Leerzeichen durch <paramref name="replacement"/>.
    /// </summary>
    /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt bearbeitet wird.</param>
    /// <param name="replacement">Eine schreibgeschützte Zeichenspanne, durch deren Inhalt die Leerzeichen-Sequenzen
    /// ersetzt werden.</param>
    /// <param name="startIndex">Der nullbasierte Index in <paramref name="builder"/>, an dem der Abschnitt beginnt,
    /// in dem die Ersetzungen vorgenommen werden.</param>
    /// <param name="count">Die Länge des Abschnitts, in dem Ersetzungen vorgenommen werden.</param>
    /// <param name="skipNewLines">Übergeben Sie <c>true</c>, um Zeilenumbruchzeichen von der 
    /// Ersetzung auszunehmen. Der Standardwert ist <c>false</c>.</param>
    /// <returns>Eine Referenz auf <paramref name="builder"/></returns>
    /// <remarks>
    /// <para>
    /// Die Methode verwendet <see cref="char.IsWhiteSpace(char)"/> zur Identifizierung von Leerraumzeichen und arbeitet
    /// damit gründlicher als 
    /// <see cref="Regex.Replace(string, string, string)">Regex.Replace(string input, @"\s+", string replacement)</see>.
    /// </para>
    /// <para>(Zur Identifizierung von Zeilenumbruchzeichen wird <see cref="CharExtension.IsNewLine(char)"/>
    /// verwendet.)
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="startIndex"/> oder <paramref name="count"/> ist kleiner als 0
    /// </para>
    /// <para>- oder -</para>
    /// <para>
    /// <paramref name="startIndex"/> + <paramref name="count"/>
    /// ist größer als die Anzahl der Zeichen in <paramref name="builder"/>.
    /// </para>
    /// </exception>
    public static StringBuilder ReplaceWhiteSpaceWith(
        this StringBuilder builder,
        ReadOnlySpan<char> replacement,
        int startIndex,
        int count,
        bool skipNewLines = false)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        if (startIndex < 0 || startIndex > builder.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex));
        }

        if (count < 0 || (count + startIndex) > builder.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        int wsLength = 0;

        for (int i = startIndex + count - 1; i >= startIndex; i--)
        {
            char current = builder[i];

            if (char.IsWhiteSpace(current) && (!skipNewLines || !current.IsNewLine()))
            {
                wsLength++;
            }
            else if (wsLength != 0)
            {
                int replacementIdx = i + 1;
                _ = builder.Remove(replacementIdx, wsLength).Insert(replacementIdx, replacement);
                wsLength = 0;
            }
        }

        if (wsLength != 0)
        {
            _ = builder.Remove(0, wsLength).Insert(0, replacement);
        }

        return builder;
    }

}
