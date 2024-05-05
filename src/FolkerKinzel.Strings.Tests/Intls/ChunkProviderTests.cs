namespace FolkerKinzel.Strings.Intls.Tests;

[TestClass]
public class ChunkProviderTests
{
# if !NET48
    [TestMethod]
    public void TryGetCunkTest1() => Assert.IsFalse(ChunkProvider.TryGetChunk(new StringBuilder(), 4711, out _, out _));
#endif
}
