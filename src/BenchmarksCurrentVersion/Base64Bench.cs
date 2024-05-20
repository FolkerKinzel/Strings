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
    //private const string LINE_BREAK = "\r\n";
    //private const int LINE_LENGTH = 76;
    private readonly byte[] _arr = new byte[50000];
    private readonly string _base64;

    public Base64Bench()
    {
        new Random().NextBytes(_arr);
        this._base64 = Convert.ToBase64String(_arr, Base64FormattingOptions.None);
    }

    [Benchmark]
    public byte[] GetBytesBenchBcl() => Base64.GetBytes(_base64);

    [Benchmark]
    public byte[] GetBytesBenchLibrary() => Base64.GetBytes(_base64, Base64ParserOptions.None);

    [Benchmark]
    public StringBuilder AppendLibrary() => new StringBuilder().AppendBase64(_arr, Base64FormattingOptions.None);

    //[Benchmark]
    //public StringBuilder AppendBcl() => AppendBclEncoded(new StringBuilder(), _arr);

    [Benchmark]
    public StringBuilder AppendLibraryLineBreaks() => new StringBuilder().AppendBase64(_arr, Base64FormattingOptions.InsertLineBreaks);

    //[Benchmark]
    //public StringBuilder AppendBclLineBreaks() => AppendBclEncodedWithLineBreaks(new StringBuilder(), _arr);


    //private static StringBuilder AppendBclEncoded(StringBuilder builder, ReadOnlySpan<byte> bytes)
    //{
    //    if (bytes.Length == 0)
    //    {
    //        return builder;
    //    }

    //    int base64CharsCount = Base64.GetEncodedLength(bytes.Length);

    //    using ArrayPoolHelper.SharedArray<byte> byteBuf = ArrayPoolHelper.Rent<byte>(base64CharsCount);
    //    _ = Base64Bcl.EncodeToUtf8(bytes, byteBuf.Array.AsSpan(), out _, out _);

    //    using ArrayPoolHelper.SharedArray<char> charBuf = ArrayPoolHelper.Rent<char>(base64CharsCount);
    //    _ = Encoding.UTF8.GetChars(byteBuf.Array, 0, base64CharsCount, charBuf.Array, 0);

    //    builder.EnsureCapacity(builder.Length + base64CharsCount);
    //    return builder.Append(charBuf.Array, 0, base64CharsCount);
    //}

    //private static StringBuilder AppendBclEncodedWithLineBreaks(StringBuilder builder, ReadOnlySpan<byte> bytes)
    //{
    //    if (bytes.Length == 0)
    //    {
    //        return builder;
    //    }

    //    bool insertNewLineAtStart = builder.Length != 0 && !builder[builder.Length - 1].IsNewLine();


    //    int base64CharsCount = Base64.GetEncodedLength(bytes.Length);

    //    using ArrayPoolHelper.SharedArray<byte> byteBuf = ArrayPoolHelper.Rent<byte>(base64CharsCount);
    //    _ = Base64Bcl.EncodeToUtf8(bytes, byteBuf.Array.AsSpan(), out _, out _);

    //    using ArrayPoolHelper.SharedArray<char> charBuf = ArrayPoolHelper.Rent<char>(base64CharsCount);
    //    int charsWritten = Encoding.UTF8.GetChars(byteBuf.Array, 0, base64CharsCount, charBuf.Array, 0);

    //    builder.EnsureCapacity(
    //        builder.Length 
    //        + base64CharsCount + (base64CharsCount / LINE_LENGTH + 1) * LINE_BREAK.Length 
    //        + (insertNewLineAtStart ? LINE_BREAK.Length : 0));

    //    int end = base64CharsCount - LINE_LENGTH;
    //    int i = 0;

    //    for (; i < end; i += LINE_LENGTH)
    //    {
    //        _ = builder.Append(charBuf.Array, i, LINE_LENGTH)
    //                   .Append(LINE_BREAK);
    //    }

    //    return builder.Append(charBuf.Array, i, base64CharsCount - i);
    //}

}
