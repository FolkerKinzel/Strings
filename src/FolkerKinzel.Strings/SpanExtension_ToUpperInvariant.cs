using System.Globalization;
using System.Runtime.CompilerServices;

namespace FolkerKinzel.Strings;

public static partial class SpanExtension
{
    /// <summary>
    /// Wandelt die Buchstaben, auf die <paramref name="span"/> verweist, in Großbuchstaben, 
    /// wobei die Regeln für die Groß-/Kleinschreibung der invarianten Kultur verwendet werden.
    /// </summary>
    /// <param name="span">Die Zeichenspanne, deren Inhalt geändert wird.</param>
    public static void ToUpperInvariant(this Span<char> span)
    {
        for (int i = 0; i < span.Length; i++)
        {
            span[i] = char.ToUpperInvariant(span[i]);
        }
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
