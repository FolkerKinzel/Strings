using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using FolkerKinzel.Strings.Properties;

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


        //public static string Replace(this string s, string oldValue, string? newValue, StringComparison comparisonType)
        //{
        //    if(s is null)
        //    {
        //        throw new NullReferenceException();
        //    }

        //    if(oldValue is null)
        //    {
        //        throw new ArgumentNullException(nameof(oldValue));
        //    }

        //    if(oldValue.Length == 0)
        //    {
        //        throw new ArgumentException(Res.NoEmptyStringAllowed, nameof(oldValue));
        //    }


        //    switch (comparisonType)
        //    {
        //        case StringComparison.CurrentCulture:
        //        case StringComparison.CurrentCultureIgnoreCase:
        //            return ReplaceCore(s, oldValue, newValue, CultureInfo.CurrentCulture.CompareInfo, GetCaseCompareOfComparisonCulture(comparisonType));
 
        //        case StringComparison.InvariantCulture:
        //        case StringComparison.InvariantCultureIgnoreCase:
        //            return ReplaceCore(s, oldValue, newValue, CultureInfo.InvariantCulture.CompareInfo, GetCaseCompareOfComparisonCulture(comparisonType));
 
        //        case StringComparison.Ordinal:
        //            return s.Replace(oldValue, newValue);
 
        //        case StringComparison.OrdinalIgnoreCase:
        //            return ReplaceCore(s, oldValue, newValue, CultureInfo.InvariantCulture.CompareInfo, CompareOptions.OrdinalIgnoreCase);
 
        //        default:
        //            throw new ArgumentException(Res.UndefinedEnumValue, nameof(comparisonType));
        //    }


        //    throw new NotImplementedException();
        //}

        //private static CompareOptions GetCaseCompareOfComparisonCulture(StringComparison comparisonType)
        //{
        //    Debug.Assert((uint)comparisonType <= (uint)StringComparison.OrdinalIgnoreCase);
 
        //    // Culture enums can be & with CompareOptions.IgnoreCase 0x01 to extract if IgnoreCase or CompareOptions.None 0x00
        //    //
        //    // CompareOptions.None                          0x00
        //    // CompareOptions.IgnoreCase                    0x01
        //    //
        //    // StringComparison.CurrentCulture:             0x00
        //    // StringComparison.InvariantCulture:           0x02
        //    // StringComparison.Ordinal                     0x04
        //    //
        //    // StringComparison.CurrentCultureIgnoreCase:   0x01
        //    // StringComparison.InvariantCultureIgnoreCase: 0x03
        //    // StringComparison.OrdinalIgnoreCase           0x05
 
        //    return (CompareOptions)((int)comparisonType & (int)CompareOptions.IgnoreCase);
        //}


        //private static string ReplaceCore(string searchSpace, string oldValue, string? newValue, CompareInfo ci, CompareOptions options)
        //{
        //    Debug.Assert(oldValue.Length != 0);

        //    var result = new StringBuilder(searchSpace.Length);
 
        //    bool hasDoneAnyReplacements = false;
 
        //    while (true)
        //    {
        //        int index = ci.IndexOf(searchSpace, oldValue, options, out int matchLength);
 
        //        // There's the possibility that 'oldValue' has zero collation weight (empty string equivalent).
        //        // If this is the case, we behave as if there are no more substitutions to be made.
 
        //        if (index < 0 || matchLength == 0)
        //        {
        //            break;
        //        }
 
        //        // append the unmodified portion of search space
        //        result.Append(searchSpace.Slice(0, index));
 
        //        // append the replacement
        //        result.Append(newValue);
 
        //        searchSpace = searchSpace.Slice(index + matchLength);
        //        hasDoneAnyReplacements = true;
        //    }
 
        //    // Didn't find 'oldValue' in the remaining search space, or the match
        //    // consisted only of zero collation weight characters. As an optimization,
        //    // if we have not yet performed any replacements, we'll save the
        //    // allocation.
 
        //    if (!hasDoneAnyReplacements)
        //    {
        //        result.Dispose();
        //        return null;
        //    }
 
        //    // Append what remains of the search space, then allocate the new string.
 
        //    result.Append(searchSpace);
        //    return result.ToString();
        //}


        
    }
#endif
}

