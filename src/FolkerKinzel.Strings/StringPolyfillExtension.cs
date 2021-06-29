using System;
using System.Runtime.CompilerServices;

namespace FolkerKinzel.Strings
{
#if NETSTANDARD2_0 || NET45
    /// <summary>
    /// Erweiterungsmethoden für die <see cref="string"/>-Klasse, die in .NET Framework 4.5 und .NET Standard 2.0 als
    /// Polyfills für Methoden aus aktuellen .NET-Versionen dienen.
    /// </summary>
    /// <remarks>
    /// Die Methoden dieser Klasse sollten ausschließlich in der Erweiterungsmethodensyntax verwendet zu werden, um die 
    /// in moderneren Frameworks vorhandenen Originalmethoden der <see cref="string"/>-Klasse zu simulieren. Um dem Verhalten der 
    /// Originalmethoden zu entsprechen, werfen diese Erweiterungsmethoden eine <see cref="NullReferenceException"/>, wenn sie auf 
    /// einem Null-String aufgerufen werden.
    /// </remarks>
    public static partial class StringPolyfillExtension
    {
        /// <summary>
        /// Gibt mithilfe der festgelegten Vergleichsregeln einen Wert zurück, der angibt, ob ein angegebenes Zeichen innerhalb der Zeichenfolge auftritt.
        /// </summary>
        /// <param name="s">Der zu untersuchende <see cref="string"/>.</param>
        /// <param name="value">Das zu suchende Zeichen.</param>
        /// <param name="comparisonType">Einer der Enumerationswerte, der die für den Vergleich zu verwendenden Regeln angibt.</param>
        /// <returns><c>true</c>, wenn der <paramref name="value"/>-Parameter innerhalb dieser Zeichenfolge auftritt, andernfalls <c>false</c>.</returns>
        /// <exception cref="NullReferenceException"><paramref name="s"/> ist <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> ist kein gültiger <see cref="StringComparison"/>-Wert.</exception>
        /// <remarks>Verfügbar für .NET Standard 2.0 und .NET Framework 4.5.</remarks>
        public static bool Contains(this string s, char value, StringComparison comparisonType)
            => s is null ? throw new NullReferenceException()
                         : s.AsSpan().Contains(stackalloc[] { value }, comparisonType);

        /// <summary>
        /// Gibt den NULL-basierten Index des ersten Vorkommens des angegebenen Unicode-Zeichens in dieser Zeichenfolge an. 
        /// Ein Parameter gibt den Typ der Suche für das angegebene Zeichen an.
        /// </summary>
        /// <param name="s">Der zu untersuchende <see cref="string"/>.</param>
        /// <param name="value">Das zu suchende Zeichen.</param>
        /// <param name="comparisonType">Ein Enumerationswert, der die Regeln für die Suche festlegt.</param>
        /// <returns>Der nullbasierte Index von <paramref name="value"/>, wenn dieses Zeichen gefunden wurde, andernfalls -1.</returns>
        /// <exception cref="NullReferenceException"><paramref name="s"/> ist <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> ist kein gültiger <see cref="StringComparison"/>-Wert.</exception>
        /// <remarks>Verfügbar für .NET Standard 2.0 und .NET Framework 4.5.</remarks>
        public static int IndexOf(this string s, char value, StringComparison comparisonType)
            => s is null ? throw new NullReferenceException()
                         : s.AsSpan().IndexOf(stackalloc[] { value }, comparisonType);

        /// <summary>
        /// Hier wird eine Zeichenfolge anhand eines angegebenen Trennzeichens und optional von Optionen in Teilzeichenfolgen unterteilt.
        /// </summary>
        /// <param name="s">Der zu teilende <see cref="string"/>.</param>
        /// <param name="separator">Ein Zeichen, das die Teilzeichenfolgen in <paramref name="s"/> trennt.</param>
        /// <param name="options">Dies ist ein Enumerationswert, der angibt, ob leere Teilzeichenfolgen 
        /// eingeschlossen werden sollen.</param>
        /// <returns>Ein Array, dessen Elemente die Teilzeichenfolgen von <paramref name="s"/> enthält, die durch
        /// <paramref name="separator"/> getrennt sind.</returns>
        /// <exception cref="NullReferenceException"><paramref name="s"/> ist <c>null</c>.</exception>
        /// <remarks>Verfügbar für .NET Standard 2.0 und .NET Framework 4.5.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string[] Split(this string s, char separator, StringSplitOptions options = StringSplitOptions.None)
            => s.Split(new char[] { separator }, options);

