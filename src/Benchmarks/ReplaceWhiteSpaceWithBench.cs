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
        ReadOnlySpan<char> sourceSpan = source.Array.AsSpan(0, count);

        using ArrayPoolHelper.SharedArray<char> buf = ArrayPoolHelper.Rent<char>(capacity);
        int outLength = ReplaceWhiteSpaceWith(sourceSpan, replacement, buf.Array, skipNewLines);

        if (!sourceSpan.Equals(buf.Array.AsSpan(0, outLength), StringComparison.Ordinal))
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
            int outLength = ReplaceWhiteSpaceWith(input, replacement, buf.Array, skipNewLines);
            ReadOnlySpan<char> outSpan = buf.Array.AsSpan(0, outLength);
            return input.AsSpan().Equals(outSpan, StringComparison.Ordinal) ? input : outSpan.ToString();
        }
        else
        {
            Span<char> destination = stackalloc char[capacity];
            int outLength = ReplaceWhiteSpaceWith(input, replacement, destination, skipNewLines);
            ReadOnlySpan<char> outSpan = destination.Slice(0, outLength);
            return input.AsSpan().Equals(outSpan, StringComparison.Ordinal) ? input : outSpan.ToString();
        }
    }

    private static int ComputeMaxCapacity(int sourceLength, int replacementLength)
    {
        int halfEven = (sourceLength + 1) >> 1;
        return halfEven * Math.Max(1, replacementLength) + halfEven;
    }

    private static int ReplaceWhiteSpaceWith(ReadOnlySpan<char> source,
                                             ReadOnlySpan<char> replacement,
                                             Span<char> destination,
                                             bool skipNewLines)
    {
        bool wsFlag = false;
        int destLength = 0;

        for (int i = 0; i < source.Length; i++)
        {
            char c = source[i];

            if (char.IsWhiteSpace(c))
            {
                if (skipNewLines && c.IsNewLine())
                {
                    wsFlag = false;
                    destination[destLength++] = c;
                }
                else if (!wsFlag)
                {
                    wsFlag = true;
                    _ = replacement.TryCopyTo(destination.Slice(destLength));
                    destLength += replacement.Length;
                }

                continue;
            }

            wsFlag = false;
            destination[destLength++] = c;
        }

        return destLength;
    }
}
