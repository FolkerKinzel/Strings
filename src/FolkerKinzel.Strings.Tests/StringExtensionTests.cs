using Microsoft.VisualStudio.TestTools.UnitTesting;
using FolkerKinzel.Strings;
using System;
using System.Collections.Generic;
using System.Text;

namespace FolkerKinzel.Strings.Tests
{
    [TestClass()]
    public class StringExtensionTests
    {
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