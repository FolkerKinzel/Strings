```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.205
  [Host]             : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET 6.0           : .NET 6.0.30 (6.0.3024.21525), X64 RyuJIT AVX2
  .NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256


```
| Method                 | Job                | Runtime            | Mean      | Error    | StdDev   | Allocated |
|----------------------- |------------------- |------------------- |----------:|---------:|---------:|----------:|
| ContainsNewLineLibrary | .NET 6.0           | .NET 6.0           | 478.22 ns | 4.346 ns | 3.393 ns |         - |
| ContainsNewLineLibrary | .NET 8.0           | .NET 8.0           |  14.67 ns | 0.066 ns | 0.062 ns |         - |
| ContainsNewLineLibrary | .NET Framework 4.8 | .NET Framework 4.8 | 388.35 ns | 0.701 ns | 0.655 ns |         - |
