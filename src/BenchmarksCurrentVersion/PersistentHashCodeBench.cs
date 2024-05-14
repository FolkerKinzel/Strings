using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Toolchains.Roslyn;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Intls;

namespace Benchmarks;

[MemoryDiagnoser]
public class PersistentHashCodeBench
{
    private readonly string _s = new('a', 200);
    private readonly StringBuilder _builder;

    public PersistentHashCodeBench() => _builder = new StringBuilder(_s);

    [Benchmark]
    public int SpanHashLibrary() => _s.AsSpan().GetPersistentHashCode(HashType.Ordinal);

    [Benchmark]
    public int SpanHashStruct()
    {
        var hash = new PersistentStringHash(HashType.Ordinal);
        hash.Add(_s.AsSpan());
        return hash.ToHashCode();
    }

    [Benchmark]
    public int StringBuilderHashLibrary() => _builder.GetPersistentHashCode(HashType.Ordinal);

    [Benchmark]
    public int StringBuilderHashCopy() => GetPersistentHashCode(_builder, HashType.Ordinal);


    [Benchmark]
    public int StringBuilderHashChunks()
    {
        var hash = new PersistentStringHash(HashType.Ordinal);
        hash.Add(_builder);
        return hash.ToHashCode();
    }


    private static int GetPersistentHashCode(StringBuilder sb, HashType hashType)
    {
        using ArrayPoolHelper.SharedArray<char> shared = ArrayPoolHelper.Rent<char>(sb.Length);
        sb.CopyTo(0, shared.Array, 0, sb.Length);
        return ((ReadOnlySpan<char>)shared.Array.AsSpan(0, sb.Length)).GetPersistentHashCode(hashType);
    }

    //private static int GetPersistentHashCode2(StringBuilder sb, HashType hashType)
    //{
    //    var hash = new PersistentStringHash(hashType);

    //    foreach (ReadOnlyMemory<char> memory in sb.GetChunks())
    //    {
    //        hash.Append(memory.Span);
    //    }

    //    return hash.Hash;
    //}

    //[Benchmark]
    //public int SpanHashSplitted()
    //{
    //    var hash = new PersistentHashCode(HashType.Ordinal);
    //    hash.Append(_s.AsSpan(0, 100));
    //    hash.Append(_s.AsSpan(100));
    //    return hash.Hash;
    //}
}
