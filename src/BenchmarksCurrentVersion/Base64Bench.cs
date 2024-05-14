using System;
using System.Text;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Intls;
using Base64Bcl = System.Buffers.Text.Base64;

namespace Benchmarks;

[MemoryDiagnoser]
public class Base64Bench
{
    private const string LINE_BREAK = "\r\n";
    private const int LINE_LENGTH = 76;
    //private const string IDX = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
    //private const int CHAR_MASK = 0b11_1111;
    //private const int CHUNK_LENGTH = 3;
    //private const int CHAR_WIDTH = 6;


    //private readonly ReadOnlyCollection<byte> _coll;
    private readonly byte[] _arr;
    //private readonly string _base64;


    public Base64Bench()
    {
        this._arr = new byte[100000];
        new Random().NextBytes(_arr);

        //this._coll = new ReadOnlyCollection<byte>(_arr);
        //this._base64 = Convert.ToBase64String(_arr, Base64FormattingOptions.None);
    }

    //[Benchmark]
    //public byte[] ToBytesBench() => Base64.GetBytes(_base64);

    //[Benchmark]
    //public byte[] FrameworkDecoder() => Convert.FromBase64String(_base64.AsSpan().ToString());

    //[Benchmark]
    //public StringBuilder ExtensionMethodBench() => new StringBuilder().AppendBase64Encoded(_coll);


    //[Benchmark]
    //public StringBuilder FrameworkBench() => new(Convert.ToBase64String(_coll.ToArray()));


    //[Benchmark]
    //public StringBuilder ExtensionMethodBenchArray() => new StringBuilder().AppendBase64(_arr.AsSpan());


    //[Benchmark]
    //public StringBuilder FrameworkBenchArray() => new(Convert.ToBase64String(_arr));


    [Benchmark]
    public StringBuilder AppendLibrary() => Base64.AppendEncodedTo(new StringBuilder(), _arr, Base64FormattingOptions.None);

    [Benchmark]
    public StringBuilder AppendBcl() => AppendBclEncoded(new StringBuilder(), _arr);

    [Benchmark]
    public StringBuilder AppendLibraryLineBreaks() => Base64.AppendEncodedTo(new StringBuilder(), _arr, Base64FormattingOptions.InsertLineBreaks);

    [Benchmark]
    public StringBuilder AppendBclLineBreaks() => AppendBclEncodedWithLineBreaks(new StringBuilder(), _arr);



    //[Benchmark]
    //public StringBuilder AppendNew() => AppendEncodedTo(new StringBuilder(), _arr, Base64FormattingOptions.None);

    //[Benchmark]
    //public StringBuilder AppendNewLineBreaks()
    //{
    //    return AppendEncodedTo(new StringBuilder(), _arr, Base64FormattingOptions.InsertLineBreaks);
    //}

    //[Benchmark]
    //public StringBuilder AppendNew2() => AppendEncodedTo2(new StringBuilder(), _arr, Base64FormattingOptions.None);

    //[Benchmark]
    //public StringBuilder AppendNewLineBreaks2()
    //{
    //    return AppendEncodedTo2(new StringBuilder(), _arr, Base64FormattingOptions.InsertLineBreaks);
    //}

    //public static void Test1()
    //{
    //    Test(Encoding.UTF8.GetBytes("Hi Fölkerchen"), Base64FormattingOptions.InsertLineBreaks);
    //}

    //public static void Test2()
    //{
    //    var bytes = new byte[58];
    //    Random.Shared.NextBytes(bytes);
    //    Test2(bytes, Base64FormattingOptions.InsertLineBreaks);
    //}

    //private static void Test(byte[] bytes, Base64FormattingOptions options)
    //{
    //    bool isAccelerated = Vector256.IsHardwareAccelerated;

    //    string convertString = Convert.ToBase64String(bytes, options);
    //    string appendString = AppendEncodedTo(new StringBuilder(), bytes, options).ToString();
    //    int convertStringLength = convertString.Length;
    //    int appendStringLength = appendString.Length;

    //    bool result = StringComparer.OrdinalIgnoreCase.Equals(convertString, appendString);
    //}

