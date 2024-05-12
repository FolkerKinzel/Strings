using System;
using System.Runtime.CompilerServices;
using System.Text;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Intls;

namespace Benchmarks;

[MemoryDiagnoser]
public class ReplaceLineEndingsBench
{
    public ReplaceLineEndingsBench() => this.TestString = Properties.Resources.ReplaceLineEndingsTest;

    public string TestString { get; }

    //[Benchmark]
    //public StringBuilder StringBuilderLibraryNoChanges()
    //{
    //    var sb = new StringBuilder(TestString);
    //    return sb.ReplaceLineEndings("\r\n");
    //}

    //[Benchmark]
    //public StringBuilder StringBuilderArrayPoolNoChanges()
    //{
    //    var sb = new StringBuilder(TestString);
    //    return ReplaceLineEndings(sb, "\r\n");
    //}

    //[Benchmark]
    //public StringBuilder StringBuilderChunksNoChanges()
    //{
    //    var sb = new StringBuilder(TestString);
    //    return ReplaceLineEndingsChunks(sb, "\r\n");
    //}

    //[Benchmark]
    //public StringBuilder StringBuilderLibraryChanges()
    //{
    //    var sb = new StringBuilder(TestString);
    //    return sb.ReplaceLineEndings("\n");
    //}

    //[Benchmark]
    //public StringBuilder StringBuilderArrayPoolChanges()
    //{
    //    var sb = new StringBuilder(TestString);
    //    return ReplaceLineEndings(sb, "\n");
    //}

    //[Benchmark]
    //public StringBuilder StringBuilderChunksChanges()
    //{
    //    var sb = new StringBuilder(TestString);
    //    return ReplaceLineEndingsChunks(sb, "\n");
    //}


    //[Benchmark]
    //public string StringLibraryNoChanges() => TestString.ReplaceLineEndings("\r\n");

    //[Benchmark]
    //public string StringArrayPoolNoChanges() => ReplaceLineEndings(TestString, "\r\n");

    [Benchmark]
    public string StringLibraryChanges() => TestString.ReplaceLineEndings("\n");

    [Benchmark]
    public string StringArrayPoolChanges() => ReplaceLineEndings(TestString, "\n");


    private static StringBuilder ReplaceLineEndings(StringBuilder input, ReadOnlySpan<char> replacement)
    {
        // TODO: Get the index of the first line break char and process only from that
        // If the index is -1, quit.
        // Get also the index of the last line break char and process only the span between.

        if (input.Length == 0)
        {
            return input;
        }

        int capacity = ComputeMaxCapacity(input.Length, replacement.Length);

        using ArrayPoolHelper.SharedArray<char> source = ArrayPoolHelper.Rent<char>(input.Length);
        input.CopyTo(0, source.Array, 0, input.Length);

        using ArrayPoolHelper.SharedArray<char> buf = ArrayPoolHelper.Rent<char>(capacity);
        ReadOnlySpan<char> sourceSpan = source.Array.AsSpan(0, input.Length);
        int outLength = sourceSpan.ReplaceLineEndings(replacement, buf.Array);

        if (!sourceSpan.Equals(buf.Array.AsSpan(0, outLength), StringComparison.Ordinal))
        {
            input.Length = 0;
            input.Append(buf.Array, 0, outLength);
        }

        return input;
    }

    private static StringBuilder ReplaceLineEndingsChunks(StringBuilder input, ReadOnlySpan<char> replacement)
    {
        // TODO: Get the index of the first line break char and process only from that
        // If the index is -1, quit.
        // Get also the index of the last line break char and process only the span between.

        if (input.Length == 0)
        {
            return input;
        }

        using ArrayPoolHelper.SharedArray<char> buf =
            ArrayPoolHelper.Rent<char>(ComputeMaxCapacity(input.Length, replacement.Length));

        Span<char> outSpan = buf.Array.AsSpan();
        bool rFound = false;
        int outLength = 0;

        foreach (ReadOnlyMemory<char> chunk in input.GetChunks())
        {
            chunk.Span.ReplaceLineEndings(replacement, outSpan, ref rFound, ref outLength);
        }

        input.Length = 0;
        input.Append(outSpan.Slice(0, outLength));

        return input;
    }


    

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int ComputeMaxCapacity(int sourceLength, int replacementLength)
        => sourceLength * Math.Max(1, replacementLength);

    
}
