﻿using System.Text;
using System;
using BenchmarkDotNet.Attributes;
using System.Buffers;
using FolkerKinzel.Strings;

namespace Benchmarks;

[MemoryDiagnoser]
public class ContainsNewLineBench
{
    private readonly string _content = new string('a', 200);
    const string NEW_LINES = "\r\n\u000B\u000C\u0085\u2028\u2029";
    private readonly SearchValues<char> _searchValues = SearchValues.Create(NEW_LINES);

    [Benchmark]
    public bool ContainsNewLineLibrary() => _content.AsSpan().ContainsNewLine();

    [Benchmark]
    public bool ContainsNewLineSpan() => _content.AsSpan().ContainsAny(NEW_LINES);

    [Benchmark]
    public bool ContainsNewLineSearchValues() => _content.AsSpan().ContainsAny(_searchValues);

    [Benchmark]
    public bool CharIsNewLineLibrary() => 'a'.IsNewLine();

    [Benchmark]
    public bool CharIsNewLineSearchValues() => _searchValues.Contains('a');
}