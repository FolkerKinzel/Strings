using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;

namespace Experiments;

[MemoryDiagnoser]
public class HexDigitBench
{
    private const string TEST = "01234AaBbFfG";

    [Benchmark]
    public bool IsAsciiHexDigitBench()
    {
        ReadOnlySpan<char> span = TEST.AsSpan();
        bool result = false;

        for (int i = 0; i < span.Length; i++)
        {
            result = span[i].IsAsciiHexDigit();
        }

        return result;
    }


    //    [Benchmark]
    //    public bool IsHexDigitTest()
    //    {
    //        ReadOnlySpan<char> span = TEST.AsSpan();
    //        bool result = false;
    //        for (int i = 0; i < span.Length; i++)
    //        {
    //#pragma warning disable CS0618 // Typ oder Element ist veraltet
    //            result = span[i].IsHexDigit();
    //#pragma warning restore CS0618 // Typ oder Element ist veraltet
    //        }

    //        return result;
    //    }
}
