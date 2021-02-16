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
            int hash1 = string.Empty.GetStableHashCode(HashType.Ordinal);
            int hash2 = "".GetStableHashCode(HashType.Ordinal);

            Assert.AreEqual(hash1, hash2);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetStableHashCodeTest2()
        {
            string? s = null;

            _ = s!.GetStableHashCode(HashType.Ordinal);
        }


        [TestMethod()]
        public void GetStableHashCodeTest3()
        {
            int hash1 = "Hallo".GetStableHashCode(HashType.OrdinalIgnoreCase);
            int hash2 = "hallo".GetStableHashCode(HashType.OrdinalIgnoreCase);

            Assert.AreEqual(hash1, hash2);
        }


        [TestMethod()]
        public void GetStableHashCodeTest4()
        {
            int hash1 = "Hallo".GetStableHashCode(HashType.Ordinal);
            int hash2 = "hallo".GetStableHashCode(HashType.Ordinal);

            Assert.AreNotEqual(hash1, hash2);
        }


        [TestMethod()]
        public void GetStableHashCodeTest5()
        {
            int hash1 = "Hallo, dies ist Text.".GetStableHashCode(HashType.AlphaNumericIgnoreCase);
            int hash2 = "hallodiesisttext".GetStableHashCode(HashType.OrdinalIgnoreCase);

            Assert.AreEqual(hash1, hash2);
        }


        [TestMethod()]
        public void GetStableHashCodeTest6()
        {
            const string s = "Hallo, dies ist Text.";
            int hash1 = s.GetStableHashCode(HashType.AlphaNumericIgnoreCase);
            int hash2 = s.AsSpan().GetStableHashCode(HashType.AlphaNumericIgnoreCase);
            int hash3 = new StringBuilder().Append(s).GetStableHashCode(HashType.AlphaNumericIgnoreCase);

            Assert.AreEqual(hash1, hash2);
            Assert.AreEqual(hash1, hash3);
        }

        [TestMethod()]
        public void GetStableHashCodeTest7()
        {
            const string s = "Hallo, dies ist Text.";
            int hash1 = s.GetStableHashCode(HashType.OrdinalIgnoreCase);
            int hash2 = s.AsSpan().GetStableHashCode(HashType.OrdinalIgnoreCase);
            int hash3 = new StringBuilder().Append(s).GetStableHashCode(HashType.OrdinalIgnoreCase);

            Assert.AreEqual(hash1, hash2);
            Assert.AreEqual(hash1, hash3);
        }

        [TestMethod()]
        public void GetStableHashCodeTest8()
        {
            const string s = "Hallo, dies ist Text.";
            int hash1 = s.GetStableHashCode(HashType.Ordinal);
            int hash2 = s.AsSpan().GetStableHashCode(HashType.Ordinal);
            int hash3 = new StringBuilder().Append(s).GetStableHashCode(HashType.Ordinal);

            Assert.AreEqual(hash1, hash2);
            Assert.AreEqual(hash1, hash3);
        }
    }
}