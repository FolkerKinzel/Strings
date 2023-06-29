using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Tests;

[TestClass()]
public class TextEncodingConverterTests
{
    [DataTestMethod]
    [DataRow(null, 65001)]
    [DataRow("iso-8859-1", 28591)]
    [DataRow("ISO-8859-1", 28591)]
    [DataRow("unBekannt", 65001)]
    public void GetEncodingTest1(string? input, int codePage)
    {
        Encoding enc = TextEncodingConverter.GetEncoding(input);
        Assert.AreEqual(codePage, enc.CodePage);
        Assert.IsNotInstanceOfType(enc.EncoderFallback, EncoderFallback.ExceptionFallback.GetType());
        Assert.IsNotInstanceOfType(enc.DecoderFallback.GetType(), DecoderFallback.ExceptionFallback.GetType());
    }

    [DataTestMethod]
    [DataRow(null, 65001)]
    [DataRow("iso-8859-1", 28591)]
    [DataRow("ISO-8859-1", 28591)]
    [DataRow("unBekannt", 65001)]
    public void GetEncodingTest2(string? input, int codePage)
    {
        Encoding enc = TextEncodingConverter.GetEncoding(input, EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback);
        Assert.AreEqual(codePage, enc.CodePage);
        Assert.IsInstanceOfType(enc.EncoderFallback, EncoderFallback.ExceptionFallback.GetType());
        Assert.IsInstanceOfType(enc.DecoderFallback, DecoderFallback.ExceptionFallback.GetType());
    }

    [DataTestMethod]
    [DataRow(65001)]
    [DataRow(28591)]
    public void GetEncodingTest3(int codePage)
    {
        Encoding enc = TextEncodingConverter.GetEncoding(codePage);
        Assert.AreEqual(codePage, enc.CodePage);
        Assert.IsNotInstanceOfType(enc.EncoderFallback, EncoderFallback.ExceptionFallback.GetType());
        Assert.IsNotInstanceOfType(enc.DecoderFallback.GetType(), DecoderFallback.ExceptionFallback.GetType());
    }

    [DataTestMethod]
    [DataRow(65001)]
    [DataRow(28591)]
    public void GetEncodingTest4(int codePage)
    {
        Encoding enc = TextEncodingConverter.GetEncoding(codePage, EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback);
        Assert.AreEqual(codePage, enc.CodePage);
        Assert.IsInstanceOfType(enc.EncoderFallback, EncoderFallback.ExceptionFallback.GetType());
        Assert.IsInstanceOfType(enc.DecoderFallback, DecoderFallback.ExceptionFallback.GetType());
    }

    [TestMethod]
    public void GetEncodingTest5()
    {
        Encoding enc = TextEncodingConverter.GetEncoding(0);
        Assert.AreEqual(Encoding.UTF8, enc);
        Assert.IsNotInstanceOfType(enc.EncoderFallback, EncoderFallback.ExceptionFallback.GetType());
        Assert.IsNotInstanceOfType(enc.DecoderFallback.GetType(), DecoderFallback.ExceptionFallback.GetType());
    }

    [TestMethod]
    public void GetEncodingTest6()
    {
        Encoding enc = TextEncodingConverter.GetEncoding(0, EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback);
        Assert.AreEqual(Encoding.UTF8.CodePage, enc.CodePage);
        Assert.IsInstanceOfType(enc.EncoderFallback, EncoderFallback.ExceptionFallback.GetType());
        Assert.IsInstanceOfType(enc.DecoderFallback, DecoderFallback.ExceptionFallback.GetType());
    }

    [DataTestMethod]
    [DataRow(null, 65001)]
    [DataRow("windows-1252", 1252)]
    [DataRow("Windows-1252", 1252)]
    [DataRow("WINDOWS-1252", 1252)]
    [DataRow("WINDOWS - 1252", 1252)]
    //[DataRow("Latin1", 1252)]
    [DataRow("unBekannt", 65001)]
    public void GetEncodingTest7(string? input, int codePage)
    {
        Encoding enc = TextEncodingConverter.GetEncoding(input);
        Assert.AreEqual(codePage, enc.CodePage);
        Assert.IsNotInstanceOfType(enc.EncoderFallback, EncoderFallback.ExceptionFallback.GetType());
        Assert.IsNotInstanceOfType(enc.DecoderFallback.GetType(), DecoderFallback.ExceptionFallback.GetType());
    }

    [DataTestMethod]
    [DataRow(-17)]
    [DataRow(int.MaxValue)]
    [DataRow(42)]
    [DataRow(4711)]
    public void GetEncodingTest8(int codePage)
    {
        Encoding enc = TextEncodingConverter.GetEncoding(codePage);
        Assert.AreEqual(65001, enc.CodePage);
        Assert.IsNotInstanceOfType(enc.EncoderFallback, EncoderFallback.ExceptionFallback.GetType());
        Assert.IsNotInstanceOfType(enc.DecoderFallback.GetType(), DecoderFallback.ExceptionFallback.GetType());
    }

