namespace FolkerKinzel.Strings.Tests;

[TestClass]
public class StreamExtensionTests
{
    private readonly byte[] _validUtf8 = [17, 4, 42];
    private readonly byte[] _noUtf8 = [129, 142, 210, 184];
    private readonly byte[] _bom = [0xEF, 0xBB, 0xBF];


    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void IsUtf8Test1()
    {
        Stream? str = null;
        str!.IsUtf8();
    }


    [TestMethod]
    public void IsUtf8Test2()
    {
        using var str = new MemoryStream();
        Assert.IsFalse(str.IsUtf8(count: 0));
    }

    [TestMethod]
    public void IsUtf8Test3()
    {
        using var str = new MemoryStream([.. _validUtf8, .. _validUtf8]);
        Assert.IsFalse(str.IsUtf8(count: 0, leaveOpen: true));
        str.Position = 0;
        Assert.IsTrue(str.IsUtf8());
    }

    [TestMethod]
    public void IsUtf8Test4()
    {
        using (var str1 = new MemoryStream(_noUtf8))
        {
            Assert.IsFalse(str1.IsUtf8());
        }

        using (var str2 = new MemoryStream(_bom))
        {
            Assert.IsTrue(str2.IsUtf8Valid());
        }

        var concat = new List<byte>(_bom);
        concat.AddRange(_noUtf8);

        var concatBytes = concat.ToArray();

        using var str3 = new MemoryStream(concatBytes);

        Assert.IsTrue(str3.IsUtf8(leaveOpen: true));
        str3.Position = 0;
        Assert.IsFalse(str3.IsUtf8Valid());
    }

    [TestMethod]
    public void IsUtf8Test5()
    {
        var list = new List<byte>(_validUtf8);
        list.AddRange(_noUtf8);
        using var stream = new MemoryStream([.. list]);
        Assert.IsFalse(stream.IsUtf8());
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void IsUtf8ValidTest1()
    {
        using var str = new MemoryStream(_validUtf8);
        _ = str.IsUtf8Valid(count: 0);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void IsUtf8ValidTest2()
    {
        Stream? str = null;
        str!.IsUtf8Valid();
    }
}
