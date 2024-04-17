namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    /// <summary>Indicates whether a read-only character span begins with the 
    /// specified Unicode character.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="value">The Unicode character to search for.</param>
    /// <returns> <c>true</c> if <paramref name="span" /> starts with <paramref name="value"
    /// />, otherwise <c>false</c>.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool StartsWith(this ReadOnlySpan<char> span, char value)
     => !span.IsEmpty && span[0] == value;
}