        /// <summary>
        /// Hier wird eine Zeichenfolge in eine maximale Anzahl von Teilzeichenfolgen anhand 
        /// des angegebenen Ersatztrennzeichens unterteilt, wobei optional leere Teilzeichenfolgen aus dem Ergebnis ausgelassen werden.
        /// </summary>
        /// <param name="s">Der zu teilende <see cref="string"/>.</param>
        /// <param name="separator">Ein Zeichen, das die Teilzeichenfolgen in <paramref name="s"/> trennt.</param>
        /// <param name="count">Die maximale Anzahl der im Array erwarteten Elemente.</param>
        /// <param name="options">Dies ist ein Enumerationswert, der angibt, ob leere Teilzeichenfolgen 
        /// eingeschlossen werden sollen.</param>
        /// <returns>Ein Array, das maximal <paramref name="count"/> Teilzeichenfolgen von <paramref name="s"/> enthält, die durch
        /// <paramref name="separator"/> getrennt sind.</returns>
        /// <exception cref="NullReferenceException"><paramref name="s"/> ist <c>null</c>.</exception>
        /// <remarks>Verfügbar für .NET Standard 2.0 und .NET Framework 4.5.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string[] Split(this string s, char separator, int count, StringSplitOptions options = StringSplitOptions.None)
            => s.Split(new char[] { separator }, count, options);

        /// <summary>
        /// Bestimmt, ob <paramref name="s"/> mit dem angegebenen Zeichen beginnt.
        /// </summary>
        /// <param name="s">Der zu untersuchende <see cref="string"/>.</param>
        /// <param name="value">Das zu vergleichende Zeichen.</param>
        /// <returns><c>true</c>, wenn <paramref name="value"/> mit dem Anfang von <paramref name="s"/> übereinstimmt, andernfalls <c>false</c>.</returns>
        /// <remarks>
        /// Diese Methode führt einen Vergleich mit der aktuellen Kultur durch (Unterscheidung nach Groß-/Kleinschreibung und Kultur sensitiv).
        /// </remarks>
        /// <exception cref="NullReferenceException"><paramref name="s"/> ist <c>null</c>.</exception>
        /// <remarks>Verfügbar für .NET Standard 2.0 und .NET Framework 4.5.</remarks>
        public static bool StartsWith(this string s, char value)
            => s is null ? throw new NullReferenceException()
                         : s.AsSpan().StartsWith(stackalloc char[] { value }, StringComparison.CurrentCulture);


        /// <summary>
        /// Bestimmt, ob <paramref name="s"/> mit dem angegebenen Zeichen endet.
        /// </summary>
        /// <param name="s">Der zu untersuchende <see cref="string"/>.</param>
        /// <param name="value">Das zu vergleichende Zeichen.</param>
        /// <returns><c>true</c>, wenn <paramref name="value"/> mit dem Ende von <paramref name="s"/> übereinstimmt, andernfalls <c>false</c>.</returns>
        /// <remarks>
        /// Diese Methode führt einen Vergleich mit der aktuellen Kultur durch (Unterscheidung nach Groß-/Kleinschreibung und Kultur sensitiv).
        /// </remarks>
        /// <exception cref="NullReferenceException"><paramref name="s"/> ist <c>null</c>.</exception>
        /// <remarks>Verfügbar für .NET Standard 2.0 und .NET Framework 4.5.</remarks>
        public static bool EndsWith(this string s, char value)
            => s is null ? throw new NullReferenceException()
                         : s.AsSpan().EndsWith(stackalloc char[] { value }, StringComparison.CurrentCulture);
        
    }
#endif
}

