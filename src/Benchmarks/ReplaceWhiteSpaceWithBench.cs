using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Intls;

namespace Benchmarks;

[MemoryDiagnoser]
public class ReplaceWhiteSpaceWithBench
{
    const string REPLACEMENT = "\r\n";
    private readonly string _s;

    public ReplaceWhiteSpaceWithBench()
    {
        var sb = new StringBuilder();

        for (int i = 0; i < 80; i++)
        {
            sb.Append("a\nb  ");
        }
        _s = sb.ToString();
    }

    [Benchmark]
    public string ReplaceWhiteSpaceStringLibrary() => _s.ReplaceWhiteSpaceWith(REPLACEMENT, false);

    [Benchmark]
    public string ReplaceWhiteSpaceStringArrayPool() => ReplaceWhiteSpaceWith(_s, REPLACEMENT, false);

    [Benchmark]
    public StringBuilder ReplaceWhiteSpaceStringBuilderLibrary() => new StringBuilder(_s).ReplaceWhiteSpaceWith(REPLACEMENT, false);

    [Benchmark]
    public StringBuilder ReplaceWhiteSpaceStringBuilderArrayPool() => ReplaceWhiteSpaceWith(new StringBuilder(_s), 0, _s.Length, REPLACEMENT, false);

    private static StringBuilder ReplaceWhiteSpaceWith(StringBuilder input, int startIndex, int count, ReadOnlySpan<char> replacement, bool skipNewLines)
    {
        if(count == 0)
        {
            return input;
        }

        int capacity = ComputeMaxCapacity(count, replacement.Length);

        using ArrayPoolHelper.SharedArray<char> source = ArrayPoolHelper.Rent<char>(count);
        input.CopyTo(startIndex, source.Array, 0, count);

        using ArrayPoolHelper.SharedArray<char> buf = ArrayPoolHelper.Rent<char>(capacity);
        int outLength = ReplaceWhiteSpaceWith(source.Array.AsSpan(0, count), replacement, buf.Array, skipNewLines, out bool replaced);

        if (replaced)
        {
            if (startIndex + count == input.Length)
            {
                input.Length = startIndex;
                input.Append(buf.Array, 0, outLength);
            }
            else
            {
                input.Remove(startIndex, count);
                input.Insert(startIndex, buf.Array, 0, outLength);
            }
        }

        return input;
    }


    private static string ReplaceWhiteSpaceWith(string input, ReadOnlySpan<char> replacement, bool skipNewLines)
    {
        int capacity = ComputeMaxCapacity(input.Length, replacement.Length);

        if (capacity > Const.StackallocCharThreshold)
        {
            using ArrayPoolHelper.SharedArray<char> buf = ArrayPoolHelper.Rent<char>(capacity);
            int outLength = ReplaceWhiteSpaceWith(input, replacement, buf.Array, skipNewLines, out bool replaced);
            return replaced ? buf.Array.AsSpan(0, outLength).ToString() : input;
        }
        else
        {
            Span<char> destination = stackalloc char[capacity];
            int outLength = ReplaceWhiteSpaceWith(input, replacement, destination, skipNewLines, out bool replaced);
            return replaced ? destination.Slice(0, outLength).ToString() : input;
        }
    }

    private static int ComputeMaxCapacity(int sourceLength, int replacementLength)
    {
        int halfEven = (sourceLength + 1) >> 1;
        return halfEven * Math.Max(1, replacementLength) + halfEven;
    }

    private static int ReplaceWhiteSpaceWith(ReadOnlySpan<char> source, ReadOnlySpan<char> replacement, Span<char> destination, bool skipNewLines, out bool replaced)
    {
        bool wsFlag = false;
        int destIdx = 0;
        replaced = false;

        for (int i = 0; i < source.Length; i++)
        {
            char c = source[i];

            if (char.IsWhiteSpace(c))
            {
                if (skipNewLines && c.IsNewLine())
                {
                    wsFlag = false;
                    destination[destIdx++] = c;
                }
                else if (!wsFlag)
                {
                    wsFlag = true;
                    _ = replacement.TryCopyTo(destination.Slice(destIdx));
                    destIdx += replacement.Length;
                    replaced = true;
                }

                continue;
            }

            wsFlag = false;
            destination[destIdx++] = c;
        }

        return destIdx;
    }
}
