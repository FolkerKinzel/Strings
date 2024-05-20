```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.205
  [Host]             : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET 6.0           : .NET 6.0.30 (6.0.3024.21525), X64 RyuJIT AVX2
  .NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256


```
| Method                  | Job                | Runtime            | Mean      | Error    | StdDev    | Median    | Gen0    | Gen1    | Gen2    | Allocated |
|------------------------ |------------------- |------------------- |----------:|---------:|----------:|----------:|--------:|--------:|--------:|----------:|
| GetBytesBenchBcl        | .NET 6.0           | .NET 6.0           |  82.71 μs | 1.642 μs |  2.789 μs |  84.00 μs | 11.8408 |       - |       - |  48.85 KB |
| GetBytesBenchLibrary    | .NET 6.0           | .NET 6.0           |  50.08 μs | 0.250 μs |  0.234 μs |  50.12 μs | 11.9019 |       - |       - |  48.85 KB |
| AppendLibrary           | .NET 6.0           | .NET 6.0           | 163.76 μs | 0.603 μs |  0.564 μs | 163.82 μs | 41.5039 | 41.5039 | 41.5039 | 130.35 KB |
| AppendLibraryLineBreaks | .NET 6.0           | .NET 6.0           | 169.56 μs | 1.185 μs |  1.108 μs | 169.65 μs | 43.4570 | 43.4570 | 43.4570 | 133.78 KB |
| GetBytesBenchBcl        | .NET 8.0           | .NET 8.0           |  84.27 μs | 0.326 μs |  0.305 μs |  84.19 μs | 11.8408 |       - |       - |  48.85 KB |
| GetBytesBenchLibrary    | .NET 8.0           | .NET 8.0           |  48.06 μs | 0.171 μs |  0.160 μs |  48.09 μs | 11.9019 |       - |       - |  48.85 KB |
| AppendLibrary           | .NET 8.0           | .NET 8.0           | 147.93 μs | 1.253 μs |  1.111 μs | 148.09 μs | 41.5039 | 41.5039 | 41.5039 | 130.35 KB |
| AppendLibraryLineBreaks | .NET 8.0           | .NET 8.0           | 152.73 μs | 0.826 μs |  0.733 μs | 152.68 μs | 43.4570 | 43.4570 | 43.4570 | 133.78 KB |
| GetBytesBenchBcl        | .NET Framework 4.8 | .NET Framework 4.8 | 497.61 μs | 0.999 μs |  0.780 μs | 497.61 μs | 11.7188 |       - |       - |  48.88 KB |
| GetBytesBenchLibrary    | .NET Framework 4.8 | .NET Framework 4.8 | 495.18 μs | 1.205 μs |  1.127 μs | 495.39 μs | 11.7188 |       - |       - |  48.98 KB |
| AppendLibrary           | .NET Framework 4.8 | .NET Framework 4.8 | 302.93 μs | 7.820 μs | 22.810 μs | 308.05 μs | 41.5039 | 41.5039 | 41.5039 | 130.57 KB |
| AppendLibraryLineBreaks | .NET Framework 4.8 | .NET Framework 4.8 | 287.88 μs | 2.368 μs |  1.977 μs | 287.81 μs | 43.4570 | 43.4570 | 43.4570 | 134.02 KB |
