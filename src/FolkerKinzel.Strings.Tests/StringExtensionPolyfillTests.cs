using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Tests;

[TestClass()]
public class StringExtensionPolyfillTests
{
    [TestMethod]
    public void ReplaceWhitespaceWithTest1()
       => Assert.AreEqual("*Test*\r\n*text*", "\t Test   \r\n text  ".ReplaceWhiteSpaceWith("*", true));


    [TestMethod]
    public void ReplaceWhitespaceWithTest2()
        => Assert.AreEqual("*Test*text*", "\t Test   \r\n text  ".ReplaceWhiteSpaceWith("*", false));

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ReplaceWhiteSpaceWithTest3()
    {
        string? s = null;
        _ = s!.ReplaceWhiteSpaceWith("*");
    }

#pragma warning disable CS0618 // Type or member is obsolete

    [TestMethod]
    public void NormalizeNewLinesToTest1()
       => Assert.AreEqual("\t Test   * text  ", "\t Test   \r\n text  ".NormalizeNewLinesTo("*"));


    [TestMethod]
    public void NormalizeNewLinesToTest2()
        => Assert.AreEqual("\t Test   * text  ", "\t Test   \r\n text  ".NormalizeNewLinesTo("*"));


    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void NormalizeNewLinesToTest3()
    {
        string? s = null;
        _ = s!.NormalizeNewLinesTo("*");
    }

#pragma warning restore CS0618 // Type or member is obsolete

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

