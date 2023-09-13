#if !NETCOREAPP3_1
using System.Net;
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
    public void TryDecodeTest1()
    {
        const int length = 256;
        var chars = new char[length];

        for (int i = 0; i < length; i++)
        {
            chars[i] = (char)i;
        }

        string input = new(chars);

        Assert.IsTrue(UrlEncoding.TryDecode(Uri.EscapeDataString(input), out string? decoded));
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

        Assert.IsTrue(UrlEncoding.TryDecode(Uri.EscapeDataString(input), null, out string? decoded));
        Assert.AreEqual(input, decoded);
    }

    [TestMethod]
    public void TryDecodeTest2()
    {
        const string input = "1+2";

        Assert.IsTrue(UrlEncoding.TryDecode(input, out string? decoded));
        Assert.AreEqual("1 2", decoded);
    }

    [TestMethod]
    public void TryDecodeTest3()
    {
        const string input = "äöü";
        Assert.IsFalse(UrlEncoding.TryDecode(input, out _));
    }


    [TestMethod]
    public void TryDecodeTest4()
    {
        const string charSet = "windows-1252";
        const string input = "a Ü+ä%ß";

        var bytes = TextEncodingConverter.GetEncoding(charSet).GetBytes(input);

        bytes = WebUtility.UrlEncodeToBytes(bytes, 0, bytes.Length);

        string encoded = Encoding.UTF8.GetString(bytes);

        Assert.IsFalse(UrlEncoding.TryDecode(encoded, out _));
        Assert.IsFalse(UrlEncoding.TryDecode(encoded, "nixdablabla", out _));
        Assert.IsFalse(UrlEncoding.TryDecode(encoded, "utf-8", out _));
        Assert.IsTrue(UrlEncoding.TryDecode(encoded, charSet, out string? decoded));

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

        Assert.IsFalse(UrlEncoding.TryDecode(encoded, out _));
        Assert.IsFalse(UrlEncoding.TryDecode(encoded, -1, out _));
        Assert.IsFalse(UrlEncoding.TryDecode(encoded, Encoding.UTF8.CodePage, out _));
        Assert.IsTrue(UrlEncoding.TryDecode(encoded, encoding.CodePage, out string? decoded));

        Assert.AreEqual(input, decoded);
    }
}
