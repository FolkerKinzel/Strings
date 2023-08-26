using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolkerKinzel.Strings.Intls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Tests.Intls;

[TestClass]
public class Utf8ValidatorTests
{
    [TestMethod]
    public void IsUtf8Test1()
    {
        const string test = "ABCäöü123 xyz";
        var bytes = Encoding.UTF8.GetBytes(test);

        using var mem = new MemoryStream(bytes);
        var validator = new Utf8Validator();
        Assert.IsTrue(validator.IsUtf8(mem, -1, false));

    }
}
