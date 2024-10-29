using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using FolkerKinzel.Strings;

namespace Benchmarks;

public class CharComparer : IEqualityComparer<char>
{
    public bool Equals(char x, char y) => x == y;
    public int GetHashCode(char obj) => obj.GetHashCode();
}

[MarkdownExporter]
[SimpleJob(RuntimeMoniker.Net80)]
//[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net48)]
public class CommonPrefixBench
{
    private readonly CharComparer _comparer = new CharComparer();
    private string _str = new string('a', 500);

    [Benchmark]
    public int Prefix() => _str.AsSpan().CommonPrefixLength(_str.AsSpan());

    [Benchmark]
    public int PrefixComparer() => _str.AsSpan().CommonPrefixLength(_str.AsSpan(), _comparer);
}
