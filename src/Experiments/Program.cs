﻿using BenchmarkDotNet.Running;
using Experiments;

//new InRangeBench().IndexExceptInRange();
_ = BenchmarkRunner.Run<InRangeBench>();
//_ = BenchmarkRunner.Run<TrimBench>();
//_ = BenchmarkRunner.Run<ConcatBench>();
//_ = BenchmarkRunner.Run<ToStringBench>();

//new ConcatBench().ConcatSpanBench();
