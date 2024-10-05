using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;

namespace Experiments;

[MemoryDiagnoser]
public class TrimBench
{
    private const string TRIM_CHARS = " \"\'";
    private const string S = "   \"\"\'\' \"";
    private const string S_FULL = S + "a" + S;


    private readonly SearchValuesPolyfill<char> _trimChars = SearchValuesPolyfill.Create(TRIM_CHARS);

    [Benchmark]
    public int TrimEndBcl() => S.AsSpan().TrimEnd(TRIM_CHARS.AsSpan()).Length;

    [Benchmark]
    public int TrimEndSearchValues() => S.AsSpan().TrimEnd(_trimChars).Length;

    [Benchmark]
    public int TrimStartBcl() => S.AsSpan().TrimStart(TRIM_CHARS.AsSpan()).Length;

    [Benchmark]
    public int TrimStartSearchValues() => S.AsSpan().TrimStart(_trimChars).Length;

    [Benchmark]
    public int TrimBcl() => S_FULL.AsSpan().Trim(TRIM_CHARS.AsSpan()).Length;

    [Benchmark]
    public int TrimSearchValues() => S_FULL.AsSpan().Trim(_trimChars).Length;



}
