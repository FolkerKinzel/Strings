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
        [ExpectedException(typeof(NullReferenceException))]
        public void GetStableHashCodeTest2()
        {
            string? s = null;

            s!.GetStableHashCode(HashType.Ordinal);
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
            int hash1 = "Hallo, dies ist Text.".GetStableHashCode(HashType.AlphaNumericNoCase);
            int hash2 = "hallodiesisttext".GetStableHashCode(HashType.OrdinalIgnoreCase);

            Assert.AreEqual(hash1, hash2);
        }
    }
}