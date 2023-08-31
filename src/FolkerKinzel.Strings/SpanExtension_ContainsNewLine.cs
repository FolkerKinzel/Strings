namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    /// <summary>
    /// Gibt an, ob die Zeichenspanne ein Zeilenwechselzeichen enthält.
    /// </summary>
    /// <param name="span">Die zu durchsuchende Spanne.</param>
    /// <returns><c>true</c>, wenn <paramref name="span"/> ein Zeilenwechselzeichen enthält, andernfalls <c>false</c>.</returns>
    /// <remarks>Für den Vergleich wird <see cref="CharExtension.IsNewLine(char)"/> verwendet.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsNewLine(this Span<char> span)
    => ((ReadOnlySpan<char>)span).ContainsNewLine();
}
