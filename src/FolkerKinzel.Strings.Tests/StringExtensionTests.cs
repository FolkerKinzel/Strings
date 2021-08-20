﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using FolkerKinzel.Strings;
using System;
using System.Collections.Generic;
using System.Text;
using FolkerKinzel.Strings.Polyfills;

namespace FolkerKinzel.Strings.Tests
{
    [TestClass()]
    public class StringExtensionTests
    {
        [TestMethod]
        public void NormalizeNewLinesToTest1()
        {
            const string input = "1\r\n\n\r2\r3\n\n4\r\n";
            const string expected = "1**2*3**4*";

            string output = input.NormalizeNewLinesTo("*");
            Assert.AreEqual(expected, output);
        }

        [DataTestMethod]
        [DataRow('e', 's', 't', true)]
        [DataRow('e', 'y', 't', true)]
        [DataRow('y', 's', 't', true)]
        [DataRow('e', 's', 'y', true)]
        [DataRow('e', 'y', 'y', true)]
        [DataRow('y', 'y', 't', true)]
        [DataRow('y', 's', 'y', true)]
        [DataRow('y', 'y', 'y', false)]
        public void ContainsAnyTest1(char val0, char val1, char val2, bool expected)
        {
            const string test = "test";
            Assert.AreEqual(expected, test.ContainsAny(val0, val1, val2));
        }

