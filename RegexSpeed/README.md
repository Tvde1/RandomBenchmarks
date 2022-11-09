``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.1098/21H2)
12th Gen Intel Core i7-1260P, 1 CPU, 16 logical and 12 physical cores
.NET SDK=7.0.100-rc.2.22477.23
  [Host]     : .NET 7.0.0 (7.0.22.47203), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.47203), X64 RyuJIT AVX2


```
|                                Method |                Input |       Mean |     Error |      StdDev |     Median | Allocated |
|-------------------------------------- |--------------------- |-----------:|----------:|------------:|-----------:|----------:|
|                           **InlineRegex** | **CN=N:(...)67890 [27]** | **1,184.1 ns** |  **49.71 ns** |   **146.58 ns** | **1,110.4 ns** |     **296 B** |
|                           RegexObject | CN=N:(...)67890 [27] | 1,136.7 ns |  41.39 ns |   122.04 ns | 1,110.6 ns |     296 B |
|                         CompiledRegex | CN=N:(...)67890 [27] |   280.1 ns |  11.31 ns |    33.34 ns |   267.2 ns |     296 B |
|          CompiledRegexNonBacktracking | CN=N:(...)67890 [27] | 3,931.5 ns | 215.70 ns |   636.00 ns | 4,002.0 ns |     528 B |
|                        GeneratedRegex | CN=N:(...)67890 [27] |   311.9 ns |   8.77 ns |    25.57 ns |   320.9 ns |     296 B |
|                GeneratedCompiledRegex | CN=N:(...)67890 [27] |   319.1 ns |   4.26 ns |     3.77 ns |   319.7 ns |     296 B |
| GeneratedCompiledNonBacktrackingRegex | CN=N:(...)67890 [27] | 4,576.2 ns |  36.49 ns |    34.14 ns | 4,579.4 ns |     528 B |
|                           **InlineRegex** | **Testi(...)=true [83]** | **2,837.8 ns** | **108.79 ns** |   **317.33 ns** | **2,727.6 ns** |     **296 B** |
|                           RegexObject | Testi(...)=true [83] | 3,142.3 ns | 101.90 ns |   300.45 ns | 3,301.6 ns |     296 B |
|                         CompiledRegex | Testi(...)=true [83] |   699.0 ns |  24.53 ns |    71.16 ns |   724.1 ns |     296 B |
|          CompiledRegexNonBacktracking | Testi(...)=true [83] | 9,137.7 ns | 170.68 ns |   182.62 ns | 9,187.7 ns |     528 B |
|                        GeneratedRegex | Testi(...)=true [83] |   727.5 ns |   5.78 ns |     5.40 ns |   728.6 ns |     296 B |
|                GeneratedCompiledRegex | Testi(...)=true [83] |   702.3 ns |  18.09 ns |    53.34 ns |   726.0 ns |     296 B |
| GeneratedCompiledNonBacktrackingRegex | Testi(...)=true [83] | 7,596.9 ns | 383.88 ns | 1,131.89 ns | 7,107.8 ns |     528 B |
