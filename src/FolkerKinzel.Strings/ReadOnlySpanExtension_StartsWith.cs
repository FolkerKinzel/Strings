using System.Runtime.CompilerServices;

namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    /// <summary>
    /// Gibt an, ob eine schreibgeschützte Zeichenspanne mit dem angegebenen
    /// Unicode-Zeichen beginnt.
    /// </summary>
    /// <param name="span">Die zu untersuchende Spanne.</param>
    /// <param name="value">Das Zeichen, nach dem gesucht wird.</param>
    /// <returns><c>true</c>, wenn <paramref name="span"/> mit <paramref name="value"/>
    /// beginnt, andernfalls <c>false</c>.</returns>
    /// <remarks>
    /// Die Methode führt einen Ordinalzeichenvergleich durch.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool StartsWith(this ReadOnlySpan<char> span, char value)
     => !span.IsEmpty && span[0] == value;


}
