using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Tests
{
    [TestClass]
    public class TextEncodingConverterTests
    {
        [DataTestMethod]
        [DataRow(null, 65001)]
        [DataRow("iso-8859-1", 28591)]
        [DataRow("ISO-8859-1", 28591)]
        [DataRow("unBekannt", 65001)]
        public void GetEncodingTest1(string? input, int codePage)
        {
            Encoding enc = TextEncodingConverter.GetEncoding(input);
            Assert.AreEqual(codePage, enc.CodePage);
            Assert.IsNotInstanceOfType(enc.EncoderFallback, EncoderFallback.ExceptionFallback.GetType());
            Assert.IsNotInstanceOfType(enc.DecoderFallback.GetType(), DecoderFallback.ExceptionFallback.GetType());
        }

        [DataTestMethod]
        [DataRow(null, 65001)]
        [DataRow("iso-8859-1", 28591)]
        [DataRow("ISO-8859-1", 28591)]
        [DataRow("unBekannt", 65001)]
        public void GetEncodingTest2(string? input, int codePage)
        {
            Encoding enc = TextEncodingConverter.GetEncoding(input, EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback);
            Assert.AreEqual(codePage, enc.CodePage);
            Assert.IsInstanceOfType(enc.EncoderFallback, EncoderFallback.ExceptionFallback.GetType());
            Assert.IsInstanceOfType(enc.DecoderFallback, DecoderFallback.ExceptionFallback.GetType());
        }

        [DataTestMethod]
        [DataRow(65001)]
        [DataRow(28591)]
        public void GetEncodingTest3(int codePage)
        {
            Encoding enc = TextEncodingConverter.GetEncoding(codePage);
            Assert.AreEqual(codePage, enc.CodePage);
            Assert.IsNotInstanceOfType(enc.EncoderFallback, EncoderFallback.ExceptionFallback.GetType());
            Assert.IsNotInstanceOfType(enc.DecoderFallback.GetType(), DecoderFallback.ExceptionFallback.GetType());
        }

        [DataTestMethod]
        [DataRow(65001)]
        [DataRow(28591)]
        public void GetEncodingTest4(int codePage)
        {
            Encoding enc = TextEncodingConverter.GetEncoding(codePage, EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback);
            Assert.AreEqual(codePage, enc.CodePage);
            Assert.IsInstanceOfType(enc.EncoderFallback, EncoderFallback.ExceptionFallback.GetType());
            Assert.IsInstanceOfType(enc.DecoderFallback, DecoderFallback.ExceptionFallback.GetType());
        }

        [DataTestMethod]
        [DataRow(-17)]
        [DataRow(int.MaxValue)]
        [DataRow(42)]
        public void GetEncodingTest7(int codePage)
        {
            Encoding enc = TextEncodingConverter.GetEncoding(codePage);
            Assert.AreEqual(65001, enc.CodePage);
            Assert.IsNotInstanceOfType(enc.EncoderFallback, EncoderFallback.ExceptionFallback.GetType());
            Assert.IsNotInstanceOfType(enc.DecoderFallback.GetType(), DecoderFallback.ExceptionFallback.GetType());
        }

        [DataTestMethod]
        [DataRow(-17)]
        [DataRow(int.MaxValue)]
        [DataRow(42)]
        public void GetEncodingTest8(int codePage)
        {
            Encoding enc = TextEncodingConverter.GetEncoding(codePage, EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback);
            Assert.AreEqual(65001, enc.CodePage);
            Assert.IsInstanceOfType(enc.EncoderFallback, EncoderFallback.ExceptionFallback.GetType());
            Assert.IsInstanceOfType(enc.DecoderFallback, DecoderFallback.ExceptionFallback.GetType());
        }

        [TestMethod]
        public void GetEncodingTest5()
        {
            const int defaultCodePage = 1252;
            Encoding enc = TextEncodingConverter.GetEncoding(0);
            Assert.AreEqual(defaultCodePage, enc.CodePage);
            Assert.IsNotInstanceOfType(enc.EncoderFallback, EncoderFallback.ExceptionFallback.GetType());
            Assert.IsNotInstanceOfType(enc.DecoderFallback.GetType(), DecoderFallback.ExceptionFallback.GetType());
        }

        [TestMethod]
        public void GetEncodingTest6()
        {
            const int defaultCodePage = 1252;
            Encoding enc = TextEncodingConverter.GetEncoding(0, EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback);
            Assert.AreEqual(defaultCodePage, enc.CodePage);
            Assert.IsInstanceOfType(enc.EncoderFallback, EncoderFallback.ExceptionFallback.GetType());
            Assert.IsInstanceOfType(enc.DecoderFallback, DecoderFallback.ExceptionFallback.GetType());
        }
    }
}