    //private static void Test2(byte[] bytes, Base64FormattingOptions options)
    //{
    //    bool isAccelerated = Vector256.IsHardwareAccelerated;

    //    string convertString = Convert.ToBase64String(bytes, options);
    //    string appendString = AppendEncodedTo2(new StringBuilder(), bytes, options).ToString();
    //    int convertStringLength = convertString.Length;
    //    int appendStringLength = appendString.Length;

    //    bool result = StringComparer.OrdinalIgnoreCase.Equals(convertString, appendString);
    //}

    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //    private static StringBuilder AppendEncodedTo(StringBuilder builder,
    //                                                  ReadOnlySpan<byte> bytes,
    //                                                  Base64FormattingOptions options)
    //    {


    //        _ArgumentNullException.ThrowIfNull(builder, nameof(builder));

    //        return options == Base64FormattingOptions.InsertLineBreaks
    //            ? AppendEncodedWithLineBreaks(builder, bytes)
    //            : AppendEncoded(builder, bytes);
    //    }

    //    private static StringBuilder AppendEncodedTo2(StringBuilder sb,
    //                                                  ReadOnlySpan<byte> bytes,
    //                                                  Base64FormattingOptions options)
    //    {
    //        _ArgumentNullException.ThrowIfNull(sb, nameof(sb));

    //        // paddingLength may be 3, but finalPartLength is 0 then and no 
    //        // padding will be added:
    //        int paddingLength = CHUNK_LENGTH - bytes.Length % CHUNK_LENGTH;
    //        int finalPartLength = CHUNK_LENGTH - paddingLength;

    //        if (options == Base64FormattingOptions.InsertLineBreaks)
    //        {
    //            bool insertNewLineAtStart = sb.Length != 0 && !sb[sb.Length - 1].IsNewLine();
    //            int capacity = Base64.GetEncodedLength(bytes.Length);
    //            capacity += (capacity / LINE_LENGTH) * LINE_BREAK.Length + (insertNewLineAtStart ? Environment.NewLine.Length : 0);
    //            _ = sb.EnsureCapacity(sb.Length + capacity);

    //            if (insertNewLineAtStart)
    //            {
    //                _ = sb.AppendLine();
    //            }

    //            AppendChunksWithLineBreaks(sb, bytes, finalPartLength);
    //        }
    //        else
    //        {
    //            _ = sb.EnsureCapacity(sb.Length + Base64.GetEncodedLength(bytes.Length));
    //            AppendChunks2(sb, bytes, finalPartLength);
    //        }

    //        if (finalPartLength > 0)
    //        {
    //            AppendFinalBlock(sb, bytes, paddingLength, finalPartLength);
    //        }

    //        return sb;
    //    }

    private static StringBuilder AppendBclEncoded(StringBuilder builder, ReadOnlySpan<byte> bytes)
    {
        int length = Base64.GetEncodedLength(bytes.Length);

        builder.EnsureCapacity(builder.Length + length);
        using ArrayPoolHelper.SharedArray<byte> shared = ArrayPoolHelper.Rent<byte>(length);
        Span<byte> buffer = shared.Array.AsSpan(0, length);

        _ = Base64Bcl.EncodeToUtf8(bytes, buffer, out _, out _);

        for (int i = 0; i < buffer.Length; i++)
        {
            _ = builder.Append((char)buffer[i]);
        }

        return builder;
    }

