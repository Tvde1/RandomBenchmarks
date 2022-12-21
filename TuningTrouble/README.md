``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.963)
12th Gen Intel Core i7-1260P, 1 CPU, 16 logical and 12 physical cores
.NET SDK=7.0.100
  [Host]   : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  

```
|                             Method | MarkerLength |       Mean |      Error |     StdDev |     Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------------------------------- |------------- |-----------:|-----------:|-----------:|-----------:|------:|--------:|----------:|------------:|
|                       **UsingHashSet** |            **4** |  **82.223 μs** |  **1.6154 μs** |  **3.2998 μs** |  **81.112 μs** | **22.24** |    **0.85** |  **239360 B** |          **NA** |
|                          UsingSpan |            4 |   3.885 μs |  0.0694 μs |  0.0616 μs |   3.890 μs |  1.00 |    0.00 |         - |          NA |
|                         UsingJumps |            4 |   2.711 μs |  0.0538 μs |  0.0772 μs |   2.692 μs |  0.70 |    0.02 |         - |          NA |
|                  UsingJumpsReverse |            4 |   1.784 μs |  0.0342 μs |  0.0320 μs |   1.780 μs |  0.46 |    0.01 |         - |          NA |
|                                    |              |            |            |            |            |       |         |           |             |
|                       **UsingHashSet** |           **14** | **836.168 μs** | **16.4871 μs** | **27.9964 μs** | **834.988 μs** | **42.80** |    **0.99** | **1582832 B** |          **NA** |
|                          UsingSpan |           14 |  19.255 μs |  0.2163 μs |  0.2023 μs |  19.252 μs |  1.00 |    0.00 |         - |          NA |
|                         UsingJumps |           14 |   5.270 μs |  0.1041 μs |  0.1022 μs |   5.257 μs |  0.27 |    0.01 |         - |          NA |
|                  UsingJumpsReverse |           14 |   1.845 μs |  0.1820 μs |  0.5365 μs |   1.538 μs |  0.08 |    0.01 |         - |          NA |
