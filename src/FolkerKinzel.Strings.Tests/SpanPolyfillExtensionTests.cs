using FolkerKinzel.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Tests;

[TestClass()]
public class SpanPolyfillExtensionTests
{
    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("   ", -1)]
    [DataRow("a", 0)]
    [DataRow(" a ", 1)]
    public void IndexOfAnyExceptTest1(string input, int expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.IndexOfAnyExcept(input.ToCharArray().AsSpan(), ' '));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("baababb", -1)]
    [DataRow("xxba", 0)]
    [DataRow("bxxxx", 1)]
    public void IndexOfAnyExceptTest2(string input, int expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.IndexOfAnyExcept(input.ToCharArray().AsSpan(), 'a', 'b'));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cbaabccabbc", -1)]
    [DataRow("xxbca", 0)]
    [DataRow("bxxxx", 1)]
    public void IndexOfAnyExceptTest3(string input, int expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.IndexOfAnyExcept(input.ToCharArray().AsSpan(), 'a', 'b', 'c'));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cbaaddbccadbbcd", -1)]
    [DataRow("xxbcdda", 0)]
    [DataRow("bxxxx", 1)]
    public void IndexOfAnyExceptTest4(string input, int expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.IndexOfAnyExcept(input.ToCharArray().AsSpan(), "abcd"));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cbaaddbccadbbcd", -1)]
    [DataRow("xxbcdda", 0)]
    [DataRow("bxxxx", 1)]
    public void IndexOfAnyExceptTest5(string input, int expected)
        => Assert.AreEqual(expected, 
                           SpanPolyfillExtension.IndexOfAnyExcept(input.ToCharArray().AsSpan(), "abcd".AsSpan()));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cbaaddbccadbbcd", -1)]
    [DataRow("xxbcdda", 0)]
    [DataRow("bxxxx", 1)]
    public void IndexOfAnyExceptTest6(string input, int expected)
        => Assert.AreEqual(expected, 
                           SpanPolyfillExtension.IndexOfAnyExcept(input.ToCharArray().AsSpan(), SearchValuesPolyfill.Create("abcd")));

    [TestMethod()]
    [ExpectedException(typeof(ArgumentNullException))]
    public void IndexOfAnyExceptTest7()
        => SpanPolyfillExtension.IndexOfAnyExcept("xyz".ToCharArray().AsSpan(), (SearchValuesPolyfill<char>?)null!);

    [DataTestMethod()]
    [DataRow("", false)]
    [DataRow("   ", false)]
    [DataRow("a", true)]
    [DataRow(" a ", true)]
    public void ContainsAnyExceptTest1(string input, bool expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.ContainsAnyExcept(input.ToCharArray().AsSpan(), ' '));

    [DataTestMethod()]
    [DataRow("", false)]
    [DataRow("baababb", false)]
    [DataRow("xxba", true)]
    [DataRow("bxxxx", true)]
    public void ContainsAnyExceptTest2(string input, bool expected)
       => Assert.AreEqual(expected, SpanPolyfillExtension.ContainsAnyExcept(input.ToCharArray().AsSpan(), 'a', 'b'));

    [DataTestMethod()]
    [DataRow("", false)]
    [DataRow("cbaabccabbc", false)]
    [DataRow("xxbca", true)]
    [DataRow("bxxxx", true)]
    public void ContainsAnyExceptTest3(string input, bool expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.ContainsAnyExcept(input.ToCharArray().AsSpan(), 'a', 'b', 'c'));

    [DataTestMethod()]
    [DataRow("", false)]
    [DataRow("cbaaddbccadbbcd", false)]
    [DataRow("xxbcdda", true)]
    [DataRow("bxxxx", true)]
    public void ContainsAnyExceptTest4(string input, bool expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.ContainsAnyExcept(input.ToCharArray().AsSpan(), "abcd"));

    [DataTestMethod()]
    [DataRow("", false)]
    [DataRow("cbaaddbccadbbcd", false)]
    [DataRow("xxbcdda", true)]
    [DataRow("bxxxx", true)]
    public void ContainsAnyExceptTest5(string input, bool expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.ContainsAnyExcept(input.ToCharArray().AsSpan(), "abcd".AsSpan()));

    [DataTestMethod()]
    [DataRow("", false)]
    [DataRow("cbaaddbccadbbcd", false)]
    [DataRow("xxbcdda", true)]
    [DataRow("bxxxx", true)]
    public void ContainsAnyExceptTest6(string input, bool expected)
        => Assert.AreEqual(expected, 
                           SpanPolyfillExtension.ContainsAnyExcept(input.ToCharArray().AsSpan(), SearchValuesPolyfill.Create("abcd")));

    [TestMethod()]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ContainsAnyExceptTest7()
        => SpanPolyfillExtension.ContainsAnyExcept("xyz".ToCharArray().AsSpan(), (SearchValuesPolyfill<char>?)null!);

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("   ", -1)]
    [DataRow("a", 0)]
    [DataRow(" a ", 1)]
    public void LastIndexOfAnyExceptTest1(string input, int expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.LastIndexOfAnyExcept(input.ToCharArray().AsSpan(), ' '));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("abbaaba", -1)]
    [DataRow("xbbaba", 0)]
    [DataRow("bxabbbababba", 1)]
    public void LastIndexOfAnyExceptTest2(string input, int expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.LastIndexOfAnyExcept(input.ToCharArray().AsSpan(), 'a', 'b'));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cabbaccaabca", -1)]
    [DataRow("xbbabcca", 0)]
    [DataRow("bxabbbabcabba", 1)]
    public void LastIndexOfAnyExceptTest3(string input, int expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.LastIndexOfAnyExcept(input.ToCharArray().AsSpan(), 'a', 'b', 'c'));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cabbadccaabcddad", -1)]
    [DataRow("xbbabcdcadd", 0)]
    [DataRow("bxabbbadbdcabba", 1)]
    public void LastIndexOfAnyExceptTest4(string input, int expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.LastIndexOfAnyExcept(input.ToCharArray().AsSpan(), "abcd"));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cabbadccaabcddad", -1)]
    [DataRow("xbbabcdcadd", 0)]
    [DataRow("bxabbbadbdcabba", 1)]
    public void LastIndexOfAnyExceptTest5(string input, int expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.LastIndexOfAnyExcept(input.ToCharArray().AsSpan(), "abcd".AsSpan()));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cabbadccaabcddad", -1)]
    [DataRow("xbbabcdcadd", 0)]
    [DataRow("bxabbbadbdcabba", 1)]
    public void LastIndexOfAnyExceptTest6(string input, int expected)
        => Assert.AreEqual(expected, 
                           SpanPolyfillExtension.LastIndexOfAnyExcept(input.ToCharArray().AsSpan(), SearchValuesPolyfill.Create("abcd")));

    [TestMethod()]
    [ExpectedException(typeof(ArgumentNullException))]
    public void LastIndexOfAnyExceptTest7()
        => SpanPolyfillExtension.LastIndexOfAnyExcept("xyz".ToCharArray().AsSpan(), (SearchValuesPolyfill<char>?)null!);

    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("", "")]
    [DataRow("xxxabc  ", "bc")]
    [DataRow("xxxabc  ", "bcd")]
    [DataRow("xxxabc  ", "")]
    [DataRow("xxxabc   ", "BC")]
    public void ContainsTest1a(string input, string needle)
       => Assert.AreEqual(input.AsSpan().Contains(needle.AsSpan(), StringComparison.OrdinalIgnoreCase),
                          SpanPolyfillExtension.Contains(input.ToCharArray().AsSpan(), needle, StringComparison.OrdinalIgnoreCase));

    [DataTestMethod]
    [DataRow("", 'x')]
    [DataRow("abc", 'x')]
    [DataRow("abc", 'B')]
    [DataRow("abc", 'b')]
    [DataRow("ABC", 'b')]
    public void ContainsTest1b(string input, char c)
        => Assert.AreEqual(input.AsSpan().Contains(c), SpanPolyfillExtension.Contains(input.ToCharArray().AsSpan(), c));

    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("", "")]
    [DataRow("xxxabc  ", "bc")]
    [DataRow("xxxabc  ", "bcd")]
    [DataRow("xxxabc  ", "")]
    [DataRow("xxxabc   ", "BC")]
    public void ContainsTest2(string input, string needle)
       => Assert.AreEqual(input.AsSpan().Contains(needle.AsSpan(), StringComparison.OrdinalIgnoreCase),
                          SpanPolyfillExtension.Contains(input.ToCharArray().AsSpan(), needle, StringComparison.OrdinalIgnoreCase));

    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("", "")]
    [DataRow("xxxabc  ", "bc")]
    [DataRow("xxxabc  ", "bcd")]
    [DataRow("xxxabc  ", "")]
    [DataRow("xxxabc   ", "BC")]
    public void ContainsTest3(string input, string needle)
       => Assert.AreEqual(input.AsSpan().Contains(needle.AsSpan(), StringComparison.Ordinal),
                          SpanPolyfillExtension.Contains(input.ToCharArray().AsSpan(), needle, StringComparison.Ordinal));

    [DataTestMethod]
    [DataRow("")]
    [DataRow("  ")]
    [DataRow("abc")]
    [DataRow("  \r\na b c  ")]
    public void TrimTest1(string input)
        => Assert.AreEqual(input.AsSpan().Trim().ToString(), SpanPolyfillExtension.Trim(input.ToCharArray().AsSpan()).ToString());

    [DataTestMethod]
    [DataRow("", "")]
    [DataRow("xxx", "")]
    [DataRow("abc", "abc")]
    [DataRow("xxx\r\na b cxxx", "\r\na b c")]
    public void TrimTest2(string input, string expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.Trim(input.ToCharArray().AsSpan(), 'x').ToString());

    [DataTestMethod]
    [DataRow("", "abc", "")]
    [DataRow(" x ", "", " x ")]
    [DataRow(" x ", null, " x ")]
    [DataRow("abc", "bac", "")]
    [DataRow("cbxabc", "bac", "x")]
    public void TrimTest3(string input, string? trimChars, string expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.Trim(input.ToCharArray().AsSpan(), trimChars).ToString());

    [DataTestMethod]
    [DataRow("", "abc", "")]
    [DataRow(" x ", "", " x ")]
    [DataRow(" x ", null, " x ")]
    [DataRow("abc", "bac", "")]
    [DataRow("cbxabc", "bac", "x")]
    public void TrimTest4(string input, string? trimChars, string expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.Trim(input.ToCharArray().AsSpan(), trimChars.AsSpan()).ToString());

    [DataTestMethod]
    [DataRow("")]
    [DataRow("  ")]
    [DataRow("abc")]
    [DataRow("  \r\na b c  ")]
    public void TrimStartTest1(string input)
        => Assert.AreEqual(input.AsSpan().TrimStart().ToString(), SpanPolyfillExtension.TrimStart(input.ToArray().AsSpan()).ToString());

    [DataTestMethod]
    [DataRow("", "")]
    [DataRow("xxx", "")]
    [DataRow("abc", "abc")]
    [DataRow("xxx\r\na b cxxx", "\r\na b cxxx")]
    public void TrimStartTest2(string input, string expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.TrimStart(input.ToCharArray().AsSpan(), 'x').ToString());

    [DataTestMethod]
    [DataRow("", "abc", "")]
    [DataRow(" x ", "", " x ")]
    [DataRow(" x ", null, " x ")]
    [DataRow("abc", "bac", "")]
    [DataRow("cbxabc", "bac", "xabc")]
    public void TrimStartTest3(string input, string? trimChars, string expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.TrimStart(input.ToCharArray().AsSpan(), trimChars).ToString());

    [TestMethod]
    public void TrimStartTest4()
        => Assert.AreEqual("T  ", SpanPolyfillExtension.TrimStart("  T  ".ToCharArray().AsSpan()).ToString());

    [DataTestMethod]
    [DataRow("", "abc", "")]
    [DataRow(" x ", "", " x ")]
    [DataRow(" x ", null, " x ")]
    [DataRow("abc", "bac", "")]
    [DataRow("cbxabc", "bac", "xabc")]
    public void TrimStartTest5(string input, string? trimChars, string expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.TrimStart(input.ToCharArray().AsSpan(), trimChars.AsSpan()).ToString());

    [DataTestMethod]
    [DataRow("")]
    [DataRow("  ")]
    [DataRow("abc")]
    [DataRow("  \r\na b c  ")]
    public void TrimEndTest1(string input)
        => Assert.AreEqual(input.AsSpan().TrimEnd().ToString(), SpanPolyfillExtension.TrimEnd(input.ToArray().AsSpan()).ToString());

    [DataTestMethod]
    [DataRow("", "")]
    [DataRow("xxx", "")]
    [DataRow("abc", "abc")]
    [DataRow("xxx\r\na b cxxx", "xxx\r\na b c")]
    public void TrimEndTest2(string input, string expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.TrimEnd(input.ToCharArray().AsSpan(), 'x').ToString());

    [DataTestMethod]
    [DataRow("", "abc", "")]
    [DataRow(" x ", "", " x ")]
    [DataRow(" x ", null, " x ")]
    [DataRow("abc", "bac", "")]
    [DataRow("bxabc", "bac", "bx")]
    public void TrimEndTest3(string input, string? trimChars, string expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.TrimEnd(input.ToCharArray().AsSpan(), trimChars).ToString());

    [TestMethod]
    public void TrimEndTest4()
        => Assert.AreEqual("  T", SpanPolyfillExtension.TrimEnd("  T  ".ToCharArray().AsSpan()).ToString());

    [DataTestMethod]
    [DataRow("", "abc", "")]
    [DataRow(" x ", "", " x ")]
    [DataRow(" x ", null, " x ")]
    [DataRow("abc", "bac", "")]
    [DataRow("bxabc", "bac", "bx")]
    public void TrimEndTest5(string input, string? trimChars, string expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.TrimEnd(input.ToCharArray().AsSpan(), trimChars.AsSpan()).ToString());

    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("", "")]
    [DataRow("abc  ", "abc")]
    [DataRow("abc  ", "ABC")]
    [DataRow("abc  ", "abcd")]
    public void EqualsTest1(string input, string comparison)
       => Assert.AreEqual(input.AsSpan().Equals(comparison.AsSpan(), StringComparison.OrdinalIgnoreCase),
                          SpanPolyfillExtension.Equals(input.ToCharArray().AsSpan(), comparison, StringComparison.OrdinalIgnoreCase));

    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("", "")]
    [DataRow("xxxabc  ", "bc")]
    [DataRow("xxxabc  ", "bcd")]
    [DataRow("xxxabc  ", "")]
    [DataRow("xxxabc   ", "BC")]
    public void LastIndexOfTest1(string input, string end)
      => Assert.AreEqual(input.AsSpan().LastIndexOf(end.AsSpan(), StringComparison.OrdinalIgnoreCase),
                         SpanPolyfillExtension.LastIndexOf(input.ToCharArray().AsSpan(), end, StringComparison.OrdinalIgnoreCase));

    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("", "")]
    [DataRow("xxxabc  ", "bc")]
    [DataRow("xxxabc  ", "bcd")]
    [DataRow("xxxabc  ", "")]
    [DataRow("xxxabc   ", "BC")]
    public void LastIndexOfTest2(string input, string end)
       => Assert.AreEqual(input.AsSpan().LastIndexOf(end.AsSpan(), input.Length - 1, input.Length, StringComparison.OrdinalIgnoreCase),
                          SpanPolyfillExtension.LastIndexOf(input.ToCharArray().AsSpan(), end, input.Length - 1, input.Length, StringComparison.OrdinalIgnoreCase));

    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("", "")]
    [DataRow("xxxabc  ", "bc")]
    [DataRow("xxxabc  ", "bcd")]
    [DataRow("xxxabc  ", "")]
    [DataRow("xxxabc   ", "BC")]
    public void LastIndexOfTest3(string input, string end)
      => Assert.AreEqual(input.AsSpan().LastIndexOf(end.AsSpan(), StringComparison.Ordinal),
                         SpanPolyfillExtension.LastIndexOf(input.ToCharArray().AsSpan(), end, StringComparison.Ordinal));

    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("", "")]
    [DataRow("xxxabc  ", "bc")]
    [DataRow("xxxabc  ", "bcd")]
    [DataRow("xxxabc  ", "")]
    [DataRow("xxxabc   ", "BC")]
    public void LastIndexOfTest4(string input, string end)
       => Assert.AreEqual(input.AsSpan().LastIndexOf(end.AsSpan(), input.Length - 1, input.Length, StringComparison.Ordinal),
                          SpanPolyfillExtension.LastIndexOf(input.ToCharArray().AsSpan(), end, input.Length - 1, input.Length, StringComparison.Ordinal));

    [DataTestMethod]
    [DataRow("", "xyz")]
    [DataRow("abc", "xyz")]
    [DataRow("abc", "")]
    [DataRow("abc", "xbz")]
    public void ContainsAnyTest1(string input, string chars)
        => Assert.AreEqual(input.AsSpan().ContainsAny(chars.AsSpan()), SpanPolyfillExtension.ContainsAny(input.ToCharArray().AsSpan(), chars));

    [TestMethod]
    public void ContainsAnyTest2() 
        => Assert.IsFalse(SpanPolyfillExtension.ContainsAny("t".ToCharArray().AsSpan(), SearchValuesPolyfill.Create("")));

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ContainsAnyTest3()
        => Assert.IsFalse(SpanPolyfillExtension.ContainsAny("t".ToCharArray().AsSpan(), (SearchValuesPolyfill<char>?)null!));

    [DataTestMethod]
    [DataRow("", "xyz")]
    [DataRow("abc", "xyz")]
    [DataRow("abc", "")]
    [DataRow("abc", "xbz")]
    public void ContainsAnyTest4(string input, string chars)
        => Assert.AreEqual(input.AsSpan().ContainsAny(chars.AsSpan()),
                           SpanPolyfillExtension.ContainsAny(input.ToCharArray().AsSpan(), chars.AsSpan()));

    [DataTestMethod]
    [DataRow("", "xyz")]
    [DataRow("abc", "xyz")]
    [DataRow("abc", "xbz")]
    public void ContainsAnyTest5(string input, string chars)
        => Assert.AreEqual(input.AsSpan().IndexOfAny(chars[0], chars[1]) != -1, 
                           SpanPolyfillExtension.ContainsAny(input.ToCharArray().AsSpan(), chars[0], chars[1]));

    [DataTestMethod]
    [DataRow("", "xyz")]
    [DataRow("abc", "xyz")]
    [DataRow("abc", "xya")]
    public void ContainsAnyTest6(string input, string chars)
        => Assert.AreEqual(input.AsSpan().IndexOfAny(chars[0], chars[1], chars[2]) != -1, 
                           SpanPolyfillExtension.ContainsAny(input.ToCharArray().AsSpan(), chars[0], chars[1], chars[2]));

    [TestMethod]
    public void LastIndexOfAnyTest1()
        => Assert.AreEqual(1, SpanPolyfillExtension.LastIndexOfAny("abc".ToCharArray().AsSpan(), "1b2"));

    [TestMethod]
    public void LastIndexOfAnyTest2()
        => Assert.AreEqual(1, SpanPolyfillExtension.LastIndexOfAny("abc".ToCharArray().AsSpan(), "1b2".AsSpan()));

    [TestMethod]
    public void LastIndexOfAnyTest3()
       => Assert.AreEqual(1, SpanPolyfillExtension.LastIndexOfAny("abc".ToCharArray().AsSpan(), "1b2", 1, 1));

    [TestMethod]
    public void LastIndexOfAnyTest4()
        => Assert.AreEqual(1, SpanPolyfillExtension.LastIndexOfAny("abc".ToCharArray().AsSpan(), SearchValuesPolyfill.Create("1b2")));

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void LastIndexOfAnyTest5()
        => Assert.AreEqual(1, SpanPolyfillExtension.LastIndexOfAny("abc".ToCharArray().AsSpan(), (SearchValuesPolyfill<char>?)null!));

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void LastIndexOfAnyTest6()
        => Assert.AreEqual(1, "abc".ToCharArray().AsSpan().LastIndexOfAny((SearchValuesPolyfill<char>?)null!, 1, 1));

    [TestMethod]
    public void LastIndexOfAnyTest7()
       => Assert.AreEqual(1, "abc".ToCharArray().AsSpan().LastIndexOfAny(SearchValuesPolyfill.Create("1b2"), 1, 1));

    [TestMethod]
    public void IndexOfAnyTest1()
        => Assert.AreEqual(1, SpanPolyfillExtension.IndexOfAny("abc".ToCharArray().AsSpan(), "1b2"));

    [DataTestMethod]
    [DataRow("t", "abcdefghi", -1)]
    [DataRow("t", "abcdefghit", 0)]
    [DataRow("testtest", "abcdfghi", -1)]
    [DataRow("testtest", "abcdfghit", 0)]
    [DataRow("", "abcdefghit", -1)]
    [DataRow("t", "", -1)]
    [DataRow("t", null, -1)]
    [DataRow("", null, -1)]
    [DataRow("testtest", "", -1)]
    public void IndexOfAnyTest3(string testStr, string? needles, int expectedIndex)
        => Assert.AreEqual(expectedIndex, 
                           SpanPolyfillExtension.IndexOfAny(testStr.ToCharArray().AsSpan(), SearchValuesPolyfill.Create(needles)));

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void IndexOfAnyTest4()
        => SpanPolyfillExtension.IndexOfAny("abc".ToCharArray().AsSpan(), (SearchValuesPolyfill<char>?)null!);

    [TestMethod]
    public void IndexOfAnyTest5()
        => Assert.AreEqual(1, SpanPolyfillExtension.IndexOfAny("abc".ToCharArray().AsSpan(), "1b2".AsSpan()));

    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("abc", "ab")]
    [DataRow("abc", "AB")]
    public void StartsWithTest1(string input, string starter)
       => Assert.AreEqual(input.AsSpan().StartsWith(starter.AsSpan(), StringComparison.OrdinalIgnoreCase),
                          SpanPolyfillExtension.StartsWith(input.ToCharArray().AsSpan(), starter, StringComparison.OrdinalIgnoreCase));

    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("abc", "ab")]
    [DataRow("abc", "AB")]
    public void StartsWithTest2(string input, string starter)
       => Assert.AreEqual(input.AsSpan().StartsWith(starter.AsSpan()),
                          SpanPolyfillExtension.StartsWith(input.ToCharArray().AsSpan(), starter));

    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("abc", "bc")]
    [DataRow("abc", "BC")]
    public void EndsWithTest1(string input, string end)
       => Assert.AreEqual(input.AsSpan().EndsWith(end.AsSpan(), StringComparison.OrdinalIgnoreCase),
                          SpanPolyfillExtension.EndsWith(input.ToCharArray().AsSpan(), end, StringComparison.OrdinalIgnoreCase));

    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("abc", "bc")]
    [DataRow("abc", "BC")]
    public void EndsWithTest2(string input, string end)
       => Assert.AreEqual(input.AsSpan().EndsWith(end.AsSpan()),
                          SpanPolyfillExtension.EndsWith(input.ToCharArray().AsSpan(), end));

    [DataTestMethod]
    [DataRow("", "abc", StringComparison.Ordinal)]
    [DataRow("abc", "bc", StringComparison.Ordinal)]
    [DataRow("abc", "BC", StringComparison.OrdinalIgnoreCase)]
    public void IndexOfTest1(string input, string end, StringComparison comp)
       => Assert.AreEqual(input.AsSpan().IndexOf(end.AsSpan(), comp),
                          SpanPolyfillExtension.IndexOf(input.ToCharArray().AsSpan(), end, comp));

    [DataTestMethod]
    [DataRow("", "", 0)]
    [DataRow("", "abc", 0)]
    [DataRow("abc", "", 0)]
    [DataRow("abc", "abc", 3)]
    [DataRow("abc", "abC", 2)]
    [DataRow("abC", "abc", 2)]
    public void CommonPrefixLengthTest1(string input, string? other, int expected)
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().CommonPrefixLength(other));

    [DataTestMethod]
    [DataRow("", "", 0)]
    [DataRow("", "abc", 0)]
    [DataRow("abc", "", 0)]
    [DataRow("abc", "abc", 3)]
    [DataRow("abc", "abC", 2)]
    [DataRow("abC", "abc", 2)]
    public void CommonPrefixLengthTest2(string input, string? other, int expected)
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().CommonPrefixLength(other, null));

    [DataTestMethod]
    [DataRow("", "", 0)]
    [DataRow("", "abc", 0)]
    [DataRow("abc", "", 0)]
    [DataRow("abc", "abc", 3)]
    [DataRow("abc", "abC", 2)]
    [DataRow("abC", "abc", 2)]
    public void CommonPrefixLengthTest3(string input, string? other, int expected)
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().CommonPrefixLength(other, EqualityComparer<char>.Default));

    [DataTestMethod]
    [DataRow("", "", 0)]
    [DataRow("", "abc", 0)]
    [DataRow("abc", "", 0)]
    [DataRow("abc", "abc", 3)]
    [DataRow("abc", "abC", 3)]
    [DataRow("abC", "abc", 3)]
    public void CommonPrefixLengthTest4(string input, string? other, int expected)
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().CommonPrefixLength(other, new CharComparer()));

    [DataTestMethod]
    [DataRow("", "", 0)]
    [DataRow("", "abc", 0)]
    [DataRow("abc", "", 0)]
    [DataRow("abc", "abc", 3)]
    [DataRow("abc", "abC", 2)]
    [DataRow("abC", "abc", 2)]
    public void CommonPrefixLengthTest5(string input, string? other, int expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.CommonPrefixLength(input.ToCharArray().AsSpan(), other.AsSpan()));

    [DataTestMethod]
    [DataRow("", "", 0)]
    [DataRow("", "abc", 0)]
    [DataRow("abc", "", 0)]
    [DataRow("abc", "abc", 3)]
    [DataRow("abc", "abC", 2)]
    [DataRow("abC", "abc", 2)]
    public void CommonPrefixLengthTest6(string input, string? other, int expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.CommonPrefixLength(input.ToCharArray().AsSpan(), other.AsSpan(), null));

    [DataTestMethod]
    [DataRow("", 'a', 'b', -1)]
    [DataRow("", 'b', 'a', -1)]
    [DataRow("", 'a', 'a', -1)]
    [DataRow("z", 'a', 'b', -1)]
    [DataRow("z", 'b', 'a', 0)]
    [DataRow("z", 'a', 'a', -1)]
    [DataRow("zax", 'a', 'b', 1)]
    [DataRow("zax", 'b', 'a', 0)]
    [DataRow("zax", 'a', 'a', 1)]
    [DataRow("zbx", 'a', 'b', 1)]
    [DataRow("zbx", 'a', 'c', 1)]
    [DataRow("zabx", 'b', 'c', 2)]
    public void IndexOfAnyInRangeTest1(string input, char lower, char upper, int expected)
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().IndexOfAnyInRange(lower, upper));

    [DataTestMethod]
    [DataRow("", 'a', 'b', -1)]
    [DataRow("", 'b', 'a', -1)]
    [DataRow("", 'a', 'a', -1)]
    [DataRow("z", 'a', 'b', -1)]
    [DataRow("z", 'b', 'a', 0)]
    [DataRow("z", 'a', 'a', -1)]
    [DataRow("zax", 'a', 'b', 1)]
    [DataRow("zax", 'b', 'a', 0)]
    [DataRow("zax", 'a', 'a', 1)]
    [DataRow("zbx", 'a', 'b', 1)]
    [DataRow("zbx", 'a', 'c', 1)]
    [DataRow("zabx", 'b', 'c', 2)]
    public void IndexOfAnyInRangeTest2(string input, char lower, char upper, int expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.IndexOfAnyInRange(input.ToCharArray().AsSpan(), lower, upper));


    [DataTestMethod]
    [DataRow("", 'a', 'b', false)]
    [DataRow("", 'b', 'a', false)]
    [DataRow("", 'a', 'a', false)]
    [DataRow("z", 'a', 'b', false)]
    [DataRow("z", 'b', 'a', true)]
    [DataRow("z", 'a', 'a', false)]
    [DataRow("zax", 'a', 'b', true)]
    [DataRow("zax", 'b', 'a', true)]
    [DataRow("zax", 'a', 'a', true)]
    [DataRow("zbx", 'a', 'b', true)]
    [DataRow("zbx", 'a', 'c', true)]
    [DataRow("zabx", 'b', 'c', true)]
    public void ContainsAnyInRangeTest1(string input, char lower, char upper, bool expected)
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().ContainsAnyInRange(lower, upper));

    [DataTestMethod]
    [DataRow("", 'a', 'b', false)]
    [DataRow("", 'b', 'a', false)]
    [DataRow("", 'a', 'a', false)]
    [DataRow("z", 'a', 'b', false)]
    [DataRow("z", 'b', 'a', true)]
    [DataRow("z", 'a', 'a', false)]
    [DataRow("zax", 'a', 'b', true)]
    [DataRow("zax", 'b', 'a', true)]
    [DataRow("zax", 'a', 'a', true)]
    [DataRow("zbx", 'a', 'b', true)]
    [DataRow("zbx", 'a', 'c', true)]
    [DataRow("zabx", 'b', 'c', true)]
    public void ContainsAnyInRangeTest2(string input, char lower, char upper, bool expected)
        => Assert.AreEqual(expected, SpanPolyfillExtension.ContainsAnyInRange(input.ToCharArray().AsSpan(), lower, upper));

    public class CharComparer : IEqualityComparer<char>
    {
        public bool Equals(char x, char y) => x.ToUpperInvariant() == y.ToUpperInvariant();
        public int GetHashCode(char obj) => obj.ToUpperInvariant().GetHashCode();
    }
}
