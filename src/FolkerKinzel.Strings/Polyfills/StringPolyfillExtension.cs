using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using FolkerKinzel.Strings.Properties;

namespace FolkerKinzel.Strings.Polyfills
{
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
#if NETSTANDARD2_0
    [ExcludeFromCodeCoverage]
#endif
    public static partial class StringPolyfillExtension
    {
#if NET45 || NETSTANDARD2_0

        /// <summary>
        /// Gibt mithilfe der festgelegten Vergleichsregeln einen Wert zurück, der angibt, ob ein angegebenes Zeichen innerhalb der Zeichenfolge auftritt.
        /// </summary>
        /// <param name="s">Der zu untersuchende <see cref="string"/>.</param>
        /// <param name="value">Das zu suchende Zeichen.</param>
        /// <param name="comparisonType">Ein Enumerationswert, der die für den Vergleich zu verwendende Regel angibt.</param>
        /// <returns><c>true</c>, wenn <paramref name="value"/> innerhalb dieser Zeichenfolge auftritt, andernfalls <c>false</c>.</returns>
        /// <exception cref="NullReferenceException"><paramref name="s"/> ist <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> ist kein gültiger <see cref="StringComparison"/>-Wert.</exception>
        public static bool Contains(this string s, char value, StringComparison comparisonType)
            => s is null ? throw new NullReferenceException()
                         : s.AsSpan().Contains(stackalloc[] { value }, comparisonType);

        /// <summary>
        /// Gibt einen Wert zurück, der angibt, ob ein angegebenes Zeichen in der Zeichenfolge vorkommt.
        /// </summary>
        /// <param name="s">Der zu untersuchende <see cref="string"/>.</param>
        /// <param name="value">Das zu suchende Zeichen.</param>
        /// <returns><c>true</c>, wenn <paramref name="value"/> innerhalb dieser Zeichenfolge auftritt, andernfalls <c>false</c>.</returns>
        /// <exception cref="NullReferenceException"><paramref name="s"/> ist <c>null</c>.</exception>
        /// <remarks>
        /// Die Methode führt einen Ordinalzeichenvergleich aus.
        /// </remarks>
        public static bool Contains(this string s, char value)
            => s is null ? throw new NullReferenceException()
                         : s.AsSpan().Contains(value);

        /// <summary>
        /// Gibt mithilfe der festgelegten Vergleichsregeln einen Wert zurück, der angibt, ob eine angegebene Zeichenfolge innerhalb von <paramref name="s"/>
        /// auftritt.
        /// </summary>
        /// <param name="s">>Der zu untersuchende <see cref="string"/>.</param>
        /// <param name="value">Die zu suchende Zeichenfolge.</param>
        /// <param name="comparisonType">Ein Enumerationswert, der die für den Vergleich zu verwendende Regel angibt.</param>
        /// <returns><c>true</c>, wenn <paramref name="value"/> innerhalb dieser Zeichenfolge auftritt, andernfalls <c>false</c>.</returns>
        /// <exception cref="NullReferenceException"><paramref name="s"/> ist <c>null</c>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains(this string s, string value, StringComparison comparisonType)
            => s.IndexOf(value, comparisonType) != -1;


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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string[] Split(this string s, char separator, int count, StringSplitOptions options = StringSplitOptions.None)
            => s.Split(new char[] { separator }, count, options);


        /// <summary>
        /// Teilt eine Zeichenfolge anhand einer angegebenen Trennzeichenfolge und optional von Optionen in die angegebene maximale Anzahl von Teilzeichenfolgen.
        /// </summary>
        /// <param name="s">Der zu splittende <see cref="string"/>.</param>
        /// <param name="separator">Eine Zeichenfolge, die die Teilzeichenfolgen in <paramref name="s"/> trennt.</param>
        /// <param name="count">Die maximale Anzahl der im Array erwarteten Elemente.</param>
        /// <param name="options">Dies ist ein Enumerationswert, der angibt, ob leere Teilzeichenfolgen 
        /// eingeschlossen werden sollen.</param>
        /// <returns>Ein Array, das maximal <paramref name="count"/> Teilzeichenfolgen von <paramref name="s"/> enthält, die durch
        /// <paramref name="separator"/> getrennt sind.</returns>
        /// <exception cref="NullReferenceException"><paramref name="s"/> ist <c>null</c>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string[] Split(this string s, string? separator, int count, StringSplitOptions options = System.StringSplitOptions.None)
            => s.Split(separator is null ? null : new string[] { separator }, count, options);

