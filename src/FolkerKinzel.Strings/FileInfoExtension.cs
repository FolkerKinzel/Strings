namespace FolkerKinzel.Strings;

public static class FileInfoExtension
{
    public static bool IsUtf8(this FileInfo fileInfo, long count = -1)
    {
        if (fileInfo == null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        using FileStream stream = fileInfo.OpenRead();
        return stream.IsUtf8Internal(count, false);
    }

    public static bool IsValidUtf8(this FileInfo fileInfo, long count = -1)
    {
        if (fileInfo == null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        using FileStream stream = fileInfo.OpenRead();
        return stream.IsValidUtf8Internal(count, false);
    }
}
