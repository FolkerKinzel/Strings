using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>
    /// Fügt den Inhalt eines schreibgeschützten Zeichenspeichers an der angegebenen Zeichenposition in <paramref name="builder"/> ein.
    /// </summary>
    /// <param name="builder">Der <see cref="StringBuilder"/>, in den Zeichen eingefügt werden.</param>
    /// <param name="index">Der nullbasierte Index in <paramref name="builder"/>, an dem die Einfügung beginnt.</param>
    /// <param name="value">Der einzufügende Zeichenspeicher.</param>
    /// <returns>Ein Verweis auf <paramref name="builder"/>, nachdem der Einfügevorgang abgeschlossen wurde.</returns>
    /// <exception cref="NullReferenceException"><paramref name="builder"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> ist kleiner als 0 oder größer
    /// als die Länge von <paramref name="builder"/>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder Insert(this StringBuilder builder, int index, ReadOnlyMemory<char> value)
        => builder.Insert(index, value.Span);

}
