using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Intls;

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
