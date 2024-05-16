// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using Benchmarks;

//_ = BenchmarkRunner.Run<ReplaceLineEndingsBench>();
//_ = BenchmarkRunner.Run<ReplaceWhiteSpaceWithBench>();
//_ = BenchmarkRunner.Run<IndexOfBench>();
//_ = BenchmarkRunner.Run<LastIndexOfBench>();
//_ = BenchmarkRunner.Run<StringBuilderTrimEndBench>();

//_ = BenchmarkRunner.Run<ToUpperInvariantBench>();
_ = BenchmarkRunner.Run<ContainsNewLineBench>();



