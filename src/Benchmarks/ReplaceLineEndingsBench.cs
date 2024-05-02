using System;
using System.Runtime.CompilerServices;
using System.Text;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Intls;

namespace Benchmarks;

[MemoryDiagnoser]
public class ReplaceLineEndingsBench
{
    public ReplaceLineEndingsBench() => this.TestString = Properties.Resources.ReplaceLineEndingsTest;

    public string TestString { get; }

    [Benchmark]
    public StringBuilder StringBuilderLibrary()
    {
        var sb = new StringBuilder(TestString);
        return sb.ReplaceLineEndings("\r\n");
    }

    [Benchmark]
    public StringBuilder StringBuilderArrayPool()
    {
        var sb = new StringBuilder(TestString);
        return ReplaceLineEndings(sb, "\r\n");
    }

    //[Benchmark]
    //public StringBuilder BenchStringBuilder2()
    //{
    //    var sb = new StringBuilder(TestString);
    //    return sb.ReplaceLineEndings("\n");
    //}

    [Benchmark]
    public string StringLibrary() => TestString.ReplaceLineEndings("\r\n");

    [Benchmark]
    public string StringArrayPool() => ReplaceLineEndings(TestString, "\r\n");

    //[Benchmark]
    //public string BenchString2() => TestString.ReplaceLineEndings("\n");


    private static StringBuilder ReplaceLineEndings(StringBuilder input, ReadOnlySpan<char> replacement)
    {
        if (input.Length == 0)
        {
            return input;
        }

        int capacity = ComputeMaxCapacity(input.Length, replacement.Length);

        using ArrayPoolHelper.SharedArray<char> source = ArrayPoolHelper.Rent<char>(input.Length);
        input.CopyTo(0, source.Array, 0, input.Length);

        using ArrayPoolHelper.SharedArray<char> buf = ArrayPoolHelper.Rent<char>(capacity);
        int outLength = ReplaceLineEndings(source.Array.AsSpan(0, input.Length), replacement, buf.Array, out bool replaced);

        if (replaced)
        {
            input.Length = 0;
            input.Append(buf.Array, 0, outLength);
        }

        return input;
    }


    private static string ReplaceLineEndings(string input, ReadOnlySpan<char> replacement)
    {
        int capacity = ComputeMaxCapacity(input.Length, replacement.Length);

        if (capacity > Const.StackallocCharThreshold)
        {
            using ArrayPoolHelper.SharedArray<char> buf = ArrayPoolHelper.Rent<char>(capacity);
            int outLength = ReplaceLineEndings(input, replacement, buf.Array, out bool replaced);
            return replaced ? buf.Array.AsSpan(0, outLength).ToString() : input;
        }
        else
        {
            Span<char> destination = stackalloc char[capacity];
            int outLength = ReplaceLineEndings(input, replacement, destination, out bool replaced);
            return replaced ? destination.Slice(0, outLength).ToString() : input;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int ComputeMaxCapacity(int sourceLength, int replacementLength)
        => sourceLength * Math.Max(1, replacementLength);

    private static int ReplaceLineEndings(ReadOnlySpan<char> source, ReadOnlySpan<char> replacement, Span<char> destination, out bool replaced)
    {
        bool rFound = false;
        int destIdx = 0;
        replaced = false;

        for (int i = 0; i < source.Length; i++)
        {
            char c = source[i];

            switch (c)
            {
                case '\r': // CR: Carriage Return
                    rFound = true;
                    _ = replacement.TryCopyTo(destination.Slice(destIdx));
                    destIdx += replacement.Length;
                    replaced = true;
                    break;
                case '\n': // LF: Line Feed
                    if (rFound)
                    {
                        rFound = false;
                        continue;
                    }
                    _ = replacement.TryCopyTo(destination.Slice(destIdx));
                    destIdx += replacement.Length;
                    replaced = true;
                    break;
                //case '\u000B': // VT: Vertical Tab
                case '\u000C': // FF: Form Feed
                case '\u0085': // NEL: Next Line
                case '\u2028': // LS: Line Separator
                case '\u2029': // PS: Paragraph Separator
                    rFound = false;
                    _ = replacement.TryCopyTo(destination.Slice(destIdx));
                    destIdx += replacement.Length;
                    replaced = true;
                    break;
                default:
                    rFound = false;
                    destination[destIdx++] = c;
                    break;
            }
        }

        return destIdx;
    }
}
