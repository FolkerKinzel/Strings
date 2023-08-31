using System.Runtime.CompilerServices;

namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    /// <summary>
    /// Gibt an, ob eine angegebene Zeichenfolge innerhalb einer Zeichenspanne auftritt.
    /// </summary>
    /// <param name="span">Die Quellspanne.</param>
    /// <param name="value">Die innerhalb der Quellspanne zu suchende Zeichenfolge.</param>
    /// <param name="comparisonType">Ein Enumerationswert, der bestimmt, wie die Zeichen in <paramref name="span"/> und 
    /// <paramref name="value"/> verglichen werden.</param>
    /// <returns><c>true</c>, wenn <paramref name="value"/> innerhalb der Spanne auftritt, andernfalls <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(this Span<char> span, ReadOnlySpan<char> value, StringComparison comparisonType)
        => ((ReadOnlySpan<char>)span).Contains(value, comparisonType);


}
