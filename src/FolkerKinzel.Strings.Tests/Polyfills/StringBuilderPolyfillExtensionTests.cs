using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Polyfills.Tests;

[TestClass()]
public class StringBuilderPolyfillExtensionTests
{ 
    [TestMethod]
    public void AppendJoinTestA1()
    {
        var input = new string[0];
        char separator = ',';

        Assert.AreEqual(string.Join(separator.ToString(), input), new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [TestMethod]
    public void AppendJoinTestA2()
    {
        var input = new string?[] {null};
        char separator = ',';

        Assert.AreEqual("", new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [TestMethod]
    public void AppendJoinTestA3()
    {
        var input = new string?[] { "" };
        char separator = ',';

        Assert.AreEqual("", new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [DataTestMethod]
    [DataRow(null, null)]
    [DataRow(null, "")]
    [DataRow("", null)]
    [DataRow("", "")]
    [DataRow(null, "test")]
    [DataRow("test", null)]
    [DataRow("test", "test")]
    public void AppendJoinTestA4(string? s1, string? s2)
    {
        var input = new string?[] { s1, s2 };
        char separator = ',';

        Assert.AreEqual(s1 + separator + s2, new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void AppendJoinTestA5()
    {
        string[]? arr = null;
        _ = new StringBuilder().AppendJoin(',', arr!);
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void AppendJoinTestA6()
    {
        StringBuilder? sb = null;
        _ = sb!.AppendJoin(',', " ");
    }

    [TestMethod]
    public void AppendJoinTestB1()
    {
        var input = new List<string>();
        char separator = ',';

        Assert.AreEqual("", new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [TestMethod]
    public void AppendJoinTestB2()
    {
        var input = new List<string?>() { null };
        char separator = ',';

        Assert.AreEqual("", new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [TestMethod]
    public void AppendJoinTestB3()
    {
        var input = new List<string?>() { "" };
        char separator = ',';

        Assert.AreEqual("", new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [DataTestMethod]
    [DataRow(null, null)]
    [DataRow(null, "")]
    [DataRow("", null)]
    [DataRow("", "")]
    [DataRow(null, "test")]
    [DataRow("test", null)]
    [DataRow("test", "test")]
    public void AppendJoinTestB4(string? s1, string? s2)
    {
        var input = new List<string?>() { s1, s2 };
        char separator = ',';

        Assert.AreEqual(s1 + separator + s2, new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void AppendJoinTestB5()
    {
        List<string>? list = null;
        _ = new StringBuilder().AppendJoin(',', list!);
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void AppendJoinTestB6()
    {
        StringBuilder? sb = null;
        _ = sb!.AppendJoin(',', new List<string>());
    }

    [TestMethod]
    public void AppendJoinTestC1()
    {
        var input = new string[0];
        string separator = "::";

        Assert.AreEqual("", new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [TestMethod]
    public void AppendJoinTestC2()
    {
        var input = new string?[] { null };
        string separator = "::";
        Assert.AreEqual("", new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [TestMethod]
    public void AppendJoinTestC3()
    {
        var input = new string?[] { "" };
        string separator = "::";

        Assert.AreEqual("", new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [DataTestMethod]
    [DataRow(null, null)]
    [DataRow(null, "")]
    [DataRow("", null)]
    [DataRow("", "")]
    [DataRow(null, "test")]
    [DataRow("test", null)]
    [DataRow("test", "test")]
    public void AppendJoinTestC4(string? s1, string? s2)
    {
        var input = new string?[] { s1, s2 };
        string separator = "::";

        Assert.AreEqual(s1 + separator + s2, new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void AppendJoinTestC5()
    {
        string[]? arr = null;
        _ = new StringBuilder().AppendJoin("::", arr!);
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void AppendJoinTestC6()
    {
        StringBuilder? sb = null;
        _ = sb!.AppendJoin("::", " ");
    }

    [DataTestMethod]
    [DataRow(null, null)]
    [DataRow(null, "")]
    [DataRow("", null)]
    [DataRow("", "")]
    [DataRow(null, "test")]
    [DataRow("test", null)]
    [DataRow("test", "test")]
    public void AppendJoinTestC7(string? s1, string? s2)
    {
        var input = new string?[] { s1, s2 };
        string? separator = null;

        Assert.AreEqual(s1 + s2, new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [TestMethod]
    public void AppendJoinTestD1()
    {
        var input = new List<string>();
        string separator = "::";

        Assert.AreEqual("", new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [TestMethod]
    public void AppendJoinTestD2()
    {
        var input = new List<string?>() { null };
        string separator = "::";

        Assert.AreEqual("", new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [TestMethod]
    public void AppendJoinTestD3()
    {
        var input = new List<string?>() { "" };
        string separator = "::";

        Assert.AreEqual("", new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [DataTestMethod]
    [DataRow(null, null)]
    [DataRow(null, "")]
    [DataRow("", null)]
    [DataRow("", "")]
    [DataRow(null, "test")]
    [DataRow("test", null)]
    [DataRow("test", "test")]
    public void AppendJoinTestD4(string? s1, string? s2)
    {
        var input = new List<string?>() { s1, s2 };
        string separator = "::";

        Assert.AreEqual(s1 + separator + s2, new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void AppendJoinTestD5()
    {
        List<string>? list = null;
        _ = new StringBuilder().AppendJoin("::", list!);
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void AppendJoinTestD6()
    {
        StringBuilder? sb = null;
        _ = sb!.AppendJoin("::", new List<string>());
    }

    [DataTestMethod]
    [DataRow(null, null)]
    [DataRow(null, "")]
    [DataRow("", null)]
    [DataRow("", "")]
    [DataRow(null, "test")]
    [DataRow("test", null)]
    [DataRow("test", "test")]
    public void AppendJoinTestD7(string? s1, string? s2)
    {
        var input = new List<string?>() { s1, s2 };
        string? separator = null;

        Assert.AreEqual(s1 + s2, new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [TestMethod]
    public void AppendJoinTestE1()
    {
        var input = new object[0];
        char separator = ',';

        Assert.AreEqual("", new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [TestMethod]
    public void AppendJoinTestE2()
    {
        var input = new object?[] { null };
        char separator = ',';

        Assert.AreEqual("", new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [TestMethod]
    public void AppendJoinTestE3()
    {
        var input = new object?[] { '\0' };
        char separator = ',';

        Assert.AreEqual("\0", new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [DataTestMethod]
    [DataRow(null, null)]
    [DataRow(null, "")]
    [DataRow("", null)]
    [DataRow("", "")]
    [DataRow(null, 7)]
    [DataRow(7, null)]
    [DataRow(7, 7)]
    public void AppendJoinTestE4(object? s1, object? s2)
    {
        var input = new object?[] { s1, s2 };
        char separator = ',';

        string join = s1?.ToString() + separator + s2?.ToString();
        string appendJoin = new StringBuilder().AppendJoin(separator, input).ToString();

        Assert.AreEqual(join, appendJoin);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void AppendJoinTestE5()
    {
        object[]? arr = null;
        _ = new StringBuilder().AppendJoin(',', arr!);
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void AppendJoinTestE6()
    {
        StringBuilder? sb = null;
        _ = sb!.AppendJoin(',', 42);
    }


    [TestMethod]
    public void AppendJoinTestF1()
    {
        var input = new object[0];
        string separator = "::";

        Assert.AreEqual("", new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [TestMethod]
    public void AppendJoinTestF2()
    {
        var input = new object?[] { null };
        string separator = "::";
        Assert.AreEqual("", new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [TestMethod]
    public void AppendJoinTestF3()
    {
        var input = new object?[] { '\0' };
        string separator = "::";

        Assert.AreEqual("\0", new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [DataTestMethod]
    [DataRow(null, null)]
    [DataRow(null, "")]
    [DataRow("", null)]
    [DataRow("", "")]
    [DataRow(null, 7)]
    [DataRow(7, null)]
    [DataRow(7, 7)]
    public void AppendJoinTestF4(object? s1, object? s2)
    {
        var input = new object?[] { s1, s2 };
        string separator = "::";

        Assert.AreEqual(s1?.ToString() + separator + s2?.ToString(), new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void AppendJoinTestF5()
    {
        object[]? arr = null;
        _ = new StringBuilder().AppendJoin("::", arr!);
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void AppendJoinTestF6()
    {
        StringBuilder? sb = null;
        _ = sb!.AppendJoin("::", 42);
    }

    [DataTestMethod]
    [DataRow(null, null)]
    [DataRow(null, "")]
    [DataRow("", null)]
    [DataRow("", "")]
    [DataRow(null, 7)]
    [DataRow(7, null)]
    [DataRow(7, 7)]
    public void AppendJoinTestF7(object? s1, object? s2)
    {
        var input = new object?[] { s1, s2 };
        string? separator = null;

        Assert.AreEqual(s1?.ToString() + s2?.ToString(), new StringBuilder().AppendJoin(separator, input).ToString());
    }

    [TestMethod]
    public void InsertTest1()
    {
        const string test = "test";
        var sb1 = new StringBuilder();
        var sb2 = new StringBuilder();

        _ = sb1.Insert(0, test.AsSpan());
        _ = sb2.Insert(0, test);

        Assert.AreEqual(sb1.ToString(), sb2.ToString());

        _ = sb1.Insert(2, test.AsSpan());
        _ = sb2.Insert(2, test);

        Assert.AreEqual(sb1.ToString(), sb2.ToString());

        _ = sb1.Insert(sb1.Length, test.AsSpan());
        _ = sb2.Insert(sb2.Length, test);

        Assert.AreEqual(sb1.ToString(), sb2.ToString());
    }


    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void InsertTest2()
    {
        StringBuilder? sb = null;
        _ = sb!.Insert(0, ReadOnlySpan<char>.Empty);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void InsertTest3()
    {
        var sb = new StringBuilder();
        _ = sb.Insert(-1, ReadOnlySpan<char>.Empty);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void InsertTest4()
    {
        var sb = new StringBuilder();
        _ = sb.Insert(1, ReadOnlySpan<char>.Empty);
    }

    [TestMethod]
    public void AppendStringBuilderTest2()
    {
        const string test = "test";
        var sb1 = new StringBuilder();
        var sb2 = new StringBuilder(test);

        Assert.AreEqual(sb1, sb1.Append(sb2, 0, sb2.Length));
        Assert.AreEqual(test, sb1.ToString());
    }

    [TestMethod]
    public void AppendStringBuilderTest12()
    {
        const string test = "test";
        var sb1 = new StringBuilder();
        var sb2 = new StringBuilder(test);

        Assert.AreEqual(sb1, sb1.Append(sb2, 1, 2));
        Assert.AreEqual("es", sb1.ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void AppendStringBuilderTest3()
    {
        const string test = "test";
        var sb1 = new StringBuilder();
        var sb2 = new StringBuilder(test);

        Assert.AreEqual(sb1, sb1.Append(sb2, -17, sb2.Length));
        Assert.AreEqual(test, sb1.ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void AppendStringBuilderTest4()
    {
        var sb1 = new StringBuilder();
        StringBuilder? sb2 = null;
        Assert.AreEqual(sb1, sb1.Append(sb2, -17, 0));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void AppendStringBuilderTest5()
    {
        var sb1 = new StringBuilder();
        StringBuilder? sb2 = null;

        Assert.AreEqual(sb1, sb1.Append(sb2, 0, -1));
    }

    [TestMethod]
    public void AppendStringBuilderTest6()
    {
        var sb1 = new StringBuilder();
        StringBuilder? sb2 = null;

        Assert.AreEqual(sb1, sb1.Append(sb2, 0, 0));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void AppendStringBuilderTest7()
    {
        var sb1 = new StringBuilder();
        StringBuilder? sb2 = null;

        Assert.AreEqual(sb1, sb1.Append(sb2, 0, 1));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void AppendStringBuilderTest8()
    {
        var sb1 = new StringBuilder();
        var sb2 = new StringBuilder();

        Assert.AreEqual(sb1, sb1.Append(sb2, 0, 4711));
    }

    [TestMethod]
    public void AppendStringBuilderTest9()
    {
        var sb1 = new StringBuilder();
        var sb2 = new StringBuilder();

        Assert.AreEqual(sb1, sb1.Append(sb2, 4711, 0));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void AppendStringBuilderTest10()
    {
        var sb1 = new StringBuilder();
        var sb2 = new StringBuilder();

        Assert.AreEqual(sb1, sb1.Append(sb2, 4711, 1));
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void AppendStringBuilderTest11()
    {
        StringBuilder? sb1 = null;
        var sb2 = new StringBuilder();

        _ = sb1!.Append(sb2, 4711, 1);
    }

    [TestMethod()]
    public void AppendTest1()
    {
        var sb = new StringBuilder();

        string test = "Test";

        ReadOnlySpan<char> span = test.AsSpan();

        _ = sb.Append(span);

        Assert.AreEqual(test, sb.ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void AppendTest2()
    {
        StringBuilder? sb = null;
        _ = sb!.Append(ReadOnlySpan<char>.Empty);
    }
}
