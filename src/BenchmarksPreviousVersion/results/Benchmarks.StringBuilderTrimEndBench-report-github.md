```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.205
  [Host]             : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET 6.0           : .NET 6.0.30 (6.0.3024.21525), X64 RyuJIT AVX2
  .NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256


```
| Method         | Job                | Runtime            | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------- |------------------- |------------------- |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| SbEmptyLibrary | .NET 6.0           | .NET 6.0           | 12.95 ns | 0.319 ns | 0.507 ns |  0.52 |    0.03 | 0.0249 |     104 B |        1.00 |
| Sb0Library     | .NET 6.0           | .NET 6.0           | 24.19 ns | 0.399 ns | 0.374 ns |  1.00 |    0.00 | 0.0249 |     104 B |        1.00 |
| Sb1Library     | .NET 6.0           | .NET 6.0           | 27.25 ns | 0.222 ns | 0.207 ns |  1.13 |    0.02 | 0.0249 |     104 B |        1.00 |
| Sb2Library     | .NET 6.0           | .NET 6.0           | 29.53 ns | 0.290 ns | 0.257 ns |  1.22 |    0.03 | 0.0249 |     104 B |        1.00 |
| Sb10Library    | .NET 6.0           | .NET 6.0           | 48.22 ns | 0.370 ns | 0.346 ns |  1.99 |    0.03 | 0.0249 |     104 B |        1.00 |
|                |                    |                    |          |          |          |       |         |        |           |             |
| SbEmptyLibrary | .NET 8.0           | .NET 8.0           | 11.92 ns | 0.104 ns | 0.092 ns |  0.56 |    0.00 | 0.0249 |     104 B |        1.00 |
| Sb0Library     | .NET 8.0           | .NET 8.0           | 21.27 ns | 0.109 ns | 0.085 ns |  1.00 |    0.00 | 0.0249 |     104 B |        1.00 |
| Sb1Library     | .NET 8.0           | .NET 8.0           | 22.56 ns | 0.131 ns | 0.116 ns |  1.06 |    0.01 | 0.0249 |     104 B |        1.00 |
| Sb2Library     | .NET 8.0           | .NET 8.0           | 25.04 ns | 0.484 ns | 0.429 ns |  1.17 |    0.02 | 0.0249 |     104 B |        1.00 |
| Sb10Library    | .NET 8.0           | .NET 8.0           | 64.53 ns | 1.381 ns | 3.308 ns |  3.06 |    0.09 | 0.0248 |     104 B |        1.00 |
|                |                    |                    |          |          |          |       |         |        |           |             |
| SbEmptyLibrary | .NET Framework 4.8 | .NET Framework 4.8 | 17.13 ns | 0.191 ns | 0.170 ns |  0.74 |    0.01 | 0.0249 |     104 B |        1.00 |
| Sb0Library     | .NET Framework 4.8 | .NET Framework 4.8 | 23.12 ns | 0.080 ns | 0.071 ns |  1.00 |    0.00 | 0.0249 |     104 B |        1.00 |
| Sb1Library     | .NET Framework 4.8 | .NET Framework 4.8 | 25.26 ns | 0.092 ns | 0.086 ns |  1.09 |    0.00 | 0.0249 |     104 B |        1.00 |
| Sb2Library     | .NET Framework 4.8 | .NET Framework 4.8 | 27.36 ns | 0.207 ns | 0.193 ns |  1.18 |    0.01 | 0.0249 |     104 B |        1.00 |
| Sb10Library    | .NET Framework 4.8 | .NET Framework 4.8 | 45.05 ns | 0.384 ns | 0.359 ns |  1.95 |    0.02 | 0.0249 |     104 B |        1.00 |
