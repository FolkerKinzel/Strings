```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.205
  [Host]             : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET 6.0           : .NET 6.0.30 (6.0.3024.21525), X64 RyuJIT AVX2
  .NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256


```
| Method                      | Job                | Runtime            | N | Mean        | Error      | StdDev     | Median      | Gen0   | Allocated |
|---------------------------- |------------------- |------------------- |-- |------------:|-----------:|-----------:|------------:|-------:|----------:|
| **StringBuilderLibraryChanges** | **.NET 6.0**           | **.NET 6.0**           | **1** |   **258.67 ns** |   **5.158 ns** |   **9.034 ns** |   **263.78 ns** |      **-** |         **-** |
| StringLibraryChanges        | .NET 6.0           | .NET 6.0           | 1 |   343.70 ns |   2.180 ns |   1.821 ns |   342.79 ns | 0.0553 |     232 B |
| StringBuilderLibraryChanges | .NET 8.0           | .NET 8.0           | 1 |   217.68 ns |   1.074 ns |   0.897 ns |   217.68 ns |      - |         - |
| StringLibraryChanges        | .NET 8.0           | .NET 8.0           | 1 |    69.33 ns |   0.231 ns |   0.216 ns |    69.35 ns | 0.0554 |     232 B |
| StringBuilderLibraryChanges | .NET Framework 4.8 | .NET Framework 4.8 | 1 |   651.82 ns |   4.357 ns |   4.076 ns |   650.98 ns |      - |         - |
| StringLibraryChanges        | .NET Framework 4.8 | .NET Framework 4.8 | 1 |   599.05 ns |   4.475 ns |   3.967 ns |   597.55 ns | 0.0553 |     233 B |
| **StringBuilderLibraryChanges** | **.NET 6.0**           | **.NET 6.0**           | **2** |   **502.77 ns** |   **2.298 ns** |   **2.149 ns** |   **501.45 ns** |      **-** |         **-** |
| StringLibraryChanges        | .NET 6.0           | .NET 6.0           | 2 |   344.63 ns |   6.748 ns |   9.678 ns |   348.15 ns | 0.0553 |     232 B |
| StringBuilderLibraryChanges | .NET 8.0           | .NET 8.0           | 2 |   426.72 ns |   2.520 ns |   2.105 ns |   426.49 ns |      - |         - |
| StringLibraryChanges        | .NET 8.0           | .NET 8.0           | 2 |    71.25 ns |   0.255 ns |   0.226 ns |    71.26 ns | 0.0554 |     232 B |
| StringBuilderLibraryChanges | .NET Framework 4.8 | .NET Framework 4.8 | 2 | 1,666.50 ns | 136.601 ns | 402.770 ns | 1,877.40 ns |      - |         - |
| StringLibraryChanges        | .NET Framework 4.8 | .NET Framework 4.8 | 2 |   596.28 ns |   3.327 ns |   3.112 ns |   595.98 ns | 0.0553 |     233 B |
| **StringBuilderLibraryChanges** | **.NET 6.0**           | **.NET 6.0**           | **3** |   **714.13 ns** |   **4.737 ns** |   **4.431 ns** |   **714.89 ns** |      **-** |         **-** |
| StringLibraryChanges        | .NET 6.0           | .NET 6.0           | 3 |   342.84 ns |   6.801 ns |   7.560 ns |   346.10 ns | 0.0553 |     232 B |
| StringBuilderLibraryChanges | .NET 8.0           | .NET 8.0           | 3 |   602.56 ns |   1.879 ns |   1.665 ns |   603.16 ns |      - |         - |
| StringLibraryChanges        | .NET 8.0           | .NET 8.0           | 3 |    68.26 ns |   0.274 ns |   0.256 ns |    68.24 ns | 0.0554 |     232 B |
| StringBuilderLibraryChanges | .NET Framework 4.8 | .NET Framework 4.8 | 3 | 1,796.01 ns |   4.477 ns |   3.738 ns | 1,794.84 ns |      - |         - |
| StringLibraryChanges        | .NET Framework 4.8 | .NET Framework 4.8 | 3 |   596.51 ns |   1.851 ns |   1.640 ns |   596.84 ns | 0.0553 |     233 B |
