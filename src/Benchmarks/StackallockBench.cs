﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings.Intls;

namespace Benchmarks;

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
        Span<char> span = shared.Value.AsSpan(0, length);
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
        Span<byte> span = shared.Value.AsSpan(0, length);
        return span.Length;
    }
}