        /// <summary>
        /// Teilt eine Zeichenfolge anhand einer angegebenen Trennzeichenfolge und optional von Optionen in Teilzeichenfolgen.
        /// </summary>
        /// <param name="s">Der zu splittende <see cref="string"/>.</param>
        /// <param name="separator">Eine Zeichenfolge, die die Teilzeichenfolgen in <paramref name="s"/> trennt.</param>
        /// <param name="options">Dies ist ein Enumerationswert, der angibt, ob leere Teilzeichenfolgen 
        /// eingeschlossen werden sollen.</param>
        /// <returns>Ein Array, dessen Elemente die Teilzeichenfolgen von <paramref name="s"/> enthält, die durch
        /// <paramref name="separator"/> getrennt sind.</returns>
        /// <exception cref="NullReferenceException"><paramref name="s"/> ist <c>null</c>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string[] Split(this string s, string? separator, StringSplitOptions options = System.StringSplitOptions.None)
            => s.Split(separator is null ? null : new string[] { separator }, options);

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
        public static bool EndsWith(this string s, char value)
            => s is null ? throw new NullReferenceException()
                         : s.AsSpan().EndsWith(stackalloc char[] { value }, StringComparison.CurrentCulture);


        /// <summary>
        /// Gibt mithilfe des bereitgestellten Vergleichstyps eine neue Zeichenfolge zurück, in der alle Vorkommen einer 
        /// angegebenen Zeichenfolge in der aktuellen Instanz durch eine andere angegebene Zeichenfolge ersetzt wurden.
        /// </summary>
        /// <param name="s">>Der zu bearbeitende <see cref="string"/>.</param>
        /// <param name="oldValue">Die zu ersetzende Zeichenfolge.</param>
        /// <param name="newValue">Die Zeichenfolge, die jedes Vorkommen von <paramref name="oldValue"/> ersetzen soll.</param>
        /// <param name="comparisonType">Ein Enumerationswert, der die für den Vergleich zu verwendende Regel angibt.</param>
        /// <returns>Eine Zeichenfolge, die der aktuellen Zeichenfolge entspricht, außer dass alle Instanzen von <paramref name="oldValue"/>
        /// durch <paramref name="newValue"/> ersetzt wurden. Wenn <paramref name="oldValue"/> nicht in der aktuellen Instanz gefunden wird, 
        /// gibt die Methode die aktuelle Instanz unverändert zurück.</returns>
        /// <exception cref="NullReferenceException"><paramref name="s"/> ist <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="oldValue"/> ist <c>null</c>.</exception>
        /// <exception cref="ArgumentException">
        /// <para><paramref name="oldValue"/> ist <see cref="string.Empty"/></para>
        /// <para>- oder -</para>
        /// <para><paramref name="comparisonType"/> ist kein gültiger <see cref="StringComparison"/>-Wert.</para></exception>
        public static string Replace(this string s, string oldValue, string? newValue, StringComparison comparisonType)
        {
            if (comparisonType == StringComparison.Ordinal)
            {
                return s.Replace(oldValue, newValue);
            }

            if (s is null)
            {
                throw new NullReferenceException();
            }

            if (oldValue is null)
            {
                throw new ArgumentNullException(nameof(oldValue));
            }

            if (oldValue.Length == 0)
            {
                throw new ArgumentException(string.Format("{0} is an empty String.", nameof(oldValue)), nameof(oldValue));
            }

            if (s.Length < oldValue.Length)
            {
                return s;
            }

            if (newValue is null)
            {
                newValue = string.Empty;
            }

            var builder = new StringBuilder(newValue.Length > oldValue.Length ? s.Length + s.Length / 2 : s.Length);
            _ = builder.Append(s);

            int idx = s.Length - 1;
            while (idx > -1)
            {
                idx = s.LastIndexOf(oldValue, idx - 1, comparisonType);
                _ = builder.Remove(idx, oldValue.Length).Insert(idx, newValue);
                --idx;
            }

            return builder.ToString();
        }


#endif
    }
}

