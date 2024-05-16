using System.Diagnostics.CodeAnalysis;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Intls;

namespace Benchmarks;

[MemoryDiagnoser]
[MarkdownExporter]
[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net48)]
public class ReplaceLineEndingsBench
{

    public const string TestString = "abc def ghi jkl mno pqr uvw xyz 1234567890\r\nabc def ghi jkl mno pqr uvw xyz 1234567890\r\n\r\nabc def ghi jkl";

    [NotNull]
    private StringBuilder? Builder { get; set; }

    [Params(1, 2, 3)]
    public int N { get; set; }
    

    [GlobalSetup]
    public void Setup()
    {
        Builder = new StringBuilder(N*TestString.Length);

        for (int i = 0; i < N; i++)
        {
            Builder.Append(TestString);
        }
    }

    [Benchmark]
    public StringBuilder StringBuilderLibraryChanges() => Builder.ReplaceLineEndings("\n");




    //[Benchmark]
    //public string StringLibraryNoChanges() => TestString.ReplaceLineEndings("\r\n");

    //[Benchmark]
    //public string StringArrayPoolNoChanges() => ReplaceLineEndings(TestString, "\r\n");

    [Benchmark]
    public string StringLibraryChanges() => TestString.ReplaceLineEndings("\n");

    //[Benchmark]
    //public string StringArrayPoolChanges() => ReplaceLineEndings(TestString, "\n");










}
