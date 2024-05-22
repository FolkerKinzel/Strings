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

    [Benchmark]
    public string ConcatListBench() => Concat(_list);

    private static string Concat(List<ReadOnlyMemory<char>> values)
    {
        _ArgumentNullException.ThrowIfNull(values, nameof(values));

        //#if NET5_0_OR_GREATER
        //if (values is List<ReadOnlyMemory<char>> list)
        //{
        //return Concat(CollectionsMarshal.AsSpan(list));
        //}
        //#endif

        if (values.Count == 1)
        {
            return values[0].ToString();
        }

        Span<ReadOnlyMemory<char>> span = CollectionsMarshal.AsSpan(values);
  
        int length = 0;

        for (int i = 0; i < span.Length; i++)
        {
            length += span[i].Length;
        }

        if (length == 0)
        {
            return string.Empty;
        }

        return string.Create(length, values,
            static (buf, vals) =>
            {
                Span<ReadOnlyMemory<char>> source = CollectionsMarshal.AsSpan(vals);

                for(int i = 0; i < source.Length; i++)
                {
                    ReadOnlySpan<char> span = source[i].Span;
                    _ = span.TryCopyTo(buf);
                    buf = buf.Slice(span.Length);
                }
            });
    }
}
