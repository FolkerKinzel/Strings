namespace FolkerKinzel.Strings.Intls;

#if NET462 || NETSTANDARD2_0

[SuppressMessage("Style", "IDE1006:Naming Styles",
    Justification = "Show as polyfill")]
internal class _Byte
{
    /// <exception cref="ArgumentException"></exception>
    internal static byte ParseHex(ReadOnlySpan<char> span)
    {
        Debug.Assert(span.Length == 2);
        return (byte)((Uri.FromHex(span[0]) << 4) | Uri.FromHex(span[1]));
    }
}
#endif
