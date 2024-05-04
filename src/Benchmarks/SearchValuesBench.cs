using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;

namespace Benchmarks;

[MemoryDiagnoser]
public class SearchValuesBench
{
    private readonly string _string;
    private readonly SearchValues<char> _searchValues;
    private readonly char[] _arr;
    private const string SEARCH_CHARS = "\n\r\f\u0085\u2028\u2029";

    public SearchValuesBench()
    {
        _string = new string('a', 500);
        _searchValues = SearchValues.Create(SEARCH_CHARS);
        _arr = SEARCH_CHARS.ToCharArray();
    }

    [Benchmark]
    public int MemoryExtensionsTest() => System.MemoryExtensions.IndexOfAny(_string.AsSpan(), SEARCH_CHARS);

    [Benchmark]
    public int SearchValuesTest() => System.MemoryExtensions.IndexOfAny(_string.AsSpan(), _searchValues);

    [Benchmark]
    public int StringTest() => _string.IndexOfAny(_arr);

    [Benchmark]
    public int IsNewLineTest()
    {
        ReadOnlySpan<char> span = _string.AsSpan();

        for (int i = 0; i < span.Length; i++)
        {
            if (span[i].IsNewLine())
            {
                return i;
            }
        }

        return -1;
    }

    [Benchmark]
    public int IsNewLineSearchValuesTest()
    {
        ReadOnlySpan<char> span = _string.AsSpan();
        ReadOnlySpan<char> needles = SEARCH_CHARS.AsSpan();

        for (int i = 0; i < span.Length; i++)
        {
            if (needles.Contains(span[i]))
            {
                return i;
            }
        }

        return -1;
    }

    [Benchmark]
    public int IsNewLineSpanTest()
    {
        ReadOnlySpan<char> span = _string.AsSpan();

        for (int i = 0; i < span.Length; i++)
        {
            if (_searchValues.Contains(span[i]))
            {
                return i;
            }
        }

        return -1;
    }
}
