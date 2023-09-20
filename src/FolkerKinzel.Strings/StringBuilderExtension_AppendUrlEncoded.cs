using FolkerKinzel.Strings.Intls;
using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>
    /// Fügt den Inhalt einer schreibgeschützten Zeichenspanne als URL-codierte Zeichenfolge
    /// an das Ende eines <see cref="StringBuilder"/>-Objekts an.
    /// </summary>
    /// 
    /// <param name="builder">Der <see cref="StringBuilder"/>, an den Zeichen angefügt werden.</param>
    /// <param name="value">Die schreibgeschützte Zeichenspanne, die die zu kodierenden und anzufügenden Zeichen enthält.</param>
    /// 
    /// <returns>Ein Verweis auf <paramref name="builder"/>, nachdem der Anfügevorgang abgeschlossen wurde.</returns>
    /// 
    /// <remarks>Die Methode ersetzt alle Zeichen in <paramref name="value"/> mit Ausnahme von nicht reservierten RFC 3986-Zeichen 
    /// durch ihre hexadezimale 
    /// Darstellung. Alle Unicode-Zeichen werden in das UTF-8-Format konvertiert, bevor sie mit Escapezeichen versehen werden.
    /// Bei dieser Methode wird davon ausgegangen, dass in <paramref name="value"/> keine Escapesequenzen enthalten sind.</remarks>
    /// 
    /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Bei der Erhöhung der Kapazität von <paramref name="builder"/>
    /// würde <see cref="StringBuilder.MaxCapacity"/> überschritten.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendUrlEncoded(this StringBuilder builder, ReadOnlySpan<char> value)
        => UrlEncoding.AppendUrlEncodedTo(builder, value);


    /// <summary>
    /// Fügt den Inhalt einer <see cref="byte"/>-Sammlung als URL-codierte Zeichenfolge
    /// an das Ende eines <see cref="StringBuilder"/>-Objekts an.
    /// </summary>
    /// 
    /// <param name="builder">Der <see cref="StringBuilder"/>, an den Zeichen angefügt werden.</param>
    /// <param name="value">Die <see cref="byte"/>-Sammlung, die die zu kodierenden und anzufügenden Daten 
    /// enthält, oder <c>null</c>.</param>
    /// 
    /// <returns>Ein Verweis auf <paramref name="builder"/>, nachdem der Anfügevorgang abgeschlossen wurde.</returns>
    /// 
    /// <remarks>Die Methode behandelt alle <see cref="byte"/>s in <paramref name="value"/> als 8-Bit-Zeichen und 
    /// ersetzt alle diese Zeichen mit Ausnahme von nicht reservierten RFC 3986-Zeichen 
    /// durch ihre hexadezimale Darstellung.</remarks>
    /// 
    /// <exception cref="ArgumentNullException"><paramref name="builder"/> oder <paramref name="value"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Bei der Erhöhung der Kapazität von <paramref name="builder"/>
    /// würde <see cref="StringBuilder.MaxCapacity"/> überschritten.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendUrlEncoded(this StringBuilder builder, IEnumerable<byte>? value)
        => value is null
               ? builder
               : builder.AppendUrlEncoded(CollectionConverter.AsReadOnlySpan(value));


    /// <summary>
    /// Fügt den Inhalt eines <see cref="byte"/>-Arrays als URL-codierte Zeichenfolge
    /// an das Ende eines <see cref="StringBuilder"/>-Objekts an.
    /// </summary>
    /// 
    /// <param name="builder">Der <see cref="StringBuilder"/>, an den Zeichen angefügt werden.</param>
    /// <param name="value">Das <see cref="byte"/>-Array, das die zu kodierenden und anzufügenden Daten 
    /// enthält, oder <c>null</c>.</param>
    /// 
    /// <returns>Ein Verweis auf <paramref name="builder"/>, nachdem der Anfügevorgang abgeschlossen wurde.</returns>
    /// 
    /// <remarks>Die Methode behandelt alle <see cref="byte"/>s in <paramref name="value"/> als 8-Bit-Zeichen und 
    /// ersetzt alle diese Zeichen mit Ausnahme von nicht reservierten RFC 3986-Zeichen 
    /// durch ihre hexadezimale Darstellung.</remarks>
    /// 
    /// <exception cref="ArgumentNullException"><paramref name="builder"/> oder <paramref name="value"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Bei der Erhöhung der Kapazität von <paramref name="builder"/>
    /// würde <see cref="StringBuilder.MaxCapacity"/> überschritten.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendUrlEncoded(this StringBuilder builder, byte[]? value)
        => UrlEncoding.AppendUrlEncodedTo(builder, value.AsSpan());


    /// <summary>
    /// Fügt den Inhalt einer schreibgeschützten <see cref="byte"/>-Spanne als URL-codierte Zeichenfolge
    /// an das Ende eines <see cref="StringBuilder"/>-Objekts an.
    /// </summary>
    /// 
    /// <param name="builder">Der <see cref="StringBuilder"/>, an den Zeichen angefügt werden.</param>
    /// <param name="value">Die schreibgeschützte <see cref="byte"/>-Spanne, die die zu kodierenden und anzufügenden Daten 
    /// enthält.</param>
    /// 
    /// <returns>Ein Verweis auf <paramref name="builder"/>, nachdem der Anfügevorgang abgeschlossen wurde.</returns>
    /// 
    /// <remarks>Die Methode behandelt alle <see cref="byte"/>s in <paramref name="value"/> als 8-Bit-Zeichen und 
    /// ersetzt alle diese Zeichen mit Ausnahme von nicht reservierten RFC 3986-Zeichen 
    /// durch ihre hexadezimale Darstellung.</remarks>
    /// 
    /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Bei der Erhöhung der Kapazität von <paramref name="builder"/>
    /// würde <see cref="StringBuilder.MaxCapacity"/> überschritten.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendUrlEncoded(this StringBuilder builder, ReadOnlySpan<byte> value)
        => UrlEncoding.AppendUrlEncodedTo(builder, value);

}
