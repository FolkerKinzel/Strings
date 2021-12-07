namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    /// <summary>
    /// Gibt den Index des ersten Nicht-Leerraumzeichens in der schreibgeschützten Zeichenspanne zurück.
    /// </summary>
    /// <param name="span">Die zu untersuchende Zeichenspanne.</param>
    /// <returns>Der Index des ersten Nicht-Leerraumzeichens in der schreibgeschützten Zeichenspanne.
    /// Wenn die Spanne leer ist oder nur aus Leerraum besteht, entspricht der Rückgabewert der Länge
    /// der Spanne.</returns>
    public static int GetTrimmedStart(this ReadOnlySpan<char> span)
    {
        for (int i = 0; i < span.Length; i++)
        {
            if (!char.IsWhiteSpace(span[i]))
            {
                return i;
            }
        }

        return span.Length;
    }
}
