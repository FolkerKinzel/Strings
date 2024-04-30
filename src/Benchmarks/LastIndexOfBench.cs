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
    private readonly StringBuilder _builder = new(new string('a', 200));

    [Benchmark]
    public int LastIndexOfLibrary() => _builder.LastIndexOf('z');

    [Benchmark]
    public int LastIndexOfChunks() => LastIndexOf(_builder, 'z');

    [Benchmark]
    public int LastIndexOfArray() => LastIndexOfPolyfill(_builder, 'z');



    private static int LastIndexOfPolyfill(StringBuilder sb, char c)
    {
        if (sb.Length == 0)
        {
            return -1;
        }

        using ArrayPoolHelper.SharedArray<char> shared = ArrayPoolHelper.Rent<char>(sb.Length);
        sb.CopyTo(0, shared.Value, sb.Length);
        return shared.Value.AsSpan(0, sb.Length).LastIndexOf(c);
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
}
