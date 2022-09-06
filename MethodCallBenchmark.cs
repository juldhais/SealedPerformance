using BenchmarkDotNet.Attributes;

namespace SealedPerformance;

[MemoryDiagnoser]
public class MethodCallBenchmark
{
    private readonly Person _person = new();
    private readonly Programmer _programmer = new();
    private readonly ProgrammerSealed _programmerSealed = new();
    
    [Benchmark]
    public void MethodCall()
    {
        _programmer.Eat();
    }
    
    [Benchmark]
    public void MethodCallSealed()
    {
        _programmerSealed.Eat();
    }
}