using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;

namespace Benchmarks;

public class IndexOfAnyExceptBench
{
    private readonly string s = new('a', 200);
    const string NEEDLE = "a";

    [Benchmark]
    public int SingleValue() => s.AsSpan().IndexOfAnyExcept('a');

    [Benchmark]
    public int Span() => s.AsSpan().IndexOfAnyExcept(NEEDLE);
}
