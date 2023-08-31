using System.Runtime.CompilerServices;

namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    /// <summary>
    /// Gibt an, ob die angegebene Zeichenspanne ausschließlich Leerraumzeichen enthält.
    /// </summary>
    /// <param name="span">Die zu untersuchende Zeichenspanne.</param>
    /// <returns><c>true</c>, wenn <paramref name="span"/> ausschließlich Leerraumzeichen enthält, andernfalls <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsWhiteSpace(this Span<char> span)
        => ((ReadOnlySpan<char>)span).IsWhiteSpace();


}
