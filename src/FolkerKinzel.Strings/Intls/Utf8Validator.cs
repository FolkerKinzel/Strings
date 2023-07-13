using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FolkerKinzel.Strings.Intls;

internal sealed class Utf8Validator
{
    private const int CODEPAGE_UTF8 = 65001;
    private readonly Encoding _encoding;

    private readonly DecoderValidationFallback _fallback = new DecoderValidationFallback();
    private const int EOF = -1;

    public Utf8Validator() => _encoding = Encoding.GetEncoding(CODEPAGE_UTF8,
                                                              EncoderFallback.ReplacementFallback,
                                                              _fallback);

    public bool HasError => _fallback.HasError;

    public bool IsUtf8(Stream stream, long count, bool leaveOpen)
    {
        if (!InitCount(ref count))
        {
            return true;
        }

        if (stream.CanSeek)
        {
            long position = stream.Position;

            if (ParseBom(stream))
            {
                if (!leaveOpen) { stream.Close(); }
                return true;
            }
            stream.Position = position;
        }

        return !HasError && DoIsValidUtf8(stream, count, leaveOpen);

        /////////////////////////////////

        static bool ParseBom(Stream stream) =>
            stream.ReadByte() == 0xEF &&
            stream.ReadByte() == 0xBB &&
            stream.ReadByte() == 0xBF;
    }


    public bool IsValidUtf8(Stream stream, long count, bool leaveOpen) =>
        !InitCount(ref count) || DoIsValidUtf8(stream, count, leaveOpen);


    private bool DoIsValidUtf8(Stream stream, long count, bool leaveOpen)
    {
        _fallback.Reset();
        using StreamReader reader = InitStreamReader(stream, count, leaveOpen: leaveOpen);

        int i;
        while (count-- > 0 && (i = reader.Read()) != EOF)
        {
            if (HasError)
            {
                return false;
            }
        }
        return !HasError;
    }

    private StreamReader InitStreamReader(Stream stream, long count, bool leaveOpen) =>
         new(stream, _encoding, bufferSize: ComputeBufSize(count), detectEncodingFromByteOrderMarks: false,
             leaveOpen: leaveOpen);

    private static int ComputeBufSize(long count) =>
        count >= 1024 ? 1024 : count >= 512 ? 512 : count >= 256 ? 256 : 128;


    private static bool InitCount(ref long count)
    {
        if (count < 0)
        {
            count = long.MaxValue;
            return true;
        }

        return count != 0;
    }
}
