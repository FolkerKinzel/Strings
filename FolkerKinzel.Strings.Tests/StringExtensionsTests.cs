using Microsoft.VisualStudio.TestTools.UnitTesting;
using FolkerKinzel.Strings;
using System;
using System.Collections.Generic;
using System.Text;

namespace FolkerKinzel.Strings.Tests
{
    [TestClass()]
    public class StringExtensionsTests
    {
        [TestMethod()]
        public void GetStableHashCodeTest1()
        {
            int hash1 = string.Empty.GetPersistentHashCode(HashType.Ordinal);
            int hash2 = "".GetPersistentHashCode(HashType.Ordinal);

            Assert.AreEqual(hash1, hash2);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetStableHashCodeTest2()
        {
            string? s = null;

            _ = s!.GetPersistentHashCode(HashType.Ordinal);
        }


        [TestMethod()]
        public void GetStableHashCodeTest3()
        {
            int hash1 = "Hallo".GetPersistentHashCode(HashType.OrdinalIgnoreCase);
            int hash2 = "hallo".GetPersistentHashCode(HashType.OrdinalIgnoreCase);

            Assert.AreEqual(hash1, hash2);
        }


        [TestMethod()]
        public void GetStableHashCodeTest4()
        {
            int hash1 = "Hallo".GetPersistentHashCode(HashType.Ordinal);
            int hash2 = "hallo".GetPersistentHashCode(HashType.Ordinal);

            Assert.AreNotEqual(hash1, hash2);
        }


        [TestMethod()]
        public void GetStableHashCodeTest5()
        {
            int hash1 = "Hallo, dies ist Text.".GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);
            int hash2 = "hallodiesisttext".GetPersistentHashCode(HashType.OrdinalIgnoreCase);

            Assert.AreEqual(hash1, hash2);
        }


        [TestMethod()]
        public void GetStableHashCodeTest6()
        {
            const string s = "Hallo, dies ist Text.";
            int hash1 = s.GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);
            int hash2 = s.AsSpan().GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);
            int hash3 = new StringBuilder().Append(s).GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);

            Assert.AreEqual(hash1, hash2);
            Assert.AreEqual(hash1, hash3);
        }

        [TestMethod()]
        public void GetStableHashCodeTest7()
        {
            const string s = "Hallo, dies ist Text.";
            int hash1 = s.GetPersistentHashCode(HashType.OrdinalIgnoreCase);
            int hash2 = s.AsSpan().GetPersistentHashCode(HashType.OrdinalIgnoreCase);
            int hash3 = new StringBuilder().Append(s).GetPersistentHashCode(HashType.OrdinalIgnoreCase);

            Assert.AreEqual(hash1, hash2);
            Assert.AreEqual(hash1, hash3);
        }

        [TestMethod()]
        public void GetStableHashCodeTest8()
        {
            const string s = "Hallo, dies ist Text.";
            int hash1 = s.GetPersistentHashCode(HashType.Ordinal);
            int hash2 = s.AsSpan().GetPersistentHashCode(HashType.Ordinal);
            int hash3 = new StringBuilder().Append(s).GetPersistentHashCode(HashType.Ordinal);

            Assert.AreEqual(hash1, hash2);
            Assert.AreEqual(hash1, hash3);
        }
    }
}