﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FolkerKinzel.Strings;

public static class Base64Decoder
{
    


    //Span<char> chars = stackalloc char[4];
    //Span<int> lookup = stackalloc int[123];

    //InitLookup(lookup);




    //int inputIdx = 0;
    //int outputIdx = 0;

    //while (GetNextChunk(base64, chars, ref inputIdx))
    //{
    //    if (chars[3] == '=')
    //    {
    //        HandlePadding(chars, lookup, output, ref outputIdx);
    //        break;
    //    }

    //    int carrier = 0;

    //    for (int i = 0; i < 4; i++)
    //    {
    //        carrier |= lookup[chars[i]] << ((3 - i) * Base64.CHAR_WIDTH);
    //    }

    //    output[outputIdx++] = (byte)(carrier >> 16);
    //    output[outputIdx++] = (byte)((carrier >> 8) & 0xFF);
    //    output[outputIdx++] = (byte)(carrier & 0xFF);
    //}

    //return outputIdx == output.Length ? output : output.AsSpan(0, outputIdx).ToArray();

    private static void HandlePadding(Span<char> chars, ReadOnlySpan<int> lookup, byte[] output, ref int outputIdx)
    {
        int paddingLength = chars[2] == '=' ? 2 : 1;

        int carrier = 0;
        for (int i = 0; i < 4 - paddingLength; i++)
        {
            carrier |= lookup[chars[i]] << ((3 - i) * Base64.CHAR_WIDTH);
        }

        output[outputIdx++] = (byte)(carrier >> 16);

        if (paddingLength == 1)
        {
            output[outputIdx++] = (byte)((carrier >> 8) & 0xFF);
        }
    }


 


    [SuppressMessage("Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", Justification = "<Ausstehend>")]
    private static void InitLookup(Span<int> lookup)
    {
        //for (int i = 0; i < lookup.Length; i++)
        //{
        //    lookup[i] = byte.MaxValue;
        //}

        ReadOnlySpan<char> idx = Base64.IDX.AsSpan();

        for (byte i = 0; i < idx.Length; i++)
        {
            lookup[idx[i]] = i;
        }
    }


    private static bool GetNextChunk(ReadOnlySpan<char> base64, Span<char> chars, ref int index)
    {
        int spanIndex = 0;
        while (index < base64.Length && spanIndex < 4)
        {
            char c = base64[index++];

            if (char.IsWhiteSpace(c))
            {
                continue;
            }
            chars[spanIndex++] = c;
        }

        if (spanIndex < 3)
        {
            if (spanIndex == 0)
            {
                return false;
            }
            else if (spanIndex == 1)
            {
                throw new FormatException();
            }

            for (int i = spanIndex; i < 4; i++)
            {
                chars[i] = '=';
            }
        }

        return true;
    }

}