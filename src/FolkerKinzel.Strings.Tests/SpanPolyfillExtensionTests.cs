﻿using FolkerKinzel.Strings;

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
    [DataRow("   ", -1)]
    [DataRow("a", 0)]
    [DataRow(" a ", 1)]
    public void LastIndexOfAnyExceptTest1(string input, int expected)
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().LastIndexOfAnyExcept(' '));

    [DataTestMethod]
    [DataRow("", 'x')]
    [DataRow("abc", 'x')]
    [DataRow("abc", 'B')]
    [DataRow("abc", 'b')]
    [DataRow("ABC", 'b')]
    public void ContainsTest1(string input, char c)
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
    [DataRow("xxxabc  ", "bc")]
    [DataRow("xxxabc  ", "bcd")]
    [DataRow("xxxabc  ", "")]
    [DataRow("xxxabc   ", "BC")]
    public void ContainsTest1(string input, string needle)
       => Assert.AreEqual(input.AsSpan().Contains(needle.AsSpan(), StringComparison.OrdinalIgnoreCase),
                          input.ToCharArray().AsSpan().Contains(needle, StringComparison.OrdinalIgnoreCase));


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
    public void LastIndexOfAnyTest1()
        => Assert.AreEqual(1, "abc".ToCharArray().AsSpan().LastIndexOfAny("1b2"));

    [TestMethod]
    public void LastIndexOfAnyTest2()
       => Assert.AreEqual(1, "abc".ToCharArray().AsSpan().LastIndexOfAny("1b2", 1, 1));

    [TestMethod]
    public void IndexOfAnyTest1()
        => Assert.AreEqual(1, "abc".ToCharArray().AsSpan().IndexOfAny("1b2"));


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
