using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        const int length = Const.ShortString + 5;
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
        const int length = Const.ShortString;
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
    [DataRow("This is 64 chars looooooooooooooooooooooooooooooooooooooooooong.", "This is 64 chars looooooooooooooooooooooooooooooooooooooooooong.", "")]
    public void ConcatTest2(string one, string two, string three)
        => Assert.AreEqual(one + two + three, StaticStringMethod.Concat(one.AsSpan(), two.AsSpan(), three.AsSpan()));

    [DataTestMethod]
    [DataRow("One", "Two")]
    [DataRow("", "Two")]
    [DataRow("One", "")]
    [DataRow("Veryyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy veryyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiing.", "Another veryyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy veryyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiing.")]
    [DataRow("", "Another veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.")]
    [DataRow("Veryyyyyyy veryyyyyyyyyyyyyy loooooooooooooooooooooooooooooong striiiiiiiiiiiiiiiiiiiiiing.", "")]
    [DataRow("", "")]
    [DataRow("This is 64 chars looooooooooooooooooooooooooooooooooooooooooong.", "This is 64 chars looooooooooooooooooooooooooooooooooooooooooong.")]
    public void ConcatTest3(string one, string two) 
        => Assert.AreEqual(one + two, StaticStringMethod.Concat(one.AsSpan(), two.AsSpan()));
}
