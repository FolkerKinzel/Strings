namespace FolkerKinzel.Strings;

public static partial class SpanExtension
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
    /// Diese Spezialisierung der Erweiterungsmethode MemoryExtensions.LastIndexOfAny&lt;T&gt;(Span&lt;T&gt;, ReadOnlySpan&lt;T&gt;)
    /// für den Datentyp <see cref="char"/> wird benötigt, um Performanceprobleme zu vermeiden.
    /// </para>
    /// <para>
    /// Wenn die Länge von <paramref name="values"/> kleiner als 5 ist, verwendet die Methode für den Vergleich 
    /// <see cref="MemoryExtensions.LastIndexOfAny{T}(Span{T}, ReadOnlySpan{T})">MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;)</see>.
    /// Ist die Länge von <paramref name="values"/>
    /// größer, wird <see cref="string.LastIndexOfAny(char[])">String.LastIndexOfAny(char[])</see> verwendet.
    /// </para>
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOfAny(this Span<char> span, ReadOnlySpan<char> values)
    => ((ReadOnlySpan<char>)span).LastIndexOfAny(values);


    /// <summary>
    /// Gibt die nullbasierte Indexposition des letzten Vorkommens eines der angegebenen Zeichen 
    /// in <paramref name="span"/> an. Die Suche beginnt an einer angegebenen Zeichenposition 
    /// und verläuft für eine angegebene Anzahl von Zeichenpositionen rückwärts zum Anfang der Zeichenfolge.
    /// </summary>
    /// <param name="span">Die zu durchsuchende Zeichenspanne.</param>
    /// <param name="values">Eine schreibgeschützte Zeichenspanne, die die zu suchenden Zeichen enthält.</param>
    /// <param name="startIndex">Die Anfangsposition der Suche. Die Suche erfolgt rückwärts zum Anfang 
    /// von <paramref name="span"/>.</param>
    /// <param name="count">Die Anzahl der zu überprüfenden Zeichenpositionen in <paramref name="span"/>.</param>
    /// <returns>Der nullbasierte Index des letzten Vorkommens eines beliebigen Zeichens aus <paramref name="values"/>
    /// in <paramref name="span"/> oder -1, wenn keines dieser Zeichen gefunden wurde.</returns>
    /// <remarks>
    /// Wenn die Länge von <paramref name="values"/> kleiner als 5 ist, verwendet die Methode für den Vergleich 
    /// <see cref="MemoryExtensions.LastIndexOfAny{T}(Span{T}, ReadOnlySpan{T})">MemoryExtensions.LastIndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;)</see>.
    /// Ist die Länge von <paramref name="values"/>
    /// größer, wird <see cref="string.LastIndexOfAny(char[])">String.LastIndexOfAny(char[])</see> verwendet.
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="span"/> ist nicht <see cref="Span{T}.Empty"/> und <paramref name="startIndex"/> ist 
    /// kleiner als 0 oder größer oder gleich der Länge von <paramref name="span"/>
    /// </para>
    /// <para>
    /// - oder -
    /// </para>
    /// <para>
    /// <paramref name="span"/> ist nicht <see cref="Span{T}.Empty"/> und <paramref name="startIndex"/> - <paramref name="count"/> + 1 
    /// ist kleiner als 0.
    /// </para>
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOfAny(this Span<char> span, ReadOnlySpan<char> values, int startIndex, int count)
    => ((ReadOnlySpan<char>)span).LastIndexOfAny(values, startIndex, count);


}
