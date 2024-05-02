using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Tests;


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

    [DataTestMethod]
    [DataRow("ef", 4)]
    [DataRow("0123456789ef", 4)]
    [DataRow("", -1)]
    [DataRow("xy", -1)]
    [DataRow("qwxyza0123456789", -1)]
    public void LastIndexOfAnyTest1b(string needles, int expected) => Assert.AreEqual(expected, "testen".AsSpan().LastIndexOfAny(needles));

    


    [TestMethod]
    public void LastIndexOfAnyTest2()
    {
        const string test = "test";
        Assert.AreEqual(-1, ReadOnlySpan<char>.Empty.LastIndexOfAny(test.AsSpan()));
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

        Assert.AreEqual(expected, test.AsSpan().LastIndexOfAny(needles.AsSpan(), test.Length - 2, 3));
    }

    [TestMethod]
    public void LastIndexOfAnyTest8()
    {
        const string test = "test";
        Assert.AreEqual(-1, "".AsSpan().LastIndexOfAny(test.AsSpan(), 0, 0));
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
        _ = "".AsSpan().LastIndexOfAny(needles, index, count);
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
        _ = "".AsSpan().LastIndexOfAny(needles, index, count);
    }

    [DataTestMethod]
    [DataRow(-1, 0)]
    [DataRow(0, -1)]
    [DataRow(0, 2)]
    [DataRow(-2, 2)]
    [DataRow(2, -2)]
    public void LastIndexOfAnyTest11b(int index, int count) => _ = "".AsSpan().LastIndexOfAny("t", index, count);

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
        _ = "t".AsSpan().LastIndexOfAny(needles, index, count);
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
        _ = "t".AsSpan().LastIndexOfAny(needles, index, count);
    }

    //[TestMethod]
    //public void MyTestMethod()
    //{
    //    int result = new char[] {'t'}.AsSpan().IndexOfAny("".AsSpan());
    //}


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


    [DataTestMethod]
    [DataRow("t", "abcdefghi", -1)]
    [DataRow("t", "abcdefghit", 0)]
    [DataRow("testtest", "abcdfghi", -1)]
    [DataRow("testtest", "abcdfghit", 0)]
    [DataRow("", "abcdefghit", -1)]
    [DataRow("t", "", -1)]
    [DataRow("testtest", "", -1)]
    public void IndexOfAnyTest2(string testStr, string needles, int expectedIndex)
        => Assert.AreEqual(expectedIndex, testStr.AsSpan().IndexOfAny(needles));

    [TestMethod]
    public void ContainsAnyTest1() => Assert.IsFalse("t".AsSpan().ContainsAny(""));

    //[TestMethod]
    //public void TestTest()
    //{
    //    var idx = ReadOnlySpanExtension.Test();
    //}


    //[DataTestMethod]
    //[DataRow("test", 0)]
    //[DataRow("", 0)]
    //[DataRow(" ", 1)]
    //[DataRow(" test", 1)]
    //public void IndexOfAnyExceptTest1(string input, int result)
    //    => Assert.AreEqual(result, input.AsSpan().IndexOfAnyExcept());

    //[DataTestMethod]
    //[DataRow("test", 4)]
    //[DataRow("", 0)]
    //[DataRow(" ", 0)]
    //[DataRow("test    ", 4)]
    //public void GetTrimmedLength1(string input, int length)
    //    => Assert.AreEqual(length, input.AsSpan().GetTrimmedLength());


    [DataTestMethod]
    [DataRow("Test\r\n1", true)]
    [DataRow("Test 2", false)]
    public void ContainsNewLineTest(string input, bool expected) => Assert.AreEqual(expected, input.AsSpan().ContainsNewLine());

    [DataTestMethod]
    [DataRow("Test", 't', true)]
    [DataRow("Test", 'T', false)]
    [DataRow("", 'T', false)]
    public void EndsWithTest(string input, char c, bool expected) => Assert.AreEqual(expected, input.AsSpan().EndsWith(c));

    [DataTestMethod]
    [DataRow("Test", 'T', true)]
    [DataRow("Test", 't', false)]
    [DataRow("", 't', false)]
    public void StartsWithTest(string input, char c, bool expected) => Assert.AreEqual(expected, input.AsSpan().StartsWith(c));

    [TestMethod()]
    public void LastIndexOfTest1() => Assert.AreEqual(-1, "test".AsSpan().LastIndexOf("bla", 3, 4, StringComparison.Ordinal));

    [TestMethod()]
    public void LastIndexOfTest2() => Assert.AreEqual(-1, "".AsSpan().LastIndexOf("bla", -1, 0, StringComparison.Ordinal));

    [TestMethod()]
    public void LastIndexOfTest3() => Assert.AreEqual(-1, "".AsSpan().LastIndexOf("bla", 0, 1, StringComparison.Ordinal));

    [TestMethod()]
    //[ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void LastIndexOfTest4()
        => Assert.AreEqual(-1, "".AsSpan().LastIndexOf("bla", 0, 2, StringComparison.Ordinal));

    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void LastIndexOfTest5() => _ = "".AsSpan().LastIndexOf("bla", -2, 0, StringComparison.Ordinal);

    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void LastIndexOfTest6() => _ = "".AsSpan().LastIndexOf("bla", 1, 0, StringComparison.Ordinal);

    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void LastIndexOfTest7() => _ = "test".AsSpan().LastIndexOf("bla", -1, 0, StringComparison.Ordinal);

    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void LastIndexOfTest8() => _ = "test".AsSpan().LastIndexOf("bla", 5, 0, StringComparison.Ordinal);

    [TestMethod()]
    [ExpectedException(typeof(ArgumentException))]
    public void LastIndexOfTest9() => _ = "test".AsSpan().LastIndexOf("bla", 3, 1, (StringComparison)4711);
}
