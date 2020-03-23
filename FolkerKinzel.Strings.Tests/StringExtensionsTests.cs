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
            int hash1 = string.Empty.GetStableHashCode();
            int hash2 = "".GetStableHashCode();

            Assert.AreEqual(hash1, hash2);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetStableHashCodeTest2()
        {
            string? s = null;

            s!.GetStableHashCode();
        }


        [TestMethod()]
        public void GetStableHashCodeTest3()
        {
            int hash1 = "Hallo".GetStableHashCode(true);
            int hash2 = "hallo".GetStableHashCode(true);

            Assert.AreEqual(hash1, hash2);
        }


        [TestMethod()]
        public void GetStableHashCodeTest4()
        {
            int hash1 = "Hallo".GetStableHashCode();
            int hash2 = "hallo".GetStableHashCode();

            Assert.AreNotEqual(hash1, hash2);
        }
    }
}