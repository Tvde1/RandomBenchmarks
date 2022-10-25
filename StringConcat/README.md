``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.1098/21H2)
12th Gen Intel Core i7-1260P, 1 CPU, 16 logical and 12 physical cores
.NET SDK=7.0.100-rc.2.22477.23
  [Host]   : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  .NET 6.0 : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.0 (7.0.22.47203), X64 RyuJIT AVX2


```
|        Method |      Job |  Runtime |     Mean |    Error |   StdDev |   Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------- |--------- |--------- |---------:|---------:|---------:|---------:|------:|--------:|----------:|------------:|
| Interpolation | .NET 6.0 | .NET 6.0 | 124.2 ns |  7.10 ns | 20.82 ns | 116.5 ns |  1.00 |    0.00 |      72 B |        1.00 |
|        Format | .NET 6.0 | .NET 6.0 | 172.8 ns |  3.57 ns |  8.13 ns | 171.8 ns |  1.40 |    0.23 |     224 B |        3.11 |
|        Concat | .NET 6.0 | .NET 6.0 | 142.6 ns |  2.90 ns |  7.48 ns | 140.9 ns |  1.16 |    0.18 |     288 B |        4.00 |
| Interpolation | .NET 7.0 | .NET 7.0 | 126.6 ns |  6.43 ns | 18.95 ns | 120.7 ns |  1.05 |    0.22 |      72 B |        1.00 |
|        Format | .NET 7.0 | .NET 7.0 | 208.8 ns | 10.33 ns | 30.30 ns | 196.3 ns |  1.73 |    0.38 |     224 B |        3.11 |
|        Concat | .NET 7.0 | .NET 7.0 | 171.6 ns | 10.13 ns | 29.86 ns | 160.2 ns |  1.41 |    0.28 |     288 B |        4.00 |
