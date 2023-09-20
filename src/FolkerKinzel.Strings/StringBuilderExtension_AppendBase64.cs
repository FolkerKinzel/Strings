using System.Runtime.InteropServices;
using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    /// <summary>
    /// Fügt den Inhalt einer <see cref="byte"/>-Sammlung als Base64-kodierte Zeichenfolge
    /// am Ende eines <see cref="StringBuilder"/>-Objekts an.
    /// </summary>
    /// <param name="builder">Der <see cref="StringBuilder"/>, an den Zeichen angefügt werden.</param>
    /// <param name="bytes">Die <see cref="byte"/>-Enumeration, die die anzufügenden Daten enthält oder <c>null</c>.</param>
    /// <param name="options">Ein Enumerationswert, der es erlaubt festzulegen, ob in das Base64 automatisch Zeilenumbrüche 
    /// eingefügt werden sollen.</param>
    /// <returns>Ein Verweis auf <paramref name="builder"/>, nachdem der Anfügevorgang abgeschlossen wurde.</returns>
    /// <remarks>Die Methode verwendet eine eigene Base64-Implementierung, die etwas langsamer als die BCL-Methoden
    /// ist, aber für den Zweck sehr viel weniger Heap-Speicher alloziert.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="builder"/> oder <paramref name="bytes"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Bei der Erhöhung der Kapazität von <paramref name="builder"/>
    /// würde <see cref="StringBuilder.MaxCapacity"/> überschritten.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendBase64(this StringBuilder builder,
                                             IEnumerable<byte>? bytes,
                                             Base64FormattingOptions options = Base64FormattingOptions.None)
        => bytes is null ? builder
                         : Base64.AppendEncodedTo(builder, CollectionConverter.AsReadOnlySpan(bytes), options);


    /// <summary>
    /// Fügt den Inhalt eines <see cref="byte"/>-Arrays als Base64-kodierte Zeichenfolge
    /// am Ende eines <see cref="StringBuilder"/>-Objekts an.
    /// </summary>
    /// <param name="builder">Der <see cref="StringBuilder"/>, an den Zeichen angefügt werden.</param>
    /// <param name="bytes">Das <see cref="byte"/>-Array, das die anzufügenden Daten enthält oder <c>null</c>.</param>
    /// <param name="options">Ein Enumerationswert, der es erlaubt festzulegen, ob in das Base64 automatisch Zeilenumbrüche 
    /// eingefügt werden sollen.</param>
    /// <returns>Ein Verweis auf <paramref name="builder"/>, nachdem der Anfügevorgang abgeschlossen wurde.</returns>
    /// <remarks>Die Methode verwendet eine eigene Base64-Implementierung, die etwas langsamer als die BCL-Methoden
    /// ist, aber für den Zweck sehr viel weniger Heap-Speicher alloziert.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Bei der Erhöhung der Kapazität von <paramref name="builder"/>
    /// würde <see cref="StringBuilder.MaxCapacity"/> überschritten.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendBase64(this StringBuilder builder,
                                             byte[]? bytes,
                                             Base64FormattingOptions options = Base64FormattingOptions.None) 
        => Base64.AppendEncodedTo(builder, bytes.AsSpan(), options);


    /// <summary>
    /// Fügt den Inhalt einer schreibgeschützten Bytespanne als Base64-kodierte Zeichenfolge
    /// am Ende eines <see cref="StringBuilder"/>-Objekts an.
    /// </summary>
    /// <param name="builder">Der <see cref="StringBuilder"/>, an den Zeichen angefügt werden.</param>
    /// <param name="bytes">Die schreibgeschützte Bytespanne, die die anzufügenden Daten enthält.</param>
    /// <param name="options">Ein Enumerationswert, der es erlaubt festzulegen, ob in das Base64 automatisch Zeilenumbrüche 
    /// eingefügt werden sollen.</param>
    /// <returns>Ein Verweis auf <paramref name="builder"/>, nachdem der Anfügevorgang abgeschlossen wurde.</returns>
    /// <remarks>Die Methode verwendet eine eigene Base64-Implementierung, die etwas langsamer als die BCL-Methoden
    /// ist, aber für den Zweck sehr viel weniger Heap-Speicher alloziert.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="builder"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Bei der Erhöhung der Kapazität von <paramref name="builder"/>
    /// würde <see cref="StringBuilder.MaxCapacity"/> überschritten.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendBase64(this StringBuilder builder,
                                             ReadOnlySpan<byte> bytes,
                                             Base64FormattingOptions options = Base64FormattingOptions.None)
        => Base64.AppendEncodedTo(builder, bytes, options);
    
}
