using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace ByRefInt;

[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
[MemoryDiagnoser(false)]
public class Benchmark
{
    [Params(100, 10_000, 1_000_000)]
    public int Iterations { get; set; }

    [Benchmark(Baseline = true)]
    public int InMethod()
    {
        int count = 0;

        for (int i = 0; i < Iterations; i++)
        {
            count++;
        }

        return count;
    }


    [Benchmark]
    public int ByRef()
    {
        int count = 0;

        for (int i = 0; i < Iterations; i++)
        {
            IncrementByRef(ref count);
        }

        return count;
    }

    [Benchmark]
    public unsafe int WithPointer()
    {
        int count = 0;
        int* ptr = &count;

        for (int i = 0; i < Iterations; i++)
        {
            IncrementByPointer(ptr);
        }

        return count;
    }

    public static void IncrementByRef(ref int count)
    {
        count++;
    }

    public static unsafe void IncrementByPointer(int* pointer)
    {
        (*pointer)++;
    }
}
