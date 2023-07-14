using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Tests;

[TestClass]
public class FileInfoExtensionTests
{
#pragma warning disable CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.
    public TestContext TestContext { get; set; }
#pragma warning restore CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.
    
    private readonly byte[] _invalidUtf8WithValidBom = new byte[] { 0xEF, 0xBB, 0xBF, 0xFF, 0xFF };

    [TestMethod]
    public void IsUtf8Test1()
    {
        string outPath = Path.Combine(TestContext.TestResultsDirectory, "test1.txt");
        File.WriteAllBytes(outPath, _invalidUtf8WithValidBom);

        var fi = new FileInfo(outPath);
        Assert.IsTrue(fi.Exists);
        Assert.IsTrue(fi.IsUtf8());
    }

    [TestMethod]
    public void IsUtf8Test1b()
    {
        string outPath = Path.Combine(TestContext.TestResultsDirectory, "test1b.txt");
        File.WriteAllBytes(outPath, _invalidUtf8WithValidBom);

        var fi = new FileInfo(outPath);
        Assert.IsTrue(fi.Exists);
        Assert.IsFalse(fi.IsValidUtf8());
    }

    [TestMethod]
    public void IsUtf8Test2()
    {
        string outPath = Path.Combine(TestContext.TestResultsDirectory, "test2.txt");
        File.WriteAllText(outPath, "Aäöü", TextEncodingConverter.GetEncoding(1252, true));

        var fi = new FileInfo(outPath);
        Assert.IsTrue(fi.Exists);
        Assert.IsFalse(fi.IsUtf8());
    }

    [TestMethod]
    public void IsUtf8Test3()
    {
        string outPath = Path.Combine(TestContext.TestResultsDirectory, "test3.txt");
        File.WriteAllText(outPath, new string('A', 130) + "äöü", TextEncodingConverter.GetEncoding(1252, true));

        var fi = new FileInfo(outPath);
        Assert.IsTrue(fi.Exists);
        Assert.IsTrue(fi.IsUtf8(count: 5));
    }

    [TestMethod]
    public void IsUtf8Test4()
    {
        string outPath = Path.Combine(TestContext.TestResultsDirectory, "test4.txt");
        File.WriteAllText(outPath, new string('A', 130) + "äöü", TextEncodingConverter.GetEncoding(1252, true));

        var fi = new FileInfo(outPath);
        Assert.IsTrue(fi.Exists);
        Assert.IsFalse(fi.IsUtf8());

        //var fb = DecoderReplacementFallback.ReplacementFallback;
    }

    [TestMethod]
    public void IsUtf8Test5()
    {
        const string input = "äöüABC";
        string outPath = Path.Combine(TestContext.TestResultsDirectory, "test4.txt");
        File.WriteAllText(outPath, input, TextEncodingConverter.GetEncoding(1252, true));

        string s = File.ReadAllText(outPath, Encoding.GetEncoding(65001, EncoderFallback.ReplacementFallback, new DecoderValidationFallback()));
        Assert.IsNotNull(s);
        Assert.AreEqual(input.Length, s.Length);
        Assert.AreNotEqual(input, s, true);
        var fi = new FileInfo(outPath);
        Assert.IsTrue(fi.Exists);
        Assert.IsFalse(fi.IsUtf8());

        //var fb = DecoderReplacementFallback.ReplacementFallback;
    }

    [TestMethod]
    public void IsUtf8Test6()
    {
        var fi = new FileInfo(TestFiles.AnsiIssueVcf);
        Assert.IsFalse(fi.IsUtf8(count: 1));
    }
}
