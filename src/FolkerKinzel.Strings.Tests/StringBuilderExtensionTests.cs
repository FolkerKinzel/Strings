using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Tests;

[TestClass]
public class StringBuilderExtensionTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ReplaceTest1()
    {
        StringBuilder? sb = null;
        sb!.Replace("abc", "", 0);

    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ReplaceTest2()
    {
        StringBuilder? sb = null;
        sb!.Replace('a', 'b', 0);

    }

    [TestMethod]
    public void ReplaceTest3()
    {
        var sb = new StringBuilder("aaa");
        sb.Replace("a", "bb", 1);
        Assert.AreEqual("abbbb", sb.ToString());
    }

    [TestMethod]
    public void ReplaceTest4()
    {
        var sb = new StringBuilder("aaa");
        sb.Replace("a", null, 1);
        Assert.AreEqual("a", sb.ToString());
    }

    [TestMethod]
    public void ReplaceTest5()
    {
        var sb = new StringBuilder("aaa");
        sb.Replace('a', 'b', 1);
        Assert.AreEqual("abb", sb.ToString());

    }

    [TestMethod]
    public void AppendNewLineTest1()
    {
        const string test = "hi";

        var builder = new StringBuilder();

        Assert.AreEqual(builder, builder.AppendLine(test.AsSpan()));
        Assert.AreEqual(builder.ToString(), new StringBuilder().AppendLine(test).ToString());
    }

    [TestMethod]
    public void AppendNewLineTest2()
    {
        const string test = "hi";

        var builder = new StringBuilder();

        Assert.AreEqual(builder, builder.AppendLine(test.AsMemory()));
        Assert.AreEqual(builder.ToString(), new StringBuilder().AppendLine(test).ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ReplaceLineEndingsTest1()
    {
        StringBuilder? sb = null;
        _ = sb!.ReplaceLineEndings("");
    }

    [TestMethod]
    public void ReplaceLineEndingsTest2()
    {
        const string input = "\n1\r\n\n\r2\r3\n\n4\r\n5\u000B6\u000C\n7\u00858\u20289\u2029";
        const string expected = "*1***2*3**4*5\u000B6**7*8*9*";

        string output = new StringBuilder(input).ReplaceLineEndings("*").ToString();
        Assert.AreEqual(expected, output);
    }

    [TestMethod]
    public void ReplaceLineEndingsTest3()
    {
        const string s = "Hi\n";
        string output = new StringBuilder(s).ReplaceLineEndings(null).ToString();
        Assert.AreEqual("Hi", output);
    }


    [TestMethod]
    public void ReplaceWhiteSpaceWithTest1()
    {
        const string original = "    This  Is Text   ";
        const string result = "ThisIsText";

        var sb = new StringBuilder(original);

        Assert.AreEqual(sb, sb.ReplaceWhiteSpaceWith("".AsSpan()));
        Assert.AreEqual(result, sb.ToString());
    }

    [DataTestMethod]
    [DataRow(-1)]
    [DataRow(1)]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void ReplaceWhiteSpaceWithTest2(int startIndex) => _ = new StringBuilder().ReplaceWhiteSpaceWith("".AsSpan(), startIndex);

    [DataTestMethod]
    [DataRow(-1)]
    [DataRow(1)]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void ReplaceWhiteSpaceWithTest3(int count) => _ = new StringBuilder().ReplaceWhiteSpaceWith("".AsSpan(), 0, count);

    [TestMethod]
    public void ReplaceWhitespaceWithTest4()
        => Assert.AreEqual("*Test*\r\n*text*", new StringBuilder("\t Test   \r\n text  ").ReplaceWhiteSpaceWith("*".AsSpan(), true).ToString());


    [TestMethod]
    public void ReplaceWhitespaceWithTest6()
        => Assert.AreEqual("*Test*text*", new StringBuilder("\t Test   \r\n text  ").ReplaceWhiteSpaceWith("*".AsSpan(), false).ToString());

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ReplaceWhiteSpaceWithTest7()
    {
        StringBuilder? sb = null;
        _ = sb!.ReplaceWhiteSpaceWith("".AsSpan());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ReplaceWhiteSpaceWithTest8()
    {
        StringBuilder? sb = null;
        _ = sb!.ReplaceWhiteSpaceWith("".AsSpan(), 0);
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
    [DataRow(0, 1)]
    [DataRow(1, 0)]
    [DataRow(1, 1)]
    [DataRow(-1, 0)]
    [DataRow(0, -1)]
    [DataRow(-1, 1)]
    [DataRow(1, -1)]
    public void LastIndexOfTest8(int startIndex, int count)
    {
        var sb = new StringBuilder();
        _ = sb.LastIndexOf('a', startIndex, count);
        _ = "".LastIndexOf('a', startIndex, count);
    }

    [DataTestMethod]
    [DataRow(0, 2)]
    //[DataRow(2,0)]
    [DataRow(2, 2)]
    //[DataRow(-1,0)]
    [DataRow(0, -1)]
    [DataRow(-1, 1)]
    [DataRow(1, -1)]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void LastIndexOfTest9(int startIndex, int count)
    {
        var sb = new StringBuilder("t");
        _ = sb.LastIndexOf('a', startIndex, count);
    }

    [DataTestMethod]
    [DataRow(-1)]
    [DataRow(4711)]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void LastIndexOfTest9b(int startIndex)
    {
        var sb = new StringBuilder("t");
        _ = sb.LastIndexOf('a', startIndex);
    }

    [TestMethod]
    public void LastIndexOfTest10()
    {
        const string test = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        Assert.AreEqual(-1, new StringBuilder(test).LastIndexOf('x'));
        Assert.AreEqual(test.Length - 1, new StringBuilder(test).LastIndexOf('a'));
    }

    [TestMethod]
    public void LastIndexOfTest11()
    {
        var builder = new StringBuilder("a");
        builder.Append("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaax");
        Assert.AreEqual(builder.Length - 1, builder.LastIndexOf('x', builder.Length - 1, 1));
    }

    [TestMethod]
    public void LastIndexOfTest12()
    {
        var builder = new StringBuilder("x");
        builder.Append("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        Assert.AreEqual(0, builder.LastIndexOf('x', builder.Length - 1, builder.Length));
    }

    [TestMethod]
    public void LastIndexOfTest14()
    {
        var builder = new StringBuilder("x");
        builder.Append("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        Assert.AreEqual(0, builder.LastIndexOf('x', 0, 1));
    }

    [TestMethod]
    public void LastIndexOfTest14b()
    {
        var builder = new StringBuilder("x");
        builder.Append("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaax");
        Assert.AreEqual(-1, builder.LastIndexOf('x', builder.Length - 2, builder.Length - 2));
    }

    [TestMethod]
    public void LastIndexOfTest14c()
    {
        var builder = new StringBuilder("x");
        builder.Append("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaax");
        Assert.AreEqual(0, builder.LastIndexOf('x', builder.Length - 2, builder.Length - 1));
    }

    [TestMethod]
    public void LastIndexOfTest14d()
    {
        var builder = new StringBuilder("x");
        builder.Append("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaxa");
        Assert.AreEqual(builder.Length - 2, builder.LastIndexOf('x', builder.Length - 1, 30));
    }

    [TestMethod]
    public void LastIndexOfTest15()
    {
        var builder = new StringBuilder("a");
        builder.Append("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        Assert.AreEqual(-1, builder.LastIndexOf('x', builder.Length - 1, builder.Length));
    }

    [TestMethod]
    public void LastIndexOfTest16() => Assert.AreEqual(-1, new StringBuilder().LastIndexOf('x', 0, 0));


    [TestMethod]
    public void IndexOfTest1() => Assert.AreEqual(1, new StringBuilder("testen").IndexOf('e'));


    [TestMethod]
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
    public void IndexOfTest4()
    {
        const string test = "testen";
        Assert.AreEqual(1, new StringBuilder(test).IndexOf('e', 0));
        Assert.AreEqual(1, new StringBuilder(test).IndexOf('e', 1));
        Assert.AreEqual(4, new StringBuilder(test).IndexOf('e', 2));
        Assert.AreEqual(-1, new StringBuilder(test).IndexOf('e', 2, 2));
        Assert.AreEqual(4, new StringBuilder(test).IndexOf('e', 2, 3));
    }

    [TestMethod]
    public void IndexOfTest5()
    {
        const string input = "testen";
        Assert.AreEqual(1, new StringBuilder(input).IndexOf('e', 0, input.Length));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void IndexOfTest6()
    {
        StringBuilder? sb = null;
        _ = sb!.IndexOf('e', 0);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void IndexOfTest7()
    {
        StringBuilder? sb = null;
        _ = sb!.IndexOf('e', 0, 0);
    }

    [DataTestMethod]
    [DataRow(-1)]
    [DataRow(4711)]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void IndexOfTest8(int startIndex) => _ = new StringBuilder().IndexOf('e', startIndex);

    [DataTestMethod]
    [DataRow(-1, -1)]
    [DataRow(0, -1)]
    [DataRow(0, 4711)]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void IndexOfTest9(int startIndex, int count) => _ = new StringBuilder().IndexOf('e', startIndex, count);

    [TestMethod]
    public void IndexOfTest10()
    {
        const string test = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        Assert.AreEqual(-1, new StringBuilder(test).IndexOf('x'));
        Assert.AreEqual(0, new StringBuilder(test).IndexOf('a'));
    }

    [TestMethod]
    public void IndexOfTest11()
    {
        var builder = new StringBuilder("a");
        builder.Append("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaax");
        Assert.AreEqual(builder.Length - 1, builder.IndexOf('x', builder.Length - 1, 1));
    }

    [TestMethod]
    public void IndexOfTest12()
    {
        var builder = new StringBuilder("a");
        builder.Append("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaax");
        Assert.AreEqual(builder.Length - 1, builder.IndexOf('x', 1, builder.Length - 1));
    }

    [TestMethod]
    public void IndexOfTest14()
    {
        var builder = new StringBuilder("x");
        builder.Append("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        Assert.AreEqual(0, builder.IndexOf('x', 0, builder.Length));
    }

    [TestMethod]
    public void IndexOfTest15()
    {
        var builder = new StringBuilder("a");
        builder.Append("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        Assert.AreEqual(-1, builder.IndexOf('x', 0, builder.Length));
    }

    [TestMethod]
    public void IndexOfTest16() => Assert.AreEqual(-1, new StringBuilder().IndexOf('x', 0, 0));

    //[TestMethod()]
    //[ExpectedException(typeof(ArgumentOutOfRangeException))]
    //public void IndexOfTest11() => _ = new StringBuilder().IndexOf('e', 0, -1);

    //[TestMethod()]
    //[ExpectedException(typeof(ArgumentOutOfRangeException))]
    //public void IndexOfTest9() => _ = new StringBuilder().IndexOf('e', 4711);

    //[TestMethod()]
    //[ExpectedException(typeof(ArgumentOutOfRangeException))]
    //public void IndexOfTest10() => _ = new StringBuilder().IndexOf('e', 0, 4711);

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
    public void ContainsTest5()
        => Assert.IsTrue(new StringBuilder("testen").Contains('e', 0));

    [TestMethod]
    public void ContainsTest6()
    {
        const string test = "testen";
        Assert.IsTrue(new StringBuilder(test).Contains('e', 0));
        Assert.IsTrue(new StringBuilder(test).Contains('e', 1));
        Assert.IsTrue(new StringBuilder(test).Contains('e', 2));
        Assert.IsFalse(new StringBuilder(test).Contains('e', 2, 2));
        Assert.IsTrue(new StringBuilder(test).Contains('e', 2, 3));
    }

    [TestMethod]
    public void ContainsTest7()
    {
        const string input = "testen";
        Assert.IsTrue(new StringBuilder(input).Contains('e', 0, input.Length));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ContainsTest8()
    {
        StringBuilder? sb = null;
        _ = sb!.Contains('e', 0);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ContainsTest9()
    {
        StringBuilder? sb = null;
        _ = sb!.Contains('e', 0, 0);
    }

    [DataTestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    [DataRow(-1)]
    [DataRow(4711)]
    public void ContainsTest10(int startIndex) => _ = new StringBuilder().Contains('e', startIndex);

    [DataTestMethod]
    [DataRow(-1, -1)]
    [DataRow(0, -1)]
    [DataRow(0, 4711)]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void ContainsTest11(int startIndex, int count) => _ = new StringBuilder().Contains('e', startIndex, count);


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

    //[DataTestMethod]
    //[DataRow("   ")]
    //[DataRow("")]
    //public void GetTrimmedStartTest1(string s) => Assert.AreEqual(s.Length, s.AsSpan().GetTrimmedStart());

    [DataTestMethod]
    [DataRow("ab@c%", true)]
    [DataRow("%", true)]
    [DataRow("test", false)]
    [DataRow("", false)]
    public void ContainsAnyTest1(string s, bool expected)
        => Assert.AreEqual(expected, s.AsSpan().ContainsAny("%@"));


    [DataTestMethod]
    [DataRow("", false)]
    [DataRow(null, false)]
    [DataRow("Test", false)]
    [DataRow("Märchen", true)]
    public void ContainsNonAsciiTest1(string? input, bool expected)
        => Assert.AreEqual(expected, new StringBuilder(input).ContainsNonAscii());

    [TestMethod]
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

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ContainsNonAsciiTest5()
    {
        StringBuilder? sb = null;
        _ = sb!.ContainsNonAscii(0);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ContainsNonAsciiTest6()
    {
        StringBuilder? sb = null;
        _ = sb!.ContainsNonAscii(0, 0);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void ContainsNonAsciiTest7() => _ = new StringBuilder().ContainsNonAscii(-1);

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void ContainsNonAsciiTest8() => _ = new StringBuilder().ContainsNonAscii(-1, -1);

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void ContainsNonAsciiTest11() => _ = new StringBuilder().ContainsNonAscii(0, -1);

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void ContainsNonAsciiTest9() => _ = new StringBuilder().ContainsNonAscii(4711);

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void ContainsNonAsciiTest10() => _ = new StringBuilder().ContainsNonAscii(0, 4711);

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetPersistentHashCodeTest1()
    {
        StringBuilder? sb = null;
        _ = sb!.GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GetPersistentHashCodeTest2()
    {
        var sb = new StringBuilder();
        _ = sb.GetPersistentHashCode((HashType)4711);
    }

    [TestMethod]
    public void GetPersistentHashCodeTest6()
    {
        const string s = "Hallo, Text.";
        int hash1 = s.GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);
        int hash2 = s.AsSpan().GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);
        int hash3 = new StringBuilder().Append(s).GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);

        Assert.AreEqual(hash1, hash2);
        Assert.AreEqual(hash1, hash3);
    }

    [TestMethod]
    public void GetPersistentHashCodeTest6b()
    {
        const string s = "Hallo, Texte ";
        int hash1 = s.GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);
        int hash2 = s.AsSpan().GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);
        int hash3 = new StringBuilder().Append(s).GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);

        Assert.AreEqual(hash1, hash2);
        Assert.AreEqual(hash1, hash3);
    }

    [TestMethod]
    public void GetPersistentHashCodeTest7()
    {
        const string s = "Hallo, Text.";
        int hash1 = s.GetPersistentHashCode(HashType.OrdinalIgnoreCase);
        int hash2 = s.AsSpan().GetPersistentHashCode(HashType.OrdinalIgnoreCase);
        int hash3 = new StringBuilder().Append(s).GetPersistentHashCode(HashType.OrdinalIgnoreCase);

        Assert.AreEqual(hash1, hash2);
        Assert.AreEqual(hash1, hash3);
    }

    [TestMethod]
    public void GetPersistentHashCodeTest7b()
    {
        const string s = "Hallo, Text .";
        int hash1 = s.GetPersistentHashCode(HashType.OrdinalIgnoreCase);
        int hash2 = s.AsSpan().GetPersistentHashCode(HashType.OrdinalIgnoreCase);
        int hash3 = new StringBuilder().Append(s).GetPersistentHashCode(HashType.OrdinalIgnoreCase);

        Assert.AreEqual(hash1, hash2);
        Assert.AreEqual(hash1, hash3);
    }

    [TestMethod]
    public void GetPersistentHashCodeTest8()
    {
        const string s = "Hallo, Text.";
        int hash1 = s.GetPersistentHashCode(HashType.Ordinal);
        int hash2 = s.AsSpan().GetPersistentHashCode(HashType.Ordinal);
        int hash3 = new StringBuilder().Append(s).GetPersistentHashCode(HashType.Ordinal);

        Assert.AreEqual(hash1, hash2);
        Assert.AreEqual(hash1, hash3);
    }

    [TestMethod]
    public void GetPersistentHashCodeTest8b()
    {
        const string s = "Hallo, Text .";
        int hash1 = s.GetPersistentHashCode(HashType.Ordinal);
        int hash2 = s.AsSpan().GetPersistentHashCode(HashType.Ordinal);
        int hash3 = new StringBuilder().Append(s).GetPersistentHashCode(HashType.Ordinal);

        Assert.AreEqual(hash1, hash2);
        Assert.AreEqual(hash1, hash3);
    }

    [TestMethod]
    public void GetPersistentHashCodeTest9()
    {
        const string s = "ääääääääääääääääääääääääääääääääääääääääääääääääääääääääääääääää";
        int hash1 = s.GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);
        int hash2 = new StringBuilder(s).GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);

        Assert.AreEqual(hash1, hash2);
    }


    [DataTestMethod]
    [DataRow("    Test    ")]
    public void TrimTest1(string input)
    {
        var sb = new StringBuilder(input);
        Assert.AreEqual(input.Trim(), sb.Trim().ToString());
    }

    [DataTestMethod]
    [DataRow("    Test    ", ' ')]
    public void TrimTest2(string input, char trimChar)
    {
        var sb = new StringBuilder(input);
        Assert.AreEqual(input.Trim(trimChar), sb.Trim(trimChar).ToString());
    }


    [TestMethod]
    public void TrimTest3()
    {
        char[] trimChars = ['\"', '\''];
        string input = "\'\"Test\'\"";

        var sb = new StringBuilder(input);
        Assert.AreEqual(input.Trim(trimChars), sb.Trim(trimChars).ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TrimTest4()
    {
        char[] trimChars = ['\"', '\''];

        StringBuilder? sb = null;
        _ = sb!.Trim(trimChars);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TrimTest5()
    {
        StringBuilder? sb = null;
        _ = sb!.Trim(' ');
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TrimTest6()
    {
        StringBuilder? sb = null;
        _ = sb!.Trim();
    }

    [TestMethod]
    public void TrimTest7()
    {
        string input = "  Test   ";

        var sb = new StringBuilder(input);
        Assert.AreEqual(input.Trim(null), sb.Trim("").ToString());
    }

    [TestMethod]
    public void TrimTest8()
    {
        char[] trimChars = [];
        string input = "   Test   ";

        var sb = new StringBuilder(input);
        Assert.AreEqual(input.Trim(trimChars), sb.Trim(trimChars).ToString());
    }


    [TestMethod]
    public void TrimTest9()
    {
        char[] trimChars = ['\"', '\''];
        string input = "\'\"Test\'\"";

        var sb = new StringBuilder(input);
        Assert.AreEqual(input.Trim(trimChars), sb.Trim(trimChars.AsSpan()).ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TrimTest10()
    {
        char[] trimChars = ['\"', '\''];

        StringBuilder? sb = null;
        _ = sb!.Trim(trimChars.AsSpan());
    }

    [TestMethod]
    public void TrimTest11()
    {
        char[] trimChars = [];
        string input = "   Test   ";

        var sb = new StringBuilder(input);
        Assert.AreEqual(input.Trim(trimChars), sb.Trim(trimChars.AsSpan()).ToString());
    }


    [DataTestMethod]
    [DataRow("    Test    ")]
    public void TrimStartTest1(string input)
    {
        var sb = new StringBuilder(input);
        Assert.AreEqual(input.TrimStart(), sb.TrimStart().ToString());
    }

    [DataTestMethod]
    [DataRow("    Test    ", ' ')]
    public void TrimStartTest2(string input, char trimChar)
    {
        var sb = new StringBuilder(input);
        Assert.AreEqual(input.TrimStart(trimChar), sb.TrimStart(trimChar).ToString());
    }


    [TestMethod]
    public void TrimStartTest3()
    {
        char[] trimChars = ['\"', '\''];
        string input = "\'\"Test\'\"";

        var sb = new StringBuilder(input);
        Assert.AreEqual(input.TrimStart(trimChars), sb.TrimStart(trimChars).ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TrimStartTest4()
    {
        char[] trimChars = ['\"', '\''];

        StringBuilder? sb = null;
        _ = sb!.TrimStart(trimChars);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TrimStartTest5()
    {
        StringBuilder? sb = null;
        _ = sb!.TrimStart(' ');
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TrimStartTest6()
    {
        StringBuilder? sb = null;
        _ = sb!.TrimStart();
    }

    [TestMethod]
    public void TrimStartTest7()
    {
        string test = "    ";
        var sb = new StringBuilder(test);
        Assert.AreEqual(test.TrimStart(), sb.TrimStart().ToString());
    }

    [TestMethod]
    public void TrimStartTest8()
    {
        string test = "xxxxx";
        var sb = new StringBuilder(test);
        Assert.AreEqual(test.TrimStart('x'), sb.TrimStart('x').ToString());
    }

    [TestMethod]
    public void TrimStartTest9()
    {
        string test = "xyyx";
        var sb = new StringBuilder(test);
        Assert.AreEqual(test.TrimStart('x', 'y'), sb.TrimStart('x', 'y').ToString());
    }


    [TestMethod]
    public void TrimStartTest10()
    {
        string input = "  Test   ";

        var sb = new StringBuilder(input);
        Assert.AreEqual(input.TrimStart(null), sb.TrimStart("").ToString());
    }

    [TestMethod]
    public void TrimStartTest11()
    {
        char[] trimChars = [];
        string input = "   Test   ";

        var sb = new StringBuilder(input);
        Assert.AreEqual(input.TrimStart(trimChars), sb.TrimStart(trimChars).ToString());
    }

    [TestMethod]
    public void TrimStartTest12()
    {
        char[] trimChars = ['\"', '\''];
        string input = "\'\"Test\'\"";

        var sb = new StringBuilder(input);
        Assert.AreEqual(input.TrimStart(trimChars), sb.TrimStart(trimChars.AsSpan()).ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TrimStartTest13()
    {
        char[] trimChars = ['\"', '\''];

        StringBuilder? sb = null;
        _ = sb!.TrimStart(trimChars.AsSpan());
    }

    [TestMethod]
    public void TrimStartTest14()
    {
        char[] trimChars = [];
        string input = "   Test   ";

        var sb = new StringBuilder(input);
        Assert.AreEqual(input.TrimStart(trimChars), sb.TrimStart(trimChars.AsSpan()).ToString());
    }


    [DataTestMethod]
    [DataRow("    Test    ")]
    public void TrimEndTest1(string input)
    {
        var sb = new StringBuilder(input);
        Assert.AreEqual(input.TrimEnd(), sb.TrimEnd().ToString());
    }

    [DataTestMethod]
    [DataRow("    Test    ", ' ')]
    public void TrimEndTest2(string input, char trimChar)
    {
        var sb = new StringBuilder(input);
        Assert.AreEqual(input.TrimEnd(trimChar), sb.TrimEnd(trimChar).ToString());
    }


    [TestMethod]
    public void TrimEndTest3()
    {
        char[] trimChars = ['\"', '\''];
        string input = "\'\"Test\'\"";

        var sb = new StringBuilder(input);
        Assert.AreEqual(input.TrimEnd(trimChars), sb.TrimEnd(trimChars).ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TrimEndTest4()
    {
        char[] trimChars = ['\"', '\''];

        StringBuilder? sb = null;
        _ = sb!.TrimEnd(trimChars);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TrimEndTest5()
    {
        StringBuilder? sb = null;
        _ = sb!.TrimEnd(' ');
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TrimEndTest6()
    {
        StringBuilder? sb = null;
        _ = sb!.TrimEnd();
    }

    [TestMethod]
    public void TrimEndTest7()
    {
        string input = "  Test   ";

        var sb = new StringBuilder(input);
        Assert.AreEqual(input.TrimEnd(null), sb.TrimEnd("").ToString());
    }

    [TestMethod]
    public void TrimEndTest8()
    {
        char[] trimChars = [];
        string input = "   Test   ";

        var sb = new StringBuilder(input);
        Assert.AreEqual(input.TrimEnd(trimChars), sb.TrimEnd(trimChars).ToString());
    }

    [TestMethod]
    public void TrimEndTest9()
    {
        char[] trimChars = ['\"', '\''];
        string input = "\'\"Test\'\"";

        var sb = new StringBuilder(input);
        Assert.AreEqual(input.TrimEnd(trimChars), sb.TrimEnd(trimChars.AsSpan()).ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TrimEndTest10()
    {
        char[] trimChars = ['\"', '\''];

        StringBuilder? sb = null;
        _ = sb!.TrimEnd(trimChars.AsSpan());
    }

    [TestMethod]
    public void TrimEndTest11()
    {
        char[] trimChars = [];
        string input = "   Test   ";

        var sb = new StringBuilder(input);
        Assert.AreEqual(input.TrimEnd(trimChars), sb.TrimEnd(trimChars.AsSpan()).ToString());
    }


    [DataTestMethod]
    [DataRow("Test", 't', true)]
    [DataRow("Test", 'T', false)]
    [DataRow("", 'T', false)]
    public void EndsWithTest1(string input, char c, bool expected) => Assert.AreEqual(expected, new StringBuilder(input).EndsWith(c));

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void EndsWithTest2()
    {
        StringBuilder? sb = null;
        _ = sb!.EndsWith('x');
    }

    [DataTestMethod]
    [DataRow("Test", 'T', true)]
    [DataRow("Test", 't', false)]
    [DataRow("", 't', false)]
    public void StartsWithTest1(string input, char c, bool expected) => Assert.AreEqual(expected, new StringBuilder(input).StartsWith(c));

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void StartsWithTest2()
    {
        StringBuilder? sb = null;
        _ = sb!.StartsWith('x');
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ContainsNewLineTest1()
    {
        StringBuilder? sb = null;
        _ = sb!.ContainsNewLine();
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ContainsNewLineTest2()
    {
        StringBuilder? sb = null;
        _ = sb!.ContainsNewLine(0);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ContainsNewLineTest3()
    {
        StringBuilder? sb = null;
        _ = sb!.ContainsNewLine(0, 0);
    }

    [DataTestMethod]
    [DataRow("", false)]
    //[DataRow(null, false)]
    [DataRow("Test", false)]
    [DataRow("\nTest", true)]
    [DataRow("Test\r", true)]
    [DataRow("Te\r\nst", true)]
    public void ContainsNewLineTest4(string input, bool expexted) => Assert.AreEqual(expexted, new StringBuilder(input).ContainsNewLine());

    [DataTestMethod]
    [DataRow("", 0, false)]
    //[DataRow(null, false)]
    [DataRow("Test", 0, false)]
    [DataRow("\nTest", 0, true)]
    [DataRow("\nTest", 1, false)]
    [DataRow("Test\r", 0, true)]
    [DataRow("Test\r", 5, false)]
    [DataRow("Te\r\nst", 0, true)]
    public void ContainsNewLineTest5(string input, int startIndex, bool expexted) => Assert.AreEqual(expexted, new StringBuilder(input).ContainsNewLine(startIndex));


    [DataTestMethod]
    [DataRow("", 0, 0, false)]
    //[DataRow(null, false)]
    [DataRow("Test", 0, 4, false)]
    [DataRow("\nTest", 0, 1, true)]
    [DataRow("\nTest", 1, 4, false)]
    [DataRow("Test\r", 0, 5, true)]
    [DataRow("Test\r", 0, 4, false)]
    [DataRow("Test\r", 5, 0, false)]
    [DataRow("Te\r\nst", 0, 4, true)]
    [DataRow("Te\r\nst", 0, 2, false)]
    public void ContainsNewLineTest6(string input, int startIndex, int count, bool expexted) => Assert.AreEqual(expexted, new StringBuilder(input).ContainsNewLine(startIndex, count));


    [DataTestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    [DataRow(-1)]
    [DataRow(4711)]
    public void ContainsNewLineTest7(int startIndex) => _ = new StringBuilder().ContainsNewLine(startIndex);

    [DataTestMethod]
    [DataRow(-1, -1)]
    [DataRow(0, -1)]
    [DataRow(0, 4711)]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void ContainsNewLineTest8(int startIndex, int count) => _ = new StringBuilder().ContainsNewLine(startIndex, count);

    [TestMethod]
    public void ContainsNewLineTest9()
    {
        StringBuilder sb = new StringBuilder("a").Append("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        Assert.IsFalse(sb.ContainsNewLine(0, sb.Length));
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ContainsWhiteSpaceTest1()
    {
        StringBuilder? sb = null;
        _ = sb!.ContainsWhiteSpace();
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ContainsWhiteSpaceTest2()
    {
        StringBuilder? sb = null;
        _ = sb!.ContainsWhiteSpace(0);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ContainsWhiteSpaceTest3()
    {
        StringBuilder? sb = null;
        _ = sb!.ContainsWhiteSpace(0, 0);
    }

    [DataTestMethod]
    [DataRow("", false)]
    //[DataRow(null, false)]
    [DataRow("Test", false)]
    [DataRow(" Test", true)]
    [DataRow("Test ", true)]
    [DataRow("Te st", true)]
    public void ContainsWhiteSpaceTest4(string input, bool expexted) => Assert.AreEqual(expexted, new StringBuilder(input).ContainsWhiteSpace());

    [DataTestMethod]
    [DataRow("", 0, false)]
    //[DataRow(null, false)]
    [DataRow("Test", 0, false)]
    [DataRow(" Test", 0, true)]
    [DataRow(" Test", 1, false)]
    [DataRow("Test ", 0, true)]
    [DataRow("Test ", 5, false)]
    [DataRow("Te  st", 0, true)]
    public void ContainsWhiteSpaceTest5(string input, int startIndex, bool expexted) => Assert.AreEqual(expexted, new StringBuilder(input).ContainsWhiteSpace(startIndex));


    [DataTestMethod]
    [DataRow("", 0, 0, false)]
    //[DataRow(null, false)]
    [DataRow("Test", 0, 4, false)]
    [DataRow(" Test", 0, 1, true)]
    [DataRow(" Test", 1, 4, false)]
    [DataRow("Test ", 0, 5, true)]
    [DataRow("Test ", 0, 4, false)]
    [DataRow("Test ", 5, 0, false)]
    [DataRow("Te  st", 0, 4, true)]
    [DataRow("Te  st", 0, 2, false)]
    public void ContainsWhiteSpaceTest6(string input, int startIndex, int count, bool expexted) => Assert.AreEqual(expexted, new StringBuilder(input).ContainsWhiteSpace(startIndex, count));


    [DataTestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    [DataRow(-1)]
    [DataRow(4711)]
    public void ContainsWhiteSpaceTest7(int startIndex) => _ = new StringBuilder().ContainsWhiteSpace(startIndex);

    [DataTestMethod]
    [DataRow(-1, -1)]
    [DataRow(0, -1)]
    [DataRow(0, 4711)]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void ContainsWhiteSpaceTest8(int startIndex, int count) => _ = new StringBuilder().ContainsWhiteSpace(startIndex, count);



    [DataTestMethod]
    [DataRow("", "")]
    [DataRow("f", "Zg==")]
    [DataRow("fo", "Zm8=")]
    [DataRow("foo", "Zm9v")]
    [DataRow("foob", "Zm9vYg==")]
    [DataRow("fooba", "Zm9vYmE=")]
    [DataRow("foobar", "Zm9vYmFy")]
    public void AppendBase64Test1(string input, string expected)
    {
        var builder = new StringBuilder();
        builder.AppendBase64(Encoding.UTF8.GetBytes(input).ToList());
        Assert.AreEqual(expected, builder.ToString());
    }

    [DataTestMethod]
    [DataRow("", "")]
    [DataRow("f", "Zg==")]
    [DataRow("fo", "Zm8=")]
    [DataRow("foo", "Zm9v")]
    [DataRow("foob", "Zm9vYg==")]
    [DataRow("fooba", "Zm9vYmE=")]
    [DataRow("foobar", "Zm9vYmFy")]
    public void AppendBase64Test1b(string input, string expected)
    {
        var builder = new StringBuilder();
        builder.AppendBase64(Encoding.UTF8.GetBytes(input).AsEnumerable());
        Assert.AreEqual(expected, builder.ToString());
    }

    [DataTestMethod]
    [DataRow("", "")]
    [DataRow("f", "Zg==")]
    [DataRow("fo", "Zm8=")]
    [DataRow("foo", "Zm9v")]
    [DataRow("foob", "Zm9vYg==")]
    [DataRow("fooba", "Zm9vYmE=")]
    [DataRow("foobar", "Zm9vYmFy")]
    public void AppendBase64Test1c(string input, string expected)
    {
        var builder = new StringBuilder();
        builder.AppendBase64(new ReadOnlyCollection<byte>(Encoding.UTF8.GetBytes(input)));
        Assert.AreEqual(expected, builder.ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void AppendBase64Test2()
    {
        StringBuilder? builder = null;
        _ = builder!.AppendBase64("*"u8.ToArray().ToList());
    }

    //[TestMethod]
    //[ExpectedException(typeof(ArgumentNullException))]
    //public void AppendBase64Test3() => _ = new StringBuilder().AppendBase64((List<byte>)null!);


    [TestMethod]
    [SuppressMessage("Style", "IDE0301:Simplify collection initialization", Justification = "<Pending>")]
    public void AppendBase64Test4()
    {
        StringBuilder builder = new StringBuilder().AppendBase64(ReadOnlySpan<byte>.Empty, Base64FormattingOptions.InsertLineBreaks);
        Assert.AreEqual(0, builder.Length);
    }

    [TestMethod]
    public void AppendBase64Test5()
    {
        StringBuilder builder = new StringBuilder().AppendBase64("*"u8.ToArray(), Base64FormattingOptions.InsertLineBreaks);
        Assert.IsFalse(builder.Contains('\n'));
    }

    [TestMethod]
    public void AppendBase64Test6()
    {
        StringBuilder builder = new StringBuilder(new string('a', 75)).AppendBase64("*"u8.ToArray().AsSpan(), Base64FormattingOptions.InsertLineBreaks);
        Assert.IsTrue(builder.Contains('\n'));
    }

    [TestMethod]
    public void AppendBase64Test7()
    {
        StringBuilder builder = new StringBuilder(new string('a', 77)).AppendBase64("*"u8.ToArray().AsSpan(), Base64FormattingOptions.InsertLineBreaks);
        Assert.IsTrue(builder.Contains('\n'));
    }

    [DataTestMethod]
    [DataRow(48)]
    [DataRow(50)]
    [DataRow(57)]
    [DataRow(58)]
    [DataRow(200)]
    public void AppendBase64Test8(int length)
    {
        byte[] bytes = new byte[length];
        new Random().NextBytes(bytes);

        Assert.AreEqual(
            Convert.ToBase64String(bytes, Base64FormattingOptions.InsertLineBreaks),
            new StringBuilder().AppendBase64(bytes, Base64FormattingOptions.InsertLineBreaks).ToString());
    }


    [TestMethod]
    public void AppendBase64Test9() => Assert.AreEqual(0, new StringBuilder().AppendBase64((IEnumerable<byte>?)null).Length);


    [TestMethod]
    public void AppendUrlEncodedTest1()
    {
        const string s = "äöü";
        StringBuilder sb = new StringBuilder().AppendUrlEncoded(s.AsSpan());

        Assert.AreEqual(Uri.EscapeDataString(s), sb.ToString());
    }

    [TestMethod]
    public void AppendUrlEncodedTest2()
    {
        string s = new('ä', 1000);
        StringBuilder sb = new StringBuilder().AppendUrlEncoded(s.AsSpan());

        Assert.AreEqual(Uri.EscapeDataString(s), sb.ToString());
    }
}
