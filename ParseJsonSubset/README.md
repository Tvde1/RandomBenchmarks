``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.978/21H2)
12th Gen Intel Core i7-1260P, 1 CPU, 16 logical and 12 physical cores
.NET SDK=7.0.100-rc.1.22431.12
  [Host]   : .NET 7.0.0 (7.0.22.42610), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.0 (7.0.22.42610), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  

```
|              Method |                Input |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------------- |--------------------- |------------:|----------:|----------:|------------:|------:|--------:|----------:|------------:|
| **WithoutPropertyName** | **{&quot;fi(...): 2} [7157]** | **21,575.3 ns** | **426.65 ns** | **584.01 ns** | **21,711.3 ns** |  **1.00** |    **0.00** |      **24 B** |        **1.00** |
|    WithPropertyName | {&quot;fi(...): 2} [7157] | 21,966.5 ns | 424.52 ns | 552.00 ns | 22,138.9 ns |  1.02 |    0.04 |      24 B |        1.00 |
|                     |                      |             |           |           |             |       |         |           |             |
| **WithoutPropertyName** | **{&quot;fir(...)&quot;: 2} [34]** |    **344.3 ns** |  **12.31 ns** |  **36.30 ns** |    **333.0 ns** |  **1.00** |    **0.00** |      **24 B** |        **1.00** |
|    WithPropertyName | {&quot;fir(...)&quot;: 2} [34] |    393.9 ns |  13.45 ns |  39.64 ns |    386.8 ns |  1.15 |    0.16 |      24 B |        1.00 |
