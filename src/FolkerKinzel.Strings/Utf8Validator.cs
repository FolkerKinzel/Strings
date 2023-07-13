using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FolkerKinzel.Strings;

public static class FileInfoExtension
{
    public static bool IsUtf8(this FileInfo fileInfo, long count = -1)
    {
        if (fileInfo == null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        using FileStream stream = fileInfo.OpenRead();
        return stream.IsUtf8Internal(count, false);
    }

    public static bool IsValidUtf8(this FileInfo fileInfo, long count = -1)
    {
        if (fileInfo == null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        using FileStream stream = fileInfo.OpenRead();
        return stream.IsValidUtf8Internal(count, false);
    }
}

public static class StreamExtension
{
    public static bool IsUtf8(this Stream stream, long count = -1, bool leaveOpen = false) => 
        stream == null ? throw new ArgumentNullException(nameof(stream)) 
                       : IsUtf8Internal(stream, count, leaveOpen);

    public static bool IsValidUtf8(this Stream stream, long count = -1, bool leaveOpen = false) => 
        stream == null ? throw new ArgumentNullException(nameof(stream))
                       : IsValidUtf8Internal(stream, count, leaveOpen);

    internal static bool IsUtf8Internal(this Stream stream, long count, bool leaveOpen)
    {
        var validator = new Utf8Validator();
        return validator.IsUtf8(stream, count, leaveOpen);
    }

    internal static bool IsValidUtf8Internal(this Stream stream, long count, bool leaveOpen)
    {
        var validator = new Utf8Validator();
        return validator.IsValidUtf8(stream, count, leaveOpen);
    }
}



public class DecoderValidatorFallback : DecoderFallback
{
    private readonly ValidatorFallbackBuffer _buffer  = new();

    public bool HasError => _buffer.HasError;

    public void Reset() => _buffer.Reset();

    public override int MaxCharCount => 0;

    public override DecoderFallbackBuffer CreateFallbackBuffer() => _buffer;
}

internal class ValidatorFallbackBuffer : DecoderFallbackBuffer
{
    public bool HasError {  get; private set; }

    public override void Reset()
    {
        base.Reset();
        HasError = false;
    }

    public override int Remaining => 0;

    public override bool Fallback(byte[] bytesUnknown, int index)
    {
        HasError = true;
        return false;
    }

    public override char GetNextChar() => '\0';
    public override bool MovePrevious() => false;
}

internal class Utf8Validator
{
    private const int CODEPAGE_UTF8 = 65001;
    private readonly Encoding _encoding;
                                                              
    private readonly DecoderValidatorFallback _fallback = new DecoderValidatorFallback();
    private const int EOF = -1;

    public Utf8Validator() => _encoding = Encoding.GetEncoding(CODEPAGE_UTF8,
                                                              EncoderFallback.ReplacementFallback,
                                                              _fallback);

    public bool HasError => _fallback.HasError;

    public bool IsUtf8(Stream stream, long count, bool leaveOpen)
    {
        if(!InitCount(ref count))
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
        using StreamReader reader = InitStreamReader(stream, leaveOpen: leaveOpen);

        int i;
        while (count-- > 0 && ((i = reader.Read()) != EOF))
        {
            if (HasError)
            { 
                return false;
            }
        }
        return !HasError;
    }

    private StreamReader InitStreamReader(Stream stream, bool leaveOpen) =>
         new(stream, _encoding, bufferSize: 128, detectEncodingFromByteOrderMarks: false,
             leaveOpen: leaveOpen);


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
