﻿namespace FolkerKinzel.Strings.Tests;

[TestClass]
public class SpanExtensionTests
{
    [TestMethod]
    public void TrimTest1()
    {
        const string trimChars = "\'\"";

        string test = "\"\'Test\'\"";

        Assert.AreEqual(test.Trim(trimChars), test.ToCharArray().AsSpan().Trim(SearchValuesPolyfill.Create(trimChars)).ToString());
    }

    [TestMethod]
    public void TrimTest2()
    {
        string test = "  Test  ";

        Assert.AreEqual(test, test.ToCharArray().AsSpan().Trim(SearchValuesPolyfill.Create("")).ToString());
    }

    [TestMethod]
    public void TrimTest3()
    {
        const string trimChars = "\'\"";

        string test = "\"\'\'\"";
        Assert.AreEqual("", test.ToCharArray().AsSpan().Trim(SearchValuesPolyfill.Create(trimChars)).ToString());
    }


    [TestMethod]
    public void TrimTest4()
    {
        string test = "    ";
        Assert.AreEqual(test, test.ToCharArray().AsSpan().Trim(SearchValuesPolyfill.Create("")).ToString());
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TrimTest5() => ReadOnlySpan<char>.Empty.Trim((SearchValuesPolyfill<char>?)null!);


    [TestMethod]
    public void TrimTest6()
    {
        const string trimChars = "\'\"";

        string test = "Test";
        Assert.AreEqual(test, test.ToCharArray().AsSpan().Trim(SearchValuesPolyfill.Create(trimChars)).ToString());
    }

    [TestMethod]
    public void TrimStartTest1()
    {
        const string trimChars = "\'\"";

        string test = "\"\'Test\'\"";

        Assert.AreEqual(test.TrimStart(trimChars), test.ToCharArray().AsSpan().TrimStart(SearchValuesPolyfill.Create(trimChars)).ToString());
    }

    [TestMethod]
    public void TrimStartTest2()
    {
        string test = "  Test  ";
        Assert.AreEqual(test, test.ToCharArray().AsSpan().TrimStart(SearchValuesPolyfill.Create("")).ToString());
    }

    [TestMethod]
    public void TrimStartTest3()
    {
        const string trimChars = "\'\"";
        string test = "\"\'\'\"";
        Assert.AreEqual("", test.ToCharArray().AsSpan().TrimStart(SearchValuesPolyfill.Create(trimChars)).ToString());
    }


    [TestMethod]
    public void TrimStartTest4()
    {
        string test = "    ";
        Assert.AreEqual(test, test.ToCharArray().AsSpan().TrimStart(SearchValuesPolyfill.Create("")).ToString());
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TrimStartTest5() => ReadOnlySpan<char>.Empty.TrimStart((SearchValuesPolyfill<char>?)null!);


    [TestMethod]
    public void TrimStartTest6()
    {
        const string trimChars = "\'\"";

        string test = "Test";
        Assert.AreEqual(test, test.ToCharArray().AsSpan().TrimStart(SearchValuesPolyfill.Create(trimChars)).ToString());
    }

    [TestMethod]
    public void TrimEndTest1()
    {
        const string trimChars = "\'\"";

        string test = "\"\'Test\'\"";

        Assert.AreEqual(test.TrimEnd(trimChars), test.ToCharArray().AsSpan().TrimEnd(SearchValuesPolyfill.Create(trimChars)).ToString());
    }

    [TestMethod]
    public void TrimEndTest2()
    {
        string test = "  Test  ";
        Assert.AreEqual(test, test.ToCharArray().AsSpan().TrimEnd(SearchValuesPolyfill.Create("")).ToString());
    }

    [TestMethod]
    public void TrimEndTest3()
    {
        const string trimChars = "\'\"";
        string test = "\"\'\'\"";
        Assert.AreEqual("", test.ToCharArray().AsSpan().TrimEnd(SearchValuesPolyfill.Create(trimChars)).ToString());
    }


    [TestMethod]
    public void TrimEndTest4()
    {
        string test = "    ";
        Assert.AreEqual(test, test.ToCharArray().AsSpan().TrimStart(SearchValuesPolyfill.Create("")).ToString());
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TrimEndTest5() => ReadOnlySpan<char>.Empty.TrimEnd((SearchValuesPolyfill<char>?)null!);

    [TestMethod]
    public void TrimEndTest6()
    {

        const string trimChars = "\'\"";

        string test = "Test";
        Assert.AreEqual(test, test.ToCharArray().AsSpan().TrimEnd(SearchValuesPolyfill.Create(trimChars)).ToString());
    }

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


    //[DataTestMethod]
    //[DataRow("")]
    //[DataRow("abc")]
    //[DataRow("  abc")]
    //[DataRow("  abc   ")]
    //public void GetTrimmedStartTest1(string input)
    //    => Assert.AreEqual(input.AsSpan().GetTrimmedStart(), input.ToCharArray().AsSpan().GetTrimmedStart());


    //[DataTestMethod]
    //[DataRow("")]
    //[DataRow("abc")]
    //[DataRow("  abc")]
    //[DataRow("  abc   ")]
    //public void GetTrimmedLengthTest1(string input)
    //   => Assert.AreEqual(input.AsSpan().GetTrimmedLength(), input.ToCharArray().AsSpan().GetTrimmedLength());

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
    [DataRow("", "abc")]
    [DataRow("abc", "ab")]
    [DataRow("abc", "AB")]
    public void StartsWithTest1(string input, string starter)
       => Assert.AreEqual(input.AsSpan().StartsWith(starter.AsSpan(), StringComparison.OrdinalIgnoreCase),
                          input.ToCharArray().AsSpan().StartsWith(starter.AsSpan(), StringComparison.OrdinalIgnoreCase));

    [DataTestMethod]
    [DataRow("", 'a')]
    [DataRow("abc", 'a')]
    [DataRow("abc", 'A')]
    public void StartsWithTest2(string input, char starter)
       => Assert.AreEqual(input.AsSpan().StartsWith(starter),
                          input.ToCharArray().AsSpan().StartsWith(starter));

    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("abc", "bc")]
    [DataRow("abc", "BC")]
    public void EndsWithTest1(string input, string end)
       => Assert.AreEqual(input.AsSpan().EndsWith(end.AsSpan(), StringComparison.OrdinalIgnoreCase),
                          input.ToCharArray().AsSpan().EndsWith(end.AsSpan(), StringComparison.OrdinalIgnoreCase));


    [DataTestMethod]
    [DataRow("", 'c')]
    [DataRow("abc", 'c')]
    [DataRow("abc", 'C')]
    public void EndsWithTest2(string input, char end)
       => Assert.AreEqual(input.AsSpan().EndsWith(end),
                          input.ToCharArray().AsSpan().EndsWith(end));


    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("", "")]
    [DataRow("xxxabc  ", "bc")]
    [DataRow("xxxabc  ", "bcd")]
    [DataRow("xxxabc  ", "")]
    [DataRow("xxxabc   ", "BC")]
    public void LastIndexOfTest1(string input, string end)
       => Assert.AreEqual(input.AsSpan().LastIndexOf(end.AsSpan(), StringComparison.OrdinalIgnoreCase),
                          input.ToCharArray().AsSpan().LastIndexOf(end.AsSpan(), StringComparison.OrdinalIgnoreCase));


    //[TestMethod]
    //public void OnlyDebugging()
    //{
    //    // ReadOnlySpanPolyfillExtension.LastIndexOf(this ReadOnlySpan<char> span, ReadOnlySpan<char> value, StringComparison comparisonType)
    //    const string test = "ab";

    //    int stringIndex = test.LastIndexOf("", StringComparison.OrdinalIgnoreCase);
    //    int roSpanIndex = test.AsSpan().LastIndexOf("".AsSpan(), StringComparison.OrdinalIgnoreCase);
    //    int spanIndex = test.ToCharArray().AsSpan().LastIndexOf("".AsSpan(), StringComparison.OrdinalIgnoreCase);

    //    int stringIndex1 = test.LastIndexOf("", StringComparison.Ordinal);
    //    int roSpanIndex1 = test.AsSpan().LastIndexOf("".AsSpan(), StringComparison.Ordinal);
    //    int spanIndex1 = test.ToCharArray().AsSpan().LastIndexOf("".AsSpan(), StringComparison.Ordinal);

    //    int stringIndex2 = "".LastIndexOf("", StringComparison.OrdinalIgnoreCase);
    //    int roSpanIndex2 = "".AsSpan().LastIndexOf("".AsSpan(), StringComparison.OrdinalIgnoreCase);
    //    int spanIndex2 =   "".ToCharArray().AsSpan().LastIndexOf("".AsSpan(), StringComparison.OrdinalIgnoreCase);
    //}


    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("", "")]
    [DataRow("xxxabc  ", "bc")]
    [DataRow("xxxabc  ", "bcd")]
    [DataRow("xxxabc  ", "")]
    [DataRow("xxxabc   ", "BC")]
    public void LastIndexOfTest2(string input, string end)
       => Assert.AreEqual(input.AsSpan().LastIndexOf(end.AsSpan(), input.Length - 1, input.Length, StringComparison.OrdinalIgnoreCase),
                          input.ToCharArray().AsSpan().LastIndexOf(end.AsSpan(), input.Length - 1, input.Length, StringComparison.OrdinalIgnoreCase));

    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("", "")]
    [DataRow("xxxabc  ", "bc")]
    [DataRow("xxxabc  ", "bcd")]
    [DataRow("xxxabc  ", "")]
    [DataRow("xxxabc   ", "BC")]
    public void LastIndexOfTest3(string input, string end)
       => Assert.AreEqual(input.AsSpan().LastIndexOf(end.AsSpan(), StringComparison.Ordinal),
                          input.ToCharArray().AsSpan().LastIndexOf(end.AsSpan(), StringComparison.Ordinal));

    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("", "")]
    [DataRow("xxxabc  ", "bc")]
    [DataRow("xxxabc  ", "bcd")]
    [DataRow("xxxabc  ", "")]
    [DataRow("xxxabc   ", "BC")]
    public void LastIndexOfTest4(string input, string end)
       => Assert.AreEqual(input.AsSpan().LastIndexOf(end.AsSpan(), input.Length - 1, input.Length, StringComparison.Ordinal),
                          input.ToCharArray().AsSpan().LastIndexOf(end.AsSpan(), input.Length - 1, input.Length, StringComparison.Ordinal));



    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("", "")]
    [DataRow("xxxabc  ", "bc")]
    [DataRow("xxxabc  ", "bcd")]
    [DataRow("xxxabc  ", "")]
    [DataRow("xxxabc   ", "BC")]
    public void ContainsTest1(string input, string needle)
       => Assert.AreEqual(input.AsSpan().Contains(needle.AsSpan(), StringComparison.OrdinalIgnoreCase),
                          input.ToCharArray().AsSpan().Contains(needle.AsSpan(), StringComparison.OrdinalIgnoreCase));


    [DataTestMethod]
    [DataRow("", "abc")]
    [DataRow("", "")]
    [DataRow("abc  ", "abc")]
    [DataRow("abc  ", "ABC")]
    [DataRow("abc  ", "abcd")]
    public void EqualsTest1(string input, string comparison)
       => Assert.AreEqual(input.AsSpan().Equals(comparison.AsSpan(), StringComparison.OrdinalIgnoreCase),
                          input.ToCharArray().AsSpan().Equals(comparison.AsSpan(), StringComparison.OrdinalIgnoreCase));

    [DataTestMethod]
    [DataRow("", "abc", StringComparison.Ordinal)]
    [DataRow("abc", "bc", StringComparison.Ordinal)]
    [DataRow("abc", "BC", StringComparison.OrdinalIgnoreCase)]
    public void IndexOfTest1(string input, string end, StringComparison comp)
       => Assert.AreEqual(input.AsSpan().IndexOf(end.AsSpan(), comp),
                          input.ToCharArray().AsSpan().IndexOf(end.AsSpan(), comp));

}
