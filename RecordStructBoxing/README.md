``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.1098/21H2)
12th Gen Intel Core i7-1260P, 1 CPU, 16 logical and 12 physical cores
.NET SDK=7.0.100-rc.2.22477.23
  [Host]   : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  .NET 6.0 : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.0 (7.0.22.47203), X64 RyuJIT AVX2


```
|                     Method |      Job |  Runtime |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------- |--------- |--------- |----------:|----------:|----------:|----------:|------:|--------:|----------:|------------:|
| ReadonlyRecordStructBoxing | .NET 6.0 | .NET 6.0 | 17.128 ns | 1.4912 ns | 4.3967 ns | 17.360 ns |  1.00 |    0.00 |     104 B |        1.00 |
| ReadonlyRecordStructBoxing | .NET 7.0 | .NET 7.0 | 17.283 ns | 1.4070 ns | 4.1484 ns | 16.116 ns |  1.09 |    0.40 |     104 B |        1.00 |
|                            |          |          |           |           |           |           |       |         |           |             |
|         RecordStructBoxing | .NET 6.0 | .NET 6.0 | 18.233 ns | 1.3666 ns | 4.0294 ns | 18.090 ns |  1.00 |    0.00 |     104 B |        1.00 |
|         RecordStructBoxing | .NET 7.0 | .NET 7.0 | 18.009 ns | 1.4994 ns | 4.3738 ns | 17.522 ns |  1.06 |    0.40 |     104 B |        1.00 |
|                            |          |          |           |           |           |           |       |         |           |             |
|                     Record | .NET 6.0 | .NET 6.0 |  8.311 ns | 0.7714 ns | 2.2744 ns |  8.084 ns |  1.00 |    0.00 |     104 B |        1.00 |
|                     Record | .NET 7.0 | .NET 7.0 |  8.059 ns | 0.2216 ns | 0.5224 ns |  7.972 ns |  1.04 |    0.31 |     104 B |        1.00 |