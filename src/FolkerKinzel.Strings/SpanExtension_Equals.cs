using System.Runtime.CompilerServices;

namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{

    /// <summary>
    /// Bestimmt, ob <paramref name="span"/> und <paramref name="other"/> 
    /// identische Zeichenfolgen sind, wenn sie mit der angegebenen <paramref name="comparisonType"/>-Option verglichen
    /// werden.
    /// </summary>
    /// <param name="span">Die zu untersuchende Zeichenspanne.</param>
    /// <param name="other">Der Wert, mit dem <paramref name="span"/> verglichen werden soll.</param>
    /// <param name="comparisonType">Ein Enumerationswert, der bestimmt, wie <paramref name="span"/> und 
    /// <paramref name="other"/> verglichen werden.</param>
    /// <returns><c>true</c>, sofern identisch, andernfalls <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Equals(this Span<char> span, ReadOnlySpan<char> other, StringComparison comparisonType)
        => ((ReadOnlySpan<char>)span).Equals(other, comparisonType);

}
