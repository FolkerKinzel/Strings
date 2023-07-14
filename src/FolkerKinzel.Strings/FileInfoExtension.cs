using System.IO;

namespace FolkerKinzel.Strings;

/// <summary>
/// Erweiterungsmethoden für die <see cref="FileInfo"/>-Klasse.
/// </summary>
public static class FileInfoExtension
{
    internal const int ISUTF8_COUNT = 255;
    internal const int EXAMINE_WHOLE_FILE = -1;
    internal const int ISUTF8VALID_COUNT = EXAMINE_WHOLE_FILE;
    private const int INITIAL_BUFSIZE = 128;
    private const int MAX_BUFSIZE = 4096;
    private const int BUFSIZE_FACTOR = 4;


    /// <summary>
    /// Testet, ob der Abschnitt der durch <paramref name="fileInfo"/> angegebenen Datei, der sich vom Dateianfang über mindestens
    /// <paramref name="count"/> Zeichen erstreckt, UTF-8-Text ist. Die Methode bezieht das Byte-Order-Mark (BOM)
    /// in die Prüfung ein.
    /// </summary>
    /// <param name="fileInfo">Ein <see cref="FileInfo"/>-Objekt, das auf die zu überprüfende Datei verweist.</param>
    /// <param name="count">Die Anzahl der mindestens zu überprüfenden Buchstaben. Wenn dem Parameter eine negative Zahl übergeben 
    /// wird oder wenn <paramref name="count"/> größer ist als die
    /// Länge der Daten in der angegebenen Datei, wird die gesamte Datei überprüft. Wird dem Parameter <c>0</c> übergeben, überprüft 
    /// die Methode nur das Byte-Order-Mark (BOM).</param>
    /// 
    /// <returns><c>true</c>, wenn der überprüfte Dateiabschnitt UTF-8-Text darstellt, andernfalls <c>false</c>.
    /// Wenn die Methode ein UTF-8-BOM findet, wird in jedem Fall <c>true</c> zurückgegeben. Wenn <paramref name="count"/>&#160;<c>0</c> ist 
    /// und kein UTF-8-BOM gefunden wird, wird <c>false</c> zurückgegeben.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="fileInfo"/> ist <c>null</c>.</exception>
    /// <exception cref="IOException">E/A Fehler.</exception>
    public static bool IsUtf8(this FileInfo fileInfo, int count = ISUTF8_COUNT)
    {
        using FileStream stream = InitFileStream(fileInfo, count);
        return stream.IsUtf8(count, false);
    }

    /// <summary>
    /// Testet, ob der Abschnitt der durch <paramref name="fileInfo"/> angegebenen Datei, der sich vom Dateianfang über mindestens
    /// <paramref name="count"/> Zeichen erstreckt, gültiges UTF-8 darstellt.
    /// </summary>
    /// 
    /// <param name="fileInfo">Ein <see cref="FileInfo"/>-Objekt, das auf die zu überprüfende Datei verweist.</param>
    /// <param name="count">Die Anzahl der mindestens zu überprüfenden Buchstaben. Wenn dem Parameter eine negative Zahl übergeben 
    /// wird (Default) oder wenn <paramref name="count"/> größer ist als die
    /// Länge der Daten in der angegebenen Datei, wird die gesamte Datei überprüft. Der Wert <c>0</c> ist nicht erlaubt.</param>
    /// <returns><c>true</c>, wenn der überprüfte Dateiabschnitt gültiges UTF-8 darstellt, andernfalls <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="fileInfo"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> ist <c>0</c>.</exception>
    /// <exception cref="IOException">E/A Fehler.</exception>
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
