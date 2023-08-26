namespace FolkerKinzel.Strings;

/// <summary>
/// Erweiterungsmethoden für die <see cref="Encoding"/>-Klasse.
/// </summary>
public static class EncodingExtension
{
    /// <summary>
    /// Kodiert alle Zeichen in der angegebenen schreibgeschützten Zeichenspanne in eine Bytefolge.
    /// </summary>
    /// <param name="encoding">Das <see cref="Encoding"/>-Objekt, auf dem die Erweiterungsmethode aufgerufen wird.</param>
    /// <param name="chars">Die schreibgeschützte Zeichenspanne, die die zu kodierenden Zeichen enthält.</param>
    /// <returns>Ein Bytearray mit den Ergebnissen der Codierung der angegebenen Zeichen.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="encoding"/> ist <c>null</c>.</exception>
    public static byte[] GetBytes(this Encoding encoding, ReadOnlySpan<char> chars)
    {
        if (encoding == null)
        {
            throw new ArgumentNullException(nameof(encoding));
        }
#if NET45 || NETSTANDARD2_0
        return encoding.GetBytes(chars.ToArray());
#else
        byte[] bytes = new byte[encoding.GetByteCount(chars)];

        _ = encoding.GetBytes(chars, bytes); 
        return bytes;
#endif
    }

    // Don't move this polyfill to the namespace FolkerKinzel.Strings.Polyfills because it polyfills an
    // instance method.
#if NET45 || NETSTANDARD2_0
    /// <summary>
    /// Decodiert alle Bytes in der angegebenen Bytespanne in eine Zeichenfolge.
    /// </summary>
    /// <param name="encoding">Das <see cref="Encoding"/>-Objekt, auf dem die Erweiterungsmethode aufgerufen wird.</param>
    /// <param name="bytes">Eine schreibgeschützte Bytespanne, die in eine Unicode-Zeichenfolge decodiert werden soll.</param>
    /// <returns>Eine Zeichenfolge, die die decodierten Bytes aus der angegebenen schreibgeschützten Spanne enthält.</returns>
    /// <exception cref="NullReferenceException"><paramref name="encoding"/> ist <c>null</c>.</exception>
    /// <remarks>Diese Methode ist ein Polyfill für die entsprechende Instanzmethode neuerer .NET-Versionen. Verwenden Sie
    /// die Methode ausschließlich in der Erweiterungsmethodensyntax.</remarks>
    public static string GetString(this Encoding encoding, ReadOnlySpan<byte> bytes) =>
        encoding == null ? throw new NullReferenceException()
                         : encoding.GetString(bytes.ToArray());
#endif
}
