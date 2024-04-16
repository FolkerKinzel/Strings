using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Tests;

[TestClass]
public class Base64Tests
{
    [DataTestMethod()]
    [DataRow("", "")]
    [DataRow("f", "Zg==")]
    [DataRow("fo", "Zm8=")]
    [DataRow("foo", "Zm9v")]
    [DataRow("foob", "Zm9vYg==")]
    [DataRow("fooba", "Zm9vYmE=")]
    [DataRow("foobar", "Zm9vYmFy")]
    public void GetBytesTest1(string expected, string input)
    {
        var bytes = Base64.GetBytes(input.AsSpan());
        Assert.AreEqual(expected, Encoding.UTF8.GetString(bytes));
    }

    [TestMethod]
    public void GetBytesTest2() => Assert.AreEqual(0, Base64.GetBytes((string?)null).Length);

    [TestMethod]
    public void GetBytesTest3() => Assert.AreEqual(0, Base64.GetBytes((string?)null, Base64ParserOptions.None).Length);

    [DataTestMethod()]
    [DataRow("", "")]
    [DataRow("f", "Zg==")]
    [DataRow("fo", "Zm8=")]
    [DataRow("foo", "Zm9v")]
    [DataRow("foob", "Zm9vYg==")]
    [DataRow("fooba", "Zm9vYmE=")]
    [DataRow("foobar", "Zm9vYmFy")]
    [DataRow("foobar", " Zm\r\n9v  YmFy  ")]
    public void GetBytesTest4(string expected, string input) => Assert.AreEqual(expected, Encoding.UTF8.GetString(Base64.GetBytes(input)));

    [DataTestMethod()]
    [DataRow("", "")]
    [DataRow("f", "Zg==")]
    [DataRow("fo", "Zm8=")]
    [DataRow("foo", "Zm9v")]
    [DataRow("foob", "Zm9vYg==")]
    [DataRow("fooba", "Zm9vYmE=")]
    [DataRow("foobar", "Zm9vYmFy")]
    [DataRow("foobar", " Zm\r\n9v  YmFy  ")]
    public void GetBytesTest5(string expected, string input) => Assert.AreEqual(expected, Encoding.UTF8.GetString(Base64.GetBytes(input, Base64ParserOptions.None)));

    [DataTestMethod()]
    [DataRow("", "")]
    [DataRow("f", "Zg==")]
    [DataRow("f", "Zg")]
    [DataRow("fo", "Zm8=")]
    [DataRow("fo", "Zm8")]
    [DataRow("foo", "Zm9v")]
    [DataRow("foob", "Zm9vYg==")]
    [DataRow("foob", "Zm9vYg")]
    [DataRow("fooba", "Zm9vYmE=")]
    [DataRow("fooba", "Zm9vYmE")]
    [DataRow("foobar", "Zm9vYmFy")]
    [DataRow("foobar", " Zm\r\n9v  YmFy  ")]
    public void GetBytesTest6(string expected, string input) => Assert.AreEqual(expected, Encoding.UTF8.GetString(Base64.GetBytes(input, Base64ParserOptions.AcceptMissingPadding)));

    [DataTestMethod()]
    [DataRow("", "")]
    [DataRow("f", "Zg==")]
    [DataRow("f", "Zg")]
    [DataRow("fo", "Zm8=")]
    [DataRow("fo", "Zm8")]
    [DataRow("foo", "Zm9v")]
    [DataRow("foob", "Zm9vYg==")]
    [DataRow("foob", "Zm9vYg")]
    [DataRow("fooba", "Zm9vYmE=")]
    [DataRow("fooba", "Zm9vYmE")]
    [DataRow("foobar", "Zm9vYmFy")]
    [DataRow("foobar", " Zm\r\n9v  YmFy  ")]
    public void GetBytesTest7(string expected, string input)
        => Assert.AreEqual(expected,
                           Encoding.UTF8.GetString(Base64.GetBytes(input, 
                                                   Base64ParserOptions.AcceptMissingPadding)));

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void GetBytesTest8() => _ = Base64.GetBytes("A".AsSpan());

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void GetBytesTest9() => _ = Base64.GetBytes("ABC".AsSpan());