    [DataTestMethod]
    [DataRow(-17)]
    [DataRow(int.MaxValue)]
    [DataRow(42)]
    public void GetEncodingTest9(int codePage)
    {
        Encoding enc = TextEncodingConverter.GetEncoding(codePage, EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback);
        Assert.AreEqual(65001, enc.CodePage);
        Assert.IsInstanceOfType(enc.EncoderFallback, EncoderFallback.ExceptionFallback.GetType());
        Assert.IsInstanceOfType(enc.DecoderFallback, DecoderFallback.ExceptionFallback.GetType());
    }

    [DataTestMethod]
    [DataRow(-17)]
    [DataRow(int.MaxValue)]
    [DataRow(0)]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void GetEncodingTest10(int codePage) =>
        _ = TextEncodingConverter.GetEncoding(
            codePage, EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback, throwOnInvalidCodePage: true);


    [DataTestMethod]
    [DataRow(42)]
    [ExpectedException(typeof(ArgumentException))]
    public void GetEncodingTest11(int codePage) =>
        _ = TextEncodingConverter.GetEncoding(
            codePage, EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback, throwOnInvalidCodePage: true);

    [DataTestMethod]
    [DataRow(-17)]
    [DataRow(int.MaxValue)]
    [DataRow(0)]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void GetEncodingTest12(int codePage) => _ = TextEncodingConverter.GetEncoding(codePage, throwOnInvalidCodePage: true);


    [DataTestMethod]
    [DataRow(42)]
    [ExpectedException(typeof(ArgumentException))]
    public void GetEncodingTest13(int codePage) => _ = TextEncodingConverter.GetEncoding(codePage, throwOnInvalidCodePage: true);


    [DataTestMethod]
    [DataRow(null)]
    [DataRow("   ")]
    [DataRow("")]
    [DataRow("unBekannt")]
    [ExpectedException(typeof(ArgumentException))]
    public void GetEncodingTest14(string? input) => _ = TextEncodingConverter.GetEncoding(input, throwOnInvalidWebName: true);


    [DataTestMethod]
    [DataRow(null)]
    [DataRow("   ")]
    [DataRow("")]
    [DataRow("unBekannt")]
    [ExpectedException(typeof(ArgumentException))]
    public void GetEncodingTest15(string? input) => _ = TextEncodingConverter.GetEncoding(input, EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback, throwOnInvalidWebName: true);

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetEncodingTest16() => 
        _ = TextEncodingConverter.GetEncoding("utf-8", null!, DecoderFallback.ExceptionFallback, true);

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetEncodingTest17() =>
        _ = TextEncodingConverter.GetEncoding("utf-8", EncoderFallback.ExceptionFallback, null!, true);

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetEncodingTest18() =>
        _ = TextEncodingConverter.GetEncoding("utf-8", null!, null!, true);

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetEncodingTest19() =>
        _ = TextEncodingConverter.GetEncoding(65001, null!, DecoderFallback.ExceptionFallback, true);

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetEncodingTest20() =>
        _ = TextEncodingConverter.GetEncoding(65001, EncoderFallback.ExceptionFallback, null!, true);

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetEncodingTest21() =>
        _ = TextEncodingConverter.GetEncoding(65001, null!, null!, true);

    [DataTestMethod]
    [DataRow(1200, 2)]
    [DataRow(1201, 2)]
    [DataRow(12000, 4)]
    [DataRow(12001, 4)]
    //[DataRow(54936, 4)]
    //[DataRow(65000, 4)]
    [DataRow(65001, 3)]
    public void GetCodePageTest1(int codePage, int expectedBomLength)
    {
        Encoding enc = TextEncodingConverter.GetEncoding(codePage);
        const string test = "test";

        var bytes = enc.GetBytes(test);
        var preamble = enc.GetPreamble();
        preamble.CopyTo(bytes, 0);

        Assert.AreEqual(codePage, TextEncodingConverter.GetCodePage(bytes.AsSpan(), out int bomLength));
        Assert.AreEqual(expectedBomLength, bomLength);
    }

    [TestMethod]
    public void GetCodePageTest2()
    {
        const int GB18030 = 54936;
        byte[] preamble = new byte[] { 0x84, 0x31, 0x95, 0x33 };
        byte[] bytes = TextEncodingConverter.GetEncoding(GB18030).GetBytes("test");

        byte[] test = new byte[preamble.Length + bytes.Length];
        preamble.CopyTo(test, 0);
        bytes.CopyTo(test, preamble.Length);

        Assert.AreEqual(GB18030, TextEncodingConverter.GetCodePage(test.AsSpan(), out int bomLength));
        Assert.AreEqual(4, bomLength);
    }

