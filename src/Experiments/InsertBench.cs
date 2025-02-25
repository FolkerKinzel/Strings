using System.Text;
using BenchmarkDotNet.Attributes;

namespace Experiments;

[MemoryDiagnoser]
public class InsertBench
{
    private const string CONTENT = "123456789abcdefghijklmnopqrstuvwxyz";
    private const int INDEX = 1;
    private StringBuilder _builder = new(CONTENT);
    private const string TO_INSERT = "abcdefghijklmnopqrstuvwxyz";

    [IterationSetup]
    public void SetupData() => _builder = new StringBuilder(CONTENT);


    [Benchmark]
    public StringBuilder Test1() => Insert1(TO_INSERT.AsSpan());

    [Benchmark]
    public StringBuilder Test2() => Insert2(TO_INSERT.AsSpan());

    private StringBuilder Insert1(ReadOnlySpan<char> value)
    {
        //_ = builder.EnsureCapacity(builder.Length + value.Length);

        for (int i = value.Length - 1; i >= 0; i--)
        {
            _ = _builder.Insert(INDEX, value[i]);
        }

        return _builder;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance",
        "CA1830:Prefer strongly-typed Append and Insert method overloads on StringBuilder",
        Justification = "<Pending>")]
    private StringBuilder Insert2(ReadOnlySpan<char> value) => _builder.Insert(INDEX, value.ToString());
}
