namespace FolkerKinzel.Strings.Tests;

[TestClass]
public class StringBuilderExtensionsPolyfillTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ReplaceWhiteSpaceWithTest1()
    {
        StringBuilder? sb = null;
        _ = sb!.ReplaceWhiteSpaceWith("");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ReplaceWhiteSpaceWithTest2()
    {
        StringBuilder? sb = null;
        _ = sb!.ReplaceWhiteSpaceWith("", 0);
    }

    [TestMethod]
    public void ReplaceWhiteSpaceWithTest6()
    {
        var sb = new StringBuilder("T e s t");
        Assert.AreEqual("Test", sb.ReplaceWhiteSpaceWith("").ToString());
    }

    [TestMethod]
    public void ReplaceWhiteSpaceWithTest3()
    {
        var sb = new StringBuilder("T e s t");
        Assert.AreEqual("Test", sb.ReplaceWhiteSpaceWith("", 0).ToString());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ReplaceWhiteSpaceWithTest4()
    {
        StringBuilder? sb = null;
        _ = sb!.ReplaceWhiteSpaceWith("", 0, 0);
    }

    [TestMethod]
    public void ReplaceWhiteSpaceWithTest5()
    {
        var sb = new StringBuilder("T e s t");
        Assert.AreEqual("Test", sb.ReplaceWhiteSpaceWith("", 0, sb.Length).ToString());
    }


    //#pragma warning disable CS0618 // Typ oder Element ist veraltet
    //    [TestMethod]
    //    public void NormalizeNewLinesToTest1()
    //       => Assert.AreEqual("\t Test   * text  ", new StringBuilder("\t Test   \r\n text  ").NormalizeNewLinesTo("*").ToString());


    //    [TestMethod]
    //    public void NormalizeNewLinesToTest2()
    //        => Assert.AreEqual("\t Test   * text  ", new StringBuilder("\t Test   \r\n text  ").NormalizeNewLinesTo("*").ToString());


    //    [TestMethod]
    //    [ExpectedException(typeof(ArgumentNullException))]
    //    public void NormalizeNewLinesToTest3()
    //    {
    //        StringBuilder? s = null;
    //        _ = s!.NormalizeNewLinesTo("*");
    //    }

    //#pragma warning restore CS0618 // Typ oder Element ist veraltet

}
