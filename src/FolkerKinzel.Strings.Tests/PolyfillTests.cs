using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FolkerKinzel.Strings.Tests
{
    [TestClass()]
    public class PolyfillTests : IDisposable
    {
        private readonly CultureInfo _culture;

        public PolyfillTests()
        {
            _culture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");
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
            _ =  test!.Contains('e', StringComparison.Ordinal);
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
            _ =  test!.IndexOf('e', StringComparison.Ordinal);
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
            _ =  test!.Split(',', StringSplitOptions.RemoveEmptyEntries);
        }

        [DataTestMethod()]
        [DataRow("Test", 'e', StringSplitOptions.RemoveEmptyEntries, 2)]
        public void SplitTest3(string value, char c, StringSplitOptions options, int expected) => Assert.AreEqual(expected, value.Split(c, 2, options).Length);


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SplitTest4()
        {
            string? test = null;
            _ =  test!.Split(',', 2, StringSplitOptions.RemoveEmptyEntries);
        }

        [DataTestMethod()]
        [DataRow("Test", 'T', true)]
        //[DataRow("aeTest", 'ä', true)]
        public void StartsWithTest1(string value, char c, bool expected) => Assert.AreEqual(expected, value.StartsWith(c));

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void StartsWithTest2()
        {
            string? test = null;
            _ =  test!.StartsWith(',');
        }

        [DataTestMethod()]
        [DataRow("Test", 't', true)]
        public void EndsWithTest1(string value, char c, bool expected) => Assert.AreEqual(expected, value.EndsWith(c));

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void EndsWithTest2()
        {
            string? test = null;
            _ =  test!.EndsWith(',');
        }


        //[TestMethod]
        //[ExpectedException(typeof(NullReferenceException))]
        //public void ReplaceTest1()
        //{
        //    string? s = null;
        //    _ = s!.Replace(" ", "", StringComparison.Ordinal);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void ReplaceTest2()
        //{
        //    string s = "Test";
        //    _ = s.Replace(null!, "", StringComparison.Ordinal);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        //public void ReplaceTest3()
        //{
        //    string s = "Test";
        //    _ = s.Replace("", "", StringComparison.Ordinal);
        //}

        public void Dispose()
        {
            Thread.CurrentThread.CurrentCulture = _culture;
            GC.SuppressFinalize(this);
        }

        //[DataTestMethod()]
        //[DataRow("Test", "Other", ',', "Test,Other")]
        //public void JoinTest1(string value1, string value2, char c, string expected)
        //{
        //    Assert.AreEqual(expected, string.Join();
        //}

    }
}