using System.Buffers;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FolkerKinzel.Strings;

/// <summary>
/// Simuliert statische Methoden der <see cref="string"/>-Klasse für .NET-Versionen, in denen diese nicht verfügbar sind, und leitet die Methodenaufrufe
/// in .NET-Versionen, in denen die Methoden verfügbar sind, an die BCL-Methoden weiter.
/// </summary>
public static class StaticStringMethod
{

#if NET45 || NETSTANDARD2_0
    /// <summary>
    /// Erstellt eine neue Zeichenfolge mit einer bestimmten Länge und initialisiert sie nach der Erstellung unter Verwendung des angegebenen Rückrufs.
    /// </summary>
    /// <typeparam name="TState">Der Typ des Elements, das an <paramref name="action"/> übergeben werden soll.</typeparam>
    /// <param name="length">Die Länge des zu erstellenden <see cref="string"/>s.</param>
    /// <param name="state">Das an <paramref name="action"/> zu übergebende Element.</param>
    /// <param name="action">Ein Rückruf zum Initialisieren der Zeichenfolge.</param>
    /// <returns>Der erstellte <see cref="string"/>.</returns>
    /// <remarks>Die Methode simuliert die statische Methode String.Create&lt;TState&gt;(int, TState, SpanAction&lt;char,TState&gt;).
    /// In neueren .NET-Versionen wird der Aufruf direkt an die vorhandene Methode der <see cref="string"/>-Klasse weitergeleitet. In 
    /// .NET Framework und .NET Standard 2.0 ermöglicht die Simulation zumindest bei der Erstellung kurzer <see cref="string"/>s, mit 
    /// nur einer Heap-Allokation auszukommen.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="action"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="length"/> ist negativ.</exception>
    public static string Create<TState>(int length, TState state, SpanAction<char, TState> action)
    {
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }

        if (length <= 0)
        {
            return length == 0 ? string.Empty : throw new ArgumentOutOfRangeException(nameof(length));
        }

        Span<char> span = length > Const.ShortString ? new char[length] : stackalloc char[length];
        action(span, state);
        return span.ToString();
    }
#else
    /// <summary>
    /// Erstellt eine neue Zeichenfolge mit einer bestimmten Länge und initialisiert sie nach der Erstellung unter Verwendung des angegebenen Rückrufs.
    /// </summary>
    /// <typeparam name="TState">Der Typ des Elements, das an <paramref name="action"/> übergeben werden soll.</typeparam>
    /// <param name="length">Die Länge der zu erstellenden Zeichenfolge.</param>
    /// <param name="state">Das an <paramref name="action"/> zu übergebende Element.</param>
    /// <param name="action">Ein Rückruf zum Initialisieren der Zeichenfolge.</param>
    /// <returns>Die erstellte Zeichenfolge.</returns>
    /// <remarks>Die Methode simuliert die statische Methode String.Create&lt;TState&gt;(int, TState, SpanAction&lt;char,TState&gt;).
    /// In neueren .NET-Versionen wird der Aufruf direkt an die vorhandene Methode der <see cref="string"/>-Klasse weitergeleitet. In 
    /// .NET Framework und .NET Standard 2.0 ermöglicht die Simulation zumindest bei der Erstellung kurzer <see cref="string"/>s, mit 
    /// nur einer Heap-Allokation auszukommen.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="action"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="length"/> ist negativ.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Create<TState>(int length, TState state, SpanAction<char, TState> action)
        => string.Create(length, state, action);

#endif

#if NET5_0_OR_GREATER

    /// <summary>
    /// Verkettet die Zeichenfolgendarstellung von vier angegebenen schreibgeschützten Zeichenspannen.
    /// </summary>
    /// <param name="str0">Die erste zu verkettende schreibgeschützte Zeichenspanne.</param>
    /// <param name="str1">Die zweite zu verkettende schreibgeschützte Zeichenspanne.</param>
    /// <param name="str2">Die dritte zu verkettende schreibgeschützte Zeichenspanne.</param>
    /// <param name="str3">Die vierte zu verkettende schreibgeschützte Zeichenspanne.</param>
    /// <returns>Die verketteten Zeichenfolgendarstellungen der Werte von <paramref name="str0"/>, 
    /// <paramref name="str1"/>, <paramref name="str2"/> und <paramref name="str3"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Concat(ReadOnlySpan<char> str0, ReadOnlySpan<char> str1, ReadOnlySpan<char> str2, ReadOnlySpan<char> str3)
        => string.Concat(str0, str1, str2, str3);

    /// <summary>
    /// Verkettet die Zeichenfolgendarstellung von drei angegebenen schreibgeschützten Zeichenspannen.
    /// </summary>
    /// <param name="str0">Die erste zu verkettende schreibgeschützte Zeichenspanne.</param>
    /// <param name="str1">Die zweite zu verkettende schreibgeschützte Zeichenspanne.</param>
    /// <param name="str2">Die dritte zu verkettende schreibgeschützte Zeichenspanne.</param>
    /// <returns>Die verketteten Zeichenfolgendarstellungen der Werte von <paramref name="str0"/>, 
    /// <paramref name="str1"/> und <paramref name="str2"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Concat(ReadOnlySpan<char> str0, ReadOnlySpan<char> str1, ReadOnlySpan<char> str2)
        => string.Concat(str0, str1, str2);

    /// <summary>
    /// Verkettet die Zeichenfolgendarstellung von zwei angegebenen schreibgeschützten Zeichenspannen.
    /// </summary>
    /// <param name="str0">Die erste zu verkettende schreibgeschützte Zeichenspanne.</param>
    /// <param name="str1">Die zweite zu verkettende schreibgeschützte Zeichenspanne.</param>
    /// <returns>Die verketteten Zeichenfolgendarstellungen der Werte von <paramref name="str0"/> und
    /// <paramref name="str1"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Concat(ReadOnlySpan<char> str0, ReadOnlySpan<char> str1)
        => string.Concat(str0, str1);

