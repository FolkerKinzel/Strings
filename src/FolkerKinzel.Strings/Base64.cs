using System.Diagnostics;
using System.Runtime.InteropServices;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings;

/// <summary>
/// Statische Klasse, die Methoden zu Verfügung stellt, um Zeichenfolgen im Base64-Format zu enkodieren und zu dekodieren.
/// </summary>
[SuppressMessage("Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", Justification = "<Ausstehend>")]
public static class Base64
{
    private const string LINE_BREAK = "\r\n";
    private const int LINE_LENGTH = 76;

    private const string IDX = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
    private const int CHAR_MASK = 0b11_1111;
    private const int CHUNK_LENGTH = 3;
    private const int CHAR_WIDTH = 6;
    private const string URL_ENCODED_PADDING = "%3d";

    /// <summary>
    /// Konvertiert eine Sammlung von 8-Bit-Ganzzahlen ohne Vorzeichen in die entsprechende mit Base64-Ziffern 
    /// codierte Zeichenfolgendarstellung. Sie können festlegen, ob im Rückgabewert Zeilenumbrüche eingefügt 
    /// werden sollen.
    /// </summary>
    /// <param name="bytes">Eine Sammlung von 8-Bit-Ganzzahlen ohne Vorzeichen.</param>
    /// <param name="options">Einer der Enumerationswerte, die angeben, ob im Rückgabewert Zeilenumbrüche eingefügt 
    /// werden sollen. Der Standardwert ist 
    /// <see cref="Base64FormattingOptions.None"/>.</param>
    /// <returns>Die Zeichenfolgendarstellung der Elemente in <paramref name="bytes"/> als Base64.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="bytes"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentException"><paramref name="options"/> ist kein gültiger <see cref="Base64FormattingOptions"/>-Wert.</exception>
    public static string Encode(IEnumerable<byte> bytes, Base64FormattingOptions options = Base64FormattingOptions.None)
    {
        if (bytes == null)
        {
            throw new ArgumentNullException(nameof(bytes));
        }

        return bytes switch
        {
            byte[] arr => Convert.ToBase64String(arr, options),
#if NET5_0_OR_GREATER
            List<byte> list => Convert.ToBase64String(CollectionsMarshal.AsSpan(list), options),
#endif
            _ => Convert.ToBase64String(bytes.ToArray(), options),
        };
    }

    /// <summary>
    /// Konvertiert ein Array von 8-Bit-Ganzzahlen ohne Vorzeichen in die entsprechende mit Base64-Ziffern 
    /// codierte Zeichenfolgendarstellung. Sie können festlegen, ob im Rückgabewert Zeilenumbrüche eingefügt 
    /// werden sollen.
    /// </summary>
    /// <param name="bytes">Ein Array von 8-Bit-Ganzzahlen ohne Vorzeichen.</param>
    /// <param name="options">Einer der Enumerationswerte, die angeben, ob im Rückgabewert Zeilenumbrüche eingefügt 
    /// werden sollen. Der Standardwert ist 
    /// <see cref="Base64FormattingOptions.None"/>.</param>
    /// <returns>Die Zeichenfolgendarstellung der Elemente in <paramref name="bytes"/> als Base64.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="bytes"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentException"><paramref name="options"/> ist kein gültiger <see cref="Base64FormattingOptions"/>-Wert.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Encode(byte[] bytes, Base64FormattingOptions options = Base64FormattingOptions.None) =>
        bytes is null ? throw new ArgumentNullException(nameof(bytes))
                      : Convert.ToBase64String(bytes, options);

    /// <summary>
    /// Konvertiert eine Teilmenge eines Arrays von 8-Bit-Ganzzahlen ohne Vorzeichen in die entsprechende mit 
    /// Base64-Ziffern codierte Zeichenfolgendarstellung. Parameter geben die Teilmenge als Offset im Eingabearray, 
    /// die Anzahl der zu konvertierenden Bytes sowie ggf. im Rückgabewert einzufügende Zeilenumbrüche an.
    /// </summary>
    /// <param name="bytes">Ein Array von 8-Bit-Ganzzahlen ohne Vorzeichen.</param>
    /// <param name="offset">Ein Offset in <paramref name="bytes"/>.</param>
    /// <param name="length">Die Anzahl der zu konvertierenden Bytes.</param>
    /// <param name="options">Einer der Enumerationswerte, die angeben, ob im Rückgabewert Zeilenumbrüche eingefügt werden sollen. 
    /// Der Standardwert ist 
    /// <see cref="Base64FormattingOptions.None"/>.</param>
    /// <returns>Die Zeichenfolgendarstellung von <paramref name="length"/> Bytes aus dem Array <paramref name="bytes"/> ab dem
    /// Index <paramref name="offset"/> als Base64.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="bytes"/> ist <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <para> <paramref name="offset"/> oder <paramref name="length"/> ist ein negativer Wert.</para>
    /// <para>- oder -</para>
    /// <para><paramref name="offset"/> plus <paramref name="length"/> ist größer als die Länge von <paramref name="bytes"/>.</para>
    /// </exception>
    /// <exception cref="ArgumentException"><paramref name="options"/> ist kein gültiger <see cref="Base64FormattingOptions"/>-Wert.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Encode(byte[] bytes, int offset, int length, Base64FormattingOptions options = Base64FormattingOptions.None) =>
        bytes is null ? throw new ArgumentNullException(nameof(bytes))
                      : Convert.ToBase64String(bytes, offset, length, options);


