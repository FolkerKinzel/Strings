using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FolkerKinzel.Strings.Tests
{
    [TestClass]
    public class CharExtensionTests
    {
        [TestMethod]
        public void IsDecimalDigitTest1()
        {
            for (int i = 0; i < 10; i++)
            {
                Assert.IsTrue(i.ToString()[0].IsDecimalDigit());
            }

            Assert.IsFalse(((char)((int)'0' - 1)).IsDecimalDigit());
            Assert.IsFalse(((char)((int)'9' + 1)).IsDecimalDigit());
        }

        [DataTestMethod]
        [DataRow('0', 0, true)]
        [DataRow('9', 9, true)]
        [DataRow('A', 10, true)]
        [DataRow('a', 10, true)]
        [DataRow('F', 15, true)]
        [DataRow('f', 15, true)]
        [DataRow('G', null, false)]
        [DataRow('g', null, false)]
        public void TryParseHexDigitTest(char input, int? expected, bool result)
        {
            Assert.AreEqual(result, input.TryParseHexDigit(out int? got));
            Assert.AreEqual(expected, got);
        }

        [DataTestMethod]
        [DataRow('0', 0)]
        [DataRow('9', 9)]
        [DataRow('A', 10)]
        [DataRow('a', 10)]
        [DataRow('F', 15)]
        [DataRow('f', 15)]
        public void ParseHexDigitTest1(char input, int? expected)
            => Assert.AreEqual(expected, input.ParseHexDigit());

        [DataTestMethod]
        [DataRow('G')]
        [DataRow('g')]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseHexDigitTest2(char input)
            => _ = input.ParseHexDigit();


        [DataTestMethod]
        [DataRow('0', 0, true)]
        [DataRow('9', 9, true)]
        [DataRow('A', null, false)]
        [DataRow('a', null, false)]
        [DataRow('F', null, false)]
        [DataRow('f', null, false)]
        [DataRow('G', null, false)]
        [DataRow('g', null, false)]
        public void TryParseDecimalDigitTest(char input, int? expected, bool result)
        {
            Assert.AreEqual(result, input.TryParseDecimalDigit(out int? got));
            Assert.AreEqual(expected, got);
        }

        [DataTestMethod]
        [DataRow('0', 0)]
        [DataRow('9', 9)]
        public void ParseDecimalDigitTest1(char input, int? expected)
            => Assert.AreEqual(expected, input.ParseDecimalDigit());

        [DataTestMethod]
        [DataRow('A')]
        [DataRow('a')]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseDecimalDigitTest2(char input)
            => _ = input.ParseDecimalDigit();


        [DataTestMethod]
        [DataRow('0', 0, true)]
        [DataRow('1', 1, true)]
        [DataRow('A', null, false)]
        [DataRow('a', null, false)]
        [DataRow('2', null, false)]
        [DataRow('2', null, false)]
        public void TryParseBinaryDigitTest(char input, int? expected, bool result)
        {
            Assert.AreEqual(result, input.TryParseBinaryDigit(out int? got));
            Assert.AreEqual(expected, got);
        }


        [DataTestMethod]
        [DataRow('0', 0)]
        [DataRow('1', 1)]
        public void ParseBinaryDigitTest1(char input, int expected)
            => Assert.AreEqual(expected, input.ParseBinaryDigit());


        [DataTestMethod]
        [DataRow('2')]
        [DataRow('a')]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseBinaryDigitTest2(char input)
            => _ = input.ParseBinaryDigit();


        [TestMethod]
        public void IsControlTest()
        {
            for (char c = char.MinValue; c < char.MaxValue; c++)
            {
                Assert.AreEqual(char.IsControl(c), c.IsControl());
            }
        }

        [TestMethod]
        public void IsDigitTest()
        {
            for (char c = char.MinValue; c < char.MaxValue; c++)
            {
                Assert.AreEqual(char.IsDigit(c), c.IsDigit());
            }
        }


        [TestMethod]
        public void IsHighSurrogateTest()
        {
            for (char c = char.MinValue; c < char.MaxValue; c++)
            {
                Assert.AreEqual(char.IsHighSurrogate(c), c.IsHighSurrogate());
            }
        }


        [TestMethod]
        public void IsLowSurrogateTest()
        {
            for (char c = char.MinValue; c < char.MaxValue; c++)
            {
                Assert.AreEqual(char.IsLowSurrogate(c), c.IsLowSurrogate());
            }
        }


        [TestMethod]
        public void IsSurrogateTest()
        {
            for (char c = char.MinValue; c < char.MaxValue; c++)
            {
                Assert.AreEqual(char.IsSurrogate(c), c.IsSurrogate());
            }
        }


        [TestMethod]
        public void IsLetterTest()
        {
            for (char c = char.MinValue; c < char.MaxValue; c++)
            {
                Assert.AreEqual(char.IsLetter(c), c.IsLetter());
            }
        }


        [TestMethod]
        public void IsLetterOrDigitTest()
        {
            for (char c = char.MinValue; c < char.MaxValue; c++)
            {
                Assert.AreEqual(char.IsLetterOrDigit(c), c.IsLetterOrDigit());
            }
        }

        [TestMethod]
        public void IsLowerTest()
        {
            for (char c = char.MinValue; c < char.MaxValue; c++)
            {
                Assert.AreEqual(char.IsLower(c), c.IsLower());
            }
        }


        [TestMethod]
        public void IsUpperTest()
        {
            for (char c = char.MinValue; c < char.MaxValue; c++)
            {
                Assert.AreEqual(char.IsUpper(c), c.IsUpper());
            }
        }


        [TestMethod]
        public void IsNumberTest()
        {
            for (char c = char.MinValue; c < char.MaxValue; c++)
            {
                Assert.AreEqual(char.IsNumber(c), c.IsNumber());
            }
        }


        [TestMethod]
        public void IsPunctuationTest()
        {
            for (char c = char.MinValue; c < char.MaxValue; c++)
            {
                Assert.AreEqual(char.IsPunctuation(c), c.IsPunctuation());
            }
        }


        [TestMethod]
        public void IsSeparatorTest()
        {
            for (char c = char.MinValue; c < char.MaxValue; c++)
            {
                Assert.AreEqual(char.IsSeparator(c), c.IsSeparator());
            }
        }


        [TestMethod]
        public void IsSymbolTest()
        {
            for (char c = char.MinValue; c < char.MaxValue; c++)
            {
                Assert.AreEqual(char.IsSymbol(c), c.IsSymbol());
            }
        }

        [TestMethod]
        public void IsWhiteSpaceTest()
        {
            for (char c = char.MinValue; c < char.MaxValue; c++)
            {
                Assert.AreEqual(char.IsWhiteSpace(c), c.IsWhiteSpace());
            }
        }


        [TestMethod]
        public void ToLowerInvariantTest()
        {
            for (char c = char.MinValue; c < char.MaxValue; c++)
            {
                Assert.AreEqual(char.ToLowerInvariant(c), c.ToLowerInvariant());
            }
        }


        [TestMethod]
        public void ToUpperInvariantTest()
        {
            for (char c = char.MinValue; c < char.MaxValue; c++)
            {
                Assert.AreEqual(char.ToUpperInvariant(c), c.ToUpperInvariant());
            }
        }

        [DataTestMethod]
        [DataRow(' ', false)]
        [DataRow('a', false)]
        [DataRow('\r'    , true)]
 		[DataRow('\n'    , true)]
 		[DataRow('\u000B', true)]
 		[DataRow('\u000C', true)]
 		[DataRow('\u0085', true)]
 		[DataRow('\u2028', true)]
 		[DataRow('\u2029', true)]
        public void IsNewLineTest(char input, bool expected)
            => Assert.AreEqual(expected, input.IsNewLine());


    }
}
