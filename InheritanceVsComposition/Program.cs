using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<Bench>();


[MemoryDiagnoser]
public class Bench
{
    private static readonly InheritanceVsComposition.Inh.CorporateCache InheritanceCache = new();
    private static readonly InheritanceVsComposition.Comp.CorporateCache CompositionCache = new();

    private static readonly Corporate CacheItem = new Corporate { Identifier = "bla bla bla" };

    [Benchmark]
    public int InheritanceGet()
    {
        return InheritanceCache.Get(CacheItem);
    }

    [Benchmark]
    public int InheritanceSet()
    {
        return InheritanceCache.Set(CacheItem);
    }

    [Benchmark]
    public int CompositionGet()
    {
        return CompositionCache.Get(CacheItem);
    }

    [Benchmark]
    public int CompositionSet()
    {
        return CompositionCache.Set(CacheItem);
    }
}



public class Corporate
{
    public string Identifier { get; set; }
}