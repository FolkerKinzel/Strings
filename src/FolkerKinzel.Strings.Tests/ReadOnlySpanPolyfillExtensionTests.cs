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

    [DataTestMethod]
    [DataRow("Test", 't', true)]
    [DataRow("Test", 'T', false)]
    [DataRow("", 'T', false)]
    public void EndsWithTest(string input, char c, bool expected) => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.EndsWith(input.AsSpan(), c));

    [DataTestMethod]
    [DataRow("Test", 'T', true)]
    [DataRow("Test", 't', false)]
    [DataRow("", 't', false)]
    public void StartsWithTest(string input, char c, bool expected) => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.StartsWith(input.AsSpan(), c));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("   ", -1)]
    [DataRow("a", 0)]
    [DataRow(" a ", 1)]
    public void IndexOfAnyExceptTest1(string input, int expected)
        => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.IndexOfAnyExcept(input.AsSpan(), ' '));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("baababb", -1)]
    [DataRow("xxba", 0)]
    [DataRow("bxxxx", 1)]
    public void IndexOfAnyExceptTest2(string input, int expected)
       => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.IndexOfAnyExcept(input.AsSpan(), 'a', 'b'));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cbaabccabbc", -1)]
    [DataRow("xxbca", 0)]
    [DataRow("bxxxx", 1)]
    public void IndexOfAnyExceptTest3(string input, int expected)
        => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.IndexOfAnyExcept(input.AsSpan(), 'a', 'b', 'c'));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cbaaddbccadbbcd", -1)]
    [DataRow("xxbcdda", 0)]
    [DataRow("bxxxx", 1)]
    public void IndexOfAnyExceptTest4(string input, int expected)
        => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.IndexOfAnyExcept(input.AsSpan(), "abcd"));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cbaaddbccadbbcd", -1)]
    [DataRow("xxbcdda", 0)]
    [DataRow("bxxxx", 1)]
    public void IndexOfAnyExceptTest5(string input, int expected)
        => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.IndexOfAnyExcept(input.AsSpan(), "abcd".AsSpan()));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cbaaddbccadbbcd", -1)]
    [DataRow("xxbcdda", 0)]
    [DataRow("bxxxx", 1)]
    public void IndexOfAnyExceptTest6(string input, int expected)
        => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.IndexOfAnyExcept(input.AsSpan(), SearchValuesPolyfill.Create("abcd")));

    [TestMethod()]
    [ExpectedException(typeof(ArgumentNullException))]  
    public void IndexOfAnyExceptTest7()
        => ReadOnlySpanPolyfillExtension.IndexOfAnyExcept("xyz".AsSpan(), (SearchValuesPolyfill<char>?)null!);

    [DataTestMethod()]
    [DataRow("", false)]
    [DataRow("   ", false)]
    [DataRow("a", true)]
    [DataRow(" a ", true)]
    public void ContainsAnyExceptTest1(string input, bool expected)
        => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.ContainsAnyExcept(input.AsSpan(), ' '));

    [DataTestMethod()]
    [DataRow("", false)]
    [DataRow("baababb", false)]
    [DataRow("xxba", true)]
    [DataRow("bxxxx", true)]
    public void ContainsAnyExceptTest2(string input, bool expected)
       => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.ContainsAnyExcept(input.AsSpan(), 'a', 'b'));

    [DataTestMethod()]
    [DataRow("", false)]
    [DataRow("cbaabccabbc", false)]
    [DataRow("xxbca", true)]
    [DataRow("bxxxx", true)]
    public void ContainsAnyExceptTest3(string input, bool expected)
        => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.ContainsAnyExcept(input.AsSpan(), 'a', 'b', 'c'));

    [DataTestMethod()]
    [DataRow("", false)]
    [DataRow("cbaaddbccadbbcd", false)]
    [DataRow("xxbcdda", true)]
    [DataRow("bxxxx", true)]
    public void ContainsAnyExceptTest4(string input, bool expected)
        => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.ContainsAnyExcept(input.AsSpan(), "abcd"));

    [DataTestMethod()]
    [DataRow("", false)]
    [DataRow("cbaaddbccadbbcd", false)]
    [DataRow("xxbcdda", true)]
    [DataRow("bxxxx", true)]
    public void ContainsAnyExceptTest5(string input, bool expected)
        => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.ContainsAnyExcept(input.AsSpan(), "abcd".AsSpan()));

    [DataTestMethod()]
    [DataRow("", false)]
    [DataRow("cbaaddbccadbbcd", false)]
    [DataRow("xxbcdda", true)]
    [DataRow("bxxxx", true)]
    public void ContainsAnyExceptTest6(string input, bool expected)
        => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.ContainsAnyExcept(input.AsSpan(), SearchValuesPolyfill.Create("abcd")));

    [TestMethod()]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ContainsAnyExceptTest7()
        => ReadOnlySpanPolyfillExtension.ContainsAnyExcept("xyz".AsSpan(), (SearchValuesPolyfill<char>?)null!);

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("   ", -1)]
    [DataRow("a", 0)]
    [DataRow(" a ", 1)]
    public void LastIndexOfAnyExceptTest1(string input, int expected)
        => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.LastIndexOfAnyExcept(input.AsSpan(), ' '));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("abbaaba", -1)]
    [DataRow("xbbaba", 0)]
    [DataRow("bxabbbababba", 1)]
    public void LastIndexOfAnyExceptTest2(string input, int expected)
        => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.LastIndexOfAnyExcept(input.AsSpan(), 'a', 'b'));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cabbaccaabca", -1)]
    [DataRow("xbbabcca", 0)]
    [DataRow("bxabbbabcabba", 1)]
    public void LastIndexOfAnyExceptTest3(string input, int expected)
        => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.LastIndexOfAnyExcept(input.AsSpan(), 'a', 'b', 'c'));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cabbadccaabcddad", -1)]
    [DataRow("xbbabcdcadd", 0)]
    [DataRow("bxabbbadbdcabba", 1)]
    public void LastIndexOfAnyExceptTest4(string input, int expected)
        => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.LastIndexOfAnyExcept(input.AsSpan(), "abcd"));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cabbadccaabcddad", -1)]
    [DataRow("xbbabcdcadd", 0)]
    [DataRow("bxabbbadbdcabba", 1)]
    public void LastIndexOfAnyExceptTest5(string input, int expected)
        => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.LastIndexOfAnyExcept(input.AsSpan(), "abcd".AsSpan()));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cabbadccaabcddad", -1)]
    [DataRow("xbbabcdcadd", 0)]
    [DataRow("bxabbbadbdcabba", 1)]
    public void LastIndexOfAnyExceptTest6(string input, int expected)
        => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.LastIndexOfAnyExcept(input.AsSpan(), SearchValuesPolyfill.Create("abcd")));

    [TestMethod()]
    [ExpectedException(typeof(ArgumentNullException))]
    public void LastIndexOfAnyExceptTest7()
        => ReadOnlySpanPolyfillExtension.LastIndexOfAnyExcept("xyz".AsSpan(), (SearchValuesPolyfill<char>?)null!);

    [DataTestMethod]
    [DataRow("", null, true)]
    [DataRow("", "", true)]
    [DataRow("", "a", false)]
    [DataRow("a", "a", true)]
    [DataRow("ab", "ab", true)]
    [DataRow("ab", "ba", false)]
    [DataRow("ab", "AB", true)]
    public void EqualsTest(string input, string? other, bool expected) =>
        Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.Equals(input.AsSpan(), other, StringComparison.OrdinalIgnoreCase));

    [TestMethod]
    public void ContainsTest1() 
        => Assert.IsTrue(ReadOnlySpanPolyfillExtension.Contains(Environment.NewLine.AsSpan(), Environment.NewLine, StringComparison.Ordinal));

    [DataTestMethod]
    [DataRow("", 'x')]
    [DataRow("abc", 'x')]
    [DataRow("abc", 'B')]
    [DataRow("abc", 'b')]
    [DataRow("ABC", 'b')]
    public void ContainsTest1b(string input, char c)
       => Assert.AreEqual(input.IndexOf(c) != -1, ReadOnlySpanPolyfillExtension.Contains(input.AsSpan(), c));

    [DataTestMethod]
    [DataRow("t", "abcdefghi", -1)]
    [DataRow("t", "abcdefghit", 0)]
    [DataRow("testtest", "abcdfghi", -1)]
    [DataRow("testtest", "abcdfghit", 0)]
    [DataRow("", "abcdefghit", -1)]
    [DataRow("t", "", -1)]
    [DataRow("testtest", "", -1)]
    public void IndexOfAnyTest1(string testStr, string needles, int expectedIndex)
        => Assert.AreEqual(expectedIndex, ReadOnlySpanPolyfillExtension.IndexOfAny(testStr.AsSpan(), needles.AsSpan()));

    [DataTestMethod]
    [DataRow("t", "abcdefghi", -1)]
    [DataRow("t", "abcdefghit", 0)]
    [DataRow("testtest", "abcdfghi", -1)]
    [DataRow("testtest", "abcdfghit", 0)]
    [DataRow("", "abcdefghit", -1)]
    [DataRow("t", "", -1)]
    [DataRow("testtest", "", -1)]
    public void IndexOfAnyTest2(string testStr, string needles, int expectedIndex)
        => Assert.AreEqual(expectedIndex, ReadOnlySpanPolyfillExtension.IndexOfAny(testStr.AsSpan(), needles));

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
        => Assert.AreEqual(expectedIndex, ReadOnlySpanPolyfillExtension.IndexOfAny(testStr.AsSpan(), SearchValuesPolyfill.Create(needles)));

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))] 
    public void IndexOfAnyTest4()
        => ReadOnlySpanPolyfillExtension.IndexOfAny("abc".AsSpan(), (SearchValuesPolyfill<char>?)null!);

    [TestMethod]
    public void ContainsAnyTest1() => Assert.IsFalse(ReadOnlySpanPolyfillExtension.ContainsAny("t".AsSpan(), ""));

    [TestMethod]
    public void ContainsAnyTest2() => Assert.IsFalse(ReadOnlySpanPolyfillExtension.ContainsAny("t".AsSpan(), SearchValuesPolyfill.Create("")));

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void ContainsAnyTest3() => Assert.IsFalse(ReadOnlySpanPolyfillExtension.ContainsAny("t".AsSpan(), (SearchValuesPolyfill<char>?)null!));

    [DataTestMethod]
    [DataRow("", "xyz")]
    [DataRow("abc", "xyz")]
    [DataRow("abc", "")]
    [DataRow("abc", "xbz")]
    public void ContainsAnyTest4(string input, string chars)
        => Assert.AreEqual(input.IndexOfAny(chars) != -1, ReadOnlySpanPolyfillExtension.ContainsAny(input.AsSpan(), chars));

    [DataTestMethod]
    [DataRow("", "xyz")]
    [DataRow("abc", "xyz")]
    [DataRow("abc", "")]
    [DataRow("abc", "xbz")]
    public void ContainsAnyTest5(string input, string chars)
        => Assert.AreEqual(input.IndexOfAny(chars) != -1,
                           ReadOnlySpanPolyfillExtension.ContainsAny(input.AsSpan(), chars.AsSpan()));

    [DataTestMethod]
    [DataRow("", "xyz")]
    [DataRow("abc", "xyz")]
    [DataRow("abc", "xbz")]
    public void ContainsAnyTest6(string input, string chars)
        => Assert.AreEqual(input.AsSpan().IndexOfAny(chars[0], chars[1]) != -1,
                           ReadOnlySpanPolyfillExtension.ContainsAny(input.AsSpan(), chars[0], chars[1]));

    [DataTestMethod]
    [DataRow("", "xyz")]
    [DataRow("abc", "xyz")]
    [DataRow("abc", "xya")]
    public void ContainsAnyTest7(string input, string chars)
        => Assert.AreEqual(input.AsSpan().IndexOfAny(chars[0], chars[1], chars[2]) != -1,
                           ReadOnlySpanPolyfillExtension.ContainsAny(input.AsSpan(), chars[0], chars[1], chars[2]));

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

        Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.LastIndexOfAny(test.AsSpan(), needles.AsSpan()));
    }

    [DataTestMethod]
    [DataRow("ef", 4)]
    [DataRow("0123456789ef", 4)]
    [DataRow("", -1)]
    [DataRow("xy", -1)]
    [DataRow("qwxyza0123456789", -1)]
    public void LastIndexOfAnyTest2(string needles, int expected) => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.LastIndexOfAny("testen".AsSpan(), needles));


    [TestMethod]
    public void LastIndexOfAnyTest3()
    {
        const string test = "test";
        Assert.AreEqual(-1, ReadOnlySpan<char>.Empty.LastIndexOfAny(test.AsSpan()));
    }

    [TestMethod]
    public void LastIndexOfAnyTest4()
        => Assert.AreEqual(1, ReadOnlySpanPolyfillExtension.LastIndexOfAny("abc".AsSpan(), SearchValuesPolyfill.Create("1b2")));

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void LastIndexOfAnyTest5()
        => Assert.AreEqual(1, ReadOnlySpanPolyfillExtension.LastIndexOfAny("abc".AsSpan(), (SearchValuesPolyfill<char>?)null!));

    [DataTestMethod]
    [DataRow("test", "TE", true)]
    [DataRow("test", "te", true)]
    [DataRow("test", "bla", false)]
    [DataRow("test", null, true)]
    [DataRow("test", "", true)]
    [DataRow("", "", true)]
    [DataRow("", "TE", false)]
    public void StartsWithTest1(string input, string? test, bool expected)
        => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.StartsWith(input.AsSpan(), test, StringComparison.OrdinalIgnoreCase));


    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void StartsWithTest2()
        => _ = ReadOnlySpanPolyfillExtension.StartsWith("test".AsSpan(), "test", (StringComparison)4711);

    [DataTestMethod]
    [DataRow("test", "TE", false)]
    [DataRow("test", "te", true)]
    [DataRow("test", "bla", false)]
    [DataRow("test", null, true)]
    [DataRow("test", "", true)]
    [DataRow("", "", true)]
    [DataRow("", "TE", false)]
    public void StartsWithTest3(string input, string? test, bool expected)
        => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.StartsWith(input.AsSpan(), test));


    [DataTestMethod]
    [DataRow("test", "ST", true)]
    [DataRow("test", "st", true)]
    [DataRow("test", "bla", false)]
    [DataRow("test", null, true)]
    [DataRow("test", "", true)]
    [DataRow("", "", true)]
    [DataRow("", "st", false)]
    public void EndsWithTest1(string input, string? test, bool expected)
       => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.EndsWith(input.AsSpan(), test, StringComparison.OrdinalIgnoreCase));


    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void EndsWithTest2()
        => _ = ReadOnlySpanPolyfillExtension.EndsWith("test".AsSpan(), "test", (StringComparison)4711);

    [DataTestMethod]
    [DataRow("test", "ST", false)]
    [DataRow("test", "st", true)]
    [DataRow("test", "bla", false)]
    [DataRow("test", null, true)]
    [DataRow("test", "", true)]
    [DataRow("", "", true)]
    [DataRow("", "st", false)]
    public void EndsWithTest3(string input, string? test, bool expected)
        => Assert.AreEqual(expected, ReadOnlySpanPolyfillExtension.EndsWith(input.AsSpan(), test));




    [DataTestMethod()]
    [DataRow(StringComparison.Ordinal)]
    [DataRow(StringComparison.CurrentCulture)]
    [SuppressMessage("Style", "IDE0301:Simplify collection initialization", Justification = "<Pending>")]
    public void LastIndexOfTest1(StringComparison comp)
    {
        const string test = "test";
        Assert.AreEqual(test.LastIndexOf("", comp), ReadOnlySpanPolyfillExtension.LastIndexOf(test.AsSpan(), ReadOnlySpan<char>.Empty, comp));
    }


    [DataTestMethod()]
    [DataRow(StringComparison.Ordinal)]
    [DataRow(StringComparison.CurrentCulture)]
    public void LastIndexOfTest2(StringComparison comp)
    {
        const string test = "test";
        Assert.AreEqual(1, ReadOnlySpanPolyfillExtension.LastIndexOf(test.AsSpan(), "est".AsSpan(), comp));
    }


    [DataTestMethod()]
    [DataRow(StringComparison.Ordinal)]
    [DataRow(StringComparison.CurrentCulture)]
    public void LastIndexOfTest3(StringComparison comp)
    {
        const string test = "test";
        Assert.AreEqual(test.LastIndexOf("", comp), ReadOnlySpanPolyfillExtension.LastIndexOf(test.AsSpan(), "", comp));
    }


    [DataTestMethod()]
    [DataRow(StringComparison.Ordinal)]
    [DataRow(StringComparison.CurrentCulture)]
    public void LastIndexOfTest4(StringComparison comp)
    {
        const string test = "test";
        Assert.AreEqual(1, ReadOnlySpanPolyfillExtension.LastIndexOf(test.AsSpan(), "est", comp));
    }


    [DataTestMethod()]
    [DataRow(StringComparison.Ordinal)]
    [DataRow(StringComparison.CurrentCulture)]
    //[ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void LastIndexOfTest5(StringComparison comp)
    {
        const string test = "test";
        Assert.AreEqual(test.LastIndexOf("", comp), ReadOnlySpanPolyfillExtension.LastIndexOf(test.AsSpan(), (string?)null, comp));
    }

    [DataTestMethod()]
    [DataRow(StringComparison.Ordinal)]
    [DataRow(StringComparison.CurrentCulture)]
    //[ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void LastIndexOfTest6(StringComparison comp)
    {
        const string test = "test";
        Assert.AreEqual(test.LastIndexOf("", comp), ReadOnlySpanPolyfillExtension.LastIndexOf(test.AsSpan(), "", comp));
    }

    [DataTestMethod]
    [DataRow("", "abc", StringComparison.Ordinal)]
    [DataRow("abc", "bc", StringComparison.Ordinal)]
    [DataRow("abc", "BC", StringComparison.OrdinalIgnoreCase)]
    public void IndexOfTest1(string input, string end, StringComparison comp)
       => Assert.AreEqual(input.AsSpan().IndexOf(end.AsSpan(), comp),
                          ReadOnlySpanPolyfillExtension.IndexOf(input.AsSpan(), end, comp));

    [DataTestMethod]
    [DataRow("abc", "abcd")]
    [DataRow("abc", "")]
    [DataRow("abc", null)]
    [DataRow("abc", "ba")]
    [DataRow("abc", "xy")]
    public void TrimStartTest1(string? input, string? trimChars)
    {
        ReadOnlySpan<char> span = input.AsSpan();
        Assert.AreEqual(span.TrimStart(trimChars.AsSpan()).ToString(),
                        ReadOnlySpanPolyfillExtension.TrimStart(span, trimChars).ToString());
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
        Assert.AreEqual(span.TrimEnd(trimChars.AsSpan()).ToString(), 
                        ReadOnlySpanPolyfillExtension.TrimEnd(span, trimChars).ToString());
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
        Assert.AreEqual(span.Trim(trimChars.AsSpan()).ToString(), ReadOnlySpanPolyfillExtension.Trim(span, trimChars).ToString());
    }
}
