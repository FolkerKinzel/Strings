namespace FolkerKinzel.Strings.Tests;

[TestClass]
public class TextWriterPolyfillExtensionTests
{
    [NotNull]
    public TestContext? TestContext { get; set; }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void WriteLineTest1()
    {
        TextWriter? writer = null;
        writer!.WriteLine("Hello".AsSpan());
    }

    [TestMethod]
    public void WriteLineTest2()
    {
        using var writer = new StringWriter();
        writer.NewLine = "::";
        writer.WriteLine("abc".AsSpan());
        Assert.AreEqual("abc::", writer.ToString());
    }

    [TestMethod]
    public void WriteLineTest3()
    {
        string path = Path.Combine(TestContext.TestRunDirectory!, "WriteLineTest3.txt");
        using var writer = new StreamWriter(path);
        writer.NewLine = "::";
        writer.WriteLine("abc".AsSpan());
        writer.Close();
        Assert.AreEqual("abc::", File.ReadAllText(path));
    }

    [TestMethod]
    public void WriteLineTest4()
    {
        using var writer = new StringWriter();
        writer.NewLine = "::";
        TextWriterPolyfillExtension.WriteLine(writer, "abc".AsSpan());
        Assert.AreEqual("abc::", writer.ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void WriteTest1()
    {
        TextWriter? writer = null;
        writer!.Write("Hello".AsSpan());
    }

    [TestMethod]
    public void WriteTest2()
    {
        using var writer = new StringWriter();
        writer.Write("abc".AsSpan());
        Assert.AreEqual("abc", writer.ToString());
    }

    [TestMethod]
    public void WriteTest3()
    {
        string path = Path.Combine(TestContext.TestRunDirectory!, "WriteTest3.txt");
        using var writer = new StreamWriter(path);
        writer.NewLine = "::";
        writer.Write("abc".AsSpan());
        writer.Close();
        Assert.AreEqual("abc", File.ReadAllText(path));
    }

    [TestMethod]
    public void WriteTest4()
    {
        using var writer = new StringWriter();
        TextWriterPolyfillExtension.Write(writer, "abc".AsSpan());
        Assert.AreEqual("abc", writer.ToString());
    }
}