    [TestMethod]
    public void GetCodePageTest3()
    {
        const int UTF7 = 65000;
        byte[] preamble = new byte[] { 0x2B, 0x2F, 0x76, 0x38 };
        byte[] bytes = TextEncodingConverter.GetEncoding(UTF7).GetBytes("test");

        byte[] test = new byte[preamble.Length + bytes.Length];
        preamble.CopyTo(test, 0);
        bytes.CopyTo(test, preamble.Length);

        Assert.AreEqual(UTF7, TextEncodingConverter.GetCodePage(test.AsSpan(), out int bomLength));
        Assert.AreEqual(4, bomLength);
    }

    [TestMethod]
    public void GetCodePageTest4()
    {
        const int UTF7 = 65000;
        byte[] preamble = new byte[] { 0x2B, 0x2F, 0x76, 0x39 };
        byte[] bytes = TextEncodingConverter.GetEncoding(UTF7).GetBytes("test");

        byte[] test = new byte[preamble.Length + bytes.Length];
        preamble.CopyTo(test, 0);
        bytes.CopyTo(test, preamble.Length);

        Assert.AreEqual(UTF7, TextEncodingConverter.GetCodePage(test.AsSpan(), out int bomLength));
        Assert.AreEqual(4, bomLength);
    }

    [TestMethod]
    public void GetCodePageTest5()
    {
        const int UTF7 = 65000;
        byte[] preamble = new byte[] { 0x2B, 0x2F, 0x76, 0x2B };
        byte[] bytes = TextEncodingConverter.GetEncoding(UTF7).GetBytes("test");

        byte[] test = new byte[preamble.Length + bytes.Length];
        preamble.CopyTo(test, 0);
        bytes.CopyTo(test, preamble.Length);

        Assert.AreEqual(UTF7, TextEncodingConverter.GetCodePage(test.AsSpan(), out int bomLength));
        Assert.AreEqual(4, bomLength);
    }

    [TestMethod]
    public void GetCodePageTest6()
    {
        const int UTF7 = 65000;
        byte[] preamble = new byte[] { 0x2B, 0x2F, 0x76, 0x2F };
        byte[] bytes = TextEncodingConverter.GetEncoding(UTF7).GetBytes("test");

        byte[] test = new byte[preamble.Length + bytes.Length];
        preamble.CopyTo(test, 0);
        bytes.CopyTo(test, preamble.Length);

        Assert.AreEqual(UTF7, TextEncodingConverter.GetCodePage(test.AsSpan(), out int bomLength));
        Assert.AreEqual(4, bomLength);
    }

    [DataTestMethod]
    [DataRow(1200)]
    [DataRow(1201)]
    [DataRow(12000)]
    [DataRow(12001)]
    //[DataRow(54936, 4)]
    //[DataRow(65000, 4)]
    [DataRow(65001)]
    public void GetCodePageTest7(int codePage)
    {
        Encoding enc = TextEncodingConverter.GetEncoding(codePage);

        /* Nicht gemergte Änderung aus Projekt "FolkerKinzel.Strings.Tests (net5.0)"
        Vor:
                    const string test = "test";

                    var bytes = enc.GetBytes(test);
        Nach:
                    const string test = "test";

                    var bytes = enc.GetBytes(test);
        */

        /* Nicht gemergte Änderung aus Projekt "FolkerKinzel.Strings.Tests (net45)"
        Vor:
                    const string test = "test";

                    var bytes = enc.GetBytes(test);
        Nach:
                    const string test = "test";

                    var bytes = enc.GetBytes(test);
        */

        /* Nicht gemergte Änderung aus Projekt "FolkerKinzel.Strings.Tests (netcoreapp2.1)"
        Vor:
                    const string test = "test";

                    var bytes = enc.GetBytes(test);
        Nach:
                    const string test = "test";

                    var bytes = enc.GetBytes(test);
        */

        /* Nicht gemergte Änderung aus Projekt "FolkerKinzel.Strings.Tests (netcoreapp3.1)"
        Vor:
                    const string test = "test";

                    var bytes = enc.GetBytes(test);
        Nach:
                    const string test = "test";

                    var bytes = enc.GetBytes(test);
        */
        const string test = "test";

        var bytes = enc.GetBytes(test);

        Assert.AreEqual(codePage, TextEncodingConverter.GetCodePage(bytes.AsSpan(), out int bomLength));
        Assert.AreEqual(0, bomLength);
    }

    [DataTestMethod]
    //[DataRow(1200)]
    //[DataRow(1201)]
    [DataRow(12000)]
    [DataRow(12001)]
    //[DataRow(54936, 4)]
    //[DataRow(65000, 4)]
    [DataRow(65001)]
    public void GetCodePageTest8(int codePage)
    {
        Encoding enc = TextEncodingConverter.GetEncoding(codePage);
        const string test = "\u03c0äöüß";

        var bytes = enc.GetBytes(test);

        Assert.AreEqual(codePage, TextEncodingConverter.GetCodePage(bytes.AsSpan(), out int bomLength));
        Assert.AreEqual(0, bomLength);
    }
}
