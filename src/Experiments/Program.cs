﻿// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using Experiments;

_ = BenchmarkRunner.Run<TrimBench>();
