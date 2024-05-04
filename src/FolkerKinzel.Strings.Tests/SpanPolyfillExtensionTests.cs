using System.Buffers;
using System;
using FolkerKinzel.Strings;

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
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().IndexOfAnyExcept(' '));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("baababb", -1)]
    [DataRow("xxba", 0)]
    [DataRow("bxxxx", 1)]
    public void IndexOfAnyExceptTest2(string input, int expected)
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().IndexOfAnyExcept('a', 'b'));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cbaabccabbc", -1)]
    [DataRow("xxbca", 0)]
    [DataRow("bxxxx", 1)]
    public void IndexOfAnyExceptTest3(string input, int expected)
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().IndexOfAnyExcept('a', 'b', 'c'));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cbaaddbccadbbcd", -1)]
    [DataRow("xxbcdda", 0)]
    [DataRow("bxxxx", 1)]
    public void IndexOfAnyExceptTest4(string input, int expected)
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().IndexOfAnyExcept("abcd"));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cbaaddbccadbbcd", -1)]
    [DataRow("xxbcdda", 0)]
    [DataRow("bxxxx", 1)]
    public void IndexOfAnyExceptTest5(string input, int expected)
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().IndexOfAnyExcept("abcd".AsSpan()));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cbaaddbccadbbcd", -1)]
    [DataRow("xxbcdda", 0)]
    [DataRow("bxxxx", 1)]
    public void IndexOfAnyExceptTest6(string input, int expected)
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().IndexOfAnyExcept(SearchValues.Create("abcd")));

    [TestMethod()]
    [ExpectedException(typeof(ArgumentNullException))]
    public void IndexOfAnyExceptTest7()
        => "xyz".ToCharArray().AsSpan().IndexOfAnyExcept((SearchValues<char>?)null!);

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("   ", -1)]
    [DataRow("a", 0)]
    [DataRow(" a ", 1)]
    public void LastIndexOfAnyExceptTest1(string input, int expected)
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().LastIndexOfAnyExcept(' '));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("abbaaba", -1)]
    [DataRow("xbbaba", 0)]
    [DataRow("bxabbbababba", 1)]
    public void LastIndexOfAnyExceptTest2(string input, int expected)
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().LastIndexOfAnyExcept('a', 'b'));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cabbaccaabca", -1)]
    [DataRow("xbbabcca", 0)]
    [DataRow("bxabbbabcabba", 1)]
    public void LastIndexOfAnyExceptTest3(string input, int expected)
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().LastIndexOfAnyExcept('a', 'b', 'c'));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cabbadccaabcddad", -1)]
    [DataRow("xbbabcdcadd", 0)]
    [DataRow("bxabbbadbdcabba", 1)]
    public void LastIndexOfAnyExceptTest4(string input, int expected)
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().LastIndexOfAnyExcept("abcd"));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cabbadccaabcddad", -1)]
    [DataRow("xbbabcdcadd", 0)]
    [DataRow("bxabbbadbdcabba", 1)]
    public void LastIndexOfAnyExceptTest5(string input, int expected)
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().LastIndexOfAnyExcept("abcd".AsSpan()));

    [DataTestMethod()]
    [DataRow("", -1)]
    [DataRow("cabbadccaabcddad", -1)]
    [DataRow("xbbabcdcadd", 0)]
    [DataRow("bxabbbadbdcabba", 1)]
    public void LastIndexOfAnyExceptTest6(string input, int expected)
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().LastIndexOfAnyExcept(SearchValues.Create("abcd")));

    [TestMethod()]
    [ExpectedException(typeof(ArgumentNullException))]
    public void LastIndexOfAnyExceptTest7()
        => "xyz".ToCharArray().AsSpan().LastIndexOfAnyExcept((SearchValues<char>?)null!);

    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("", "")]
    [DataRow("xxxabc  ", "bc")]
    [DataRow("xxxabc  ", "bcd")]
    [DataRow("xxxabc  ", "")]
    [DataRow("xxxabc   ", "BC")]
    public void ContainsTest1a(string input, string needle)
       => Assert.AreEqual(input.AsSpan().Contains(needle.AsSpan(), StringComparison.OrdinalIgnoreCase),
                          input.ToCharArray().AsSpan().Contains(needle, StringComparison.OrdinalIgnoreCase));

    [DataTestMethod]
    [DataRow("", 'x')]
    [DataRow("abc", 'x')]
    [DataRow("abc", 'B')]
    [DataRow("abc", 'b')]
    [DataRow("ABC", 'b')]
    public void ContainsTest1b(string input, char c)
        => Assert.AreEqual(input.AsSpan().Contains(c), input.ToArray().AsSpan().Contains(c));

    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("", "")]
    [DataRow("xxxabc  ", "bc")]
    [DataRow("xxxabc  ", "bcd")]
    [DataRow("xxxabc  ", "")]
    [DataRow("xxxabc   ", "BC")]
    public void ContainsTest2(string input, string needle)
       => Assert.AreEqual(input.AsSpan().Contains(needle.AsSpan(), StringComparison.OrdinalIgnoreCase),
                          input.ToCharArray().AsSpan().Contains(needle, StringComparison.OrdinalIgnoreCase));

    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("", "")]
    [DataRow("xxxabc  ", "bc")]
    [DataRow("xxxabc  ", "bcd")]
    [DataRow("xxxabc  ", "")]
    [DataRow("xxxabc   ", "BC")]
    public void ContainsTest3(string input, string needle)
       => Assert.AreEqual(input.AsSpan().Contains(needle.AsSpan(), StringComparison.Ordinal),
                          input.ToCharArray().AsSpan().Contains(needle, StringComparison.Ordinal));

    [DataTestMethod]
    [DataRow("")]
    [DataRow("  ")]
    [DataRow("abc")]
    [DataRow("  \r\na b c  ")]
    public void TrimTest1(string input)
        => Assert.AreEqual(input.AsSpan().Trim().ToString(), input.ToCharArray().AsSpan().Trim().ToString());

    [DataTestMethod]
    [DataRow("")]
    [DataRow("  ")]
    [DataRow("abc")]
    [DataRow("  \r\na b c  ")]
    public void TrimStartTest1(string input)
        => Assert.AreEqual(input.AsSpan().TrimStart().ToString(), input.ToArray().AsSpan().TrimStart().ToString());

    [DataTestMethod]
    [DataRow("")]
    [DataRow("  ")]
    [DataRow("abc")]
    [DataRow("  \r\na b c  ")]
    public void TrimEndTest1(string input)
        => Assert.AreEqual(input.AsSpan().TrimEnd().ToString(), input.ToArray().AsSpan().TrimEnd().ToString());



    [DataTestMethod]
    [DataRow("", "")]
    [DataRow("xxx", "")]
    [DataRow("abc", "abc")]
    [DataRow("xxx\r\na b cxxx", "\r\na b c")]
    public void TrimTest2(string input, string expected)
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().Trim('x').ToString());

    [DataTestMethod]
    [DataRow("", "")]
    [DataRow("xxx", "")]
    [DataRow("abc", "abc")]
    [DataRow("xxx\r\na b cxxx", "\r\na b cxxx")]
    public void TrimStartTest2(string input, string expected)
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().TrimStart('x').ToString());

    [DataTestMethod]
    [DataRow("", "")]
    [DataRow("xxx", "")]
    [DataRow("abc", "abc")]
    [DataRow("xxx\r\na b cxxx", "xxx\r\na b c")]
    public void TrimEndTest2(string input, string expected)
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().TrimEnd('x').ToString());

    


    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("", "")]
    [DataRow("abc  ", "abc")]
    [DataRow("abc  ", "ABC")]
    [DataRow("abc  ", "abcd")]
    public void EqualsTest1(string input, string comparison)
       => Assert.AreEqual(input.AsSpan().Equals(comparison.AsSpan(), StringComparison.OrdinalIgnoreCase),
                          input.ToCharArray().AsSpan().Equals(comparison, StringComparison.OrdinalIgnoreCase));

    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("", "")]
    [DataRow("xxxabc  ", "bc")]
    [DataRow("xxxabc  ", "bcd")]
    [DataRow("xxxabc  ", "")]
    [DataRow("xxxabc   ", "BC")]
    public void LastIndexOfTest1(string input, string end)
      => Assert.AreEqual(input.AsSpan().LastIndexOf(end.AsSpan(), StringComparison.OrdinalIgnoreCase),
                         input.ToCharArray().AsSpan().LastIndexOf(end, StringComparison.OrdinalIgnoreCase));

    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("", "")]
    [DataRow("xxxabc  ", "bc")]
    [DataRow("xxxabc  ", "bcd")]
    [DataRow("xxxabc  ", "")]
    [DataRow("xxxabc   ", "BC")]
    public void LastIndexOfTest2(string input, string end)
       => Assert.AreEqual(input.AsSpan().LastIndexOf(end.AsSpan(), input.Length - 1, input.Length, StringComparison.OrdinalIgnoreCase),
                          input.ToCharArray().AsSpan().LastIndexOf(end, input.Length - 1, input.Length, StringComparison.OrdinalIgnoreCase));

    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("", "")]
    [DataRow("xxxabc  ", "bc")]
    [DataRow("xxxabc  ", "bcd")]
    [DataRow("xxxabc  ", "")]
    [DataRow("xxxabc   ", "BC")]
    public void LastIndexOfTest3(string input, string end)
      => Assert.AreEqual(input.AsSpan().LastIndexOf(end.AsSpan(), StringComparison.Ordinal),
                         input.ToCharArray().AsSpan().LastIndexOf(end, StringComparison.Ordinal));

    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("", "")]
    [DataRow("xxxabc  ", "bc")]
    [DataRow("xxxabc  ", "bcd")]
    [DataRow("xxxabc  ", "")]
    [DataRow("xxxabc   ", "BC")]
    public void LastIndexOfTest4(string input, string end)
       => Assert.AreEqual(input.AsSpan().LastIndexOf(end.AsSpan(), input.Length - 1, input.Length, StringComparison.Ordinal),
                          input.ToCharArray().AsSpan().LastIndexOf(end, input.Length - 1, input.Length, StringComparison.Ordinal));

    [DataTestMethod]
    [DataRow("", "xyz")]
    [DataRow("abc", "xyz")]
    [DataRow("abc", "")]
    [DataRow("abc", "xbz")]
    public void ContainsAnyTest1(string input, string chars)
        => Assert.AreEqual(input.AsSpan().ContainsAny(chars.AsSpan()), input.ToCharArray().AsSpan().ContainsAny(chars));

    [TestMethod]
    public void ContainsAnyTest2() => Assert.IsFalse("t".ToCharArray().AsSpan().ContainsAny(SearchValues.Create("")));

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ContainsAnyTest3() => Assert.IsFalse("t".ToCharArray().AsSpan().ContainsAny((SearchValues<char>?)null!));


    [TestMethod]
    public void LastIndexOfAnyTest1()
        => Assert.AreEqual(1, "abc".ToCharArray().AsSpan().LastIndexOfAny("1b2"));

    [TestMethod]
    public void LastIndexOfAnyTest2()
        => Assert.AreEqual(1, "abc".ToCharArray().AsSpan().LastIndexOfAny("1b2".AsSpan()));

    [TestMethod]
    public void LastIndexOfAnyTest3()
       => Assert.AreEqual(1, "abc".ToCharArray().AsSpan().LastIndexOfAny("1b2", 1, 1));

    [TestMethod]
    public void LastIndexOfAnyTest4()
        => Assert.AreEqual(1, "abc".ToCharArray().AsSpan().LastIndexOfAny(SearchValues.Create("1b2")));

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void LastIndexOfAnyTest5()
        => Assert.AreEqual(1, "abc".ToCharArray().AsSpan().LastIndexOfAny((SearchValues<char>?)null!));

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void LastIndexOfAnyTest6()
        => Assert.AreEqual(1, "abc".ToCharArray().AsSpan().LastIndexOfAny((SearchValues<char>?)null!, 1, 1));

    [TestMethod]
    public void LastIndexOfAnyTest7()
       => Assert.AreEqual(1, "abc".ToCharArray().AsSpan().LastIndexOfAny(SearchValues.Create("1b2"), 1, 1));

    [TestMethod]
    public void IndexOfAnyTest1()
        => Assert.AreEqual(1, "abc".ToCharArray().AsSpan().IndexOfAny("1b2"));

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
        => Assert.AreEqual(expectedIndex, testStr.ToCharArray().AsSpan().IndexOfAny(SearchValues.Create(needles)));

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void IndexOfAnyTest4()
        => "abc".ToCharArray().AsSpan().IndexOfAny((SearchValues<char>?)null!);


    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("abc", "ab")]
    [DataRow("abc", "AB")]
    public void StartsWithTest1(string input, string starter)
       => Assert.AreEqual(input.AsSpan().StartsWith(starter.AsSpan(), StringComparison.OrdinalIgnoreCase),
                          input.ToCharArray().AsSpan().StartsWith(starter, StringComparison.OrdinalIgnoreCase));

    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("abc", "ab")]
    [DataRow("abc", "AB")]
    public void StartsWithTest2(string input, string starter)
       => Assert.AreEqual(input.AsSpan().StartsWith(starter.AsSpan()),
                          input.ToCharArray().AsSpan().StartsWith(starter));




    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("abc", "bc")]
    [DataRow("abc", "BC")]
    public void EndsWithTest1(string input, string end)
       => Assert.AreEqual(input.AsSpan().EndsWith(end.AsSpan(), StringComparison.OrdinalIgnoreCase),
                          input.ToCharArray().AsSpan().EndsWith(end, StringComparison.OrdinalIgnoreCase));


    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("abc", "bc")]
    [DataRow("abc", "BC")]
    public void EndsWithTest2(string input, string end)
       => Assert.AreEqual(input.AsSpan().EndsWith(end.AsSpan()),
                          input.ToCharArray().AsSpan().EndsWith(end));

    [DataTestMethod]
    [DataRow("", "abc", StringComparison.Ordinal)]
    [DataRow("abc", "bc", StringComparison.Ordinal)]
    [DataRow("abc", "BC", StringComparison.OrdinalIgnoreCase)]
    public void IndexOfTest1(string input, string end, StringComparison comp)
       => Assert.AreEqual(input.AsSpan().IndexOf(end.AsSpan(), comp),
                          input.ToCharArray().AsSpan().IndexOf(end, comp));



    

    

    
}
