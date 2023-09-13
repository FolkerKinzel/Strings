using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder AppendUrlEncoded(this StringBuilder builder, ReadOnlySpan<char> value)
        => UrlEncoding.AppendUrlEncodedTo(builder, value);

}
