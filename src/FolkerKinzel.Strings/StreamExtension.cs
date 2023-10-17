using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings;

/// <summary>Extension methods for the <see cref="Stream" /> class.</summary>
public static class StreamExtension
{
    /// <summary>Tests whether the specified section of <paramref name="stream" /> that extends
    /// at least <paramref name="count" /> decoded characters from the current <see cref="Stream.Position"
    /// /> is UTF-8 text. The method includes the byte order mark (BOM) in the check.</summary>
    /// <param name="stream">The <see cref="Stream" /> to test.</param>
    /// <param name="count">The minimum number of characters to check. If <paramref name="count"
    /// /> is larger than <paramref name="stream" /> has data, <paramref name="stream" />
    /// is examined beginning from the current <see cref="Stream.Position" /> until EOF.
    /// If the parameter is passed a negative number or if <paramref name="count" /> is greater
    /// than the length of the data in <paramref name="stream" />, <paramref name="stream"
    /// /> is checked from the current position until EOF. If <c>0</c> is passed to the parameter,
    /// the method only checks the byte order mark (BOM).</param>
    /// <param name="leaveOpen"> <c>true</c> to leave the stream open after the method has
    /// finished; otherwise, <c>false</c>.</param>
    /// <returns> <c>true</c> if the checked stream section represents UTF-8 text, <c>false</c>
    /// otherwise. In any case, if the method finds a UTF-8 BOM, it returns <c>true</c>.
    /// If <paramref name="count" /> is <c>0</c> and no UTF-8 BOM is found, <c>false</c>
    /// is returned.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="stream" /> is <c>null</c>.</exception>
    /// <exception cref="IOException">I/O error.</exception>
    /// <exception cref="ObjectDisposedException"> <paramref name="stream" /> was already
    /// closed.</exception>
    /// <exception cref="NotSupportedException"> <paramref name="stream" /> doesn't support
    /// read and seek operations.</exception>
    public static bool IsUtf8(this Stream stream,
                              int count = FileInfoExtension.ISUTF8_COUNT,
                              bool leaveOpen = false)
    {
        var validator = new Utf8Validator();
        return validator.IsUtf8(stream, count, leaveOpen);
    }


    /// <summary>Tests whether the byte sequence of <paramref name="stream" /> that starts
    /// with the current <see cref="Stream.Position" /> and is at least <paramref name="count"
    /// /> characters long is valid UTF-8.</summary>
    /// <param name="stream">The <see cref="Stream" /> to test.</param>
    /// <param name="count">The minimum number of characters to check. If a negative number
    /// is passed to the parameter (default) or if <paramref name="count" /> is greater than
    /// the length of the data in <paramref name="stream" />, <paramref name="stream" />
    /// is checked beginning from its current <see cref="Stream.Position" /> until EOF. The
    /// value <c>0</c> is not allowed.</param>
    /// <param name="leaveOpen"> <c>true</c> to leave the stream open after the method has
    /// finished; otherwise, <c>false</c>.</param>
    /// <returns> <c>true</c> if the checked stream section represents valid UTF-8, <c>false</c>
    /// otherwise.</returns>
    /// <exception cref="ArgumentNullException"> <paramref name="stream" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"> <paramref name="count" /> is <c>0</c>.</exception>
    /// <exception cref="IOException">I/O error.</exception>
    /// <exception cref="ObjectDisposedException"> <paramref name="stream" /> was already
    /// closed.</exception>
    /// <exception cref="NotSupportedException"> <paramref name="stream" /> doesn't support
    /// read operations.</exception>
    public static bool IsUtf8Valid(this Stream stream,
                                   int count = FileInfoExtension.ISUTF8VALID_COUNT,
                                   bool leaveOpen = false)
    {
        var validator = new Utf8Validator();
        return validator.IsUtf8Valid(stream, count, leaveOpen);
    }
}
