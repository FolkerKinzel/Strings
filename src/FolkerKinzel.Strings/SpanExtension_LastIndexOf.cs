using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    /// <summary>
    /// Gibt die NULL-basierte Indexposition des letzten Vorkommens einer angegebenen Zeichenfolge in <paramref name="span"/> an.
    /// </summary>
    /// <param name="span">Die zu durchsuchende Zeichenspanne.</param>
    /// <param name="value">Die zu suchende Zeichenfolge.</param>
    /// <param name="comparisonType">Einer der Enumerationswerte, der die Regeln für die Suche angibt.</param>
    /// <returns>Die nullbasierte Anfangsindexposition des <paramref name="value"/>-Parameters, wenn diese Zeichenfolge gefunden
    /// wurde, oder -1, wenn sie nicht 
    /// gefunden wurde oder <paramref name="span"/> leer ist.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOf(this Span<char> span, ReadOnlySpan<char> value, StringComparison comparisonType)
        => ((ReadOnlySpan<char>)span).LastIndexOf(value, comparisonType);



    /// <summary>
    /// Gibt die NULL-basierte Indexposition des letzten Vorkommens einer angegebenen Zeichenfolge in <paramref name="span"/> an. Die Suche beginnt an einer angegebenen Zeichenposition 
    /// und verläuft für eine angegebene Anzahl von Zeichenpositionen rückwärts zum Anfang der Zeichenspanne. Ein Parameter gibt den Typ des bei der Suche nach der angegebenen 
    /// Zeichenfolge auszuführenden Vergleichs an.
    /// </summary>
    /// <param name="span">Die zu durchsuchende Zeichenspanne.</param>
    /// <param name="value">Die zu suchende Zeichenfolge.</param>
    /// <param name="startIndex">Die Anfangsposition der Suche. Die Suche wird von <paramref name="startIndex"/> bis zum Anfang von <paramref name="span"/> fortgesetzt.</param>
    /// <param name="count">Die Anzahl der zu überprüfenden Zeichenpositionen.</param>
    /// <param name="comparisonType">Einer der Enumerationswerte, der die Regeln für die Suche angibt.</param>
    /// <returns>Die nullbasierte Anfangsindexposition des <paramref name="value"/>-Parameters, wenn diese Zeichenfolge gefunden wurde, oder -1, wenn sie nicht 
    /// gefunden wurde oder <paramref name="span"/> leer ist.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para>
    /// <paramref name="count"/> ist ein negativer Wert
    /// </para>
    /// <para>
    /// - oder -
    /// </para>
    /// <para>
    /// <paramref name="span"/> ist nicht <see cref="ReadOnlySpan{T}.Empty"/>, und <paramref name="startIndex"/> ist ein negativer Wert.
    /// </para>
    /// <para>
    /// - oder -
    /// </para>
    /// <para>
    /// <paramref name="span"/> ist nicht <see cref="ReadOnlySpan{T}.Empty"/>, und <paramref name="startIndex"/> ist größer als die Länge von <paramref name="span"/>.
    /// </para>
    /// <para>
    /// - oder -
    /// </para>
    /// <para>
    /// <paramref name="span"/> ist nicht <see cref="Span{T}.Empty"/>, und <paramref name="startIndex"/> + 1 - <paramref name="count"/> gibt eine Position an, 
    /// die nicht innerhalb von <paramref name="span"/> liegt.
    /// </para>
    /// <para>
    /// - oder -
    /// </para>
    /// <para>
    /// <paramref name="span"/> ist <see cref="Span{T}.Empty"/>, und <paramref name="startIndex"/> ist kleiner als -1 oder größer als 0.
    /// </para>
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="comparisonType"/> ist kein gültiger <see cref="StringComparison"/>-Wert.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOf(this Span<char> span, ReadOnlySpan<char> value, int startIndex, int count, StringComparison comparisonType)
    => ((ReadOnlySpan<char>) span).LastIndexOf(value, startIndex, count, comparisonType);


}
