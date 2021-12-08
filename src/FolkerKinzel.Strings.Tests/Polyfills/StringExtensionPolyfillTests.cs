using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Polyfills.Tests;

[TestClass()]
public class StringExtensionPolyfillTests
{
    [TestMethod]
    public void ReplaceWhitespaceWithTest1()
       => Assert.AreEqual("*Test*\r\n*text*", "\t Test   \r\n text  ".ReplaceWhiteSpaceWith("*", true));


    [TestMethod]
    public void ReplaceWhitespaceWithTest2()
        => Assert.AreEqual("*Test*text*", "\t Test   \r\n text  ".ReplaceWhiteSpaceWith("*", false));

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ReplaceWhiteSpaceWithTest3()
    {
        string? s = null;
        _ = s!.ReplaceWhiteSpaceWith("*");
    }

#pragma warning disable CS0618 // Typ oder Element ist veraltet
    [TestMethod]
    public void NormalizeNewLinesToTest1()
       => Assert.AreEqual("\t Test   * text  ", "\t Test   \r\n text  ".NormalizeNewLinesTo("*"));


    [TestMethod]
    public void NormalizeNewLinesToTest2()
        => Assert.AreEqual("\t Test   * text  ", "\t Test   \r\n text  ".NormalizeNewLinesTo("*"));


    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void NormalizeNewLinesToTest3()
    {
        string? s = null;
        _ = s!.NormalizeNewLinesTo("*");
    }

#pragma warning restore CS0618 // Typ oder Element ist veraltet

}
