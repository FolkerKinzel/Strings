using Microsoft.VisualStudio.TestTools.UnitTesting;
using FolkerKinzel.Strings.Polyfills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace FolkerKinzel.Strings.Polyfills.Tests
{
    [TestClass()]
    public class ReadOnlySpanPolyfillExtensionTests : IDisposable
    {
        private readonly CultureInfo _culture;

        public ReadOnlySpanPolyfillExtensionTests()
        {
            _culture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");
        }

        [DataTestMethod]
        [DataRow("test", "TE", true)]
        [DataRow("test", "te", true)]
        [DataRow("test", "bla", false)]
        [DataRow("test", null, true)]
        [DataRow("test", "", true)]
        [DataRow("", "", true)]
        [DataRow("", "TE", false)]
        public void StartsWithTest1(string input, string? test, bool expected)
            => Assert.AreEqual(expected, input.AsSpan().StartsWith(test, StringComparison.OrdinalIgnoreCase));


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StartsWithTest2()
            => _ = "test".AsSpan().StartsWith("test", (StringComparison)4711);

        [DataTestMethod]
        [DataRow("test", "TE", false)]
        [DataRow("test", "te", true)]
        [DataRow("test", "bla", false)]
        [DataRow("test", null, true)]
        [DataRow("test", "", true)]
        [DataRow("", "", true)]
        [DataRow("", "TE", false)]
        public void StartsWithTest3(string input, string? test, bool expected)
            => Assert.AreEqual(expected, input.AsSpan().StartsWith(test));


        [DataTestMethod]
        [DataRow("test", "ST", true)]
        [DataRow("test", "st", true)]
        [DataRow("test", "bla", false)]
        [DataRow("test", null, true)]
        [DataRow("test", "", true)]
        [DataRow("", "", true)]
        [DataRow("", "st", false)]
        public void EndsWithTest1(string input, string? test, bool expected)
           => Assert.AreEqual(expected, input.AsSpan().EndsWith(test, StringComparison.OrdinalIgnoreCase));


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EndsWithTest2()
            => _ = "test".AsSpan().EndsWith("test", (StringComparison)4711);

        [DataTestMethod]
        [DataRow("test", "ST", false)]
        [DataRow("test", "st", true)]
        [DataRow("test", "bla", false)]
        [DataRow("test", null, true)]
        [DataRow("test", "", true)]
        [DataRow("", "", true)]
        [DataRow("", "st", false)]
        public void EndsWithTest3(string input, string? test, bool expected)
            => Assert.AreEqual(expected, input.AsSpan().EndsWith(test));


        public void Dispose()
        {
            Thread.CurrentThread.CurrentCulture = _culture;
            GC.SuppressFinalize(this);
        }

        [DataTestMethod()]
        [DataRow(StringComparison.Ordinal)]
        [DataRow(StringComparison.CurrentCulture)]
        public void LastIndexOfTest1(StringComparison comp)
        {
            const string test = "test";
            Assert.AreEqual(test.Length, test.AsSpan().LastIndexOf(ReadOnlySpan<char>.Empty, comp));
        }


        [DataTestMethod()]
        [DataRow(StringComparison.Ordinal)]
        [DataRow(StringComparison.CurrentCulture)]
        public void LastIndexOfTest2(StringComparison comp)
        {
            const string test = "test";
            Assert.AreEqual(1, test.AsSpan().LastIndexOf("est".AsSpan(), comp));
        }
    }
}