using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Tests
{
    [TestClass]
    public class StringBuilderExtensionTests
    {
        [DataTestMethod]
        [DataRow("", false)]
        [DataRow(null, false)]
        [DataRow("Test", false)]
        [DataRow("Märchen", true)]
        public void ContainsNonAsciiTest1(string? input, bool expected) => Assert.AreEqual(expected, new StringBuilder(input).ContainsNonAscii());

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsNonAsciiTest2()
        {
            StringBuilder? sb = null;
            _ = sb!.ContainsNonAscii();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPersistentHashCodeTest1()
        {
            StringBuilder? sb = null;
            _ = sb!.GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void GetPersistentHashCodeTest2()
        {
            var sb = new StringBuilder();
            _ = sb.GetPersistentHashCode((HashType)4711);
        }

        [TestMethod()]
        public void GetPersistentHashCodeTest6()
        {
            const string s = "Hallo, dies ist Text.";
            int hash1 = s.GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);
            int hash2 = s.AsSpan().GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);
            int hash3 = new StringBuilder().Append(s).GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);

            Assert.AreEqual(hash1, hash2);
            Assert.AreEqual(hash1, hash3);
        }

        [TestMethod()]
        public void GetPersistentHashCodeTest7()
        {
            const string s = "Hallo, dies ist Text.";
            int hash1 = s.GetPersistentHashCode(HashType.OrdinalIgnoreCase);
            int hash2 = s.AsSpan().GetPersistentHashCode(HashType.OrdinalIgnoreCase);
            int hash3 = new StringBuilder().Append(s).GetPersistentHashCode(HashType.OrdinalIgnoreCase);

            Assert.AreEqual(hash1, hash2);
            Assert.AreEqual(hash1, hash3);
        }

        [TestMethod()]
        public void GetPersistentHashCodeTest8()
        {
            const string s = "Hallo, dies ist Text.";
            int hash1 = s.GetPersistentHashCode(HashType.Ordinal);
            int hash2 = s.AsSpan().GetPersistentHashCode(HashType.Ordinal);
            int hash3 = new StringBuilder().Append(s).GetPersistentHashCode(HashType.Ordinal);

            Assert.AreEqual(hash1, hash2);
            Assert.AreEqual(hash1, hash3);
        }


        [DataTestMethod()]
        [DataRow("    Test    ")]
        public void TrimTest1(string input)
        {
            var sb = new StringBuilder(input);
            Assert.AreEqual(input.Trim(), sb.Trim().ToString());
        }

        [DataTestMethod()]
        [DataRow("    Test    ", ' ')]
        public void TrimTest2(string input, char trimChar)
        {
            var sb = new StringBuilder(input);
            Assert.AreEqual(input.Trim(trimChar), sb.Trim(trimChar).ToString());
        }


        [TestMethod()]
        public void TrimTest3()
        {
            char[] trimChars = new char[] { '\"', '\'' };
            string input = "\'\"Test\'\"";

            var sb = new StringBuilder(input);
            Assert.AreEqual(input.Trim(trimChars), sb.Trim(trimChars).ToString());
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrimTest4()
        {
            char[] trimChars = new char[] { '\"', '\'' };

            StringBuilder? sb = null;
            _ = sb!.Trim(trimChars);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrimTest5()
        {
            StringBuilder? sb = null;
            _ = sb!.Trim(' ');
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrimTest6()
        {
            StringBuilder? sb = null;
            _ = sb!.Trim();
        }

        [TestMethod()]
        public void TrimTest7()
        {
            string input = "  Test   ";

            var sb = new StringBuilder(input);
            Assert.AreEqual(input.Trim(null), sb.Trim(null).ToString());
        }

        [TestMethod()]
        public void TrimTest8()
        {
#if NET45
            char[] trimChars = new char[0];
#else
            char[] trimChars = Array.Empty<char>();
#endif
            string input = "   Test   ";

            var sb = new StringBuilder(input);
            Assert.AreEqual(input.Trim(trimChars), sb.Trim(trimChars).ToString());
        }


        [TestMethod()]
        public void TrimTest9()
        {
            char[] trimChars = new char[] { '\"', '\'' };
            string input = "\'\"Test\'\"";

            var sb = new StringBuilder(input);
            Assert.AreEqual(input.Trim(trimChars), sb.Trim(trimChars.AsSpan()).ToString());
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrimTest10()
        {
            char[] trimChars = new char[] { '\"', '\'' };

            StringBuilder? sb = null;
            _ = sb!.Trim(trimChars.AsSpan());
        }

        [TestMethod()]
        public void TrimTest11()
        {
#if NET45
            char[] trimChars = new char[0];
#else
            char[] trimChars = Array.Empty<char>();
#endif
            string input = "   Test   ";

            var sb = new StringBuilder(input);
            Assert.AreEqual(input.Trim(trimChars), sb.Trim(trimChars.AsSpan()).ToString());
        }


        [DataTestMethod()]
        [DataRow("    Test    ")]
        public void TrimStartTest1(string input)
        {
            var sb = new StringBuilder(input);
            Assert.AreEqual(input.TrimStart(), sb.TrimStart().ToString());
        }

        [DataTestMethod()]
        [DataRow("    Test    ", ' ')]
        public void TrimStartTest2(string input, char trimChar)
        {
            var sb = new StringBuilder(input);
            Assert.AreEqual(input.TrimStart(trimChar), sb.TrimStart(trimChar).ToString());
        }


        [TestMethod()]
        public void TrimStartTest3()
        {
            char[] trimChars = new char[] { '\"', '\'' };
            string input = "\'\"Test\'\"";

            var sb = new StringBuilder(input);
            Assert.AreEqual(input.TrimStart(trimChars), sb.TrimStart(trimChars).ToString());
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrimStartTest4()
        {
            char[] trimChars = new char[] { '\"', '\'' };

            StringBuilder? sb = null;
            _ = sb!.TrimStart(trimChars);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrimStartTest5()
        {
            StringBuilder? sb = null;
            _ = sb!.TrimStart(' ');
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrimStartTest6()
        {
            StringBuilder? sb = null;
            _ = sb!.TrimStart();
        }

        [TestMethod()]
        public void TrimStartTest7()
        {
            string test = "    ";
            var sb = new StringBuilder(test);
            Assert.AreEqual(test.TrimStart(), sb.TrimStart().ToString());
        }

        [TestMethod()]
        public void TrimStartTest8()
        {
            string test = "xxxxx";
            var sb = new StringBuilder(test);
            Assert.AreEqual(test.TrimStart('x'), sb.TrimStart('x').ToString());
        }

        [TestMethod()]
        public void TrimStartTest9()
        {
            string test = "xyyx";
            var sb = new StringBuilder(test);
            Assert.AreEqual(test.TrimStart('x', 'y'), sb.TrimStart('x', 'y').ToString());
        }


        [TestMethod()]
        public void TrimStartTest10()
        {
            string input = "  Test   ";

            var sb = new StringBuilder(input);
            Assert.AreEqual(input.TrimStart(null), sb.TrimStart(null).ToString());
        }

        [TestMethod()]
        public void TrimStartTest11()
        {
#if NET45
            char[] trimChars = new char[0];
#else
            char[] trimChars = Array.Empty<char>();
#endif
            string input = "   Test   ";

            var sb = new StringBuilder(input);
            Assert.AreEqual(input.TrimStart(trimChars), sb.TrimStart(trimChars).ToString());
        }

        [TestMethod()]
        public void TrimStartTest12()
        {
            char[] trimChars = new char[] { '\"', '\'' };
            string input = "\'\"Test\'\"";

            var sb = new StringBuilder(input);
            Assert.AreEqual(input.TrimStart(trimChars), sb.TrimStart(trimChars.AsSpan()).ToString());
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrimStartTest13()
        {
            char[] trimChars = new char[] { '\"', '\'' };

            StringBuilder? sb = null;
            _ = sb!.TrimStart(trimChars.AsSpan());
        }

        [TestMethod()]
        public void TrimStartTest14()
        {
#if NET45
            char[] trimChars = new char[0];
#else
            char[] trimChars = Array.Empty<char>();
#endif
            string input = "   Test   ";

            var sb = new StringBuilder(input);
            Assert.AreEqual(input.TrimStart(trimChars), sb.TrimStart(trimChars.AsSpan()).ToString());
        }


        [DataTestMethod()]
        [DataRow("    Test    ")]
        public void TrimEndTest1(string input)
        {
            var sb = new StringBuilder(input);
            Assert.AreEqual(input.TrimEnd(), sb.TrimEnd().ToString());
        }

        [DataTestMethod()]
        [DataRow("    Test    ", ' ')]
        public void TrimEndTest2(string input, char trimChar)
        {
            var sb = new StringBuilder(input);
            Assert.AreEqual(input.TrimEnd(trimChar), sb.TrimEnd(trimChar).ToString());
        }


        [TestMethod()]
        public void TrimEndTest3()
        {
            char[] trimChars = new char[] { '\"', '\'' };
            string input = "\'\"Test\'\"";

            var sb = new StringBuilder(input);
            Assert.AreEqual(input.TrimEnd(trimChars), sb.TrimEnd(trimChars).ToString());
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrimEndTest4()
        {
            char[] trimChars = new char[] { '\"', '\'' };

            StringBuilder? sb = null;
            _ = sb!.TrimEnd(trimChars);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrimEndTest5()
        {
            StringBuilder? sb = null;
            _ = sb!.TrimEnd(' ');
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrimEndTest6()
        {
            StringBuilder? sb = null;
            _ = sb!.TrimEnd();
        }

        [TestMethod()]
        public void TrimEndTest7()
        {
            string input = "  Test   ";

            var sb = new StringBuilder(input);
            Assert.AreEqual(input.TrimEnd(null), sb.TrimEnd(null).ToString());
        }

        [TestMethod()]
        public void TrimEndTest8()
        {
#if NET45
            char[] trimChars = new char[0];
#else
            char[] trimChars = Array.Empty<char>();
#endif
            string input = "   Test   ";

            var sb = new StringBuilder(input);
            Assert.AreEqual(input.TrimEnd(trimChars), sb.TrimEnd(trimChars).ToString());
        }

        [TestMethod()]
        public void TrimEndTest9()
        {
            char[] trimChars = new char[] { '\"', '\'' };
            string input = "\'\"Test\'\"";

            var sb = new StringBuilder(input);
            Assert.AreEqual(input.TrimEnd(trimChars), sb.TrimEnd(trimChars.AsSpan()).ToString());
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrimEndTest10()
        {
            char[] trimChars = new char[] { '\"', '\'' };

            StringBuilder? sb = null;
            _ = sb!.TrimEnd(trimChars.AsSpan());
        }

        [TestMethod()]
        public void TrimEndTest11()
        {
#if NET45
            char[] trimChars = new char[0];
#else
            char[] trimChars = Array.Empty<char>();
#endif
            string input = "   Test   ";

            var sb = new StringBuilder(input);
            Assert.AreEqual(input.TrimEnd(trimChars), sb.TrimEnd(trimChars.AsSpan()).ToString());
        }

    }
}