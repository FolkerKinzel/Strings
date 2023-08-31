namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    /// <summary>
    /// Sucht nach dem NULL-basierten Index des ersten Vorkommens eines der angegebenen Unicode-Zeichen.
    /// </summary>
    /// <param name="span">Die zu untersuchende Spanne.</param>
    /// <param name="values">Eine schreibgeschützte Zeichenspanne, die die zu suchenden Zeichen enthält.</param>
    /// <returns>Der NULL-basierte Index des ersten Vorkommens eines beliebigen Zeichens aus <paramref name="values"/>
    /// in <paramref name="span"/> oder -1, wenn keines der Zeichen gefunden wurde. Wenn <paramref name="values"/> eine 
    /// leere Spanne ist, gibt die Methode -1 zurück.</returns>
    /// <remarks>
    /// <para>
    /// Diese Spezialisierung der Erweiterungsmethode MemoryExtensions.IndexOfAny&lt;T&gt;(Span&lt;T&gt;, ReadOnlySpan&lt;T&gt;)
    /// für den Datentyp <see cref="char"/> wird benötigt, um Performanceprobleme zu vermeiden.
    /// </para>
    /// <para>
    /// Wenn die Länge von <paramref name="values"/> kleiner als 5 ist, verwendet die Methode für den Vergleich 
    /// MemoryExtensions.IndexOfAny&lt;T&gt;(ReadOnlySpan&lt;T&gt;, ReadOnlySpan&lt;T&gt;). Ist die Länge von <paramref name="values"/>
    /// größer, wird <see cref="string.IndexOfAny(char[])"/> verwendet.
    /// </para>
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfAny(this Span<char> span, ReadOnlySpan<char> values)
    => ((ReadOnlySpan<char>)span).IndexOfAny(values);

}
