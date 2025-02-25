using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings.Intls;

namespace Experiments;

[MemoryDiagnoser]
public class StackAllockBench
{
    [Benchmark]
    public int StackAllocChar256()
    {
        Span<char> span = stackalloc char[256];
        return span.Length;
    }

    [Benchmark]
    public int RentChar256()
    {
        const int length = 256;
        using ArrayPoolHelper.SharedArray<char> shared = ArrayPoolHelper.Rent<char>(length);
        Span<char> span = shared.Array.AsSpan(0, length);
        return span.Length;
    }


    [Benchmark]
    public int StackAllocByte512()
    {
        Span<byte> span = stackalloc byte[512];
        return span.Length;
    }

    [Benchmark]
    public int RentByte512()
    {
        const int length = 512;
        using ArrayPoolHelper.SharedArray<byte> shared = ArrayPoolHelper.Rent<byte>(length);
        Span<byte> span = shared.Array.AsSpan(0, length);
        return span.Length;
    }
}
