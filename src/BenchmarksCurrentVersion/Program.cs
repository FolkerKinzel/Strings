using System;
using BenchmarkDotNet.Running;
using Benchmarks;

BenchmarkDotNet.Reports.Summary report;

// new InsertBench().Test1();
//var val = new IsAsciiLetterBench();
//new IsUtf8Bench().IsUtf8Exception();
//_ = BenchmarkRunner.Run<Base64Bench>();
//
report = BenchmarkRunner.Run<UrlEncodingBench>();

//_ = BenchmarkRunner.Run<IndexOfBench>();
//_ = BenchmarkRunner.Run<LastIndexOfBench>();
//_ = BenchmarkRunner.Run<PersistentHashCodeBench>();
//_ = BenchmarkRunner.Run<ContainsNewLineBench>();
//_ = BenchmarkRunner.Run<ToUpperInvariantBench>();
//_ = BenchmarkRunner.Run<ReplaceWhiteSpaceWithBench>();
//_ = BenchmarkRunner.Run<ReplaceLineEndingsBench>();
//_ = BenchmarkRunner.Run<IndexOfAnyExceptBench>();
//_ = BenchmarkRunner.Run<StringBuilderTrimEndBench>();
//_ = BenchmarkRunner.Run<IsUtf8Bench>();
//_ = BenchmarkRunner.Run<TrimBench>();


//    new ToUpperInvariantBench().ToUpperInvariantChunks();
// new StringBuilderTrimEndBench().Sb10Chunks();
// new IndexOfBench().IndexOfSpanBounds();
// new LastIndexOfBench().LastIndexOfSpanBounds();
// new PersistentHashCodeBench().StringBuilderHashChunks();
//new ReplaceWhiteSpaceWithBench().ReplaceWhiteSpaceStringBuilderChunks();
//new ReplaceLineEndingsBench().StringArrayPoolChanges();
// Base64Bench.Test2();

//new IsUtf8Bench().IsUtf8Exception();


//BenchmarkDotNet.Reports.Summary summary = BenchmarkRunner.Run<IsUtf8Bench>();
//var summary = BenchmarkRunner.Run<ReplaceLineEndingsBench>();//Console.Write("Total Time:");//Console.WriteLine(summary.TotalTime);

Console.WriteLine(report);

