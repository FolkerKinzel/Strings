using System.Globalization;
using System.Runtime.CompilerServices;

namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{

    /// <summary>
    /// Wandelt die Buchstaben, auf die <paramref name="span"/> verweist, in Kleinbuchstaben, 
    /// wobei die Regeln für die Groß-/Kleinschreibung der invarianten Kultur verwendet werden.
    /// </summary>
    /// <param name="span">Die Zeichenspanne, deren Inhalt geändert wird.</param>
    /// <returns>Eine Kopie von <paramref name="span"/>.</returns>
    public static ReadOnlySpan<char> ToLowerInvariant(this Span<char> span)
    {
        for (int i = 0; i < span.Length; i++)
        {
            span[i] = char.ToLowerInvariant(span[i]);
        }
        return span;
    }

    //public static void ToLower(this Span<char> span, CultureInfo? culture = null)
    //{
    //    culture ??= CultureInfo.CurrentCulture;

    //    for (int i = 0; i < span.Length; i++)
    //    {
    //        char c = span[i];
    //        span[i] = char.ToLower(c, culture);
    //    }
    //}

}
