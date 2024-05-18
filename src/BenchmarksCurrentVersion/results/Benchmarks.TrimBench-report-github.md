```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.205
  [Host]             : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET 6.0           : .NET 6.0.30 (6.0.3024.21525), X64 RyuJIT AVX2
  .NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256


```
| Method                | Job                | Runtime            | S         | Mean       | Error     | StdDev    | Median     | Allocated |
|---------------------- |------------------- |------------------- |---------- |-----------:|----------:|----------:|-----------:|----------:|
| **TrimEndBcl**            | **.NET 6.0**           | **.NET 6.0**           | ****          |   **4.527 ns** | **0.1148 ns** | **0.1018 ns** |   **4.511 ns** |         **-** |
| TrimEndSearchValues   | .NET 6.0           | .NET 6.0           |           |   2.741 ns | 0.0557 ns | 0.0493 ns |   2.737 ns |         - |
| TrimStartBcl          | .NET 6.0           | .NET 6.0           |           |   4.006 ns | 0.0765 ns | 0.0785 ns |   3.977 ns |         - |
| TrimStartSearchValues | .NET 6.0           | .NET 6.0           |           |   4.314 ns | 0.0339 ns | 0.0317 ns |   4.314 ns |         - |
| TrimBcl               | .NET 6.0           | .NET 6.0           |           |   9.991 ns | 0.0958 ns | 0.0800 ns |   9.975 ns |         - |
| TrimSearchValues      | .NET 6.0           | .NET 6.0           |           |  16.647 ns | 0.0387 ns | 0.0323 ns |  16.649 ns |         - |
| TrimEndBcl            | .NET 8.0           | .NET 8.0           |           |   4.096 ns | 0.0206 ns | 0.0193 ns |   4.101 ns |         - |
| TrimEndSearchValues   | .NET 8.0           | .NET 8.0           |           |   2.743 ns | 0.0193 ns | 0.0171 ns |   2.743 ns |         - |
| TrimStartBcl          | .NET 8.0           | .NET 8.0           |           |   3.932 ns | 0.0464 ns | 0.0411 ns |   3.924 ns |         - |
| TrimStartSearchValues | .NET 8.0           | .NET 8.0           |           |   4.273 ns | 0.0537 ns | 0.0476 ns |   4.286 ns |         - |
| TrimBcl               | .NET 8.0           | .NET 8.0           |           |  12.183 ns | 0.1472 ns | 0.1229 ns |  12.178 ns |         - |
| TrimSearchValues      | .NET 8.0           | .NET 8.0           |           |   8.751 ns | 0.2039 ns | 0.1702 ns |   8.747 ns |         - |
| TrimEndBcl            | .NET Framework 4.8 | .NET Framework 4.8 |           |  33.762 ns | 0.9914 ns | 2.8284 ns |  34.128 ns |         - |
| TrimEndSearchValues   | .NET Framework 4.8 | .NET Framework 4.8 |           |  26.565 ns | 0.4368 ns | 0.7298 ns |  26.417 ns |         - |
| TrimStartBcl          | .NET Framework 4.8 | .NET Framework 4.8 |           |  21.401 ns | 0.0474 ns | 0.0420 ns |  21.399 ns |         - |
| TrimStartSearchValues | .NET Framework 4.8 | .NET Framework 4.8 |           |  27.398 ns | 0.1321 ns | 0.1103 ns |  27.352 ns |         - |
| TrimBcl               | .NET Framework 4.8 | .NET Framework 4.8 |           |  40.638 ns | 0.5377 ns | 0.4490 ns |  40.502 ns |         - |
| TrimSearchValues      | .NET Framework 4.8 | .NET Framework 4.8 |           |  60.856 ns | 0.1302 ns | 0.1217 ns |  60.856 ns |         - |
| **TrimEndBcl**            | **.NET 6.0**           | **.NET 6.0**           | ** **         |   **4.391 ns** | **0.0190 ns** | **0.0169 ns** |   **4.388 ns** |         **-** |
| TrimEndSearchValues   | .NET 6.0           | .NET 6.0           |           |   6.090 ns | 0.0440 ns | 0.0344 ns |   6.089 ns |         - |
| TrimStartBcl          | .NET 6.0           | .NET 6.0           |           |   4.275 ns | 0.0168 ns | 0.0149 ns |   4.276 ns |         - |
| TrimStartSearchValues | .NET 6.0           | .NET 6.0           |           |   6.802 ns | 0.0397 ns | 0.0372 ns |   6.802 ns |         - |
| TrimBcl               | .NET 6.0           | .NET 6.0           |           |  12.557 ns | 0.0554 ns | 0.0433 ns |  12.544 ns |         - |
| TrimSearchValues      | .NET 6.0           | .NET 6.0           |           |  39.022 ns | 1.3097 ns | 3.7998 ns |  38.513 ns |         - |
| TrimEndBcl            | .NET 8.0           | .NET 8.0           |           |   6.265 ns | 0.1480 ns | 0.1312 ns |   6.240 ns |         - |
| TrimEndSearchValues   | .NET 8.0           | .NET 8.0           |           |   4.858 ns | 0.1415 ns | 0.1629 ns |   4.805 ns |         - |
| TrimStartBcl          | .NET 8.0           | .NET 8.0           |           |   5.175 ns | 0.1481 ns | 0.1455 ns |   5.111 ns |         - |
| TrimStartSearchValues | .NET 8.0           | .NET 8.0           |           |   7.475 ns | 0.1215 ns | 0.1015 ns |   7.486 ns |         - |
| TrimBcl               | .NET 8.0           | .NET 8.0           |           |  19.670 ns | 0.4291 ns | 0.4407 ns |  19.649 ns |         - |
| TrimSearchValues      | .NET 8.0           | .NET 8.0           |           |  11.738 ns | 0.7835 ns | 2.3100 ns |  10.193 ns |         - |
| TrimEndBcl            | .NET Framework 4.8 | .NET Framework 4.8 |           |  22.565 ns | 0.0389 ns | 0.0363 ns |  22.576 ns |         - |
| TrimEndSearchValues   | .NET Framework 4.8 | .NET Framework 4.8 |           |  32.984 ns | 0.1593 ns | 0.1412 ns |  32.944 ns |         - |
| TrimStartBcl          | .NET Framework 4.8 | .NET Framework 4.8 |           |  24.685 ns | 0.0687 ns | 0.0642 ns |  24.718 ns |         - |
| TrimStartSearchValues | .NET Framework 4.8 | .NET Framework 4.8 |           |  33.427 ns | 0.1107 ns | 0.1036 ns |  33.460 ns |         - |
| TrimBcl               | .NET Framework 4.8 | .NET Framework 4.8 |           |  46.469 ns | 0.1304 ns | 0.1089 ns |  46.477 ns |         - |
| TrimSearchValues      | .NET Framework 4.8 | .NET Framework 4.8 |           |  72.452 ns | 0.1779 ns | 0.1664 ns |  72.510 ns |         - |
| **TrimEndBcl**            | **.NET 6.0**           | **.NET 6.0**           | **   &quot;&quot;&#39;&#39; &quot;** |  **16.193 ns** | **0.1465 ns** | **0.1299 ns** |  **16.248 ns** |         **-** |
| TrimEndSearchValues   | .NET 6.0           | .NET 6.0           |    &quot;&quot;&#39;&#39; &quot; |  31.274 ns | 0.1950 ns | 0.1729 ns |  31.251 ns |         - |
| TrimStartBcl          | .NET 6.0           | .NET 6.0           |    &quot;&quot;&#39;&#39; &quot; |  17.787 ns | 0.1379 ns | 0.1152 ns |  17.847 ns |         - |
| TrimStartSearchValues | .NET 6.0           | .NET 6.0           |    &quot;&quot;&#39;&#39; &quot; |  32.385 ns | 0.5514 ns | 0.5158 ns |  32.261 ns |         - |
| TrimBcl               | .NET 6.0           | .NET 6.0           |    &quot;&quot;&#39;&#39; &quot; |  39.278 ns | 0.3874 ns | 0.3623 ns |  39.387 ns |         - |
| TrimSearchValues      | .NET 6.0           | .NET 6.0           |    &quot;&quot;&#39;&#39; &quot; |  77.905 ns | 0.4363 ns | 0.3406 ns |  77.895 ns |         - |
| TrimEndBcl            | .NET 8.0           | .NET 8.0           |    &quot;&quot;&#39;&#39; &quot; |  13.119 ns | 0.0986 ns | 0.0922 ns |  13.160 ns |         - |
| TrimEndSearchValues   | .NET 8.0           | .NET 8.0           |    &quot;&quot;&#39;&#39; &quot; |   5.763 ns | 0.0452 ns | 0.0423 ns |   5.778 ns |         - |
| TrimStartBcl          | .NET 8.0           | .NET 8.0           |    &quot;&quot;&#39;&#39; &quot; |  14.349 ns | 0.0996 ns | 0.0932 ns |  14.344 ns |         - |
| TrimStartSearchValues | .NET 8.0           | .NET 8.0           |    &quot;&quot;&#39;&#39; &quot; |   7.493 ns | 0.0266 ns | 0.0222 ns |   7.497 ns |         - |
| TrimBcl               | .NET 8.0           | .NET 8.0           |    &quot;&quot;&#39;&#39; &quot; |  41.584 ns | 0.1479 ns | 0.1311 ns |  41.628 ns |         - |
| TrimSearchValues      | .NET 8.0           | .NET 8.0           |    &quot;&quot;&#39;&#39; &quot; |  13.470 ns | 0.0694 ns | 0.0649 ns |  13.508 ns |         - |
| TrimEndBcl            | .NET Framework 4.8 | .NET Framework 4.8 |    &quot;&quot;&#39;&#39; &quot; |  49.417 ns | 0.2172 ns | 0.2032 ns |  49.417 ns |         - |
| TrimEndSearchValues   | .NET Framework 4.8 | .NET Framework 4.8 |    &quot;&quot;&#39;&#39; &quot; |  76.277 ns | 0.2046 ns | 0.1597 ns |  76.297 ns |         - |
| TrimStartBcl          | .NET Framework 4.8 | .NET Framework 4.8 |    &quot;&quot;&#39;&#39; &quot; |  50.838 ns | 0.2189 ns | 0.1941 ns |  50.822 ns |         - |
| TrimStartSearchValues | .NET Framework 4.8 | .NET Framework 4.8 |    &quot;&quot;&#39;&#39; &quot; |  84.061 ns | 0.3853 ns | 0.3218 ns |  84.141 ns |         - |
| TrimBcl               | .NET Framework 4.8 | .NET Framework 4.8 |    &quot;&quot;&#39;&#39; &quot; |  99.698 ns | 0.3783 ns | 0.2954 ns |  99.721 ns |         - |
| TrimSearchValues      | .NET Framework 4.8 | .NET Framework 4.8 |    &quot;&quot;&#39;&#39; &quot; | 155.607 ns | 0.5556 ns | 0.5197 ns | 155.516 ns |         - |