    /// <summary>
    /// Konvertiert die 8-Bit-Ganzzahlen ohne Vorzeichen in der angegebenen schreibgeschützten Spanne in eine entsprechende Zeichenfolgendarstellung, 
    /// die mit Base64-Ziffern codiert ist. Sie können optional angeben, ob im Rückgabewert Zeilenumbrüche eingefügt werden sollen.
    /// </summary>
    /// <param name="bytes">Eine schreibgeschützte Spanne von 8-Bit-Ganzzahlen ohne Vorzeichen.</param>
    /// <param name="options">Einer der Enumerationswerte, die angeben, ob im Rückgabewert Zeilenumbrüche eingefügt werden sollen. Der Standardwert ist 
    /// <see cref="Base64FormattingOptions.None"/>.</param>
    /// <returns>Die Zeichenfolgendarstellung der Elemente in <paramref name="bytes"/> als Base64. Wenn die Länge von <paramref name="bytes"/> 0 ist, 
    /// wird eine leere Zeichenfolge zurückgegeben.</returns>
    /// <remarks>
    /// <note type="note">
    /// Da die Methode in der .NET-Framework 4.5 und .NET Standard 2.0 Version des nuget-Pakets aus <paramref name="bytes"/> ein neues
    /// Array alloziert, wird empfohlen, aus Performancegründen nach Möglichkeit auf die Überladung 
    /// <see cref="Encode(byte[], int, int, Base64FormattingOptions)"/> oder <see cref="Encode(byte[], Base64FormattingOptions)"/> zurückzugreifen,
    /// wenn alte Frameworks unterstützt werden müssen.
    /// </note>
    /// </remarks>
    /// <exception cref="ArgumentException"><paramref name="options"/> ist kein gültiger <see cref="Base64FormattingOptions"/>-Wert.</exception>
    /// <exception cref="OutOfMemoryException">Die Ausgabelänge war größer als <see cref="int.MaxValue">Int32.MaxValue</see>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Encode(ReadOnlySpan<byte> bytes, Base64FormattingOptions options = Base64FormattingOptions.None) =>
#if NET45 || NETSTANDARD2_0
        Convert.ToBase64String(bytes.ToArray(), options);
#else
        Convert.ToBase64String(bytes, options);
#endif


    /// <summary>
    /// Konvertiert die angegebene Zeichenfolge, die Binärdaten als Base-64-Ziffern codiert, in ein entsprechendes Array 
    /// von 8-Bit-Ganzzahlen ohne Vorzeichen.
    /// </summary>
    /// <param name="base64">Die zu konvertierende Zeichenfolge.</param>
    /// <returns>Ein Array von 8-Bit-Ganzzahlen ohne Vorzeichen, das <paramref name="base64"/> entspricht.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="base64"/> ist <c>null</c>.</exception>
    /// <exception cref="FormatException">
    /// <para>Die Länge von <paramref name="base64"/> bei ignorierten Leerzeichen ist nicht 0 (null) oder ein Vielfaches von 4.</para>
    /// <para>- oder -</para>
    /// <para>Das Format von <paramref name="base64"/> ist ungültig. <paramref name="base64"/> enthält ein Nicht-Base-64-Zeichen, 
    /// mehr als zwei Füllzeichen oder in den 
    /// Füllzeichen ein Zeichen, das kein Leerzeichen ist.</para>
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte[] GetBytes(string base64) => Convert.FromBase64String(base64 ?? throw new ArgumentNullException(nameof(base64)));


