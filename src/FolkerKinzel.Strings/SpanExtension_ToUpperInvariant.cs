namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    /// <summary>Converts the letters that <paramref name="span" /> references 
    /// to uppercase letters using the rules of the invariant culture.</summary>
    /// <param name="span">The span whose content is changed.</param>
    /// <returns>A copy of <paramref name="span" />.</returns>
    public static Span<char> ToUpperInvariant(this Span<char> span)
    {
        for (int i = 0; i < span.Length; i++)
        {
            span[i] = char.ToUpperInvariant(span[i]);
        }

        return span;
    }

    //public static void ToUpper(this Span<char> span, CultureInfo? culture = null)
    //{
    //    culture ??= CultureInfo.CurrentCulture;

    //    for (int i = 0; i < span.Length; i++)
    //    {
    //        char c = span[i];
    //        span[i] = char.ToUpper(c, culture);
    //    }
    //}
}
