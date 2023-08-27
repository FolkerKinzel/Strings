using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings.Intls;

[SuppressMessage("Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", Justification = "<Ausstehend>")]
internal static class Base64
{
    internal const string LINE_BREAK = "\n";
    internal const int LINE_LENGTH = 76;

    private const string IDX = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
    private const int CHAR_MASK = 0b11_1111;
    private const int CHUNK_LENGTH = 3;
    private const int CHAR_WIDTH = 6;

    internal static void AppendEncodedTo(StringBuilder sb, IList<byte> data)
    {
        Debug.Assert(sb != null);
        Debug.Assert(data != null);

        int paddingLength = CHUNK_LENGTH - (data.Count % CHUNK_LENGTH);
        int finalPartLength = paddingLength == 0 ? 0 : CHUNK_LENGTH - paddingLength;

        AppendChunks(sb, data, finalPartLength);

        if (finalPartLength > 0)
        {
            AppendFinalBlock(sb, data, paddingLength, finalPartLength);
        }
    }

    private static void AppendChunks(StringBuilder sb, IList<byte> data, int finalPartLength)
    {
        if (data.Count < CHUNK_LENGTH)
        {
            return;
        }

        int counter = 0;
        ReadOnlySpan<char> idx = IDX.AsSpan();
        Span<char> tmp = stackalloc char[4];

        while (counter < data.Count - finalPartLength)
        {
            int i = data[counter] << 16;
            i |= data[counter + 1] << 8;
            i |= data[counter + 2];

            for (int j = 3; j >= 0; j--)
            {
                tmp[j] = idx[i & CHAR_MASK];
                i >>= CHAR_WIDTH;
            }

            sb.Append(tmp);
            counter += CHUNK_LENGTH;
        }
    }


    private static void AppendFinalBlock(StringBuilder sb, IList<byte> data, int paddingLength, int finalPartLength)
    {
        ReadOnlySpan<char> idx = IDX.AsSpan();
        int dataHolder = 0;

        for (int j = 0; j < finalPartLength; j++)
        {
            dataHolder <<= 8;
            dataHolder |= data[data.Count - (finalPartLength - j)];
        }

        dataHolder <<= paddingLength * 2;

        int remainingDataLength = 4 - paddingLength;

        for (int j = 1; j <= remainingDataLength; j++)
        {
            int shift = (remainingDataLength - j) * CHAR_WIDTH;
            sb.Append(idx[(dataHolder >> shift) & CHAR_MASK]);
        }

        for (int j = 0; j < paddingLength; j++)
        {
            sb.Append('=');
        }
    }

    //private void InitIdx(Span<char> span)
    //{
    //    // Absolute offset for all ranges:
    //    // Translate values 0..63 to the Base64 alphabet. There are five sets:
    //    // #  From      To         Abs    Index  Characters
    //    // 0  [0..25]   [65..90]   +65        0  ABCDEFGHIJKLMNOPQRSTUVWXYZ
    //    // 1  [26..51]  [97..122]  +71        1  abcdefghijklmnopqrstuvwxyz
    //    // 2  [52..61]  [48..57]    -4  [2..11]  0123456789
    //    // 3  [62]      [43]       -19       12  +
    //    // 4  [63]      [47]       -16       13  /
    //    for (int i = 0; i < 26; i++)
    //    {
    //        span[i] = (char)(i + 65);
    //    }

    //    for (int i = 26; i < 52; i++)
    //    {
    //        span[i] = 71;
    //    }

    //    for (int i = 52; i < 62; i++)
    //    {
    //        span[i] = -4;
    //    }

    //    span[62] = -19;
    //    span[63] = -16;
    //}
}
