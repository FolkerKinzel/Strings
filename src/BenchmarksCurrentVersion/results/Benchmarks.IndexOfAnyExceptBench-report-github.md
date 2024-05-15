```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.205
  [Host]             : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET 6.0           : .NET 6.0.30 (6.0.3024.21525), X64 RyuJIT AVX2
  .NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256


```
| Method      | Job                | Runtime            | Mean         | Error     | StdDev    | Allocated |
|------------ |------------------- |------------------- |-------------:|----------:|----------:|----------:|
| SingleValue | .NET 6.0           | .NET 6.0           |    96.019 ns | 1.8537 ns | 1.8205 ns |         - |
| Span        | .NET 6.0           | .NET 6.0           |   614.902 ns | 2.8908 ns | 2.5626 ns |         - |
| SingleValue | .NET 8.0           | .NET 8.0           |     8.042 ns | 0.0257 ns | 0.0215 ns |         - |
| Span        | .NET 8.0           | .NET 8.0           |    11.755 ns | 0.0544 ns | 0.0509 ns |         - |
| SingleValue | .NET Framework 4.8 | .NET Framework 4.8 |   182.965 ns | 0.5922 ns | 0.4624 ns |         - |
| Span        | .NET Framework 4.8 | .NET Framework 4.8 | 1,081.809 ns | 3.5318 ns | 3.3037 ns |         - |
