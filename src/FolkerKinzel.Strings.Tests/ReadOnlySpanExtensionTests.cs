using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Tests
{
    [TestClass]
    public class ReadOnlySpanExtensionTests
    {
        [DataTestMethod]
        [DataRow("ef", 4)]
        [DataRow("0123456789ef", 4)]
        [DataRow("", -1)]
        [DataRow("xy", -1)]
        [DataRow("qwxyza0123456789", -1)]
        public void LastIndexOfAnyTest1(string needles, int expected)
        {
            const string test = "testen";

            //int i = "".LastIndexOfAny(new char[0]);
            //i = MemoryExtensions.LastIndexOfAny(test.AsSpan(), ReadOnlySpan<char>.Empty);

            Assert.AreEqual(expected, test.AsSpan().LastIndexOfAny(needles.AsSpan()));
        }

        [TestMethod]
        public void LastIndexOfAnyTest2()
        {
            const string test = "test";
            Assert.AreEqual(-1, ReadOnlySpan<char>.Empty.LastIndexOfAny(test.AsSpan()));
        }


        [DataTestMethod]
        [DataRow("t", "abcdefghi", -1)]
        [DataRow("t", "abcdefghit", 0)]
        [DataRow("testtest", "abcdfghi", -1)]
        [DataRow("testtest", "abcdfghit", 0)]
        [DataRow("", "abcdefghit", -1)]
        [DataRow("t", "", -1)]
        [DataRow("testtest", "", -1)]
        public void IndexOfAnyTest1(string testStr, string needles, int expectedIndex)
            => Assert.AreEqual(expectedIndex, testStr.AsSpan().IndexOfAny(needles.AsSpan()));

        [TestMethod]
        public void ContainsAnyTest1() => Assert.IsFalse("test".AsSpan().ContainsAny(ReadOnlySpan<char>.Empty));

        [DataTestMethod]
        [DataRow("test", 0)]
        [DataRow("", 0)]
        [DataRow(" ", 1)]
        [DataRow(" test", 1)]
        public void GetTrimmedStartTest1(string input, int result)
        {
            Assert.AreEqual(result, input.AsSpan().GetTrimmedStart());
        }

        [DataTestMethod]
        [DataRow("test", 4)]
        [DataRow("", 0)]
        [DataRow(" ", 0)]
        [DataRow("test    ", 4)]
        public void GetTrimmedLength1(string input, int length)
        {
            Assert.AreEqual(length, input.AsSpan().GetTrimmedLength());
        }
    }
}
