``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2006/21H2/November2021Update)
AMD Ryzen 5 3600, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.100-rc.1.22431.12
  [Host]   : .NET 7.0.0 (7.0.22.42610), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.0 (7.0.22.42610), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  

```
|      Method |      Mean |     Error |    StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------ |----------:|----------:|----------:|------:|--------:|----------:|------------:|
|        Linq | 89.175 μs | 1.1771 μs | 1.0435 μs | 12.54 |    0.19 | 123.31 KB |        2.10 |
|         For |  7.113 μs | 0.0491 μs | 0.0459 μs |  1.00 |    0.00 |  58.62 KB |        1.00 |
| TannerMagic |  2.526 μs | 0.0459 μs | 0.0451 μs |  0.36 |    0.01 |  58.62 KB |        1.00 |
