﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}