        Assert.AreEqual(expected, test.IndexOfAny(needles, 1, test.Length - 1));
    }

    [DataTestMethod]
    [DataRow("ts", 2)]
    [DataRow("0123456789ts", 2)]
    [DataRow("", -1)]
    [DataRow("xy", -1)]
    [DataRow("qwxyza0123456789", -1)]
    public void IndexOfAnyTest7b(string needles, int expected)
    {
        const string test = "test";

        //int i = "".LastIndexOfAny(new char[0]);
        //i = MemoryExtensions.LastIndexOfAny(test.AsSpan(), ReadOnlySpan<char>.Empty);

        Assert.AreEqual(expected, test.IndexOfAny(needles, 1));
    }

    [DataTestMethod]
    [DataRow("ts", 0)]
    [DataRow("0123456789ts", 0)]
    [DataRow("", -1)]
    [DataRow("xy", -1)]
    [DataRow("qwxyza0123456789", -1)]
    public void IndexOfAnyTest7c(string needles, int expected)
    {
        const string test = "test";

        //int i = "".LastIndexOfAny(new char[0]);
        //i = MemoryExtensions.LastIndexOfAny(test.AsSpan(), ReadOnlySpan<char>.Empty);

        Assert.AreEqual(expected, test.IndexOfAny(needles));
    }

    [TestMethod]
    public void IndexOfAnyTest8()
    {
        const string test = "test";
        Assert.AreEqual(-1, "".IndexOfAny(test, 0, 0));
    }

    [TestMethod]
    public void IndexOfAnyTest8b()
    {
        const string test = "test";
        Assert.AreEqual(-1, "".IndexOfAny(test, 0));
    }

    [TestMethod]
    public void IndexOfAnyTest8c()
    {
        const string test = "test";
        Assert.AreEqual(-1, "".IndexOfAny(test));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void IndexOfAnyTest9()
    {
        const string? test = null;
        _ = test!.IndexOfAny("", 0, 0);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void IndexOfAnyTest9b()
    {
        const string? test = null;
        _ = test!.IndexOfAny("", 0);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void IndexOfAnyTest9c()
    {
        const string? test = null;
        _ = test!.IndexOfAny("");
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

        Assert.AreEqual(expected, test.LastIndexOfAny(needles, test.Length - 2, 3));
    }

    [DataTestMethod]
    [DataRow("ef", 4)]
    [DataRow("0123456789ef", 4)]
    [DataRow("", -1)]
    [DataRow("xy", -1)]
    [DataRow("qwxyza0123456789", -1)]
    public void LastIndexOfAnyTest7b(string needles, int expected)
    {
        const string test = "testen";

        //int i = "".LastIndexOfAny(new char[0]);
        //i = MemoryExtensions.LastIndexOfAny(test.AsSpan(), ReadOnlySpan<char>.Empty);

        Assert.AreEqual(expected, test.LastIndexOfAny(needles, test.Length - 2));
    }

    [DataTestMethod]
    [DataRow("ef", 4)]
    [DataRow("0123456789ef", 4)]
    [DataRow("", -1)]
    [DataRow("xy", -1)]
    [DataRow("qwxyza0123456789", -1)]
    public void LastIndexOfAnyTest7c(string needles, int expected)
    {
        const string test = "testen";

        //int i = "".LastIndexOfAny(new char[0]);
        //i = MemoryExtensions.LastIndexOfAny(test.AsSpan(), ReadOnlySpan<char>.Empty);

        Assert.AreEqual(expected, test.LastIndexOfAny(needles));
    }

    [TestMethod]
    public void LastIndexOfAnyTest8()
    {
        const string test = "test";
        Assert.AreEqual(-1, "".LastIndexOfAny(test, 0, 0));
    }

    [TestMethod]
    public void LastIndexOfAnyTest8b()
    {
        const string test = "test";
        Assert.AreEqual(-1, "".LastIndexOfAny(test, 0));
    }

    [TestMethod]
    public void LastIndexOfAnyTest8c()
    {
        const string test = "test";
        Assert.AreEqual(-1, "".LastIndexOfAny(test));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void LastIndexOfAnyTest9()
    {
        const string? test = null;
        _ = test!.LastIndexOfAny("", 0, 0);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void LastIndexOfAnyTest9b()
    {
        const string? test = null;
        _ = test!.LastIndexOfAny("", 0);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void LastIndexOfAnyTest9c()
    {
        const string? test = null;
        _ = test!.LastIndexOfAny("");
    }

    [DataTestMethod]
    [DataRow(-1, 0)]
    [DataRow(0, -1)]
    [DataRow(0, 2)]
    [DataRow(-2, 2)]
    [DataRow(2, -2)]
    public void LastIndexOfAnyTest10(int index, int count)
    {
        string needles = "testganzlang";

        _ = "".LastIndexOfAny(needles, index, count);
    }

    [DataTestMethod]
    [DataRow(-1)]
    [DataRow(0)]
    [DataRow(0)]
    [DataRow(-2)]
    [DataRow(2)]
    public void LastIndexOfAnyTest10b(int index)
    {
        string needles = "testganzlang";

        _ = "".LastIndexOfAny(needles, index);
    }

    [DataTestMethod]
    [DataRow(-1, 0)]
    [DataRow(0, -1)]
    [DataRow(0, 2)]
    [DataRow(-2, 2)]
    [DataRow(2, -2)]
    public void LastIndexOfAnyTest11(int index, int count)
    {
        string needles = "t";

        _ = "".LastIndexOfAny(needles, index, count);
    }

    [DataTestMethod]
    [DataRow(-1)]
    [DataRow(0)]
    [DataRow(0)]
    [DataRow(-2)]
    [DataRow(2)]
    public void LastIndexOfAnyTest11b(int index)
    {
        string needles = "t";

        _ = "".LastIndexOfAny(needles, index);
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
        string needles = "testganzlang";
        _ = "t".LastIndexOfAny(needles, index, count);
    }

    [DataTestMethod]
    [DataRow(-2)]
    [DataRow(2)]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void LastIndexOfAnyTest16b(int index)
    {
        string needles = "testganzlang";
        _ = "t".LastIndexOfAny(needles, index);
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
        string needles = "t";
        _ = "t".LastIndexOfAny(needles, index, count);
    }

    [DataTestMethod]
    [DataRow(-2)]
    [DataRow(2)]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void LastIndexOfAnyTest17b(int index)
    {
        string needles = "t";
        _ = "t".LastIndexOfAny(needles, index);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ContainsAnyTest5()
    {
        string? s = null;
        _ = s!.ContainsAny("");
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
        Assert.AreEqual(expected, test.ContainsAny(needles));
    }

}
