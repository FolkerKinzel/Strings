```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.205
  [Host]             : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET 6.0           : .NET 6.0.30 (6.0.3024.21525), X64 RyuJIT AVX2
  .NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256


```
| Method                  | Job                | Runtime            | N   | Mean      | Error     | StdDev    | Median    | Allocated |
|------------------------ |------------------- |------------------- |---- |----------:|----------:|----------:|----------:|----------:|
| **ToUpperInvariantLibrary** | **.NET 6.0**           | **.NET 6.0**           | **15**  | **120.48 ns** |  **4.689 ns** | **13.302 ns** | **117.01 ns** |         **-** |
| ToUpperInvariantLibrary | .NET 8.0           | .NET 8.0           | 15  |  39.93 ns |  0.132 ns |  0.117 ns |  39.92 ns |         - |
| ToUpperInvariantLibrary | .NET Framework 4.8 | .NET Framework 4.8 | 15  | 147.77 ns |  3.073 ns |  2.874 ns | 148.67 ns |         - |
| **ToUpperInvariantLibrary** | **.NET 6.0**           | **.NET 6.0**           | **50**  | **334.65 ns** |  **1.829 ns** |  **1.622 ns** | **334.56 ns** |         **-** |
| ToUpperInvariantLibrary | .NET 8.0           | .NET 8.0           | 50  | 175.00 ns |  0.886 ns |  0.740 ns | 174.90 ns |         - |
| ToUpperInvariantLibrary | .NET Framework 4.8 | .NET Framework 4.8 | 50  | 492.23 ns |  9.630 ns | 14.414 ns | 497.09 ns |         - |
| **ToUpperInvariantLibrary** | **.NET 6.0**           | **.NET 6.0**           | **100** | **653.39 ns** |  **3.108 ns** |  **2.907 ns** | **653.61 ns** |         **-** |
| ToUpperInvariantLibrary | .NET 8.0           | .NET 8.0           | 100 | 384.44 ns | 19.690 ns | 58.055 ns | 418.96 ns |         - |
| ToUpperInvariantLibrary | .NET Framework 4.8 | .NET Framework 4.8 | 100 | 923.51 ns | 17.187 ns | 35.109 ns | 940.98 ns |         - |