#else
    /// <summary>
    /// Verkettet die Zeichenfolgendarstellung von vier angegebenen schreibgeschützten Zeichenspannen.
    /// </summary>
    /// <param name="str0">Die erste zu verkettende schreibgeschützte Zeichenspanne.</param>
    /// <param name="str1">Die zweite zu verkettende schreibgeschützte Zeichenspanne.</param>
    /// <param name="str2">Die dritte zu verkettende schreibgeschützte Zeichenspanne.</param>
    /// <param name="str3">Die vierte zu verkettende schreibgeschützte Zeichenspanne.</param>
    /// <returns>Die verketteten Zeichenfolgendarstellungen der Werte von <paramref name="str0"/>, 
    /// <paramref name="str1"/>, <paramref name="str2"/> und <paramref name="str3"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Concat(ReadOnlySpan<char> str0, ReadOnlySpan<char> str1, ReadOnlySpan<char> str2, ReadOnlySpan<char> str3)
    {
        int length = str0.Length + str1.Length + str2.Length + str3.Length;
        Span<char> span = length > Const.ShortString ? new char[length] : stackalloc char[length];

        str0.CopyTo(span);
        Span<char> spanPart = span.Slice(str0.Length);
        str1.CopyTo(spanPart);
        spanPart = spanPart.Slice(str1.Length);
        str2.CopyTo(spanPart);
        spanPart = spanPart.Slice(str2.Length);
        str3.CopyTo(spanPart);

        return span.ToString();
    }

    /// <summary>
    /// Verkettet die Zeichenfolgendarstellung von drei angegebenen schreibgeschützten Zeichenspannen.
    /// </summary>
    /// <param name="str0">Die erste zu verkettende schreibgeschützte Zeichenspanne.</param>
    /// <param name="str1">Die zweite zu verkettende schreibgeschützte Zeichenspanne.</param>
    /// <param name="str2">Die dritte zu verkettende schreibgeschützte Zeichenspanne.</param>
    /// <returns>Die verketteten Zeichenfolgendarstellungen der Werte von <paramref name="str0"/>, 
    /// <paramref name="str1"/> und <paramref name="str2"/>.</returns>
    public static string Concat(ReadOnlySpan<char> str0, ReadOnlySpan<char> str1, ReadOnlySpan<char> str2)
    {
        int length = str0.Length + str1.Length + str2.Length;
        Span<char> span = length > Const.ShortString ? new char[length] : stackalloc char[length];

        str0.CopyTo(span);
        Span<char> spanPart = span.Slice(str0.Length);
        str1.CopyTo(spanPart);
        spanPart = spanPart.Slice(str1.Length);
        str2.CopyTo(spanPart);

        return span.ToString();
    }

    /// <summary>
    /// Verkettet die Zeichenfolgendarstellung von zwei angegebenen schreibgeschützten Zeichenspannen.
    /// </summary>
    /// <param name="str0">Die erste zu verkettende schreibgeschützte Zeichenspanne.</param>
    /// <param name="str1">Die zweite zu verkettende schreibgeschützte Zeichenspanne.</param>
    /// <returns>Die verketteten Zeichenfolgendarstellungen der Werte von <paramref name="str0"/> und
    /// <paramref name="str1"/>.</returns>
    public static string Concat(ReadOnlySpan<char> str0, ReadOnlySpan<char> str1)
    {
        int length = str0.Length + str1.Length;
        Span<char> span = length > Const.ShortString ? new char[length] : stackalloc char[length];

        str0.CopyTo(span);
        Span<char> spanPart = span.Slice(str0.Length);
        str1.CopyTo(spanPart);

        return span.ToString();
    }

#endif
}
