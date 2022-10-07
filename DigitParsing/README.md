``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2006/21H2/November2021Update)
AMD Ryzen 5 3600, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.100-rc.1.22431.12
  [Host]   : .NET 7.0.0 (7.0.22.42610), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.0 (7.0.22.42610), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  

```
|          Method |      Mean |     Error |    StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------- |----------:|----------:|----------:|------:|--------:|----------:|------------:|
|            Linq | 88.569 μs | 0.5220 μs | 0.4359 μs | 12.37 |    0.12 | 123.31 KB |        2.10 |
|             For |  7.158 μs | 0.0571 μs | 0.0506 μs |  1.00 |    0.00 |  58.62 KB |        1.00 |
| TannerMagic_128 |  2.548 μs | 0.0376 μs | 0.0352 μs |  0.36 |    0.01 |  58.62 KB |        1.00 |
| TannerMagic_256 |  2.288 μs | 0.0120 μs | 0.0094 μs |  0.32 |    0.00 |  58.62 KB |        1.00 |
