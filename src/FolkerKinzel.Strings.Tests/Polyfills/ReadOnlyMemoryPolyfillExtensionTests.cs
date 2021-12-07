
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
Nach:
using System.Linq;
using System.Text;
using System.Threading;
*/

/* Nicht gemergte Änderung aus Projekt "FolkerKinzel.Strings.Tests (net45)"
Vor:
using System.Collections.Generic;
using System.Linq;
using System.Text;
Nach:
using System.Linq;
using System.Text;
using System.Threading;
*/

/* Nicht gemergte Änderung aus Projekt "FolkerKinzel.Strings.Tests (netcoreapp2.1)"
Vor:
using System.Collections.Generic;
using System.Linq;
using System.Text;
Nach:
using System.Linq;
using System.Text;
using System.Threading;
*/

/* Nicht gemergte Änderung aus Projekt "FolkerKinzel.Strings.Tests (netcoreapp3.1)"
Vor:
using System.Collections.Generic;
using System.Linq;
using System.Text;
Nach:
using System.Linq;
using System.Text;
using System.Threading;
*/
using Microsoft.VisualStudio.TestTools.
/* Nicht gemergte Änderung aus Projekt "FolkerKinzel.Strings.Tests (net5.0)"
Vor:
using System.Globalization;
using System.Threading;
Nach:
using FolkerKinzel.Strings.Polyfills;
using Microsoft.VisualStudio.TestTools.UnitTesting;
*/

/* Nicht gemergte Änderung aus Projekt "FolkerKinzel.Strings.Tests (net45)"
Vor:
using System.Globalization;
using System.Threading;
Nach:
using FolkerKinzel.Strings.Polyfills;
using Microsoft.VisualStudio.TestTools.UnitTesting;
*/

/* Nicht gemergte Änderung aus Projekt "FolkerKinzel.Strings.Tests (netcoreapp2.1)"
Vor:
using System.Globalization;
using System.Threading;
Nach:
using FolkerKinzel.Strings.Polyfills;
using Microsoft.VisualStudio.TestTools.UnitTesting;
*/

/* Nicht gemergte Änderung aus Projekt "FolkerKinzel.Strings.Tests (netcoreapp3.1)"
Vor:
using System.Globalization;
using System.Threading;
Nach:
using FolkerKinzel.Strings.Polyfills;
using Microsoft.VisualStudio.TestTools.UnitTesting;
*/
UnitTesting;

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