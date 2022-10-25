using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace RecordStructBoxing;

[SimpleJob(RuntimeMoniker.Net60, baseline: true)]
[SimpleJob(RuntimeMoniker.Net70)]
[MemoryDiagnoser(false)]
public class Benchmark
{
    [Benchmark]
    public object ReadonlyRecordStructBoxing()
    {
        var r = new ReadonlyRecordStruct(69, 420, 1, 2, 3, 4, 5, 1000, 1000, 1, 2);
        return DoSomething(r);
    }

    [Benchmark]
    public object RecordStructBoxing()
    {
        var r = new RecordStruct(69, 420, 1, 2, 3, 4, 5, 1000, 1000, 1, 2);
        return DoSomething(r);
    }

    [Benchmark]
    public object Record()
    {
        var r = new Record(69, 420, 1, 2, 3, 4, 5, 1000, 1000, 1, 2);
        return DoSomething(r);
    }

    private object DoSomething(object o) => o;
}

public readonly record struct ReadonlyRecordStruct(long A, long B, long C, long D, long E, long F, long G, long H,
    long I, long J, long K);

public record struct RecordStruct(long A, long B, long C, long D, long E, long F, long G, long H, long I, long J,
    long K);

public record Record(long A, long B, long C, long D, long E, long F, long G, long H, long I, long J, long K);