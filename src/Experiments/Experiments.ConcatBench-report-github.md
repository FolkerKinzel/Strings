```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.205
  [Host]     : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2


```
| Method          | Mean     | Error    | StdDev    | Median   |
|---------------- |---------:|---------:|----------:|---------:|
| ConcatSpanBench | 49.86 μs | 1.340 μs |  3.929 μs | 49.71 μs |
| ConcatListBench | 55.79 μs | 4.781 μs | 14.096 μs | 64.26 μs |
