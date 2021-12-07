namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    /// <summary>
    /// Sucht nach dem NULL-basierten Index des letzten Vorkommens eines der angegebenen Unicode-Zeichen.
    /// </summary>
    /// <param name="span">Die zu untersuchende Spanne.</param>
    /// <param name="values">Eine schreibgeschützte Zeichenspanne, die die zu suchenden Zeichen enthält.</param>
    /// <returns>Der NULL-basierte Index des letzten Vorkommens eines beliebigen Zeichens aus <paramref name="values"/>
    /// in <paramref name="span"/> oder -1, wenn keines der Zeichen gefunden wurde. Wenn <paramref name="values"/> eine
    /// leere Spanne ist, wird -1 zurückgegeben</returns>
    /// <remarks>
    /// <para>
    /// Diese Spezialisierung der Erweiterungsmethode MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;)
    /// für den Datentyp <see cref="char"/> wird benötigt, um Performanceprobleme zu vermeiden.
    /// </para>
    /// <para>
    /// Wenn die Länge von <paramref name="values"/> kleiner als 5 ist, verwendet die Methode für den Vergleich 
    /// MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;).
    /// Ist die Länge von <paramref name="values"/>
    /// größer, wird <see cref="string.LastIndexOfAny(char[])"/> verwendet.
    /// </para>
    /// </remarks>
    public static int LastIndexOfAny(this ReadOnlySpan<char> span, ReadOnlySpan<char> values)
    {
        // string.LastIndexOfAny returns -1 if anyOf is an empty array (although MSDN says it would return 0).
        // MemoryExtensions.LastIndexOfAny returns 0 if the span with the characters to search for is empty.
        // This makes it consistent:
        return span.IsEmpty || values.IsEmpty
            ? -1
            : values.Length > 5 && span.Length > 2
                ? span.ToString().LastIndexOfAny(values.ToArray())
                : MemoryExtensions.LastIndexOfAny(span, values);
    }


    /// <summary>
    /// Gibt die nullbasierte Indexposition des letzten Vorkommens eines der angegebenen Zeichen 
    /// in <paramref name="span"/> an. Die Suche beginnt an einer angegebenen Zeichenposition 
    /// und verläuft für eine angegebene Anzahl von Zeichenpositionen rückwärts zum Anfang der Zeichenfolge.
    /// </summary>
    /// <param name="span">Die zu durchsuchende schreibgeschützte Zeichenspanne.</param>
    /// <param name="values">Eine schreibgeschützte Zeichenspanne, die die zu suchenden Zeichen enthält.</param>
    /// <param name="startIndex">Die Anfangsposition der Suche. Die Suche erfolgt rückwärts zum Anfang 
    /// von <paramref name="span"/>.</param>
    /// <param name="count">Die Anzahl der zu überprüfenden Zeichenpositionen in <paramref name="span"/>.</param>
    /// <returns>Der nullbasierte Index des letzten Vorkommens eines beliebigen Zeichens aus <paramref name="values"/>
    /// in <paramref name="span"/> oder -1, wenn keines dieser Zeichen gefunden wurde.</returns>
    /// <remarks>
    /// Wenn die Länge von <paramref name="values"/> kleiner als 5 ist, verwendet die Methode für den Vergleich 
    /// <see cref="MemoryExtensions.LastIndexOfAny{T}(ReadOnlySpan{T}, ReadOnlySpan{T})"/>. Ist die Länge von <paramref name="values"/>
    /// größer, wird <see cref="string.LastIndexOfAny(char[])"/> verwendet.
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="span"/> ist nicht <see cref="ReadOnlySpan{T}.Empty"/> und <paramref name="startIndex"/> ist 
    /// kleiner als 0 oder größer oder gleich der Länge von <paramref name="span"/>
    /// </para>
    /// <para>
    /// - oder -
    /// </para>
    /// <para>
    /// <paramref name="span"/> ist nicht <see cref="ReadOnlySpan{T}.Empty"/> und <paramref name="startIndex"/> - <paramref name="count"/> + 1 
    /// ist kleiner als 0.
    /// </para>
    /// </exception>
    /// 
    public static int LastIndexOfAny(this ReadOnlySpan<char> span, ReadOnlySpan<char> values, int startIndex, int count)
    {
        // string.LastIndexOfAny returns -1 if anyOf is an empty array (although MSDN says it would return 0).
        // MemoryExtensions.LastIndexOfAny returns 0 if the span with the characters to search for is empty.
        // This makes it consistent:
        if (count == 0 || values.IsEmpty)
        {
            return -1;
        }

        if (values.Length <= 5)
        {
            // MemoryExtensions.LastIndexOfAny throws ArgumentOutOfRangeExceptions even if s is ""
            // string.LastIndexOfAny does not.
            if (span.Length == 0)
            {
                return -1;
            }
            int matchIndex = MemoryExtensions.LastIndexOfAny(span.Slice(startIndex - count + 1, count), values);
            return matchIndex == -1 ? -1 : matchIndex + startIndex - count + 1;
        }

        return span.ToString().LastIndexOfAny(values.ToArray(), startIndex, count);
    }


}