    [TestMethod]
    public void GetBytesTest10()
    {
        const string input = "A+b/";
        byte[] originalBytes = Base64.GetBytes(input);

        string base64Url = input.Replace('+', '-').Replace('/', '_');
        byte[] base64UrlBytes = Base64.GetBytes(base64Url, Base64ParserOptions.AcceptBase64Url);
        CollectionAssert.AreEqual(originalBytes, base64UrlBytes);
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void GetBytesTest11() => _ = Base64.GetBytes("A".AsSpan(), Base64ParserOptions.AcceptMissingPadding);

    [TestMethod]
    public void GetBytesTest12()
    {
        const string input = "A+b/fg==";
        byte[] originalBytes = Base64.GetBytes(input);

        string base64Url = input.Replace('+', '-').Replace('/', '_');
        base64Url = Uri.EscapeDataString(base64Url);
        byte[] base64UrlBytes = Base64.GetBytes(base64Url, Base64ParserOptions.AcceptBase64Url);
        CollectionAssert.AreEqual(originalBytes, base64UrlBytes);
    }

    [TestMethod]
    public void GetBytesTest13()
    {
        const string input = "A+b/fg";
        byte[] originalBytes = Base64.GetBytes(input, Base64ParserOptions.AcceptMissingPadding);

        string base64Url = input.Replace('+', '-').Replace('/', '_');
        byte[] base64UrlBytes = Base64.GetBytes(base64Url, Base64ParserOptions.AcceptBase64Url | Base64ParserOptions.AcceptMissingPadding);
        CollectionAssert.AreEqual(originalBytes, base64UrlBytes);
    }

    [TestMethod]
    public void EncodeTest1() => Assert.AreEqual(0, Base64.Encode((byte[]?)null).Length);

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void EncodeTest2() => Base64.Encode((byte[]?)null!, 0, 0);

    [TestMethod]
    public void EncodeTest3() => Assert.AreEqual(0, Base64.Encode((IEnumerable<byte>?)null).Length);

    [DataTestMethod()]
    [DataRow("", "")]
    [DataRow("f", "Zg==")]
    [DataRow("fo", "Zm8=")]
    [DataRow("foo", "Zm9v")]
    [DataRow("foob", "Zm9vYg==")]
    [DataRow("fooba", "Zm9vYmE=")]
    [DataRow("foobar", "Zm9vYmFy")]
    public void EncodeTest4(string input, string expected) => Assert.AreEqual(expected, Base64.Encode(Encoding.UTF8.GetBytes(input).AsEnumerable()));

    [DataTestMethod()]
    [DataRow("", "")]
    [DataRow("f", "Zg==")]
    [DataRow("fo", "Zm8=")]
    [DataRow("foo", "Zm9v")]
    [DataRow("foob", "Zm9vYg==")]
    [DataRow("fooba", "Zm9vYmE=")]
    [DataRow("foobar", "Zm9vYmFy")]
    public void EncodeTest5(string input, string expected) => Assert.AreEqual(expected, Base64.Encode(Encoding.UTF8.GetBytes(input).ToList()));

    [DataTestMethod()]
    [DataRow("", "")]
    [DataRow("f", "Zg==")]
    [DataRow("fo", "Zm8=")]
    [DataRow("foo", "Zm9v")]
    [DataRow("foob", "Zm9vYg==")]
    [DataRow("fooba", "Zm9vYmE=")]
    [DataRow("foobar", "Zm9vYmFy")]
    public void EncodeTest6(string input, string expected) => Assert.AreEqual(expected, Base64.Encode(new ReadOnlyCollection<byte>(Encoding.UTF8.GetBytes(input))));

    [DataTestMethod()]
    [DataRow("", "")]
    [DataRow("f", "Zg==")]
    [DataRow("fo", "Zm8=")]
    [DataRow("foo", "Zm9v")]
    [DataRow("foob", "Zm9vYg==")]
    [DataRow("fooba", "Zm9vYmE=")]
    [DataRow("foobar", "Zm9vYmFy")]
    public void EncodeTest7(string input, string expected) => Assert.AreEqual(expected, Base64.Encode(Encoding.UTF8.GetBytes(input)));


    [DataTestMethod()]
    [DataRow("", "")]
    [DataRow("f", "Zg==")]
    [DataRow("fo", "Zm8=")]
    [DataRow("foo", "Zm9v")]
    [DataRow("foob", "Zm9vYg==")]
    [DataRow("fooba", "Zm9vYmE=")]
    [DataRow("foobar", "Zm9vYmFy")]
    public void EncodeTest8(string input, string expected) => Assert.AreEqual(expected, Base64.Encode(Encoding.UTF8.GetBytes(input).AsSpan()));

    [DataTestMethod()]
    [DataRow("", "")]
    [DataRow("f", "Zg==")]
    [DataRow("fo", "Zm8=")]
    [DataRow("foo", "Zm9v")]
    [DataRow("foob", "Zm9vYg==")]
    [DataRow("fooba", "Zm9vYmE=")]
    [DataRow("foobar", "Zm9vYmFy")]
    public void EncodeTest9(string input, string expected)
    {
        var bytes = Encoding.UTF8.GetBytes(input);
        Assert.AreEqual(expected, Base64.Encode(bytes, 0, bytes.Length));
    }


    [TestMethod]
    public void GetEncodedLengthTest1()
    {
        for (int i = 0; i < 10000; i++)
        {
            Assert.AreEqual(GetEncodedLength(i), Base64.GetEncodedLength(i));
        }

        static int GetEncodedLength(int inputLength)
        => (int)Math.Ceiling(inputLength / 3.0) << 2;
    }

    [TestMethod]
    public void GetEncodedLengthTest2() => Base64.GetEncodedLength(-42);
    


    //[TestMethod()]
    //public void FrameworkTest()
    //{
    //    var bytes = Convert.FromBase64String("Zm9#vYmFy");
    //    string s = Encoding.UTF8.GetString(bytes);
    //}
}
