using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<Benchmark>();

[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class Benchmark
{
    [Benchmark]
    [Arguments(0)]
    [Arguments(1)]
    [Arguments(5)]
    [Arguments(10)]
    [Arguments(25)]
    [Arguments(50)]
    [Arguments(100)]
    public void Sleep(int sleep)
    {
        Thread.Sleep(sleep);
    }
}