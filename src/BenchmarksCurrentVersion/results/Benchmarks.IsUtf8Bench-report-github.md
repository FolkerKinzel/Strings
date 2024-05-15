```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.205
  [Host]             : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET 6.0           : .NET 6.0.30 (6.0.3024.21525), X64 RyuJIT AVX2
  .NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256


```
| Method          | Job                | Runtime            | Mean     | Error    | StdDev   | Ratio | RatioSD | Baseline | Gen0   | Allocated | Alloc Ratio |
|---------------- |------------------- |------------------- |---------:|---------:|---------:|------:|--------:|--------- |-------:|----------:|------------:|
| IsUtf8Library   | .NET 6.0           | .NET 6.0           |       NA |       NA |       NA |     ? |       ? | Yes      |     NA |        NA |           ? |
| IsUtf8Exception | .NET 6.0           | .NET 6.0           |       NA |       NA |       NA |     ? |       ? | No       |     NA |        NA |           ? |
|                 |                    |                    |          |          |          |       |         |          |        |           |             |
| IsUtf8Library   | .NET 8.0           | .NET 8.0           |       NA |       NA |       NA |     ? |       ? | Yes      |     NA |        NA |           ? |
| IsUtf8Exception | .NET 8.0           | .NET 8.0           |       NA |       NA |       NA |     ? |       ? | No       |     NA |        NA |           ? |
|                 |                    |                    |          |          |          |       |         |          |        |           |             |
| IsUtf8Library   | .NET Framework 4.8 | .NET Framework 4.8 | 46.86 μs | 0.933 μs | 1.453 μs |  1.00 |    0.00 | Yes      | 0.4883 |   2.04 KB |        1.00 |
| IsUtf8Exception | .NET Framework 4.8 | .NET Framework 4.8 | 90.13 μs | 0.326 μs | 0.289 μs |  1.97 |    0.07 | No       | 2.1973 |   9.42 KB |        4.62 |

Benchmarks with issues:
  IsUtf8Bench.IsUtf8Library: .NET 6.0(Runtime=.NET 6.0)
  IsUtf8Bench.IsUtf8Exception: .NET 6.0(Runtime=.NET 6.0)
  IsUtf8Bench.IsUtf8Library: .NET 8.0(Runtime=.NET 8.0)
  IsUtf8Bench.IsUtf8Exception: .NET 8.0(Runtime=.NET 8.0)
