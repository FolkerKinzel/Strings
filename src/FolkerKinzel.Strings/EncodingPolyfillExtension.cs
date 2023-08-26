namespace FolkerKinzel.Strings;

public static class EncodingPolyfillExtension
{
    // Don't move this to the namespace FolkerKinzel.Strings.Polyfills because the Polyfills are for 
    // instance methods.

    // Place this preprocessor directive inside the class to let .NETSTANDARD 2.1 and above have an empty class!
#if NET45 || NETSTANDARD2_0
    public static string GetString(this Encoding encoding, ReadOnlySpan<byte> bytes) => 
        encoding == null ? throw new NullReferenceException()
                         : encoding.GetString(bytes.ToArray());
#endif
}
