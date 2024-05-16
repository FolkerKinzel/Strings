```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.205
  [Host]             : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET 6.0           : .NET 6.0.30 (6.0.3024.21525), X64 RyuJIT AVX2
  .NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256


```
| Method                      | Job                | Runtime            | N | Mean         | Error      | StdDev     | Gen0   | Allocated |
|---------------------------- |------------------- |------------------- |-- |-------------:|-----------:|-----------:|-------:|----------:|
| **StringBuilderLibraryChanges** | **.NET 6.0**           | **.NET 6.0**           | **1** |  **2,985.86 ns** |  **45.132 ns** |  **37.687 ns** |      **-** |         **-** |
| StringLibraryChanges        | .NET 6.0           | .NET 6.0           | 1 |    346.55 ns |   1.876 ns |   1.663 ns | 0.0553 |     232 B |
| StringBuilderLibraryChanges | .NET 8.0           | .NET 8.0           | 1 |  3,276.30 ns |  18.972 ns |  16.819 ns |      - |         - |
| StringLibraryChanges        | .NET 8.0           | .NET 8.0           | 1 |     69.99 ns |   0.752 ns |   0.703 ns | 0.0554 |     232 B |
| StringBuilderLibraryChanges | .NET Framework 4.8 | .NET Framework 4.8 | 1 |  3,179.78 ns |  30.409 ns |  23.741 ns |      - |         - |
| StringLibraryChanges        | .NET Framework 4.8 | .NET Framework 4.8 | 1 |    610.31 ns |   1.523 ns |   1.189 ns | 0.2232 |     939 B |
| **StringBuilderLibraryChanges** | **.NET 6.0**           | **.NET 6.0**           | **2** | **18,409.80 ns** |  **21.800 ns** |  **20.391 ns** |      **-** |         **-** |
| StringLibraryChanges        | .NET 6.0           | .NET 6.0           | 2 |    350.67 ns |   1.796 ns |   1.680 ns | 0.0553 |     232 B |
| StringBuilderLibraryChanges | .NET 8.0           | .NET 8.0           | 2 | 18,822.06 ns | 158.914 ns | 140.873 ns |      - |         - |
| StringLibraryChanges        | .NET 8.0           | .NET 8.0           | 2 |     70.64 ns |   0.643 ns |   0.502 ns | 0.0554 |     232 B |
| StringBuilderLibraryChanges | .NET Framework 4.8 | .NET Framework 4.8 | 2 | 19,147.04 ns |  80.528 ns |  75.326 ns |      - |         - |
| StringLibraryChanges        | .NET Framework 4.8 | .NET Framework 4.8 | 2 |    612.46 ns |   2.013 ns |   1.784 ns | 0.2232 |     939 B |
| **StringBuilderLibraryChanges** | **.NET 6.0**           | **.NET 6.0**           | **3** | **45,985.87 ns** | **414.221 ns** | **345.893 ns** |      **-** |         **-** |
| StringLibraryChanges        | .NET 6.0           | .NET 6.0           | 3 |    346.60 ns |   1.459 ns |   1.293 ns | 0.0553 |     232 B |
| StringBuilderLibraryChanges | .NET 8.0           | .NET 8.0           | 3 | 46,760.99 ns | 297.780 ns | 263.974 ns |      - |         - |
| StringLibraryChanges        | .NET 8.0           | .NET 8.0           | 3 |     74.87 ns |   1.217 ns |   1.016 ns | 0.0554 |     232 B |
| StringBuilderLibraryChanges | .NET Framework 4.8 | .NET Framework 4.8 | 3 | 47,484.56 ns | 190.014 ns | 177.739 ns |      - |         - |
| StringLibraryChanges        | .NET Framework 4.8 | .NET Framework 4.8 | 3 |    610.30 ns |   1.271 ns |   1.061 ns | 0.2232 |     939 B |
