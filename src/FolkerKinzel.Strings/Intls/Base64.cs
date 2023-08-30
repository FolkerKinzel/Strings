using System.Diagnostics;
using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings.Intls;

[SuppressMessage("Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", Justification = "<Ausstehend>")]
internal static class Base64
{
    internal const string LINE_BREAK = "\r\n";
    internal const int LINE_LENGTH = 76;

    internal const string IDX = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
    private const int CHAR_MASK = 0b11_1111;
    private const int CHUNK_LENGTH = 3;
    internal const int CHAR_WIDTH = 6;

    internal static void AppendEncodedTo(StringBuilder sb, ReadOnlySpan<byte> data)
    {
        Debug.Assert(sb != null);

        // paddingLength may be 3, but finalPartLength is 0 then and no 
        // padding will be added:
        int paddingLength = CHUNK_LENGTH - (data.Length % CHUNK_LENGTH);
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

            _ = sb.Append(idx[(i >> 3 * CHAR_WIDTH) & CHAR_MASK])
                  .Append(idx[(i >> 2 * CHAR_WIDTH) & CHAR_MASK])
                  .Append(idx[(i >> CHAR_WIDTH) & CHAR_MASK])
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
            sb.Append(IDX[(dataHolder >> shift) & CHAR_MASK]);
        }

        for (int j = 0; j < paddingLength; j++)
        {
            sb.Append('=');
        }
    }
}