    private static StringBuilder AppendBclEncodedWithLineBreaks(StringBuilder builder, ReadOnlySpan<byte> bytes)
    {
        int length = Base64.GetEncodedLength(bytes.Length);

        bool insertNewLineAtStart = builder.Length != 0 && !builder[builder.Length - 1].IsNewLine();
        int capacity = length;
        capacity += (capacity / LINE_LENGTH) * LINE_BREAK.Length + (insertNewLineAtStart ? Environment.NewLine.Length : 0);
        builder.EnsureCapacity(builder.Length + capacity);

        if (insertNewLineAtStart)
        {
            builder.AppendLine();
        }

        using ArrayPoolHelper.SharedArray<byte> shared = ArrayPoolHelper.Rent<byte>(length);
        Span<byte> buffer = shared.Array.AsSpan(0, length);

        _ = Base64Bcl.EncodeToUtf8(bytes, buffer, out _, out _);

        AppendWithLineBreaks(builder, buffer);

        return builder;

        static void AppendWithLineBreaks(StringBuilder builder, Span<byte> buffer)
        {
            AppendChunk(builder, ref buffer);

            while (buffer.Length > 0)
            {
                _ = builder.Append(LINE_BREAK);
                AppendChunk(builder, ref buffer);
            }

            static void AppendChunk(StringBuilder sb, ref Span<byte> buf)
            {
                ReadOnlySpan<byte> span = buf.Slice(0, Math.Min(LINE_LENGTH, buf.Length));
                buf = buf.Slice(span.Length);

                for (int i = 0; i < span.Length; i++)
                {
                    _ = sb.Append((char)span[i]);
                }
            }
        }
    }

    //    /// ///////////////////////////////////////////////////////////////////////



    //    private static void AppendChunks2(StringBuilder sb, ReadOnlySpan<byte> data, int finalPartLength)
    //    {
    //        if (data.Length < CHUNK_LENGTH)
    //        {
    //            return;
    //        }

    //        int counter = 0;
    //        ReadOnlySpan<char> idx = IDX.AsSpan();

    //        while (counter < data.Length - finalPartLength)
    //        {
    //            int i = data[counter] << 16;
    //            i |= data[counter + 1] << 8;
    //            i |= data[counter + 2];

    //            _ = sb.Append(idx[i >> 3 * CHAR_WIDTH & CHAR_MASK])
    //                  .Append(idx[i >> 2 * CHAR_WIDTH & CHAR_MASK])
    //                  .Append(idx[i >> CHAR_WIDTH & CHAR_MASK])
    //                  .Append(idx[i & CHAR_MASK]);

    //            counter += CHUNK_LENGTH;
    //        }
    //    }




    //    private static void AppendChunksWithLineBreaks(StringBuilder sb, ReadOnlySpan<byte> data, int finalPartLength)
    //    {
    //        if (data.Length < CHUNK_LENGTH)
    //        {
    //            return;
    //        }

    //        int counter = 0;
    //        ReadOnlySpan<char> idx = IDX.AsSpan();

    //Repeat:

    //        for (int k = 0; k < LINE_LENGTH / 4; k++)
    //        {
    //            if(counter >= data.Length - finalPartLength)
    //            {
    //                return;
    //            }

    //            int i = data[counter] << 16;
    //            i |= data[counter + 1] << 8;
    //            i |= data[counter + 2];

    //            _ = sb.Append(idx[i >> 3 * CHAR_WIDTH & CHAR_MASK])
    //                  .Append(idx[i >> 2 * CHAR_WIDTH & CHAR_MASK])
    //                  .Append(idx[i >> CHAR_WIDTH & CHAR_MASK])
    //                  .Append(idx[i & CHAR_MASK]);

    //            counter += CHUNK_LENGTH;
    //        }

    //        if (counter < data.Length)
    //        {
    //            _ = sb.Append(LINE_BREAK);
    //        }

    //        goto Repeat;
    //    }

    //    private static void AppendFinalBlock(StringBuilder sb, ReadOnlySpan<byte> data, int paddingLength, int finalPartLength)
    //    {
    //        int dataHolder = 0;

    //        for (int j = 0; j < finalPartLength; j++)
    //        {
    //            dataHolder <<= 8;
    //            dataHolder |= data[data.Length - (finalPartLength - j)];
    //        }

    //        dataHolder <<= paddingLength * 2;

    //        int remainingDataLength = 4 - paddingLength;

    //        for (int j = 1; j <= remainingDataLength; j++)
    //        {
    //            int shift = (remainingDataLength - j) * CHAR_WIDTH;
    //            _ = sb.Append(IDX[dataHolder >> shift & CHAR_MASK]);
    //        }

    //        for (int j = 0; j < paddingLength; j++)
    //        {
    //            _ = sb.Append('=');
    //        }
    //    }


}