    /// <summary>
    /// Konvertiert die angegebene Zeichenfolge, die Binärdaten als Base-64-Ziffern codiert, in ein entsprechendes Array 
    /// von 8-Bit-Ganzzahlen ohne Vorzeichen und erlaubt es, Optionen für die Konvertierung anzugeben.
    /// </summary>
    /// <param name="base64">Die zu konvertierende Zeichenfolge.</param>
    /// <param name="options">Optionen für die Konvertierung.</param>
    /// <returns>Ein Array von 8-Bit-Ganzzahlen ohne Vorzeichen, das <paramref name="base64"/> entspricht.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="base64"/> ist <c>null</c>.</exception>
    /// <exception cref="FormatException">
    /// <paramref name="base64"/> lässt sich - abhängig von den mit <paramref name="options"/> angegebenen Konvertierungsoptionen - 
    /// nicht in gültiges Base64 umwandeln.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte[] GetBytes(string base64, Base64ParserOptions options) =>
        base64 == null ? throw new ArgumentNullException(nameof(base64))
                       : GetBytes(base64.AsSpan(), options);

    /// <summary>
    /// Konvertiert die angegebene schreibgeschützte Zeichenspanne, die Binärdaten als Base-64-Ziffern codiert, in ein entsprechendes Array 
    /// von 8-Bit-Ganzzahlen ohne Vorzeichen und erlaubt es, Optionen für die Konvertierung anzugeben.
    /// </summary>
    /// <param name="base64">Die zu konvertierende schreibgeschützte Zeichenspanne.</param>
    /// <param name="options">Optionen für die Konvertierung.</param>
    /// <returns>Ein Array von 8-Bit-Ganzzahlen ohne Vorzeichen, das <paramref name="base64"/> entspricht.</returns>
    /// <exception cref="FormatException">
    /// <paramref name="base64"/> lässt sich - abhängig von den mit <paramref name="options"/> angegebenen Konvertierungsoptionen - 
    /// nicht in gültiges Base64 umwandeln.
    /// </exception>
    public static byte[] GetBytes(ReadOnlySpan<char> base64, Base64ParserOptions options)
    {
        base64 = base64.Trim();

        if (base64.IsEmpty)
        {
            return GetEmptyByteArray();
        }

        char[]? arr = null;
        Span<char> contentSpan = default;

        if (options.HasFlag(Base64ParserOptions.AcceptBase64Url) && IsBase64Url(base64))
        {
            arr = new char[base64.Length + 2];
            contentSpan = arr.AsSpan(0, base64.Length);
            base64.CopyTo(contentSpan);

            int urlEncodedPaddingCount = ReplaceUrlEncodedPadding(arr, ref contentSpan);
            ReplaceBase64UrlChars(contentSpan, urlEncodedPaddingCount);
        }

        int missingPaddingCount = options.HasFlag(Base64ParserOptions.AcceptMissingPadding) ? GetMissingPaddingCount(base64) : 0;

        if (missingPaddingCount != 0)
        {
            if (arr is null)
            {
                arr = new char[base64.Length + missingPaddingCount];
                contentSpan = arr.AsSpan();
                base64.CopyTo(contentSpan);
            }
            else
            {
                Debug.Assert(arr.Length >= contentSpan.Length + missingPaddingCount);
                contentSpan = arr.AsSpan(0, contentSpan.Length + missingPaddingCount);
            }

            ApplyPadding(contentSpan, missingPaddingCount);
        }

        return arr == null ? DoGetBytes(base64) : DoGetBytes(contentSpan);

        /////////////////////////////////////////////////////

        static int GetMissingPaddingCount(ReadOnlySpan<char> base64)
        {
            int whiteSpaceLength = 0;

            for (int i = 0; i < base64.Length; i++)
            {
                if (base64[i] < '!')
                {
                    whiteSpaceLength++;
                }
            }

            return ((base64.Length - whiteSpaceLength) % 4) switch { 0 => 0, 2 => 2, 3 => 1, _ => throw new FormatException() };
        }

        static bool IsBase64Url(ReadOnlySpan<char> base64)
            => base64.EndsWith(URL_ENCODED_PADDING, StringComparison.OrdinalIgnoreCase) || base64.ContainsAny("-_");


        static int ReplaceUrlEncodedPadding(char[]? arr, ref Span<char> contentSpan)
        {
            int urlEncodedPaddingCount = 0;

            while (contentSpan.EndsWith(URL_ENCODED_PADDING, StringComparison.OrdinalIgnoreCase))
            {
                contentSpan = contentSpan.Slice(0, contentSpan.Length - 3);
                urlEncodedPaddingCount++;
            }

            if (urlEncodedPaddingCount != 0)
            {
                contentSpan = arr.AsSpan(0, contentSpan.Length + urlEncodedPaddingCount);
                ApplyPadding(contentSpan, urlEncodedPaddingCount);
            }

            return urlEncodedPaddingCount;
        }

        static void ReplaceBase64UrlChars(Span<char> contentSpan, int urlEncodedPaddingCount)
        {
            int replacementLength = contentSpan.Length - urlEncodedPaddingCount;
            for (int i = 0; i < replacementLength; i++)
            {
                char c = contentSpan[i];

                if (c == '-')
                {
                    contentSpan[i] = '+';
                }
                else if (c == '_')
                {
                    contentSpan[i] = '/';
                }
            }
        }

        static void ApplyPadding(Span<char> span, int urlEncodedPaddingCount)
        {
            for (int i = 1; i <= urlEncodedPaddingCount; i++)
            {
                span[span.Length - i] = '=';
            }
        }
    }


