```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.205
  [Host]             : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET 6.0           : .NET 6.0.30 (6.0.3024.21525), X64 RyuJIT AVX2
  .NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256


```
| Method                  | Job                | Runtime            | Mean     | Error    | StdDev    | Median   | Gen0   | Gen1   | Allocated |
|------------------------ |------------------- |------------------- |---------:|---------:|----------:|---------:|-------:|-------:|----------:|
| ToBytesBench            | .NET 6.0           | .NET 6.0           | 16.29 μs | 0.040 μs |  0.033 μs | 16.29 μs | 2.3804 |      - |   9.79 KB |
| AppendLibrary           | .NET 6.0           | .NET 6.0           | 21.79 μs | 0.160 μs |  0.149 μs | 21.72 μs | 6.3477 |      - |  26.17 KB |
| AppendBcl               | .NET 6.0           | .NET 6.0           | 23.95 μs | 0.068 μs |  0.060 μs | 23.96 μs | 6.3477 |      - |  26.17 KB |
| AppendLibraryLineBreaks | .NET 6.0           | .NET 6.0           | 22.57 μs | 0.176 μs |  0.147 μs | 22.59 μs | 6.5308 |      - |  26.86 KB |
| AppendBclLineBreaks     | .NET 6.0           | .NET 6.0           | 24.10 μs | 0.056 μs |  0.052 μs | 24.08 μs | 6.5308 |      - |  26.86 KB |
| ToBytesBench            | .NET 8.0           | .NET 8.0           | 17.00 μs | 0.073 μs |  0.065 μs | 16.98 μs | 2.3804 |      - |   9.79 KB |
| AppendLibrary           | .NET 8.0           | .NET 8.0           | 18.65 μs | 0.190 μs |  0.169 μs | 18.57 μs | 6.3477 |      - |  26.17 KB |
| AppendBcl               | .NET 8.0           | .NET 8.0           | 20.27 μs | 0.065 μs |  0.061 μs | 20.29 μs | 6.3477 |      - |  26.17 KB |
| AppendLibraryLineBreaks | .NET 8.0           | .NET 8.0           | 19.38 μs | 0.056 μs |  0.044 μs | 19.38 μs | 6.5308 |      - |  26.86 KB |
| AppendBclLineBreaks     | .NET 8.0           | .NET 8.0           | 21.38 μs | 0.238 μs |  0.198 μs | 21.33 μs | 6.5308 |      - |  26.86 KB |
| ToBytesBench            | .NET Framework 4.8 | .NET Framework 4.8 | 92.68 μs | 0.593 μs |  0.555 μs | 92.63 μs | 2.3193 |      - |   9.81 KB |
| AppendLibrary           | .NET Framework 4.8 | .NET Framework 4.8 | 67.48 μs | 3.621 μs | 10.271 μs | 68.75 μs | 6.3477 |      - |   26.2 KB |
| AppendBcl               | .NET Framework 4.8 | .NET Framework 4.8 | 66.63 μs | 4.759 μs | 14.031 μs | 72.64 μs | 6.3477 |      - |   26.2 KB |
| AppendLibraryLineBreaks | .NET Framework 4.8 | .NET Framework 4.8 | 46.25 μs | 0.174 μs |  0.154 μs | 46.22 μs | 6.5308 |      - |  26.89 KB |
| AppendBclLineBreaks     | .NET Framework 4.8 | .NET Framework 4.8 | 45.41 μs | 0.246 μs |  0.218 μs | 45.40 μs | 6.5308 | 0.5493 |  26.89 KB |
