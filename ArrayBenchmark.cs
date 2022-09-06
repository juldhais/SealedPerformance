using BenchmarkDotNet.Attributes;

namespace SealedPerformance;

[MemoryDiagnoser]
public class ArrayBenchmark
{
    private readonly Programmer[] _array = new Programmer[100];
    private readonly ProgrammerSealed[] _sealedArray = new ProgrammerSealed[100];

    [Benchmark]
    public void Array()
    {
        for (var i = 0; i < _array.Length; i++)
        {
            _array[i] = new Programmer();
        }
    }
    
    [Benchmark]
    public void ArraySealed()
    {
        for (var i = 0; i < _sealedArray.Length; i++)
        {
            _sealedArray[i] = new ProgrammerSealed();
        }
    }
}