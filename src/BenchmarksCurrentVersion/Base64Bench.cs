using System;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Intls;
using Base64Bcl = System.Buffers.Text.Base64;

namespace Benchmarks;

[MemoryDiagnoser]
[MarkdownExporter]
[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net48)]
public class Base64Bench
{
    private const string LINE_BREAK = "\r\n";
    private const int LINE_LENGTH = 76;
    private readonly byte[] _arr;
    private readonly string _base64;


    public Base64Bench()
    {
        this._arr = new byte[10000];
        new Random().NextBytes(_arr);

        this._base64 = Convert.ToBase64String(_arr, Base64FormattingOptions.None);
    }

    [Benchmark]
    public byte[] ToBytesBench() => Base64.GetBytes(_base64);

    [Benchmark]
    public StringBuilder AppendLibrary() => new StringBuilder().AppendBase64(_arr, Base64FormattingOptions.None);

    [Benchmark]
    public StringBuilder AppendBcl() => AppendBclEncoded(new StringBuilder(), _arr);

    [Benchmark]
    public StringBuilder AppendLibraryLineBreaks() => new StringBuilder().AppendBase64(_arr, Base64FormattingOptions.InsertLineBreaks);

    [Benchmark]
    public StringBuilder AppendBclLineBreaks() => AppendBclEncodedWithLineBreaks(new StringBuilder(), _arr);


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

}
