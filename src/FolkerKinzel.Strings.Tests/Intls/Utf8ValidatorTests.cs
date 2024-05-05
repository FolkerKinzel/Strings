namespace FolkerKinzel.Strings.Intls.Tests;

[TestClass]
public class Utf8ValidatorTests
{
    [TestMethod]
    public void IsUtf8Test1()
    {
        const string test = "ABCäöü123 xyz";
        var bytes = Encoding.UTF8.GetBytes(test);

        using var mem = new MemoryStream(bytes);
        var validator = new Utf8Validator();
        Assert.IsTrue(validator.IsUtf8(mem, -1, false));
    }

    [TestMethod]
    public void IsUtf8Test2()
    {
        var bytes = new byte[] { 158, 100, 199 };

        using var mem = new MemoryStream(bytes);
        var validator = new Utf8Validator();
        Assert.IsFalse(validator.IsUtf8(mem, -1, true));
        Assert.IsTrue(validator.IsUtf8(mem, -1, false));
    }
}
