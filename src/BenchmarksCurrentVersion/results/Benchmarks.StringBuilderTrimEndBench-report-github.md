```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.205
  [Host]             : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET 6.0           : .NET 6.0.30 (6.0.3024.21525), X64 RyuJIT AVX2
  .NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256


```
| Method         | Job                | Runtime            | Mean     | Error    | StdDev    | Median   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------- |------------------- |------------------- |---------:|---------:|----------:|---------:|------:|--------:|-------:|----------:|------------:|
| SbEmptyLibrary | .NET 6.0           | .NET 6.0           | 12.48 ns | 0.313 ns |  0.449 ns | 12.62 ns |  0.51 |    0.03 | 0.0249 |     104 B |        1.00 |
| Sb0Library     | .NET 6.0           | .NET 6.0           | 24.27 ns | 0.168 ns |  0.141 ns | 24.32 ns |  1.00 |    0.00 | 0.0249 |     104 B |        1.00 |
| Sb1Library     | .NET 6.0           | .NET 6.0           | 25.87 ns | 0.263 ns |  0.246 ns | 25.92 ns |  1.07 |    0.01 | 0.0249 |     104 B |        1.00 |
| Sb2Library     | .NET 6.0           | .NET 6.0           | 28.96 ns | 0.166 ns |  0.147 ns | 28.93 ns |  1.19 |    0.01 | 0.0249 |     104 B |        1.00 |
| Sb10Library    | .NET 6.0           | .NET 6.0           | 47.48 ns | 0.201 ns |  0.188 ns | 47.42 ns |  1.96 |    0.02 | 0.0249 |     104 B |        1.00 |
|                |                    |                    |          |          |           |          |       |         |        |           |             |
| SbEmptyLibrary | .NET 8.0           | .NET 8.0           | 11.87 ns | 0.132 ns |  0.124 ns | 11.86 ns |  0.57 |    0.01 | 0.0249 |     104 B |        1.00 |
| Sb0Library     | .NET 8.0           | .NET 8.0           | 20.75 ns | 0.047 ns |  0.040 ns | 20.73 ns |  1.00 |    0.00 | 0.0249 |     104 B |        1.00 |
| Sb1Library     | .NET 8.0           | .NET 8.0           | 30.96 ns | 3.605 ns | 10.630 ns | 23.04 ns |  1.31 |    0.39 | 0.0249 |     104 B |        1.00 |
| Sb2Library     | .NET 8.0           | .NET 8.0           | 24.54 ns | 0.075 ns |  0.067 ns | 24.52 ns |  1.18 |    0.00 | 0.0249 |     104 B |        1.00 |
| Sb10Library    | .NET 8.0           | .NET 8.0           | 38.45 ns | 0.829 ns |  1.598 ns | 38.62 ns |  1.79 |    0.08 | 0.0249 |     104 B |        1.00 |
|                |                    |                    |          |          |           |          |       |         |        |           |             |
| SbEmptyLibrary | .NET Framework 4.8 | .NET Framework 4.8 | 17.11 ns | 0.043 ns |  0.034 ns | 17.12 ns |  0.74 |    0.01 | 0.0249 |     104 B |        1.00 |
| Sb0Library     | .NET Framework 4.8 | .NET Framework 4.8 | 23.13 ns | 0.366 ns |  0.325 ns | 23.05 ns |  1.00 |    0.00 | 0.0249 |     104 B |        1.00 |
| Sb1Library     | .NET Framework 4.8 | .NET Framework 4.8 | 24.82 ns | 0.571 ns |  0.781 ns | 25.07 ns |  1.06 |    0.04 | 0.0249 |     104 B |        1.00 |
| Sb2Library     | .NET Framework 4.8 | .NET Framework 4.8 | 27.17 ns | 0.150 ns |  0.126 ns | 27.17 ns |  1.17 |    0.01 | 0.0249 |     104 B |        1.00 |
| Sb10Library    | .NET Framework 4.8 | .NET Framework 4.8 | 58.07 ns | 6.873 ns | 20.050 ns | 44.16 ns |  3.41 |    0.17 | 0.0249 |     104 B |        1.00 |
