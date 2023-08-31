namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    /// <summary>
    /// Gibt an, ob die Zeichenspanne ein Leerraumzeichen enthält.
    /// </summary>
    /// <param name="span">Die zu durchsuchende Spanne.</param>
    /// <returns><c>true</c>, wenn <paramref name="span"/> ein Leerraumzeichen enthält, andernfalls <c>false</c>.</returns>
    /// <remarks>Für den Vergleich wird <see cref="char.IsWhiteSpace(char)"/> verwendet.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsWhiteSpace(this Span<char> span)
    => ((ReadOnlySpan<char>)span).ContainsWhiteSpace();
}
