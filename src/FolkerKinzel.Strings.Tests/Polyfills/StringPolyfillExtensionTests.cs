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
    public class StringPolyfillExtensionTests : IDisposable
    {
        private readonly CultureInfo _culture;

        public StringPolyfillExtensionTests()
        {
            _culture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");
        }

        public void Dispose()
        {
            Thread.CurrentThread.CurrentCulture = _culture;
            GC.SuppressFinalize(this);
        }


        [DataTestMethod()]
        [DataRow("Test", 'e', StringComparison.Ordinal, true)]
        public void ContainsTest1(string value, char c, StringComparison comparison, bool expected)
         => Assert.AreEqual(expected, value.Contains(c, comparison));

        [DataTestMethod()]
        [DataRow("Test", 'e', true)]
        public void ContainsTest2(string value, char c, bool expected) => Assert.AreEqual(expected, value.Contains(c));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ContainsTest3() => _ = "Test".Contains('e', (StringComparison)4711);

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ContainsTest4()
        {
            string? test = null;
            _ = test!.Contains('e', StringComparison.Ordinal);
        }

        [DataTestMethod]
        [DataRow("Test", 'e', true)]
        public void ContainsTest5(string input, char c, bool expected) => Assert.AreEqual(expected, input.Contains(c));

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ContainsTest6()
        {
            string? test = null;
            _ = test!.Contains('e');
        }

        [DataTestMethod]
        [DataRow("Test", "es", true)]
        public void ContainsTest7(string input, string s, bool expected) => Assert.AreEqual(expected, input.Contains(s, StringComparison.Ordinal));

        [DataTestMethod]
        [DataRow("Test", "as", false)]
        public void ContainsTest8(string input, string s, bool expected) => Assert.AreEqual(expected, input.Contains(s, StringComparison.Ordinal));


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ContainsTest9()
        {
            string? test = null;
            _ = test!.Contains("es", StringComparison.Ordinal);
        }

        [DataTestMethod()]
        [DataRow("Test", 'e', StringComparison.Ordinal, 1)]
        public void IndexOfTest1(string value, char c, StringComparison comparison, int expected) => Assert.AreEqual(expected, value.IndexOf(c, comparison));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IndexOfTest2() => _ = "Test".IndexOf('e', (StringComparison)4711);

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void IndexOfTest3()
        {
            string? test = null;
            _ = test!.IndexOf('e', StringComparison.Ordinal);
        }


        [DataTestMethod()]
        [DataRow("Test", 'e', StringSplitOptions.RemoveEmptyEntries, 2)]
        public void SplitTest1(string value, char c, StringSplitOptions options, int expected)
            => Assert.AreEqual(expected, value.Split(c, options).Length);

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SplitTest2()
        {
            string? test = null;
            _ = test!.Split(',', StringSplitOptions.RemoveEmptyEntries);
        }

        [DataTestMethod()]
        [DataRow("Test", 'e', StringSplitOptions.RemoveEmptyEntries, 2)]
        public void SplitTest3(string value, char c, StringSplitOptions options, int expected) => Assert.AreEqual(expected, value.Split(c, 2, options).Length);


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SplitTest4()
        {
            string? test = null;
            _ = test!.Split(',', 2, StringSplitOptions.RemoveEmptyEntries);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SplitTest5()
        {
            string? test = null;
            _ = test!.Split(",", 2, StringSplitOptions.RemoveEmptyEntries);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void SplitTest6(string? separator) => Assert.AreEqual(1, "test".Split(separator, 4711).Length);

        [DataTestMethod]
        [DataRow(StringSplitOptions.None, 1)]
        [DataRow(StringSplitOptions.RemoveEmptyEntries, 0)]
        public void SplitTest7(StringSplitOptions options, int expected) => Assert.AreEqual(expected, "".Split("bla", 4711, options).Length);

        [TestMethod]
        public void SplitTest8() => Assert.AreEqual(0, "test".Split("e", 0).Length);


        [DataTestMethod]
        [DataRow("This is a test.", null, 100, StringSplitOptions.None, 1)]
        [DataRow("This is a test.", null, 0, StringSplitOptions.None, 0)]
        [DataRow("This is a test.", "", 100, StringSplitOptions.None, 1)]
        [DataRow("This is a test.", "", 0, StringSplitOptions.None, 0)]
        [DataRow("This is a test.", "is", 100, StringSplitOptions.None, 3)]
        [DataRow("This is a test.", "is", 2, StringSplitOptions.None, 2)]
        [DataRow("", "is", 2, StringSplitOptions.None, 1)]
        [DataRow("", "is", 2, StringSplitOptions.RemoveEmptyEntries, 0)]
        public void SplitTest9(string input, string? split, int parts, StringSplitOptions options, int expected)
            => Assert.AreEqual(expected, input.Split(split, parts, options).Length);


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SplitTest10()
        {
            string test = "Test";
            _ = test.Split("bla", -1);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SplitTest11()
        {
            string? test = null;
            _ = test!.Split("bla", 100);
        }

        
        [DataTestMethod]
        [DataRow("This is a test.", null, StringSplitOptions.None, 1)]
        [DataRow("This is a test.", "", StringSplitOptions.None, 1)]
        [DataRow("This is a test.", "is", StringSplitOptions.None, 3)]
        [DataRow("", "is", StringSplitOptions.None, 1)]
        [DataRow("", "is", StringSplitOptions.RemoveEmptyEntries, 0)]
        public void SplitTest12(string input, string? split, StringSplitOptions options, int expected)
            => Assert.AreEqual(expected, input.Split(split, options).Length);


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SplitTest13()
        {
            string? test = null;
            _ = test!.Split("bla");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SplitTest14() => _ = "test".Split("3", -1);

        [DataTestMethod()]
        [DataRow("Test", 'T', true)]
        //[DataRow("aeTest", 'ä', true)]
        public void StartsWithTest1(string value, char c, bool expected) => Assert.AreEqual(expected, value.StartsWith(c));

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void StartsWithTest2()
        {
            string? test = null;
            _ = test!.StartsWith(',');
        }

        [DataTestMethod()]
        [DataRow("Test", 't', true)]
        public void EndsWithTest1(string value, char c, bool expected) => Assert.AreEqual(expected, value.EndsWith(c));

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void EndsWithTest2()
        {
            string? test = null;
            _ = test!.EndsWith(',');
        }

        [DataTestMethod]
        [DataRow("Test", "testen", "as", StringComparison.Ordinal, "Test")]
        [DataRow("Test", "testen", "as", StringComparison.OrdinalIgnoreCase, "Test")]
        [DataRow("Test", "testen", null, StringComparison.Ordinal, "Test")]
        [DataRow("Test", "testen", null, StringComparison.OrdinalIgnoreCase, "Test")]
        [DataRow("Test", "test", "as", StringComparison.Ordinal, "Test")]
        [DataRow("Test", "test", "as", StringComparison.OrdinalIgnoreCase, "as")]
        [DataRow("Test", "test", null, StringComparison.Ordinal, "Test")]
        [DataRow("Test", "test", null, StringComparison.OrdinalIgnoreCase, "")]
        [DataRow("Test", "test", "test", StringComparison.Ordinal, "Test")]
        [DataRow("Test", "test", "test", StringComparison.OrdinalIgnoreCase, "test")]
        [DataRow("Test", "EST", "ante", StringComparison.Ordinal, "Test")]
        [DataRow("Test", "EST", "ante", StringComparison.OrdinalIgnoreCase, "Tante")]
        public void ReplaceTest1(string input, string oldValue, string? replacement, StringComparison comparison, string expected)
            => Assert.AreEqual(expected, input.Replace(oldValue, replacement, comparison));


        [DataTestMethod]
        [DataRow(StringComparison.Ordinal)]
        [DataRow(StringComparison.OrdinalIgnoreCase)]
        [ExpectedException(typeof(NullReferenceException))]
        public void ReplaceTest2(StringComparison comparison)
        {
            string? s = null;
            _ = s!.Replace("test", "bb", comparison);
        }

        [DataTestMethod]
        [DataRow(StringComparison.Ordinal)]
        [DataRow(StringComparison.OrdinalIgnoreCase)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReplaceTest3(StringComparison comparison)
        {
            string s = "Test";
            _ = s.Replace(null!, "bb", comparison);
        }

        [DataTestMethod]
        [DataRow(StringComparison.Ordinal)]
        [DataRow(StringComparison.OrdinalIgnoreCase)]
        [ExpectedException(typeof(ArgumentException))]
        public void ReplaceTest4(StringComparison comparison)
        {
            string s = "Test";
            _ = s.Replace("", "bb", comparison);
        }


    }
}