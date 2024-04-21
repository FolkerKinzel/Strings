using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Intls.Tests;

[TestClass]
public class NullReferenceExceptionTests
{
    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void ThrowIfNullTest1() => _NullReferenceException.ThrowIfNull(null, "para");

    [TestMethod]
    public void ThrowIfNullTest2() => _NullReferenceException.ThrowIfNull("", "para");
}
