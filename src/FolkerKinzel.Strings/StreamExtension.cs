using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;


/// <summary>
/// Erweiterungsmethoden für die <see cref="Stream"/>-Klasse.
/// </summary>
public static class StreamExtension
{
    /// <summary>
    /// Testet, ob der angegebene Abschnitt von <paramref name="stream"/>, der sich von der aktuellen <see cref="Stream.Position"/>
    /// über mindestens <paramref name="count"/> Zeichen erstreckt, UTF-8-Text ist. Die Methode bezieht das Byte-Order-Mark (BOM)
    /// in die Prüfung ein.
    /// </summary>
    /// <param name="stream">Der zu testende <see cref="Stream"/>.</param>
    /// <param name="count">Die Anzahl der mindestens zu überprüfenden Buchstaben. Wenn dem Parameter eine negative Zahl übergeben 
    /// wird oder wenn <paramref name="count"/> größer ist als die
    /// Länge der Daten in <paramref name="stream"/>, wird <paramref name="stream"/> von der aktuellen <see cref="Stream.Position"/> 
    /// bis zu seinem Ende (EOF) überprüft. Wird dem Parameter <c>0</c> übergeben, überprüft die Methode nur das Byte-Order-Mark (BOM).</param>
    /// <param name="leaveOpen"><c>false</c>, damit die Methode <paramref name="stream"/> schließt, andernfalls <c>true</c>.</param>
    /// <returns><c>true</c>, wenn der in <paramref name="stream"/> überprüfte Abschnitt UTF-8-Text darstellt, andernfalls <c>false</c>.
    /// Wenn die Methode ein UTF-8-BOM findet, wird in jedem Fall <c>true</c> zurückgegeben. Wenn <paramref name="count"/>&#160;<c>0</c> ist 
    /// und kein UTF-8-BOM gefunden wird, wird <c>false</c> zurückgegeben.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream"/> ist <c>null</c>.</exception>
    /// <exception cref="IOException">E/A Fehler.</exception>
    /// <exception cref="ObjectDisposedException"><paramref name="stream"/> war bereits geschlossen.</exception>
    /// <exception cref="NotSupportedException"><paramref name="stream"/> unterstützt keine Lesevorgänge oder keinen wahlfreien Zugriff.</exception>
    public static bool IsUtf8(this Stream stream, int count = FileInfoExtension.ISUTF8_COUNT, bool leaveOpen = false)
    {
        var validator = new Utf8Validator();
        return validator.IsUtf8(stream, count, leaveOpen);
    }


    /// <summary>
    /// Testet, ob der angegebene Abschnitt von <paramref name="stream"/>, der sich von der aktuellen <see cref="Stream.Position"/>
    /// über mindestens <paramref name="count"/> Zeichen erstreckt, gültiges UTF-8 darstellt.
    /// </summary>
    /// <param name="stream">Der zu testende <see cref="Stream"/>.</param>
    /// <param name="count">Die Anzahl der mindestens zu überprüfenden Buchstaben. Wenn dem Parameter eine negative Zahl übergeben 
    /// wird (Default) oder wenn <paramref name="count"/> größer ist als die
    /// Länge der Daten in <paramref name="stream"/>, wird <paramref name="stream"/> von der aktuellen <see cref="Stream.Position"/> 
    /// bis zu seinem Ende (EOF) überprüft. Der Wert <c>0</c> ist nicht erlaubt.</param>
    /// <param name="leaveOpen"><c>false</c>, damit die Methode <paramref name="stream"/> schließt, andernfalls <c>true</c>.</param>
    /// <returns><c>true</c>, wenn der in <paramref name="stream"/> überprüfte Abschnitt gültiges UTF-8 darstellt, andernfalls <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="stream"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> ist <c>0</c>.</exception>
    /// <exception cref="IOException">E/A Fehler.</exception>
    /// <exception cref="ObjectDisposedException"><paramref name="stream"/> war bereits geschlossen.</exception>
    /// <exception cref="NotSupportedException"><paramref name="stream"/> unterstützt keine Lesevorgänge.</exception>
    public static bool IsUtf8Valid(this Stream stream, int count = FileInfoExtension.ISUTF8VALID_COUNT, bool leaveOpen = false)
    {
        var validator = new Utf8Validator();
        return validator.IsUtf8Valid(stream, count, leaveOpen);
    }
}
