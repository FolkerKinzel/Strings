using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>
    /// Fügt eine Kopie der angegebenen schreibgeschützten Zeichenspanne gefolgt vom Standardzeilenabschlusszeichen 
    /// am Ende eines <see cref="StringBuilder"/>-Objekts an.
    /// </summary>
    /// <param name="builder">Der <see cref="StringBuilder"/>, an den Zeichen angefügt werden.</param>
    /// <param name="value">Die anzufügende schreibgeschützte Zeichenspanne.</param>
    /// <returns>Ein Verweis auf <paramref name="builder"/>, nachdem der Anfügevorgang abgeschlossen wurde.</returns>
    /// <exception cref="NullReferenceException"><paramref name="builder"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Bei der Erhöhung der Kapazität von <paramref name="builder"/>
    /// würde <see cref="StringBuilder.MaxCapacity"/> überschritten.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendLine(this StringBuilder builder, ReadOnlySpan<char> value)
        => builder.Append(value).AppendLine();


    /// <summary>
    /// Fügt eine Kopie des angegebenen schreibgeschützten Zeichenspeichers gefolgt vom Standardzeilenabschlusszeichen 
    /// am Ende eines <see cref="StringBuilder"/>-Objekts an.
    /// </summary>
    /// <param name="builder">Der <see cref="StringBuilder"/>, an den Zeichen angefügt werden.</param>
    /// <param name="value">Der anzufügende schreibgeschützte Zeichenspeicher.</param>
    /// <returns>Ein Verweis auf <paramref name="builder"/>, nachdem der Anfügevorgang abgeschlossen wurde.</returns>
    /// <exception cref="NullReferenceException"><paramref name="builder"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Bei der Erhöhung der Kapazität von <paramref name="builder"/>
    /// würde <see cref="StringBuilder.MaxCapacity"/> überschritten.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendLine(this StringBuilder builder, ReadOnlyMemory<char> value)
        => builder.Append(value.Span).AppendLine();

}
