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


    [TestMethod]
    public void AddTest15()
    {
        var hasher = new PersistentStringHash(HashType.Ordinal);
        string? s = null;
        hasher.Add(s);
        int hash1 = hasher.ToHashCode();
        int hash2 = s.GetPersistentHashCode(HashType.Ordinal);
        Assert.AreEqual(hash1, hash2);
    }

    [DataTestMethod]
    [DataRow(HashType.Ordinal)]
    [DataRow(HashType.OrdinalIgnoreCase)]
    [DataRow(HashType.AlphaNumericIgnoreCase)]
    public void AddTest16(HashType hashType)
    {
        const string str1 = "aBc";
        const string str2 = "+ Gg";

        var hasher = new PersistentStringHash(hashType);
        hasher.Add(new StringBuilder(str1));
        hasher.Add(new StringBuilder(str2));
        int hash1 = hasher.ToHashCode();

        string combined = str1 + str2;
        int hash2 = PersistentStringHash.From(new StringBuilder(combined), hashType);
        int hash3 = PersistentStringHash.From(combined, hashType);

        Assert.AreEqual(hash1, hash2);
        Assert.AreEqual(hash1, hash3);
    }


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

    [TestMethod()]
    public void FromTest1()
    {
        int hash1 = PersistentStringHash.From(string.Empty.AsSpan(), HashType.Ordinal);
        int hash2 = "".GetPersistentHashCode(HashType.Ordinal);

        Assert.AreEqual(hash1, hash2);
    }

    [TestMethod()]
    public void FromTest2()
    {
        string? s1 = null;
        const HashType hashType = HashType.Ordinal;
        Assert.AreEqual("".GetPersistentHashCode(hashType), PersistentStringHash.From(s1.AsSpan(), hashType));
    }

    [TestMethod()]
    public void FromTest3()
    {
        int hash1 = PersistentStringHash.From("Hallo".AsSpan(), HashType.OrdinalIgnoreCase);
        int hash2 = PersistentStringHash.From("hallo".AsSpan(), HashType.OrdinalIgnoreCase);

        Assert.AreEqual(hash1, hash2);
    }

    [TestMethod()]
    public void FromTest4()
    {
        int hash1 = PersistentStringHash.From("Hallo".AsSpan(), HashType.Ordinal);
        int hash2 = PersistentStringHash.From("hallo".AsSpan(), HashType.Ordinal);

        Assert.AreNotEqual(hash1, hash2);
    }

    [TestMethod()]
    public void FromTest5()
    {
        int hash1 = PersistentStringHash.From("Hallo, dies ist Text.".AsSpan(), HashType.AlphaNumericIgnoreCase);
        int hash2 = PersistentStringHash.From("hallodiesisttext".AsSpan(), HashType.OrdinalIgnoreCase);

        Assert.AreEqual(hash1, hash2);
    }

    [TestMethod()]
    public void FromTest6()
    {
        string? s1 = null;
        const HashType hashType = HashType.AlphaNumericIgnoreCase;
        Assert.AreEqual("".GetPersistentHashCode(hashType), PersistentStringHash.From(s1, hashType));
    }

    [TestMethod()]
    [ExpectedException(typeof(ArgumentException))]
    public void FromTest7() => _ = PersistentStringHash.From(string.Empty.AsSpan(), (HashType)4711);

    [TestMethod()]
    public void FromTest11()
    {
        int hash1 = PersistentStringHash.From(string.Empty.AsSpan(), HashType.Ordinal);
        int hash2 = "".GetPersistentHashCode(HashType.Ordinal);

        Assert.AreEqual(hash1, hash2);
    }

    [TestMethod()]
    public void FromTest12()
    {
        string? s1 = null;
        const HashType hashType = HashType.Ordinal;
        Assert.AreEqual("".GetPersistentHashCode(hashType), PersistentStringHash.From(s1.AsSpan(), hashType));
    }

    [TestMethod()]
    public void FromTest13()
    {
        int hash1 = PersistentStringHash.From("Hallo".AsSpan(), HashType.OrdinalIgnoreCase);
        int hash2 = PersistentStringHash.From("hallo".AsSpan(), HashType.OrdinalIgnoreCase);

        Assert.AreEqual(hash1, hash2);
    }

    [TestMethod()]
    public void FromTest14()
    {
        int hash1 = PersistentStringHash.From("Hallo".AsSpan(), HashType.Ordinal);
        int hash2 = PersistentStringHash.From("hallo".AsSpan(), HashType.Ordinal);

        Assert.AreNotEqual(hash1, hash2);
    }

    [TestMethod()]
    public void FromTest15()
    {
        int hash1 = PersistentStringHash.From("Hallo, dies ist Text.".AsSpan(), HashType.AlphaNumericIgnoreCase);
        int hash2 = PersistentStringHash.From("hallodiesisttext".AsSpan(), HashType.OrdinalIgnoreCase);

        Assert.AreEqual(hash1, hash2);
    }

    [TestMethod()]
    public void FromTest16()
    {
        string? s1 = null;
        const HashType hashType = HashType.AlphaNumericIgnoreCase;
        Assert.AreEqual("".GetPersistentHashCode(hashType), PersistentStringHash.From(s1.AsSpan(), hashType));
    }

    [TestMethod()]
    [ExpectedException(typeof(ArgumentException))]
    public void FromTest17() => _ = PersistentStringHash.From(string.Empty.AsSpan(), (HashType)4711);
}
