using System;
using System.Runtime.CompilerServices;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Intls;

namespace Benchmarks;

[MemoryDiagnoser]
[MarkdownExporter]
[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net48)]
public class ReplaceWhiteSpaceWithBench
{
    const string REPLACEMENT = "\r\n";

    readonly string _s;

    private StringBuilder Builder { get; set; }

    public ReplaceWhiteSpaceWithBench()
    {
        var sb = new StringBuilder();

        for (int i = 0; i < 80; i++)
        {
            sb.Append("a\nb  ");
        }

        Builder = sb;
        _s = sb.ToString();
    }

    [GlobalSetup]
    public void Setup() => Builder = new StringBuilder(_s);

    [Benchmark]
    public string ReplaceWhiteSpaceStringLibrary() => _s.ReplaceWhiteSpaceWith(REPLACEMENT, false);

    //[Benchmark]
    //public string ReplaceWhiteSpaceStringArrayPool() => ReplaceWhiteSpaceWith(_s, REPLACEMENT, false);

    [Benchmark]
    public StringBuilder ReplaceWhiteSpaceStringBuilderLibrary() => Builder.ReplaceWhiteSpaceWith(REPLACEMENT, false);

    //[Benchmark]
    //public StringBuilder ReplaceWhiteSpaceStringBuilderArrayPool() => ReplaceWhiteSpaceWith(new StringBuilder(_s), REPLACEMENT, 0, _s.Length, false);

    //[Benchmark]
    //public StringBuilder ReplaceWhiteSpaceStringBuilderChunks() => ReplaceWhiteSpaceWithChunks(new StringBuilder(_s), REPLACEMENT, 0, _s.Length, false);


 

    //private static StringBuilder ReplaceWhiteSpaceWithChunks(StringBuilder builder, ReadOnlySpan<char> replacement, int startIndex, int count, bool skipNewLines)
    //{
    //    if (count == 0)
    //    {
    //        return builder;
    //    }

    //    int capacity = ComputeMaxCapacity(count, replacement.Length);

    //    using ArrayPoolHelper.SharedArray<char> buf = ArrayPoolHelper.Rent<char>(capacity);
    //    Span<char> outSpan = buf.Array.AsSpan();
    //    int outLength = DoReplace(builder, replacement, startIndex, count, skipNewLines, outSpan);

    //    if (startIndex + count == builder.Length)
    //    {
    //        builder.Length = startIndex;
    //        builder.Append(outSpan.Slice(0, outLength));
    //    }
    //    else
    //    {
    //        int remainingStart = startIndex + count;
    //        int remainingLength = builder.Length - remainingStart;
    //        using ArrayPoolHelper.SharedArray<char> copy = ArrayPoolHelper.Rent<char>(remainingLength);
    //        Span<char> copySpan = copy.Array.AsSpan(0, remainingLength);
    //        builder.CopyTo(remainingStart, copySpan, remainingLength);

    //        builder.Length = startIndex;
    //        builder.Append(outSpan.Slice(0, outLength));
    //        builder.Append(copySpan);


    //        //builder.Remove(startIndex, count);
    //        //builder.Insert(startIndex, outSpan.Slice(0, outLength));
    //    }

    //    return builder;

    //    ///////////////////////////////////////////////////////////

    //    static int DoReplace(StringBuilder input, ReadOnlySpan<char> replacement, int startIndex, int count, bool skipNewLines, Span<char> outSpan)
    //    {
    //        bool wsFlag = false;
    //        int outLength = 0;
    //        int chunkStart = 0;

    //        foreach (ReadOnlyMemory<char> chunk in input.GetChunks())
    //        {
    //            if (startIndex < chunk.Length + chunkStart)
    //            {
    //                int spanStart = startIndex - chunkStart;
    //                ReadOnlySpan<char> span = chunk.Span.Slice(spanStart, Math.Min(chunk.Length - spanStart, count));
    //                count -= span.Length;

    //                span.ReplaceWhiteSpaceWith(replacement, outSpan, skipNewLines, ref wsFlag, ref outLength);

    //                if (count == 0)
    //                {
    //                    break;
    //                }

    //                chunkStart += chunk.Length;
    //                startIndex = chunkStart;
    //            }
    //            else
    //            {
    //                chunkStart += chunk.Length;
    //            }
    //        }

    //        return outLength;
    //    }
    //}



    


}
