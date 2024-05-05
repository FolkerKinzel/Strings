using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Intls;

namespace Benchmarks;

[MemoryDiagnoser]
public class IndexOfBench
{
    private readonly StringBuilder _builder200 = new StringBuilder(new string('a', 100)).Append(new string('a', 100));

    //[Benchmark]
    //public int IndexOfLibrary200() => _builder200.IndexOf('z');

    ////[Benchmark]
    ////public int IndexOfChunks() => IndexOf(_builder, 'z');

    ////[Benchmark]
    ////public int IndexOfEnumerator() => IndexOfWithEnumerator(_builder, 'z');

    //[Benchmark]
    //public int IndexOfSpan200() => IndexOfSpan(_builder200, 'z');

    [Benchmark]
    public int IndexOfSpan50() => IndexOfSpan(_builder50, 'z');

    [Benchmark]
    public int IndexOfSpanBounds50() => IndexOfSpanBounds(_builder50, 'z', 0, _builder50.Length);

    ////[Benchmark]
    ////public int IndexOfArray() => IndexOfPolyfill(_builder200, 'z');

    //[Benchmark]
    //public int IndexOfSpanBounds200() => IndexOfSpanBounds(_builder200, 'z', 0, _builder200.Length);

    //[Benchmark]
    //public int IndexOfArrayBounds200() => IndexOfPolyfillBounds(_builder200, 'z', 0, _builder200.Length);

    ////private readonly StringBuilder _builder100 = new StringBuilder(new string('a', 50)).Append(new string('a', 50));
    private readonly StringBuilder _builder50 = new StringBuilder(new string('a', 25)).Append(new string('a', 25));
    private readonly StringBuilder _builder10 = new StringBuilder(new string('a', 8)).Append(new string('a', 8));
    //private readonly StringBuilder _builder4 = new StringBuilder(new string('a', 5)).Append(new string('a', 5));

    //[Benchmark]
    //public int IndexOfArrayBounds50() => IndexOfPolyfillBounds(_builder50, 'z', 0, _builder50.Length);

    //[Benchmark]
    //public int IndexOfArrayBounds10() => IndexOfPolyfillBounds(_builder10, 'z', 0, _builder10.Length);

    //[Benchmark]
    //public int IndexOfArrayBounds4() => IndexOfPolyfillBounds(_builder4, 'z', 0, _builder4.Length);

    //[Benchmark]
    //public int IndexOfSimpleBounds50() => IndexOfSimpleBounds(_builder50, 'z', 0, _builder50.Length);

    //[Benchmark]
    //public int IndexOfSimpleBounds10() => IndexOfSimpleBounds(_builder10, 'z', 0, _builder10.Length);

    //[Benchmark]
    //public int IndexOfSimpleBounds4() => IndexOfSimpleBounds(_builder4, 'z', 0, _builder4.Length);


    //private static int IndexOfPolyfill(StringBuilder sb, char c)
    //{
    //    if (sb.Length == 0)
    //    {
    //        return -1;
    //    }

    //    using ArrayPoolHelper.SharedArray<char> shared = ArrayPoolHelper.Rent<char>(sb.Length);
    //    sb.CopyTo(0, shared.Array, sb.Length);
    //    return shared.Array.AsSpan(0, sb.Length).IndexOf(c);
    //}

    private static int IndexOfSimpleBounds(StringBuilder builder, char value, int startIndex, int count)
    {
        for (int i = startIndex; i < count; ++i)
        {
            if (value == builder[i])
            {
                return i;
            }
        }

        return -1;
    }

    private static int IndexOfPolyfillBounds(StringBuilder sb, char c, int startIndex, int count)
    {
        using ArrayPoolHelper.SharedArray<char> shared = ArrayPoolHelper.Rent<char>(count);
        sb.CopyTo(startIndex, shared.Array, 0, count);
        return shared.Array.AsSpan(0, count).IndexOf(c);
    }

    //private static int IndexOf(StringBuilder sb, char c)
    //{
    //    int pos = 0;

    //    foreach (ReadOnlyMemory<char> chunk in sb.GetChunks())
    //    {
    //        ReadOnlySpan<char> span = chunk.Span;

    //        for (int i = 0; i < span.Length; i++)
    //        {
    //            if (span[i] == c)
    //            {
    //                return pos + i;
    //            }
    //        }

    //        pos += span.Length;
    //    }

    //    return -1;
    //}

    private static int IndexOfSpan(StringBuilder sb, char c)
    {
        int pos = 0;

        foreach (ReadOnlyMemory<char> chunk in sb.GetChunks())
        {
            ReadOnlySpan<char> span = chunk.Span;
            int i = span.IndexOf(c);

            if(i != -1)
            {
                return pos + i;
            }

            pos += span.Length;
        }

        return -1;
    }

    private static int IndexOfSpanBounds(StringBuilder sb, char c, int startIndex, int count)
    {
        int pos = 0;

        foreach (ReadOnlyMemory<char> chunk in sb.GetChunks())
        {
            if(startIndex >= chunk.Length + pos)
            {
                pos += chunk.Length;
                continue;
            }

            int spanStart = startIndex - pos;
            int evaluatedLength = chunk.Length - spanStart;
            ReadOnlySpan<char> span = chunk.Span;
            int idx;

            if (evaluatedLength >= count)
            {
                span = span.Slice(spanStart, count);

                idx = span.IndexOf(c);

                return idx == -1 ? -1 : pos + idx;
            }

            span = span.Slice(spanStart);

            idx = span.IndexOf(c);

            if (idx != -1)
            {
                return pos + idx;
            }
           
            pos += chunk.Length;
            count -= evaluatedLength;
            startIndex = pos;
        }

        return -1;
    }
}
