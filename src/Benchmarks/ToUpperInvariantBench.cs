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
        builder.CopyTo(0, shared.Array, 0, builder.Length);
        Span<char> span = shared.Array.AsSpan(0, builder.Length);
        _ = span.ToUpperInvariant();
        return builder.Clear().Append(shared.Array, 0, span.Length);
    }

    private static StringBuilder ToUpperInvariantBcl(StringBuilder builder)
    {
        if (builder.Length == 0)
        {
            return builder;
        }

        using ArrayPoolHelper.SharedArray<char> source = ArrayPoolHelper.Rent<char>(builder.Length);
        using ArrayPoolHelper.SharedArray<char> destination = ArrayPoolHelper.Rent<char>(builder.Length);

        builder.CopyTo(0, source.Array, 0, builder.Length);
        ReadOnlySpan<char> sourceSpan = source.Array.AsSpan(0, builder.Length);

        // MemoryExtensions assumes that changing case does not affect length
        _ = sourceSpan.ToUpperInvariant(destination.Array.AsSpan(0, builder.Length));

        return builder.Clear().Append(destination.Array, 0, sourceSpan.Length);
    }

    private static StringBuilder ToUpperInvariantChunks(StringBuilder builder)
    {
        if(builder.Length == 0)
        {
            return builder;
        }

        int length = builder.Length;
        using ArrayPoolHelper.SharedArray<char> destination = ArrayPoolHelper.Rent<char>(length);

        // MemoryExtensions assumes that changing case does not affect length
        Span<char> destSpan = destination.Array.AsSpan(0, length);

        foreach (ReadOnlyMemory<char> chunk in builder.GetChunks())
        {
            _ = chunk.Span.ToUpperInvariant(destSpan);
            destSpan = destSpan.Slice(chunk.Length);
        }

        return builder.Clear().Append(destination.Array, 0, length);
    }
}
