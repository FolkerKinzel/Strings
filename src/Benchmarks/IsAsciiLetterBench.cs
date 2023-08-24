using System;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;

namespace Benchmarks;


[MemoryDiagnoser]
public class IsAsciiLetterBench
{
    private readonly char[] _chars = new char[10000];

    public IsAsciiLetterBench()
    {
        for (int i = 0; i < _chars.Length; i++)
        {
            _chars[i] = (char)Random.Shared.Next(128);
        }
    }

    [Benchmark]
    public bool IsAsciiLetterBenchMark()
    {
        bool result = false;
        for (int i = 0;i < _chars.Length; i++)
        {
            result = _chars[i].IsAsciiLetter();
        }
        return result;
    }

    [Benchmark]
    public bool IsAsciiLetter2BenchMark()
    {
        bool result = false;
        for (int i = 0; i < _chars.Length; i++)
        {
            result = _chars[i].IsAsciiLetter2();
        }
        return result;
    }

    [Benchmark]
    public bool IsAsciiLetter3BenchMark()
    {
        bool result = false;
        for (int i = 0; i < _chars.Length; i++)
        {
            result = _chars[i].IsAsciiLetter3();
        }
        return result;
    }

    [Benchmark]
    public bool IsAsciiLetter4BenchMark()
    {
        bool result = false;
        for (int i = 0; i < _chars.Length; i++)
        {
            result = _chars[i].IsAsciiLetter4();
        }
        return result;
    }
}
