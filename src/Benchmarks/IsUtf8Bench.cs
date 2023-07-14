﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;

namespace Benchmarks;

[MemoryDiagnoser]
[BaselineColumn]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Member als statisch markieren", Justification = "<Ausstehend>")]
public class IsUtf8Bench
{
    private static readonly FileInfo _fi = new(@"C:\Users\fkinz\source\repos\FolkerKinzel.Strings\src\Benchmarks\Testfiles\AnsiIssue.vcf");
    private static readonly Encoding _enc = Encoding.GetEncoding(65001, EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback);

    [Benchmark(Baseline = true)]
    public bool IsUtf8Library() => _fi.IsUtf8();


    [Benchmark]
    public bool IsUtf8Exception()
    {
        try
        {
            using var reader = new StreamReader(_fi.FullName, _enc, detectEncodingFromByteOrderMarks: false);
            _ = reader.ReadToEnd();
        }
        catch(DecoderFallbackException)
        { 
            return false; 
        }
        return true;
    }
}
