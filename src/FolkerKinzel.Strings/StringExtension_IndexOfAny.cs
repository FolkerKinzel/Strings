namespace FolkerKinzel.Strings;

public static partial class StringExtension
{
    // Avoid overloads which pass the span around: This is for performance!

    /// <summary>
    /// Sucht nach dem NULL-basierten Index des ersten Vorkommens eines beliebigen Zeichens aus einer
    /// schreibgeschützten Zeichenspanne in <paramref name="s"/>. Die Suche beginnt an einer angegebenen 
    /// Zeichenposition, und es wird eine angegebene Anzahl von Zeichenpositionen überprüft.
    /// </summary>
    /// <param name="s">Der zu durchsuchende <see cref="string"/>.</param>
    /// <param name="anyOf">Eine schreibgeschützte Zeichenspanne, die die zu suchenden Zeichen enthält.</param>
    /// <param name="startIndex">Der NULL-basierte Index in <paramref name="s"/>, an dem die Suche beginnt.</param>
    /// <param name="count">Die Anzahl der in <paramref name="s"/> zu überprüfenden Zeichen.</param>
    /// <returns>Der NULL-basierte Index des ersten Vorkommens eines beliebigen Zeichens aus <paramref name="anyOf"/>
    /// in <paramref name="s"/> oder -1, wenn keines dieser Zeichen gefunden wurde. Wenn <paramref name="anyOf"/> eine
    /// leere Spanne ist, wird -1 zurückgegeben.</returns>
    /// <remarks>
    /// Wenn die Länge von <paramref name="anyOf"/> kleiner als 5 ist, verwendet die Methode für den Vergleich 
    /// <see cref="MemoryExtensions.IndexOfAny{T}(ReadOnlySpan{T}, ReadOnlySpan{T})">MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;)</see>. 
    /// Ist die Länge von <paramref name="anyOf"/>
    /// größer, wird <see cref="string.IndexOfAny(char[])">String.IndexOfAny(char[])</see> verwendet.
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> oder <paramref name="anyOf"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="startIndex"/> oder <paramref name="count"/> sind kleiner als 0
    /// </para>
    /// <para>
    /// - oder -
    /// </para>
    /// <para>
    /// <paramref name="startIndex"/> + <paramref name="count"/> ist größer als die Anzahl der Zeichen in
    /// <paramref name="s"/>.
    /// </para>
    /// </exception>
    public static int IndexOfAny(this string s, ReadOnlySpan<char> anyOf, int startIndex, int count)
    {
        if (s is null)
        {
            throw new ArgumentNullException(nameof(s));
        }

        // string.IndexOfAny returns -1 if anyOf is an empty array (although MSDN says it would return 0).
        // MemoryExtensions.IndexOfAny returns 0 if the span with the characters to search for is empty.
        // This makes it consistent:
        if (count == 0 || anyOf.IsEmpty)
        {
            return -1;
        }

        if (anyOf.Length <= 5)
        {
            int matchIndex = MemoryExtensions.IndexOfAny(s.AsSpan(startIndex, count), anyOf);
            return matchIndex == -1 ? -1 : matchIndex + startIndex;
        }

        return s.IndexOfAny(anyOf.ToArray(), startIndex, count);
    }
}
