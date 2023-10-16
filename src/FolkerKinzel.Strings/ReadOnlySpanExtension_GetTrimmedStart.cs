namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    /// <summary>Returns the index of the first non-white-space character in the span.</summary>
    /// <param name="span">The span to examine.</param>
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
}
