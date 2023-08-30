using System.Diagnostics;
using System.Runtime.InteropServices;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings;

[SuppressMessage("Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", Justification = "<Ausstehend>")]
public static class Base64
{
    private const string LINE_BREAK = "\r\n";
    private const int LINE_LENGTH = 76;

    private const string IDX = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
    private const int CHAR_MASK = 0b11_1111;
    private const int CHUNK_LENGTH = 3;
    private const int CHAR_WIDTH = 6;

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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Encode(byte[] bytes, Base64FormattingOptions options = Base64FormattingOptions.None) =>
        bytes is null ? throw new ArgumentNullException(nameof(bytes))
                      : Convert.ToBase64String(bytes, options);


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Encode(byte[] bytes, int offset, int length, Base64FormattingOptions options = Base64FormattingOptions.None) =>
        bytes is null ? throw new ArgumentNullException(nameof(bytes))
                      : Convert.ToBase64String(bytes, offset, length, options);


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Encode(ReadOnlySpan<byte> bytes, Base64FormattingOptions options = Base64FormattingOptions.None) =>
#if NET45 || NETSTANDARD2_0
        Convert.ToBase64String(bytes.ToArray(), options);
#else
        Convert.ToBase64String(bytes, options);
#endif


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte[] GetBytes(string base64) => Convert.FromBase64String(base64 ?? throw new ArgumentNullException(nameof(base64)));


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte[] GetBytes(string base64, Base64ParserOptions options) =>
        base64 == null ? throw new ArgumentNullException(nameof(base64))
                       : GetBytes(base64.AsSpan(), options);


    public static byte[] GetBytes(ReadOnlySpan<char> base64, Base64ParserOptions options)
    {
        base64 = base64.Trim();

        if (base64.IsEmpty)
        {
#if NET45
            return new byte[0];
#else
            return Array.Empty<byte>();
#endif
        }

        int missingPaddingCount = options.HasFlag(Base64ParserOptions.AcceptMissingPadding) ? GetMissingPaddingCount(base64.Length) : 0;

        bool isBase64Url = options.HasFlag(Base64ParserOptions.AcceptBase64Url) && IsBase64Url(base64);

        if (missingPaddingCount != 0 || isBase64Url)
        {
            var sb = new StringBuilder();
            sb.EnsureCapacity(base64.Length + missingPaddingCount);
            _ = sb.Append(base64);

            if (isBase64Url)
            {
                sb.Replace('-', '+').Replace('_', '/');
            }

            for (int i = 0; i < missingPaddingCount; i++)
            {
                sb.Append('=');
            }

            return Convert.FromBase64String(sb.ToString());
        }

        return DoGetBytes(base64);

        /////////////////////////////////////////////////////

        static int GetMissingPaddingCount(int base64Length) =>
            (base64Length % 4) switch { 0 => 0, 2 => 2, 3 => 1, _ => throw new FormatException() };
        

        static bool IsBase64Url(ReadOnlySpan<char> base64) => base64.ContainsAny("-_".AsSpan());

    }

    public static byte[] GetBytes(ReadOnlySpan<char> base64)
    {
        base64 = base64.Trim();

        if (base64.IsEmpty)
        {
#if NET45
            return new byte[0];
#else
            return Array.Empty<byte>();
#endif
        }

        return DoGetBytes(base64);
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
}
