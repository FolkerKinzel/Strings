using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;

namespace Benchmarks;

[MemoryDiagnoser]
public class IsUtf8Bench
{
    private static readonly FileInfo _fi = new(@"C:\Users\fkinz\source\repos\FolkerKinzel.Strings\src\Benchmarks\Testfiles\AnsiIssue.vcf");


    [Benchmark]
    public bool IsUtf8Test() => _fi.IsUtf8();
}
