```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.205
  [Host]             : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET 6.0           : .NET 6.0.30 (6.0.3024.21525), X64 RyuJIT AVX2
  .NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256


```
| Method                  | Job                | Runtime            | Mean      | Error    | StdDev   | Median    | Gen0    | Gen1    | Gen2    | Allocated |
|------------------------ |------------------- |------------------- |----------:|---------:|---------:|----------:|--------:|--------:|--------:|----------:|
| GetBytesBenchBcl        | .NET 6.0           | .NET 6.0           |  74.79 μs | 1.287 μs | 1.004 μs |  74.67 μs | 11.8408 |       - |       - |  48.85 KB |
| GetBytesBenchLibrary    | .NET 6.0           | .NET 6.0           |  49.94 μs | 0.214 μs | 0.189 μs |  49.89 μs | 11.9019 |       - |       - |  48.85 KB |
| AppendLibrary           | .NET 6.0           | .NET 6.0           |  75.79 μs | 1.477 μs | 2.467 μs |  75.57 μs | 41.6260 | 41.6260 | 41.6260 | 130.41 KB |
| AppendLibraryLineBreaks | .NET 6.0           | .NET 6.0           |  79.71 μs | 1.566 μs | 2.941 μs |  81.01 μs | 43.4570 | 43.4570 | 43.4570 | 134.33 KB |
| GetBytesBenchBcl        | .NET 8.0           | .NET 8.0           |  85.22 μs | 0.581 μs | 0.543 μs |  85.03 μs | 11.8408 |       - |       - |  48.85 KB |
| GetBytesBenchLibrary    | .NET 8.0           | .NET 8.0           |  48.00 μs | 0.332 μs | 0.311 μs |  47.94 μs | 11.9019 |       - |       - |  48.85 KB |
| AppendLibrary           | .NET 8.0           | .NET 8.0           |  72.89 μs | 1.382 μs | 3.005 μs |  73.13 μs | 41.7480 | 41.7480 | 41.7480 | 130.91 KB |
| AppendLibraryLineBreaks | .NET 8.0           | .NET 8.0           |  81.61 μs | 2.341 μs | 6.902 μs |  82.63 μs | 43.4570 | 43.4570 | 43.4570 | 133.79 KB |
| GetBytesBenchBcl        | .NET Framework 4.8 | .NET Framework 4.8 | 497.41 μs | 4.149 μs | 4.075 μs | 496.34 μs | 11.7188 |       - |       - |  48.88 KB |
| GetBytesBenchLibrary    | .NET Framework 4.8 | .NET Framework 4.8 | 494.44 μs | 1.310 μs | 1.094 μs | 494.78 μs | 11.7188 |       - |       - |  48.98 KB |
| AppendLibrary           | .NET Framework 4.8 | .NET Framework 4.8 | 149.26 μs | 0.624 μs | 0.584 μs | 149.09 μs | 41.5039 | 41.5039 | 41.5039 | 130.57 KB |
| AppendLibraryLineBreaks | .NET Framework 4.8 | .NET Framework 4.8 | 158.74 μs | 0.930 μs | 0.870 μs | 158.65 μs | 43.4570 | 43.4570 | 43.4570 | 134.01 KB |
