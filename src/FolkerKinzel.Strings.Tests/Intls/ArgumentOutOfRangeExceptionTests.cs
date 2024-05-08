namespace FolkerKinzel.Strings.Intls.Tests;

[TestClass]
public class ArgumentOutOfRangeExceptionTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void ThrowIfNegativeTest1() => _ArgumentOutOfRangeException.ThrowIfNegative(-1, "para");

    [TestMethod]
    public void ThrowIfNegativeTest2() => _ArgumentOutOfRangeException.ThrowIfNegative(0, "para");
}
