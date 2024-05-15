```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.205
  [Host]             : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET 6.0           : .NET 6.0.30 (6.0.3024.21525), X64 RyuJIT AVX2
  .NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256


```
| Method                                | Job                | Runtime            | N | Mean      | Error     | StdDev    | Median    | Gen0   | Allocated |
|-------------------------------------- |------------------- |------------------- |-- |----------:|----------:|----------:|----------:|-------:|----------:|
| **ReplaceWhiteSpaceStringLibrary**        | **.NET 6.0**           | **.NET 6.0**           | **1** |  **1.617 μs** | **0.0324 μs** | **0.0421 μs** |  **1.633 μs** | **0.2346** |     **984 B** |
| ReplaceWhiteSpaceStringBuilderLibrary | .NET 6.0           | .NET 6.0           | 1 |  1.915 μs | 0.0065 μs | 0.0061 μs |  1.914 μs |      - |         - |
| ReplaceWhiteSpaceStringLibrary        | .NET 8.0           | .NET 8.0           | 1 |  1.401 μs | 0.0062 μs | 0.0048 μs |  1.399 μs | 0.2346 |     984 B |
| ReplaceWhiteSpaceStringBuilderLibrary | .NET 8.0           | .NET 8.0           | 1 |  1.354 μs | 0.0267 μs | 0.0399 μs |  1.370 μs |      - |         - |
| ReplaceWhiteSpaceStringLibrary        | .NET Framework 4.8 | .NET Framework 4.8 | 1 |  3.937 μs | 0.0195 μs | 0.0173 μs |  3.938 μs | 0.2365 |     995 B |
| ReplaceWhiteSpaceStringBuilderLibrary | .NET Framework 4.8 | .NET Framework 4.8 | 1 |  4.096 μs | 0.0238 μs | 0.0199 μs |  4.089 μs |      - |         - |
| **ReplaceWhiteSpaceStringLibrary**        | **.NET 6.0**           | **.NET 6.0**           | **2** |  **1.633 μs** | **0.0032 μs** | **0.0025 μs** |  **1.633 μs** | **0.2346** |     **984 B** |
| ReplaceWhiteSpaceStringBuilderLibrary | .NET 6.0           | .NET 6.0           | 2 |  3.778 μs | 0.0163 μs | 0.0153 μs |  3.780 μs |      - |         - |
| ReplaceWhiteSpaceStringLibrary        | .NET 8.0           | .NET 8.0           | 2 |  1.399 μs | 0.0073 μs | 0.0065 μs |  1.397 μs | 0.2346 |     984 B |
| ReplaceWhiteSpaceStringBuilderLibrary | .NET 8.0           | .NET 8.0           | 2 |  3.616 μs | 0.3263 μs | 0.9622 μs |  3.226 μs |      - |         - |
| ReplaceWhiteSpaceStringLibrary        | .NET Framework 4.8 | .NET Framework 4.8 | 2 |  3.911 μs | 0.0767 μs | 0.1260 μs |  3.955 μs | 0.2289 |     995 B |
| ReplaceWhiteSpaceStringBuilderLibrary | .NET Framework 4.8 | .NET Framework 4.8 | 2 |  7.857 μs | 0.1550 μs | 0.2547 μs |  7.987 μs |      - |         - |
| **ReplaceWhiteSpaceStringLibrary**        | **.NET 6.0**           | **.NET 6.0**           | **3** |  **1.604 μs** | **0.0314 μs** | **0.0497 μs** |  **1.634 μs** | **0.2346** |     **984 B** |
| ReplaceWhiteSpaceStringBuilderLibrary | .NET 6.0           | .NET 6.0           | 3 |  5.616 μs | 0.1102 μs | 0.1683 μs |  5.688 μs |      - |         - |
| ReplaceWhiteSpaceStringLibrary        | .NET 8.0           | .NET 8.0           | 3 |  1.397 μs | 0.0078 μs | 0.0066 μs |  1.394 μs | 0.2346 |     984 B |
| ReplaceWhiteSpaceStringBuilderLibrary | .NET 8.0           | .NET 8.0           | 3 |  4.199 μs | 0.0100 μs | 0.0088 μs |  4.201 μs |      - |         - |
| ReplaceWhiteSpaceStringLibrary        | .NET Framework 4.8 | .NET Framework 4.8 | 3 |  3.945 μs | 0.0102 μs | 0.0096 μs |  3.944 μs | 0.2365 |     995 B |
| ReplaceWhiteSpaceStringBuilderLibrary | .NET Framework 4.8 | .NET Framework 4.8 | 3 | 11.794 μs | 0.0604 μs | 0.0535 μs | 11.797 μs |      - |         - |
