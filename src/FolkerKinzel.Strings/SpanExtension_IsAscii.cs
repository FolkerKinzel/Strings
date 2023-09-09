namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    /// <summary>
    /// Untersucht, ob die Zeichenspanne Unicode-Zeichen enthält,
    /// die nicht zum ASCII-Zeichensatz gehören.
    /// </summary>
    /// <param name="span">Eine Spanne von Unicode-Zeichen.</param>
    /// <returns><c>false</c>, wenn <paramref name="span"/> ein Unicode-Zeichen enthält, das nicht zum 
    /// ASCII-Zeichensatz gehört, andernfalls <c>true</c>.</returns>
    public static bool IsAscii(this Span<char> span)
    => ((ReadOnlySpan<char>)span).IsAscii();

}
