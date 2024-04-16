namespace FolkerKinzel.Strings;

/// <summary> Extension methods for the <see cref="FileInfo" /> class. </summary>
public static class FileInfoExtension
{
    internal const int ISUTF8_COUNT = 255;
    internal const int EXAMINE_WHOLE_FILE = -1;
    internal const int ISUTF8VALID_COUNT = EXAMINE_WHOLE_FILE;
    private const int INITIAL_BUFSIZE = 128;
    private const int MAX_BUFSIZE = 4096;
    private const int BUFSIZE_FACTOR = 4;

    /// <summary>Tests whether the portion of the file specified by <paramref name="fileInfo"
    /// /> that extends at least <paramref name="count" /> characters from the beginning
    /// of the file is UTF-8 text. The method includes the byte order mark (BOM) in the check.</summary>
    /// <param name="fileInfo">A <see cref="FileInfo" /> object that references the file to check.</param>
    /// <param name="count">The minimum number of characters to check. If the parameter is
    /// passed a negative number or if <paramref name="count" /> is greater than the length
    /// of the data in the specified file, the entire file is checked. If <c>0</c> is passed
    /// to the parameter, the method only checks the byte order mark (BOM).</param>
    /// <returns> <c>true</c> if the checked file section represents UTF-8 text, <c>false</c>
    /// otherwise. In any case, if the method finds a UTF-8 BOM, it returns <c>true</c>.
    /// If <paramref name="count" /> is <c>0</c> and no UTF-8 BOM is found, <c>false</c>
    /// is returned.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="fileInfo" /> is <c>null</c>.</exception>
    /// <exception cref="IOException">I/O error.</exception>
    public static bool IsUtf8(this FileInfo fileInfo, int count = ISUTF8_COUNT)
    {
        using FileStream stream = InitFileStream(fileInfo, count);
        return stream.IsUtf8(count, false);
    }

    /// <summary>Tests whether the portion of the file specified by <paramref name="fileInfo"
    /// /> that extends at least <paramref name="count" /> characters from the beginning
    /// of the file represents valid UTF-8.</summary>
    /// <param name="fileInfo">A <see cref="FileInfo" /> object that references the file to 
    /// check.</param>
    /// <param name="count">The minimum number of characters to check. If a negative number
    /// is passed to the parameter (default) or if <paramref name="count" /> is greater than
    /// the length of the data in the specified file, the entire file is checked. The value
    /// <c>0</c> is not allowed.</param>
    /// <returns> <c>true</c> if the checked file section represents valid UTF-8, <c>false</c>
    /// otherwise.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="fileInfo" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="count" /> is <c>0</c>.</exception>
    /// <exception cref="IOException">I/O error.</exception>
    public static bool IsUtf8Valid(this FileInfo fileInfo, int count = ISUTF8VALID_COUNT)
    {
        using FileStream stream = InitFileStream(fileInfo, count);
        return stream.IsUtf8Valid(count, false);
    }

    private static FileStream InitFileStream(FileInfo fileInfo, int count)
    {
        return new FileStream(GetPath(fileInfo),
                              FileMode.Open,
                              FileAccess.Read,
                              FileShare.Read,
                              ComputeBufSize(count < 0 ? fileInfo.Length : count));

        static string GetPath(FileInfo fileInfo) =>
        fileInfo?.FullName ?? throw new ArgumentNullException(nameof(fileInfo));

        static int ComputeBufSize(long count)
        {
            int bufsize = INITIAL_BUFSIZE;
            while (bufsize < count * BUFSIZE_FACTOR && bufsize < MAX_BUFSIZE)
            {
                bufsize *= 2;
            }
            return bufsize;
        }
    }
}
