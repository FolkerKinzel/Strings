using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using FolkerKinzel.Strings;
using FolkerKinzel.Strings.Polyfills;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class ReplaceLineEndingsBench
    {
        public ReplaceLineEndingsBench()
        {
            this.TestString = Properties.Resources.ReplaceLineEndingsTest;
        }

        public string TestString { get; }

        [Benchmark]
        public StringBuilder BenchStringBuilder1()
        {
            var sb = new StringBuilder(TestString);
            return sb.ReplaceLineEndings("\r\n");
        }

        [Benchmark]
        public StringBuilder BenchStringBuilder2()
        {
            var sb = new StringBuilder(TestString);
            return sb.ReplaceLineEndings("\n");
        }

        [Benchmark]
        public string BenchString1()
        {
            return TestString.ReplaceLineEndings("\r\n");
        }

        [Benchmark]
        public string BenchString2()
        {
            return TestString.ReplaceLineEndings("\n");
        }
    }
}
