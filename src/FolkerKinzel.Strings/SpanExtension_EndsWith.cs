using System.Runtime.CompilerServices;

namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    /// <summary>
    /// Gibt an, ob eine schreibgeschützte Zeichenspanne mit dem angegebenen
    /// Unicode-Zeichen endet.
    /// </summary>
    /// <param name="span">Die zu untersuchende Spanne.</param>
    /// <param name="value">Das Zeichen, nach dem gesucht wird.</param>
    /// <returns><c>true</c>, wenn <paramref name="span"/> mit <paramref name="value"/>
    /// endet, andernfalls <c>false</c>.</returns>
    /// <remarks>
    /// Die Methode führt einen Ordinalzeichenvergleich durch.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EndsWith(this Span<char> span, char value)
     => ((ReadOnlySpan<char>)span).EndsWith(value);


    /// <summary>
    /// Gibt an, ob das Ende von <paramref name="span"/> mit <paramref name="value"/> übereinstimmt, wenn unter Verwendung der angegebenen
    /// <paramref name="comparisonType"/>-Option verglichen wird.
    /// </summary>
    /// <param name="span">Die zu untersuchende Zeichenspanne.</param>
    /// <param name="value">Die Zeichenfolge mit der das Ende von <paramref name="span"/> verglichen wird.</param>
    /// <param name="comparisonType">Einer der Enumerationswerte, der festlegt, wie <paramref name="span"/> und <paramref name="value"/>
    /// verglichen werden.</param>
    /// <returns><c>true</c>, wenn <paramref name="span"/> mit <paramref name="value"/>
    /// endet, andernfalls <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EndsWith(this Span<char> span, ReadOnlySpan<char> value, StringComparison comparisonType)
        => ((ReadOnlySpan<char>)span).EndsWith(value, comparisonType);


}
