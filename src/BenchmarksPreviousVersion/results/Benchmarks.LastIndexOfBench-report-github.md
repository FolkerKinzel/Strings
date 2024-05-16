```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.205
  [Host]             : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET 6.0           : .NET 6.0.30 (6.0.3024.21525), X64 RyuJIT AVX2
  .NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256


```
| Method    | Job                | Runtime            | Mean      | Error    | StdDev   | Allocated |
|---------- |------------------- |------------------- |----------:|---------:|---------:|----------:|
| IndexOf50 | .NET 6.0           | .NET 6.0           | 136.59 ns | 1.505 ns | 1.257 ns |         - |
| IndexOf10 | .NET 6.0           | .NET 6.0           |  27.46 ns | 0.117 ns | 0.109 ns |         - |
| IndexOf50 | .NET 8.0           | .NET 8.0           | 107.57 ns | 0.348 ns | 0.309 ns |         - |
| IndexOf10 | .NET 8.0           | .NET 8.0           |  18.68 ns | 0.405 ns | 0.642 ns |         - |
| IndexOf50 | .NET Framework 4.8 | .NET Framework 4.8 | 118.48 ns | 0.408 ns | 0.381 ns |         - |
| IndexOf10 | .NET Framework 4.8 | .NET Framework 4.8 |  23.52 ns | 0.106 ns | 0.094 ns |         - |
