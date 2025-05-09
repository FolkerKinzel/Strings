﻿using FolkerKinzel.Strings.Intls;

namespace FolkerKinzel.Strings.Tests;

[TestClass()]
public class StaticStringMethodTests
{
    [TestMethod()]
    [ExpectedException(typeof(ArgumentNullException))]
    public void CreateTest1() => _ = StaticStringMethod.Create(0, "", null!);

    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void CreateTest2() => _ = StaticStringMethod.Create(-1, "", (span, tState) => { });

    [TestMethod()]
    public void CreateTest3() => Assert.AreEqual(0, StaticStringMethod.Create(0, "", (span, tState) => { }).Length);

    [TestMethod()]
    public void CreateTest4()
    {
        Assert.AreEqual("HELL", StaticStringMethod.Create(4, "hello",
            (span, tState) =>
            {
                for (int i = 0; i < span.Length; i++)
                {
                    span[i] = tState[i].ToUpperInvariant();
                }
            }));
    }

    [TestMethod()]
    public void CreateTest5()
    {
        const int length = Const.StackallocCharThreshold + 5;
        Assert.AreEqual(new string('x', length), StaticStringMethod.Create(length, "",
            (span, tState) =>
            {
                for (int i = 0; i < span.Length; i++)
                {
                    span[i] = 'x';
                }
            }));
    }

    [TestMethod()]
    public void CreateTest6()
    {
        const int length = Const.StackallocCharThreshold;
        Assert.AreEqual(new string('x', length), StaticStringMethod.Create(length, "",
            (span, tState) =>
            {
                for (int i = 0; i < span.Length; i++)
                {
                    span[i] = 'x';
                }
            }));
    }

    [DataTestMethod]
    [DataRow("One", "Two", "Three", "Four")]
    [DataRow("", "Two", "Three", "Four")]
    [DataRow("One", "", "Three", "Four")]
    [DataRow("One", "Two", "", "Four")]
    [DataRow("One", "Two", "Three", "")]
    [DataRow("Veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.", "Another veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.", "Third veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.", "Last veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.")]
    [DataRow("", "Another veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.", "Third veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.", "Last veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.")]
    [DataRow("Veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.", "", "Third veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.", "Last veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.")]
    [DataRow("Veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.", "Another veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.", "", "Last veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.")]
    [DataRow("Veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.", "Another veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.", "Third veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.", "")]
    [DataRow("", "", "", "")]
    [DataRow("One", "", "", "")]
    [DataRow("This is 64 chars looooooooooooooooooooooooooooooooooooooooooong.", "", "This is 64 chars looooooooooooooooooooooooooooooooooooooooooong.", "")]
    public void ConcatTest1(string one, string two, string three, string four)
        => Assert.AreEqual(one + two + three + four, StaticStringMethod.Concat(one.AsSpan(), two.AsSpan(), three.AsSpan(), four.AsSpan()));

    [DataTestMethod]
    [DataRow("One", "Two", "Three")]
    [DataRow("", "Two", "Three")]
    [DataRow("One", "", "Three")]
    [DataRow("One", "Two", "")]
    [DataRow("Veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.", "Another veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.", "Last veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.")]
    [DataRow("", "Another veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.", "Last veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.")]
    [DataRow("Veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.", "", "Last veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.")]
    [DataRow("Veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.", "Another veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.", "")]
    [DataRow("", "", "")]
    [DataRow("One", "", "")]
    [DataRow("This is 64 chars looooooooooooooooooooooooooooooooooooooooooong.", "This is 64 chars looooooooooooooooooooooooooooooooooooooooooong.", "")]
    public void ConcatTest2(string one, string two, string three)
        => Assert.AreEqual(one + two + three, StaticStringMethod.Concat(one.AsSpan(), two.AsSpan(), three.AsSpan()));

    [DataTestMethod]
    [DataRow("One", "Two")]
    [DataRow("", "Two")]
    [DataRow("One", "")]
    [DataRow("Veryyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy veryyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiing.", "Another veryyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy veryyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiing.")]
    [DataRow("Veryyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy veryyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy looooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiing.", "")]
    [DataRow("", "Veryyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy veryyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiing.")]
    [DataRow("", "Another veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.")]
    [DataRow("Veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.", "")]
    [DataRow("", "")]
    [DataRow("This is 64 chars looooooooooooooooooooooooooooooooooooooooooong.", "This is 64 chars looooooooooooooooooooooooooooooooooooooooooong.")]
    public void ConcatTest3(string one, string two)
        => Assert.AreEqual(one + two, StaticStringMethod.Concat(one.AsSpan(), two.AsSpan()));

    [TestMethod]
    public void ConcatTest4() => Assert.AreEqual("", StaticStringMethod.Concat(ReadOnlySpan<ReadOnlyMemory<char>>.Empty));

    [TestMethod]
    public void ConcatTest5() => Assert.AreEqual("123", StaticStringMethod.Concat(["123".AsMemory()]));

    [TestMethod]
    public void ConcatTest6() => Assert.AreEqual("123456", StaticStringMethod.Concat(["123".AsMemory(), "456".AsMemory()]));

    [TestMethod]
    public void ConcatTest7()
    {
        const string chunk = "1234567890";

        var memList = new List<ReadOnlyMemory<char>>();
        var stringList = new List<string>();

        for (int i = 0; i < 100; i++)
        {
            memList.Add(chunk.AsMemory());
            stringList.Add(chunk);
        }

        Assert.AreEqual(string.Concat(stringList), StaticStringMethod.Concat(memList.ToArray().AsSpan()));
    }
}
