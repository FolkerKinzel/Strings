using System.Runtime.CompilerServices;

namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{

    /// <summary>Determines whether this <paramref name="span" /> and <paramref name="other"
    /// /> have the same characters when compared using the specified <paramref name="comparisonType"
    /// /> option.</summary>
    /// <param name="span">The span to examine.</param>
    /// <param name="other">The value to compare with the source span.</param>
    /// <param name="comparisonType">An enumeration value that determines how <paramref name="span"
    /// /> and <paramref name="other" /> are compared.</param>
    /// <returns> <c>true</c> if identical, <c>false</c> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Equals(this Span<char> span, ReadOnlySpan<char> other, StringComparison comparisonType)
        => ((ReadOnlySpan<char>)span).Equals(other, comparisonType);

}
