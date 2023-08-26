using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarks;
internal static class Base64
{
    const string IDX = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
    internal static void AppendEncodedTo(StringBuilder sb, IList<byte> data)
    {
        const int chunkLength = 3;

        int counter = 0;
        int paddingLength = data.Count % chunkLength;
        int finalPartLength = data.Count - (chunkLength - paddingLength);

        ReadOnlySpan<char> idx = IDX.AsSpan();

        const int charMask = 0b11_1111;

        if (data.Count > chunkLength)
        {
            Span<char> tmp = stackalloc char[4];

            while (counter < data.Count - finalPartLength)
            {
                int i = data[counter] << 16;
                i |= data[counter + 1] << 8;
                i |= data[counter + 2];

                for (int j = 0; j < 4; j++)
                {
                    tmp[3 - j] = idx[i & charMask];
                    i >>= 6;
                }

                sb.Append(tmp);
                counter += chunkLength;
            }
        }

        int dataHolder = 0;

        for (int j = 0; j < finalPartLength; j++)
        {
            dataHolder <<= 8;
            dataHolder |= data[data.Count - (finalPartLength - j)];
        }

        int remainingDataLength = 4 - paddingLength;

        for (int j = 0; j < remainingDataLength; j++)
        {

            sb.Append(idx[(dataHolder >> ((remainingDataLength - j) * 6)) & charMask]);
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
