```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.205
  [Host]             : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET 6.0           : .NET 6.0.30 (6.0.3024.21525), X64 RyuJIT AVX2
  .NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256


```
| Method                  | Job                | Runtime            | Mean      | Error    | StdDev   | Gen0    | Gen1    | Gen2    | Allocated |
|------------------------ |------------------- |------------------- |----------:|---------:|---------:|--------:|--------:|--------:|----------:|
| GetBytesBenchBcl        | .NET 6.0           | .NET 6.0           |  77.04 μs | 0.544 μs | 0.425 μs | 11.8408 |       - |       - |  48.85 KB |
| GetBytesBenchLibrary    | .NET 6.0           | .NET 6.0           |  51.16 μs | 0.432 μs | 0.360 μs | 11.9019 |       - |       - |  48.85 KB |
| AppendLibrary           | .NET 6.0           | .NET 6.0           |  78.09 μs | 0.432 μs | 0.361 μs | 41.6260 | 41.6260 | 41.6260 | 130.36 KB |
| AppendLibraryLineBreaks | .NET 6.0           | .NET 6.0           |  81.31 μs | 0.653 μs | 0.579 μs | 43.4570 | 43.4570 | 43.4570 | 133.79 KB |
| GetBytesBenchBcl        | .NET 8.0           | .NET 8.0           |  84.27 μs | 0.378 μs | 0.335 μs | 11.8408 |       - |       - |  48.85 KB |
| GetBytesBenchLibrary    | .NET 8.0           | .NET 8.0           |  47.95 μs | 0.140 μs | 0.124 μs | 11.9019 |       - |       - |  48.85 KB |
| AppendLibrary           | .NET 8.0           | .NET 8.0           |  76.96 μs | 0.521 μs | 0.487 μs | 41.6260 | 41.6260 | 41.6260 | 130.36 KB |
| AppendLibraryLineBreaks | .NET 8.0           | .NET 8.0           |  73.52 μs | 0.389 μs | 0.345 μs | 43.4570 | 43.4570 | 43.4570 | 133.79 KB |
| GetBytesBenchBcl        | .NET Framework 4.8 | .NET Framework 4.8 | 490.23 μs | 3.437 μs | 3.215 μs | 11.7188 |       - |       - |  48.88 KB |
| GetBytesBenchLibrary    | .NET Framework 4.8 | .NET Framework 4.8 | 499.65 μs | 2.577 μs | 2.284 μs | 11.7188 |       - |       - |  48.98 KB |
| AppendLibrary           | .NET Framework 4.8 | .NET Framework 4.8 | 148.47 μs | 0.868 μs | 0.812 μs | 41.5039 | 41.5039 | 41.5039 | 130.57 KB |
| AppendLibraryLineBreaks | .NET Framework 4.8 | .NET Framework 4.8 | 157.48 μs | 0.746 μs | 0.698 μs | 43.4570 | 43.4570 | 43.4570 | 134.01 KB |
