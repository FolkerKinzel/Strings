using System.Dynamic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Tests;


[TestClass]
public class ReadOnlySpanExtensionTests
{
    [TestMethod]
    public void TrimTest1()
    {
        const string trimChars = "\'\"";

        string test = "\"\'Test\'\"";

        Assert.AreEqual(test.Trim(trimChars), test.AsSpan().Trim(SearchValuesPolyfill.Create(trimChars)).ToString());
    }

    [TestMethod]
    public void TrimTest2()
    {
        string test = "  Test  ";

        Assert.AreEqual(test, test.AsSpan().Trim(SearchValuesPolyfill.Create("")).ToString());
    }

    [TestMethod]
    public void TrimTest3()
    {
        const string trimChars = "\'\"";

        string test = "\"\'\'\"";
        Assert.AreEqual("", test.AsSpan().Trim(SearchValuesPolyfill.Create(trimChars)).ToString());
    }


    [TestMethod]
    public void TrimTest4()
    {
        string test = "    ";
        Assert.AreEqual(test, test.AsSpan().Trim(SearchValuesPolyfill.Create("")).ToString());
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TrimTest5() => ReadOnlySpan<char>.Empty.Trim((SearchValuesPolyfill<char>?)null!);
    

    [TestMethod]
    public void TrimTest6()
    {
        const string trimChars = "\'\"";

        string test = "Test";
        Assert.AreEqual(test, test.AsSpan().Trim(SearchValuesPolyfill.Create(trimChars)).ToString());
    }

    [TestMethod]
    public void TrimStartTest1()
    {
        const string trimChars = "\'\"";

        string test = "\"\'Test\'\"";

        Assert.AreEqual(test.TrimStart(trimChars), test.AsSpan().TrimStart(SearchValuesPolyfill.Create(trimChars)).ToString());
    }

    [TestMethod]
    public void TrimStartTest2()
    {
        string test = "  Test  ";
        Assert.AreEqual(test, test.AsSpan().TrimStart(SearchValuesPolyfill.Create("")).ToString());
    }

    [TestMethod]
    public void TrimStartTest3()
    {
        const string trimChars = "\'\"";
        string test = "\"\'\'\"";
        Assert.AreEqual("", test.AsSpan().TrimStart(SearchValuesPolyfill.Create(trimChars)).ToString());
    }


    [TestMethod]
    public void TrimStartTest4()
    {
        string test = "    ";
        Assert.AreEqual(test, test.AsSpan().TrimStart(SearchValuesPolyfill.Create("")).ToString());
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TrimStartTest5() => ReadOnlySpan<char>.Empty.TrimStart((SearchValuesPolyfill<char>?)null!);
    

    [TestMethod]
    public void TrimStartTest6()
    {
        const string trimChars = "\'\"";

        string test = "Test";
        Assert.AreEqual(test, test.AsSpan().TrimStart(SearchValuesPolyfill.Create(trimChars)).ToString());
    }

    [TestMethod]
    public void TrimEndTest1()
    {
        const string trimChars = "\'\"";

        string test = "\"\'Test\'\"";

        Assert.AreEqual(test.TrimEnd(trimChars), test.AsSpan().TrimEnd(SearchValuesPolyfill.Create(trimChars)).ToString());
    }

    [TestMethod]
    public void TrimEndTest2()
    {
        string test = "  Test  ";
        Assert.AreEqual(test, test.AsSpan().TrimEnd(SearchValuesPolyfill.Create("")).ToString());
    }

    [TestMethod]
    public void TrimEndTest3()
    {
        const string trimChars = "\'\"";
        string test = "\"\'\'\"";
        Assert.AreEqual("", test.AsSpan().TrimEnd(SearchValuesPolyfill.Create(trimChars)).ToString());
    }


    [TestMethod]
    public void TrimEndTest4()
    {
        string test = "    ";
        Assert.AreEqual(test, test.AsSpan().TrimStart(SearchValuesPolyfill.Create("")).ToString());
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TrimEndTest5() => ReadOnlySpan<char>.Empty.TrimEnd((SearchValuesPolyfill<char>?)null!);

    [TestMethod]
    public void TrimEndTest6()
    {
        
        const string trimChars = "\'\"";

        string test = "Test";
        Assert.AreEqual(test, test.AsSpan().TrimEnd(SearchValuesPolyfill.Create(trimChars)).ToString());
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

    [DataTestMethod]
    [DataRow("ef", 4)]
    [DataRow("0123456789ef", 4)]
    [DataRow("", -1)]
    [DataRow("xy", -1)]
    [DataRow("qwxyza0123456789", -1)]
    public void LastIndexOfAnyTest18(string needles, int expected)
    {
        const string test = "testen";

        //int i = "".LastIndexOfAny(new char[0]);
        //i = MemoryExtensions.LastIndexOfAny(test.AsSpan(), ReadOnlySpan<char>.Empty);

        Assert.AreEqual(expected, test.AsSpan().LastIndexOfAny(SearchValuesPolyfill.Create(needles), test.Length - 2, 3));
    }

    [TestMethod]
    public void LastIndexOfAnyTest19()
    {
        const string test = "test";
        Assert.AreEqual(-1, "".AsSpan().LastIndexOfAny(SearchValuesPolyfill.Create(test), 0, 0));
    }

    [DataTestMethod]
    [DataRow(-1, 0)]
    [DataRow(0, -1)]
    [DataRow(0, 2)]
    [DataRow(-2, 2)]
    [DataRow(2, -2)]
    public void LastIndexOfAnyTest20(int index, int count)
    {
        var needles = SearchValuesPolyfill.Create("testganzlang");
        _ = "".AsSpan().LastIndexOfAny(needles, index, count);
    }

    [DataTestMethod]
    [DataRow(-1, 0)]
    [DataRow(0, -1)]
    [DataRow(0, 2)]
    [DataRow(-2, 2)]
    [DataRow(2, -2)]
    public void LastIndexOfAnyTest21(int index, int count)
    {
        var needles = SearchValuesPolyfill.Create("t");
        _ = "".AsSpan().LastIndexOfAny(needles, index, count);
    }

    [DataTestMethod]
    [DataRow(-1, 0)]
    [DataRow(0, -1)]
    [DataRow(0, 2)]
    [DataRow(-2, 2)]
    [DataRow(2, -2)]
    public void LastIndexOfAnyTest22(int index, int count)
        => _ = "".AsSpan().LastIndexOfAny(SearchValuesPolyfill.Create("t"), index, count);

    [DataTestMethod]
    //[DataRow(-1, 0)]
    [DataRow(0, -1)]
    [DataRow(0, 2)]
    [DataRow(-2, 2)]
    [DataRow(2, -2)]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void LastIndexOfAnyTest23(int index, int count)
    {
        var needles = SearchValuesPolyfill.Create("testganzlang");
        _ = "t".AsSpan().LastIndexOfAny(needles, index, count);
    }

    [DataTestMethod]
    //[DataRow(-1, 0)]
    [DataRow(0, -1)]
    [DataRow(0, 2)]
    [DataRow(-2, 2)]
    [DataRow(2, -2)]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void LastIndexOfAnyTest24(int index, int count)
    {
        var needles = SearchValuesPolyfill.Create("t");
        _ = "t".AsSpan().LastIndexOfAny(needles, index, count);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void LastIndexOfAnyTest25()
        => Assert.AreEqual(1, "abc".AsSpan().LastIndexOfAny((SearchValuesPolyfill<char>?)null!, 1, 1));


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

    //[TestMethod()]
    //[ExpectedException(typeof(ArgumentOutOfRangeException))]
    //public void LastIndexOfTest5() => _ = "".AsSpan().LastIndexOf("bla", -2, 0, StringComparison.Ordinal);

    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void LastIndexOfTest6() => _ = "test".AsSpan().LastIndexOf("bla", 0, -1, StringComparison.Ordinal);

    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void LastIndexOfTest7() => _ = "test".AsSpan().LastIndexOf("bla", -1, 0, StringComparison.Ordinal);

    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void LastIndexOfTest8() => _ = "test".AsSpan().LastIndexOf("bla", 5, 0, StringComparison.Ordinal);

    [TestMethod()]
    [ExpectedException(typeof(ArgumentException))]
    public void LastIndexOfTest9() => _ = "test".AsSpan().LastIndexOf("bla", 3, 1, (StringComparison)4711);

    [TestMethod]
    public void LastIndexOfAnyTest2()
       => Assert.AreEqual(1, "abc".ToCharArray().AsSpan().LastIndexOfAny("1b2".AsSpan(), 1, 1));
}
