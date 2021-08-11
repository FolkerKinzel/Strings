using System;
using System.Collections.Generic;
using System.Text;

namespace FolkerKinzel.Strings
{
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
        public static int LastIndexOfAny (this ReadOnlySpan<char> span, ReadOnlySpan<char> values)
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

    }
}
