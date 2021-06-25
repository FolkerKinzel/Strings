using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Tests
{
    [TestClass]
    public class StringBuilderExtensionTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPersistentHashCodeTest1()
        {
            StringBuilder? sb = null;
            _ = sb!.GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void GetPersistentHashCodeTest2()
        {
            var sb = new StringBuilder();
            _ = sb.GetPersistentHashCode((HashType)4711);
        }

        [TestMethod()]
        public void GetPersistentHashCodeTest6()
        {
            const string s = "Hallo, dies ist Text.";
            int hash1 = s.GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);
            int hash2 = s.AsSpan().GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);
            int hash3 = new StringBuilder().Append(s).GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);

            Assert.AreEqual(hash1, hash2);
            Assert.AreEqual(hash1, hash3);
        }

        [TestMethod()]
        public void GetPersistentHashCodeTest7()
        {
            const string s = "Hallo, dies ist Text.";
            int hash1 = s.GetPersistentHashCode(HashType.OrdinalIgnoreCase);
            int hash2 = s.AsSpan().GetPersistentHashCode(HashType.OrdinalIgnoreCase);
            int hash3 = new StringBuilder().Append(s).GetPersistentHashCode(HashType.OrdinalIgnoreCase);

            Assert.AreEqual(hash1, hash2);
            Assert.AreEqual(hash1, hash3);
        }

        [TestMethod()]
        public void GetPersistentHashCodeTest8()
        {
            const string s = "Hallo, dies ist Text.";
            int hash1 = s.GetPersistentHashCode(HashType.Ordinal);
            int hash2 = s.AsSpan().GetPersistentHashCode(HashType.Ordinal);
            int hash3 = new StringBuilder().Append(s).GetPersistentHashCode(HashType.Ordinal);

            Assert.AreEqual(hash1, hash2);
            Assert.AreEqual(hash1, hash3);
        }


        [TestMethod()]
        public void TrimTest1()
        {
            const string test = "Test";

            string value = $"    {test}    ";

            var sb = new StringBuilder(value);

            Assert.AreEqual(test, sb.Trim().ToString());
        }

    }
}