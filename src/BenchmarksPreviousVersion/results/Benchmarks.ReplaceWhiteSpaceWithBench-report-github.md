```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.205
  [Host]             : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET 6.0           : .NET 6.0.30 (6.0.3024.21525), X64 RyuJIT AVX2
  .NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256


```
| Method                                | Job                | Runtime            | N | Mean        | Error     | StdDev    | Median      | Gen0   | Allocated |
|-------------------------------------- |------------------- |------------------- |-- |------------:|----------:|----------:|------------:|-------:|----------:|
| **ReplaceWhiteSpaceStringLibrary**        | **.NET 6.0**           | **.NET 6.0**           | **1** |    **34.32 μs** |  **0.131 μs** |  **0.109 μs** |    **34.28 μs** | **2.7466** |   **11512 B** |
| ReplaceWhiteSpaceStringBuilderLibrary | .NET 6.0           | .NET 6.0           | 1 |   112.70 μs |  0.194 μs |  0.172 μs |   112.76 μs |      - |     104 B |
| ReplaceWhiteSpaceStringLibrary        | .NET 8.0           | .NET 8.0           | 1 |    34.31 μs |  0.077 μs |  0.060 μs |    34.31 μs | 2.7466 |   11512 B |
| ReplaceWhiteSpaceStringBuilderLibrary | .NET 8.0           | .NET 8.0           | 1 |   113.36 μs |  0.430 μs |  0.381 μs |   113.39 μs |      - |     104 B |
| ReplaceWhiteSpaceStringLibrary        | .NET Framework 4.8 | .NET Framework 4.8 | 1 |    52.52 μs |  0.127 μs |  0.119 μs |    52.52 μs | 2.7466 |   11554 B |
| ReplaceWhiteSpaceStringBuilderLibrary | .NET Framework 4.8 | .NET Framework 4.8 | 1 |   131.31 μs |  0.492 μs |  0.460 μs |   131.26 μs |      - |     106 B |
| **ReplaceWhiteSpaceStringLibrary**        | **.NET 6.0**           | **.NET 6.0**           | **2** |    **36.56 μs** |  **0.557 μs** |  **1.186 μs** |    **36.02 μs** | **2.7466** |   **11512 B** |
| ReplaceWhiteSpaceStringBuilderLibrary | .NET 6.0           | .NET 6.0           | 2 |   457.03 μs |  1.868 μs |  1.748 μs |   457.36 μs |      - |     105 B |
| ReplaceWhiteSpaceStringLibrary        | .NET 8.0           | .NET 8.0           | 2 |    34.60 μs |  0.158 μs |  0.132 μs |    34.53 μs | 2.7466 |   11512 B |
| ReplaceWhiteSpaceStringBuilderLibrary | .NET 8.0           | .NET 8.0           | 2 |   460.51 μs |  3.504 μs |  3.277 μs |   461.65 μs |      - |     104 B |
| ReplaceWhiteSpaceStringLibrary        | .NET Framework 4.8 | .NET Framework 4.8 | 2 |    62.82 μs |  3.508 μs | 10.342 μs |    57.06 μs | 2.7466 |   11554 B |
| ReplaceWhiteSpaceStringBuilderLibrary | .NET Framework 4.8 | .NET Framework 4.8 | 2 |   498.31 μs |  1.031 μs |  0.914 μs |   498.31 μs |      - |     112 B |
| **ReplaceWhiteSpaceStringLibrary**        | **.NET 6.0**           | **.NET 6.0**           | **3** |    **36.10 μs** |  **0.093 μs** |  **0.087 μs** |    **36.10 μs** | **2.7466** |   **11512 B** |
| ReplaceWhiteSpaceStringBuilderLibrary | .NET 6.0           | .NET 6.0           | 3 | 1,144.20 μs | 12.569 μs | 11.757 μs | 1,146.93 μs |      - |     105 B |
| ReplaceWhiteSpaceStringLibrary        | .NET 8.0           | .NET 8.0           | 3 |    34.68 μs |  0.233 μs |  0.206 μs |    34.67 μs | 2.7466 |   11512 B |
| ReplaceWhiteSpaceStringBuilderLibrary | .NET 8.0           | .NET 8.0           | 3 | 1,137.63 μs |  5.472 μs |  5.119 μs | 1,138.42 μs |      - |     105 B |
| ReplaceWhiteSpaceStringLibrary        | .NET Framework 4.8 | .NET Framework 4.8 | 3 |    52.89 μs |  0.261 μs |  0.244 μs |    52.86 μs | 2.7466 |   11554 B |
| ReplaceWhiteSpaceStringBuilderLibrary | .NET Framework 4.8 | .NET Framework 4.8 | 3 | 1,233.35 μs | 24.371 μs | 22.796 μs | 1,227.40 μs |      - |     112 B |
