using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Intls;

namespace Benchmarks;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net48)]
public class StreamWriterBench
{
    private const string PATH = "..\\Release\\";
    private string? _input;
    private string? _filePath;

    [Params(10, 50, 100, 5000)]
    public int Length { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _input = new string('a', Length);
        _filePath = Path.Combine(Path.GetFullPath(PATH),"test.txt");
    }

    [Benchmark]
    public long MethodCall()
    {
        ReadOnlySpan<char> span = _input.AsSpan();
        using var fileStream = new FileStream(_filePath!, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
        using var writer = new StreamWriter(fileStream);
        for (int i = 0; i < span.Length; i++)
        {
            writer.Write(span[i]);
        }

        writer.Flush();
        return fileStream.Length;
    }

    [Benchmark]
    public long TempArray()
    {
        ReadOnlySpan<char> span = _input.AsSpan();
        using var fileStream = new FileStream(_filePath!, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
        using var writer = new StreamWriter(fileStream);
        using ArrayPoolHelper.SharedArray<char> shared = ArrayPoolHelper.Rent<char>(span.Length);
        span.CopyTo(shared.Array);
        writer.Write(shared.Array, 0, span.Length);

        writer.Flush();
        return fileStream.Length;
    }
}
