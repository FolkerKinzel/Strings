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
                if(skipNewLines && c.IsNewLine())
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
