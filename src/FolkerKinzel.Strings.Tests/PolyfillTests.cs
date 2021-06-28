﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkerKinzel.Strings.Tests
{
    [TestClass()]
    public class PolyfillTests
    {
        [DataTestMethod()]
        [DataRow("Test", 'e', StringComparison.Ordinal, true)]
        public void ContainsTest1(string value, char c, StringComparison comparison,  bool expected)
        {
            Assert.AreEqual(expected, value.Contains(c, comparison));
        }

        [DataTestMethod()]
        [DataRow("Test", 'e', true)]
        public void ContainsTest2(string value, char c, bool expected)
        {
            Assert.AreEqual(expected, value.Contains(c));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ContainsTest3()
        {
            _ = "Test".Contains('e', (StringComparison)4711);
        }

        [DataTestMethod()]
        [DataRow("Test", 'e', StringComparison.Ordinal, 1)]
        public void IndexOfTest1(string value, char c, StringComparison comparison,  int expected)
        {
            Assert.AreEqual(expected, value.IndexOf(c, comparison));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IndexOfTest2()
        {
            _ = "Test".IndexOf('e', (StringComparison)4711);
        }


        [DataTestMethod()]
        [DataRow("Test", 'e', StringSplitOptions.RemoveEmptyEntries, 2)]
        public void SplitTest1(string value, char c, StringSplitOptions options,  int expected)
        {
            Assert.AreEqual(expected, value.Split(c, options));
        }

        [DataTestMethod()]
        [DataRow("Test", 'e', StringSplitOptions.RemoveEmptyEntries, 2)]
        public void SplitTest2(string value, char c, StringSplitOptions options,  int expected)
        {
            Assert.AreEqual(expected, value.Split(c, 2, options));
        }


        [DataTestMethod()]
        [DataRow("Test", 'e')]
        public void ReplaceTest1(string value, char c1)
        {
            Assert.AreEqual(2, value.IndexOf(c1));
        }


        [DataTestMethod()]
        [DataRow("xxTestxxx", 'x', "Test")]
        public void TrimTest1(string value, char c1, string expected)
        {
            Assert.AreEqual(expected, value.TrimEnd(c1));
        }

        [DataTestMethod()]
        [DataRow("Test", 'T', true)]
        public void StartsWithTest1(string value, char c, bool expected)
        {
            Assert.AreEqual(expected, value.StartsWith(c));
        }

        [DataTestMethod()]
        [DataRow("Test", 't', true)]
        public void EndsWithTest1(string value, char c, bool expected)
        {
            Assert.AreEqual(expected, value.EndsWith(c));
        }

        //[DataTestMethod()]
        //[DataRow("Test", "Other", ',', "Test,Other")]
        //public void JoinTest1(string value1, string value2, char c, string expected)
        //{
        //    Assert.AreEqual(expected, string.Join();
        //}

    }
}