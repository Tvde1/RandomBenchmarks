using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<Benchmark>();

[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
[MemoryDiagnoser]
public class Benchmark
{
    private readonly string[] _inputs = Enumerable.Range(0, 100).Select(_ => Random.Shared.Next(0, 1000).ToString()).ToArray();

    [Benchmark]
    public int ParseInt()
    {
        var counter = 0;
        foreach (var input in _inputs)
        {
            counter += int.Parse(input);
        }

        return counter;
    }

    [Benchmark()]
    public int TryParse()
    {
        var counter = 0;
        foreach (var input in _inputs)
        {
            if (int.TryParse(input, out var num))
            {
                counter += num;
            }
        }

        return counter;
    }

    [Benchmark()]
    public int CustomParse()
    {
        var counter = 0;
        foreach (var input in _inputs)
        {
            counter += BenchmarkImpl.CustomParse(input);
        }

        return counter;
    }

    [Benchmark()]
    public int CustomParseSpan()
    {
        var counter = 0;
        foreach (var input in _inputs)
        {
            counter += BenchmarkImpl.CustomParseSpan(input);
        }

        return counter;
    }
}

public static class BenchmarkImpl
{
    public static int CustomParse(string input)
    {
        var value = 0;
        for (var index = 0; index < input.Length; index++)
        {
            value = value * 10 + (input[index] - '0');
        }

        return value;
    }

    public static int CustomParseSpan(ReadOnlySpan<char> input)
    {
        var value = 0;
        foreach (var t in input)
        {
            value = value * 10 + (t - '0');
        }

        return value;
    }
}