``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.1219/21H2)
12th Gen Intel Core i7-1260P, 1 CPU, 16 logical and 12 physical cores
.NET SDK=7.0.100
  [Host]   : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  .NET 6.0 : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|          Method |      Job |  Runtime |     Mean |    Error |   StdDev | Allocated |
|---------------- |--------- |--------- |---------:|---------:|---------:|----------:|
|        ParseInt | .NET 6.0 | .NET 6.0 | 777.1 ns |  7.15 ns |  5.58 ns |         - |
|        TryParse | .NET 6.0 | .NET 6.0 | 832.6 ns | 15.86 ns | 14.84 ns |         - |
|     CustomParse | .NET 6.0 | .NET 6.0 | 258.0 ns |  3.20 ns |  2.84 ns |         - |
| CustomParseSpan | .NET 6.0 | .NET 6.0 | 258.7 ns |  4.71 ns |  4.41 ns |         - |
|        ParseInt | .NET 7.0 | .NET 7.0 | 834.7 ns | 14.92 ns | 13.95 ns |         - |
|        TryParse | .NET 7.0 | .NET 7.0 | 836.1 ns | 16.11 ns | 17.91 ns |         - |
|     CustomParse | .NET 7.0 | .NET 7.0 | 287.8 ns |  5.35 ns |  4.47 ns |         - |
| CustomParseSpan | .NET 7.0 | .NET 7.0 | 251.7 ns |  3.17 ns |  3.39 ns |         - |
