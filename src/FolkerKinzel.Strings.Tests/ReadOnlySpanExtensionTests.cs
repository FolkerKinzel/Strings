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
