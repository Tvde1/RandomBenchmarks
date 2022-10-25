
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace SerialNumberParse;

[SimpleJob(RuntimeMoniker.Net60, baseline: true)]
[SimpleJob(RuntimeMoniker.Net70)]
[MemoryDiagnoser(false)]
public class Benchmark
{
    [Params("CN=00000 00000 00000 010910", "CN=12345 98765 99999 990910")]
    public string Input { get; set; }

    [Benchmark]
    public MachineIdentifier StringSplit()
    {
        var splits = Input[3..].Split(' ');
        return new MachineIdentifier(uint.Parse(splits[0]), uint.Parse(splits[1]), uint.Parse(splits[2]),
            uint.Parse(splits[3]));
    }
    
    [Benchmark(Baseline = true)]
    public MachineIdentifier String()
    {
        var one = uint.Parse(Input[3..8]);  
        var two = uint.Parse(Input[9..14]);   
        var three = uint.Parse(Input[15..20]);
        var four = uint.Parse(Input[21..27]);
        
        return new MachineIdentifier(one, two, three, four);
    }
    
    [Benchmark]
    public MachineIdentifier Span()
    {
        ReadOnlySpan<char> s = Input;

        var one = uint.Parse(s[3..8]);  
        var two = uint.Parse(s[9..14]);   
        var three = uint.Parse(s[15..20]);
        var four = uint.Parse(s[21..27]);
        
        return new MachineIdentifier(one, two, three, four);
    }
}

public readonly record struct MachineIdentifier(uint One, uint Two, uint Three, uint Four);