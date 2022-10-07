using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace RecordStructBoxing;

[SimpleJob(RuntimeMoniker.Net60, baseline: true)]
[SimpleJob(RuntimeMoniker.Net70)]
[MemoryDiagnoser(false)]
public class Benchmark
{
    [BenchmarkCategory("Class"), Benchmark(Baseline = true)]
    public void RecordClass()
    {
        var r = new RecordClass(69);
        DoSomething(r);
    }

    [BenchmarkCategory("Class", "Inline"), Benchmark]
    public void RecordClass_Inlined()
    {
        var r = new RecordClass(69);
        DoSomethingInlined(r);
    }
    
    [BenchmarkCategory("Struct"), Benchmark]
    public void RecordStruct()
    {
        var r = new RecordStruct(69);
        DoSomething(r);
    }

    [BenchmarkCategory("Struct", "Inline"), Benchmark]
    public void RecordStruct_Inline()
    {
        var r = new RecordStruct(69);
        DoSomethingInlined(r);
    }


    [BenchmarkCategory("Readonly record struct"), Benchmark]
    public void ReadonlyRecordStruct()
    {
        var r = new ReadonlyRecordStruct(69);
        DoSomething(r);
    }
    
    [BenchmarkCategory("Readonly record struct", "Inline"), Benchmark]
    public void ReadonlyRecordStruct_Inline()
    {
        var r = new ReadonlyRecordStruct(69);
        DoSomethingInlined(r);
    }

    private object DoSomething(object o) => o;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private object DoSomethingInlined(object o) => o;
}

public record RecordClass(int A);

public record struct RecordStruct(int A);

public readonly record struct ReadonlyRecordStruct(int A);