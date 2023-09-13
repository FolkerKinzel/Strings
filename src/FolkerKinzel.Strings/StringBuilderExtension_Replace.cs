using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings;

public static partial class StringBuilderExtension
{

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder Replace(this StringBuilder builder, string oldValue, string? newValue, int startIndex)
        => builder?.Replace(oldValue, newValue, startIndex, builder.Length - startIndex) ?? throw new ArgumentNullException(nameof(builder));


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringBuilder Replace(this StringBuilder builder, char oldValue, char newValue, int startIndex)
        => builder?.Replace(oldValue, newValue, startIndex, builder.Length - startIndex) ?? throw new ArgumentNullException(nameof(builder));
}
