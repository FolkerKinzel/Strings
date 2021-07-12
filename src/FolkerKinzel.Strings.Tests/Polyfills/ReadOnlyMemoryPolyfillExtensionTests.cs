using Microsoft.VisualStudio.TestTools.UnitTesting;
using FolkerKinzel.Strings.Polyfills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace FolkerKinzel.Strings.Polyfills.Tests
{
    [TestClass()]
    public class ReadOnlyMemoryPolyfillExtensionTests
    {
        [TestMethod()]
        public void TrimTest()
        {
            string test = "  Test ";
            ReadOnlyMemory<char> memory = test.AsMemory();
            Assert.AreEqual(test.Trim(), memory.Trim().ToString());
        }

        [TestMethod()]
        public void TrimStartTest()
        {
            string test = "  Test ";
            ReadOnlyMemory<char> memory = test.AsMemory();
            Assert.AreEqual(test.TrimStart(), memory.TrimStart().ToString());
        }

        [TestMethod()]
        public void TrimEndTest()
        {
            string test = "  Test ";
            ReadOnlyMemory<char> memory = test.AsMemory();
            Assert.AreEqual(test.TrimEnd(), memory.TrimEnd().ToString());
        }
    }
}