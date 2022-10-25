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
| ReadonlyRecordStructBoxing | .NET 6.0 | .NET 6.0 |  9.769 ns | 0.2517 ns | 0.3689 ns |  9.707 ns |  1.00 |    0.00 |     104 B |        1.00 |
| ReadonlyRecordStructBoxing | .NET 7.0 | .NET 7.0 | 11.613 ns | 0.3952 ns | 1.1211 ns | 11.198 ns |  1.24 |    0.12 |     104 B |        1.00 |
|                            |          |          |           |           |           |           |       |         |           |             |
|         RecordStructBoxing | .NET 6.0 | .NET 6.0 |  9.819 ns | 0.1928 ns | 0.1610 ns |  9.784 ns |  1.00 |    0.00 |     104 B |        1.00 |
|         RecordStructBoxing | .NET 7.0 | .NET 7.0 | 13.933 ns | 1.1025 ns | 3.0366 ns | 12.883 ns |  1.29 |    0.20 |     104 B |        1.00 |
|                            |          |          |           |           |           |           |       |         |           |             |
|                     Record | .NET 6.0 | .NET 6.0 |  4.844 ns | 0.1482 ns | 0.1386 ns |  4.833 ns |  1.00 |    0.00 |     104 B |        1.00 |
|                     Record | .NET 7.0 | .NET 7.0 |  8.390 ns | 0.5806 ns | 1.6375 ns |  7.801 ns |  1.80 |    0.45 |     104 B |        1.00 |