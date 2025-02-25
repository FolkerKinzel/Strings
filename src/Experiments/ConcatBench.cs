using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;

namespace Experiments;

public class ConcatBench
{
    private readonly List<ReadOnlyMemory<char>> _list = ["123".AsMemory(), "456".AsMemory()];

    public ConcatBench()
    {
        _list = new List<ReadOnlyMemory<char>>(60_000);

        const string input = "1234567890";

        for (int i = 0; i < 5000; i++)
        {
            _list.Add(input.AsMemory());
        }
    }

    //[Benchmark]
    //public string ConcatEnumerableBench() => StaticStringMethod.Concat(_list.AsEnumerable());


    [Benchmark]
    public string ConcatSpanBench() => StaticStringMethod.Concat(CollectionsMarshal.AsSpan(_list));


}
