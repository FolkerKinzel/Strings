
/* Nicht gemergte Änderung aus Projekt "FolkerKinzel.Strings.Tests (net5.0)"
Vor:
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FolkerKinzel.Strings.Polyfills;
Nach:
using System;
using System.Collections.Generic;
*/

/* Nicht gemergte Änderung aus Projekt "FolkerKinzel.Strings.Tests (net45)"
Vor:
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FolkerKinzel.Strings.Polyfills;
Nach:
using System;
using System.Collections.Generic;
*/

/* Nicht gemergte Änderung aus Projekt "FolkerKinzel.Strings.Tests (netcoreapp2.1)"
Vor:
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FolkerKinzel.Strings.Polyfills;
Nach:
using System;
using System.Collections.Generic;
*/

/* Nicht gemergte Änderung aus Projekt "FolkerKinzel.Strings.Tests (netcoreapp3.1)"
Vor:
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FolkerKinzel.Strings.Polyfills;
Nach:
using System;
using System.Collections.Generic;
*/
using System.Linq;

/* Nicht gemergte Änderung aus Projekt "FolkerKinzel.Strings.Tests (net5.0)"
Vor:
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
Nach:
using System.Text;
using System.Threading.Tasks;
using FolkerKinzel.Strings.Polyfills;
using Microsoft.VisualStudio.Threading.Tasks;
*/

/* Nicht gemergte Änderung aus Projekt "FolkerKinzel.Strings.Tests (net45)"
Vor:
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
Nach:
using System.Text;
using System.Threading.Tasks;
using FolkerKinzel.Strings.Polyfills;
using Microsoft.VisualStudio.Threading.Tasks;
*/

/* Nicht gemergte Änderung aus Projekt "FolkerKinzel.Strings.Tests (netcoreapp2.1)"
Vor:
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
Nach:
using System.Text;
using System.Threading.Tasks;
using FolkerKinzel.Strings.Polyfills;
using Microsoft.VisualStudio.Threading.Tasks;
*/

/* Nicht gemergte Änderung aus Projekt "FolkerKinzel.Strings.Tests (netcoreapp3.1)"
Vor:
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
Nach:
using System.Text;
using System.Threading.Tasks;
using FolkerKinzel.Strings.Polyfills;
using Microsoft.VisualStudio.Threading.Tasks;
*/
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Polyfills.Tests
{
    [TestClass()]
    public class StringBuilderPolyfillExtensionTests
    {
        [TestMethod]
        public void InsertTest1()
        {
            const string test = "test";
            var sb1 = new StringBuilder();
            var sb2 = new StringBuilder();

            _ = sb1.Insert(0, test.AsSpan());
            _ = sb2.Insert(0, test);

            Assert.AreEqual(sb1.ToString(), sb2.ToString());

            _ = sb1.Insert(2, test.AsSpan());
            _ = sb2.Insert(2, test);

            Assert.AreEqual(sb1.ToString(), sb2.ToString());

            _ = sb1.Insert(sb1.Length, test.AsSpan());
            _ = sb2.Insert(sb2.Length, test);

            Assert.AreEqual(sb1.ToString(), sb2.ToString());
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void InsertTest2()
        {
            StringBuilder? sb = null;
            _ = sb!.Insert(0, ReadOnlySpan<char>.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertTest3()
        {
            var sb = new StringBuilder();
            _ = sb.Insert(-1, ReadOnlySpan<char>.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertTest4()
        {
            var sb = new StringBuilder();
            _ = sb.Insert(1, ReadOnlySpan<char>.Empty);
        }

        [TestMethod]
        public void AppendStringBuilderTest2()
        {
            const string test = "test";
            var sb1 = new StringBuilder();
            var sb2 = new StringBuilder(test);

            Assert.AreEqual(sb1, sb1.Append(sb2, 0, sb2.Length));
            Assert.AreEqual(test, sb1.ToString());
        }

        [TestMethod]
        public void AppendStringBuilderTest12()
        {
            const string test = "test";
            var sb1 = new StringBuilder();
            var sb2 = new StringBuilder(test);

            Assert.AreEqual(sb1, sb1.Append(sb2, 1, 2));
            Assert.AreEqual("es", sb1.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AppendStringBuilderTest3()
        {
            const string test = "test";
            var sb1 = new StringBuilder();
            var sb2 = new StringBuilder(test);

            Assert.AreEqual(sb1, sb1.Append(sb2, -17, sb2.Length));
            Assert.AreEqual(test, sb1.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AppendStringBuilderTest4()
        {
            var sb1 = new StringBuilder();
            StringBuilder? sb2 = null;
            Assert.AreEqual(sb1, sb1.Append(sb2, -17, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AppendStringBuilderTest5()
        {
            var sb1 = new StringBuilder();
            StringBuilder? sb2 = null;

            Assert.AreEqual(sb1, sb1.Append(sb2, 0, -1));
        }

        [TestMethod]
        public void AppendStringBuilderTest6()
        {
            var sb1 = new StringBuilder();
            StringBuilder? sb2 = null;

            Assert.AreEqual(sb1, sb1.Append(sb2, 0, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AppendStringBuilderTest7()
        {
            var sb1 = new StringBuilder();
            StringBuilder? sb2 = null;

            Assert.AreEqual(sb1, sb1.Append(sb2, 0, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AppendStringBuilderTest8()
        {
            var sb1 = new StringBuilder();
            var sb2 = new StringBuilder();

            Assert.AreEqual(sb1, sb1.Append(sb2, 0, 4711));
        }

        [TestMethod]
        public void AppendStringBuilderTest9()
        {
            var sb1 = new StringBuilder();
            var sb2 = new StringBuilder();

            Assert.AreEqual(sb1, sb1.Append(sb2, 4711, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AppendStringBuilderTest10()
        {
            var sb1 = new StringBuilder();
            var sb2 = new StringBuilder();

            Assert.AreEqual(sb1, sb1.Append(sb2, 4711, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void AppendStringBuilderTest11()
        {
            StringBuilder? sb1 = null;
            var sb2 = new StringBuilder();

            _ = sb1!.Append(sb2, 4711, 1);
        }

        [TestMethod()]
        public void AppendTest1()
        {
            var sb = new StringBuilder();

            string test = "Test";

            ReadOnlySpan<char> span = test.AsSpan();

            _ = sb.Append(span);

            Assert.AreEqual(test, sb.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void AppendTest2()
        {
            StringBuilder? sb = null;
            _ = sb!.Append(ReadOnlySpan<char>.Empty);
        }
    }
}