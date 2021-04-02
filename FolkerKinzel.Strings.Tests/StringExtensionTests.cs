using Microsoft.VisualStudio.TestTools.UnitTesting;
using FolkerKinzel.Strings;
using System;
using System.Collections.Generic;
using System.Text;

namespace FolkerKinzel.Strings.Tests
{
    [TestClass()]
    public class StringExtensionTests
    {
        [TestMethod()]
        public void GetPersistentHashCodeTest1()
        {
            int hash1 = string.Empty.GetPersistentHashCode(HashType.Ordinal);
            int hash2 = "".GetPersistentHashCode(HashType.Ordinal);

            Assert.AreEqual(hash1, hash2);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPersistentHashCodeTest2()
        {
            string? s = null;

            _ = s!.GetPersistentHashCode(HashType.Ordinal);
        }


        [TestMethod()]
        public void GetPersistentHashCodeTest3()
        {
            int hash1 = "Hallo".GetPersistentHashCode(HashType.OrdinalIgnoreCase);
            int hash2 = "hallo".GetPersistentHashCode(HashType.OrdinalIgnoreCase);

            Assert.AreEqual(hash1, hash2);
        }


        [TestMethod()]
        public void GetPersistentHashCodeTest4()
        {
            int hash1 = "Hallo".GetPersistentHashCode(HashType.Ordinal);
            int hash2 = "hallo".GetPersistentHashCode(HashType.Ordinal);

            Assert.AreNotEqual(hash1, hash2);
        }


        [TestMethod()]
        public void GetPersistentHashCodeTest5()
        {
            int hash1 = "Hallo, dies ist Text.".GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);
            int hash2 = "hallodiesisttext".GetPersistentHashCode(HashType.OrdinalIgnoreCase);

            Assert.AreEqual(hash1, hash2);
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPersistentHashCodeTest6()
        {
            string? s = null;
            _ = s!.GetPersistentHashCode(HashType.AlphaNumericIgnoreCase);
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void GetPersistentHashCodeTest7() => _ = string.Empty.GetPersistentHashCode((HashType)4711);
    }
}