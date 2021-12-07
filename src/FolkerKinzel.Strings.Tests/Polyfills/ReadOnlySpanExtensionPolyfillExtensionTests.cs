
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
using Microsoft.VisualStudio.TestTools.Tasks;
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
using Microsoft.VisualStudio.TestTools.Tasks;
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
using Microsoft.VisualStudio.TestTools.Tasks;
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
using Microsoft.VisualStudio.TestTools.Tasks;
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Polyfills.Tests
{
    [TestClass()]
    public class ReadOnlySpanExtensionPolyfillExtensionTests
    {
        [TestMethod()]
        public void LastIndexOfTest1() => Assert.AreEqual(-1, "test".AsSpan().LastIndexOf("bla", 3, 4, StringComparison.Ordinal));

        [TestMethod()]
        public void LastIndexOfTest2() => Assert.AreEqual(-1, "".AsSpan().LastIndexOf("bla", -1, 0, StringComparison.Ordinal));

        [TestMethod()]
        public void LastIndexOfTest3() => Assert.AreEqual(-1, "".AsSpan().LastIndexOf("bla", 0, 1, StringComparison.Ordinal));

        [TestMethod()]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LastIndexOfTest4()
            => Assert.AreEqual(-1, "".AsSpan().LastIndexOf("bla", 0, 2, StringComparison.Ordinal));

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LastIndexOfTest5() => _ = "".AsSpan().LastIndexOf("bla", -2, 0, StringComparison.Ordinal);

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LastIndexOfTest6() => _ = "".AsSpan().LastIndexOf("bla", 1, 0, StringComparison.Ordinal);

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LastIndexOfTest7() => _ = "test".AsSpan().LastIndexOf("bla", -1, 0, StringComparison.Ordinal);

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LastIndexOfTest8() => _ = "test".AsSpan().LastIndexOf("bla", 5, 0, StringComparison.Ordinal);

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void LastIndexOfTest9() => _ = "test".AsSpan().LastIndexOf("bla", 3, 1, (StringComparison)4711);

        [TestMethod()]
        //[ExpectedException(typeof(ArgumentNullException))]
        public void LastIndexOfTest10() => _ = "test".AsSpan().LastIndexOf((string?)null, 3, 1, StringComparison.Ordinal);
    }
}