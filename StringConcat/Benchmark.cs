using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace StringConcat;

[SimpleJob(RuntimeMoniker.Net60, baseline: true)]
[SimpleJob(RuntimeMoniker.Net70)]
[MemoryDiagnoser(false)]
public class Benchmark
{
    public int One = 12345;
    public int Two = 99999;
    public int Three = 00001;
    public int Four = 100001;

    [Benchmark(Baseline = true)]
    public string Interpolation()
    {
        return $"{One:D5} {Two:D5} {Three:D5} {Four:D6}";
    }

    [Benchmark]
    public string Format()
    {
        return string.Format("{0:D5} {1:D5} {2:D5} {3:D6}", One, Two, Three, Four);
    }

    [Benchmark]
    public string Concat()
    {
        const string space = " ";
        return One.ToString("D5") + space + Two.ToString("D5") + space + Three.ToString("D5") + space +
               Four.ToString("D6");
    }
}