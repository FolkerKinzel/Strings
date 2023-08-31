namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    /// <summary>
    /// Gibt die Länge zurück, die die Zeichenspanne ohne nachgestellten Leerraum hätte.
    /// </summary>
    /// <param name="span">Die zu untersuchende Zeichenspanne.</param>
    /// <returns>Die Länge, die <paramref name="span"/> ohne nachgestellten Leerraum hätte.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetTrimmedLength(this Span<char> span)
    => ((ReadOnlySpan<char>)span).GetTrimmedLength();




}
