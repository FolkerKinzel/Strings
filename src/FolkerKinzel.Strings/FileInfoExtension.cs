namespace FolkerKinzel.Strings;

/// <summary>
/// Erweiterungsmethoden für die <see cref="FileInfo"/>-Klasse.
/// </summary>
public static class FileInfoExtension
{
    private const int INITIAL_BUFSIZE = 128;
    private const int MAX_BUFSIZE = 4096;
    private const int BUFSIZE_FACTOR = 4;
    //public static bool IsUtf8(this FileInfo fileInfo, int count = 100)
    //{
    //    using FileStream stream = fileInfo?.OpenRead() ?? throw new ArgumentNullException(nameof(fileInfo));
    //    return stream.IsUtf8(count, false);
    //}

    public static bool IsUtf8(this FileInfo fileInfo, int count = 100)
    {
        string path = fileInfo?.FullName ?? throw new ArgumentNullException(nameof(fileInfo));
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, ComputeBufSize(count < 0 ? fileInfo.Length : count));
        return stream.IsUtf8(count, false);
    }

    private static int ComputeBufSize(long count)
    {
        int bufsize = INITIAL_BUFSIZE;
        while (bufsize < count * BUFSIZE_FACTOR && bufsize < MAX_BUFSIZE)
        {
            bufsize = bufsize * 2;
        }
        return bufsize;
    }

    public static bool IsValidUtf8(this FileInfo fileInfo, int count = -1)
    {
        using FileStream stream = fileInfo.OpenRead() ?? throw new ArgumentNullException(nameof(fileInfo));
        return stream.IsValidUtf8(count, false);
    }
}
