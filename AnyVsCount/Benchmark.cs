using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<Benchmark>();

[MemoryDiagnoser(false)]
public class Benchmark
{
    [Params(10, 10_000)]
    public int Size { get; set; }

    private List<int> _list;
    private int[] _array;
    
    [GlobalSetup]
    public void Setup()
    {
        _list = Enumerable.Range(0, Size).ToList();
        _array = _list.ToArray();
    }

    [Benchmark]
    public bool ListCount()
    {
        return _list.Count > 0;
    }

    [Benchmark]
    public bool ListAny()
    {
        return _list.Any();
    }
    
    [Benchmark]
    public bool ArrayLength()
    {
        return _array.Length > 0;
    }
    
    [Benchmark]
    public bool ArrayAny()
    {
        return _array.Any();
    }
}