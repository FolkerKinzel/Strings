namespace FolkerKinzel.Strings;

/// <summary>
/// Erweiterungsmethoden für die <see cref="Encoding"/>-Klasse.
/// </summary>
public static class EncodingExtension
{
    [SuppressMessage("Style", "IDE0022:Ausdruckskörper für Methode verwenden", Justification = "<Ausstehend>")]
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
    public static string GetString(this Encoding encoding, ReadOnlySpan<byte> bytes) =>
        encoding == null ? throw new NullReferenceException()
                         : encoding.GetString(bytes.ToArray());
#endif
}
