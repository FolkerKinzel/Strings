using System.Globalization;

namespace FolkerKinzel.Strings.Tests;

[TestClass()]
public class StringPolyfillExtensionTests : IDisposable
{
    private readonly CultureInfo _culture;

    public StringPolyfillExtensionTests()
    {
        _culture = Thread.CurrentThread.CurrentCulture;
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");
    }

    public void Dispose()
    {
        Thread.CurrentThread.CurrentCulture = _culture;
        GC.SuppressFinalize(this);
    }

    [TestMethod]
    public void TrimTest1()
    {
        char[] trimChars = ['\'', '\"'];
        string test = "\"\'Test\'\"";
        Assert.AreEqual(test.Trim(trimChars), StringPolyfillExtension.Trim(test, trimChars.AsSpan()));
    }

    [TestMethod]
    public void TrimTest2()
    {
        string test = "  Test  ";
        Assert.AreEqual(test.Trim(null), StringPolyfillExtension.Trim(test, ""));
    }

    [TestMethod]
    public void TrimTest3()
    {
        char[] trimChars = ['\'', '\"'];
        string test = "\"\'\'\"";
        Assert.AreEqual(test.Trim(trimChars), StringPolyfillExtension.Trim(test, trimChars.AsSpan()));
    }

    [TestMethod]
    public void TrimTest4()
    {
        string test = "    ";
        Assert.AreEqual(test.Trim(null), StringPolyfillExtension.Trim(test, ""));
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void TrimTest5()
    {
        string? test = null;
        _ = StringPolyfillExtension.Trim(test!, "");
    }

    [TestMethod]
    public void TrimTest6()
    {
        char[] trimChars = ['\'', '\"'];
        string test = "Test";
        Assert.AreEqual(test.Trim(trimChars), StringPolyfillExtension.Trim(test, trimChars.AsSpan()));
    }

    [TestMethod]
    public void TrimStartTest1()
    {
        char[] trimChars = ['\'', '\"'];
        string test = "\"\'Test\'\"";
        Assert.AreEqual(test.TrimStart(trimChars), StringPolyfillExtension.TrimStart(test, trimChars.AsSpan()));
    }

    [TestMethod]
    public void TrimStartTest2()
    {
        string test = "  Test  ";
        Assert.AreEqual(test.TrimStart(null), StringPolyfillExtension.TrimStart(test, ""));
    }

    [TestMethod]
    public void TrimStartTest3()
    {
        char[] trimChars = ['\'', '\"'];
        string test = "\"\'\'\"";
        Assert.AreEqual(test.TrimStart(trimChars), StringPolyfillExtension.TrimStart(test, trimChars.AsSpan()));
    }


    [TestMethod]
    public void TrimStartTest4()
    {
        string test = "    ";
        Assert.AreEqual(test.TrimStart(null), StringPolyfillExtension.TrimStart(test, ""));
    }


    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void TrimStartTest5()
    {
        string? test = null;
        _ = StringPolyfillExtension.TrimStart(test!, "");
    }

    [TestMethod]
    public void TrimStartTest6()
    {
        char[] trimChars = ['\'', '\"'];
        string test = "Test";
        Assert.AreEqual(test.TrimStart(trimChars),
                        StringPolyfillExtension.TrimStart(test, trimChars.AsSpan()));
    }

    [TestMethod]
    public void TrimEndTest1()
    {
        char[] trimChars = ['\'', '\"'];
        string test = "\"\'Test\'\"";
        Assert.AreEqual(test.TrimEnd(trimChars), StringPolyfillExtension.TrimEnd(test, trimChars.AsSpan()));
    }

    [TestMethod]
    public void TrimEndTest2()
    {
        string test = "  Test  ";
        Assert.AreEqual(test.TrimEnd(null), StringPolyfillExtension.TrimEnd(test, ""));
    }

    [TestMethod]
    public void TrimEndTest3()
    {
        char[] trimChars = ['\'', '\"'];
        string test = "\"\'\'\"";
        Assert.AreEqual(test.TrimEnd(trimChars), StringPolyfillExtension.TrimEnd(test, trimChars.AsSpan()));
    }


    [TestMethod]
    public void TrimEndTest4()
    {
        string test = "    ";
        Assert.AreEqual(test.TrimEnd(null), StringPolyfillExtension.TrimEnd(test, ""));
    }


    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void TrimEndTest5()
    {
        string? test = null;
        _ = StringPolyfillExtension.TrimEnd(test!, "");
    }

    [TestMethod]
    public void TrimEndTest6()
    {
        char[] trimChars = ['\'', '\"'];
        string test = "Test\"";
        Assert.AreEqual(test.TrimEnd(trimChars),
                        StringPolyfillExtension.TrimEnd(test, trimChars.AsSpan()));
    }

    [TestMethod]
    public void TrimEndTest7()
    {
        const string test = "test";
        char[] trimChars = ['\'', '\"'];
        Assert.AreSame(test.TrimEnd(trimChars), StringPolyfillExtension.TrimEnd(test, trimChars.AsSpan()));
    }

    [TestMethod]
    public void ReplaceLineEndingsTest1()
    {
        const string input = "\n1\r\n\n\r2\r3\n\n4\r\n5\u000B6\u000C\n7\u00858\u20289\u2029";
        const string expected = "*1***2*3**4*5\u000B6**7*8*9*";
        string output = StringPolyfillExtension.ReplaceLineEndings(input, "*");
        Assert.AreEqual(expected, output);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ReplaceLineEndingsTest2()
    {
        string s = "Hi\n";
        _ = StringPolyfillExtension.ReplaceLineEndings(s, null!);
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void ReplaceLineEndingsTest3()
    {
        string? s = null;
        _ = StringPolyfillExtension.ReplaceLineEndings(s!, "*");
    }

    [TestMethod]
    public void ReplaceLineEndingsTest4()
    {
        const string test = "test";
        Assert.AreSame(test, StringPolyfillExtension.ReplaceLineEndings(test, "blub"));
    }

    [TestMethod]
    public void ReplaceLineEndingsTest5()
    {
        const string test = "\u0085";
        Assert.AreEqual(Environment.NewLine, StringPolyfillExtension.ReplaceLineEndings(test));
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void ReplaceLineEndingsTest6()
    {
        string? s = null;
        _ = StringPolyfillExtension.ReplaceLineEndings(s!);
    }

    [DataTestMethod]
    [DataRow("Hi\rFolker")]
    [DataRow("Hi\nFolker")]
    [DataRow("Hi\u0085Folker")]
    [DataRow("Hi\u000CFolker")]
    [DataRow("Hi\u2028Folker")]
    [DataRow("Hi\u2029Folker")]
    public void ReplaceLineEndingsTest7(string input)
        => Assert.AreEqual("Hi*Folker", StringPolyfillExtension.ReplaceLineEndings(input, "*"));

    [TestMethod]
    public void ReplaceLineEndingsTest8()
    {
        const string test = "t\ne\ns\nt\n";
        Assert.AreSame(test, StringPolyfillExtension.ReplaceLineEndings(test, "\n"));
    }

    [TestMethod]
    public void ReplaceLineEndingsTest9()
    {
        const string test = "t\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\nt\ne\ns\nt\n";
        Assert.AreSame(test, StringPolyfillExtension.ReplaceLineEndings(test, "\n"));
    }

    [TestMethod]
    public void ReplaceLineEndingsTest10()
    {
        string test = "t\n" + new string('e', 260) + "\nt";
        Assert.AreEqual("t**" + new string('e', 260) + "**t", StringPolyfillExtension.ReplaceLineEndings(test, "**"));
    }

    [DataTestMethod()]
    [DataRow("Test", 'e', StringComparison.Ordinal, true)]
    public void ContainsTest1(string value, char c, StringComparison comparison, bool expected)
     => Assert.AreEqual(expected, StringPolyfillExtension.Contains(value, c, comparison));

    [DataTestMethod()]
    [DataRow("Test", 'e', true)]
    public void ContainsTest2(string value, char c, bool expected)
        => Assert.AreEqual(expected, StringPolyfillExtension.Contains(value, c));

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ContainsTest3()
        => _ = StringPolyfillExtension.Contains("Test", 'e', (StringComparison)4711);

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void ContainsTest4()
    {
        string? test = null;
        _ = StringPolyfillExtension.Contains(test!, 'e', StringComparison.Ordinal);
    }

    [DataTestMethod]
    [DataRow("Test", 'e', true)]
    public void ContainsTest5(string input, char c, bool expected)
        => Assert.AreEqual(expected, StringPolyfillExtension.Contains(input, c));

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void ContainsTest6()
    {
        string? test = null;
        _ = StringPolyfillExtension.Contains(test!, 'e');
    }

    [DataTestMethod]
    [DataRow("Test", "es", true)]
    public void ContainsTest7(string input, string s, bool expected)
        => Assert.AreEqual(expected, StringPolyfillExtension.Contains(input, s, StringComparison.Ordinal));

    [DataTestMethod]
    [DataRow("Test", "as", false)]
    public void ContainsTest8(string input, string s, bool expected)
        => Assert.AreEqual(expected, StringPolyfillExtension.Contains(input, s, StringComparison.Ordinal));


    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void ContainsTest9()
    {
        string? test = null;
        _ = StringPolyfillExtension.Contains(test!, "es", StringComparison.Ordinal);
    }

    [DataTestMethod()]
    [DataRow("Test", 'e', StringComparison.Ordinal, 1)]
    public void IndexOfTest1(string value, char c, StringComparison comparison, int expected)
        => Assert.AreEqual(expected, StringPolyfillExtension.IndexOf(value, c, comparison));

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void IndexOfTest2() => _ = StringPolyfillExtension.IndexOf("Test", 'e', (StringComparison)4711);

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void IndexOfTest3()
    {
        string? test = null;
        _ = StringPolyfillExtension.IndexOf(test!, 'e', StringComparison.Ordinal);
    }


    [DataTestMethod()]
    [DataRow("Test", 'e', StringSplitOptions.RemoveEmptyEntries, 2)]
    public void SplitTest1(string value, char c, StringSplitOptions options, int expected)
        => Assert.AreEqual(expected, value.Split(c, options).Length);

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void SplitTest2()
    {
        string? test = null;
        _ = StringPolyfillExtension.Split(test!, ',', StringSplitOptions.RemoveEmptyEntries);
    }

    [DataTestMethod()]
    [DataRow("Test", 'e', StringSplitOptions.RemoveEmptyEntries, 2)]
    public void SplitTest3(string value, char c, StringSplitOptions options, int expected)
        => Assert.AreEqual(expected, value.Split(c, 2, options).Length);

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void SplitTest4()
    {
        string? test = null;
        _ = StringPolyfillExtension.Split(test!, ',', 2, StringSplitOptions.RemoveEmptyEntries);
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void SplitTest5()
    {
        string? test = null;
        _ = StringPolyfillExtension.Split(test!, ",", 2, StringSplitOptions.RemoveEmptyEntries);
    }

    [DataTestMethod]
    [DataRow("")]
    [DataRow(null)]
    public void SplitTest6(string? separator)
        => Assert.AreEqual(1, StringPolyfillExtension.Split("test", separator, 4711).Length);

    [DataTestMethod]
    [DataRow(StringSplitOptions.None, 1)]
    [DataRow(StringSplitOptions.RemoveEmptyEntries, 0)]
    public void SplitTest7(StringSplitOptions options, int expected)
        => Assert.AreEqual(expected, StringPolyfillExtension.Split("", "bla", 4711, options).Length);

    [TestMethod]
    public void SplitTest8() => Assert.AreEqual(0, StringPolyfillExtension.Split("test", "e", 0).Length);

    [DataTestMethod]
    [DataRow("This is a test.", null, 100, StringSplitOptions.None, 1)]
    [DataRow("This is a test.", null, 0, StringSplitOptions.None, 0)]
    [DataRow("This is a test.", "", 100, StringSplitOptions.None, 1)]
    [DataRow("This is a test.", "", 0, StringSplitOptions.None, 0)]
    [DataRow("This is a test.", "is", 100, StringSplitOptions.None, 3)]
    [DataRow("This is a test.", "is", 2, StringSplitOptions.None, 2)]
    [DataRow("", "is", 2, StringSplitOptions.None, 1)]
    [DataRow("", "is", 2, StringSplitOptions.RemoveEmptyEntries, 0)]
    public void SplitTest9(string input, string? split, int parts, StringSplitOptions options, int expected)
        => Assert.AreEqual(expected, StringPolyfillExtension.Split(input, split, parts, options).Length);

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void SplitTest10()
    {
        string test = "Test";
        _ = StringPolyfillExtension.Split(test, "bla", -1);
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void SplitTest11()
    {
        string? test = null;
        _ = StringPolyfillExtension.Split(test!, "bla", 100);
    }

    [DataTestMethod]
    [DataRow("This is a test.", null, StringSplitOptions.None, 1)]
    [DataRow("This is a test.", "", StringSplitOptions.None, 1)]
    [DataRow("This is a test.", "is", StringSplitOptions.None, 3)]
    [DataRow("", "is", StringSplitOptions.None, 1)]
    [DataRow("", "is", StringSplitOptions.RemoveEmptyEntries, 0)]
    public void SplitTest12(string input, string? split, StringSplitOptions options, int expected)
        => Assert.AreEqual(expected, StringPolyfillExtension.Split(input, split, options).Length);

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void SplitTest13()
    {
        string? test = null;
        _ = StringPolyfillExtension.Split(test!, "bla");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void SplitTest14() => _ = StringPolyfillExtension.Split("test", "3", -1);

    [DataTestMethod()]
    [DataRow("Test", 'T', true)]
    //[DataRow("aeTest", 'ä', true)]
    public void StartsWithTest1(string value, char c, bool expected) => Assert.AreEqual(expected, StringPolyfillExtension.StartsWith(value, c));

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void StartsWithTest2()
    {
        string? test = null;
        _ = StringPolyfillExtension.StartsWith(test!, ',');
    }

    [DataTestMethod()]
    [DataRow("Test", 't', true)]
    public void EndsWithTest1(string value, char c, bool expected) => Assert.AreEqual(expected, StringPolyfillExtension.EndsWith(value, c));

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void EndsWithTest2()
    {
        string? test = null;
        _ = StringPolyfillExtension.EndsWith(test!, ',');
    }

    [DataTestMethod]
    [DataRow("Test", "testen", "as", StringComparison.Ordinal, "Test")]
    [DataRow("Test", "testen", "as", StringComparison.OrdinalIgnoreCase, "Test")]
    [DataRow("Test", "testen", null, StringComparison.Ordinal, "Test")]
    [DataRow("Test", "testen", null, StringComparison.OrdinalIgnoreCase, "Test")]
    [DataRow("Test", "test", "as", StringComparison.Ordinal, "Test")]
    [DataRow("Test", "test", "as", StringComparison.OrdinalIgnoreCase, "as")]
    [DataRow("Test", "test", null, StringComparison.Ordinal, "Test")]
    [DataRow("Test", "test", null, StringComparison.OrdinalIgnoreCase, "")]
    [DataRow("Test", "test", "test", StringComparison.Ordinal, "Test")]
    [DataRow("Test", "test", "test", StringComparison.OrdinalIgnoreCase, "test")]
    [DataRow("Test", "EST", "ante", StringComparison.Ordinal, "Test")]
    [DataRow("Test", "EST", "ante", StringComparison.OrdinalIgnoreCase, "Tante")]
    public void ReplaceTest1(string input, string oldValue, string? replacement, StringComparison comparison, string expected)
        => Assert.AreEqual(expected, StringPolyfillExtension.Replace(input, oldValue, replacement, comparison));

    [DataTestMethod]
    [DataRow(StringComparison.Ordinal)]
    [DataRow(StringComparison.OrdinalIgnoreCase)]
    [ExpectedException(typeof(NullReferenceException))]
    public void ReplaceTest2(StringComparison comparison)
    {
        string? s = null;
        _ = StringPolyfillExtension.Replace(s!, "test", "bb", comparison);
    }

    [DataTestMethod]
    [DataRow(StringComparison.Ordinal)]
    [DataRow(StringComparison.OrdinalIgnoreCase)]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ReplaceTest3(StringComparison comparison)
    {
        string s = "Test";
        _ = StringPolyfillExtension.Replace(s, null!, "bb", comparison);
    }

    [DataTestMethod]
    [DataRow(StringComparison.Ordinal)]
    [DataRow(StringComparison.OrdinalIgnoreCase)]
    [ExpectedException(typeof(ArgumentException))]
    public void ReplaceTest4(StringComparison comparison)
    {
        string s = "Test";
        _ = StringPolyfillExtension.Replace(s, "", "bb", comparison);
    }
}
