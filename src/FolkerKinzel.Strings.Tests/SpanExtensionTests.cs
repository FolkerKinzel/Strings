using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Tests;

[TestClass]
public class SpanExtensionTests
{
    [DataTestMethod]
    [DataRow("", "")]
    [DataRow("12", "12")]
    [DataRow("AB", "AB")]
    [DataRow("ab", "AB")]
    [DataRow("aB", "AB")]
    [DataRow(" 12 aB ", " 12 AB ")]
    public void ToUpperInvariantTest1(string input, string expected)
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().ToUpperInvariant().ToString());


    [DataTestMethod]
    [DataRow("", "")]
    [DataRow("12", "12")]
    [DataRow("ab", "ab")]
    [DataRow("AB", "ab")]
    [DataRow("aB", "ab")]
    [DataRow(" 12 aB ", " 12 ab ")]
    public void ToLowerInvariantTest1(string input, string expected)
        => Assert.AreEqual(expected, input.ToCharArray().AsSpan().ToLowerInvariant().ToString());

    [TestMethod]
    public void LastIndexOfAnyTest1()
        => Assert.AreEqual(1, "abc".ToCharArray().AsSpan().LastIndexOfAny("1b2".AsSpan()));

    [TestMethod]
    public void LastIndexOfAnyTest2()
       => Assert.AreEqual(1, "abc".ToCharArray().AsSpan().LastIndexOfAny("1b2".AsSpan(), 1, 1));


    [DataTestMethod]
    [DataRow("")]
    [DataRow(" \r\n ")]
    [DataRow(" \r\nx ")]
    public void IsWhiteSpaceTest1(string input)
       => Assert.AreEqual(input.AsSpan().IsWhiteSpace(), input.ToCharArray().AsSpan().IsWhiteSpace());


    [DataTestMethod]
    [DataRow("")]
    [DataRow(" \r\n AbC123;.:")]
    [DataRow("ähh")]
    public void IsAsciiTest1(string input)
       => Assert.AreEqual(input.AsSpan().IsAscii(), input.ToCharArray().AsSpan().IsAscii());


    [TestMethod]
    public void IndexOfAnyTest1()
        => Assert.AreEqual(1, "abc".ToCharArray().AsSpan().IndexOfAny("1b2".AsSpan()));

    [DataTestMethod]
    [DataRow("")]
    [DataRow("abc")]
    [DataRow("  abc")]
    [DataRow("  abc   ")]
    public void GetTrimmedStartTest1(string input)
        => Assert.AreEqual(input.AsSpan().GetTrimmedStart(), input.ToCharArray().AsSpan().GetTrimmedStart());


    [DataTestMethod]
    [DataRow("")]
    [DataRow("abc")]
    [DataRow("  abc")]
    [DataRow("  abc   ")]
    public void GetTrimmedLengthTest1(string input)
       => Assert.AreEqual(input.AsSpan().GetTrimmedLength(), input.ToCharArray().AsSpan().GetTrimmedLength());

    [DataTestMethod]
    [DataRow("")]
    [DataRow("abc")]
    [DataRow("  abc")]
    [DataRow("  abc   ")]
    public void GetPersistentHashCodeTest1(string input)
       => Assert.AreEqual(input.AsSpan().GetPersistentHashCode(HashType.AlphaNumericIgnoreCase), 
                          input.ToCharArray().AsSpan().GetPersistentHashCode(HashType.AlphaNumericIgnoreCase));

    [DataTestMethod]
    [DataRow("")]
    [DataRow("abc")]
    [DataRow("  abc")]
    [DataRow("  abc   ")]
    public void ContainsWhiteSpaceTest1(string input)
       => Assert.AreEqual(input.AsSpan().ContainsWhiteSpace(),
                          input.ToCharArray().AsSpan().ContainsWhiteSpace());

    [DataTestMethod]
    [DataRow("")]
    [DataRow(" \r\n AbC123;.:")]
    [DataRow("ähh")]
    public void ContainsNewLineTest1(string input)
       => Assert.AreEqual(input.AsSpan().ContainsNewLine(), input.ToCharArray().AsSpan().ContainsNewLine());

    [DataTestMethod]
    [DataRow("", "xyz")]
    [DataRow("abc", "xyz")]
    [DataRow("abc", "")]
    [DataRow("abc", "xbz")]
    public void ContainsAnyTest1(string input, string chars) 
        => Assert.AreEqual(input.AsSpan().ContainsAny(chars.AsSpan()), input.ToCharArray().AsSpan().ContainsAny(chars.AsSpan()));

    [DataTestMethod]
    [DataRow("", "xyz")]
    [DataRow("abc", "xyz")]
    [DataRow("abc", "xbz")]
    public void ContainsAnyTest2(string input, string chars)
        => Assert.AreEqual(input.AsSpan().IndexOfAny(chars[0], chars[1]) != -1, input.ToCharArray().AsSpan().ContainsAny(chars[0], chars[1]));


    [DataTestMethod]
    [DataRow("", "xyz")]
    [DataRow("abc", "xyz")]
    [DataRow("abc", "xya")]
    public void ContainsAnyTest3(string input, string chars)
        => Assert.AreEqual(input.AsSpan().IndexOfAny(chars[0], chars[1], chars[2]) != -1, input.ToCharArray().AsSpan().ContainsAny(chars[0], chars[1], chars[2]));


    [DataTestMethod]
    [DataRow("")]
    [DataRow("abc")]
    [DataRow("  abc")]
    [DataRow("  abc   ")]
    public void StartsWithTest1(string input)
       => Assert.AreEqual(input.AsSpan().ContainsWhiteSpace(),
                          input.ToCharArray().AsSpan().ContainsWhiteSpace());

}
