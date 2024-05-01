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
public class ToUpperInvariantBench
{
    private readonly StringBuilder _builder = new StringBuilder(new string('a', 100)).Append(new string('a', 100));


    [Benchmark]
    public StringBuilder ToUpperInvariantLibrary() => _builder.ToUpperInvariant();

    [Benchmark]
    public StringBuilder ToUpperInvariantArray() => ToUpperInvariantArray(_builder);

    [Benchmark]
    public StringBuilder ToUpperInvariantBcl() => ToUpperInvariantBcl(_builder);

    [Benchmark]
    public StringBuilder ToUpperInvariantChunks() => ToUpperInvariantBcl(_builder);

    private static StringBuilder ToUpperInvariantArray(StringBuilder builder)
    {
        if (builder.Length == 0)
        {
            return builder;
        }

        using ArrayPoolHelper.SharedArray<char> shared = ArrayPoolHelper.Rent<char>(builder.Length);
        builder.CopyTo(0, shared.Value, 0, builder.Length);
        Span<char> span = shared.Value.AsSpan(0, builder.Length);
        _ = span.ToUpperInvariant();
        return builder.Clear().Append(shared.Value, 0, span.Length);
    }

    private static StringBuilder ToUpperInvariantBcl(StringBuilder builder)
    {
        if (builder.Length == 0)
        {
            return builder;
        }

        using ArrayPoolHelper.SharedArray<char> source = ArrayPoolHelper.Rent<char>(builder.Length);
        using ArrayPoolHelper.SharedArray<char> destination = ArrayPoolHelper.Rent<char>(builder.Length);

        builder.CopyTo(0, source.Value, 0, builder.Length);
        ReadOnlySpan<char> sourceSpan = source.Value.AsSpan(0, builder.Length);
        _ = sourceSpan.ToUpperInvariant(destination.Value.AsSpan(0, builder.Length));

        return builder.Clear().Append(destination.Value, 0, sourceSpan.Length);
    }

    private static StringBuilder ToUpperInvariantChunks(StringBuilder builder)
    {
        if(builder.Length == 0)
        {
            return builder;
        }

        int length = builder.Length;
        using ArrayPoolHelper.SharedArray<char> destination = ArrayPoolHelper.Rent<char>(length);
        Span<char> destSpan = destination.Value.AsSpan(0, length);

        foreach (ReadOnlyMemory<char> chunk in builder.GetChunks())
        {
            _ = chunk.Span.ToUpperInvariant(destSpan);
            destSpan = destSpan.Slice(chunk.Length);
        }

        return builder.Clear().Append(destination.Value, 0, length);
    }
}
