using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;


/// <summary>
/// Erweiterungsmethoden für die <see cref="Stream"/>-Klasse.
/// </summary>
public static class StreamExtension
{
    public const int ExaminationLength = -1;

    public static bool IsUtf8(this Stream stream, int count = -1, bool leaveOpen = false)
    {
        var validator = new Utf8Validator();
        return validator.IsUtf8(stream, count, leaveOpen);
    }

    public static bool IsValidUtf8(this Stream stream, int count = -1, bool leaveOpen = false)
    {
        var validator = new Utf8Validator();
        return validator.IsValidUtf8(stream, count, leaveOpen);
    }
}
