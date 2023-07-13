using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

public static class StreamExtension
{
    public static bool IsUtf8(this Stream stream, long count = -1, bool leaveOpen = false) => 
        stream == null ? throw new ArgumentNullException(nameof(stream)) 
                       : IsUtf8Internal(stream, count, leaveOpen);

    public static bool IsValidUtf8(this Stream stream, long count = -1, bool leaveOpen = false) => 
        stream == null ? throw new ArgumentNullException(nameof(stream))
                       : IsValidUtf8Internal(stream, count, leaveOpen);

    internal static bool IsUtf8Internal(this Stream stream, long count, bool leaveOpen)
    {
        var validator = new Utf8Validator();
        return validator.IsUtf8(stream, count, leaveOpen);
    }

    internal static bool IsValidUtf8Internal(this Stream stream, long count, bool leaveOpen)
    {
        var validator = new Utf8Validator();
        return validator.IsValidUtf8(stream, count, leaveOpen);
    }
}
