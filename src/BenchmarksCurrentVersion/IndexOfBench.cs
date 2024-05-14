using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Intls;

namespace Benchmarks;

[MemoryDiagnoser]
//[SimpleJob(runtimeMoniker: RuntimeMoniker.Net80)]
public class IndexOfBench
{
    [Benchmark]
    public int IndexOf50() => StringBuilders._50.IndexOf('x');

    [Benchmark]
    public int IndexOf10() => StringBuilders._10.IndexOf('x');
}