    /// <summary>
    /// Konvertiert die angegebene schreibgeschützte Zeichenspanne, die Binärdaten als Base-64-Ziffern codiert, in ein entsprechendes Array 
    /// von 8-Bit-Ganzzahlen ohne Vorzeichen.
    /// </summary>
    /// <param name="base64">Die zu konvertierende schreibgeschützte Zeichenspanne.</param>
    /// <returns>Ein Array von 8-Bit-Ganzzahlen ohne Vorzeichen, das <paramref name="base64"/> entspricht.</returns>
    /// <exception cref="FormatException">
    /// <para>Die Länge von <paramref name="base64"/> bei ignorierten Leerzeichen ist nicht 0 (null) oder ein Vielfaches von 4.</para>
    /// <para>- oder -</para>
    /// <para>Das Format von <paramref name="base64"/> ist ungültig. <paramref name="base64"/> enthält ein Nicht-Base-64-Zeichen, 
    /// mehr als zwei Füllzeichen oder in den 
    /// Füllzeichen ein Zeichen, das kein Leerzeichen ist.</para>
    /// </exception>
    public static byte[] GetBytes(ReadOnlySpan<char> base64)
    {
        base64 = base64.Trim();
        return base64.IsEmpty ? GetEmptyByteArray() : DoGetBytes(base64);
    }

    private static byte[] DoGetBytes(ReadOnlySpan<char> base64)
    {
        Debug.Assert(!base64.IsWhiteSpace());

#if NET45 || NETSTANDARD2_0
        return Convert.FromBase64String(base64.ToString());
#else
        int outputSize = ComputeMaxOutputSize(base64);

        byte[] output = new byte[outputSize];

        return Convert.TryFromBase64Chars(base64, output, out outputSize)
            ? output.Length == outputSize ? output : output[0..outputSize]
            : throw new FormatException();
#endif
    }


    private static int ComputeMaxOutputSize(ReadOnlySpan<char> base64)
    {
        int outLength = (base64.Length >> 2) * 3;

        try
        {
            if (base64[base64.Length - 1] == '=')
            {
                --outLength;
            }

            if (base64[base64.Length - 2] == '=')
            {
                --outLength;
            }
        }
        catch
        {
            throw new FormatException();
        }

        return outLength;
    }


    internal static StringBuilder AppendEncodedTo(this StringBuilder builder,
                                                  ReadOnlySpan<byte> bytes,
                                                  Base64FormattingOptions options)
    {
        Debug.Assert(builder != null);

        bool insertLineBreaks = options.HasFlag(Base64FormattingOptions.InsertLineBreaks) && !bytes.IsEmpty;
        builder.EnsureCapacity(builder.Length + ComputeNeededCapacity(bytes.Length, insertLineBreaks));
        int startOfBase64 = builder.Length;

        Base64.AppendEncodedTo(builder, bytes);

        if (insertLineBreaks)
        {
            InsertLineBreaks(builder, startOfBase64);
        }

        return builder;
    }

    private static int ComputeNeededCapacity(int dataLength, bool insertLineBreaks)
    {
        int capacity = (int)Math.Ceiling(dataLength / 3.0) << 2;

        if (insertLineBreaks)
        {
            capacity += dataLength / Base64.LINE_LENGTH * Base64.LINE_BREAK.Length;
        }

        return capacity;
    }

    private static void InsertLineBreaks(StringBuilder builder, int startOfBase64)
    {
        int currentLineStartIndex = builder.LastIndexOf('\n', startOfBase64) + 1;

        if (startOfBase64 - currentLineStartIndex < Base64.LINE_LENGTH)
        {
            startOfBase64 = currentLineStartIndex;
        }
        else
        {
            builder.Insert(startOfBase64, Base64.LINE_BREAK);
            startOfBase64 += Base64.LINE_BREAK.Length;
        }


        int nextLineStart = startOfBase64 + Base64.LINE_LENGTH;
        while (nextLineStart < builder.Length)
        {
            builder.Insert(nextLineStart, Base64.LINE_BREAK);
            nextLineStart += Base64.LINE_BREAK.Length + Base64.LINE_LENGTH;
        }
    }


