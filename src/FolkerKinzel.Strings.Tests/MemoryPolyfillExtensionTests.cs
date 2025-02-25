namespace FolkerKinzel.Strings.Tests;

[TestClass()]
public class MemoryPolyfillExtensionTests
{
    [TestMethod()]
    public void TrimTest()
    {
        string test = "  Test ";
        Memory<char> memory = test.ToCharArray().AsMemory();
        Assert.AreEqual(test.Trim(), MemoryPolyfillExtension.Trim(memory).ToString());
    }

    [TestMethod()]
    public void TrimStartTest()
    {
        string test = "  Test ";
        Memory<char> memory = test.ToCharArray().AsMemory();
        Assert.AreEqual(test.TrimStart(), MemoryPolyfillExtension.TrimStart(memory).ToString());
    }

    [TestMethod()]
    public void TrimEndTest()
    {
        string test = "  Test ";
        Memory<char> memory = test.ToCharArray().AsMemory();
        Assert.AreEqual(test.TrimEnd(), MemoryPolyfillExtension.TrimEnd(memory).ToString());
    }
}
