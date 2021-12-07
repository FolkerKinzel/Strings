namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    /// <summary>
    /// Gibt die Länge zurück, die die schreibgeschützte Zeichenspanne ohne nachgestellten Leerraum hätte.
    /// </summary>
    /// <param name="span">Die zu untersuchende Zeichenspanne.</param>
    /// <returns>Die Länge, die <paramref name="span"/> ohne nachgestellten Leerraum hätte.</returns>
    public static int GetTrimmedLength(this ReadOnlySpan<char> span)
    {
        int length = span.Length;

        for (int i = length - 1; i >= 0; i--)
        {
            if (char.IsWhiteSpace(span[i]))
            {
                length--;
            }
            else
            {
                break;
            }
        }
        return length;
    }




}
