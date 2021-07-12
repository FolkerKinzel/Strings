using Microsoft.VisualStudio.TestTools.UnitTesting;
using FolkerKinzel.Strings.Polyfills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkerKinzel.Strings.Polyfills.Tests
{
    [TestClass()]
    public class StringBuilderPolyfillExtensionTests
    {
        [TestMethod()]
        public void AppendTest1()
        {
            var sb = new StringBuilder();

            string test = "Test";

            ReadOnlySpan<char> span = test.AsSpan();

            _ = sb.Append(span);

            Assert.AreEqual(test, sb.ToString());
        }
    }
}