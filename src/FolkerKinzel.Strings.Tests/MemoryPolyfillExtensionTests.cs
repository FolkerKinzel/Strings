using FolkerKinzel.Strings;

namespace FolkerKinzel.Strings.Tests;

[TestClass()]
public class MemoryPolyfillExtensionTests
{
    [TestMethod()]
    public void TrimTest()
    {
        string test = "  Test ";
        Memory<char> memory = test.ToCharArray().AsMemory();
        Assert.AreEqual(test.Trim(), memory.Trim().ToString());
    }

    [TestMethod()]
    public void TrimStartTest()
    {
        string test = "  Test ";
        Memory<char> memory = test.ToCharArray().AsMemory();
        Assert.AreEqual(test.TrimStart(), memory.TrimStart().ToString());
    }

    [TestMethod()]
    public void TrimEndTest()
    {
        string test = "  Test ";
        Memory<char> memory = test.ToCharArray().AsMemory();
        Assert.AreEqual(test.TrimEnd(), memory.TrimEnd().ToString());
    }
}
