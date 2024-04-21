using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Intls;
using Base64Bcl = System.Buffers.Text.Base64;

namespace Benchmarks;

[MemoryDiagnoser]
public class Base64Bench
{
    private readonly ReadOnlyCollection<byte> _coll;
    private readonly byte[] _arr;
    private readonly string _base64;


    public Base64Bench()
    {
        this._arr = new byte[100000];
        Random.Shared.NextBytes(_arr);

        this._coll = new ReadOnlyCollection<byte>(_arr);
        this._base64 = Convert.ToBase64String(_arr, Base64FormattingOptions.None);
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
    public StringBuilder AppendLibraryLineBreaks() => Base64.AppendEncodedTo(new StringBuilder(), _arr, Base64FormattingOptions.None);

    [Benchmark]
    public StringBuilder AppendNew() => AppendEncodedTo(new StringBuilder(), _arr, Base64FormattingOptions.None);

    [Benchmark]
    public StringBuilder AppendNewLineBreaks()
    {
        return AppendEncodedTo(new StringBuilder(), _arr, Base64FormattingOptions.None);
    }

    public static void Test1()
    {
        Test(Encoding.UTF8.GetBytes("Hi Fölkerchen"), Base64FormattingOptions.InsertLineBreaks);
    }

    public static void Test2()
    {
        var bytes = new byte[760];
        Random.Shared.NextBytes(bytes);
        Test(bytes, Base64FormattingOptions.InsertLineBreaks);
    }

    private static void Test(byte[] bytes, Base64FormattingOptions options)
    {

        string convertString = Convert.ToBase64String(bytes, options);
        string appendString = AppendEncodedTo(new StringBuilder(), bytes, options).ToString();

        bool result = StringComparer.OrdinalIgnoreCase.Equals(convertString, appendString);
    }

    private static StringBuilder AppendEncodedTo(StringBuilder builder,
                                                  ReadOnlySpan<byte> bytes,
                                                  Base64FormattingOptions options)
    {
        const int LINE_LENGTH = 76;
        const string LINE_BREAK = "\r\n";

        _ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        int length = Base64.GetEncodedLength(bytes.Length);
        bool insertNewLineAtStart = false;
        int capacity = length;
        bool insertLineBreaks = options == Base64FormattingOptions.InsertLineBreaks;

        if (insertLineBreaks)
        {
            insertNewLineAtStart = builder.Length != 0 && !builder[builder.Length - 1].IsNewLine();
            capacity += (capacity / LINE_LENGTH) * LINE_BREAK.Length + (insertNewLineAtStart ? Environment.NewLine.Length : 0);
        }

        builder.EnsureCapacity(builder.Length + capacity);

        if(insertNewLineAtStart)
        {
            builder.AppendLine();
        }

        using ArrayPoolHelper.SharedArray<byte> shared = ArrayPoolHelper.Rent<byte>(length);
        Span<byte> buffer = shared.Value.AsSpan(0, length);

        _ = Base64Bcl.EncodeToUtf8(bytes, buffer, out _, out _);

        if(insertLineBreaks)
        {
            AppendChunk(builder, ref buffer);

            while(buffer.Length > 0)
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
        else
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                _ = builder.Append((char)buffer[i]);
            }
        }


        return builder;
    }
}
