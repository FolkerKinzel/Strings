using System.Diagnostics;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings;

[SuppressMessage("Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", Justification = "<Ausstehend>")]
public static class Base64
{
    internal const string LINE_BREAK = "\r\n";
    internal const int LINE_LENGTH = 76;

    private const string IDX = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
    private const int CHAR_MASK = 0b11_1111;
    private const int CHUNK_LENGTH = 3;
    private const int CHAR_WIDTH = 6;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte[] GetBytes(string s) => Convert.FromBase64String(s);


    public static byte[] GetBytes(ReadOnlySpan<char> base64, Base64ParserOptions options)
    {
        int missingPaddingCount = options.HasFlag(Base64ParserOptions.AcceptMissingPadding) ? GetMissingPaddingCount(base64) : 0;

        bool isBase64Url = options.HasFlag(Base64ParserOptions.AcceptBase64Url) ? IsBase64Url(base64) : false;

        if(missingPaddingCount != 0 ||  isBase64Url)
        {
            if(missingPaddingCount > 2)
            {
                throw new FormatException();
            }

            StringBuilder sb = new StringBuilder();
            sb.EnsureCapacity(base64.Length + missingPaddingCount);
            _ = sb.Append(base64);

            if(isBase64Url)
            {
                sb.Replace('-', '+').Replace('_', '/');
            }

            for (int i = 0; i < missingPaddingCount; i++)
            {
                sb.Append('=');
            }

            return Convert.FromBase64String(sb.ToString());
        }

        return GetBytes(base64);

        /////////////////////////////////////////////////////

        static int GetMissingPaddingCount(ReadOnlySpan<char> base64) => 4 - (base64.Length % 4);
        
        static bool IsBase64Url(ReadOnlySpan<char> base64) => base64.ContainsAny("-_".AsSpan());
        
    }


    public static byte[] GetBytes(ReadOnlySpan<char> base64)
    {
#if NET45 || NETSTANDARD2_0
        return Convert.FromBase64String(base64.ToString());
#else
        int outPutSize = ComputeMaxOutputSize(base64);
        if (outPutSize == 0)
        {
#if NET45
            return new byte[0];
#else
            return Array.Empty<byte>();
#endif
        }

        byte[] output = new byte[outPutSize];

        return Convert.TryFromBase64Chars(base64, output, out outPutSize)
            ? output.Length == outPutSize ? output : output[0..outPutSize]
            : throw new FormatException();
#endif
    }

    private static int ComputeMaxOutputSize(ReadOnlySpan<char> base64)
    {
        if (base64.IsWhiteSpace())
        {
            return 0;
        }
        else
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
            catch { throw new FormatException(); }

            return outLength;
        }
    }

    internal static void AppendEncodedTo(StringBuilder sb, ReadOnlySpan<byte> data)
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
