namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    /// <summary>
    /// Gibt den Index des ersten Nicht-Leerraumzeichens in der Zeichenspanne zurück.
    /// </summary>
    /// <param name="span">Die zu untersuchende Zeichenspanne.</param>
    /// <returns>Der Index des ersten Nicht-Leerraumzeichens in der Zeichenspanne.
    /// Wenn die Spanne leer ist oder nur aus Leerraum besteht, entspricht der Rückgabewert der Länge
    /// der Spanne.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetTrimmedStart(this Span<char> span)
    => ((ReadOnlySpan<char>)span).GetTrimmedStart();
}
