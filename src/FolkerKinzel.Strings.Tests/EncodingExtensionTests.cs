using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Tests;

[TestClass]
public class EncodingExtensionTests
{
    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))] 
    public void GetStringTest1()
    {
        Encoding? enc = null;
        _ = enc!.GetString(new byte[1].AsSpan());
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void GetStringTest1b()
    {
        Encoding? enc = null;
        _ = EncodingExtension.GetString(enc!, new byte[1].AsSpan());
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetBytesTest1()
    {
        Encoding? enc = null;
        _ = enc!.GetBytes("A".AsSpan());
    }

    [TestMethod]
    public void RoundtripTest()
    {
        const string s = "abcDEF 0123, : ; ÄÖÜ ßüöä";
        Encoding enc = Encoding.UTF8;

        var bytes = enc.GetBytes(s.AsSpan());
        string s2 = EncodingExtension.GetString(enc, bytes.AsSpan());

        Assert.AreEqual(s, s2);
    }
}
