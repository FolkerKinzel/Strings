```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.205
  [Host]             : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET 6.0           : .NET 6.0.30 (6.0.3024.21525), X64 RyuJIT AVX2
  .NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256


```
| Method                  | Job                | Runtime            | N   | Mean      | Error    | StdDev   | Median    | Allocated |
|------------------------ |------------------- |------------------- |---- |----------:|---------:|---------:|----------:|----------:|
| **ToUpperInvariantLibrary** | **.NET 6.0**           | **.NET 6.0**           | **15**  |  **80.34 ns** | **1.660 ns** | **2.819 ns** |  **82.03 ns** |         **-** |
| ToUpperInvariantLibrary | .NET 8.0           | .NET 8.0           | 15  |  26.25 ns | 0.187 ns | 0.156 ns |  26.16 ns |         - |
| ToUpperInvariantLibrary | .NET Framework 4.8 | .NET Framework 4.8 | 15  | 204.82 ns | 1.620 ns | 1.436 ns | 204.32 ns |         - |
| **ToUpperInvariantLibrary** | **.NET 6.0**           | **.NET 6.0**           | **50**  | **148.63 ns** | **1.185 ns** | **1.108 ns** | **148.77 ns** |         **-** |
| ToUpperInvariantLibrary | .NET 8.0           | .NET 8.0           | 50  |  85.50 ns | 0.272 ns | 0.241 ns |  85.57 ns |         - |
| ToUpperInvariantLibrary | .NET Framework 4.8 | .NET Framework 4.8 | 50  | 452.01 ns | 3.722 ns | 3.300 ns | 451.32 ns |         - |
| **ToUpperInvariantLibrary** | **.NET 6.0**           | **.NET 6.0**           | **100** | **244.30 ns** | **4.969 ns** | **8.164 ns** | **248.59 ns** |         **-** |
| ToUpperInvariantLibrary | .NET 8.0           | .NET 8.0           | 100 | 131.41 ns | 0.442 ns | 0.392 ns | 131.25 ns |         - |
| ToUpperInvariantLibrary | .NET Framework 4.8 | .NET Framework 4.8 | 100 | 788.59 ns | 3.117 ns | 2.915 ns | 788.18 ns |         - |
