// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using Experiments;

//_ = BenchmarkRunner.Run<TrimBench>();
_ = BenchmarkRunner.Run<ConcatBench>();

//new ConcatBench().ConcatSpanBench();
