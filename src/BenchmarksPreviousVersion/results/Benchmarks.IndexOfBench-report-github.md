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
| IndexOf50 | .NET 6.0           | .NET 6.0           | 113.91 ns | 2.315 ns | 3.671 ns |         - |
| IndexOf10 | .NET 6.0           | .NET 6.0           |  20.38 ns | 0.093 ns | 0.073 ns |         - |
| IndexOf50 | .NET 8.0           | .NET 8.0           | 106.32 ns | 0.942 ns | 0.735 ns |         - |
| IndexOf10 | .NET 8.0           | .NET 8.0           |  17.36 ns | 0.083 ns | 0.077 ns |         - |
| IndexOf50 | .NET Framework 4.8 | .NET Framework 4.8 | 123.66 ns | 0.459 ns | 0.429 ns |         - |
| IndexOf10 | .NET Framework 4.8 | .NET Framework 4.8 |  23.19 ns | 0.063 ns | 0.053 ns |         - |
