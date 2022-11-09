using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<Benchmark>();

public static partial class RegexContainer
{
    public const string RegexString = @"CN=N:(?<name>.+?)\+MS:(?<ms>.+?)(?:,|$)";

    public static readonly Regex Regex = new(RegexString);
    public static readonly Regex CompiledRegex = new(RegexString, RegexOptions.Compiled);

    public static readonly Regex CompiledRegexNonbacktracking =
        new(RegexString, RegexOptions.Compiled | RegexOptions.NonBacktracking);

    [GeneratedRegex(RegexString)]
    public static partial Regex GeneratedRegex();

    [GeneratedRegex(RegexString, RegexOptions.Compiled)]
    public static partial Regex GeneratedCompiledRegex();

    [GeneratedRegex(RegexString, RegexOptions.Compiled | RegexOptions.NonBacktracking)]
    public static partial Regex GeneratedCompiledNonBacktrackingRegex();
}

[MemoryDiagnoser(false)]
public class Benchmark
{
    [Params("CN=N:John Doe+MS:1234567890", "TestingWithALongString=true;CN=N:John Doe+MS:1234567890;TestingWithALongString=true")]
    public string Input { get; set; }

    [Benchmark]
    public Match InlineRegex()
    {
        return Regex.Match(Input, RegexContainer.RegexString);
    }

    [Benchmark]
    public Match RegexObject()
    {
        return RegexContainer.Regex.Match(Input);
    }

    [Benchmark]
    public Match CompiledRegex()
    {
        return RegexContainer.CompiledRegex.Match(Input);
    }


    [Benchmark]
    public Match CompiledRegexNonBacktracking()
    {
        return RegexContainer.CompiledRegexNonbacktracking.Match(Input);
    }

    [Benchmark]
    public Match GeneratedRegex()
    {
        return RegexContainer.GeneratedRegex().Match(Input);
    }

    [Benchmark]
    public Match GeneratedCompiledRegex()
    {
        return RegexContainer.GeneratedCompiledRegex().Match(Input);
    }

    [Benchmark]
    public Match GeneratedCompiledNonBacktrackingRegex()
    {
        return RegexContainer.GeneratedCompiledNonBacktrackingRegex().Match(Input);
    }
}