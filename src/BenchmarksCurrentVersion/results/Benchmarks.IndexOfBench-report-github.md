```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.205
  [Host]             : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET 6.0           : .NET 6.0.30 (6.0.3024.21525), X64 RyuJIT AVX2
  .NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256


```
| Method    | Job                | Runtime            | Mean      | Error     | StdDev    | Allocated |
|---------- |------------------- |------------------- |----------:|----------:|----------:|----------:|
| IndexOf50 | .NET 6.0           | .NET 6.0           | 23.949 ns | 0.4981 ns | 0.8459 ns |         - |
| IndexOf10 | .NET 6.0           | .NET 6.0           | 10.884 ns | 0.0607 ns | 0.0568 ns |         - |
| IndexOf50 | .NET 8.0           | .NET 8.0           | 15.495 ns | 0.0699 ns | 0.0654 ns |         - |
| IndexOf10 | .NET 8.0           | .NET 8.0           |  8.803 ns | 0.1390 ns | 0.1232 ns |         - |
| IndexOf50 | .NET Framework 4.8 | .NET Framework 4.8 | 89.139 ns | 0.6273 ns | 0.4898 ns |         - |
| IndexOf10 | .NET Framework 4.8 | .NET Framework 4.8 | 25.572 ns | 0.5446 ns | 0.8948 ns |         - |
