using System.Globalization;
using System.Runtime.CompilerServices;

namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    public static void ToUpperInvariant(this Span<char> span)
    {
        for (int i = 0; i < span.Length; i++)
        {
            char c = span[i];
            span[i] = char.ToUpperInvariant(c);
        }
    }

    public static void ToUpper(this Span<char> span, CultureInfo? culture = null)
    {
        culture ??= CultureInfo.CurrentCulture;

        for (int i = 0; i < span.Length; i++)
        {
            char c = span[i];
            span[i] = char.ToUpper(c, culture);
        }
    }


}
