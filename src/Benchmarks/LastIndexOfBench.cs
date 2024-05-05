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
//[SimpleJob(runtimeMoniker: RuntimeMoniker.Net80)]
public class LastIndexOfBench
{
    [Benchmark]
    public int IndexOf50() => StringBuilders._50.LastIndexOf('x');

    [Benchmark]
    public int IndexOf10() => StringBuilders._10.LastIndexOf('x');
}
