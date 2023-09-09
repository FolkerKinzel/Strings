namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    /// <summary>
    /// Untersucht, ob die schreibgeschützte Zeichenspanne ausschließlich Unicode-Zeichen enthält,
    /// die zum ASCII-Zeichensatz gehören.
    /// </summary>
    /// <param name="span">Eine schreibgeschützte Spanne von Unicode-Zeichen.</param>
    /// <returns><c>false</c>, wenn <paramref name="span"/> ein Unicode-Zeichen enthält, das nicht zum 
    /// ASCII-Zeichensatz gehört, andernfalls <c>true</c>.</returns>
    public static bool IsAscii(this ReadOnlySpan<char> span)
    {
        for (int i = 0; i < span.Length; ++i)
        {
            if (!span[i].IsAscii())
            {
                return false;
            }
        }
        return true;
    }

}
