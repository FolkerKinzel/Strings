using System;
using System.Runtime.CompilerServices;
using System.Text;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Intls;

namespace Benchmarks;

[MemoryDiagnoser]
public class ReplaceLineEndingsBench
{
    public ReplaceLineEndingsBench() => this.TestString = Properties.Resources.ReplaceLineEndingsTest;

    public string TestString { get; }

    


    //[Benchmark]
    //public StringBuilder StringBuilderLibraryNoChanges()
    //{
    //    var sb = new StringBuilder(TestString);
    //    return sb.ReplaceLineEndings("\r\n");
    //}

    

    [Benchmark]
    public StringBuilder StringBuilderLibraryChanges()
    {
        var sb = new StringBuilder(TestString);
        return sb.ReplaceLineEndings("\n");
    }

    


    //[Benchmark]
    //public string StringLibraryNoChanges() => TestString.ReplaceLineEndings("\r\n");

    //[Benchmark]
    //public string StringArrayPoolNoChanges() => ReplaceLineEndings(TestString, "\r\n");

    //[Benchmark]
    //public string StringLibraryChanges() => TestString.ReplaceLineEndings("\n");

    //[Benchmark]
    //public string StringArrayPoolChanges() => ReplaceLineEndings(TestString, "\n");


   




    


}
