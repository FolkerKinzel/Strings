using BenchmarkDotNet.Running;
using Experiments;

new InRangeBench().IndexInRangeOwn();
//_ = BenchmarkRunner.Run<TrimBench>();
//_ = BenchmarkRunner.Run<ConcatBench>();
//_ = BenchmarkRunner.Run<ToStringBench>();

//new ConcatBench().ConcatSpanBench();