    private static void AppendEncodedTo(StringBuilder sb, ReadOnlySpan<byte> data)
    {
        Debug.Assert(sb != null);

        // paddingLength may be 3, but finalPartLength is 0 then and no 
        // padding will be added:
        int paddingLength = CHUNK_LENGTH - data.Length % CHUNK_LENGTH;
        int finalPartLength = CHUNK_LENGTH - paddingLength;

        AppendChunks2(sb, data, finalPartLength);

        if (finalPartLength > 0)
        {
            AppendFinalBlock(sb, data, paddingLength, finalPartLength);
        }
    }


    private static void AppendChunks2(StringBuilder sb, ReadOnlySpan<byte> data, int finalPartLength)
    {
        if (data.Length < CHUNK_LENGTH)
        {
            return;
        }

        int counter = 0;
        ReadOnlySpan<char> idx = IDX.AsSpan();

        while (counter < data.Length - finalPartLength)
        {
            int i = data[counter] << 16;
            i |= data[counter + 1] << 8;
            i |= data[counter + 2];

            _ = sb.Append(idx[i >> 3 * CHAR_WIDTH & CHAR_MASK])
                  .Append(idx[i >> 2 * CHAR_WIDTH & CHAR_MASK])
                  .Append(idx[i >> CHAR_WIDTH & CHAR_MASK])
                  .Append(idx[i & CHAR_MASK]);

            counter += CHUNK_LENGTH;
        }
    }


    private static void AppendFinalBlock(StringBuilder sb, ReadOnlySpan<byte> data, int paddingLength, int finalPartLength)
    {
        int dataHolder = 0;

        for (int j = 0; j < finalPartLength; j++)
        {
            dataHolder <<= 8;
            dataHolder |= data[data.Length - (finalPartLength - j)];
        }

        dataHolder <<= paddingLength * 2;

        int remainingDataLength = 4 - paddingLength;

        for (int j = 1; j <= remainingDataLength; j++)
        {
            int shift = (remainingDataLength - j) * CHAR_WIDTH;
            sb.Append(IDX[dataHolder >> shift & CHAR_MASK]);
        }

        for (int j = 0; j < paddingLength; j++)
        {
            sb.Append('=');
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static byte[] GetEmptyByteArray() =>
#if NET45
            return new byte[0];
#else
                Array.Empty<byte>();
#endif


    //    public static byte[] GetBytes2(ReadOnlySpan<char> base64, Base64ParserOptions options)
    //    {
    //        base64 = base64.Trim();

    //        if (base64.IsEmpty)
    //        {
    //#if NET45
    //            return new byte[0];
    //#else
    //            return Array.Empty<byte>();
    //#endif
    //        }

    //        StringBuilder? sb = null;

    //        if (options.HasFlag(Base64ParserOptions.AcceptBase64Url) && IsBase64Url(base64))
    //        {
    //            sb = new StringBuilder();
    //            sb.EnsureCapacity(base64.Length + 2);
    //            _ = sb.Append(base64);

    //            base64 = sb.Replace('-', '+').Replace('_', '/').Replace("%3d", "=").Replace("%3D", "=").ToString().AsSpan();
    //        }

    //        int missingPaddingCount = options.HasFlag(Base64ParserOptions.AcceptMissingPadding) ? GetMissingPaddingCount(base64) : 0;

    //        if (missingPaddingCount != 0)
    //        {
    //            sb ??= new StringBuilder(base64.Length + missingPaddingCount);

    //            for (int i = 0; i < missingPaddingCount; i++)
    //            {
    //                sb.Append('=');
    //            }

    //            return Convert.FromBase64String(sb.ToString());
    //        }

    //        return DoGetBytes(base64);

    //        /////////////////////////////////////////////////////

    //        static int GetMissingPaddingCount(ReadOnlySpan<char> base64)
    //        {
    //            int whiteSpaceLength = 0;

    //            for (int i = 0; i < base64.Length; i++)
    //            {
    //                if (base64[i] < '!')
    //                {
    //                    whiteSpaceLength++;
    //                }
    //            }

    //            return ((base64.Length - whiteSpaceLength) % 4) switch { 0 => 0, 2 => 2, 3 => 1, _ => throw new FormatException() };
    //        }

    //        static bool IsBase64Url(ReadOnlySpan<char> base64) => base64.ContainsAny("-_%".AsSpan());
    //    }
}
