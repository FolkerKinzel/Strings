#if !NETCOREAPP3_1
using FolkerKinzel.Strings.Polyfills;
#endif
using System.Net;


using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Tests;

[TestClass]
public class UrlEncodingTests
{
    [DataTestMethod]
    [DataRow(0)]
    [DataRow(128)]
    [DataRow(256)]
    public void AppendUrlEncodedTest1(int length)
    {
        var chars = new char[length];

        for (int i = 0; i < length; i++)
        {
            chars[i] = (char)i;
        }

        string input = new(chars);
        Assert.AreEqual(Uri.EscapeDataString(input), new StringBuilder().AppendUrlEncoded(input).ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void AppendUrlEncodedTest2()
    {
        StringBuilder? sb = null;
        sb!.AppendUrlEncoded("abc");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void AppendUrlEncodedTest3()
    {
        StringBuilder? sb = null;
        sb!.AppendUrlEncoded(new byte[] {1,2,3});
    }

    [TestMethod]
    public void AppendUrlEncodedTest4()
    {
        byte[]? input = null;
        Assert.AreEqual(0, new StringBuilder().AppendUrlEncoded(input!).Length);
    }

    [TestMethod]
    public void AppendUrlEncodedTest5()
    {
        IEnumerable<byte>? input = null;
        Assert.AreEqual(0, new StringBuilder().AppendUrlEncoded(input!).Length);
    }

    [TestMethod]
    public void TryDecodeTest1()
    {
        const int length = 256;
        var chars = new char[length];

        for (int i = 0; i < length; i++)
        {
            chars[i] = (char)i;
        }

        string input = new(chars);

        Assert.IsTrue(UrlEncoding.TryDecode(Uri.EscapeDataString(input), true, out string? decoded));
        Assert.AreEqual(input, decoded);
    }

    [TestMethod]
    public void TryDecodeTest1b()
    {
        const int length = 256;
        var chars = new char[length];

        for (int i = 0; i < length; i++)
        {
            chars[i] = (char)i;
        }

        string input = new(chars);

        Assert.IsTrue(UrlEncoding.TryDecode(Uri.EscapeDataString(input), null, true, out string? decoded));
        Assert.AreEqual(input, decoded);
    }

    [TestMethod]
    public void TryDecodeTest2()
    {
        const string input = "1+2%3D3";

        Assert.IsTrue(UrlEncoding.TryDecode(input, true, out string? decoded));
        Assert.AreEqual("1 2=3", decoded);
    }

    [TestMethod]
    public void TryDecodeTest2b()
    {
        const string input = "1+2%3D3";

        Assert.IsTrue(UrlEncoding.TryDecode(input, false, out string? decoded));
        Assert.AreEqual("1+2=3", decoded);
    }

    [TestMethod]
    public void TryDecodeTest3()
    {
        const string input = "äöü";
        Assert.IsFalse(UrlEncoding.TryDecode(input, true, out _));
    }


    [TestMethod]
    public void TryDecodeTest4()
    {
        const string charSet = "windows-1252";
        const string input = "a Ü+ä%ß";

        var bytes = TextEncodingConverter.GetEncoding(charSet).GetBytes(input);

        bytes = WebUtility.UrlEncodeToBytes(bytes, 0, bytes.Length);

        string encoded = Encoding.UTF8.GetString(bytes);

        Assert.IsFalse(UrlEncoding.TryDecode(encoded, true, out _));
        Assert.IsFalse(UrlEncoding.TryDecode(encoded, "nixdablabla", true, out _));
        Assert.IsFalse(UrlEncoding.TryDecode(encoded, "utf-8", true, out _));
        Assert.IsTrue(UrlEncoding.TryDecode(encoded, charSet, true, out string? decoded));

        Assert.AreEqual(input, decoded);
    }

    [TestMethod]
    public void TryDecodeTest5()
    {
        const string charSet = "windows-1252";
        const string input = "a Ü+ä%ß";

        Encoding encoding = TextEncodingConverter.GetEncoding(charSet);
        var bytes = encoding.GetBytes(input);

        bytes = WebUtility.UrlEncodeToBytes(bytes, 0, bytes.Length);

        string encoded = Encoding.UTF8.GetString(bytes);

        Assert.IsFalse(UrlEncoding.TryDecode(encoded, true, out _));
        Assert.IsFalse(UrlEncoding.TryDecode(encoded, -1, true, out _));
        Assert.IsFalse(UrlEncoding.TryDecode(encoded, Encoding.UTF8.CodePage, true, out _));
        Assert.IsTrue(UrlEncoding.TryDecode(encoded, encoding.CodePage, true, out string? decoded));

        Assert.AreEqual(input, decoded);
    }


    [TestMethod]
    public void TryDecodeToBytesTest1()
    {
        byte[] data = new byte[1024];
        var rnd = new Random();
        rnd.NextBytes(data);

        var sb = new StringBuilder();
        string encoded = sb.AppendUrlEncoded(data).ToString();

        Assert.IsTrue(UrlEncoding.TryDecodeToBytes(encoded, out byte[]? decoded));
        CollectionAssert.AreEqual(data, decoded);
    }

    [TestMethod]
    public void TryDecodeToBytesTest1b()
    {
        byte[] data = new byte[1024];
        var rnd = new Random();
        rnd.NextBytes(data);

        var sb = new StringBuilder();
        string encoded = sb.AppendUrlEncoded(data.AsEnumerable()).ToString();

        Assert.IsTrue(UrlEncoding.TryDecodeToBytes(encoded, out byte[]? decoded));
        CollectionAssert.AreEqual(data, decoded);
    }

    [TestMethod]
    public void TryDecodeToBytesTest2()
    {
        byte[] data = "IT"u8.ToArray();

        var sb = new StringBuilder();
        string encoded = sb.AppendUrlEncoded(data).ToString();

        Assert.IsTrue(UrlEncoding.TryDecodeToBytes(encoded, out byte[]? decoded));
        CollectionAssert.AreEqual(data, decoded);
    }

    [TestMethod]
    public void TryDecodeToBytesTest3() => Assert.IsFalse(UrlEncoding.TryDecodeToBytes("äöü", out _));
}
