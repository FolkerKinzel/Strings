```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.205
  [Host]             : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET 6.0           : .NET 6.0.30 (6.0.3024.21525), X64 RyuJIT AVX2
  .NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256


```
| Method    | Job                | Runtime            | Mean      | Error    | StdDev   | Median    | Allocated |
|---------- |------------------- |------------------- |----------:|---------:|---------:|----------:|----------:|
| IndexOf50 | .NET 6.0           | .NET 6.0           |  37.98 ns | 0.784 ns | 1.149 ns |  38.70 ns |         - |
| IndexOf10 | .NET 6.0           | .NET 6.0           |  17.04 ns | 0.080 ns | 0.075 ns |  17.04 ns |         - |
| IndexOf50 | .NET 8.0           | .NET 8.0           |  18.95 ns | 0.074 ns | 0.062 ns |  18.96 ns |         - |
| IndexOf10 | .NET 8.0           | .NET 8.0           |  10.22 ns | 0.236 ns | 0.519 ns |  10.50 ns |         - |
| IndexOf50 | .NET Framework 4.8 | .NET Framework 4.8 | 100.69 ns | 0.347 ns | 0.308 ns | 100.57 ns |         - |
| IndexOf10 | .NET Framework 4.8 | .NET Framework 4.8 |  23.96 ns | 0.179 ns | 0.167 ns |  23.99 ns |         - |
