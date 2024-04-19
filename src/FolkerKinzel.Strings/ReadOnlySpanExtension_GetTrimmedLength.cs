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

    /// <summary>Returns the length that the read-only span would have without trailing occurrences
    /// of <paramref name="trimChar"/>.</summary>
    /// <param name="span">The read-only span to examine.</param>
    /// <param name="trimChar">The <see cref="char"/> to remove from the end of <paramref name="span"/>.</param>
    /// <returns>The length that the span would have without trailing occurrences
    /// of <paramref name="trimChar"/>.</returns>
    /// <remarks>The method performs an ordinal character comparison.</remarks>
    public static int GetTrimmedLength(this ReadOnlySpan<char> span, char trimChar)
    {
        int length = span.Length;

        for (int i = length - 1; i >= 0; i--)
        {
            if (trimChar == span[i])
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
