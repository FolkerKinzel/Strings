using System.Runtime.CompilerServices;

namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    /// <summary>Indicates whether a read-only character span ends with a specified Unicode
    /// character.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <returns> <c>true</c> if <paramref name="span" /> ends with <paramref name="value"
    /// />, otherwise <c>false</c>.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EndsWith(this ReadOnlySpan<char> span, char value)
     => !span.IsEmpty && span[span.Length - 1] == value;


}
