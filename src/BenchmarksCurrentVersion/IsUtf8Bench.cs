using System.IO;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using FolkerKinzel.Strings;

namespace Benchmarks;

[MemoryDiagnoser]
[BaselineColumn]
[MarkdownExporter]
[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net48)]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Member als statisch markieren", Justification = "<Ausstehend>")]
public class IsUtf8Bench
{
    private static readonly FileInfo _fi = new(@"..\..\..\..\BenchmarksCurrentVersion\Testfiles\AnsiIssue.vcf");
    private static readonly Encoding _enc = Encoding.GetEncoding(65001, EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback);

    [Benchmark(Baseline = true)]
    public bool IsUtf8Library() => _fi.IsUtf8();

    [Benchmark]
    public bool IsUtf8Exception()
    {
        try
        {
            using var reader = new StreamReader(_fi.FullName, _enc, detectEncodingFromByteOrderMarks: false);
            _ = reader.ReadToEnd();
        }
        catch (DecoderFallbackException)
        {
            return false;
        }
        return true;
    }
}
