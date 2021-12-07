using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>
    /// Ersetzt alle Zeilenumbrüche in <paramref name="builder"/> durch <paramref name="newLine"/>.
    /// </summary>
    /// <param name="builder">Der <see cref="StringBuilder"/>, dessen Inhalt verändert wird.</param>
    /// <param name="newLine">Eine schreibgeschützte Zeichenspanne, durch deren Inhalt jeder Zeilenumbruch
    /// ersetzt wird. Wenn eine leere Spanne übergeben wird, werden alle Zeilenumbrüche entfernt.</param>
    /// <returns>Ein Verweis auf <paramref name="builder"/>.</returns>
    /// <remarks>
    /// Für die Identifizierung von Zeilenwechselzeichen wird <see cref="CharExtension.IsNewLine(char)"/> 
    /// verwendet. Die Sequenzen CRLF und LFCR werden als ein Zeilenumbruch behandelt.
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
    public static StringBuilder NormalizeNewLinesTo(this StringBuilder builder, ReadOnlySpan<char> newLine)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        bool skipR = false, skipN = false;
        for (int i = builder.Length - 1; i >= 0; i--)
        {
            char c = builder[i];

            if (skipR)
            {
                skipR = false;

                if (c == '\r')
                {
                    _ = builder.Remove(i, 2).Insert(i, newLine);
                    continue;
                }
                else
                {
                    _ = builder.Remove(i + 1, 1).Insert(i + 1, newLine);
                }
            }
            else if (skipN)
            {
                skipN = false;
                if (c == '\n')
                {
                    _ = builder.Remove(i, 2).Insert(i, newLine);
                    continue;
                }
                else
                {
                    _ = builder.Remove(i + 1, 1).Insert(i + 1, newLine);
                }
            }

            if (c == '\r')
            {
                skipN = true;
                continue;
            }
            else if (c == '\n')
            {
                skipR = true;
                continue;
            }
            else if (c.IsNewLine())
            {
                _ = builder.Remove(i, 1).Insert(i, newLine);
            }
        } //for

        if (skipN || skipR)
        {
            _ = builder.Remove(0, 1).Insert(0, newLine);
        }

        return builder;
    }
}
