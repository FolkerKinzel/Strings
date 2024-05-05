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
    private readonly StringBuilder _builder50 = new StringBuilder(new string('a', 25)).Append(new string('a', 25));
    private readonly StringBuilder _builder10 = new StringBuilder(new string('a', 5)).Append(new string('a', 5));

    [Benchmark]
    public int IndexOf50() => _builder50.IndexOf('x');

    [Benchmark]
    public int IndexOf10() => _builder10.IndexOf('x');
}
