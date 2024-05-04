using System.Buffers;
using System.Globalization;
using FolkerKinzel.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Tests;


[TestClass()]
public class ReadOnlySpanPolyfillExtensionTests : IDisposable
{
    private readonly CultureInfo _culture;

    public ReadOnlySpanPolyfillExtensionTests()
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
    [DataRow("", -1)]
    [DataRow("   ", -1)]
    [DataRow("a", 0)]
    [DataRow(" a ", 1)]
    public void IndexOfAnyExceptTest1(string input, int expected)
        => Assert.AreEqual(expected, input.AsSpan().IndexOfAnyExcept(' '));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("baababb", -1)]
    [DataRow("xxba", 0)]
    [DataRow("bxxxx", 1)]
    public void IndexOfAnyExceptTest2(string input, int expected)
       => Assert.AreEqual(expected, input.AsSpan().IndexOfAnyExcept('a', 'b'));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cbaabccabbc", -1)]
    [DataRow("xxbca", 0)]
    [DataRow("bxxxx", 1)]
    public void IndexOfAnyExceptTest3(string input, int expected)
        => Assert.AreEqual(expected, input.AsSpan().IndexOfAnyExcept('a', 'b', 'c'));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cbaaddbccadbbcd", -1)]
    [DataRow("xxbcdda", 0)]
    [DataRow("bxxxx", 1)]
    public void IndexOfAnyExceptTest4(string input, int expected)
        => Assert.AreEqual(expected, input.AsSpan().IndexOfAnyExcept("abcd"));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cbaaddbccadbbcd", -1)]
    [DataRow("xxbcdda", 0)]
    [DataRow("bxxxx", 1)]
    public void IndexOfAnyExceptTest5(string input, int expected)
        => Assert.AreEqual(expected, input.AsSpan().IndexOfAnyExcept("abcd".AsSpan()));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cbaaddbccadbbcd", -1)]
    [DataRow("xxbcdda", 0)]
    [DataRow("bxxxx", 1)]
    public void IndexOfAnyExceptTest6(string input, int expected)
        => Assert.AreEqual(expected, input.AsSpan().IndexOfAnyExcept(SearchValues.Create("abcd")));

    [TestMethod()]
    [ExpectedException(typeof(ArgumentNullException))]  
    public void IndexOfAnyExceptTest7()
        => "xyz".AsSpan().IndexOfAnyExcept((SearchValues<char>?)null!);

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("   ", -1)]
    [DataRow("a", 0)]
    [DataRow(" a ", 1)]
    public void LastIndexOfAnyExceptTest1(string input, int expected)
        => Assert.AreEqual(expected, input.AsSpan().LastIndexOfAnyExcept(' '));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("abbaaba", -1)]
    [DataRow("xbbaba", 0)]
    [DataRow("bxabbbababba", 1)]
    public void LastIndexOfAnyExceptTest2(string input, int expected)
        => Assert.AreEqual(expected, input.AsSpan().LastIndexOfAnyExcept('a', 'b'));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cabbaccaabca", -1)]
    [DataRow("xbbabcca", 0)]
    [DataRow("bxabbbabcabba", 1)]
    public void LastIndexOfAnyExceptTest3(string input, int expected)
        => Assert.AreEqual(expected, input.AsSpan().LastIndexOfAnyExcept('a', 'b', 'c'));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cabbadccaabcddad", -1)]
    [DataRow("xbbabcdcadd", 0)]
    [DataRow("bxabbbadbdcabba", 1)]
    public void LastIndexOfAnyExceptTest4(string input, int expected)
        => Assert.AreEqual(expected, input.AsSpan().LastIndexOfAnyExcept("abcd"));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cabbadccaabcddad", -1)]
    [DataRow("xbbabcdcadd", 0)]
    [DataRow("bxabbbadbdcabba", 1)]
    public void LastIndexOfAnyExceptTest5(string input, int expected)
        => Assert.AreEqual(expected, input.AsSpan().LastIndexOfAnyExcept("abcd".AsSpan()));

    [DataTestMethod]
    [DataRow("", null, true)]
    [DataRow("", "", true)]
    [DataRow("", "a", false)]
    [DataRow("a", "a", true)]
    [DataRow("ab", "ab", true)]
    [DataRow("ab", "ba", false)]
    [DataRow("ab", "AB", true)]
    public void EqualsTest(string input, string? other, bool expected) =>
        Assert.AreEqual(expected, input.AsSpan().Equals(other, StringComparison.OrdinalIgnoreCase));

    [TestMethod]
    public void ContainsTest1() => Assert.IsTrue(Environment.NewLine.AsSpan().Contains(Environment.NewLine, StringComparison.Ordinal));

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

    [DataTestMethod]
    [DataRow("t", "abcdefghi", -1)]
    [DataRow("t", "abcdefghit", 0)]
    [DataRow("testtest", "abcdfghi", -1)]
    [DataRow("testtest", "abcdfghit", 0)]
    [DataRow("", "abcdefghit", -1)]
    [DataRow("t", "", -1)]
    [DataRow("t", null, -1)]
    [DataRow(null, null, -1)]
    [DataRow("testtest", "", -1)]
    public void IndexOfAnyTest3(string? testStr, string? needles, int expectedIndex)
        => Assert.AreEqual(expectedIndex, testStr.AsSpan().IndexOfAny(SearchValues.Create(needles)));

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))] 
    public void IndexOfAnyTest4()
        => "abc".AsSpan().IndexOfAny((SearchValues<char>?)null!);

    [TestMethod]
    public void ContainsAnyTest1() => Assert.IsFalse("t".AsSpan().ContainsAny(""));

    [TestMethod]
    public void ContainsAnyTest2() => Assert.IsFalse("t".AsSpan().ContainsAny(SearchValues.Create("")));

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void ContainsAnyTest3() => Assert.IsFalse("t".AsSpan().ContainsAny((SearchValues<char>?)null!));

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
    public void LastIndexOfAnyTest2(string needles, int expected) => Assert.AreEqual(expected, "testen".AsSpan().LastIndexOfAny(needles));


    [TestMethod]
    public void LastIndexOfAnyTest3()
    {
        const string test = "test";
        Assert.AreEqual(-1, ReadOnlySpan<char>.Empty.LastIndexOfAny(test.AsSpan()));
    }

    [TestMethod]
    public void LastIndexOfAnyTest4()
        => Assert.AreEqual(1, "abc".AsSpan().LastIndexOfAny(SearchValues.Create("1b2")));

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void LastIndexOfAnyTest5()
        => Assert.AreEqual(1, "abc".AsSpan().LastIndexOfAny((SearchValues<char>?)null!));

    [DataTestMethod]
    [DataRow("test", "TE", true)]
    [DataRow("test", "te", true)]
    [DataRow("test", "bla", false)]
    [DataRow("test", null, true)]
    [DataRow("test", "", true)]
    [DataRow("", "", true)]
    [DataRow("", "TE", false)]
    public void StartsWithTest1(string input, string? test, bool expected)
        => Assert.AreEqual(expected, input.AsSpan().StartsWith(test, StringComparison.OrdinalIgnoreCase));


    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void StartsWithTest2()
        => _ = "test".AsSpan().StartsWith("test", (StringComparison)4711);

    [DataTestMethod]
    [DataRow("test", "TE", false)]
    [DataRow("test", "te", true)]
    [DataRow("test", "bla", false)]
    [DataRow("test", null, true)]
    [DataRow("test", "", true)]
    [DataRow("", "", true)]
    [DataRow("", "TE", false)]
    public void StartsWithTest3(string input, string? test, bool expected)
        => Assert.AreEqual(expected, input.AsSpan().StartsWith(test));


    [DataTestMethod]
    [DataRow("test", "ST", true)]
    [DataRow("test", "st", true)]
    [DataRow("test", "bla", false)]
    [DataRow("test", null, true)]
    [DataRow("test", "", true)]
    [DataRow("", "", true)]
    [DataRow("", "st", false)]
    public void EndsWithTest1(string input, string? test, bool expected)
       => Assert.AreEqual(expected, input.AsSpan().EndsWith(test, StringComparison.OrdinalIgnoreCase));


    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void EndsWithTest2()
        => _ = "test".AsSpan().EndsWith("test", (StringComparison)4711);

    [DataTestMethod]
    [DataRow("test", "ST", false)]
    [DataRow("test", "st", true)]
    [DataRow("test", "bla", false)]
    [DataRow("test", null, true)]
    [DataRow("test", "", true)]
    [DataRow("", "", true)]
    [DataRow("", "st", false)]
    public void EndsWithTest3(string input, string? test, bool expected)
        => Assert.AreEqual(expected, input.AsSpan().EndsWith(test));




    [DataTestMethod()]
    [DataRow(StringComparison.Ordinal)]
    [DataRow(StringComparison.CurrentCulture)]
    [SuppressMessage("Style", "IDE0301:Simplify collection initialization", Justification = "<Pending>")]
    public void LastIndexOfTest1(StringComparison comp)
    {
        const string test = "test";
        Assert.AreEqual(test.LastIndexOf("", comp), test.AsSpan().LastIndexOf(ReadOnlySpan<char>.Empty, comp));
    }


    [DataTestMethod()]
    [DataRow(StringComparison.Ordinal)]
    [DataRow(StringComparison.CurrentCulture)]
    public void LastIndexOfTest2(StringComparison comp)
    {
        const string test = "test";
        Assert.AreEqual(1, test.AsSpan().LastIndexOf("est".AsSpan(), comp));
    }


    [DataTestMethod()]
    [DataRow(StringComparison.Ordinal)]
    [DataRow(StringComparison.CurrentCulture)]
    public void LastIndexOfTest3(StringComparison comp)
    {
        const string test = "test";
        Assert.AreEqual(test.LastIndexOf("", comp), test.AsSpan().LastIndexOf("", comp));
    }


    [DataTestMethod()]
    [DataRow(StringComparison.Ordinal)]
    [DataRow(StringComparison.CurrentCulture)]
    public void LastIndexOfTest4(StringComparison comp)
    {
        const string test = "test";
        Assert.AreEqual(1, test.AsSpan().LastIndexOf("est", comp));
    }


    [DataTestMethod()]
    [DataRow(StringComparison.Ordinal)]
    [DataRow(StringComparison.CurrentCulture)]
    //[ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void LastIndexOfTest5(StringComparison comp)
    {
        const string test = "test";
        Assert.AreEqual(test.LastIndexOf("", comp), test.AsSpan().LastIndexOf((string?)null, comp));
    }

    [DataTestMethod()]
    [DataRow(StringComparison.Ordinal)]
    [DataRow(StringComparison.CurrentCulture)]
    //[ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void LastIndexOfTest6(StringComparison comp)
    {
        const string test = "test";
        Assert.AreEqual(test.LastIndexOf("", comp), test.AsSpan().LastIndexOf("", comp));
    }

    [DataTestMethod]
    [DataRow("", "abc", StringComparison.Ordinal)]
    [DataRow("abc", "bc", StringComparison.Ordinal)]
    [DataRow("abc", "BC", StringComparison.OrdinalIgnoreCase)]
    public void IndexOfTest1(string input, string end, StringComparison comp)
       => Assert.AreEqual(input.AsSpan().IndexOf(end.AsSpan(), comp),
                          input.AsSpan().IndexOf(end, comp));

    [DataTestMethod]
    [DataRow("abc", "abcd")]
    [DataRow("abc", "")]
    [DataRow("abc", null)]
    [DataRow("abc", "ba")]
    [DataRow("abc", "xy")]
    public void TrimStartTest1(string? input, string? trimChars)
    {
        ReadOnlySpan<char> span = input.AsSpan();
        Assert.AreEqual(span.TrimStart(trimChars.AsSpan()).ToString(), span.TrimStart(trimChars).ToString());
    }

    [DataTestMethod]
    [DataRow("abc", "abcd")]
    [DataRow("abc", "")]
    [DataRow("abc", null)]
    [DataRow("abc", "ba")]
    [DataRow("abc", "xy")]
    public void TrimEndTest1(string? input, string? trimChars)
    {
        ReadOnlySpan<char> span = input.AsSpan();
        Assert.AreEqual(span.TrimEnd(trimChars.AsSpan()).ToString(), span.TrimEnd(trimChars).ToString());
    }

    [DataTestMethod]
    [DataRow("abc", "abcd")]
    [DataRow("abc", "")]
    [DataRow("abc", null)]
    [DataRow("abc", "ba")]
    [DataRow("abc", "xy")]
    [DataRow("abcab", "ba")]
    public void TrimTest1(string? input, string? trimChars)
    {
        ReadOnlySpan<char> span = input.AsSpan();
        Assert.AreEqual(span.Trim(trimChars.AsSpan()).ToString(), span.Trim(trimChars).ToString());
    }
}
