namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    /// <summary>Indicates whether the character span contains only white space characters.</summary>
    /// <param name="span">The span to examine.</param>
    /// <returns> <c>true</c> if <paramref name="span" /> consists only of white space, otherwise
    /// <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsWhiteSpace(this Span<char> span) => MemoryExtensions.IsWhiteSpace(span);
}
