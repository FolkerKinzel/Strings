using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;

namespace Benchmarks;

[MemoryDiagnoser]
public class IndexOfBench
{
    private StringBuilder _builder = new(new string('a', 200));

    [Benchmark]
    public int IndexOfLibrary() => _builder.IndexOf('z');

    [Benchmark]
    public int IndexOfChunks() => IndexOf(_builder, 'z');


    private static int IndexOf(StringBuilder sb, char c)
    {
        int pos = 0;

        foreach (ReadOnlyMemory<char> chunk in sb.GetChunks())
        {
            ReadOnlySpan<char> span = chunk.Span;

            for (int i = 0; i < span.Length; i++)
            {
                if (span[i] == c)
                {
                    return pos + i;
                }
            }

            pos += span.Length;
        }

        return -1;
    }
}
