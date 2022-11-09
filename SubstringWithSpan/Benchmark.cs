using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace SubstringWithSpan;

[SimpleJob(RuntimeMoniker.Net60, baseline: true)]
[SimpleJob(RuntimeMoniker.Net70)]
[MemoryDiagnoser(false)]
public class Benchmark
{
    public IEnumerable<(string String, Range Range)> InputGenerator()
    {
        yield return ("ABCDEFG", 4..6);
        yield return (new string('a', 800), 400..408);
        yield return (new string('a', 800), 400..799);
        yield return (new string('a', 800), 400..);
    }

    [ParamsSource(nameof(InputGenerator))]
    public (string String, Range Range) Input { get; set; }
    
    [Benchmark(Baseline = true)]
    public string Range()
    {
        return Input.String[Input.Range];
    }

    [Benchmark]
    public string SpanRange()
    {
        ReadOnlySpan<char> i = Input.String;
        return i[Input.Range].ToString();
    }
}