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

    public const string TestString = "abc\r\nabc\r\n\r\nabc";

    private StringBuilder Builder { get; set; }


    //[Benchmark]
    //public StringBuilder StringBuilderLibraryNoChanges()
    //{
    //    var sb = new StringBuilder(TestString);
    //    return sb.ReplaceLineEndings("\r\n");
    //}

    [GlobalSetup]
    public void Setup() => Builder = new StringBuilder(TestString);


    [Benchmark]
    public StringBuilder StringBuilderLibraryChanges() => Builder.ReplaceLineEndings("\n");




    //[Benchmark]
    //public string StringLibraryNoChanges() => TestString.ReplaceLineEndings("\r\n");

    //[Benchmark]
    //public string StringArrayPoolNoChanges() => ReplaceLineEndings(TestString, "\r\n");

    //[Benchmark]
    //public string StringLibraryChanges() => TestString.ReplaceLineEndings("\n");

    //[Benchmark]
    //public string StringArrayPoolChanges() => ReplaceLineEndings(TestString, "\n");










}
