```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.205
  [Host]             : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET 6.0           : .NET 6.0.30 (6.0.3024.21525), X64 RyuJIT AVX2
  .NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256


```
| Method                   | Job                | Runtime            | Mean     | Error    | StdDev   | Median   | Allocated |
|------------------------- |------------------- |------------------- |---------:|---------:|---------:|---------:|----------:|
| SpanHashLibrary          | .NET 6.0           | .NET 6.0           | 153.8 ns |  0.32 ns |  0.25 ns | 153.9 ns |         - |
| SpanHashStruct           | .NET 6.0           | .NET 6.0           | 224.4 ns |  0.46 ns |  0.39 ns | 224.4 ns |         - |
| StringBuilderHashLibrary | .NET 6.0           | .NET 6.0           | 234.4 ns |  0.98 ns |  0.77 ns | 234.7 ns |         - |
| StringBuilderHashStruct  | .NET 6.0           | .NET 6.0           | 231.0 ns |  4.55 ns |  6.37 ns | 234.3 ns |         - |
| SpanHashLibrary          | .NET 8.0           | .NET 8.0           | 149.9 ns |  1.34 ns |  1.25 ns | 150.1 ns |         - |
| SpanHashStruct           | .NET 8.0           | .NET 8.0           | 216.7 ns |  0.96 ns |  0.80 ns | 216.5 ns |         - |
| StringBuilderHashLibrary | .NET 8.0           | .NET 8.0           | 219.4 ns |  4.35 ns |  6.77 ns | 223.4 ns |         - |
| StringBuilderHashStruct  | .NET 8.0           | .NET 8.0           | 280.2 ns | 24.61 ns | 72.56 ns | 223.3 ns |         - |
| SpanHashLibrary          | .NET Framework 4.8 | .NET Framework 4.8 | 244.6 ns |  0.53 ns |  0.45 ns | 244.5 ns |         - |
| SpanHashStruct           | .NET Framework 4.8 | .NET Framework 4.8 | 281.0 ns |  1.60 ns |  1.50 ns | 281.0 ns |         - |
| StringBuilderHashLibrary | .NET Framework 4.8 | .NET Framework 4.8 | 349.0 ns |  1.02 ns |  0.96 ns | 348.9 ns |         - |
| StringBuilderHashStruct  | .NET Framework 4.8 | .NET Framework 4.8 | 355.5 ns |  4.37 ns |  3.41 ns | 354.6 ns |         - |
