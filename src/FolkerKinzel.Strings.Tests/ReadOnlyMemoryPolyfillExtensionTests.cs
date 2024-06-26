﻿using FolkerKinzel.Strings;

namespace FolkerKinzel.Strings.Tests;

[TestClass()]
public class ReadOnlyMemoryPolyfillExtensionTests
{
    [TestMethod()]
    public void TrimTest()
    {
        string test = "  Test ";
        ReadOnlyMemory<char> memory = test.AsMemory();
        Assert.AreEqual(test.Trim(), memory.Trim().ToString());
    }

    [TestMethod()]
    public void TrimStartTest()
    {
        string test = "  Test ";
        ReadOnlyMemory<char> memory = test.AsMemory();
        Assert.AreEqual(test.TrimStart(), memory.TrimStart().ToString());
    }

    [TestMethod()]
    public void TrimEndTest()
    {
        string test = "  Test ";
        ReadOnlyMemory<char> memory = test.AsMemory();
        Assert.AreEqual(test.TrimEnd(), memory.TrimEnd().ToString());
    }
}
