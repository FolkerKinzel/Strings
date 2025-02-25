namespace FolkerKinzel.Strings.Tests;

[TestClass]
public class SpanLineEnumeratorPolyfillExtensionTests
{
    [TestMethod]
    public void MoveNextTest1()
    {
        string input = "1\r";

        int counter = 0;

        foreach (ReadOnlySpan<char> _ in input.AsSpan().EnumerateLines())
        {
            counter++;
        }

        Assert.AreEqual(2, counter);
    }

    [TestMethod]
    public void MoveNextTest2()
    {
        string input = "1\r2";

        int counter = 0;

        foreach (ReadOnlySpan<char> _ in input.AsSpan().EnumerateLines())
        {
            counter++;
        }

        Assert.AreEqual(2, counter);
    }
}
