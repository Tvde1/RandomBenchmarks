``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.819)
12th Gen Intel Core i7-1260P, 1 CPU, 16 logical and 12 physical cores
.NET SDK=7.0.100
  [Host]   : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  

```
|       Method | MarkerLength |         Mean |      Error |      StdDev |       Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------- |------------- |-------------:|-----------:|------------:|-------------:|------:|--------:|----------:|------------:|
| **UsingHashSet** |            **4** |   **111.820 μs** |  **5.2945 μs** |  **14.8464 μs** |   **106.075 μs** | **19.90** |    **4.26** |  **239360 B** |          **NA** |
|    UsingSpan |            4 |     5.748 μs |  0.3464 μs |   1.0214 μs |     5.586 μs |  1.00 |    0.00 |         - |          NA |
|   UsingJumps |            4 |     3.684 μs |  0.1728 μs |   0.4985 μs |     3.552 μs |  0.66 |    0.16 |         - |          NA |
|              |              |              |            |             |              |       |         |           |             |
| **UsingHashSet** |           **14** | **1,334.523 μs** | **64.9065 μs** | **191.3782 μs** | **1,341.539 μs** | **46.72** |   **13.95** | **1582833 B** |          **NA** |
|    UsingSpan |           14 |    30.395 μs |  2.4362 μs |   7.1833 μs |    30.150 μs |  1.00 |    0.00 |         - |          NA |
|   UsingJumps |           14 |     6.628 μs |  0.2298 μs |   0.6405 μs |     6.443 μs |  0.23 |    0.06 |         - |          NA |
