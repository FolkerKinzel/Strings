using System.Buffers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Tests;

[TestClass]
public class SearchValuesTests
{
    [TestMethod]
    public void SearchValuesTest1()
    {
        var vals = SearchValuesPolyfill.Create("t".AsSpan());
        Assert.IsFalse(vals.Contains('x'));
        Assert.IsTrue(vals.Contains('t'));
    }

    [TestMethod]
    public void SearchValuesTest2()
    {
        var vals = SearchValuesPolyfill.Create("".AsSpan());
        Assert.IsFalse(vals.Contains('x'));
    }

}
