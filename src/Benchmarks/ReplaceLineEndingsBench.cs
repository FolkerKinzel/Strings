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
    public StringBuilder StringBuilderLibraryNoChanges()
    {
        var sb = new StringBuilder(TestString);
        return sb.ReplaceLineEndings("\r\n");
    }

    [Benchmark]
    public StringBuilder StringBuilderArrayPoolNoChanges()
    {
        var sb = new StringBuilder(TestString);
        return ReplaceLineEndings(sb, "\r\n");
    }

    [Benchmark]
    public StringBuilder StringBuilderChunksNoChanges()
    {
        var sb = new StringBuilder(TestString);
        return ReplaceLineEndingsChunks(sb, "\r\n");
    }

    [Benchmark]
    public StringBuilder StringBuilderLibraryChanges()
    {
        var sb = new StringBuilder(TestString);
        return sb.ReplaceLineEndings("\n");
    }

    [Benchmark]
    public StringBuilder StringBuilderArrayPoolChanges()
    {
        var sb = new StringBuilder(TestString);
        return ReplaceLineEndings(sb, "\n");
    }

    [Benchmark]
    public StringBuilder StringBuilderChunksChanges()
    {
        var sb = new StringBuilder(TestString);
        return ReplaceLineEndingsChunks(sb, "\n");
    }


    [Benchmark]
    public string StringLibraryNoChanges() => TestString.ReplaceLineEndings("\r\n");

    [Benchmark]
    public string StringArrayPoolNoChanges() => ReplaceLineEndings(TestString, "\r\n");

    [Benchmark]
    public string StringLibraryChanges() => TestString.ReplaceLineEndings("\n");

    [Benchmark]
    public string StringArrayPoolChanges() => ReplaceLineEndings(TestString, "\n");




    private static StringBuilder ReplaceLineEndings(StringBuilder input, ReadOnlySpan<char> replacement)
    {
        // TODO: Get the index of the first line break char and process only from that
        // If the index is -1, quit.
        // Get also the index of the last line break char and process only the span between.

        if (input.Length == 0)
        {
            return input;
        }

        int capacity = ComputeMaxCapacity(input.Length, replacement.Length);

        using ArrayPoolHelper.SharedArray<char> source = ArrayPoolHelper.Rent<char>(input.Length);
        input.CopyTo(0, source.Array, 0, input.Length);

        using ArrayPoolHelper.SharedArray<char> buf = ArrayPoolHelper.Rent<char>(capacity);
        ReadOnlySpan<char> sourceSpan = source.Array.AsSpan(0, input.Length);
        int outLength = ReplaceLineEndings(sourceSpan, replacement, buf.Array);

        if (!sourceSpan.Equals(buf.Array.AsSpan(0, outLength), StringComparison.Ordinal))
        {
            input.Length = 0;
            input.Append(buf.Array, 0, outLength);
        }

        return input;
    }

    private static StringBuilder ReplaceLineEndingsChunks(StringBuilder input, ReadOnlySpan<char> replacement)
    {
        // TODO: Get the index of the first line break char and process only from that
        // If the index is -1, quit.
        // Get also the index of the last line break char and process only the span between.

        if (input.Length == 0)
        {
            return input;
        }

        using ArrayPoolHelper.SharedArray<char> buf =
            ArrayPoolHelper.Rent<char>(ComputeMaxCapacity(input.Length, replacement.Length));

        Span<char> outSpan = buf.Array.AsSpan();
        bool rFound = false;
        int outLength = 0;

        foreach (ReadOnlyMemory<char> chunk in input.GetChunks())
        {
            ReplaceLineEndings(chunk.Span, replacement, outSpan, ref rFound,  ref outLength);
        }

        input.Length = 0;
        input.Append(outSpan.Slice(0, outLength));

        return input;
    }


    private static string ReplaceLineEndings(string input, ReadOnlySpan<char> replacement)
    {
        // TODO: Get the index of the first line break char.
        // If the index is -1, quit.
        // Get also the index of the last line break char and process only the span between.
        // Use string.Concat to concat the three parts

        int capacity = ComputeMaxCapacity(input.Length, replacement.Length);

        if (capacity > Const.StackallocCharThreshold)
        {
            using ArrayPoolHelper.SharedArray<char> buf = ArrayPoolHelper.Rent<char>(capacity);
            int outLength = ReplaceLineEndings(input, replacement, buf.Array);
            Span<char> outSpan = buf.Array.AsSpan(0, outLength);
            return input.AsSpan().Equals(outSpan, StringComparison.Ordinal) ? input : outSpan.ToString();
        }
        else
        {
            Span<char> destination = stackalloc char[capacity];
            int outLength = ReplaceLineEndings(input, replacement, destination);
            Span<char> outSpan = destination.Slice(0, outLength);
            return input.AsSpan().Equals(outSpan, StringComparison.Ordinal) ? input : outSpan.ToString();
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int ComputeMaxCapacity(int sourceLength, int replacementLength)
        => sourceLength * Math.Max(1, replacementLength);

    private static int ReplaceLineEndings(ReadOnlySpan<char> source, ReadOnlySpan<char> replacement, Span<char> destination)
    {
        bool rFound = false;
        int outputLength = 0;

        for (int i = 0; i < source.Length; i++)
        {
            char c = source[i];

            switch (c)
            {
                case '\r': // CR: Carriage Return
                    rFound = true;
                    _ = replacement.TryCopyTo(destination.Slice(outputLength));
                    outputLength += replacement.Length;
                    break;
                case '\n': // LF: Line Feed
                    if (rFound)
                    {
                        rFound = false;
                        continue;
                    }
                    _ = replacement.TryCopyTo(destination.Slice(outputLength));
                    outputLength += replacement.Length;
                    break;
                //case '\u000B': // VT: Vertical Tab
                case '\u000C': // FF: Form Feed
                case '\u0085': // NEL: Next Line
                case '\u2028': // LS: Line Separator
                case '\u2029': // PS: Paragraph Separator
                    rFound = false;
                    _ = replacement.TryCopyTo(destination.Slice(outputLength));
                    outputLength += replacement.Length;
                    break;
                default:
                    rFound = false;
                    destination[outputLength++] = c;
                    break;
            }
        }

        return outputLength;
    }

    private static void ReplaceLineEndings(ReadOnlySpan<char> source,
                                           ReadOnlySpan<char> replacement,
                                           Span<char> destination,
                                           ref bool rFound,
                                           ref int outputLength)
    {
        for (int i = 0; i < source.Length; i++)
        {
            char c = source[i];

            switch (c)
            {
                case '\r': // CR: Carriage Return
                    rFound = true;
                    _ = replacement.TryCopyTo(destination.Slice(outputLength));
                    outputLength += replacement.Length;
                    break;
                case '\n': // LF: Line Feed
                    if (rFound)
                    {
                        rFound = false;
                        continue;
                    }
                    _ = replacement.TryCopyTo(destination.Slice(outputLength));
                    outputLength += replacement.Length;
                    break;
                //case '\u000B': // VT: Vertical Tab
                case '\u000C': // FF: Form Feed
                case '\u0085': // NEL: Next Line
                case '\u2028': // LS: Line Separator
                case '\u2029': // PS: Paragraph Separator
                    rFound = false;
                    _ = replacement.TryCopyTo(destination.Slice(outputLength));
                    outputLength += replacement.Length;
                    break;
                default:
                    rFound = false;
                    destination[outputLength++] = c;
                    break;
            }
        }
    }
}
