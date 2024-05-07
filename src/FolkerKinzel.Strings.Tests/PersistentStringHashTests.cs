using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Tests;

[TestClass]
public class PersistentStringHashTests
{
    [DataTestMethod]
    [DataRow(HashType.Ordinal)]
    [DataRow(HashType.OrdinalIgnoreCase)]
    [DataRow(HashType.AlphaNumericIgnoreCase)]
    public void PersistentStringHashTest1(HashType hashType)
        => Assert.AreEqual(hashType, new PersistentStringHash(hashType).HashType);

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void PersistentStringHashTest2() => new PersistentStringHash((HashType)4711);

    [TestMethod]
    [ExpectedException(typeof(NotSupportedException))]
    public void EqualsTest1() => ((object)new PersistentStringHash(HashType.Ordinal)).Equals(42);

    [TestMethod]
    [ExpectedException(typeof(NotSupportedException))]
    public void GetHashCodeTest1() => ((object)new PersistentStringHash(HashType.Ordinal)).GetHashCode();

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void AddTest1() => new PersistentStringHash().Add("a".AsSpan());

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void AddTest2() => new PersistentStringHash().Add('a');

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void AddTest3() => new PersistentStringHash().Add(new StringBuilder("a"));

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void AddTest4() => new PersistentStringHash().Add(new StringBuilder("a"), 0);

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void AddTest5() => new PersistentStringHash().Add(new StringBuilder("a"), 0, 1);


    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void AddTest6() => new PersistentStringHash().Add((StringBuilder)null!);

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void AddTest7() => new PersistentStringHash().Add((StringBuilder)null!, 0);

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void AddTest8() => new PersistentStringHash().Add((StringBuilder)null!, 0, 1);

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void AddTest9() => new PersistentStringHash().Add(new StringBuilder("a"), -1);

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void AddTest10() => new PersistentStringHash().Add(new StringBuilder("a"), 50);

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void AddTest11() => new PersistentStringHash().Add(new StringBuilder("a"), -1, 1);

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void AddTest12() => new PersistentStringHash().Add(new StringBuilder("a"), 50, 1);

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void AddTest13() => new PersistentStringHash().Add(new StringBuilder("a"), 0, -1);

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void AddTest14() => new PersistentStringHash().Add(new StringBuilder("a"), 0, 50);

    [DataTestMethod]
    [DataRow(HashType.Ordinal)]
    [DataRow(HashType.OrdinalIgnoreCase)]
    [DataRow(HashType.AlphaNumericIgnoreCase)]
    public void ToHashCodeTest1(HashType hashType)
    {
        int hash1 = new PersistentStringHash(hashType).ToHashCode();

        var sbHash = new PersistentStringHash(hashType);
        sbHash.Add(new StringBuilder());
        int hash2 = sbHash.ToHashCode();

        var spanHash = new PersistentStringHash(hashType);
        spanHash.Add("".AsSpan());
        int hash3 = spanHash.ToHashCode();

        Assert.AreEqual(hash1, hash2);
        Assert.AreEqual(hash1, hash3);
    }


    [DataTestMethod]
    [DataRow(HashType.Ordinal)]
    [DataRow(HashType.OrdinalIgnoreCase)]
    [DataRow(HashType.AlphaNumericIgnoreCase)]
    public void ToHashCodeTest2(HashType hashType)
    {
        const string test = " XüÖ$§@kT22*";

        var charHash = new PersistentStringHash(hashType);

        foreach (char c in test.AsSpan())
        {
            charHash.Add(c);
        }

        int hash1 = charHash.ToHashCode();

        var sbHash = new PersistentStringHash(hashType);
        sbHash.Add(new StringBuilder(test));
        int hash2 = sbHash.ToHashCode();

        var spanHash = new PersistentStringHash(hashType);
        spanHash.Add(test.AsSpan());
        int hash3 = spanHash.ToHashCode();

        var sbHash2 = new PersistentStringHash(hashType);
        sbHash2.Add(new StringBuilder(test), 0);
        int hash4 = sbHash.ToHashCode();

        var sbHash3 = new PersistentStringHash(hashType);
        sbHash3.Add(new StringBuilder(test), 0, test.Length);
        int hash5 = sbHash.ToHashCode();

        Assert.AreEqual(hash1, hash2);
        Assert.AreEqual(hash1, hash3);
        Assert.AreEqual(hash1, hash4);
        Assert.AreEqual(hash1, hash5);
    }

    [DataTestMethod]
    [DataRow(HashType.Ordinal)]
    [DataRow(HashType.OrdinalIgnoreCase)]
    [DataRow(HashType.AlphaNumericIgnoreCase)]
    public void ToHashCodeTest3(HashType hashType)
    {
        var sb = new StringBuilder("abc");
        var hasher = new PersistentStringHash(hashType);

        int hash1 = hasher.ToHashCode();
        hasher.Add(sb, 0, 0);
        int hash2 = hasher.ToHashCode();

        Assert.AreEqual(hash1, hash2);
    }

    [DataTestMethod]
    [DataRow(HashType.Ordinal)]
    [DataRow(HashType.OrdinalIgnoreCase)]
    [DataRow(HashType.AlphaNumericIgnoreCase)]
    public void ToHashCodeTest4(HashType hashType)
    {
        StringBuilder sb = new StringBuilder("a").Append("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
        var hasher1 = new PersistentStringHash(hashType);
        hasher1.Add(sb, sb.Length - 1, 1);

        var hasher2 = new PersistentStringHash(hashType);
        hasher2.Add('x');

        Assert.AreEqual(hasher1.ToHashCode(), hasher2.ToHashCode());
    }

    [DataTestMethod]
    [DataRow(HashType.Ordinal)]
    [DataRow(HashType.OrdinalIgnoreCase)]
    [DataRow(HashType.AlphaNumericIgnoreCase)]
    public void ToHashCodeTest5(HashType hashType)
    {
        StringBuilder sb = new StringBuilder("a").Append("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
        var hasher1 = new PersistentStringHash(hashType);
        hasher1.Add(sb, 0, sb.Length);

        var hasher2 = new PersistentStringHash(hashType);
        hasher2.Add(sb.ToString().AsSpan());

        Assert.AreEqual(hasher1.ToHashCode(), hasher2.ToHashCode());
    }
}
