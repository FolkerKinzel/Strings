using System;
using System.Text;
using FolkerKinzel.Strings.Polyfills;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Tests
{
    [TestClass]
    public class StringBuilderExtensionTests
    {
        [TestMethod]
        public void NormalizeNewLinesToTest1()
        {
            const string input = "1\r\n\n\r2\r3\n\n4\r\n";
            const string expected = "1**2*3**4*";

            var sb = new StringBuilder(input);

            string output = sb.NormalizeNewLinesTo("*").ToString();
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void ReplaceWhiteSpaceWithTest1()
        {
            const string original = "    This  Is Text   ";
            const string result = "ThisIsText";

            var sb = new StringBuilder(original);

            Assert.AreEqual(sb, sb.ReplaceWhiteSpaceWith(""));
            Assert.AreEqual(result, sb.ToString());
        }

        


        [DataTestMethod]
        [DataRow("abcabc", 'b', 4)]
        [DataRow("abcabc", 'y', -1)]
        [DataRow("xbcabc", 'x', 0)]
        [DataRow("abcabq", 'q', 5)]
        [DataRow("", 'a', -1)]
        public void LastIndexOfTest1(string testStr, char needle, int expectedIndex)
        {
            var sb = new StringBuilder(testStr);
            Assert.AreEqual(expectedIndex, sb.LastIndexOf(needle));
        }

        [DataTestMethod]
        [DataRow("abcabc", 'b', 4, 4)]
        [DataRow("abcabc", 'b', 3, 1)]
        [DataRow("abcabc", 'y', 5, -1)]
        [DataRow("xbcabc", 'x', 3, 0)]
        [DataRow("abcabq", 'q', 5, 5)]
        [DataRow("abcabq", 'q', 4, -1)]
        [DataRow("", 'a', 0, -1)]
        public void LastIndexOfTest5(string testStr, char needle, int startIndex, int expectedIndex)
        {
            var sb = new StringBuilder(testStr);
            Assert.AreEqual(expectedIndex, sb.LastIndexOf(needle, startIndex));
        }

        [DataTestMethod]
        [DataRow("abcabc", 'b', 4, 2, 4)]
        [DataRow("abcabc", 'b', 3, 3, 1)]
        [DataRow("abcabc", 'b', 3, 2, -1)]
        [DataRow("abcabc", 'y', 5, 6, -1)]
        [DataRow("xbcabc", 'x', 3, 4, 0)]
        [DataRow("xbcabc", 'x', 3, 3, -1)]
        [DataRow("abcabq", 'q', 5, 1, 5)]
        [DataRow("abcabq", 'q', 4, 5, -1)]
        [DataRow("", 'a', 0, 0, -1)]
        public void LastIndexOfTest5(string testStr, char needle, int startIndex, int count, int expectedIndex)
        {
            var sb = new StringBuilder(testStr);
            Assert.AreEqual(expectedIndex, sb.LastIndexOf(needle, startIndex, count));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LastIndexOfTest2()
        {
            StringBuilder? sb = null;
            _ = sb!.LastIndexOf('a');
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LastIndexOfTest3()
        {
            StringBuilder? sb = null;
            _ = sb!.LastIndexOf('a', 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LastIndexOfTest4()
        {
            StringBuilder? sb = null;
            _ = sb!.LastIndexOf('a', 0, 0);
        }

        [DataTestMethod]
        [DataRow(0,1)]
        [DataRow(1,0)]
        [DataRow(1,1)]
        [DataRow(-1,0)]
        [DataRow(0,-1)]
        [DataRow(-1,1)]
        [DataRow(1,-1)]
        public void LastIndexOfTest8(int startIndex, int count)
        {
            var sb = new StringBuilder();
            _ = sb.LastIndexOf('a', startIndex, count);
            _ = "".LastIndexOf('a', startIndex, count);
        }

        [DataTestMethod]
        [DataRow(0,2)]
        //[DataRow(2,0)]
        [DataRow(2,2)]
        //[DataRow(-1,0)]
        [DataRow(0,-1)]
        [DataRow(-1,1)]
        [DataRow(1,-1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LastIndexOfTest9(int startIndex, int count)
        {
            var sb = new StringBuilder("t");
            _ = sb.LastIndexOf('a', startIndex, count);
        }

        [TestMethod]
        public void IndexOfTest1() => Assert.AreEqual(1, new StringBuilder("testen").IndexOf('e'));

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IndexOfTest2()
        {
            StringBuilder? sb = null;
            _ = sb!.IndexOf('e');
        }

        [TestMethod]
        public void IndexOfTest3()
            => Assert.AreEqual(1, new StringBuilder("testen").IndexOf('e', 0));

        [TestMethod]
        public void IndexOfTest14()
        {
            const string test = "testen";
            Assert.AreEqual(1, new StringBuilder(test).IndexOf('e', 0));
            Assert.AreEqual(1, new StringBuilder(test).IndexOf('e', 1));
            Assert.AreEqual(4, new StringBuilder(test).IndexOf('e', 2));
            Assert.AreEqual(-1, new StringBuilder(test).IndexOf('e', 2, 2));
            Assert.AreEqual(4, new StringBuilder(test).IndexOf('e', 2, 3));
        }

        [TestMethod]
        public void IndexOfTest4()
        {
            const string input = "testen";
            Assert.AreEqual(1, new StringBuilder(input).IndexOf('e', 0, input.Length));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IndexOfTest5()
        {
            StringBuilder? sb = null;
            _ = sb!.IndexOf('e', 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IndexOfTest6()
        {
            StringBuilder? sb = null;
            _ = sb!.IndexOf('e', 0, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexOfTest7() => _ = new StringBuilder().IndexOf('e', -1);

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexOfTest8() => _ = new StringBuilder().IndexOf('e', -1, -1);

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexOfTest11() => _ = new StringBuilder().IndexOf('e', 0, -1);

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexOfTest9() => _ = new StringBuilder().IndexOf('e', 4711);

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexOfTest10() => _ = new StringBuilder().IndexOf('e', 0, 4711);

        [TestMethod]
        public void ContainsTest1()
        {
            var sb = new StringBuilder("test");

            Assert.IsTrue(sb.Contains('e'));
            Assert.IsFalse(sb.Contains('E'));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsTest2()
        {
            StringBuilder? sb = null;
            _ = sb!.Contains('e');
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToLowerInvariantTest1()
        {
            StringBuilder? sb = null;
            _ = sb!.ToLowerInvariant();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToLowerInvariantTest2()
        {
            var sb = new StringBuilder();
            _ = sb.ToLowerInvariant(-15);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToLowerInvariantTest3()
        {
            var sb = new StringBuilder();
            _ = sb.ToLowerInvariant(0, 4711);
        }

        [TestMethod]
        public void ToLowerInvariantTest4()
        {
            var sb = new StringBuilder("TEST");
            Assert.AreEqual("test", sb.ToLowerInvariant().ToString());
        }

        [TestMethod]
        public void ToLowerInvariantTest12()
        {
            var sb = new StringBuilder("TEST");
            Assert.AreEqual("Test", sb.ToLowerInvariant(1).ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToLowerInvariantTest5()
        {
            StringBuilder? sb = null;
            _ = sb!.ToLowerInvariant(17);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToLowerInvariantTest6()
        {
            StringBuilder? sb = null;
            _ = sb!.ToLowerInvariant(17, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToLowerInvariantTest7()
        {
            var sb = new StringBuilder();
            _ = sb.ToLowerInvariant(0, -4711);
        }

        [TestMethod]
        public void ToLowerInvariantTest8()
        {
            var sb = new StringBuilder();
            _ = sb.ToLowerInvariant(0, 0);
        }

        [TestMethod]
        public void ToLowerInvariantTest9()
        {
            var sb = new StringBuilder();
            _ = sb.ToLowerInvariant(0);
        }

        [TestMethod]
        public void ToLowerInvariantTest10()
        {
            var sb = new StringBuilder();
            _ = sb.ToLowerInvariant();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToUpperInvariantTest1()
        {
            StringBuilder? sb = null;
            _ = sb!.ToUpperInvariant();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToUpperInvariantTest2()
        {
            var sb = new StringBuilder();
            _ = sb.ToUpperInvariant(-15);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToUpperInvariantTest3()
        {
            var sb = new StringBuilder();
            _ = sb.ToUpperInvariant(0, 4711);
        }

        [TestMethod]
        public void ToUpperInvariantTest4()
        {
            var sb = new StringBuilder("test");
            Assert.AreEqual("TEST", sb.ToUpperInvariant().ToString());
        }

        [TestMethod]
        public void ToUpperInvariantTest12()
        {
            var sb = new StringBuilder("test");
            Assert.AreEqual("tEST", sb.ToUpperInvariant(1).ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToUpperInvariantTest5()
        {
            StringBuilder? sb = null;
            _ = sb!.ToUpperInvariant(17);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToUpperInvariantTest6()
        {
            StringBuilder? sb = null;
            _ = sb!.ToUpperInvariant(17, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToUpperInvariantTest7()
        {
            var sb = new StringBuilder();
            _ = sb.ToUpperInvariant(0, -4711);
        }

        [TestMethod]
        public void ToUpperInvariantTest8()
        {
            var sb = new StringBuilder();
            _ = sb.ToUpperInvariant(0, 0);
        }

        [TestMethod]
        public void ToUpperInvariantTest9()
        {
            var sb = new StringBuilder();
            _ = sb.ToUpperInvariant(0);
        }

        [TestMethod]
        public void ToUpperInvariantTest10()
        {
            var sb = new StringBuilder();
            _ = sb.ToUpperInvariant();
        }

        [DataTestMethod]
        [DataRow("   ")]
        [DataRow("")]
        public void GetTrimmedStartTest1(string s) => Assert.AreEqual(s.Length, s.AsSpan().GetTrimmedStart());

        [DataTestMethod]
        [DataRow("ab@c%", true)]
        [DataRow("%", true)]
        [DataRow("test", false)]
        [DataRow("", false)]
        public void ContainsAnyTest1(string s, bool expected)
            => Assert.AreEqual(expected, s.AsSpan().ContainsAny(stackalloc char[] { '%', '@' }));


        [DataTestMethod]
        [DataRow("", false)]
        [DataRow(null, false)]
        [DataRow("Test", false)]
        [DataRow("Märchen", true)]
        public void ContainsNonAsciiTest1(string? input, bool expected)
            => Assert.AreEqual(expected, new StringBuilder(input).ContainsNonAscii());

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsNonAsciiTest2()
        {
            StringBuilder? sb = null;
            _ = sb!.ContainsNonAscii();
        }

        [DataTestMethod]
        [DataRow("", false)]
        [DataRow(null, false)]
        [DataRow("Test", false)]
        [DataRow("Märchen", true)]
        public void ContainsNonAsciiTest3(string? input, bool expected)
            => Assert.AreEqual(expected, new StringBuilder(input).ContainsNonAscii(0));


        [DataTestMethod]
        [DataRow("", false)]
        [DataRow("Test", false)]
        [DataRow("Märchen", true)]
        public void ContainsNonAsciiTest4(string input, bool expected)
            => Assert.AreEqual(expected, new StringBuilder(input).ContainsNonAscii(0, input.Length));


        [TestMethod]
        public void ContainsNonAsciiTest14()
        {
            const string test = "Märchenbücher";
            var sb = new StringBuilder(test);
            Assert.IsTrue(sb.ContainsNonAscii(0));
            Assert.IsFalse(sb.ContainsNonAscii(9));
            Assert.IsFalse(sb.ContainsNonAscii(9, 4));
            Assert.IsTrue(sb.ContainsNonAscii(8, 2));
            Assert.IsFalse(sb.ContainsNonAscii(2, 5));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsNonAsciiTest5()
        {
            StringBuilder? sb = null;
            _ = sb!.ContainsNonAscii(0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsNonAsciiTest6()
        {
            StringBuilder? sb = null;
            _ = sb!.ContainsNonAscii(0, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ContainsNonAsciiTest7() => _ = new StringBuilder().ContainsNonAscii(-1);

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ContainsNonAsciiTest8() => _ = new StringBuilder().ContainsNonAscii(-1, -1);

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ContainsNonAsciiTest11() => _ = new StringBuilder().ContainsNonAscii(0, -1);

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ContainsNonAsciiTest9() => _ = new StringBuilder().ContainsNonAscii(4711);

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ContainsNonAsciiTest10() => _ = new StringBuilder().ContainsNonAscii(0, 4711);

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