        [DataTestMethod]
        [DataRow('e', 's', true)]
        [DataRow('e', 'y', true)]
        [DataRow('y', 's', true)]
        [DataRow('y', 'y', false)]
        public void ContainsAnyTest2(char val0, char val1, bool expected)
        {
            const string test = "test";
            Assert.AreEqual(expected, test.ContainsAny(val0, val1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsAnyTest3()
        {
            string? s = null;
            _ = s!.ContainsAny('a', 'b', 'c');
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsAnyTest4()
        {
            string? s = null;
            _ = s!.ContainsAny('a', 'b');
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsAnyTest5()
        {
            string? s = null;
            _ = s!.ContainsAny(ReadOnlySpan<char>.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsAnyTest6()
        {
            string? s = null;
            _ = s!.ContainsAny(new char[]{ 'a', 'b'});
        }


        [DataTestMethod]
        [DataRow("ts", true)]
        [DataRow("0123456789ts", true)]
        [DataRow("", false)]
        [DataRow("xy", false)]
        [DataRow("qwxyza0123456789", false)]
        public void ContainsAnyTest7(string needles, bool expected)
        {
            const string test = "test";

            //int i = MemoryExtensions.IndexOfAny(test.AsSpan(), ReadOnlySpan<char>.Empty);

            Assert.AreEqual(expected, test.ContainsAny(needles.AsSpan()));
        }

        [DataTestMethod]
        [DataRow("ts", true)]
        [DataRow("0123456789ts", true)]
        [DataRow("", false)]
        [DataRow("xy", false)]
        [DataRow("qwxyza0123456789", false)]
        public void ContainsAnyTest8(string needles, bool expected)
        {
            const string test = "test";
            Assert.AreEqual(expected, test.ContainsAny(needles.ToCharArray()));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsAnyTest10()
        {
            const string test = "test";
            char[]? arr = null;
            _ = test.ContainsAny(arr!);
        }

        [DataTestMethod]
        [DataRow("ts", 2)]
        [DataRow("0123456789ts", 2)]
        [DataRow("", -1)]
        [DataRow("xy", -1)]
        [DataRow("qwxyza0123456789", -1)]
        public void IndexOfAnyTest7(string needles, int expected)
        {
            const string test = "test";

            //int i = "".LastIndexOfAny(new char[0]);
            //i = MemoryExtensions.LastIndexOfAny(test.AsSpan(), ReadOnlySpan<char>.Empty);

            Assert.AreEqual(expected, test.IndexOfAny(needles.AsSpan(), 1, test.Length - 1));
        }

        [TestMethod]
        public void IndexOfAnyTest8()
        {
            const string test = "test";
            Assert.AreEqual(-1, "".IndexOfAny(test.AsSpan(), 0, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IndexOfAnyTest9()
        {
            const string? test = null;
            _ = test!.IndexOfAny(ReadOnlySpan<char>.Empty, 0, 0);
        }

        [DataTestMethod]
        [DataRow("ef", 4)]
        [DataRow("0123456789ef", 4)]
        [DataRow("", -1)]
        [DataRow("xy", -1)]
        [DataRow("qwxyza0123456789", -1)]
        public void LastIndexOfAnyTest7(string needles, int expected)
        {
            const string test = "testen";

            //int i = "".LastIndexOfAny(new char[0]);
            //i = MemoryExtensions.LastIndexOfAny(test.AsSpan(), ReadOnlySpan<char>.Empty);

            Assert.AreEqual(expected, test.LastIndexOfAny(needles.AsSpan(), test.Length - 2, 3));
        }

        [TestMethod]
        public void LastIndexOfAnyTest8()
        {
            const string test = "test";
            Assert.AreEqual(-1, "".LastIndexOfAny(test.AsSpan(), 0, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LastIndexOfAnyTest9()
        {
            const string? test = null;
            _ = test!.LastIndexOfAny(ReadOnlySpan<char>.Empty, 0, 0);
        }

        [DataTestMethod]
        [DataRow(-1, 0)]
        [DataRow(0, -1)]
        [DataRow(0, 2)]
        [DataRow(-2, 2)]
        [DataRow(2, -2)]
        public void LastIndexOfAnyTest10(int index, int count)
        {
            ReadOnlySpan<char> needles = "testganzlang".AsSpan();

            _ = "".LastIndexOfAny(needles, index, count);
        }

        [DataTestMethod]
        [DataRow(-1, 0)]
        [DataRow(0, -1)]
        [DataRow(0, 2)]
        [DataRow(-2, 2)]
        [DataRow(2, -2)]
        public void LastIndexOfAnyTest11(int index, int count)
        {
            ReadOnlySpan<char> needles = "t".AsSpan();

            _ = "".LastIndexOfAny(needles, index, count);
        }

        [DataTestMethod]
        //[DataRow(-1, 0)]
        [DataRow(0, -1)]
        [DataRow(0, 2)]
        [DataRow(-2, 2)]
        [DataRow(2, -2)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LastIndexOfAnyTest16(int index, int count)
        {
            ReadOnlySpan<char> needles = "testganzlang".AsSpan();
            _ = "t".LastIndexOfAny(needles, index, count);
        }

        [DataTestMethod]
        //[DataRow(-1, 0)]
        [DataRow(0, -1)]
        [DataRow(0, 2)]
        [DataRow(-2, 2)]
        [DataRow(2, -2)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LastIndexOfAnyTest17(int index, int count)
        {
            ReadOnlySpan<char> needles = "t".AsSpan();
            _ = "t".LastIndexOfAny(needles, index, count);
        }

        [DataTestMethod]
        [DataRow("", false)]
        [DataRow(null, false)]
        [DataRow("Test", false)]
        [DataRow(" Test", true)]
        [DataRow("Test ", true)]
        [DataRow("Te st", true)]
        public void ContainsWhiteSpaceTest(string? input, bool expected) => Assert.AreEqual(expected, input.ContainsWhiteSpace());

        [DataTestMethod]
        [DataRow("", true)]
        [DataRow(null, true)]
        [DataRow("Test", true)]
        [DataRow("Märchen", false)]
        public void IsAsciiTest(string? input, bool expected) => Assert.AreEqual(expected, input.IsAscii());

        [TestMethod()]
        public void GetPersistentHashCodeTest1()
        {
            int hash1 = string.Empty.GetPersistentHashCode(HashType.Ordinal);
            int hash2 = "".GetPersistentHashCode(HashType.Ordinal);

            Assert.AreEqual(hash1, hash2);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPersistentHashCodeTest2()
        {
            string? s = null;

            _ = s!.GetPersistentHashCode(HashType.Ordinal);
        }


        [TestMethod()]
        public void GetPersistentHashCodeTest3()
        {
            int hash1 = "Hallo".GetPersistentHashCode(HashType.OrdinalIgnoreCase);
            int hash2 = "hallo".GetPersistentHashCode(HashType.OrdinalIgnoreCase);

            Assert.AreEqual(hash1, hash2);
        }


        [TestMethod()]
        public void GetPersistentHashCodeTest4()
        {
            int hash1 = "Hallo".GetPersistentHashCode(HashType.Ordinal);
            int hash2 = "hallo".GetPersistentHashCode(HashType.Ordinal);

            Assert.AreNotEqual(hash1, hash2);
        }


        [TestMethod()]
        public void GetPersistentHashCodeTest5()
        {
            int hash1 = "Hallo, dies ist Text.".GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);
            int hash2 = "hallodiesisttext".GetPersistentHashCode(HashType.OrdinalIgnoreCase);

            Assert.AreEqual(hash1, hash2);
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPersistentHashCodeTest6()
        {
            string? s = null;
            _ = s!.GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void GetPersistentHashCodeTest7() => _ = string.Empty.GetPersistentHashCode((HashType)4711);



        [TestMethod]
        public void TrimTest1()
        {
            char[] trimChars = new char[] { '\'', '\"' };

            string test = "\"\'Test\'\"";

            Assert.AreEqual(test.Trim(trimChars), test.Trim(trimChars.AsSpan()));
        }

        [TestMethod]
        public void TrimTest2()
        {
            string test = "  Test  ";

            Assert.AreEqual(test.Trim(null), test.Trim(ReadOnlySpan<char>.Empty));
        }

        [TestMethod]
        public void TrimTest3()
        {
            char[] trimChars = new char[] { '\'', '\"' };
            string test = "\"\'\'\"";
            Assert.AreEqual(test.Trim(trimChars), test.Trim(trimChars.AsSpan()));
        }


        [TestMethod]
        public void TrimTest4()
        {
            string test = "    ";
            Assert.AreEqual(test.Trim(null), test.Trim(ReadOnlySpan<char>.Empty));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrimTest5()
        {
            string? test = null;
            _ = test!.Trim(ReadOnlySpan<char>.Empty);
        }

        [TestMethod]
        public void TrimTest6()
        {
            char[] trimChars = new char[] { '\'', '\"' };

            string test = "Test";
            Assert.AreEqual(test.Trim(trimChars), test.Trim(trimChars.AsSpan()));
        }

        [TestMethod]
        public void TrimStartTest1()
        {
            char[] trimChars = new char[] { '\'', '\"' };

            string test = "\"\'Test\'\"";

            Assert.AreEqual(test.TrimStart(trimChars), test.TrimStart(trimChars.AsSpan()));
        }

        [TestMethod]
        public void TrimStartTest2()
        {
            string test = "  Test  ";

            Assert.AreEqual(test.TrimStart(null), test.TrimStart(ReadOnlySpan<char>.Empty));
        }

        [TestMethod]
        public void TrimStartTest3()
        {
            char[] trimChars = new char[] { '\'', '\"' };
            string test = "\"\'\'\"";
            Assert.AreEqual(test.TrimStart(trimChars), test.TrimStart(trimChars.AsSpan()));
        }


        [TestMethod]
        public void TrimStartTest4()
        {
            string test = "    ";
            Assert.AreEqual(test.TrimStart(null), test.TrimStart(ReadOnlySpan<char>.Empty));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrimStartTest5()
        {
            string? test = null;
            _ = test!.TrimStart(ReadOnlySpan<char>.Empty);
        }

        [TestMethod]
        public void TrimStartTest6()
        {
            char[] trimChars = new char[] { '\'', '\"' };

            string test = "Test";
            Assert.AreEqual(test.TrimStart(trimChars), test.TrimStart(trimChars.AsSpan()));
        }
        
        [TestMethod]
        public void TrimEndTest1()
        {
            char[] trimChars = new char[] { '\'', '\"' };

            string test = "\"\'Test\'\"";

            Assert.AreEqual(test.TrimEnd(trimChars), test.TrimEnd(trimChars.AsSpan()));
        }

        [TestMethod]
        public void TrimEndTest2()
        {
            string test = "  Test  ";

            Assert.AreEqual(test.TrimEnd(null), test.TrimEnd(ReadOnlySpan<char>.Empty));
        }

        [TestMethod]
        public void TrimEndTest3()
        {
            char[] trimChars = new char[] { '\'', '\"' };
            string test = "\"\'\'\"";
            Assert.AreEqual(test.TrimEnd(trimChars), test.TrimEnd(trimChars.AsSpan()));
        }


        [TestMethod]
        public void TrimEndTest4()
        {
            string test = "    ";
            Assert.AreEqual(test.TrimEnd(null), test.TrimEnd(ReadOnlySpan<char>.Empty));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrimEndTest5()
        {
            string? test = null;
            _ = test!.TrimEnd(ReadOnlySpan<char>.Empty);
        }

        [TestMethod]
        public void TrimEndTest6()
        {
            char[] trimChars = new char[] { '\'', '\"' };

            string test = "Test";
            Assert.AreEqual(test.TrimEnd(trimChars), test.TrimEnd(trimChars.AsSpan()));
        }
    }
}