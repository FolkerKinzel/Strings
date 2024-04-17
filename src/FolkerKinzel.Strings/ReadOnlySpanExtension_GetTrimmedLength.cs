namespace FolkerKinzel.Strings;

public static partial class ReadOnlySpanExtension
{
    /// <summary>Returns the length that the read-only span would have without trailing white
    /// space.</summary>
    /// <param name="span">The read-only span to examine.</param>
    /// <returns>The length that the span would have without trailing white space.</returns>
    public static int GetTrimmedLength(this ReadOnlySpan<char> span)
    {
        int length = span.Length;

        for (int i = length - 1; i >= 0; i--)
        {
            if (char.IsWhiteSpace(span[i]))
            {
                length--;
            }
            else
            {
                break;
            }
        }
        return length;
    }
}
