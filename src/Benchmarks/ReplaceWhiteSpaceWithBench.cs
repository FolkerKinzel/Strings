using System;
using System.Runtime.CompilerServices;
using System.Text;
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

    //[Benchmark]
    //public string ReplaceWhiteSpaceStringLibrary() => _s.ReplaceWhiteSpaceWith(REPLACEMENT, false);

    //[Benchmark]
    //public string ReplaceWhiteSpaceStringArrayPool() => ReplaceWhiteSpaceWith(_s, REPLACEMENT, false);

    [Benchmark]
    public StringBuilder ReplaceWhiteSpaceStringBuilderLibrary() => new StringBuilder(_s).ReplaceWhiteSpaceWith(REPLACEMENT, false);

    [Benchmark]
    public StringBuilder ReplaceWhiteSpaceStringBuilderArrayPool() => ReplaceWhiteSpaceWith(new StringBuilder(_s), REPLACEMENT, 0, _s.Length, false);

    [Benchmark]
    public StringBuilder ReplaceWhiteSpaceStringBuilderChunks() => ReplaceWhiteSpaceWithChunks(new StringBuilder(_s), REPLACEMENT, 0, _s.Length, false);


    private static StringBuilder ReplaceWhiteSpaceWith(StringBuilder input, ReadOnlySpan<char> replacement, int startIndex, int count, bool skipNewLines)
    {
        // TODO: Get the index of the first white space char and process only from that
        // If the index is -1, quit.
        // Get also the index of the last  white space char and process only the span between.

        if (count == 0)
        {
            return input;
        }

        int capacity = ComputeMaxCapacity(count, replacement.Length);

        using ArrayPoolHelper.SharedArray<char> source = ArrayPoolHelper.Rent<char>(count);
        input.CopyTo(startIndex, source.Array, 0, count);
        ReadOnlySpan<char> sourceSpan = source.Array.AsSpan(0, count);

        using ArrayPoolHelper.SharedArray<char> buf = ArrayPoolHelper.Rent<char>(capacity);
        int outLength = sourceSpan.ReplaceWhiteSpaceWith(replacement, buf.Array, skipNewLines);

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

    private static StringBuilder ReplaceWhiteSpaceWithChunks(StringBuilder input, ReadOnlySpan<char> replacement, int startIndex, int count, bool skipNewLines)
    {
        // TODO: Get the index of the first white space char and process only from that
        // If the index is -1, quit.
        // Get also the index of the last white space char and process only the span between.

        if (count == 0)
        {
            return input;
        }

        int capacity = ComputeMaxCapacity(count, replacement.Length);

        using ArrayPoolHelper.SharedArray<char> buf = ArrayPoolHelper.Rent<char>(capacity);
        Span<char> outSpan = buf.Array.AsSpan();
        int outLength = DoReplace(input, replacement, startIndex, count, skipNewLines, outSpan);

        if (startIndex + count == input.Length)
        {
            input.Length = startIndex;
            input.Append(outSpan.Slice(0, outLength));
        }
        else
        {
            input.Remove(startIndex, count);
            input.Insert(startIndex, outSpan.Slice(0, outLength));
        }

        return input;

        ///////////////////////////////////////////////////////////

        static int DoReplace(StringBuilder input, ReadOnlySpan<char> replacement, int startIndex, int count, bool skipNewLines, Span<char> outSpan)
        {
            bool wsFlag = false;
            int outLength = 0;
            int pos = 0;

            foreach (ReadOnlyMemory<char> chunk in input.GetChunks())
            {
                if (startIndex < chunk.Length + pos)
                {
                    int spanStart = startIndex - pos;
                    ReadOnlySpan<char> span = chunk.Span.Slice(spanStart, Math.Min(chunk.Length - spanStart, count));
                    count -= span.Length;

                    span.ReplaceWhiteSpaceWith(replacement, outSpan, skipNewLines, ref wsFlag, ref outLength);

                    if (count == 0)
                    {
                        break;
                    }
                }

                pos += chunk.Length;
            }

            return outLength;
        }
    }

    

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int ComputeMaxCapacity(int sourceLength, int replacementLength)
    {
        int halfEven = (sourceLength + 1) >> 1;
        return halfEven * Math.Max(1, replacementLength) + halfEven;
    }

    
}
