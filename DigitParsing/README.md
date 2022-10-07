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
|        Linq | 89.175 μs | 0.5447 μs | 0.5095 μs | 12.45 |    0.08 | 123.31 KB |        2.10 |
|         For |  7.157 μs | 0.0386 μs | 0.0301 μs |  1.00 |    0.00 |  58.62 KB |        1.00 |
| TannerMagic |  2.526 μs | 0.0289 μs | 0.0242 μs |  0.35 |    0.00 |  58.62 KB |        1.00 |
