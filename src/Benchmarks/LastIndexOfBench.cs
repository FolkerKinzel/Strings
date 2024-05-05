using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Toolchains.Roslyn;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Intls;

namespace Benchmarks;

[MemoryDiagnoser]
public class LastIndexOfBench
{
    private readonly StringBuilder _builder = new StringBuilder(new string('a', 100)).Append(new string('a', 100));

    [Benchmark]
    public int LastIndexOfLibrary() => _builder.LastIndexOf('z');

    [Benchmark]
    public int LastIndexOfChunks() => LastIndexOf(_builder, 'z');

    [Benchmark]
    public int LastIndexOfArray() => LastIndexOfPolyfill(_builder, 'z');

    [Benchmark]
    public int LastIndexOfSpanBounds() => LastIndexOfSpanBounds(_builder, 'z', _builder.Length, _builder.Length);

    [Benchmark]
    public int LastIndexOfArrayBounds() => LastIndexOfPolyfillBounds(_builder, 'z', _builder.Length, _builder.Length);


    private static int LastIndexOfPolyfill(StringBuilder sb, char c)
    {
        if (sb.Length == 0)
        {
            return -1;
        }

        using ArrayPoolHelper.SharedArray<char> shared = ArrayPoolHelper.Rent<char>(sb.Length);
        sb.CopyTo(0, shared.Array, sb.Length);
        return shared.Array.AsSpan(0, sb.Length).LastIndexOf(c);
    }

    private static int LastIndexOfPolyfillBounds(StringBuilder sb, char c, int startIndex, int count)
    {
        if (count == 0)
        {
            return -1;
        }

        if (startIndex == sb.Length)
        {
            --startIndex;
        }

        using ArrayPoolHelper.SharedArray<char> shared = ArrayPoolHelper.Rent<char>(count);
        sb.CopyTo(startIndex + 1 - count, shared.Array, 0, count);
        return shared.Array.AsSpan(0, count).LastIndexOf(c);
    }

    private static int LastIndexOf(StringBuilder sb, char c)
    {
        int pos = sb.Length - 1;

        while(ChunkProvider.TryGetChunk(sb, pos, out int chunkStart, out ReadOnlySpan<char> span))
        {
            int idx = span.LastIndexOf(c);

            if (idx != -1)
            {
                return chunkStart + idx;
            }

            pos = chunkStart - 1;
        }

        return -1;
    }

    private static int LastIndexOfSpanBounds(StringBuilder sb, char c, int startIndex, int count)
    {
        if (startIndex == sb.Length)
        {
            --startIndex;
        }

        while (ChunkProvider.TryGetChunk(sb, startIndex, out int chunkStart, out ReadOnlySpan<char> span))
        {
            int evaluatedLength = startIndex + 1 - chunkStart;
            span = span.Slice(0, evaluatedLength);
            int idx = span.LastIndexOf(c);

            if (evaluatedLength >= count)
            {
                return idx == -1 ? -1 : chunkStart + idx;
            }

            if (idx != -1)
            {
                return chunkStart + idx;
            }

            startIndex -= evaluatedLength;
            count -= evaluatedLength;
        }

        return -1;
    }
}
