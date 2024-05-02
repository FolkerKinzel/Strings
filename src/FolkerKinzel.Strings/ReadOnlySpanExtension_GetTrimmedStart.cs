using System.ComponentModel;

namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    /// <summary>Returns the index of the first non-white-space character in the 
    /// read-only span.</summary>
    /// <param name="span">The read-only span to examine.</param>
    /// <returns>The index of the first non-white-space character found in the span. If the
    /// span is empty or consists only of white space, the length of the span is returned.</returns>
    public static int GetTrimmedStart(this ReadOnlySpan<char> span)
    {
        for (int i = 0; i < span.Length; i++)
        {
            if (!char.IsWhiteSpace(span[i]))
            {
                return i;
            }
        }

        return span.Length;
    }

    /// <summary>Returns the index of the first character in the 
    /// read-only span that is not equal to <paramref name="trimChar"/>.</summary>
    /// <param name="span">The read-only span to examine.</param>
    /// <param name="trimChar">The <see cref="char"/> to remove from the beginning of <paramref name="span"/>.</param>
    /// <returns>The index of the first first character in the 
    /// read-only span that is not equal to <paramref name="trimChar"/>. If the
    /// span is empty or consists only of <paramref name="trimChar"/>s, <c>0</c> is returned.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    [Obsolete("Use IndexOfAnyExcept instead.", false)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static int GetTrimmedStart(this ReadOnlySpan<char> span, char trimChar)
    {
        int idx = span.IndexOfAnyExcept(trimChar);
        return idx == -1 ? span.Length : idx;
    }
}
