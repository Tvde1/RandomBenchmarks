``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.1098/21H2)
12th Gen Intel Core i7-1260P, 1 CPU, 16 logical and 12 physical cores
.NET SDK=7.0.100-rc.2.22477.23
  [Host]   : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  .NET 6.0 : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.0 (7.0.22.47203), X64 RyuJIT AVX2


```
|      Method |      Job |  Runtime |                Input |      Mean |    Error |    StdDev |    Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------ |--------- |--------- |--------------------- |----------:|---------:|----------:|----------:|------:|--------:|----------:|------------:|
| **StringSplit** | **.NET 6.0** | **.NET 6.0** | **CN=00(...)10910 [27]** | **132.69 ns** | **3.023 ns** |  **8.327 ns** | **130.77 ns** |  **1.59** |    **0.10** |     **264 B** |        **1.94** |
|      String | .NET 6.0 | .NET 6.0 | CN=00(...)10910 [27] |  83.65 ns | 1.424 ns |  3.547 ns |  83.00 ns |  1.00 |    0.00 |     136 B |        1.00 |
|        Span | .NET 6.0 | .NET 6.0 | CN=00(...)10910 [27] |  65.37 ns | 3.240 ns |  9.552 ns |  67.26 ns |  0.79 |    0.12 |         - |        0.00 |
| StringSplit | .NET 7.0 | .NET 7.0 | CN=00(...)10910 [27] | 149.58 ns | 7.394 ns | 21.800 ns | 141.72 ns |  1.79 |    0.28 |     264 B |        1.94 |
|      String | .NET 7.0 | .NET 7.0 | CN=00(...)10910 [27] |  98.77 ns | 4.852 ns | 14.306 ns | 107.80 ns |  1.14 |    0.18 |     136 B |        1.00 |
|        Span | .NET 7.0 | .NET 7.0 | CN=00(...)10910 [27] |  67.26 ns | 0.767 ns |  0.640 ns |  67.12 ns |  0.81 |    0.04 |         - |        0.00 |
|             |          |          |                      |           |          |           |           |       |         |           |             |
| **StringSplit** | **.NET 6.0** | **.NET 6.0** | **CN=12(...)90910 [27]** | **201.67 ns** | **2.860 ns** |  **2.676 ns** | **201.43 ns** |  **1.69** |    **0.23** |     **264 B** |        **1.94** |
|      String | .NET 6.0 | .NET 6.0 | CN=12(...)90910 [27] | 103.10 ns | 5.432 ns | 16.017 ns |  94.83 ns |  1.00 |    0.00 |     136 B |        1.00 |
|        Span | .NET 6.0 | .NET 6.0 | CN=12(...)90910 [27] |  56.66 ns | 1.118 ns |  2.233 ns |  56.35 ns |  0.54 |    0.08 |         - |        0.00 |
| StringSplit | .NET 7.0 | .NET 7.0 | CN=12(...)90910 [27] | 144.95 ns | 6.313 ns | 18.613 ns | 135.85 ns |  1.43 |    0.23 |     264 B |        1.94 |
|      String | .NET 7.0 | .NET 7.0 | CN=12(...)90910 [27] |  83.78 ns | 1.702 ns |  3.156 ns |  83.39 ns |  0.80 |    0.13 |     136 B |        1.00 |
|        Span | .NET 7.0 | .NET 7.0 | CN=12(...)90910 [27] |  54.02 ns | 1.081 ns |  2.886 ns |  53.11 ns |  0.53 |    0.08 |         - |        0.00 |