using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings.Intls;

namespace Benchmarks;

[MemoryDiagnoser]
public class StackAllockBench
{
    [Benchmark]
    public int StackAlloc256()
    {
        Span<char> span = stackalloc char[256];
        return span.Length;
    }

    [Benchmark]
    public int Rent256() 
    {
        using var shared = ArrayPoolHelper.Rent<char>(256);
        Span<char> span = shared.Value;
        span = span.Slice(0, 256);
        return span.Length;
    }
}
