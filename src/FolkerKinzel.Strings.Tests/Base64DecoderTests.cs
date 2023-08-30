using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Tests;

[TestClass]
public class Base64DecoderTests
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
        var bytes = Base64Decoder.GetBytes(input.AsSpan());
        Assert.AreEqual(expected, Encoding.UTF8.GetString(bytes));
    }
}
