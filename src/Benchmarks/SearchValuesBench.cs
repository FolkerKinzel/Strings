using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class SearchValuesBench
{
    private readonly string _string;
    private readonly SearchValues<char> _searchValues;
    private readonly char[] _arr;
    private const string SEARCH_CHARS = "-_3456";

    public SearchValuesBench()
    {
        _string = new String('a', 50000);
        _searchValues = SearchValues.Create(SEARCH_CHARS);
        _arr = SEARCH_CHARS.ToCharArray();
    }

    [Benchmark]
    public int MemoryExtensionsTest() => System.MemoryExtensions.IndexOfAny(_string.AsSpan(), SEARCH_CHARS);

    [Benchmark]
    public int SearchValuesTest() => System.MemoryExtensions.IndexOfAny(_string.AsSpan(), _searchValues);

    [Benchmark]
    public int StringTest() => _string.IndexOfAny(_arr);
}
