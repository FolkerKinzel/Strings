using Microsoft.VisualStudio.TestTools.UnitTesting;
using FolkerKinzel.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkerKinzel.Strings.Tests
{
    [TestClass()]
    public class StringHelperTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateTest1() => _ = StringHelper.Create(0, "", null!);

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTest2() => _ = StringHelper.Create(-1, "", (span, tState) => { });

        [TestMethod()]
        public void CreateTest3() => Assert.AreEqual(0, StringHelper.Create(0, "", (span, tState) => { }).Length);

        [TestMethod()]
        public void CreateTest4()
        {
            Assert.AreEqual("HELL",  StringHelper.Create(4, "hello",
                (span, tState) => 
                {
                    for (int i = 0; i < span.Length; i++)
                    {
                        span[i] = tState[i].ToUpperInvariant();
                    }
                }));
        }

        [TestMethod()]
        public void CreateTest5()
        {
            const int length = Const.ShortString + 5;
            Assert.AreEqual(new string('x', length),  StringHelper.Create(length, "",
                (span, tState) => 
                {
                    for (int i = 0; i < span.Length; i++)
                    {
                        span[i] = 'x';
                    }
                }));
        }
    }
}