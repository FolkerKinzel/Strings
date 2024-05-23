// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using Experiments;

//_ = BenchmarkRunner.Run<TrimBench>();
//_ = BenchmarkRunner.Run<ConcatBench>();
_ = BenchmarkRunner.Run<ToStringBench>();

//new ConcatBench().ConcatSpanBench();
